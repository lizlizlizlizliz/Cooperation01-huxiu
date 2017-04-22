<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPage.master" CodeFile="PassageContent.aspx.cs" Inherits="PassageContent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<meta charset="UTF-8">
	<title>Document</title>
	<link rel="stylesheet" href="/css/news content.css">
	<link rel="stylesheet" type="text/css" href="/css/topnav.css">
	<link rel="stylesheet" href="/css/footer.css">
	<script src="/js/jquery.js"></script>
	<script type="text/javascript" src="/js/topnav.js"></script>
    <script src="js/news content.js"></script>
	<script src="js/footer.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="container">
		<div class="writer-and-content">
			<div class="writer-inf">
				<div class="writer-title clearfix">
					<a href="#">                        
                        <asp:Image runat="server" ID="authorimage" />
<%--<img src="images/writer-photo.png" alt="">--%></a>
					<h1><asp:Label runat="server" ID="title"></asp:Label></h1>
				</div>
				
				<div class="about-writer clearfix">
					<a href="#">
						<img src="images/find-writer.png" alt="">
						<p><asp:Label runat="server" ID="authorname"></asp:Label></p>
					</a>
					<p ><asp:Label runat="server" ID="authorsummary"></asp:Label></p>
					<p></p>
					<%--<p >20篇文章</p>--%>
				</div>
			</div>
			<div class="just-border"></div>
			<div class="inf-operate clearfix">
				<div class="infor">
					<p><asp:Label runat="server" ID="time"></asp:Label></p>
					<p><asp:Label runat="server" ID="views"></asp:Label></p>
					<p>评论6</p>
				</div>
				<div class="operate">
					<div class="operate-click" ></div>
					<div class="operate-click operate-click-2"></div>
					<div class="operate-collect"></div>
					<div class="operate-share share-first"></div>
				</div>
			</div>
			<div class="article-content">
			<!-- 	<div class="wechat-weibo share-first">
				<div class="weibo"></div>
				<div class="wechat"></div>
			</div> -->
		<!-- 	<div class="weibo-2d">
				<div></div>
				<div></div>
			</div>
			<div class="wechat-2d">
				<div></div>
				<div></div>
		</div> -->
					<div class="wechat-weibo share-first">
						<div class="weibo"></div>
						<div class="wechat"></div>
						<div class="weibo-2d">
							<div></div>
							<div></div>
						</div>
						<div class="wechat-2d">
							<div></div>
							<div></div>
						</div> 
					</div>
                <asp:Image runat="server" ID="image" />
				<div class="article-para">
                    
                    <asp:Label runat="server" ID="content"></asp:Label>
                    </div>
		</div>
     </div>
		<div class="activity-related">
			<h1>相关文章</h1>
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


