<?php

function reportSalesByMonth($CodMes='', $msg='') {
    global $tpl, $msgArray;
	
	if (!empty($msg)) {
        $tpl->set('errorMsg', $msgArray[$msg]);
    } else {
        $tpl->set('errorMsg', '');
    }
	
	$MesCode = '';
	$query = "SELECT * FROM meseci;";
	if (!$result = mysql_query($query)) {
		print mysql_error();
		exit; // s tozi operator prekratiavame izpylnenieto na programata
	}
	while ($row = mysql_fetch_assoc($result)) {
		$tpl->set('opValue', $row['CodM']);
		$tpl->set('opTitle', $row['ImeM']);
		if ($row['CodM'] == $CodMes) {
			$tpl->set('opSelected', ' selected');
		} else {
			$tpl->set('opSelected', '');
		}
		$MesCode.=$tpl->fetch('_select_box.html');
	}
	$tpl->set('CodMesS', $MesCode);
	
    if (!empty($CodMes)) {
		$data='';
		$Where = "mes.CodM = " . $CodMes;
		
        $sql="SELECT p.Id, m.NameM AS magName, m.Boss AS boss, mes.ImeM AS mesName, p.StPlan, p.StIzp FROM prodajbi p, magazins m, meseci mes WHERE p.CodM=m.CodM AND p.CodMes=mes.CodM AND " . $Where;
        if (!$result = mysql_query($sql)) {
            print mysql_error();
            exit; // s tozi operator prekratiavame ispylnenieto na programata
        }
        while ($row = mysql_fetch_assoc($result)) {
            foreach ($row as $key => $value) {
                $tpl->set($key, $value);
            }
            // obrabotva i izvlicha obrabotenia HTML kod za tekushtia red
            $data = $data . $tpl->fetch('_reports_sales_section2_row.html');
        }
		if (empty($data)) {
			$tpl->set('section_2', '');
			$tpl->set('section_3', '');
			$tpl->set('errorMsg', $msgArray['br_no_such']);
		}
		else {
			$tpl->set('row', $data);
			$tpl->set('section_2', $tpl->fetch('_reports_sales_section2.html'));
			$tpl->set('section_3', '');
		}
    } else {
        $tpl->set('section_2', '');
        $tpl->set('section_3', '');
    }
		
    $tpl->set('content', $tpl->fetch('_reports_sales_section1.html'));
    print $tpl->fetch('_main_template.html');
}

function reportPreizpilnenie($PK='', $msg='') {
    global $tpl, $msgArray;
	
	if (!empty($msg)) {
        $tpl->set('errorMsg', $msgArray[$msg]);
    } else {
        $tpl->set('errorMsg', '');
    }
	
	$MagCode = '';
	$query = "SELECT * FROM magazins;";
	if (!$result = mysql_query($query)) {
		print mysql_error();
		exit; // s tozi operator prekratiavame izpylnenieto na programata
	}
	while ($row = mysql_fetch_assoc($result)) {
		$tpl->set('opValue', $row['CodM']);
		$tpl->set('opTitle', $row['NameM']);
		if ($row['CodM'] == $PK) {
			$tpl->set('opSelected', ' selected');
		} else {
			$tpl->set('opSelected', '');
		}
		$MagCode.=$tpl->fetch('_select_box.html');
	}
	$tpl->set('MagCode', $MagCode);
	
    if (!empty($PK)) {
		$data='';
	
        $sql="SELECT m.NameM, mes.ImeM, p.StPlan, p.StIzp, p.StIzp-p.StPlan AS preizp FROM prodajbi p, magazins m, meseci mes WHERE p.StIzp-p.StPlan > 0 AND p.CodM=$PK AND p.CodM=m.CodM AND p.CodMes=mes.CodM;";
        if (!$result = mysql_query($sql)) {
            print mysql_error();
            exit; // s tozi operator prekratiavame ispylnenieto na programata
        }
        while ($row = mysql_fetch_assoc($result)) {
            foreach ($row as $key => $value) {
                $tpl->set($key, $value);
            }
            // obrabotva i izvlicha obrabotenia HTML kod za tekushtia red
            $data = $data . $tpl->fetch('_reports_sales_pre_section2_row.html');
        }
		if (empty($data)) {
			$tpl->set('section_2', '');
			$tpl->set('section_3', '');
			$tpl->set('errorMsg', $msgArray['br_no_such']);
		}
		else {
			$tpl->set('row', $data);
			$tpl->set('section_2', $tpl->fetch('_reports_sales_pre_section2.html'));
			$tpl->set('section_3', '');
		}
    } else {
        $tpl->set('section_2', '');
        $tpl->set('section_3', '');
    }
		
    $tpl->set('content', $tpl->fetch('_reports_sales_pre_section1.html'));
    print $tpl->fetch('_main_template.html');
}

?>