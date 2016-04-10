<?php
	class Student extends User {
	
		function __construct() {
			$this->table = 'students';
			$this->primary = 'ID';
			
			if ($_SESSION['studentID']) {			
				$this->information = $this->find($_SESSION['studentID']);
			}
		}
		
		function findAll($conditions = '', $params = array()) {
			$sql = "SELECT s.*, u.firstname, u.lastname, u.emailAddress, u.dateAdded FROM students s LEFT JOIN users u ON (s.ID = u.ID) " .
			$this->processConditions($conditions). $this->processParams($params);
			
			return $this->query($sql);
		}
		
		function find($id) {
			$sql = "SELECT s.*, u.firstname, u.lastname, u.emailAddress, u.dateAdded FROM 
			students s LEFT JOIN users u ON (s.ID = u.ID) WHERE s." . $this->primary . " = '" . $id . "'";
			
			return $this->query($sql, array('first' => true));
		}
		
		function login($email, $password) {
			$sql = "SELECT s.*, u.firstname, u.lastname, u.emailAddress, u.dateAdded FROM students s LEFT JOIN users u ON (s.ID = u.ID) WHERE 
			u.emailAddress = '" . $email . "' and u.password = '" . $password . "'";
			
			return $this->query($sql, array('first' => true));		
		}
	}
?>