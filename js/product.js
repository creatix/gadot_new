
var selectedTab='';
function selectTab(id) {
	if (selectedTab == id) {
		return;
	}
	document.getElementById('tabcontent'+id).style.display = 'block';
	document.getElementById('tabbut'+id).className = 'selected';
	if (selectedTab != '') {
		document.getElementById('tabcontent'+selectedTab).style.display = 'none';
		document.getElementById('tabbut'+selectedTab).className = '';
	}
	selectedTab = id;
}
function initTabs(id) {
	if (id == undefined) { id = 1; }
	if (document.getElementById('tabcontent'+id).innerHTML == '') {
		document.getElementById('tabbut'+id).style.display = 'none';
	} else {
		if (selectedTab == '') { selectTab(id); }
	}
	if (document.getElementById('tabcontent'+(id+1))) {
		initTabs(id+1);
	} else {
		if (selectedTab == '') { document.getElementById('tabspanel').style.display = 'none'; }
	}
}

function showmodal(url) {
	document.getElementById('modaliframe').src = url;
	document.getElementById('modalbackground').style.display = 'block';
	document.getElementById('modalwindow').style.display = 'block';
	return false;
}

function closemodal() {
	document.getElementById('modalbackground').style.display = 'none';
	document.getElementById('modalwindow').style.display = 'none';
}

var thumbindex = 0;

function showthumb(index,pic,name) {
	thumbindex = index;
	document.getElementById('mainpic').innerHTML = '<a href="#" onclick="return showpic('+index+');" title="'+name+'" class="bigpic"><img src="components/img.aspx?img=images\\'+pic+'&width=381&height=381" width="381" height="381" /><span></span></a>';
	return false;
}

function showpic(i) {
	milkbox.showGallery({ gallery:'gall1', index:thumbindex })
	return false;
}

function open_popup(theURL,w,h,window_name) {
	features="product_browser.aspx','toolbar=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,width="+w+",height="+h;
	window.open(theURL,window_name,features);
}

function open_compare(productid) {
	
	var p_list = '';
	var count = 0;
	
	var inputRefArray = document.getElementsByTagName('input');
	
	for (var i=0; i<=inputRefArray.length-1; i++) {
		if (inputRefArray(i).type == 'checkbox') {
			if (inputRefArray(i).checked) {
				p_list = p_list + inputRefArray(i).value + ',';
				count++;
			}
		}
	}
		
	if (count>6) {
		alert("אנא בחרו לא יותר מ-6 מוצרים");
		return;
	}
		
	if (p_list == "") {
		alert("אנא בחר מוצרים להשוואה");
	} else {
		p_list = productid + ',' + p_list;
		open_popup('compare.aspx?p='+p_list,800,600,'product_compare');
	}

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

function addToBasket(id) {
	window.location = 'basket.aspx?pid='+id;
}
