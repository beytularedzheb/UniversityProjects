function check(){
	/* http://stackoverflow.com/questions/46155/validate-email-address-in-javascript */
	var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
	
	if (document.forms.reg_form.firstN.value == "") 
		alert('Моля въведете вашето име!');
	else if (document.forms.reg_form.famN.value == "")
		alert('Моля въведете вашето фамилно име!');
	else if (document.forms.reg_form.email.value == "")
		alert('Моля въведете email!');
	else if (!re.test(document.forms.reg_form.email.value))
		alert('Невалиден email формат!');
	else if (document.forms.reg_form.pw.value == "" || document.forms.reg_form.pwp.value == "")
		alert('Моля въведете парола!');
	else if (document.forms.reg_form.pw.value != document.forms.reg_form.pwp.value)
		alert('Паролите на съвпадат!');
	else {
		alert('Успешно се регистрирахте!');
		return true;
	}
	return false;
}