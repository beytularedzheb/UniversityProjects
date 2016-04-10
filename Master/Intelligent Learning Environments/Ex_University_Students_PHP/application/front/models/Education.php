<?php
	class Education extends DB {
		function __construct() {
			$this->table = 'educations';
			$this->primary = 'ID';
		}
	}
?>