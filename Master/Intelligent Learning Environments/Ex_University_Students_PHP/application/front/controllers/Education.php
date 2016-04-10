<?php
	class EducationController extends Front {
	
		function __construct() {
			parent::__construct();
			
			/* зарежда модела Education от models/Education.php */
			$this->loadModel('Education');
		}
		
		function index() {
			// забраняване на http://dev.tieipt.com/pc1/education/index
			echo 'N/A';
		}
		
		function view($id) {
			$this->data['education'] = $this->Education->find($id);
			
			// извикване на шаблона views/faculty/view.php
			$this->loadView('education/view', $this->data);
		}
		
		function update($id) {
			$this->data['education'] = $this->Education->find($id);
			
			if ($this->action) {
				// извикай метода save на модела Education, подай
				// новата информация и го запиши на факултета, за който говорим - ID
				$this->Education->save($_POST['Education'], $this->data['education']['ID']);
				$this->redirect($this->buildLink('educations'));
			}
			
			// извикване на шаблона views/education/update.php
			$this->loadView('education/update', $this->data);
		}
		
		function create() {
			if ($this->action) {
				// извикай метода create на модела Education, подай
				// информацията и го запиши на факултета, с новото ID
				$this->Education->create($_POST['Education']);
				$this->redirect($this->buildLink('educations'));
			}
			
			// извикване на шаблона views/education/create.php
			$this->loadView('education/create', $this->data);
		}
		
		function delete($id) {
			$this->Education->remove($id);
			$this->redirect($this->buildLink('educations'));
		}
	}
?>