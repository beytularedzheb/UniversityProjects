<?php
	class MajorsController extends Front {
	
		function __construct() {
			parent::__construct();
			
			/* зарежда модела Major от models/Major.php */
			$this->loadModel('Major');
		}
			
		/* зарежда шаблона от views/majors/index.php */
		function index() {
			$this->data['majors'] = $this->Major->findAll();
			$this->data['majorsFound'] = count($this->data['majors']);
			
			$this->loadView('majors/index', $this->data);
		}
	}
?>