<?php
	class GroupController extends Front {
	
		function __construct() {
			parent::__construct();
			
			$this->loadModel('Group');
		}
		
		function index() {
			echo 'N/A';
		}
		
		function view($id) {			
			$this->data['group'] = $this->Group->find($id);
			
			$this->loadView('group/view', $this->data);
		}
		
		function update($id) {
			$this->loadModel('Education');
			$this->data['educations'] = $this->Education->findAll();
			$this->loadModel('Major');
			$this->data['majors'] = $this->Major->findAll();
			
			$this->data['group'] = $this->Group->find($id);
			
			if ($this->action) {
				$this->Group->save($_POST['Group'], $this->data['group']['ID']);
				$this->redirect($this->buildLink('groups'));
			}
			
			$this->loadView('group/update', $this->data);
		}
		
		function create() {
			$this->loadModel('Education');
			$this->data['educations'] = $this->Education->findAll();
			$this->loadModel('Major');
			$this->data['majors'] = $this->Major->findAll();
			
			if ($this->action) {
				$this->Group->create($_POST['Group']);
				$this->redirect($this->buildLink('groups'));
			}
			
			$this->loadView('group/create', $this->data);
		}
		
		function delete($id) {
			$this->Group->remove($id);
			$this->redirect($this->buildLink('groups'));
		}
	}
?>