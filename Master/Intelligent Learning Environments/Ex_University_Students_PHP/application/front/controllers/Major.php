<?php
	class MajorController extends Front {
	
		function __construct() {
			parent::__construct();
			
			/* зарежда модела Major от models/Major.php */
			$this->loadModel('Major');
		}
		
		function index() {
			// забраняване на http://dev.tieipt.com/pc1/major/index
			echo 'N/A';
		}
		
		function view($id) {
			if (empty($id) || is_numeric($id) == false) {
				$this->redirect($this->buildLink('majors'), 'Error in URL');
			}
			
			$this->data['major'] = $this->Major->find($id);
			
			if (empty($this->data['major']['ID'])) {
				$this->redirect($this->buildLink('majors'), 'Error in Model Primary Key');
			}			
			
			$this->loadView('major/view', $this->data);
		}
		
		function update($id) {
			$this->loadModel('Faculty');
			$this->data['faculties'] = $this->Faculty->findAll();
			
			$this->data['major'] = $this->Major->find($id);
			
			if ($this->action) {
				$this->Major->save($_POST['Major'], $this->data['major']['ID']);
				$this->redirect($this->buildLink('majors'));
			}
			
			$this->loadView('major/update', $this->data);
		}
		
		function create() {
			$this->loadModel('Faculty');
			$this->data['faculties'] = $this->Faculty->findAll();
			
			if ($this->action) {
				if (empty($_POST['Major']['name'])) {
					$error = 'Please, enter major name';
				}
				else if (empty($_POST['Major']['faculty'])) {
					$error = 'Please, choose faculty';
				}
				else if (empty($_POST['Major']['abbr'])) {
					$error = 'Please, enter abbreviation';
				}
				
				if ($error) {
					$this->setMessage($error);
				}
				else {
					$this->Major->create($_POST['Major']);
					$this->redirect($this->buildLink('majors'));
				}
			}
			
			$this->loadView('major/create', $this->data);
		}
		
		function delete($id) {
			$this->Major->remove($id);
			$this->redirect($this->buildLink('majors'));
		}
	}
?>