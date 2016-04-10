<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" http://www.w3.org/TR/html4/loose.dtd"> 

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
		<title><?php echo $title;?></title>
		<meta name="description" content="<?php echo $description;?>" />
		<meta name="keywords" content="<?php echo $keywords;?>" />
		<link rel="icon" href="<?php echo $this->path_template;?>icons/favicon.ico" type="image/x-icon">
		<link rel="stylesheet" media="all" href="<?php echo $this->path_template;?>styles.css" />
		<link rel="stylesheet" media="all" href="<?php echo $this->path_template;?>layout.css" />
		<link rel="stylesheet" media="only screen and (max-width: 981px)" href="<?php echo $this->path_template;?>mobile.css" />
		<script type="text/javascript" src="<?php echo PATH;?>assets/jquery/jquery-1.10.2.min.js"></script>
		<script type="text/javascript" src="<?php echo PATH;?>assets/jquery/jquery-ui.js"></script>
	</head>
	<body>
		<nav>
			&nbsp;
<?php if ($_SESSION['message']) { 
		echo $_SESSION['message']['text']; 
		unset($_SESSION['message']);
	  }		
?>
		</nav>
		<div id="wrap">
			<header>
				<img src="<?php echo $this->path_template;?>images/logo.png" alt="" />
			</header>
			<ul id="menu">	
				<li><a href="<?php echo $this->buildLink();?>" title="<?php echo $menuHome;?>"><?php echo $menuHome;?></a></li>
			</ul>
