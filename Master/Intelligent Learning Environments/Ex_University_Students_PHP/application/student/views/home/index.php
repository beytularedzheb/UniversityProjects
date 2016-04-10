			<div id="content" class="left">
				<div class="box">
					<h1>Student module</h1>
					<p><?php if ($this->Student->information['ID']) echo 'Welcome,' . $this->Student->information['firstname'] . ' ' . $this->Student->information['lastname']; ?></p>
					<p><a href="<?php echo $this->buildLink('', 'front')?>">Back to Front module</a></p>
				</div>
			</div>
