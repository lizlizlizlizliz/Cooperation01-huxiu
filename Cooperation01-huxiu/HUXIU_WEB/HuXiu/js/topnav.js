
//阻止搜索弹窗中的事件冒泡
window.onload = function(){
var span = document.getElementsByTagName("span")[0];
span.onclick=function(){
    var searchwords = $(".alertInner").children("input").val();
    //if (searchwords == "")
    //    return false;
    window.open('SearchList.aspx?search='+searchwords);
};

var input = document.getElementsByTagName("input")[0];
input.onclick=function(event){
  // 停止DOM事件层次传播
  event.stopPropagation();
};
}
$(function () {
    $("#phone").click(function () {
        e.preventDefault();
    })
    
})

//固定置顶
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


//资讯二级菜单的弹出
$(document).ready(function(){//加载整个DOM元素
	$("#information").click(function(){
        if($(".secondNav").hasClass("displaynone")){
            $(".secondNav").removeClass("displaynone");
            $(".secondNav").animate({'opacity':'1','top':'60px'},450);
        }
        else{
            $(".secondNav").animate({'opacity':'0','top':'50px'},450,function(){
                $(".secondNav").addClass("displaynone");
            });
        }
	})
})


//搜索弹框
$(document).ready(function(){
	$("#search").click(function(){
		$(".alert").css({"display":"block","position":"fixed"});
	});
	$(".alert").click(function(){
		$(".alert").css({"display":"none"});
	});

})




$(document).ready(function(){
    $("#phone").mouseover(function(){
        $("#phone").css({"background":"url(images/phone-orange.png) no-repeat"});
    });
    $("#phone").mouseout(function(){
        $("#phone").css({"background":"url(images/phone.png) no-repeat"});
    });
    $("#search").mouseover(function(){
        $("#search").css({"background":"url(images/search-orange.png) no-repeat"});
    });
    $("#search").mouseout(function(){
        $("#search").css({"background":"url(images/search.png) no-repeat"});
    });
})
$(function(){
    $(".alert").css({
        "height": $(document).height()
    });
})