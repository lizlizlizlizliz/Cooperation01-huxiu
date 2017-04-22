<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PassageList.aspx.cs" Inherits="PassageList" MasterPageFile="~/MasterPage/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>虎嗅网-资讯</title>
	<link rel="stylesheet" type="text/css" href="css/information-list.css">
	<link rel="stylesheet" type="text/css" href="css/footer.css">
	<link rel="stylesheet" type="text/css" href="css/topnav.css">
	<script type="text/javascript" src="http://cdn.static.runoob.com/libs/jquery/1.10.2/jquery.min.js"></script>
	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/information-list.js"></script>
	<script type="text/javascript" src="js/footer.js"></script>
	<script type="text/javascript" src="js/topnav.js"></script>
</head>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<body>
	<div class="top"><!--顶部导航栏-->
		<div class="topNav"><!--顶部导航栏居中部分-->
			<div class="informationNav"><!--资讯导航栏-->
				<div class="secondNav displaynone"><!--资讯二级菜单-->
					<ul>
						<li><a href="">电商消费</a></li>
						<li><a href="">娱乐淘金</a></li>
						<li><a href="">电商消费</a></li>
						<li><a href="">娱乐淘金</a></li>
						<li><a href="">电商消费</a></li>
						<li><a href="">娱乐淘金</a></li>
						<li><a href="">电商消费</a></li>
						<li><a href="">娱乐淘金</a></li>
					</ul>
				</div>
				<h1 id="information">资讯</h1>
			</div>
			<div class="logo"><!--虎嗅logo-->
				<a href="index.html">
					<img src="images/logo.jpg">
				</a>
			</div>
			<div class="activities"><!--活动按钮-->
				<a href="">活动</a>
			</div>
			<div class="search"><!--手机+搜索-->
				<a href=""><button id="phone"></button></a><!--手机-->
				<button src="images/search.png" id="search"></button><!--搜索按钮-->
			</div>
		</div>
	</div>


    <div class="alert"><!--搜索弹窗-->
		<div class="alertInner">
			<input type="text" placeholder="请输入关键词">
			<span></span>
			<div class="hotWords">
				<h1>热搜词</h1>
			</div>
		</div>
	</div>--%>

	<div class="container clearfix">
		<div class="listNav"><!--导航-->
			<button></button>
			<ul>
				<asp:Repeater ID="Rpt" runat="server" >
                             <ItemTemplate>
                                 <li><a href='<%# "/PassageList.aspx?id=" + Eval("PCategoryId") %>'><%#Eval("CategoryName") %></a></li>
                            </ItemTemplate>
                </asp:Repeater>
			</ul>
		</div>
		<div class="listTitle"><!--资讯分类标题-->
			<img src="images/lifestyle.png"><!--hover时展开导航栏-->
			<%--<h1>生活腔调</h1>--%>
            <h1><asp:Label runat="server" ID="lifestyle"></asp:Label></h1>
		</div>
		<div class="lists clearfix"><!--资讯列表-->
			
		</div>
		<div class="loading"><!--加载按钮--></div>
	</div>
	<%--<div class="footer">
		<img class="return-top" src="images/returntop.png" alt="">
		<ul class="footer-inf clearfix">
			<li><a href="">关于我们</a></li>
			<li><a href="">加入我们</a></li>
			<li><a href="">合作伙伴</a></li>
			<li><a href="">广告及服务</a></li>
			<li><a href="">常见问题解答</a></li>
			<li><a href="">防网络诈骗专题</a></li>
		</ul>
		<div class="weibo-wechat-qqzone clearfix">
			<div class="footer-weibo"><a href=""></a></div>
			<div class="footer-wechat"><a href=""></a></div>
			<div class="footer-qqzone"><a href=""></a></div>
		</div>
		<div class="footer-login">
			<div>
				<p>All Rights Reserved. </p>
				<a href="login.html">管理员登录</a>
			</div>
		</div>
	</div >
</body>
</html>--%>

</asp:Content>
