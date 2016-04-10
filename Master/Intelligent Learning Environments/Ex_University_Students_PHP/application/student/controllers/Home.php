<?php
	class HomeController extends StudentModule {
	
		function __construct() {
			parent::__construct();
		}
		
		function index() {
			$this->loadView('home/index');
		}
	}
?>