			<div id="content" class="left">
				<div class="box">
					<h1>Update group "<?php echo $group['name']; ?>"</h1>					
					<form method="post">
						<table>
							<tr>
								<td>Name: </td>
								<td>
									<input  type="text" 
											name="Group[name]" 
											value="<?php echo $group['name']; ?>" 
											size="20" />
								</td>
							</tr>
							<tr>
								<td>Major: </td>
								<td>
									<select name="Group[major]">
<?php
	foreach ($majors as $row) {
?>
										<option value="<?php echo $row['ID']; ?>" <?php if ($row['ID'] == $group['major']) { echo 'selected'; } ?>><?php echo $row['name']; ?></option>
<?php
	}
?>
									</select>
								</td>
							</tr>
							<tr>
								<td>Faculty: </td>
								<td>
									<select name="Group[education]">
<?php
	foreach ($educations as $row) {
?>
										<option value="<?php echo $row['ID']; ?>" <?php if ($row['ID'] == $group['education']) { echo 'selected'; } ?>><?php echo $row['name']; ?></option>
<?php
	}
?>
									</select>
								</td>
							</tr>							
							<tr>
								<td></td>
								<td><input type="submit" name="Action" value="Update" /></td>
							</tr>							
						</table>
					</form>				
					<p><a href="<?php echo $this->buildLink('groups'); ?>">Back</a></p>			
				</div>
			</div>