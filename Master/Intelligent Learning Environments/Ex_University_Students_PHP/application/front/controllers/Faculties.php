<?php
	class FacultiesController extends Front {
	
		function __construct() {
			parent::__construct();
			
			/* зарежда модела Faculty от models/Faculty.php */
			$this->loadModel('Faculty');
		}
			
		/* зарежда шаблона от views/faculties/index.php */
		function index() {
			$this->data['faculties'] = $this->Faculty->findAll();
			$this->data['facultiesFound'] = count($this->data['faculties']);
			
			// ako nqmam faculteti - syzdai
			if ($this->data['facultiesFound'] == 0) {
				$this->redirect($this->buildLink('faculty/create'), 'No faculties were found in DB. Redirecting to CREATE action.');
			}
			$this->loadView('faculties/index', $this->data);
		}
	}
?>