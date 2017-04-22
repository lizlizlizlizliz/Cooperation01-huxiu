/*$(document).ready(function(){
	$(".lists").on("click",".likebutton",function(){
		$(".liked").css({"display":"block"}).animate({top:'-20px',opacity:'0'},850,function(){
			$(".liked").css({"display":"none"});
			$(".like").children("span").text(jsonObj[j].count+1);
		})
	})
})*/
// $(document).ready(function(){
//     var searchwords = $(".searchInput").children("input").text();
//     $(".searchInput").children("span").click(function(){
//         searchwords();
//     })
//     function searchwords(){
//     $.ajax({
//             type: "post",
//             url: "",
//             data: searchwords,
//             datatype: "text",
//             success: function (data) {
//                 var i=0;
//                 $(".searchInput").children("span").click(function(){
//                     var objects = $(".funs-shadow").children(".title-and-time").children("h1").text();
//                     document.write(objects.replace(searchwords, "<em>" + searchwords + "</em>"));
//                 })
//             }
 
//         });
// }
// });
    $(document).ready(function(){
    
        var i=1,j,jsonObj;//i是当前请求页数,j用于循环,jsonObj是解析后的json对象
        var judge = false;
        var a = window.location.href;
        var a1 = a;
        console.log(a);
        for (m = 0; m < a.length - 7;) {
            if (a[m] + a[m + 1] + a[m + 2] + a[m + 3] + a[m + 4] + a[m + 5] + a[m + 6] == "search=") {
                a = a.substring(m + 7);
                console.log(a);
            }
            else { m++; }
        }
        console.log(a);
        var b = decodeURI(a);
    
        var searchwords = $(".searchInput").children("input").val(b);
        //else
        // var searchwords=b;
        console.log(searchwords);
        //$(".footer").css({
        //    "position": "absolute",
        //    "top": $("body").height() - $(".footer").innerHeight()
        //});
        changeAct();
        if (a1 == "http://localhost:55010/SearchList.aspx?search=")
            $(".searchInput").children("input").val("");

        $(".searchInput").children("span").click(function () {
            //$(".footer").css({
            //    "position": "absolute",
            //    "top": $("body").height() - $(".footer").innerHeight()
            //});
            changeAct();
        })
        $(".loading").click(function () {
            //$(".footer").css({
            //    "position": "absolute",
            //    "top": $("body").height() - $(".footer").innerHeight()
            //});
            appendAct();
        })
        function appendAct(){
            var searchwords = $(".searchInput").children("input").val();
            i++;
            $.ajax({
                type:"GET",
                url:"/Ajax/SearchHandler.ashx",
                data:{pageNumber:i,pageSize:4,searchwords},
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
                        jsonObj=JSON.parse(dat);
                        console.log(jsonObj);
                        //将json字符串解析为json对象
                        for(j=0;j<jsonObj.length;j++){

                            var funs=$("<div>").addClass("funs-shadow").appendTo($(".lists"));
                            var  titleTime=$("<div>").addClass("title-and-time").appendTo(funs);
                            var replacetext = "<span style='color:" + "#fd974d" + ";'>"+ searchwords +"</span>"
                            var objects = jsonObj[j].PassageTitle.replace(searchwords, replacetext);
                            var title=$("<h1>").html(objects).appendTo(titleTime);
                            var time=$("<p>").text(jsonObj[j].PublishDate).appendTo(titleTime);
                            var funsContent = $("<div>").addClass("funs-content").appendTo(funs);
                            var substring = jsonObj[j].PassageBody.substring(0, 250) + "...";

                            var contentP=$("<p>").text(substring).appendTo(funsContent);
                            var contentA = $("<a>").text("详情>>").appendTo(contentP).attr("href", "PassageContent.aspx" + "?" + "id=" + jsonObj[j].PassageId).attr("target", "_blank");
                            

                            // var dianzan=$("<div>").addClass("dianzan-bottom").addClass("clearfix").appendTo(funs);
                            //     var like=$("<div>").addClass("like").addClass("clearfix").appendTo(dianzan);
                            //         var likenum=$("<p>") .text(jsonObj[j].likenumber).appendTo(like);
                            //         var likeimg=$("<img>").addClass("likebutton").attr("src","images/like.png").appendTo(like)
                            /*.bind("click",function(){
                                console.log(3);
                                var likednum=parseInt($(this).parent(".like").find("p").text());
                                $(this).parent(".like").find("p").text(likednum+1)
                                .css({"color":"rgb(241,124,24)"});
                                $(this).attr("src","images/like-orange.png");
                                $(this).parent(".like").parent(".dianzan-bottom").find(".liked").css({"display":"block","opacity":1}).animate({bottom:'+=20px',opacity:'0'},850,function(){
                                $(this).css({"bottom":"-=20px"});
                                });
                            })*/;
                            // var liked=$("<div>").addClass("liked").addClass("clearfix").appendTo(dianzan);
                            //     var likednum=$("<p>") .text("+1").appendTo(liked);
                            //     var likedimg=$("<img>").attr("src","images/like-orange.png").appendTo(liked);    
                        }
                    }
                }
            })
        }
        function changeAct() {
            i = 1;
            var searchwords = $(".searchInput").children("input").val();
    
            if (searchwords == "")
            {
                $(".lists").empty();
                $(".loading")
                           .text("已经到底了")
                           .css({
                               "background": "none",
                               "cursor": "auto",
                               "color": "rgb(85,85,85)"
                           })
                           .removeClass("loadhover");
                return false;
            }
            $.ajax({
                type:"GET",
                url:"/Ajax/SearchHandler.ashx",
                data:{pageNumber:i,pageSize:4,searchwords},
                    //发送给后台，请求第几页信息，每页信息多大
                    //dataType:"json",
                        async:true,
                        success:function(dat){
                            if (dat == "[]" && i == 1) {
                                $(".loading")
                               .text("已经到底了")
                               .css({
                                   "background": "none",
                                   "cursor": "auto",
                                   "color": "rgb(85,85,85)"
                               })
                               .removeClass("loadhover");
                                alert("很抱歉，没有找到相关内容！");

                            }
                                //else if(dat=="[]"&& i!=1){
                                //    $(".loading")
                                //    .text("已经到底了")
                                //    .css({
                                //        "background":"none",
                                //        "cursor":"auto",
                                //        "color":"rgb(85,85,85)"
                                //    })
                                //    .removeClass("loadhover");
                                //}
                            else{
                                if($(".loading").text("已经到底了"))
                                {
                                    $(".loading").css({
                                        "background":"url(images/loading.png)",
                                        "cursor":"pointer"
                                    })
                                    .text("")
                                    .addClass("loadhover");
                                }
                                jsonObj=JSON.parse(dat);
                                console.log(jsonObj);
                                //将json字符串解析为json对象
                                //删除之前产生的div
                    
                                $(".lists").empty();
                                for(j=0;j<jsonObj.length;j++){

                                    var funs=$("<div>").addClass("funs-shadow").appendTo($(".lists"));
                                    var  titleTime=$("<div>").addClass("title-and-time").appendTo(funs);
                                    var replacetext = "<span style='color:" + "#fd974d" + ";'>"+ searchwords +"</span>"
                                    var objects = jsonObj[j].PassageTitle.replace(searchwords, replacetext);
                                    var title=$("<h1>").html(objects).appendTo(titleTime);
                                    var time=$("<p>").text(jsonObj[j].PublishDate).appendTo(titleTime);
                                    var funsContent = $("<div>").addClass("funs-content").appendTo(funs);
                                    var substring = jsonObj[j].PassageBody.substring(0,100) + "...";
                                    var contentP = $("<p>").text(substring).appendTo(funsContent);
                                    var contentA = $("<a>").text("详情>>").appendTo(contentP).attr("href", "PassageContent.aspx" + "?" + "id=" + jsonObj[j].PassageId).attr("target", "_blank");

 
                                }

                
              
                            }
                        }
            })
        };
    });

    // $(document).ready(function(){
    // /*    $(".likebutton").click(function(){
    //         console.log(3);
    //         var likednum=parseInt($(this).parent(".like").find("p").text());
    //         $(this).parent(".like").find("p").text(likednum+1)
    //         .css({"color":"rgb(241,124,24)"});
    //         $(this).attr("src","images/like-orange.png");
    //         $(this).parent(".like").parent(".dianzan-bottom").find(".liked").css({"display":"block","opacity":1}).animate({bottom:'+=20px',opacity:'0'},850,function(){
    //             $(this).css({"bottom":"-=20px"});
    //         });

    //     })*/
    //     $(".lists").delegate(".likebutton","click",function(){
    //          console.log(4);
    //         if($(this).hasClass("afterlike"))
    //         {
    //             return false;
    //         }
    //         $(this).addClass("afterlike");
    //         var likednum=parseInt($(this).parent(".like").find("p").text());
    //         $(this).parent(".like").find("p").text(likednum+1)
    //         .css({"color":"rgb(241,124,24)"});
    //         $(this).attr("src","images/like-orange.png");
    //         $(this).parent(".like").parent(".dianzan-bottom").find(".liked").css({"display":"block","opacity":1}).animate({bottom:'+=20px',opacity:'0'},850,function(){
    //             $(this).css({"bottom":"-=20px"});
    //         });
    //     })
    // })


    //瀑布流
    /*$(document).ready(function(){
        appendAct();
       var i=1,j,jsonObj;
       var judge=false;
       $(".loading").click(function(){
            appendAct();
       })
       function appendAct(){
            console.log(1);
            i++;
            $.ajax({
                type:"GET",
                url:"ajax/news.txt",
                data:{pageNumber:i,pageSize:4},
                //发送给后台，请求第几页信息，每页信息多大
                //dataType:"json",
                async:true,
                success:function(dat){
                    console.log(dat);
                    jsonObj=JSON.parse(dat);
                    console.log(jsonObj);
                    //将json字符串解析为json对象
                    for(j=0;j<jsonObj.length;j++){
                        var funs = $("<div>").addClass("funs").addClass("shadow").appendTo($(".lists"));
                        var funsLeft = $("<div>").addClass("funs-left").appendTo(funs);
                        var icon = $("<img>").attr("src",jsonObj[j].icon).appendTo(funsLeft);
                        var writer = $("<h1>").text(jsonObj[j].id).appendTo(funsLeft);
                        var time = $("<p>").text(jsonObj[j].time).appendTo(funsLeft);
                        var funsRight = $("<div>").addClass("funs-right").appendTo(funs);
                        var title = $("<h1>").text(jsonObj[j].title).appendTo(funsRight);
                        var like = $("<div>").addClass("like").appendTo(funsRight);
                        var count = $("<span>").text(jsonObj[j].count).appendTo(like);
                        var likebutton = $("<button>").addClass("likebutton").appendTo(like);
                        var liked = $("<div>").addClass("liked").appendTo(funsRight);
                        var counted = $("<span>").text("+1").appendTo(liked);
                        var already = $("<button>").addClass("already").appendTo(liked);
                        var content = $("<p>").text(jsonObj[j].content).appendTo(funsRight);
                    }
                    console.log("done");
                },
                //根据后台发来的数据动态添加元素
                error:function(xhr){
                $(".loading").css({
                    "background":"none",
                    "cursor":"auto"
                })
                .text("已经到底了");
                }
            })
       }
    })*/