<?php
	class User extends DB {
		function __construct() {
			$this->table = 'users';
			$this->primary = 'ID';
		}
	}
?>