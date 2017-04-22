<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ShortList.aspx.cs" Inherits="ShortList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!DOCTYPE html>
<html lang="en">
    <meta charset="UTF-8">
	<title>虎嗅网-短趣</title>
	<!-- <link rel="stylesheet" type="text/css" href="css/short.css"> -->
	<link rel="stylesheet" type="text/css" href="css/shortmon.css">
	<link rel="stylesheet" type="text/css" href="css/footer.css">
	<link rel="stylesheet" type="text/css" href="css/topnav.css">
	<!-- <script type="text/javascript" src="http://cdn.static.runoob.com/libs/jquery/1.10.2/jquery.min.js"></script> -->
	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/short.js"></script>
	<script type="text/javascript" src="js/footer.js"></script>
	<script type="text/javascript" src="js/topnav.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container clearfix">
		<div class="listTitle">
			<img src="images/lifestyle.png"><!--hover时展开导航栏-->
			<h1>短趣</h1>
		</div>
        <div class="lists clearfix">
    	</div>
    </div>
    <div class="loaddiv"></div>
</asp:Content>

