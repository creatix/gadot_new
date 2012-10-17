	var tout;
	var i = 0;
	var currentlink;
	
	if(arr.length == 1)
	{
		document.getElementById("imgPictures").src = arr[0];
	}
	else
	{

			function ShowPictures() {
				
				if (arr[i]==undefined) {
					return;
				}
			
				var loader = new Asset.images(arr[i], {
					onComplete: function() {
					
						$('loaderdivPictures').empty();
						var imgobj = new Element('img',{ src:arr[i], width:$('loaderdivPictures').style.width, height:$('loaderdivPictures').style.height }).inject($('loaderdivPictures'));
						imgobj.width = $('loaderdivPictures').style.width.replace('px','');
						imgobj.height = $('loaderdivPictures').style.height.replace('px','');
						$('loaderdivPictures').setOpacity(0);
						currentlink = arrlinks[i];
						if (currentlink == '') {
							currentlink = '#';
						}
						var fx = new Fx.Style('loaderdivPictures', 'opacity', {
							duration: 600,
							transition: Fx.Transitions.Back.easeInOut,
							wait: true,
							onComplete:function() {
								$('divPictures').innerHTML = $('loaderdivPictures').innerHTML;
								$('divPictures').href = currentlink;
								$('loaderdivPictures').href = currentlink;
								$('loaderdivPictures').empty();
							}
						});
						fx.start(1);
						
						selectbut(i);
						
						i++;
						if(i > arr.length - 1)
						i=0;
						removeTimer();
						tout = setTimeout('ShowPictures()',5000);
						
					}
				});
			}
	}
	
	function selectbut(i) {
		for (var j=0; j<=arr.length-1; j++) {
			$('navbut'+j).style.backgroundColor = '#00aeef';
		}
		$('navbut'+i).style.backgroundColor = '#703695';
	}
	
	function initbannernav() {
		var str='';
		for (var j=0; j<=arr.length-1; j++) {
			str += '<a href="javascript:showframe('+j+');" id="navbut'+j+'" style="width:10px; height:10px; float:left; background-color:#00aeef; border:1px solid #00aeef; margin-right:5px;"></a>';
		}
		document.getElementById("bannernav").innerHTML = str;
		selectbut(0);
		i=i+1;
		tout = setTimeout('ShowPictures()',5000);
	}
	
	function showframe(num) {
		i = num;
		currentlink = arrlinks[i];
		ShowPictures();
		selectbut(i);
	}
	
	function removeTimer() {
		clearTimeout(tout);
	}
	
	function startTimer() {
		clearTimeout(tout);
		tout = setTimeout('ShowPictures()',5000);
	}

	window.onload=initbannernav;