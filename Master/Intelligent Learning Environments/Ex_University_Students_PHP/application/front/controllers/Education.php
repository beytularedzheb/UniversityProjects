<?php
	class EducationController extends Front {
	
		function __construct() {
			parent::__construct();
			
			/* ������� ������ Education �� models/Education.php */
			$this->loadModel('Education');
		}
		
		function index() {
			// ����������� �� http://dev.tieipt.com/pc1/education/index
			echo 'N/A';
		}
		
		function view($id) {
			$this->data['education'] = $this->Education->find($id);
			
			// ��������� �� ������� views/faculty/view.php
			$this->loadView('education/view', $this->data);
		}
		
		function update($id) {
			$this->data['education'] = $this->Education->find($id);
			
			if ($this->action) {
				// ������� ������ save �� ������ Education, �����
				// ������ ���������� � �� ������ �� ���������, �� ����� ������� - ID
				$this->Education->save($_POST['Education'], $this->data['education']['ID']);
				$this->redirect($this->buildLink('educations'));
			}
			
			// ��������� �� ������� views/education/update.php
			$this->loadView('education/update', $this->data);
		}
		
		function create() {
			if ($this->action) {
				// ������� ������ create �� ������ Education, �����
				// ������������ � �� ������ �� ���������, � ������ ID
				$this->Education->create($_POST['Education']);
				$this->redirect($this->buildLink('educations'));
			}
			
			// ��������� �� ������� views/education/create.php
			$this->loadView('education/create', $this->data);
		}
		
		function delete($id) {
			$this->Education->remove($id);
			$this->redirect($this->buildLink('educations'));
		}
	}
?>