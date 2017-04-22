<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchList.aspx.cs" Inherits="SearchList" MasterPageFile="~/MasterPage/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>虎嗅网-搜索</title>
	<link rel="stylesheet" type="text/css" href="css/shortmonl.css">
	<link rel="stylesheet" type="text/css" href="css/footer.css">
	<link rel="stylesheet" type="text/css" href="css/topnav.css">
	<script type="text/javascript" src="http://cdn.static.runoob.com/libs/jquery/1.10.2/jquery.min.js"></script>
	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/search.js"></script>
	<script type="text/javascript" src="js/footer.js"></script>
	<script type="text/javascript" src="js/topnav.js"></script>
</head>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<div class="container clearfix">
		<div class="searchInput">
			<input type="text" name="" placeholder="">
			<span></span>
		</div>
		<div class="lists clearfix"><!--短趣列表-->
			<!-- <div class="funs shadow">
				<div class="funs-left">
					<img src="images/icon01.png">
					<h1>发条橙子</h1>
					<p>七小时前</p>
				</div>
				<div class="funs-right">
					<h1>研究显示在网上浏览猫咪图片视频可让强迫症患者感觉更好</h1>
					<div class="like">
					<span>0</span>
					<button class="likebutton"></button>
					</div>
					<div class="liked">
					<span>+1</span>
					<button class="already"></button>
					</div>
					<p>使用互联网的人们喜欢猫的视频，实际上，猫视频在YouTube上每个类别的观看次数都是最高的，研究人员甚至出了一篇论文，来研究拖延症/强迫症患者在互联网上观看猫咪图片或者视频是否有助于改善心情。这篇论文于2015年发表在《计算机和人类行为》杂志上，论文的关键字包括互联网使用、有罪快乐、拖延、享受、社交媒体和猫。</p>
				</div>
			</div> -->
		</div>
		<div class="loading"><!--加载按钮--></div>
	</div>
</asp:Content>
