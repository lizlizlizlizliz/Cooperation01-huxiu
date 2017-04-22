###壹·关于技术

####01. 阻止事件冒泡

1. 通过使用stopPropagation()方法只阻止一个事件冒泡。
```JavaScript
var input = document.getElementsByTagName("input")[0];
input.onclick=function(event){
  event.stopPropagation();
};
```
2. 通过使用preventDefault()方法只取消默认的行为。
```JavaScript
$("input").bind(
　　"submit", 
　　function(event){
　　　　event.preventDefault();
　　}
);
```
3. 通过返回false来取消默认的行为并阻止事件冒泡。
```JavaScript
$("input").bind(
　　"submit", 
　　function() { 
　　　　return false;
　　 }
);
```
4. 注意
    * 一个事件起泡对应触发的是上层的同一事件
        特殊：如果two设置成双击事件，那么在你单击two的时候就会起泡触发one单击的事件（双击包含单击）。

    * 如果在click事件中，在你要处理的事件之前加上e.preventDefault();那么就取消了行为（通俗理解：相当于做了个return操作），不执行之后的语句了。

    * e.stopPropagation()只要在click事件中，就不会触发上层click事件。
    ```JavaScript
    //如果提供了事件对象，则这是一个非IE浏览器
    if ( e && e.stopPropagation )
    　　// 因此它支持W3C的stopPropagation()方法
    　　e.stopPropagation();
    else
    　　//否则，我们需要使用IE的方式来取消事件冒泡
    　　window.event.cancelBubble = true;
    return false;
    ```

####02.固定置顶

```JavaScript
$(function(){        
        //获取要定位元素距离浏览器顶部的距离
        var navH = $(".top").offset().top;
        //滚动条事件
        $(window).scroll(function(){
                //获取滚动条的滑动距离
                var scroH = $(this).scrollTop();
                //滚动条的滑动距离大于等于定位元素距离浏览器顶部的距离，就固定，反之就不固定
                if(scroH >  navH ){
                        $(".top").css({"position":"fixed","top":0,"left":0,});
                }
                else if(scroH <= navH ){
                        $(".top").css({"position":"static","margin":"0 auto",});
                }
        })
})
```

####03.js控制响应式

    通过获取window.screen.width控制在不同分辨率下的css及js效果。

####04.轮播事件（有待改进）

    思路：初始化各li位置，通过调换li顺序使图片轮流在中间显示。

```JavaScript
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
```

####05.动态加载数据（瀑布流Ajax）

    * 通过在后台与服务器进行少量数据交换，AJAX 可以使网页实现异步更新。这意味着可以在不重新加载整个网页的情况下，对网页的某部分进行更新。
    type：请求的类型；GET 或 POST
    url：文件在服务器上的位置
    async：true（异步）或 false（同步）

    * 动态生成标签 appendTo() & attr() & addClass()
```JavaScript
var news = $("<div>").addClass("news").addClass("shadow").appendTo($(".newsList"));
var newsImage = $("<div>").addClass("newsImage").appendTo(news);
var png = $("<img>").attr("src", jsonObj[j].PassageImage).appendTo(newsImage);
var newsWriter = $("<div>").addClass("newsWriter").appendTo(news);
var newsLeft = $("<div>").addClass("newsLeft").appendTo(newsWriter);
var icon = $("<img>").attr("src", jsonObj[j].AuthorImage).appendTo(newsLeft);
var writer = $("<p>").text(jsonObj[j].AuthorName).appendTo(newsLeft);
var newsTitle = $("<h1>").attr("id", jsonObj[j].PassageId).text(jsonObj[j].PassageTitle).appendTo(newsWriter).click(function () {
    window.open("PassageContent.aspx?id=" + $(this).attr("id"));
    });
```

####06.字符串拼接地址

```JavaScript
$(".newsList").on("click", ".weibo", function () {
    var a = window.location.href;//当前地址
    var b = window.location.href.lastIndexOf('/') + 1;//指定的字符串值最后出现的位置
    var d = $(this).parent(".wechat-weibo").parent(".newsReading").parent(".newsWriter").children("h1").text();
    var c = window.location.href.substring(0, b) + $(this).parent(".wechat-weibo").parent(".newsReading").parent(".newsWriter").parent(".news").children(".newsImage").children("img").attr("src");//将相对路径改为绝对路径
    window.open("http://service.weibo.com/share/share.php?appkey=1934882415&url=" + a + "&title=" + d + "@艾特网&content=utf-8&pic=" + c + "#_loginLayer_1490090511099");//字符串拼接
});
```

####07.搜索关键词变色

```JavaScript
var replacetext = "<span style='color:" + "#fd974d" + ";'>"+ searchwords +"</span>"
var objects = jsonObj[j].PassageTitle.replace(searchwords, replacetext);
```

####08.动态生成的html的js事件失效问题

    利用on()绑定在静态父级元素上
```JavaScript
$(".newsList").on("mouseover",".share",function(){
    $(this).css({"background":"url(images/share-orange.png) no-repeat"});
});
```

###贰·关于感想

    哎呀想说的太多了不知道从哪说……
    就是感觉第一次做出一个完整的网站很激动很开心啊。和小组最一开始一起讨论项目设计，和钱怡辰一起讨论网页实现效果和分工，和程序同学们一起讨论要实现的功能，以及通宵写网页，各种改效果改bug，一起战斗到天明……虽然有一点点辛苦，但是给我的感觉是幸福的。这种有人一起战斗的感觉真好，这种共同奋斗的感觉真好。
    这四个周里我其实有过很多次失望烦闷，有过很多次想放弃，觉得为什么要搞得这么累，为什么所有的事情都挤到了一起，觉得自己拖了大家的后腿。但不管怎么样，还是要写下去。那段时间，很多次练完啦啦操急匆匆跑上六楼讨论功能实现，很多次写着写着代码中途又被叫去处理啦啦操的事。日子充实得有点过了头，每天脑子里只想着代码和动作（学习是什么我不知道）。所幸，最后结果不算太差，时间没有白费，啦啦操比赛比完的时候，看着完整的被挂上服务器的网页的时候，我都特别想哭。这是大家的心血，是大家一起努力的结果。团体的力量凝聚在一起，就是这么强大。
    要谢谢好多人。谢谢宿天宇梁颖芳叶伊凡一起熬夜战斗，没有嫌弃一直丢三落四的我；谢谢钱怡辰分担了很大比重的工作量；谢谢李宜璟学姐廖舒祺学姐一直陪了我们四个周，帮我们指出不足；谢谢舍友愿意陪我一起通宵；谢谢陶贇学长帮zz的我改bug写效果；谢谢同伴们对我的信任，谢谢大家的谅解和安慰，给我力量让我坚持下去。
    虽然过程中会有难过和抱怨，但可能，我最喜欢做的两件事就是跳舞和代码了。在大学里我能有把这两件事做下去的机会并且遇到一群投缘的小伙伴，这是一件多么幸运的事啊。我只希望，我能继续走下去，做好喜欢的事，遇见共同成长的朋友，珍惜这份幸运。