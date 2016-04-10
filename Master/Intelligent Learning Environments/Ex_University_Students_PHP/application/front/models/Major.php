<?php
	class Major extends DB {
		function __construct() {
			$this->table = 'majors';
			$this->primary = 'ID';
		}
		
		function findAll($conditions = '', $params = array()) {
			$sql = "SELECT m.*, f.abbr facultyAbbr FROM majors m LEFT JOIN faculties f ON (m.faculty = f.ID) " .
			$this->processConditions($conditions). $this->processParams($params);
			
			return $this->query($sql);
		}
		
		function find($id) {
			$sql = "SELECT m.*, f.abbr facultyAbbr FROM majors m LEFT JOIN faculties f ON (m.faculty = f.ID) WHERE m." . $this->primary . 
			" = '" . $id . "'";
			
			return $this->query($sql, array('first' => true));
		}
	}
?>