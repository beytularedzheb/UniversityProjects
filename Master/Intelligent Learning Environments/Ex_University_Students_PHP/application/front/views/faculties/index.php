			<div id="content" class="left">
				<div class="box">
					<h1>List of all faculties</h1>
					<p>Faculties found: <?php echo $facultiesFound; ?></p><?php
	if ($facultiesFound) {
?>				
					<table>
<?php
		foreach ($faculties as $row) {
?>	
						<tr>
							<td><?php echo $row['ID'];?></td>
							<td><?php echo $row['name'];?></td>
							<td><?php echo $row['abbr'];?></td>
							<td>
								<a href="<?php echo $this->buildLink('faculty/view') . $row['ID']; ?>">[v]</a> 
								<a href="<?php echo $this->buildLink('faculty/update') . $row['ID']; ?>">[u]</a>
								<a href="<?php echo $this->buildLink('faculty/delete') . $row['ID']; ?>">[d]</a>
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
					<p> No faculties in DB</p>
<?php
	}
?>
					<p><a href="<?php echo $this->buildLink('faculty/create'); ?>">Create new Faculty</a></p>
				</div>
			</div>