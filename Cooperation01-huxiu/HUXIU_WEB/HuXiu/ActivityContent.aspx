<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ActivityContent.aspx.cs" Inherits="ActivityContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>Document</title>
	<link rel="stylesheet" href="css/activity content.css" />
	<link rel="stylesheet" type="text/css" href="css/topnav.css" />
	<link rel="stylesheet" href="css/footer.css" />
	<script src="js/jquery.js"></script>
	<script type="text/javascript" src="js/topnav.js"></script>
    <script src="js/activity content.js"></script>
	<script src="js/footer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<div class="container">
		<div class="activity-main">
			<div class="main-content">
				<%--<img src="images/activity-background2.png" alt="">--%>
                <asp:Image ID="img" runat="server" />
				<div class="main-content-summary">
					<h1><asp:Label ID="title" runat="server"></asp:Label></h1>
					<div>
						<asp:Label ID="what" runat="server"></asp:Label>
					</div>
				</div>
				<p class="main-content-information">
					地点：<asp:Label ID="where" runat="server"></asp:Label><br>
                    时间：<asp:Label ID="when" runat="server" ></asp:Label>
				</p>
			</div>
			<div class="main-buy">
				<div >
					<a class="main-buy-vip" href=""><p><asp:Label runat="server" ID="tips"></asp:Label></p><img src="images/orange-left.png" alt=""></a>
				</div>
				<a class="main-buy-now" href="">立 即 购 票</a>
			</div>
		</div>
		<div class="activity-related">
			<h1>相关活动</h1>

			<div class="activity-related-main clearfix">
				<div class="activity-more-left">
					<div class="activity-more">
						<img src="images/activity-icon.png" alt="">
						<h1>虎嗅活动</h1>
						<p><asp:Label ID="title1" runat="server"></asp:Label></p>
						<div class="act-change">
                            <asp:ImageButton runat="server" class="activity-mouseover-img" ID="image1" />
							<%--<img class="activity-mouseover-img" src="images/more-activity.png" alt="">--%>
							<a href="">了解更多</a>
						</div>
					</div>
				</div>
				<div class="activity-more-center">
					<div class="activity-more">
						<img src="images/activity-icon.png" alt="">
						<h1>虎嗅活动</h1>
						<p><asp:Label ID="title2" runat="server"></asp:Label></p>
						<div class="act-change">
							<%--<img class="activity-mouseover-img" src="images/more-activity.png" alt="">--%>
                            <asp:ImageButton runat="server" class="activity-mouseover-img" ID="image2" />
							<a href="">了解更多</a>
						</div>
					</div>
				</div>
				<div class="activity-more-right">
					<div class="activity-more">
						<img src="images/activity-icon.png" alt="">
						<h1>虎嗅活动</h1>
		                <p><asp:Label ID="title3" runat="server"></asp:Label></p>
						<div class="act-change">
							<%--<img class="activity-mouseover-img" src="images/more-activity.png" alt="">--%>
                            <asp:ImageButton runat="server" class="activity-mouseover-img" ID="image3" />
							<a href="">了解更多</a>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

	

