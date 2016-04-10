<?php
	class ProfileController extends StudentModule {
		function __construct() {
			parent::__construct();
		}
		
		function create() {
			if ($this->action) {
				if ($_POST['Password']['first'] == $_POST['Password']['repeat']) {
					// v user.password zapisvame heshiranata stojnost na vuvedenata parola
					$_POST['User']['password'] = md5($_POST['Password']['first']);
					
					// pyrvo zapisvame dannite za user
					// create vrushta ID na user-a, koeto shte polzvame
					// pri suzdavaneto na student, t.k vruzkata e 1:1
					$userID = $this->User->create($_POST['User']);
					// suzdavame student-a i mu zadavame ID, ID-to na user
					$this->Student->create($_POST['Student'] + array('ID' => $userID));
					
					$this->redirect($this->buildLink());
				}
			}
			
			$this->loadView('profile/create', $this->data);
		}
		
		function login() {		
			$student = $this->Student->login($_POST['emailAddress'], md5($_POST['password']));

			if ($student['ID']) {
				$_SESSION['studentID'] = $student['ID'];
				$this->redirect($this->buildLink());
			}
		}
		
		function logout() {		
			unset($_SESSION['studentID']);
			$this->redirect($this->buildLink());
		}
	}
?>