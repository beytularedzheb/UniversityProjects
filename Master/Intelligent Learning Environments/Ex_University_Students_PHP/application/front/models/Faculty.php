<?php
	class Faculty extends DB {
		function __construct() {
			$this->table = 'faculties';
			$this->primary = 'ID';
		}
	}
?>