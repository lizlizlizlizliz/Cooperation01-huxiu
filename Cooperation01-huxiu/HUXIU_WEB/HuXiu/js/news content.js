$(function () {
    var img2d = $("<img>").attr("id", "QRimg").css({ "width": "100px", "height": "100px", "margin": "10px auto" }).attr("src", "/Ajax/QRshare.ashx?str=" + window.location.href).appendTo($(".wechat-2d"));
	$(".operate-click").click(function(){
		$(this).css({
			"backgroundPosition":"0px -1px"
		});
		$(".operate-click-2").css({"display":"block","opacity":1})
		.animate({bottom:"+=20px",opacity:0},850,afterZan);
	})
	function afterZan(){
		$(".operate-click-2").css({
			"display":"none",
			"bottom":"-=20px",
			"opacity":1
		});
	}
	//点赞飞起效果
	$(".click-to-close").css({
		"width":$(document).width(),
		"height":"1000px",
		"zIndex":-5
	});
	$(".operate-share").click(function(){
		$(".wechat-weibo")
		.css({"display":"block","opacity":0})
		.stop()
		.animate({opacity:1},200);
		$(".click-to-close").css({
			"zIndex":3
		});
	})
	$(".click-to-close").click(function(){
		$(".wechat-weibo")
		.stop()
		.animate({ opacity: 0 }, 200);
		$(".wechat-2d").css({
		    "opacity": 0,
		    "top": "60px"
		});
		$(".click-to-close").css({
			"zIndex":-5
		});
	})
	$(".wechat-2d").css({"opacity":0});
	$(".weibo-2d").css({"opacity":0});
	$(".weibo").click(function () {
	    $(".wechat-2d").css({
	        "opacity": 0,
	        "top": "60px"
	    });
		//$(".weibo-2d")
		//.stop()
		//.animate({"top":"50px","opacity":1},100);
	})
	$(".wechat").click(function(){
		//$(".weibo-2d").css({
		//	"opacity":0,
		//	"top":"60px"
		//});
		$(".wechat-2d")
		.stop()
		.animate({"top":"50px","opacity":1},100);
	})


/*	$(".share-first").hover(appendShare,removeShare);
	function appendShare(){
		$(".wechat-weibo")
		.css({"display":"block","opacity":0})
		.stop()
		.animate({opacity:1},200);
	}
	function removeShare(){
		$(".wechat-weibo")
		.stop()
		.animate({opacity:0},200);
	}
	$(".weibo").hover(aWeibo2d,rWeibo2d);
	function aWeibo2d(){
		$(".weibo-2d").css({
			"display":"block",
		})
		.stop()
		.animate({"top":"55px"});
		$(".weibo").css({"backgroundPosition":"0 0"});
	}
	function rWeibo2d(){
		$(".weibo-2d").css({
			"display":"none",
			"top":"65px",
		});
		$(".weibo").css({"backgroundPosition":"0 -35px"});
	}
	$(".wechat").hover(aWechat2d,rWechat2d);
	function aWechat2d(){
		$(".wechat-2d").css({
			"display":"block",
		})
		.stop()
		.animate({"top":"55px"});
		$(".wechat").css({"backgroundPosition":"-65px 0"});
	}
	function rWechat2d(){
		$(".wechat-2d").css({
			"display":"none",
			"top":"65px",
		});
		$(".wechat").css({"backgroundPosition":"-65px -35px"});
	}*/
	//二维码效果

	/*$(".activity-mouseover-img").click(function(){
		window.location="http://www.ouc.edu.cn";
		//注意此处，一定要把网址换掉！！
	})*/
	var actChange;
	var actchangeNow;
	$(".activity-more").hover(actOn,actOut);
	function actOn(){
		$(this).stop().find(".activity-mouseover-img").css({
			"visibility":"visible",
			"opacity":1
		})
		actChange=$(".activity-more").index(this);
		//$(this).find("a")
		actchangeImg=$(".activity-mouseover-img:eq("+actChange+")");
		$(".activity-mouseover-img").not(actchangeImg)
		.css({
			"opacity":0
		});
		actchangeNow=$(".activity-more a:eq("+actChange+")");
		actchangeNow
		.css({"visibility":"visible"})
		.animate({bottom:0},200);
		$(".activity-more a").not(actchangeNow)
		.css({
			"visibility":"hidden",
			"bottom":-40
		});
	}
	function actOut(){
		$(this).find(".activity-mouseover-img").stop(false,true)
		/*.css({
			"visibility":"hidden"
		});*/
		.css({"opacity":0})
		//$(this).find("a")
		$(".activity-more a")
		.css({
			"visibility":"hidden",
			"bottom":-40
		});
	}
	//相关活动 相关文章效果
})

$(document).ready(function () {
    $(".weibo").click(function () {
        var a = window.location.href;
        var b = window.location.href.lastIndexOf('/') + 1;
        //var c = window.location.href.substring(0, b) + jsonObj[j].imgSrc.substring(1);
        var d = $(".writer-title").children("h1").children("span").text();
        var c = window.location.href.substring(0, b) + $("#ContentPlaceHolder1_image").attr("src");
        window.open("http://service.weibo.com/share/share.php?appkey=1934882415&url=" + a + "&title=" + d + "@艾特网&content=utf-8&pic=" + c + "#_loginLayer_1490090511099");
    });
})