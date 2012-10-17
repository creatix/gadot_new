
var selectedframe = '1';

function showBanner(frame) {
	document.getElementById('mainbanner').src = 'img/mainbanner'+frame+'.jpg';
	document.getElementById('mb'+frame).className = 'b'+frame+'selected';
	document.getElementById('mb'+selectedframe).className = 'b'+selectedframe;
	selectedframe = frame;
}