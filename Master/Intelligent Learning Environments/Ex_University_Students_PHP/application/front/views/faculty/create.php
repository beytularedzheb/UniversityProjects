			<div id="content" class="left">
				<div class="box">
					<h1>Create new faculty</h1>					
					<form method="post">
						<table>
							<tr>
								<td>Name: </td>
								<td>
									<!-- name="Faculty[name]" - това поле ще е елемент 
										от масив Faculty и този елемент ще е name -->	
									<input  type="text"
											name="Faculty[name]" 
											value="<?php echo $_POST['Faculty']['name']; ?>" 
											size="60" />
								</td>
							</tr>
							<tr>
								<td>Abbreviation: </td>
								<td>
									<!-- name="Faculty[abbr]" - това поле ще е елемент 
										от масив Faculty и този елемент ще е abbr -->	
									<input  type="text"								
											name="Faculty[abbr]"
											value="<?php echo $_POST['Faculty']['abbr']; ?>" 
											size="10" />
								</td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" name="Action" value="Create" /></td>
							</tr>							
						</table>
					</form>				
					<p><a href="<?php echo $this->buildLink('faculties'); ?>">Back</a></p>			
				</div>
			</div>