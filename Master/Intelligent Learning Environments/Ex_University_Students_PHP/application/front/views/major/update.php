			<div id="content" class="left">
				<div class="box">
					<h1>Update major "<?php echo $major['abbr']; ?>"</h1>					
					<form method="post">
						<table>
							<tr>
								<td>Name: </td>
								<td>
									<input  type="text" 
											name="Major[name]" 
											value="<?php echo $major['name']; ?>" 
											size="60" />
								</td>
							</tr>
							<tr>
								<td>Abbreviation: </td>
								<td>
									<input  type="text" 
											name="Major[abbr]" 
											value="<?php echo $major['abbr']; ?>" 
											size="10" />
								</td>
							</tr>
							<tr>
								<td>Faculty: </td>
								<td>
									<select name="Major[faculty]">
<?php
	foreach ($faculties as $row) {
?>
										<option value="<?php echo $row['ID']; ?>" <?php if ($row['ID'] == $major['faculty']) { echo 'selected'; } ?>><?php echo $row['name']; ?></option>
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
					<p><a href="<?php echo $this->buildLink('majors'); ?>">Back</a></p>			
				</div>
			</div>