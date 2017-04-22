<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>


<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>虎嗅后台管理</title>
	<link rel="stylesheet" href="css/login.css">
	<!-- <link href="css/slide-unlock.css" rel="stylesheet">  -->
	<script src="Scripts/jquery-3.1.1.min.js"></script>
  	<!-- <script src="js/jquery.slideunlock.js"></script> -->
</head>
<body>
    <form id="form1" runat ="server">

	<div class="container">
		<h1>Adiminstrator Login Page</h1>
<!-- <input class="username" type="text" value="username"> -->
        
        <asp:TextBox ID="txtUserName" runat ="server"  MaxLength="8" CssClass="username" Text="username"></asp:TextBox>



	<div class="username-tip">
			<p>用户名不存在</p>
		</div>

	<!--	<input  class="password" type="text" value="password"> -->

        <asp:TextBox ID="txtpwd" runat ="server"  CssClass="password"  MaxLength="16" Text="password"></asp:TextBox> 

		<div class="password-tip">
			<p>密码格式不正确</p>
		</div> 

    
		<div class="indentifying-code clearfix">
		<!--	<input type="text">  -->
            <asp:TextBox ID="txtCaptcha"  runat ="server"  Text="captcha" MaxLength="2" ></asp:TextBox>
			<div>
                  <img  src ="captcha.aspx"  id="valiImg" alt="validate" width="140" height="65" onclick="reflash();"/>
                <script>
            function reflash() {
                $("#valiImg").attr("src", 'captcha.aspx?time=' + Math.random());
            }
        </script>
               <!--     <a  href="javascript:void(0)" onclick ="reflash(); return false">看不清， 点击刷新</a>  -->
			</div>
		</div>
          

        <div class="login-in" runat ="server">
          <!--  login -->
            <asp:LinkButton ID="lbtLogin"  ForeColor="White" runat ="server" Text="Login" OnClick="lbtLogin_Click"></asp:LinkButton>
        </div>
	</div>



	<script src="Scripts/login.js"></script>

        </form>
</body>
</html>