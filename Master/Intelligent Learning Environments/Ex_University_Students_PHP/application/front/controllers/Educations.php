<?php
	class EducationsController extends Front {
	
		function __construct() {
			parent::__construct();
			
			/* ������� ������ Education �� models/Education.php */
			$this->loadModel('Education');
		}
			
		/* ������� ������� �� views/educations/index.php */
		function index() {
			$this->data['educations'] = $this->Education->findAll();
			$this->data['educationsFound'] = count($this->data['educations']);
			
			$this->loadView('educations/index', $this->data);
		}
	}
?>