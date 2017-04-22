/// <reference path="login.js" />
$(function(){
	$(".username").focus(function(){
		$(".username-tip p").css({
			"display":"none"
		});
		$(this).css({
			"background":"url(images/username.png)",
			"color":"white"
		});
		if(this.value=="username")
			$(this).val("");
	})
	$(".username").blur(function(){
		$(this).css({
			"background":"url(images/username1.png)",
			"color":"#999"
		});


		if($(this).val()=="")
			$(this).val("username");
    /*
		else {
			var userin=$.trim($(this).val());
			var pat = new RegExp("[^a-zA-Z0-9\_\u4e00-\u9fa5]", "i");
			if(pat.test(userin)){
				$(".username-tip p")
				.text("用户名格式不正确")
				.css({
					"display":"block"
				});
			}
			else{
				$.ajax({  
                type: "POST", 
                url: "regist_username.ashx",
                data:{
                	"userName":userin
                },
                //dataType: 'json', 
                //（返回数据形式）
                success: function(dat) {
                    var datObj=JSON.parse(dat);
                    if(!datObj.code==0){
                    	$(".username-tip p")
						.text("用户名不存在")
						.css({
							"display":"block"
						});
                    }
                }
                //dat为由服务器返回，并根据dataType进行处理后的函数
            });  
			}
		}
        */
	})


	$(".password").focus(function(){
		$(".password").attr("type","password");
		$(".password-tip p")
				.css({
					"display":"none"
				});
		$(this).css({
			"background":"url(images/username.png)",
			"color":"white"
		});
		if(this.value=="password")
			$(this).val("");
	})
	$(".password").blur(function(){
		$(this).css({
			"background":"url(images/username1.png)",
			"color":"#999"
		});
		if($(this).val()=="")
			$(this).val("password").attr("type","text");
            /*
		else {
			var passin=$.trim($(this).val());
			var pat2 =new RegExp("[^a-zA-Z0-9\_\u4e00-\u9fa5]", "i");
			//只含有数字字母，6-18位
			if(pat2.test(passin)){
				$(".password-tip p")
				.text("密码格式不正确")
				.css({
					"display":"block"
				});
			}
		}

        */

	})
	//var yanzheng=false;
	/*var slider = new SliderUnlock("#slider",{
				successLabelTip : "Success"	
			},function(){
				 yanzheng=true;
        	});
    slider.init();*/
    $(".indentifying-code input").focus(function(){
        $(this).css({
            "background":"url(images/yanzheng.png)",
            "color":"white"
        });
        if(this.value=="captcha")
            $(this).val("");
    })
    $(".indentifying-code input").blur(function(){
        $(this).css({
            "background":"url(images/yanzheng1.png)",
            "color":"#999"
        });
        if($(this).val()=="")
            $(this).val("captcha");
    })

    /*
    $(".login-in").click(function(){
    	if($(".username").val()=="username"||$(".password").val()=="password")
    		alert("username and password cannot be empty!");
    	$.ajax({  
                type: "POST", 
                url: "regist_username.ashx",
                data:{
                	"userName":$(".username").val(),
                	"passWord":$(".password").val()
                },
                success: function(dat) {
                    var datObj=JSON.parse(dat);
                    if(dataObj.judgeRight)
                    	//judgeright为布尔值，判断用户名和密码是否匹配
                    	window.open();
                    //此处括号中输入后台管理界面的网址
                	else{
                		alert("Password isn't right!");
                	}
                }
                //dat为由服务器返回，并根据dataType进行处理后的函数
         });  
    

    })
    */



})