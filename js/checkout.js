
var shippingid=0;
var payment = 1;
var instr = 'Main_';

function shippingSelected(sid) {
	shippingid = sid;
	if ($('basketpaneldiv')) {
		load_html('basketpaneldiv', 'components/loadcontrol.aspx?cn=basketpanel_side&shippingid='+shippingid+'&payment='+payment+'&calculateShipping=1');
	}
}

function paymentSelected(pay) {
	payment = pay;
	if ($('basketpaneldiv')) {
		load_html('basketpaneldiv', 'components/loadcontrol.aspx?cn=basketpanel_side&shippingid='+shippingid+'&payment='+payment+'&calculateShipping=1');
	}
}

function paymentOptionSelected(method) {
	if (method=='chargewithcreditcard') {
		$('cardpanel').style.display = 'block';
	} else {
		$('cardpanel').style.display = 'none';
	}
}

function formSubmited() {
	
	if (!paymentSubmit()) {
		return false;
	}
	
	if ($('agreecheck')) {
		if (!$('agreecheck').checked) {
			alert('אנא סמן שקראת והינך מסכים לתקנון');
			return false;
		}
	}
	return true;
}

function open_popup(theURL,w,h,window_name) {
	features="product_browser.aspx','toolbar=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,width="+w+",height="+h;
	window.open(theURL,window_name,features);
}

function shippingSubmit() {

	var isValid = true;
	
	if (isEmptyField(instr+'addressfirstnametxt', 'אנא הכנס שם פרטי')) {
		isValid = false;
	}
	if (isEmptyField(instr+'addresslastnametxt', 'אנא הכנס שם משפחה')) {
		isValid = false;
	}
	if (isEmptyField(instr+'addressstreettxt', 'אנא הכנס רחוב')) {
		isValid = false;
	}
	if (isEmptyField(instr+'addresshousenumtxt', 'אנא הכנס מס\' בית')) {
		isValid = false;
	}
	if (isEmptyField(instr+'addresscitytxt', 'אנא הכנס עיר')) {
		isValid = false;
	}
	if (shippingid == 0) {
		insertFieldComment('deliverydiv','אנא בחר אופן משלוח');
		isValid = false;
	} else {
		clearFieldComment('deliverydiv','true');
	}
	if (!isValid) {
		return;
	}
	
	$('shippingPanelLink').innerHTML = '<a href="javascript:showShippingPanel();">שנה פרטים</a>';
	$('shippingpanel').style.display = 'none';
	$('paymentpanel').style.display = 'block';
}

function showShippingPanel() {
	$('shippingPanelLink').innerHTML = '';
	$('shippingpanel').style.display = 'block';
	$('paymentpanel').style.display = 'none';
}

function paymentSubmit() {
	
	if (!$('cardpanel')) {
		return true;
	}
	
	if ($('cardpanel').style.display == 'none') {
		return true;
	}
	
	var isValid = true;
	
	if (isEmptyField(instr+'cardholdernametxt', 'אנא הכנס את שם בעל כרטיס האשראי')) {
		isValid = false;
	}
	if (isEmptyField(instr+'numbertxt', 'אנא הכנס מס\' כרטיס אשראי')) {
		isValid = false;
	}
	if (isEmptyField(instr+'cardtypeselect', 'אנא בחר את סוג כרטיס האשראי')) {
		isValid = false;
	}
	if (isEmptyField(instr+'expirationmonthselect', 'אנא בחר חודש')) {
		isValid = false;
	}
	if (isEmptyField(instr+'expirationyearselect', 'אנא בחר שנה')) {
		isValid = false;
	}
	if (isEmptyField(instr+'cvvtxt', 'אנא הכנס קוד אימות')) {
		isValid = false;
	}
	if (isNumericField(instr+'cvvtxt', 'אנא הכנס קוד אימות תקין')) {
		isValid = false;
	}
	
	return isValid;
	
}


