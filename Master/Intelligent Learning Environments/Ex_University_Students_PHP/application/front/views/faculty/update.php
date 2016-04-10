			<div id="content" class="left">
				<div class="box">
					<h1>Update faculty "<?php echo $faculty['abbr']; ?>"</h1>					
					<form method="post">
						<table>
							<tr>
								<td>Name: </td>
								<td>
									<input  type="text" 
											name="Faculty[name]" 
											value="<?php echo $faculty['name']; ?>" 
											size="60" />
								</td>
							</tr>
							<tr>
								<td>Abbreviation: </td>
								<td>
									<input  type="text" 
											name="Faculty[abbr]" 
											value="<?php echo $faculty['abbr']; ?>" 
											size="10" />
								</td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" name="Action" value="Update" /></td>
							</tr>							
						</table>
					</form>				
					<p><a href="<?php echo $this->buildLink('faculties'); ?>">Back</a></p>			
				</div>
			</div>