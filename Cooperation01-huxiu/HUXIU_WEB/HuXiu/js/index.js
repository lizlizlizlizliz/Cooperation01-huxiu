

//热文/短趣切换
$(document).ready(function(){//加载整个DOM元素
	$(".hot").hover(function(){
		$(".content").eq(1).addClass("displayNone");
		$(".content").eq(0).removeClass("displayNone");
		$(".hot").addClass("hover");
		$(".interesting").removeClass("hover");
	});
	$(".interesting").hover(function(){
		$(".content").eq(0).addClass("displayNone");
		$(".content").eq(1).removeClass("displayNone");
		$(".interesting").addClass("hover");
		$(".hot").removeClass("hover");
	});
});

//短趣弹窗
$(document).ready(function(){
	$("#content").children(".issay").children("h1").click(function(){
		$(".shortA").css({"display":"block","position":"fixed"});
	});
	$(".close").mouseover(function(){
		$(".close").css({"background":"url(images/close-orange.png)"});
	})
	$(".close").mouseout(function(){
		$(".close").css({"background":"url(images/close.png)"});
	})
	$(".close").click(function(){
		$(".shortA").css({"display":"none"});
	})
})


//轮播按钮hover
$(document).ready(function(){
	//左切换按钮
	$(".turnLeft").mouseover(function(){
		$(".turnLeft").css({"background":"url(images/arrow-left-orange.png)"});
	});
	$(".turnLeft").mouseout(function(){
		$(".turnLeft").css({"background":"url(images/arrow-left-black.png)"});
	});
	//右切换按钮
	$(".turnRight").mouseover(function(){
		$(".turnRight").css({"background":"url(images/arrow-right-orange.png)"});
	});
	$(".turnRight").mouseout(function(){
		$(".turnRight").css({"background":"url(images/arrow-right-black.png)"});
	});
});


////轮播效果
//$(document).ready(function(){
//	//初始化
//	$(".turnImg").children("li").eq(0).css({"left":"0px"});
//	$(".turnImg").children("li").eq(1).css({"left":"1000px"});
//	$(".turnImg").children("li").eq(2).css({"left":"2000px"});
//	$(".turnImg").children("li").eq(3).css({"left":"3000px"});
//	//轮播事件-右
//	$(".turnRight").click(function(){
//		//防止连续多按页面崩溃
//		$(".turnImg").children("li").stop(true,true);
//		$(".turnImg").children("li").eq(0).animate({left:'-1000px'},350);
//		$(".turnImg").children("li").eq(1).animate({left:'0px'},350);
//		$(".turnImg").children("li").eq(2).animate({left:'1000px'},350);
//		$(".turnImg").children("li").eq(3).animate({left:'2000px'},350,function(){//调换li标签顺序
//			$(".turnImg").children("li").eq(3).after($(".turnImg").children("li").eq(0));
//			$(".turnImg").children("li").eq(3).css({"left":"3000px"});
//		});
//	});

//	//轮播事件-左
//	$(".turnLeft").click(function(){
//		//防止连续多按页面崩溃
//		$(".turnImg").children("li").stop(true,true);
//		$(".turnImg").children("li").eq(3).css({"left":"-1000px"});
//		$(".turnImg").children("li").eq(0).animate({left:'1000px'},350);
//		$(".turnImg").children("li").eq(1).animate({left:'2000px'},350);
//		$(".turnImg").children("li").eq(2).animate({left:'3000px'},350);
//		$(".turnImg").children("li").eq(3).animate({left:'0px'},350,function(){//调换li标签顺序
//			$(".turnImg").children("li").eq(0).before($(".turnImg").children("li").eq(3));
//		});
//	});
//})
//响应式
//轮播效果
$(document).ready(function () {
    if (window.screen.width > 1600) {
        $(".turnImg").children("li").eq(0).css({ "left": "0px" });
        $(".turnImg").children("li").eq(1).css({ "left": "1405px" });
        $(".turnImg").children("li").eq(2).css({ "left": "2810px" });
        $(".turnImg").children("li").eq(3).css({ "left": "4215px" });
        //轮播事件-右
        $(".turnRight").click(function () {
            //防止连续多按页面崩溃
            $(".turnImg").children("li").stop(true, true);
            $(".turnImg").children("li").eq(0).animate({ left: '-1405px' }, 350);
            $(".turnImg").children("li").eq(1).animate({ left: '0px' }, 350);
            $(".turnImg").children("li").eq(2).animate({ left: '1405px' }, 350);
            $(".turnImg").children("li").eq(3).animate({ left: '2810px' }, 350, function () {//调换li标签顺序
                $(".turnImg").children("li").eq(3).after($(".turnImg").children("li").eq(0));
                $(".turnImg").children("li").eq(3).css({ "left": "4215px" });
            });
        });

        //轮播事件-左
        $(".turnLeft").click(function () {
            //防止连续多按页面崩溃
            $(".turnImg").children("li").stop(true, true);
            $(".turnImg").children("li").eq(3).css({ "left": "-1405px" });
            $(".turnImg").children("li").eq(0).animate({ left: '1405px' }, 350);
            $(".turnImg").children("li").eq(1).animate({ left: '2810px' }, 350);
            $(".turnImg").children("li").eq(2).animate({ left: '4215px' }, 350);
            $(".turnImg").children("li").eq(3).animate({ left: '0px' }, 350, function () {//调换li标签顺序
                $(".turnImg").children("li").eq(0).before($(".turnImg").children("li").eq(3));
            });
        });
    }
    else {
        //初始化
        $(".turnImg").children("li").eq(0).css({ "left": "0px" });
        $(".turnImg").children("li").eq(1).css({ "left": "1000px" });
        $(".turnImg").children("li").eq(2).css({ "left": "2000px" });
        $(".turnImg").children("li").eq(3).css({ "left": "3000px" });
        //轮播事件-右
        $(".turnRight").click(function () {
            //防止连续多按页面崩溃
            $(".turnImg").children("li").stop(true, true);
            $(".turnImg").children("li").eq(0).animate({ left: '-1000px' }, 350);
            $(".turnImg").children("li").eq(1).animate({ left: '0px' }, 350);
            $(".turnImg").children("li").eq(2).animate({ left: '1000px' }, 350);
            $(".turnImg").children("li").eq(3).animate({ left: '2000px' }, 350, function () {//调换li标签顺序
                $(".turnImg").children("li").eq(3).after($(".turnImg").children("li").eq(0));
                $(".turnImg").children("li").eq(3).css({ "left": "3000px" });
            });
        });

        //轮播事件-左
        $(".turnLeft").click(function () {
            //防止连续多按页面崩溃
            $(".turnImg").children("li").stop(true, true);
            $(".turnImg").children("li").eq(3).css({ "left": "-1000px" });
            $(".turnImg").children("li").eq(0).animate({ left: '1000px' }, 350);
            $(".turnImg").children("li").eq(1).animate({ left: '2000px' }, 350);
            $(".turnImg").children("li").eq(2).animate({ left: '3000px' }, 350);
            $(".turnImg").children("li").eq(3).animate({ left: '0px' }, 350, function () {//调换li标签顺序
                $(".turnImg").children("li").eq(0).before($(".turnImg").children("li").eq(3));
            });
        });
    }
});


//$(document).ready(function () {
//    $(".newsList").on("click", ".news", function () {
//        var id = $(this).children("h1").attr("id");
//        window.open("PassageContent.aspx?id=" + id);
//    })
//})

$(document).ready(function(){
	$(".newsList").on("mouseover",".share",function(){
		$(this).css({"background":"url(images/share-orange.png) no-repeat"});
	});
	$(".newsList").on("mouseout",".share",function(){
		$(this).css({"background":"url(images/share-gray.png) no-repeat"});
	});
	$(".newsList").on("mouseover",".collect",function(){
		$(this).css({"background":"url(images/collect-orange.png) no-repeat"});
	});
	$(".newsList").on("mouseout",".collect",function(){
		$(this).css({"background":"url(images/collect-gray.png) no-repeat"});
	});
})



//瀑布流
$(document).ready(function(){
   
    var i = 0, j, jsonObj;
    appendAct();
    var judge=false;
    $(".loading").click(function(){
        appendAct();
    })
    function appendAct(){
        console.log(1);
        i++;
        $.ajax({
            type:"GET",
            url:"/Ajax/IndexHandler.ashx",
            data:{pageNumber:i,pageSize:2},
            //发送给后台，请求第几页信息，每页信息多大
            //dataType:"json",
            async:true,
            success:function(dat){
                if(dat=="[]"){
                    $(".loading")
                    .text("已经到底了")
                    .css({
                        "background":"none",
                        "cursor":"auto",
                        "color":"rgb(85,85,85)"
                    })
                    .removeClass("loadhover");
                }
                else{
                    if(!$(".loading").hasClass("loadhover"))
                    {
                        $(".loading").css({
                            "background":"images/loaddiv.png",
                            "cursor":"pointer"
                        })
                        .text("")
                        
                    }

                    console.log(dat);
                    jsonObj=JSON.parse(dat);
                    console.log(jsonObj);
                    //将json字符串解析为json对象
                    for(j=0;j<jsonObj.length;j++){
                        var news = $("<div>").addClass("news").addClass("shadow").appendTo($(".newsList"));
                        var newsImage = $("<div>").addClass("newsImage").appendTo(news);
                        var png = $("<img>").attr("src", jsonObj[j].PassageImage).appendTo(newsImage);
                        var newsWriter = $("<div>").addClass("newsWriter").appendTo(news);
                        var newsLeft = $("<div>").addClass("newsLeft").appendTo(newsWriter);
                        var icon = $("<img>").attr("src", jsonObj[j].AuthorImage).appendTo(newsLeft);
                        var writer = $("<p>").text(jsonObj[j].AuthorName).appendTo(newsLeft);
                        var newsTitle = $("<h1>").attr("id", jsonObj[j].PassageId).text(jsonObj[j].PassageTitle).appendTo(newsWriter)
                        .click(function () {
                            window.open("PassageContent.aspx?id=" + $(this).attr("id"));
                        });
                        var newsReading = $("<div>").addClass("newsReading").appendTo(newsWriter);
                        var wechatbo = $("<div>").addClass("wechat-weibo").appendTo(newsReading);
                        var weibo = $("<div>").addClass("weibo").appendTo(wechatbo);
                        var weichat = $("<div>").addClass("wechat").appendTo(wechatbo);
                        /*var weibo2d=$("<div>").addClass("weibo-2d").appendTo(wechatbo).css({"opacity":0});*/
                        var wechat2d = $("<div>").addClass("wechat-2d").appendTo(wechatbo).css({ "opacity": 0 });
                        var img2d = $("<img>").attr("id", "QRimg").css({ "width": "100px", "height": "100px", "margin": "10px auto" }).attr("src", "/Ajax/QRshare.ashx?str=" + window.location.href).appendTo(wechat2d);
                        var share = $("<span>").addClass("share").appendTo(newsReading);

                        //var newsReading = $("<div>").addClass("newsReading").appendTo(newsWriter);
                        //    var wechatbo=$("<div>").addClass("wechat-weibo").appendTo(newsReading);
                        //        var weibo=$("<div>").addClass("weibo").appendTo(wechatbo);
                        //        var weichat=$("<div>").addClass("wechat").appendTo(wechatbo);
                        //        /*var weibo2d=$("<div>").addClass("weibo-2d").appendTo(wechatbo).css({"opacity":0});*/
                        //        var wechat2d=$("<div>").addClass("wechat-2d").appendTo(wechatbo).css({"opacity":0});
                        //            var img2d=$("<img>").attr("id","QRimg").css({"width":"100px","height":"100px","margin":"10px auto"}).attr("src","QRshare.ashx?str="+window.location.href).appendTo(wechat2d);
                        //var share = $("<button>").addClass("share").appendTo(newsReading);
                        var collect = $("<button>").addClass("collect").appendTo(newsReading);
                        var reading = $("<p>").text("阅读量"+jsonObj[j].PageViews).appendTo(newsReading);
                        var time = $("<p>").text(jsonObj[j].PublishDate).appendTo(newsReading);
                }
                    console.log("done");
                }
            
                
                //根据后台发来的数据动态添加元素
                //error:function(xhr){
                //    $(".loading").css({
                //        "background":"none",
                //        "cursor":"auto"
                //    })
                //    .text("已经到底了");
                //}
            }})
        $(".newsList").on("click", ".weibo", function () {
            var a = window.location.href;
            var b = window.location.href.lastIndexOf('/') + 1;
            //var c = window.location.href.substring(0, b) + jsonObj[j].imgSrc.substring(1);
            var d = $(this).parent(".wechat-weibo").parent(".newsReading").parent(".newsWriter").children("h1").text();
            var c = window.location.href.substring(0, b) + $(this).parent(".wechat-weibo").parent(".newsReading").parent(".newsWriter").parent(".news").children(".newsImage").children("img").attr("src");
            window.open("http://service.weibo.com/share/share.php?appkey=1934882415&url=" + a + "&title=" + d + "@艾特网&content=utf-8&pic=" + c + "#_loginLayer_1490090511099");
        });
    }
})

//短趣绑数据
 var obj=[
	{
		"title":"这是一本",
		"time":"7小时前",
		"content":"给魅族设计了悬浮音响造型的日本设计师坪井浩尚最近又和Android Objects试验项目玩到了一起。让他产生设计Magic Calendar想法的原因正是出自上一段的需要，在家时不想做拿出手机，解锁，打开app这一系列动作去看日程安排；外观设计思想则是随着挂历的形态而流动",
		"href":"index.html"
	},
	{
		"title":"可以挂在墙上的魔法日历",
		"time":"2017-4-5",
		"content":"所以使用无框电子墨水屏作为它的显示材料，让其显示Android手机上的日程安排并保持同步。",
		"href":"information-list.html"
	}
];

$(document).ready(function(){

	$(".issay").children("h1").click(function(){
		var a = $(this).parent(".issay").index();
		change(a);
	});
	function change(a){
		$(".shortAlert").children("h1").text(obj[a].title);
		$(".shortAlert").children("div").children("h1").eq(0).text(obj[a].time);
		$(".shortAlert").children("div").children("h1").eq(1).text(obj[a].read);
		$(".shortAlert").children("p").eq(0).text(obj[a].content);
		$(".shortAlert").children("p").eq(1).children("a").attr("href",obj[a].href);
}
})




$(document).ready(function () {
    var obj = {};        //短趣的 AJAX 返回对象
    $.ajax({

        type: 'get',
        url: '/Ajax/NewsBind.ashx',
        async: 'true',
        data: {
            tiem: Math.random()
        },
        success: function (data) {
            obj = eval("(" + data + ")");//字符串转换为json对象，有这句话就不能在设置 datatype=json   
        },
        error: function () {
            //window.location.reload();
        }
    });


    $(".issay").children("h1").click(function () {
        var a = $(this).parent(".issay").index();
        change(a);
    });
    function change(a) {
        $(".shortAlert").children("h1").text(obj[a].title);
        $(".shortAlert").children("div").children("h1").text(obj[a].time);
        $(".shortAlert").children("p").eq(0).html(obj[a].content);
        $(".shortAlert").children("p").eq(1).children("a").attr("href", obj[a].href);
    }
})

$(function(){
    //$(".newsList").load("" , function(){
   // $("input").css("background","blue");
    if(window.screen.width<1601)
        $(".wechat-weibo").css({
            "right":"26px"
        });
    else
         $(".wechat-weibo").css({
            "right":"20px"
        });
    $(".click-to-close").css({
        "width":$(document).width(),
        "height":$(document).height(),
        "zIndex":-5
    });
    $(".newsList").delegate(".share","click",function(){
        $(this).parent(".newsReading").find(".wechat-weibo")
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
        .animate({opacity:0},200);
        $(".wechat-2d").css({
            "opacity":0,
            "top":"20px"
        });
        $(".click-to-close").css({
            "zIndex":-5
        });
    })
    //下面这个为微博的点击事件
    $(".newsList").delegate(".weibo","click",function(){
        $(this).parent(".wechat-weibo").find(".wechat-2d").stop().animate({opacity:0},200,function(){
            $(this).css({"top":"20px"});
        });
        /* $(this).parent(".wechat-weibo").find(".weibo-2d").stop().animate({opacity:1,top:0},200);*/
    })
    //下面为二维码事件
    $(".newsList").delegate(".wechat","click",function(){

        /*$(this).parent(".wechat-weibo").find(".weibo-2d").stop().animate({opacity:0},500,function(){
            $(this).css({"top":"20px"});
        })*/
        $(this).parent(".wechat-weibo").find(".wechat-2d").stop().animate({opacity:1,top:0},200);
    })
})


 
