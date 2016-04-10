<?php

require_once('./config.php');
require_once('./msgFile.php');
require_once('./modules/template.php');
require_once('./modules/firmi.php');
require_once('./modules/magazin.php');
require_once('./modules/prodajbi.php');
require_once('./modules/reports.php');

// zadavame pytia do firektoriata sys HTML shabloni
$path = './template/';

// syazdawame instakcia na klasa
$tpl = new Template($path);
$tpl->set('charEncoding', 'Windows-1251');
$tpl->set('JavaScript', '');

// tuk pravim vryzkata s bazata ot danni
if (!$DBH = @mysql_connect($host, $user, $password)) {
	$tpl->set('content', $msgArray['DB_unable_to_connect']);
	print $tpl->fetch('_main_template.html');
	exit;
}

mysql_select_db($db_name);

if (!empty($_REQUEST['cmd'])) {
	$cmd = $_REQUEST['cmd'];
} else {
	$cmd = 'mainMenu';
}

if ($cmd == 'browseFirms') {
	browseFirms(@$_GET['search']);
} elseif ($cmd == 'addFirm') {
	addFirm();
} elseif ($cmd == 'addEditFirm') {
	addEditFirm($_POST['data'], $_POST['sid']);
} elseif ($cmd == 'editFirm') {
	editFirm(@$_GET['CodF']);
} elseif ($cmd == 'deleteFirm') {
	deleteFirm(@$_GET['CodF']);
} elseif ($cmd == 'browseShops') {
	browseShops(@$_GET['search']);
} elseif ($cmd == 'addShop') {
	addShop();
} elseif ($cmd == 'addEditShop') {
	addEditShop($_POST['data'], $_POST['sid']);
} elseif ($cmd == 'editShop') {
	editShop(@$_GET['CodM']);
} elseif ($cmd == 'deleteShop') {
	deleteShop(@$_GET['CodM']);
} elseif ($cmd == 'browseSales') {
	browseSales(@$_GET['search']);
} elseif ($cmd == 'addSale') {
	addSale();
} elseif ($cmd == 'addEditSale') {
	addEditSale($_POST['data'], $_POST['sid']);
} elseif ($cmd == 'editSale') {
	editSale(@$_GET['Id']);
} elseif ($cmd == 'deleteSale') {
	deleteSale(@$_GET['Id']);
} elseif ($cmd == 'reportSalesByMonth') {
	reportSalesByMonth(@$_GET['id']);
} elseif ($cmd == 'reportPreizpilnenie') {
	reportPreizpilnenie(@$_GET['id']);
} else {
	// izvejdane na glavnoto menu
	$tpl->set('content', '<center>Информационна система "Магазин" е създадена с учебна цел по дисциплината „Информационни системи”. Базата от данни съдържа таблици: фирми, магазини, продажби и месеци.</center>');
	print $tpl->fetch('_main_template.html');
	exit;
}
?>