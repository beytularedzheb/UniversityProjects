			<div id="content" class="left">
				<div class="box">
					<h1>List of all groups</h1>
					<p>Groups found: <?php echo $groupsFound; ?></p>
<?php
	if ($groupsFound) {
?>				
					<table>
<?php
		foreach ($groups as $row) {
?>	
						<tr>
							<td><?php echo $row['ID'];?></td>
							<td><?php echo $row['name'];?></td>
							<td><?php echo $row['majorAbbr'];?></td>
							<td><?php echo $row['educationAbbr'];?></td>
							<td>
								<a href="<?php echo $this->buildLink('group/view') . $row['ID']; ?>">[v]</a> 
								<a href="<?php echo $this->buildLink('group/update') . $row['ID']; ?>">[u]</a>
								<a href="<?php echo $this->buildLink('group/delete') . $row['ID']; ?>">[d]</a>
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
					<p> No groups in DB</p>
<?php
	}
?>
					<p><a href="<?php echo $this->buildLink('group/create'); ?>">Create new Group</a></p>
				</div>
			</div>