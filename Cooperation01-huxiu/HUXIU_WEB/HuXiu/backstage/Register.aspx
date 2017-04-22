<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="testRegist" %>

 
<!DOCTYPE html>
<html>
<head runat="server">
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
   <!-- <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0"> -->
<!--<meta name="keywords" content="注册页面模板,网站注册页面,注册模板页面,网站模板,注册页面表单验证">
<meta name="description" content="JS代码网提供大量的注册页面模板的学习和下载">
<!-- <link rel="shortcut icon" href="resources/images/favicon.ico" />
 -->
    <link href="resources/style/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="resources/js/jquery.js"></script>
<script type="text/javascript" src="resources/js/jquery.i18n.properties-1.0.9.js" ></script>

<script type="text/javascript" src="resources/js/jquery.validate.js"></script>
<script type="text/javascript" src="resources/js/md5.js"></script> 
<script type="text/javascript" src="resources/js/page_regist.js?lang=zh"></script>
<!--[if IE]>
  <script src="resources/js/html5.js"></script>
<![endif]-->
<!--[if lte IE 6]>
	<script src="resources/js/DD_belatedPNG_0.0.8a-min.js" language="javascript"></script>
	<script>
	  DD_belatedPNG.fix('div,li,a,h3,span,img,.png_bg,ul,input,dd,dt');
	</script>
<![endif]-->
</head>
<body class="loginbody">

<div class="dataEye">
	<div class="loginbox registbox">
		<div class="logo-a">
			<a href="#" title="虎嗅网">
				<img src="/images/logo.jpg" height ="70" width="140">
			</a>
		</div>
        
		<div class="login-content reg-content">
			<div class="loginbox-title">
				<h3>注册</h3>
			</div>
			<form id="signupForm" runat ="server"  >
			<div class="login-error"></div>
			<div class="row">
				<label class="field" for="username">用户名</label>
				<input type="text" value="" class="input-text-user noPic input-click" name="username" id="username">
				<div class="icon-tips-div"><img class="icon-tips-img" src="resources/images/icon-tips.png" alt=""></div>
			</div>
			<div class="row">
				<label class="field" for="password">密码(4-16位)</label>
				<input type="password" value="" class="input-text-password noPic input-click" name="password" id="password">
				<div class="icon-tips-div"><img class="icon-tips-img" src="resources/images/icon-tips.png" alt=""></div>
			</div>
			<div class="row">
				<label class="field" for="passwordAgain">确认密码</label>
				<input type="password" value="" class="input-text-password noPic input-click" name="passwordAgain" id="passwordAgain">
				<div class="icon-tips-div"><img class="icon-tips-img" src="resources/images/icon-tips.png" alt=""></div>
			</div>
               
            <div  id="sexdiv" class="row" style="line-height: 50px;">
                        <label class="field" for="sex">性别</label>
                        <input value="女" class="input-text-user noPic input-click" name="sex" id="sexf" checked="checked" style="width: 120px;height:13px" type="radio">女
                        <input value="男" class="input-text-user noPic input-click" name="sex" id="sexm" style="width: 120px;height:13px" type="radio">男
                        <div class="icon-tips-div"><img class="icon-tips-img" src="resources/images/icon-tips.png" alt=""></div>
           </div>
                
			<div class="row">
				<label class="field" for="protectProblem">密保问题</label>
				<input type="text" value="" class="input-text-user noPic input-click" name="protectProblem" id="protectProblem">
				<div class="icon-tips-div"><img class="icon-tips-img" src="resources/images/icon-tips.png" alt=""></div>
			</div>
			<div class="row">
				<label class="field" for="protectAnswer">密保答案</label>
				<input type="text" value="" class="input-text-user noPic input-click" name="protectAnswer" id="protectAnswer">
				<div class="icon-tips-div"><img class="icon-tips-img" src="resources/images/icon-tips.png" alt=""></div>
			</div>
                <div class="row">
                 验证码：  <img  src ="captcha.aspx"  width ="110" height ="30"  id="valiImg" alt="validate"/>
                    <a  href="javascript:void(0)" onclick ="reflash(); return false">看不清， 点击刷新</a>
                    <script>
            function reflash() {
                $("#valiImg").attr("src", 'captcha.aspx?time=' + Math.random());
            }
        </script>
			</div>
                    <div class="row">
                <label class="field" for="captcha">请输入图片计算结果</label>
				<input type="text" value="" class="input-text-user noPic input-click" name="captcha" id="captcha">
			</div>
			<div class="row btnArea">
				<a class="login-btn" id="submit">注册</a>
			</div>
			</form>
		</div>
		
	</div>
	<!--
<div id="footer">
	<div class="dblock">
		<div class="inline-block"><img src="resources/images/logo-gray.png"></div>
		<div class="inline-block copyright">
			<p><a href="#">关于我们</a> | <a href="#">微博</a> | <a href="#">隐私政策</a> | <a href="#">人员招聘</a></p>
			<p> Copyright © 2013 JS代码网</p>
		</div>
	</div>
</div>

        -->

</div>
<div class="loading">
	<div class="mask">
		<div class="loading-img">
		<img src="resources/images/loading.gif" width="31" height="31">
		</div>
	</div>
</div>
</body>
</html>