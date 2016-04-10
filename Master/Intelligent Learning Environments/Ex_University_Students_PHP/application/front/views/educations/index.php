			<div id="content" class="left">
				<div class="box">
					<h1>List of all educations</h1>
					<p>Educations found: <?php echo $educationsFound; ?></p>
<?php
	if ($educationsFound) {
?>				
					<table>
<?php
		foreach ($educations as $row) {
?>	
						<tr>
							<td><?php echo $row['ID'];?></td>
							<td><?php echo $row['name'];?></td>
							<td><?php echo $row['abbr'];?></td>
							<td>
								<a href="<?php echo $this->buildLink('education/view') . $row['ID']; ?>">[v]</a> 
								<a href="<?php echo $this->buildLink('education/update') . $row['ID']; ?>">[u]</a>
								<a href="<?php echo $this->buildLink('education/delete') . $row['ID']; ?>">[d]</a>
							</td>
						</tr>
<?php
		}
?>			
					</table>
<?php
	}
	else {
?>
					<p> No educations in DB</p>
<?php
	}
?>
					<p><a href="<?php echo $this->buildLink('education/create'); ?>">Create new Education</a></p>
				</div>
			</div>