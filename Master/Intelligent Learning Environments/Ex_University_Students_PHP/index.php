<?php
	session_start();
	require_once('application/config.php');
	require_once('application/base.php');
	
	$application = new Application();
	$application->loadController();
?>