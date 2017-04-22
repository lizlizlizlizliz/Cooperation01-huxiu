<%@ Page Language="C#" MasterPageFile="/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<!DOCTYPE html>
<html lang="en">
    <meta charset="UTF-8">
	<title>虎嗅网</title>
	<link rel="stylesheet" type="text/css" href="css/index.css">
	<link rel="stylesheet" type="text/css" href="css/topnav.css">
	<link rel="stylesheet" type="text/css" href="css/footer.css">
	<script type="text/javascript" src="http://cdn.static.runoob.com/libs/jquery/1.10.2/jquery.min.js"></script>
	<script type="text/javascript" src="js/index.js"></script>
	<script type="text/javascript" src="js/topnav.js"></script>
	<script type="text/javascript" src="js/footer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="click-to-close"></div>
	<div class="container">
		<div class="topNews"><!--头条轮播+热文+短趣-->
		<ul class="turnImg">

                <asp:Repeater ID="rptTurnImg" runat ="server" >
                   <ItemTemplate>
                         <li><a  href='<%# "/PassageContent.aspx?id=" + Eval("HId") %>'  ><img src='<%# Eval("Himg") %>'></a></li>
                   </ItemTemplate>
                </asp:Repeater>
		</ul>

			<div class="turn"> <!--轮播按钮-->
				<span class="turnLeft"></span>
				<span class="turnRight"></span>
			</div>
			<div class="hotInteresting"><!--热文+短趣-->
				<div class="content"><!--热文标题-->

                    <asp:Repeater ID="rptHotPassage" runat ="server"  >
                        <ItemTemplate>
                            <div class="issay">
						<a href='<%# "/PassageContent.aspx?id=" + Eval("PassageId") %>''>
						<h1><%#Eval("PassageTitle") %></h1>
						</a>
					</div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!--
					<div class="issay">
						<a href="">
						<h1>18年后大学文凭可能需要花费50万美元</h1>
						</a>
					</div>
					<div class="issay">
						<a href="">
						<h1>18年后大学文凭可能需要花费50万美元</h1>
						</a>
					</div>
					<div class="issay">
						<a href="">
						<h1>18年后大学文凭可能需要花费50万美元</h1>
						</a>
					</div>
					<div class="issay">
						<a href="">
						<h1>18年后大学文凭可能需要花费50万美元</h1>
						</a>
					</div>
                        -->
					<h1 class="issayAll"><a href="PassageList.aspx?id=1">全部>></a></h1>
				</div>
				<div class="content displayNone" id="content"><!--短趣标题-->
					
                    <asp:Repeater ID="rptNews" runat ="server" >
                        <ItemTemplate>

                            <div class="issay">
						<h1><%# Eval("NewsTitle") %></h1>

					</div>

                        </ItemTemplate>
                    </asp:Repeater>                

					<h1 class="issayAll"><a href="ShortList.aspx">全部>></a></h1>
				</div>
				<div class="titles"><!--切换按钮-->
					<div class="hot hover"><a href="">热文</a></div>
					<div class="interesting"><a href="">短趣</a></div>
					<div class="spare"></div>
				</div><!--a标签以切换到热文/短趣全部内容-->
			</div>
		</div>
	<div class="shortA"><!--短趣弹窗-->
			<div class="shortAlert">
				<div class="close"><!--关闭按钮--></div>
				<h1>这是一本可以挂在墙上的魔法日历</h1>
				<div><!--相关信息-->
					<h1>7小时前</h1>
				</div>
				<p>给魅族设计了悬浮音响造型的日本设计师坪井浩尚最近又和Android Objects试验项目玩到了一起。让他产生设计Magic Calendar想法的原因正是出自上一段的需要，在家时不想做拿出手机，解锁，打开app这一系列动作去看日程安排；外观设计思想则是随着挂历的形态而流动，“纸与电子设备的结合”，所以使用无框电子墨水屏作为它的显示材料，让其显示Android手机上的日程安排并保持同步。</p>
				<p><a href="">详情>></a></p>
			</div>
		</div>
		<!--很多a标签……-->
		<div class="newsList"><!--首页新闻列表-->
			
		</div>
		<div class="loading"><!--加载按钮--></div>
	</div>
		<%--<div>
		<a href="javascript:void(0);" id="btn_Page" class="alink">查看更多>>></a>
		</div>--%>
</asp:Content>