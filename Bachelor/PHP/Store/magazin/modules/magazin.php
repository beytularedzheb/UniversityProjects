<?php
function browseShops($search = '', $msg = '') {

    global $DBH, $tpl, $msgArray;
    // ako $search ne e prazna, znachi potrebiteliat e vyvel neshto po koeto da tyrsi
    if (!empty($search)) {
        $WHERE_SEARCH = "((m.NameM LIKE '%$search%') OR (m.Boss LIKE '%$search%') OR (m.AdresM LIKE '%$search%'))";
        $tpl->set('search', $search);
    } else {
        // a ako e prazna ne se tyrsi po nishto i zatova sled where ima (1), koeto vse edno oznachava che niama where
        $WHERE_SEARCH = '(1)';
        $tpl->set('search', '');
    }
    $query = 'SELECT m.CodM, m.Type, m.NameM, m.AdresM, m.Boss, f.NameF FROM magazins m, firms f WHERE m.CodF = f.CodF AND ' . $WHERE_SEARCH;
    // izpylniavame zaiavkata
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame ispylnenieto na programata
    }
    $tpl->set('numberOfShops', mysql_num_rows($result));
    $data = '';
    $i = 0;
    while ($row = mysql_fetch_assoc($result)) {
        //zamestvame etiketite v _browse_produkti_row
        foreach ($row as $key => $value) {
            $tpl->set($key, $value);
        }
        // i tuk moje vmesto da se pishe set() 2 pyti da se polzva cikyl - ama za dva etiketa ...
        if ($i % 2) {
            $tpl->set('bgColor', '#F2F2F2');
        } else {
            $tpl->set('bgColor', '#E0E0E0');
        }
        $i++;
        // obrabotva i izvlicha obrabotenia HTML kod za tekushtia red
        $data = $data . $tpl->fetch('_browse_shop_row.html');
    }
    $tpl->set('tableShops', $data);
    if ($i == 0) {
        $tpl->set('tableShops', $msgArray['br_no_such']);
    }
    if (!empty($msg)) {
        $tpl->set('msg', $msgArray[$msg]);
    } else {
        $tpl->set('msg', '');
    }
    $tpl->set('content', $tpl->fetch('_browse_shop.html'));
    print $tpl->fetch('_main_template.html');
}

function addShop($formData = '', $msg='', $PK='') {
    global $DBH, $tpl, $msgArray;
    if (!empty($msg)) {
        $tpl->set('errorMsg', $msgArray[$msg]);
    } else {
        $tpl->set('errorMsg', '');
    }
//pROVERKA dali ima popylnenie danni
    if (!empty($formData)) {
        foreach ($formData as $k => $v) {
            $tpl->set($k, $v);
        }
    } else {
        $tpl->set('CodM', '');
        $tpl->set('Type', '');
        $tpl->set('NameM', '');
		$tpl->set('AdresM', '');
		$tpl->set('Boss', '');
		$tpl->set('CodF', '');
    }
	
	//izvejdane na firmite
    $CodF = '';
    $query = "Select * FROM firms;";
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame izpylnenieto na programata
    }
    while ($row = mysql_fetch_assoc($result)) {
        $tpl->set('opValue', $row['CodF']);
        $tpl->set('opTitle', $row['NameF']);
        if (!empty($formData['CodF']) and ($formData['CodF'] == $row['CodF'])) {
            $tpl->set('opSelected', 'selected');
        } else {
            $tpl->set('opSelected', '');
        }
        $CodF.=$tpl->fetch('_select_box.html');
    }
    $tpl->set('CodF', $CodF);
	
    $tpl->set('sid', $PK);
    $tpl->set('cmd', 'addEditShop');
    $tpl->set('content', $tpl->fetch('_addEdit_shop_screen.html'));
    print $tpl->fetch('_main_template.html');
}

function addEditShop($FormData='', $PK='') {
    $insertFields = ''; //запазваме полетата в които ще въвеждаме данни
    $insertValues = ''; //запазваме данните за полетата
    if (!empty($PK)) {
        $updateFields = '';
        foreach ($FormData as $key => $value) {
            $updateFields = $updateFields . ',' . $key . "='" . addslashes($value) . "'";
            if (empty($value)) {//проверяваме дали има въведени данни в полето
                addShop($FormData, 'empty', $PK);
                exit;
            }
        }
        $updateFields = substr($updateFields, 1);
        $query = "UPDATE magazins SET $updateFields WHERE CodM=$PK";
        $msg = 'edited';
    } else {
        foreach ($FormData as $key => $value) {
            $insertFields = $insertFields . ", $key";
            $insertValues = $insertValues . ",'" . addslashes($value) . "'";
            if (empty($value)) {
                addShop($FormData, 'empty', $PK);
                exit;
            }
        }
        $insertFields = substr($insertFields, 1);
        $insertValues = substr($insertValues, 1);
        $query = "INSERT INTO magazins($insertFields) VALUES($insertValues)";
        $msg = 'added';
    }
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame ispylnenieto na programata
    }
    browseShops('', $msg);
}

function editShop($PK='') {
    global $DBH, $tpl, $msgArray;
    $query = 'SELECT * FROM magazins WHERE CodM=' . $PK;
// izpylniavame zaiavkata
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame ispylnenieto na programata
    }
    if ($row = mysql_fetch_assoc($result)) {
        addShop($row, '', $PK);
    } else {
        browseShops('', 'edit_no_such');
    }
}

function deleteShop($PK='') {
	global $DBH;	
	if (empty($PK)){
		browseShops('', 'delete_no_such');
	}
	$query = "DELETE FROM magazins WHERE CodM = '".$PK."'";
	if (!mysql_query($query)) {
		browseShops('', 'delete_no_such');
	} else {
		browseShops('', 'deleted');
	}
}
?>