function check(){
	var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
	if (document.forms.reg_form.firstN.value == "") 
		alert('Please enter yout name!');
	else if (document.forms.reg_form.famN.value == "")
		alert('Please enter yout surname!');
	else if (document.forms.reg_form.email.value == "")
		alert('Please enter your e-mail!');
	else if (!re.test(document.forms.reg_form.email.value))
		alert('Invalid e-mail format!');
	else if (document.forms.reg_form.pw.value == "" || document.forms.reg_form.pwp.value == "")
		alert('Please enter password!');
	else if (document.forms.reg_form.pw.value != document.forms.reg_form.pwp.value)
		alert('The passwords do not match!');
	else {
		alert('Submitted!');
		return true;
	}
	return false;
}