<?php
	class DB {
		
		public function create($fields = array()) {
			return $this->insert($this->table, $fields);
		}
		
		public function save($fields = array(), $id) {
			$this->update($this->table, $fields, array($this->primary => $id));
		}

		public function remove($id) {
			$this->delete($this->table, array($this->primary => $id));
		}
		
		function find($id, $field = '') {
			return $this->select($this->table, array($field ? $field : $this->primary => $id), array('first' => true));
		}
		
		function findAll($conditions = '', $params = array()) {
			return $this->select($this->table, $conditions, $params + array('primary' => $this->primary));
		}
		
		public function select($table, $conditions = '', $params = array()) {
			$sql = "SELECT * FROM ".$table." ".$this->processConditions($conditions).$this->processParams($params);
			return $this->query($sql, $params);
		}
		
		public function insert($table, $fields = array()) {
			$sql = "INSERT IGNORE INTO ".$table." SET ".$this->processFields($fields)."";
			$this->__query($sql);
			return mysql_insert_id();
		}
		
		public function update($table, $fields, $conditions) {
			$sql = "UPDATE ".$table." SET ".$this->processFields($fields)." ".$this->processConditions($conditions)."";
			$this->__query($sql);
		}
		
		public function delete($table, $conditions) {
			$sql = "DELETE FROM ".$table." ".$this->processConditions($conditions)."";
			$this->__query($sql);
		}
		
		function checkRules($data, $rules = '') {
			if (empty($rules))
				$rules = $this->rules();
			
			if (count($rules) == 0)
				return true;
			
			foreach ($rules as $rule => $fields) {
				if (count($fields) == 0)
					continue;
			
				if ($rule == 'required') {
					foreach ($fields as $field) {
						if (empty($data[$field]))
							return array('type' => $rule, 'field' => $field);
					}
				} else if ($rule == 'alpha') {
					foreach ($fields as $field) {
						if (ctype_alpha(str_replace(' ', '', $data[$field])) == false && empty($data[$field]) == false)
							return array('type' => $rule, 'field' => $field);
					}
				} else if ($rule == 'cyrillic') {
					foreach ($fields as $field) {
						if (!preg_match('/^[\p{Cyrillic}\p{Common}]+$/u', $data[$field]) && empty($data[$field]) == false)
							return array('type' => $rule, 'field' => $field);
					}
				} else if ($rule == 'numeric') {
					foreach ($fields as $field) {
						if (!is_numeric($data[$field]) && empty($data[$field]) == false)
							return array('type' => $rule, 'field' => $field);
					}
				}
			}
			return true;
		}		
		
		
		function processParams($params) {
			if (is_array($params) == false || count($params) == 0)
				return '';
			
			$return .= $params['group'] ? 'GROUP BY '.$params['group'].' ' : '';
			$return .= $params['order'] ? 'ORDER BY '.$params['order'].' ' : '';
			$return .= $params['limit'] ? 'LIMIT '.$params['limit'].' ' : '';
			return $return;
		}
		
		function processConditions($array) {
			if (is_array($array) == false) {
				return strlen($array) ? 'WHERE '.$array : '';
			}
			
			foreach ($array as $key => $value)
				$return[] = is_numeric($key) ? $value : ($key . " = '".$value."'");
			
			return 'WHERE '.implode(' AND ', $return).' ';
		}
		
		function processFields($array) {
			if (is_array($array) == false || count($array) == 0)
				return false;
			
			foreach ($array as $key => $value)
				$return[] = '`'.$key . "` = '".$value."'";
			
			return implode(', ', $return).' ';
		}
		
		public function query($sql, $params = array()) {
			if ($params['page'] > 0) {
				$query = $this->__query($sql);
				$count = mysql_num_rows($query);
				$sql .= ' LIMIT '.(($params['page'] - 1) * PER_PAGE).", ".PER_PAGE;
			}
			
			$query = $this->__query($sql);
			
			if ($params['first']) {
				$rows = mysql_fetch_assoc($query);
				if (isset($rows[$params['first']]))
					$rows = $rows[$params['first']];
			} else if ($params['primary']) {
				while ($row = mysql_fetch_assoc($query))
					$rows[$row[$params['primary']]] = $row;
			} else {
				while ($row = mysql_fetch_assoc($query))
					$rows[] = $row;
			}
			
			return $params['page'] == 0 ? $rows : array('Count' => $count, 'Pages' => ceil($count / PER_PAGE), 'Rows' => $rows);
		}
		
		public function __query($sql) {
			$result = mysql_query($sql) or die(mysql_error().' '.$sql);
			return $result;
		}
	}
?>