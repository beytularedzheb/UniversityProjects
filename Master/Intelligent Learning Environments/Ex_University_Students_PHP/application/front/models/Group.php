<?php
	class Group extends DB {
		function __construct() {
			$this->table = 'groups';
			$this->primary = 'ID';
		}
		
		function findAll($conditions = '', $params = array()) {
			$sql = "SELECT g.*, e.abbr educationAbbr, m.abbr majorAbbr FROM groups g LEFT JOIN educations e ON (g.education = e.ID) 
			LEFT JOIN majors m ON (g.major = m.ID) " .
			$this->processConditions($conditions). $this->processParams($params);
			
			return $this->query($sql);
		}
		
		function find($id) {
			$sql = "SELECT g.*, e.abbr educationAbbr, m.abbr majorAbbr FROM groups g LEFT JOIN educations e ON (g.education = e.ID) 
			LEFT JOIN majors m ON (g.major = m.ID) WHERE g." . $this->primary . 
			" = " . $id;
			
			return $this->query($sql, array('first' => true));
		}
	}
?>