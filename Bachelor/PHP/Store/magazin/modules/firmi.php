<?php
function browseFirms($search = '', $msg = '') {

    global $DBH, $tpl, $msgArray;
    // ako $search ne e prazna, znachi potrebiteliat e vyvel neshto po koeto da tyrsi
    if (!empty($search)) {
        $WHERE_SEARCH = "((NameF LIKE '%$search%') OR (Adres LIKE '%$search%'))";
        $tpl->set('search', $search);
    } else {
        // a ako e prazna ne se tyrsi po nishto i zatova sled where ima (1), koeto vse edno oznachava che niama where
        $WHERE_SEARCH = '(1)';
        $tpl->set('search', '');
    }
    $query = 'SELECT * FROM firms WHERE ' . $WHERE_SEARCH;
    // izpylniavame zaiavkata
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame ispylnenieto na programata
    }
    $tpl->set('numberOfFirms', mysql_num_rows($result));
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
        $data = $data . $tpl->fetch('_browse_firms_row.html');
    }
    $tpl->set('firmTable', $data);
    if ($i == 0) {
        $tpl->set('firmTable', $msgArray['br_no_such']);
    }
    if (!empty($msg)) {
        $tpl->set('msg', $msgArray[$msg]);
    } else {
        $tpl->set('msg', '');
    }
    $tpl->set('content', $tpl->fetch('_browse_firms.html'));
    print $tpl->fetch('_main_template.html');
}
function addFirm($formData = '', $msg='', $PK='') {
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
        $tpl->set('CodF', '');
        $tpl->set('NameF', '');
        $tpl->set('Adres', '');
    }
    $tpl->set('sid', $PK);
    $tpl->set('cmd', 'addEditFirm');
    $tpl->set('content', $tpl->fetch('_addEdit_firms_screen.html'));
    print $tpl->fetch('_main_template.html');
}

function addEditFirm($FormData='', $PK='') {
    $insertFields = ''; //запазваме полетата в които ще въвеждаме данни
    $insertValues = ''; //запазваме данните за полетата
    if (!empty($PK)) {
        $updateFields = '';
        foreach ($FormData as $key => $value) {
            $updateFields = $updateFields . ',' . $key . "='" . addslashes($value) . "'";
            if (empty($value)) {//проверяваме дали има въведени данни в полето
                addSlujiteliScreen($FormData, 'empty', $PK);
                exit;
            }
        }
        $updateFields = substr($updateFields, 1);
        $query = "UPDATE firms SET $updateFields WHERE CodF=$PK";
        $msg = 'edited';
    } else {
        foreach ($FormData as $key => $value) {
            $insertFields = $insertFields . ", $key";
            $insertValues = $insertValues . ",'" . addslashes($value) . "'";
            if (empty($value)) {
                addFirm($FormData, 'empty', $PK);
                exit;
            }
        }
        $insertFields = substr($insertFields, 1);
        $insertValues = substr($insertValues, 1);
        $query = "INSERT INTO firms($insertFields) VALUES($insertValues)";
        $msg = 'added';
    }
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame ispylnenieto na programata
    }
    browseFirms('', $msg);
}

function editFirm($PK='') {
    global $DBH, $tpl, $msgArray;
    $query = 'SELECT * FROM firms WHERE CodF=' . $PK;
// izpylniavame zaiavkata
    if (!$result = mysql_query($query)) {
        print mysql_error();
        exit; // s tozi operator prekratiavame ispylnenieto na programata
    }
    if ($row = mysql_fetch_assoc($result)) {
        addFirm($row, '', $PK);
    } else {
        browseFirms('', 'edit_no_such');
    }
}

function deleteFirm($PK='') {
	global $DBH;	
	if (empty($PK)){
		browseShops('', 'delete_no_such');
	}
	$query = "DELETE FROM firms WHERE CodF = '".$PK."'";
	if (!mysql_query($query)) {
		browseFirms('', 'delete_no_such');
	} else {
		browseFirms('', 'deleted');
	}
}
?>