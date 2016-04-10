<?php
	class Application {
		
		function __construct() {
			$url = PATH == '/' ? $_SERVER['REQUEST_URI'] : str_replace(PATH, '', $_SERVER['REQUEST_URI']);
			$this->uri = array_map('addslashes', preg_split('[\\/]', strtok($url, '?'), -1, PREG_SPLIT_NO_EMPTY));
			$this->uri = array_map('urldecode', $this->uri);
			parse_str($_SERVER['QUERY_STRING'], $this->query_array);
			
			$file = 'application/'.$this->uri[0].'/'.$this->uri[0].'.php';
			if (file_exists($file)) {
				require_once($file);
				list($this->module, $this->controller, $this->method, $this->parameter) = $this->uri;
			} else {
				$file = 'application/front/front.php';
				require_once($file);
				$this->module = 'front';
				list($this->controller, $this->method, $this->parameter) = $this->uri;
			}
			
			$this->controller = implode('', array_map('ucfirst', explode('-', '-'.$this->controller)));
			$this->path = 'application/'.$this->module.'/';
			$this->path_template = PATH . $this->path.'views/templates/'.$this->template.'/';
		}
		
		function loadController() {
			$file = $this->path.'controllers/'.$this->controller.'.php';
			
			if (file_exists($file) == false) {
				$file = $this->path.'controllers/'.DEFAULT_CONTROLLER.'.php';
				$this->controller = DEFAULT_CONTROLLER;
			}
			
			require_once($file);
			$class_name = $this->controller.'Controller';
			$controller = new $class_name();
			
			if (method_exists($controller, $this->method))
			 	$controller->{$this->method}($this->parameter);
			else if (method_exists($controller, 'index'))
				$controller->index($this->method);
			else
				$this->redirect($this->buildLink());
		}
		
		function loadView($view, $vars = '', $header = 1) {
			if (is_array($vars) && count($vars) > 0)
				extract($vars);
			
			if ($header)
				require_once($this->path.'views/templates/'.$this->template.'/header.php');
			
			require($this->path.'views/'.$view.'.php');
			if ($header)
				require_once($this->path.'views/templates/'.$this->template.'/footer.php');
		}
		
		function loadModel($model) {
			require_once($this->path.'models/'.$model.'.php');
			$this->$model = new $model;
		}
		
		function loadLanguage($view) {
			require_once($this->path.'languages/'.$this->language.'/'.$this->language.'.php');
			require_once($this->path.'languages/'.$this->language.'/'.$view.'.php');
			return $_;
		}
		
		function buildLink($route = '', $module = '') {
			$module = $module ? $module : $this->module;
			$module = $module == 'front' ? '' : $module.'/';
			
			$this->ssl_pages = array('account/', 'checkout', 'card');
		
			if (SSL_ENABLE) {
				if (in_array($module, $this->ssl_pages))
					$ssl_enabled = true;
				else {
					$route_array = explode('/', $route);
					if (in_array($route_array[0], $this->ssl_pages))
						$ssl_enabled = true;
				}
			}
			
			return 'http'.($ssl_enabled ? 's' : '') .'://'. DOMAIN . PATH . $module . ($route ? $route . '/' : '');
		}
		
		function queryString($parameter = '', $value = '') {
			$query_array = $this->query_array;
			if (empty($value))
				unset($query_array[$parameter]);
			else
				$query_array[$parameter] = $value;
			return count($query_array) ? '?'.http_build_query($query_array) : '';
		}
		
		function linkImage($image) {
			return PATH . 'images/' . (file_exists(PATH_FULL . 'images/'.$image) ? $image : 'no_image.jpg');
		}
		
		function redirect($url, $message = '', $type = 'error') {
			if ($message)
				$_SESSION['message'] = array('text' => $message, 'type' => $type);
			header('Location:'.$url);
			exit;
		}
		
		function setMessage($message, $type = 'error') {
			$_SESSION['message'] = array('text' => $message, 'type' => $type);
		}
		
		function getMessage() {
			return $_SESSION['message'];
		}
	}
	
	mysql_connect(HOSTNAME, USERNAME, PASSWORD) or die(mysql_error());
	mysql_query("SET NAMES 'utf8'");
	mysql_select_db(DATABASE) or die(mysql_error());
?>