
function load_html(cont, url) {
	//$(cont).fade(1,0);
	$(cont).empty().addClass('ajax-loading');
	var req = new Request.HTML({
					method: 'post',
					url: url,
					onRequest: function() {  },
					//update: $('login_win'),
					onComplete: function(response) {
						$(cont).setOpacity(0);
						$(cont).removeClass('ajax-loading');
						$(cont).empty();
						$(cont).adopt(response);
						//myVerticalSlide = new Fx.Slide('cat_strip_container');
						$(cont).fade(0,1);
					}
				}).send();
}


function formatPrice(n) {
	var DecimalSeparator = Number("1.2").toLocaleString().substr(1,1); 
	var AmountWithCommas = n.toLocaleString(); 
	var arParts = String(AmountWithCommas).split(DecimalSeparator); 
	var intPart = arParts[0];
	 
	return '$' + intPart; 
}

function IsNumeric(sText) {
	var ValidChars = "0123456789.";
	var IsNumber=true;
	var Char;
	for (i = 0; i < sText.length && IsNumber == true; i++) { 
    	Char = sText.charAt(i); 
    	if (ValidChars.indexOf(Char) == -1) {
        	IsNumber = false;
        }
    }
	return IsNumber;
}

function isEmptyField(id, msg) {
	if ($(id).value == '') {
		if (msg == undefined) { msg = 'שדה זה שדה חובה'; }
		insertFieldComment(id, msg);
		return true;
	} else {
		clearFieldComment(id);
	}
	return false;
}

function isNumericField(id, msg) {
	if (!IsNumeric($(id).value)) {
		if (msg == undefined) { msg = 'שדה זה שדה מספרי'; }
		insertFieldComment(id, msg);
		return true;
	}
	return false;
}

function insertFieldComment(id, msg) {
	var divObj;
	if ($(id+'_comment')) {
		divObj = $(id+'_comment')
	} else {
		divObj  = new Element('div', {id: id+'_comment'});
	}
	divObj.className = 'fielderror';
	divObj.innerHTML = msg;
	divObj.inject($(id), 'after');
	$(id).style.border = '2px solid #F00';
}

function clearFieldComment(id,removeborder) {
	if ($(id+'_comment')) {
		if (removeborder == 'true') {
			$(id).style.border = '0px';
		} else {
			$(id).style.border = '1px solid #b3b3b3';
		}
		$(id+'_comment').dispose();
	}
}


