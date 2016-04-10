			<div id="content" class="left">
				<div class="box">
					<h1>Update education "<?php echo $education['abbr']; ?>"</h1>					
					<form method="post">
						<table>
							<tr>
								<td>Name: </td>
								<td>
									<input  type="text" 
											name="Education[name]" 
											value="<?php echo $education['name']; ?>" 
											size="60" />
								</td>
							</tr>
							<tr>
								<td>Abbreviation: </td>
								<td>
									<input  type="text" 
											name="Education[abbr]" 
											value="<?php echo $education['abbr']; ?>" 
											size="10" />
								</td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" name="Action" value="Update" /></td>
							</tr>							
						</table>
					</form>				
					<p><a href="<?php echo $this->buildLink('educations'); ?>">Back</a></p>			
				</div>
			</div>