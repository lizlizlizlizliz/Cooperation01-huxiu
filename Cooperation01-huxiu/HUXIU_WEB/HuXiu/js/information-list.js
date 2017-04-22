//响应式
//资讯内容hover效果
$(document).ready(function(){
    if (window.screen.width > 1600) {
        $(".lists").on("mouseover",".informations",function(){
            $(this).children(".detail").stop(false,false);
            $(this).children(".detail").animate({top:'0'},450);
        })
        $(".lists").on("mouseout",".informations",function(){
            $(this).children(".detail").stop(false,false);
            $(this).children(".detail").animate({top:'320px'},450);
        })
        $(".lists").on(".informations",function(){
            $(this).css({backgroundSize:'682px 512px'});
        })
    }
    else {
        $(".lists").on("mouseover",".informations",function(){
            $(this).children(".detail").stop(false,false);
            $(this).children(".detail").animate({top:'0'},450);
        })
        $(".lists").on("mouseout",".informations",function(){
            $(this).children(".detail").stop(false,false);
            $(this).children(".detail").animate({top:'222px'},450);
        })
    }
})



//导航展开
$(document).ready(function(){
	$(".listTitle").click(function(){
		$(".listTitle").css({'display':'none'});
		$(".listNav").css({'display':'block'});
	})
	$(".listNav").children("button").click(function(){
		$(".listNav").css({'display':'none'});
		$(".listTitle").css({'display':'block'});
		return false;
	})
})


//瀑布流
$(document).ready(function(){
     var i=0,j,jsonObj;
   var judge=false;
    appendAct();
   $(".loading").click(function(){
       appendAct();
   })
   function appendAct(){
        console.log(1);
        i++;
        $.ajax({
            type:"GET",
            url:"/Ajax/InfoHandler.ashx",
            data:{pageNumber:i,pageSize:4},
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
                    if ($(".loading").text("已经到底了"))
                    {
                        $(".loading").css({
                        "background":"url(images/loading.png)",
                        "cursor":"pointer"
                        })
                        .text("")
                        .addClass("loadhover");
                    }
                console.log(dat);
                jsonObj=JSON.parse(dat);
                console.log(jsonObj);
                //将json字符串解析为json对象
                for(j=0;j<jsonObj.length;j++){
                    var infor = $("<div>").attr("id",jsonObj[j].PassageId).addClass("informations").css({"background":"url(" + jsonObj[j].PassageImage + ")","backgroundSize":"auto 100%","backgroundPosition":"center"}).appendTo($(".lists"));
                    var detail = $("<div>").addClass("detail").addClass("clearfix").appendTo(infor);
                    var detailLeft = $("<div>").addClass("detailLeft").appendTo(detail);
                    var icon = $("<img>").attr("src",jsonObj[j].AuthorImage).appendTo(detailLeft);
                    var writer = $("<p>").text(jsonObj[j].AuthorName).appendTo(detailLeft);
                    var detailRight = $("<div>").addClass("detailRight").appendTo(detail);
                    var title = $("<h1>").text(jsonObj[j].PassageTitle).appendTo(detailRight);
                    var read = $("<p>").text(jsonObj[j].PageViews).appendTo(detailRight);
                    var time = $("<p>").text(jsonObj[j].PublishDate).appendTo(detailRight);
                    var hide = $("<div>").addClass("hide").appendTo(detail);
                    var substring = jsonObj[j].PassageBody.substring(0,180) + "...";
                    var content = $("<p>").text(substring).appendTo(hide);

                    if(j%2==0){
                        infor.addClass("left")
                    }
                    if(j%2==1){
                        infor.addClass("right");
                    }
                }
            }
            },
            //根据后台发来的数据动态添加元素
        })
   }
   //资讯点击事件跳转链接
   $(".lists").on("click",".detail",function(){
        var j = $(this).parent(".informations").attr("id");
        window.open("PassageContent.aspx" + "?" + "id=" + j);
    })
})

//$(function () {
//    $(window).scroll(function () {
//        if ($(document).scrollTop() == 0) {
//            $(".return-top").animate({ opacity: 0 }, 300);
//            return false;
//        }
//        $(".return-top").css({
//            "opacity": 1,
//            "position": "fixed",
//            "right": ($("body").width() - $(".container").width()) / 2 - $(".return-top").width() - 2,
//            "top": $(window).height() - $(".return-top").height() - 45

//        });
//        //var d = $(window).height() + $(window).scrollTop() - $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height();
//        //if($("body").height()-$(".return-top").offset().top<193)
//        //if ($("body").height() - $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height() < 0) {
//        console.log($(window).height() + $(window).scrollTop() - $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height());
//        //if($(window).height()+$(document).scrollTop()- $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height()<0){
//        if($(document).scrollTop()+$(".footer").innerHeight()>=$(document).height()-$(window).height()){
//            console.log($(window).height() + $(window).scrollTop() - $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height());
//            $(".return-top").css({
//                "position": "absolute",
//                "top": $("body").height() - $(".footer").innerHeight() - $(".return-top").height()+452
//            });
//            console.log($(window).height() + $(window).scrollTop() - $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height());
//        }
//       // console.log(d);
//        //if ($(window).height() + $(document).scrollTop() - $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height() >=0) {
//        else{
//            console.log($(window).height() + $(window).scrollTop() - $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height());
//            $(".return-top").css({
//                "position": "fixed",
//                "top": $(window).height() - $(".return-top").height() - 45
//            });
//            console.log($(window).height() + $(window).scrollTop() - $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height());
//        }
//        console.log($(window).height() + $(window).scrollTop() - $(".footer").innerHeight() - $(".return-top").offset().top - $(".return-top").height());
//    })
//})