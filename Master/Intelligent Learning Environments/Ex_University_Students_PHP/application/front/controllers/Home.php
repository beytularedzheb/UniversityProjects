<?php
	class HomeController extends Front {
	
		function __construct() {
			parent::__construct();
		}
		
		function index() {
			$this->loadView('home/index');
		}
	}
?>