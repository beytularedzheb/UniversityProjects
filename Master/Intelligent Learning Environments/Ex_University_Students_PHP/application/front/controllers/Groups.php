<?php
	class GroupsController extends Front {
	
		function __construct() {
			parent::__construct();
			
			$this->loadModel('Group');
		}
			
		function index() {
			$this->data['groups'] = $this->Group->findAll();
			$this->data['groupsFound'] = count($this->data['groups']);
			
			$this->loadView('groups/index', $this->data);
		}
	}
?>