			<div id="content" class="left">
				<div class="box">
					<h1>Create new group</h1>
					<form method="post">
						<table>
							<tr>
								<td>Name: </td>
								<td>
									<input  type="text"
											name="Group[name]" 
											value="<?php echo $_POST['Group']['name']; ?>" 
											size="60" />
								</td>
							</tr>
							<tr>
								<td>Major: </td>
								<td>
									<select name="Group[major]">
<?php
	foreach ($majors as $row) {
?>
										<option value="<?php echo $row['ID']; ?>"><?php echo $row['name']; ?></option>
<?php
	}
?>
									</select>
								</td>
							</tr>
							<tr>
								<td>Education: </td>
								<td>
									<select name="Group[education]">
<?php
	foreach ($educations as $row) {
?>
										<option value="<?php echo $row['ID']; ?>"><?php echo $row['name']; ?></option>
<?php
	}
?>
									</select>
								</td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" name="Action" value="Create" /></td>
							</tr>
						</table>
					</form>
					<p><a href="<?php echo $this->buildLink('groups'); ?>">Back</a></p>
				</div>
			</div>