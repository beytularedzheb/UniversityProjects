<?php

function browseSales($search = '', $msg = '') {

    global $DBH, $tpl, $msgArray;
    // ako $search ne e prazna, znachi potrebiteliat e vyvel neshto po koeto da tyrsi
    if (!empty($search)) {
        $WHERE_SEARCH = "((m.NameM LIKE '%$search%') OR (mes.ImeM LIKE '%$search%'))";
        $tpl->set('search', $search);
    } else {
        // a ako e prazna ne se tyrsi po nishto i zatova sled where ima (1), koeto vse edno oznachava che niama where
        $WHERE_SEARCH = '(1)';
        $tpl->set('search', '');
    }
    $query = "SELECT m.NameM AS magName, mes.ImeM AS mesName, p.StPlan, p.StIzp, p.Id FROM prodajbi p, magazins m, meseci mes WHERE p.CodM=m.CodM AND p.CodMes=mes.CodM AND " . $WHERE_SEARCH
	. " ORDER BY p.Id;";
    // izpylniavame zaiavkata
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame ispylnenieto na programata
    }
    $tpl->set('numberOfSales', mysql_num_rows($result));
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
        $data = $data . $tpl->fetch('_browse_sales_row.html');
    }
    $tpl->set('tableSales', $data);
    if ($i == 0) {
        $tpl->set('tableSales', $msgArray['br_no_such']);
    }
    if (!empty($msg)) {
        $tpl->set('msg', $msgArray[$msg]);
    } else {
    $tpl->set('msg', '');
    }
    $tpl->set('content', $tpl->fetch('_browse_sales.html'));
    print $tpl->fetch('_main_template.html');
}

function addSale($formData = '', $msg='', $PK='') {
    global $DBH, $tpl, $msgArray;
    if (!empty($msg)) {
        $tpl->set('errorMsg', $msgArray[$msg]);
    } else {
        $tpl->set('errorMsg', '');
    }
//PROVERKA dali ima popylnenie danni
    if (!empty($formData)) {
        foreach ($formData as $k => $v) {
            $tpl->set($k, $v);
        }
    } else {
		$tpl->set('CodM', '');
		$tpl->set('CodMes', '');
        $tpl->set('StPlan', '');
		$tpl->set('StIzp', '');
    }
    //izvejdane na magazinite
    $MCode = '';
    $query = "Select * FROM magazins;";
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame izpylnenieto na programata
    }
    while ($row = mysql_fetch_assoc($result)) {
        $tpl->set('opValue', $row['CodM']);
        $tpl->set('opTitle', $row['NameM']);
        if (!empty($formData['CodM']) and ($formData['CodM'] == $row['CodM'])) {
            $tpl->set('opSelected', 'selected');
        } else {
            $tpl->set('opSelected', '');
        }
        $MCode.=$tpl->fetch('_select_box.html');
    }
    $tpl->set('CodM', $MCode);
    //izvejdane na mesecite
    $MesCode = '';
    $query = "SELECT * FROM meseci;";
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame izpylnenieto na programata
    }
    while ($row = mysql_fetch_assoc($result)) {
        $tpl->set('opValue', $row['CodM']);
        $tpl->set('opTitle', $row['ImeM']);
        if (!empty($formData['CodMes']) and ($formData['CodMes'] == $row['CodM'])) {
            $tpl->set('opSelected', ' selected');
        } else {
            $tpl->set('opSelected', '');
        }
        $MesCode.=$tpl->fetch('_select_box.html');
    }
    $tpl->set('CodMes', $MesCode);
    $tpl->set('sid', $PK);
    $tpl->set('cmd', 'addEditSale');
    $tpl->set('content', $tpl->fetch('_addEdit_sales_screen.html'));
    print $tpl->fetch('_main_template.html');
}

function addEditSale($FormData='', $PK='') {
    $insertFields = ''; //запазваме полетата в които ще въвеждаме данни
    $insertValues = ''; //запазваме данните за полетата
    if (!empty($PK)) {
        $updateFields = '';
        foreach ($FormData as $key => $value) {
            $updateFields = $updateFields . ',' . $key . "='" . addslashes($value) . "'";
            if (empty($value)) {//проверяваме дали има въведени данни в полето
                addSale($FormData, 'empty', $PK);
                exit;
            }
        }
        $updateFields = substr($updateFields, 1);
        $query = "UPDATE prodajbi SET $updateFields WHERE Id=$PK;";
        $msg = 'edited';
    } else {
        foreach ($FormData as $key => $value) {
            $insertFields = $insertFields . ", $key";
            $insertValues = $insertValues . ",'" . addslashes($value) . "'";
            if (empty($value)) {
                addSale($FormData, 'empty', $PK);
                exit;
            }
        }
        $insertFields = substr($insertFields, 1);
        $insertValues = substr($insertValues, 1);
        $query = "INSERT INTO prodajbi($insertFields) VALUES($insertValues)";
        $msg = 'added';
    }
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame ispylnenieto na programata
    }
    browseSales('', $msg);
}

function editSale($PK='') {
    global $DBH, $tpl, $msgArray;
    $query = "SELECT * FROM prodajbi WHERE Id=$PK;";
// izpylniavame zaiavkata
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame ispylnenieto na programata
    }
    if ($row = mysql_fetch_assoc($result)) {
        addSale($row, '', $PK);
    } else {
        browseSales('', 'edit_no_such');
    }
}

function deleteSale($PK='') {
	global $DBH;	
	if (empty($PK)){
		browseShops('', 'delete_no_such');
	}
	$query = "DELETE FROM prodajbi WHERE Id = '".$PK."'";
	if (!mysql_query($query)) {
		browseSales('', 'delete_no_such');
	} else {
		browseSales('', 'deleted');
	}
}
?>