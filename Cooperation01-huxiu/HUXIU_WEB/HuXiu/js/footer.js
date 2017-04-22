$(function(){
	$(".footer-login ").hover(login,rights);
	function login(){
		$(".footer-login div").stop().animate({marginTop:"-40px"},200);
	}
	function rights(){
		$(".footer-login div").stop().animate({marginTop:"0px"},200);
		//$(".footer-login div").css({"marginTop":0});
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
})
$(function(){
    $(".return-top").css({
            "position":"absolute",
            "right":($("body").width()-$(".container").width())/2-$(".return-top").width()-2,
            "top":"-55px"
        });
    $(window).resize(function(){
        $(".return-top").css({
            "right":($("body").width()-$(".container").width())/2-$(".return-top").width()-2
        });
    })
     
})
//$(function () {
//    if ($("html").height() < $(window).height()) {
//        $(".footer").css({
//            "position": "absolute",
//            "top": $(document).height() - $(".footer").innerHeight()
//        });

//    }
//})