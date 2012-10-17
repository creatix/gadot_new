/// <reference path="jquery-1.4.4.min.js" />
var originalSizeRelation = 896 / 1376;
// window load script1376x896
$(window).load(function () {
    // set mid content height
    $(".midContent").height($(".textContent").height() + 200);
    // right pic sizes
    //originalSizeRelation = parseFloat($(".rightPic IMG").width()) / parseFloat($(".rightPic IMG").height());
    
    setRightImgSize();
    
    //alert($(window).height());
    if ($(window).height() > $(".midContent").height()){
       $(".midContent").height($(window).height()-10);
    }   
  
    $(".rightPic").css("opacity", "1");
	
	//$(".footer").css("display","block");

    $(window).resize(function () {
        setRightImgSize();
    });
  
  $("html").resize(function(){
    //console.log("a");
  });
   $("body").resize(function(){
    //console.log("b");
  });
 
    
});

// document ready script
$(document).ready(function() {

    
	//$(".footer").css("display","none");
    // set mid content height
    

    $(".midContent").height($(".textContent").height() + 250);
    if ($("BODY > .black").length > 0)
    {
        $(".midContent").height($(".textContent").height() + 300);
    }
    if ($(window).height() > $(".midContent").height()){
       $(".midContent").height($(window).height()-10);
    }

    // menu tooltip
    $('.toolLink').hover(function() {
        $(this).children('.linkToolTip').toggle();
    });

    // right pic.
    setRightImgSize();

    // menu drop down
    $(".dropMenu").each(function() {
        var dmHeight = $(this).height();
        $(this).find(".sub2").css("min-height", dmHeight - 26);
    });


    $("LI.frstLvl").each(function() {
        var outDelay;
        $(this).hover(function() {
            clearTimeout(outDelay);
            $("LI.frstLvl").not($(this)).removeClass("onM");
            $(this).addClass("onM");
        }, function() {
            var obj = $(this);
            outDelay = setTimeout(function() {
                if (!(obj.hasClass("on"))) {
                    obj.removeClass("onM");
                }
            }, 100);
        });
    });

    $(".topNav ul LI .dropMenu").hover(function() {
        $(this).parent("LI").addClass("on");
    },
    function() {
        $(this).parent("LI").removeClass("on");
    });

    $(".sub2").hover(function() {
        $(this).parent("LI").addClass("on");
    },
    function() {
        $(this).parent("LI").removeClass("on");
    });

    // clear empty <p> from macros in textContent. 
    $(".textContent .pWidth").each(function() {
        if ($.trim($(this).prev("P").html()) == "") {
            $(this).prev("P").remove();
        }
        if ($.trim($(this).next("DIV").next("P").html()) == "") {
            $(this).next("DIV").next("P").remove();
        }
    });

    $(".textContent .h3Width").each(function() {
        if ($.trim($(this).prev("P").html()) == "") {
            $(this).prev("P").remove();
        }
        if ($.trim($(this).next("DIV").next("P").html()) == "") {
            $(this).next("DIV").next("P").remove();
        }
    });

    $(".textContent .FlashPlayer").each(function() {
        if ($.trim($(this).prev("P").html()) == "") {
            $(this).prev("P").remove();
        }
        if ($.trim($(this).next("P").html()) == "") {
            $(this).next("P").remove();
        }
    });

    $(".textContent .gallpic").each(function() {
        if ($.trim($(this).prev("P").html()) == "") {
            $(this).prev("P").remove();
        }
        if ($.trim($(this).next("P").html()) == "") {
            $(this).next("P").remove();
        }
    });

    $(".textContent .dataList").each(function() {
        if ($.trim($(this).prev("P").html()) == "") {
            $(this).prev("P").remove();
        }
        if ($.trim($(this).next("P").html()) == "") {
            $(this).next("P").remove();
        }
    });

    // clear inputs 
    $(".clearInput").each(function() {
        var currentVal = $(this).val();
        $(this).focus(function() {
            if ($(this).val() == currentVal) {
                $(this).val("");
            }
        });
        $(this).blur(function() {
            if ($(this).val() == "") {
                $(this).val(currentVal);
            }
        });

    });

    // social - blog feed
    $('.blogFeed').rssfeed("http://blog.microsoftrnd.co.il/en/?feed=rss2", {
        limit: 1
    });

    //open social tolls
    $('.socialOpen').css("width", "0");
    $('.socialTools').css("width", "0");
    $('.socialOpen').css("padding", "0");
    $("#twtr-widget-1").hide(0);

    $('#tabLink').click(function() {
        if ($(this).hasClass('tab')) {
            $(this).attr('class', 'tab_open');
            $('.socialOpen').css("display", "block");
            $('.socialOpen').animate({ "width": "360", "padding": "20" }, 600);
            $("#twtr-widget-1").show(0);
            $('.socialTools').animate({ "width": "400" }, 600);
        } else {
            $(this).attr('class', 'tab');
            $('.socialOpen').animate({ "width": "0", "padding": "0" }, 600);
            $('.socialTools').animate({ "width": "0" }, 600, function() {
                $("#twtr-widget-1").hide(0);
            });
        }
    });

    /// gallery - general

    $(".gallpic .HotGalNav LI IMG").live('click', function() {
        $(this).prev("A").click();
    });

    $(".gallpic .HotGalNav LI A").live('click', function() {
        var galleryObj = $(this).closest(".gallpic");
        galleryObj.find(".HotGalNav LI A").removeClass('selectPic');
        curImg = $(this).closest("LI").find("IMG");
        var imgSrc = curImg.attr("src");
        imgSrc = imgSrc.replace("_thumb.jpg", ".jpg");
        galleryObj.find(".galleryBigPic IMG.bottomImage").css("display", "none");
        galleryObj.find(".galleryBigPic .loading").css("display", "block");
        galleryObj.find(".galleryBigPic IMG.bottomImage").attr("src", imgSrc);
        galleryObj.find(".galleryBigPic IMG.topImage").fadeOut(500);
        //galleryObj.find(".galleryBigPic IMG.topImage").attr("src", galleryObj.find(".galleryBigPic IMG.bottomImage").attr("src"));
        //galleryObj.find(".galleryBigPic IMG.topImage").css("display", "block");

        $(this).closest(".gallpic").find(".galleryBigPic .picText .textPadding").html(curImg.attr("alt"));
        $(this).addClass('selectPic');
    });

    $(".galleryBigPic IMG.bottomImage").load(function() {
        var galleryObj = $(this).closest(".gallpic");
        galleryObj.find(".galleryBigPic .loading").css("display", "none");
        galleryObj.find(".galleryBigPic IMG.bottomImage").fadeIn(500, function() {
            galleryObj.find(".galleryBigPic IMG.topImage").attr("src", galleryObj.find(".galleryBigPic IMG.bottomImage").attr("src"));
            galleryObj.find(".galleryBigPic IMG.topImage").css("display", "block");
        });
    });

    $(".galleryBigPic").live("click", function() {
        var galleryObj = $(this).closest(".gallpic");
        if (!galleryObj.find(".HotGalNav").is(":animated")) {
            if (galleryObj.hasClass("isM")) {
                navObject = galleryObj.find(".smallPic");
                currintInd = navObject.find("LI A").index(navObject.find("A.selectPic"));
                if (currintInd < 2) {
                    navObject.find("LI A:eq(" + (currintInd + 1) + ")").click();
                }
                else if (currintInd == 2) {
                    navObject.find("LI A:eq(" + (currintInd - 1) + ")").click();
                    navObject.find(".galleryR").click();
                }
                else {
                    navObject.find("LI A:eq(" + (currintInd - 1) + ")").click();
                }
            }
        }
    });

    $(".gallpic").each(function() {
        var imgNav = $(this).find(".HotGalNav");
        if (imgNav.find("LI").length > 4) {
            $(this).addClass("isM");
            imgNav.width(122 * imgNav.find("LI").length + 1);
            imgNav.css("left", "-8px");
            imgNav.find("LI:first A").addClass('selectPic');
            imgNav.prepend(imgNav.find("LI:last"));
        }
        else {
            $(this).find(".galleryR").css("display", "none");
            $(this).find(".galleryL").css("display", "none");
            imgNav.find("LI:first A").addClass('selectPic');
        }
    });

    $(".galleryR").click(function() {
        galleryObj = $(this).closest(".gallpic");
        if (!galleryObj.find(".HotGalNav").is(":animated")) {
            var tempObj = galleryObj.find(".HotGalNav LI:last").clone();
            galleryObj.find(".HotGalNav").prepend(tempObj);
            galleryObj.find(".HotGalNav").css("left", "-130px");
            galleryObj.find(".HotGalNav").animate({ "left": "+=122px" }, 500, function() {
                galleryObj.find(".HotGalNav LI:last").remove();
            });
        }
    });

    $(".galleryL").click(function() {
        galleryObj = $(this).closest(".gallpic");
        if (!galleryObj.find(".HotGalNav").is(":animated")) {
            var tempObj = galleryObj.find(".HotGalNav LI:first").clone();
            galleryObj.find(".HotGalNav").append(tempObj);
            galleryObj.find(".HotGalNav").animate({ "left": "-=122px" }, 500, function() {
                galleryObj.find(".HotGalNav LI:first").remove();
                galleryObj.find(".HotGalNav").css("left", "-8px");
            });
        }
    });

    // vidoe player
    $(".FlashPlayer").each(function(idx, obj) {
        var _this = $(obj);
        var _href = _this.children("a").attr("href");
        var _img = _this.children(".hdnBGI").val();
        _this.children("a").remove();
        _this.children(".hdnBGI").remove();
        _this.flash({
            src: '/scripts/videoPlayerInner.swf?file=' + _href,
            width: 590,
            height: 332,
            flashvars: { playColor: '0xFFC000' },
            allowFullScreen: true,
            wMode: 'transparent'
        });
        _this.css("backgroundImage", "url('" + _img + "')");
    });


    // video gallery
    $(".videoGallery .HotGalNav LI IMG").live('click', function() {
        $(this).prev("A").click();
    });

    $(".videoGallery .HotGalNav LI A").live('click', function() {
        var galleryObj = $(this).closest(".videoGallery");
        galleryObj.find(".HotGalNav LI A").removeClass('selectPic');
        curImg = $(this).closest("LI").find("IMG");
        var imgSrc = curImg.attr("src");
        var videoSrc = $(this).closest("LI").find(".hdnVid").val();
        $(this).addClass('selectPic');
        galleryObj.find(".galFlashPlayer").html("");
        var _this = galleryObj.find(".galFlashPlayer");
        _this.children("a").remove();
        _this.children(".hdnBGI").remove();
        _this.flash({
            src: '/scripts/videoPlayerInner.swf?file=' + videoSrc,
            width: 590,
            height: 332,
            flashvars: { playColor: '0x004083' },
            allowFullScreen: true,
            wMode: 'transparent'
        });
        _this.css("backgroundImage", "url('" + imgSrc + "')");
    });

    $(".galleryBigPic IMG.bottomImage").load(function() {
        var galleryObj = $(this).closest(".videoGallery");
        galleryObj.find(".galleryBigPic .loading").css("display", "none");
        galleryObj.find(".galleryBigPic IMG.bottomImage").fadeIn(500, function() {
            galleryObj.find(".galleryBigPic IMG.topImage").attr("src", galleryObj.find(".galleryBigPic IMG.bottomImage").attr("src"));
            galleryObj.find(".galleryBigPic IMG.topImage").css("display", "block");
        });
    });

    $(".VidgalleryR").click(function() {
        galleryObj = $(this).closest(".videoGallery");
        if (!galleryObj.find(".HotGalNav").is(":animated")) {
            var tempObj = galleryObj.find(".HotGalNav LI:last").clone();
            galleryObj.find(".HotGalNav").prepend(tempObj);
            galleryObj.find(".HotGalNav").css("left", "-130px");
            galleryObj.find(".HotGalNav").animate({ "left": "+=122px" }, 500, function() {
                galleryObj.find(".HotGalNav LI:last").remove();
            });
        }
    });

    $(".VidgalleryL").click(function() {
        galleryObj = $(this).closest(".videoGallery");
        if (!galleryObj.find(".HotGalNav").is(":animated")) {
            var tempObj = galleryObj.find(".HotGalNav LI:first").clone();
            galleryObj.find(".HotGalNav").append(tempObj);
            galleryObj.find(".HotGalNav").animate({ "left": "-=122px" }, 500, function() {
                galleryObj.find(".HotGalNav LI:first").remove();
                galleryObj.find(".HotGalNav").css("left", "-8px");
            });
        }
    });

    $(".videoGallery").each(function() {
        var imgNav = $(this).find(".HotGalNav");
        if (imgNav.find("LI").length > 4) {
            $(this).addClass("isM");
            imgNav.width(122 * imgNav.find("LI").length + 1);
            imgNav.css("left", "-8px");
            imgNav.find("LI:first A").click();
            imgNav.prepend(imgNav.find("LI:last"));
        }
        else {
            //alert("a");
            $(this).find(".VidgalleryR").css("display", "none");
            $(this).find(".VidgalleryL").css("display", "none");
            imgNav.find("LI:first A").click().click();
        }
    });

    // data lists - general
    $('A.moreLink').click(function() {
        var link = $(this);
        link.hide(500);
        link.closest("LI").find(".forBorder").show(500);
        link.next('DIV.moreText').slideDown(500, function() {
            $(".midContent").height($(".textContent").height() + 250);
        });

    });
    $('A.closeText').click(function() {
        var link = $(this);
        link.parent('DIV.moreText').slideUp(500, function() {
            $(".midContent").height($(".textContent").height() + 250);
        });
        link.closest("LI").find(".forBorder").hide(500);
        link.parent('DIV.moreText').prev('A.moreLink').show(500);
    });

    // scroll top links
    $('a.topLink').click(function() {
        $('html, body').animate({ scrollTop: 0 }, 'slow');
    });


});

$(window).load(function() {
    // fix for ie 7
    $("DIV.socialTools A.tab").show(0);

      // left menu bottom gallery
    $(".leftGallery A:first").css("display", "block");
    $(".nav A:first").addClass("activeSlide");
    if ($(".leftGallery A").length > 0 )
    {
      $(".leftGallery").height($(".leftGallery A:first").height());
    }
    var leftGalleryImagesSum = $(".nav A").length;
    var leftGalleryCurrentInd = 0;

      
  
    var galleryInterval = setInterval(function () {
        leftGalleryCurrentInd++;
        if (leftGalleryCurrentInd == leftGalleryImagesSum) {
            leftGalleryCurrentInd = 0;
        }
        changeLeftGalleryImg(leftGalleryCurrentInd);
    }, 8000);
  
    $(".nav A").click(function () {
        if (!($(".leftGallery A").is(":animated"))) {
            leftGalleryCurrentInd = $(".nav A").index($(this));
            clearInterval(galleryInterval);
            changeLeftGalleryImg(leftGalleryCurrentInd);
            galleryInterval = setInterval(function () {
                leftGalleryCurrentInd++;
                if (leftGalleryCurrentInd == leftGalleryImagesSum) {
                    leftGalleryCurrentInd = 0;
                }
                changeLeftGalleryImg(leftGalleryCurrentInd);
            }, 8000);
        }
    });   
});

function setRightImgSize() {
    var newHeight = parseInt($("BODY").height());
    if (newHeight < 768) {
        newHeight = 768;
    }
    $(".rightPic IMG").height(newHeight);
    $(".rightPic IMG").width(parseInt(originalSizeRelation * newHeight));
    if ($("BODY").width() > (1016 + $(".rightPic").width())) {
        var newWidth = parseInt($("BODY").width() - 1016);
        $(".rightPic IMG").width(newWidth);
        $(".rightPic IMG").height(parseInt(newWidth / originalSizeRelation));
    }
}

function changeLeftGalleryImg(ind) {
    $(".leftGallery A:visible").fadeOut(500, function () {
        $(".leftGallery A:eq(" + ind + ")").fadeIn(500);
    });
    $(".nav .activeSlide").removeClass("activeSlide");
    $(".nav A:eq(" + ind + ")").addClass("activeSlide");
}