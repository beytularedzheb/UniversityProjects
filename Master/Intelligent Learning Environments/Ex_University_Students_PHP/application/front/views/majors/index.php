			<div id="content" class="left">
				<div class="box">
					<h1>List of all majors</h1>
					<p>Majors found: <?php echo $majorsFound; ?></p>
<?php
	if ($majorsFound) {
?>				
					<table>
<?php
		foreach ($majors as $row) {
?>	
						<tr>
							<td><?php echo $row['ID'];?></td>
							<td><?php echo $row['name'];?></td>
							<td><?php echo $row['abbr'];?></td>
							<td><?php echo $row['facultyAbbr'];?></td>
							<td>
								<a href="<?php echo $this->buildLink('major/view') . $row['ID']; ?>">[v]</a> 
								<a href="<?php echo $this->buildLink('major/update') . $row['ID']; ?>">[u]</a>
								<a href="<?php echo $this->buildLink('major/delete') . $row['ID']; ?>">[d]</a>
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
					<p> No majors in DB</p>
<?php
	}
?>
					<p><a href="<?php echo $this->buildLink('major/create'); ?>">Create new Major</a></p>
				</div>
			</div>