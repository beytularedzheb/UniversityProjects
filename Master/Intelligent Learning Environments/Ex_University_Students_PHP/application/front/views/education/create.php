			<div id="content" class="left">
				<div class="box">
					<h1>Create new education</h1>					
					<form method="post">
						<table>
							<tr>
								<td>Name: </td>
								<td>
									<!-- name="Education[name]" - това поле ще е елемент 
										от масив Education и този елемент ще е name -->	
									<input  type="text"
											name="Education[name]" 
											value="<?php echo $_POST['Education']['name']; ?>" 
											size="60" />
								</td>
							</tr>
							<tr>
								<td>Abbreviation: </td>
								<td>
									<!-- name="Education[abbr]" - това поле ще е елемент 
										от масив Education и този елемент ще е abbr -->	
									<input  type="text"								
											name="Education[abbr]"
											value="<?php echo $_POST['Education']['abbr']; ?>" 
											size="10" />
								</td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" name="Action" value="Create" /></td>
							</tr>							
						</table>
					</form>				
					<p><a href="<?php echo $this->buildLink('educations'); ?>">Back</a></p>			
				</div>
			</div>