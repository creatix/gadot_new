
function shownews(url) {
	features=url+"','toolbar=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600";
	window.open(url,'news',features);
	return false;
}

function supportagree() {
	if (document.getElementById('supportcb').checked) {
		document.getElementById('supportbut').disabled = false;
	} else {
		document.getElementById('supportbut').disabled = true;
	}
}

function searchSite() {
	window.location = 'search.aspx?keyword=' + document.getElementById('keyword').value;
}

function searchShop() {
	window.location = 'searchproducts.aspx?keyword=' + document.getElementById('keyword').value;
}

function popupform(myform, windowname) {
	if (! window.focus) return true;
	window.open('', windowname, 'toolbar=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,width=500,height=350');
	myform.target=windowname;
	return true;
}

function userlogin() {
	window.location = 'index.aspx?email=' + document.getElementById('email').value + '&password=' + document.getElementById('password').value;
}
