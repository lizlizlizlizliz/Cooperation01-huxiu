$(function(){
    var i=0,j,jsonobj,jsonObj,id3;//i是当前请求页数,j用于循环,jsonObj是解析后的json对象
    var judge=false;//如果滚动添加瀑布流的判断。
    var $el, $parentWrap, $otherWrap,pageNow;
    $.ajax({
            type:"GET",
            /*url:"try4.txt",*/
            url:"/Ajax/getActHead.ashx",
            //data:{pageNumber:i,pageSize:4},
                //发送给后台，请求第几页信息，每页信息多大
                //dataType:"json",
            async:true,
            success:function(data){
                jsonobj=JSON.parse(data);
                for(j=0;j<2;j++)
                {
                    $(".accordion a:eq("+j+")").find($(".accordion-act"))
                    .attr("src",jsonobj[j].URL);
                }
                var background=jsonobj[2].URL;
                $(".accordion").css({
                    "backgroundImage":"url("+background+")",
                    "backgroundRepeat":"no-repeat",
                    "backgroundPosition":"right"
                });
                for(j=0;j<3;j++)
                {
                    $(".accordion a:eq("+j+")").attr("href","ActivityContent.aspx?id="+jsonobj[j].ID);
                }
                id3=jsonobj[2].ID;
            }
    })
    appendAct();


    $(".accordion a").click(function(e){
        if(!$(this).hasClass("curCol"))
        {
            e.preventDefault();
            $parentWrap=$(this);
            pageNow=$(".accordion a").index(this);
            $otherWraps = $(".accordion a").not($parentWrap);

        }
        if(window.screen.width<1601){
            $parentWrap.animate({
                width: 710
            }).addClass("curCol");
            
        // make other columns the small size
            $otherWraps.removeClass("curCol").animate({
            //width: 142
                width:145
            });
        }
        else{
            $parentWrap.animate({
                width: 995
            }).addClass("curCol");
            
        // make other columns the small size
            $otherWraps.removeClass("curCol").animate({
            //width: 142
                width:205
            });
        }
        $(".accordion-button")
        .attr("src","images/btn.png");
        if(pageNow!=2){
            $parentWrap.find(".accordion-button")
            .attr("src","images/btn_hover.png");
        }
        else{
            $(".accordion-special-button")
            .attr("src","images/btn_hover.png");
        }
        /*$otherWraps.find(".accordion-button")
        .attr("src","images/btn.png");*/
       
        
    });
    //$(".accordion a:eq(0)").trigger("click").addClass("curCol");
    if(window.screen.width<1601){
        $(".accordion a:eq(0)").css({"width":710}).addClass("curCol")
        .find(".accordion-button").attr("src","images/btn_hover.png");
        ;
    }
    else{
        $(".accordion a:eq(0)").css({"width":995}).addClass("curCol")
        .find(".accordion-button").attr("src","images/btn_hover.png");
        
    }
    $("#starter").trigger("click");
    $(".accordion-special-button").click(function(){
        if($(".act-back").hasClass("curCol"))
            window.location="ActivityContent.aspx?id="+id3;
        else
             $(".act-back").click();
        })

//手风琴即手风琴响应式效果
   $(".loaddiv").click(function(){
        appendAct();
   })
   function appendAct(){
        i++;
        $.ajax({
            type:"GET",
            url:"/Ajax/ActivityListHandler.ashx",
            data:{pageNumber:i,pageSize:4},
                //发送给后台，请求第几页信息，每页信息多大
                //dataType:"json",
            async:true,
            success:function(dat){
                if(dat=="[]"){
                    $(".loaddiv")
                    .text("已经到底了")
                    .css({
                        "background":"none",
                        "cursor":"auto",
                        "color":"rgb(85,85,85)"
                    })
                    .removeClass("loadhover");
                }
                else{
                    if(!$(".loaddiv").hasClass("loadhover"))
                    {
                        $(".loaddiv").css({
                        "background":"images/loaddiv.png",
                        "cursor":"pointer"
                        })
                        .text("")
                        .addClass("loadhover");
                    }
                    jsonObj=JSON.parse(dat);
                    //将json字符串解析为json对象
                    for(j=0;j<jsonObj.length;j++){
                    var actIn=$("<div>").addClass("act-in").addClass("clearfix").appendTo($(".huxiu-act"));
                    if(j%2!=0) actIn.addClass("act-in-2");
                    if(j%2==0){
                        var actProcess=$("<div>").addClass("act-process").appendTo(actIn);
                    }
                    else{
                         var actProcess=$("<div>").addClass("act-process-2").appendTo(actIn);
                    }
                        var processImg=$("<img>").appendTo(actProcess);
                        var processP=$("<p>").text(jsonObj[j].ActivityWhen).appendTo(actProcess);
                        if(jsonObj[j].ActivityWhen=="进行中")
                            processImg.attr("src","images/circle_orange.png");
                        else
                            processImg.attr("src","images/circle_black.png");
                    var huodongImgdiv=$("<div>").addClass("activity-img").appendTo(actIn);
                    if(j%2!=0) huodongImgdiv.addClass("activity-img-2");
                    var huodongImg=$("<img>").attr("src",jsonObj[j].ActivityImage).appendTo(huodongImgdiv);
                    /*var huodongImg=$("<img>").addClass("activity-img").attr("src",jsonObj[j].ActivityImage).appendTo(actIn);*/
                    /*if(j%2!=0) huodongImg.addClass("activity-img-2");*/

                    var actText=$("<div>").addClass("activity-text").appendTo(actIn);
                    if(j%2!=0) actText.addClass("activity-text-2");
                        var actTexttitle=$("<h2>").text(jsonObj[j].ActivityTitle).appendTo(actText);
                        var actTexttitle=$("<p>").text(jsonObj[j].ActivityWhat).appendTo(actText);
                        var actTexta = $("<a>").attr("href", "ActivityContent.aspx?id=" + jsonObj[j].ActivityId).text("更多详情").appendTo(actText);
                    }
                }
            }
                //根据后台发来的数据动态添加元素
            /*,error:function(xhr){
            $(".loaddiv")
            .text("已经到底了")
            .css({
                "background":"none",
                "cursor":"auto",
                "color":"rgb(85,85,85)"
            })
            .removeClass("loadhover");
            }*/
        })
   }
   var timer = null;
   $(".return-top").click(function(){
                cancelAnimationFrame(timer);
                timer = requestAnimationFrame(function fn(){
                        var oTop = document.body.scrollTop || document.documentElement.scrollTop;
                        if(oTop > 0){
                                document.body.scrollTop = document.documentElement.scrollTop = oTop - 100;
                                timer = requestAnimationFrame(fn);
                        }
                        else{
                                cancelAnimationFrame(timer);
                        } 
                });
   })
   //以上是在点击页面下三个点时加载的瀑布流
    /*$(window).on("scroll",function(){
        judgefall();
        if(judge){
            i++;
            console.log(1);
            $.ajax({
                type:"GET",
                url:"try.txt",
                data:{pageNumber:i},
                //dataType:"json",
                async:true,
                success:function(dat){
                    console.log(dat);
                    jsonObj=JSON.parse(dat);
                    for(j=0;j<jsonObj.length;j++){
                        var actIn=$("<div>").addClass("act-in").addClass("clearfix").appendTo($(".huxiu-act"));
                        if(j%2!=0) actIn.addClass("act-in-2");
                        if(j%2==0){
                            var actProcess=$("<div>").addClass("act-process").appendTo(actIn);
                        }
                        else{
                            var actProcess=$("<div>").addClass("act-process-2").appendTo(actIn);
                        }
                            var processImg=$("<img>").attr("src",jsonObj[j].proImg).appendTo(actProcess);
                            var processP=$("<p>").text(jsonObj[j].proText).appendTo(actProcess);
                        var huodongImg=$("<img>").addClass("activity-img").attr("src",jsonObj[j].actImg).appendTo(actIn);
                        if(j%2!=0) huodongImg.addClass("activity-img-2");
                        var actText=$("<div>").addClass("activity-text").appendTo(actIn);
                        if(j%2!=0) actText.addClass("activity-text-2");
                            var actTexttitle=$("<h2>").text(jsonObj[j].actTextt).appendTo(actText);
                            var actTexttitle=$("<p>").text(jsonObj[j].actTextp).appendTo(actText);
                    }
                },
                error:function(xhr){
                alert("发生错误"+xhr);
                }
            })
        }
    })*/
    /*function judgefall(){
        judge=false;
        var first=$(".act-in").last().offset().top+$(".act-in").height();
        //最后一个活动到页面头部距离加活动高度
        var second=$(window).height()+$(window).scrollTop();
        //可视窗口宽度加上滚动条滚动的距离
        console.log(first);
        console.log(second);
        if(first-second<50) judge=true;
    }*/

    //注释掉的内容判断滚动条距离底部的距离的瀑布流

});