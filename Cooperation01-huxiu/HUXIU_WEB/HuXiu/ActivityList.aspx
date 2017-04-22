<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ActivityList.aspx.cs" Inherits="ActivityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <html lang="en">
    <meta charset="UTF-8">
	<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
	<title>Document</title>
	<link rel="stylesheet" href="css/activity list.css">
	<link rel="stylesheet" type="text/css" href="css/topnav.css">
	<link rel="stylesheet" href="css/footer.css">
	<!-- <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
	<script src="js/jquery.js"></script> -->
	<script src="js/jqueryto.js"></script>
	<script type="text/javascript" src="js/topnav.js"></script>
    <script src="js/activity list click.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
		<div class="accordion clearfix">
			<a class="act-animate" href="activity content.html">
				<img  class="accordion-act" src="images/banner_bg1.png" alt="">
				<img class="accordion-button" src="images/btn.png" alt="">
			</a>
			<a class="act-animate" href="activity content.html">
				<img  class="accordion-act" src="images/banner_bg2.png" alt="">
				<img class="accordion-button" src="images/btn.png" alt="">
			</a> 
			<a class="act-back" href="activity content.html">
				<!-- <img class="accordion-act" src="images/banner_bg3.png"  alt=""> -->
				 <!-- <img class="accordion-button" src="images/btn.png" alt=""> -->
			</a>
			<img class="accordion-button accordion-special-button" src="images/btn.png" alt="">
		</div>
		<div class="huxiu-act">
			<div class="activity-title">
				<img src="images/huodong_icon.png" alt="">
				<p>»¢Ðá»î¶¯</p>
			</div>		
		</div>
		<div class="loaddiv"></div>
	</div>
</asp:Content>

