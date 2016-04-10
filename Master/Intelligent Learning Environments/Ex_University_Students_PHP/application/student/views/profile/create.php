			<div id="content" class="left">
				<form method="post" action="">
					<div class="box">
						<h1>Create new Student</h1>					
						<table>
							<tr>
								<td style="width: 120px">Email:</td>
								<td><input type="text" name="User[emailAddress]" value="" /></td>
							</tr>
							<tr>
								<td>Password:</td>
								<td><input type="password" name="Password[first]" value="" /></td>
							</tr>
							<tr>
								<td>Repeat password:</td>
								<td><input type="password" name="Password[repeat]" value="" /></td>
							</tr>
							<tr>
								<td>Firstname:</td>
								<td><input type="text" name="User[firstname]" value="" /></td>
							</tr>
							<tr>
								<td>Lastname:</td>
								<td><input type="text" name="User[lastname]" value="" /></td>
							</tr>
						</table>
					</div>
					
					<div class="box">
						<h1>Student information</h1>					
						<table>
							<tr>
								<td style="width: 120px">Faculty Number:</td>
								<td><input type="text" name="Student[facultyNumber]" value="" /></td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" name="Action" value="Create Profile" /></td>
							</tr>
						</table>				
					</div>
				</form>
			</div>