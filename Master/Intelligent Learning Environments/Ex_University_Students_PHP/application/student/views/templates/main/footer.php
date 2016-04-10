			
			<div id="sidebar">
				<div class="box" style="height: 500px;">
<?php	if (!$this->Student->information['ID']) {
?>					
					<h2>Student login</h2>
					<form method="post" action="<?php echo $this->buildLink('profile/login'); ?>">
						<table>
							<tr>
								<td>Email:</td>
								<td><input type="text" name="emailAddress" /></td>
							</tr>
							<tr>
								<td>Password:</td>
								<td><input type="password" name="password" /></td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" name="Action" value="Login" /></td>
							</tr>
						</table>
					</form>
<?php					
		}
		else {
?>
					<h2>Student logout</h2>
					<p><a href="<?php echo $this->buildLink('profile/logout'); ?>">Logout</a></p>					
<?php
		}
?>
				</div>
			</div>			
			<div style="clear: both;"></div>
		</div>
		<footer>

		</footer>
	</body>
</html>