<?php
	class FacultyController extends Front {
	
		function __construct() {
			parent::__construct();
			
			/* зарежда модела Faculty от models/Faculty.php */
			$this->loadModel('Faculty');
		}
		
		function index() {
			// забраняване на http://dev.tieipt.com/pc1/faculty/index
			echo 'N/A';
		}
		
		function view($id) {
			if (empty($id)) {
				$this->redirect($this->buildLink('faculties'), 'Error in URL');
			}
			
			$this->data['faculty'] = $this->Faculty->find($id);
			
			if (empty($this->data['faculty'])) {
				$this->redirect($this->buildLink('faculties'), 'Error in Model Primary Key');	
			}				
			// извикване на шаблона views/faculty/view.php
			$this->loadView('faculty/view', $this->data);
		}
		
		function update($id) {
			$this->data['faculty'] = $this->Faculty->find($id);
			
			if ($this->action) {
				// извикай метода save на модела Faculty, подай
				// новата информация и го запиши на факултета, за който говорим - ID
				$this->Faculty->save($_POST['Faculty'], $this->data['faculty']['ID']);
				$this->redirect($this->buildLink('faculties'));
			}
			
			// извикване на шаблона views/faculty/update.php
			$this->loadView('faculty/update', $this->data);
		}
		
		function create() {
			if ($this->action) {
				// извикай метода create на модела Faculty, подай
				// информацията и го запиши на факултета, с новото ID
				$this->Faculty->create($_POST['Faculty']);
				$this->redirect($this->buildLink('faculties'));
			}
			
			// извикване на шаблона views/faculty/create.php
			$this->loadView('faculty/create', $this->data);
		}
		
		function delete($id) {
			$this->Faculty->remove($id);
			$this->redirect($this->buildLink('faculties'));
		}
	}
?>