			<div id="content" class="left">
				<div class="box">
					<h1>Create new major</h1>
					<form method="post">
						<table>
							<tr>
								<td>Name: </td>
								<td>
									<!-- name="Major[name]" - това поле ще е елемент 
										от масив Major и този елемент ще е name -->
									<input  type="text"
											name="Major[name]" 
											value="<?php echo $_POST['Major']['name']; ?>" 
											size="60" />
								</td>
							</tr>
							<tr>
								<td>Abbreviation: </td>
								<td>
									<!-- name="Major[abbr]" - това поле ще е елемент 
										от масив Major и този елемент ще е abbr -->	
									<input  type="text"	
											name="Major[abbr]"
											value="<?php echo $_POST['Major']['abbr']; ?>" 
											size="10" />
								</td>
							</tr>
							<tr>
								<td>Faculty: </td>
								<td>
									<select name="Major[faculty]">
									<option value="0">-- Please select --</option>
<?php
	foreach ($faculties as $row) {
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
					<p><a href="<?php echo $this->buildLink('majors'); ?>">Back</a></p>
				</div>
			</div>