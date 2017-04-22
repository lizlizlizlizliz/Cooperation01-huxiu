<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recovery.aspx.cs" Inherits="recovery" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Welcome to Tablecloth</title>

<!-- paste this code into your webpage -->
<link href="tablecloth/tablecloth.css" rel="stylesheet" type="text/css" media="screen" />
<script type="text/javascript" src="tablecloth/tablecloth.js"></script>
<!-- end -->

<style>

body{
	margin:0;
	padding:0;
	background:#f1f1f1;
	font:70% Arial, Helvetica, sans-serif; 
	color:#555;
	line-height:150%;
	text-align:left;
}
a{
	text-decoration:none;
	color:#057fac;
}
a:hover{
	text-decoration:none;
	color:#999;
}
h1{
	font-size:140%;
	margin:0 20px;
	line-height:80px;	
}
h2{
	font-size:120%;
}
#container{
	margin:0 auto;
	width:680px;
	background:#fff;
	padding-bottom:20px;
}
#content{margin:0 20px;}
p.sig{	
	margin:0 auto;
	width:680px;
	padding:1em 0;
}
form{
	margin:1em 0;
	padding:.2em 20px;
	background:#eee;
}
    </style>

</head>

<body>

<form id="form1" runat="server">

    
<!--<div id="container">-->
	<div title="SetCategory">
       <!--添加分类框，默认资讯-->
        分类：
        <asp:DropDownList ID ="DplistCategory" runat="server"  OnTextChanged="DplistCategory_TextChanged"   AutoPostBack="True">
            <asp:ListItem>资讯</asp:ListItem>
            <asp:ListItem>短趣</asp:ListItem>
            <asp:ListItem>活动</asp:ListItem>
        </asp:DropDownList>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:DropDownList ID="DplistPassageLable" runat="server" Visible="false" OnSelectedIndexChanged="DplistPassageLable_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
         &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Label ID="lblCount" runat="server" Font-Bold="true" ></asp:Label>
        
        
        </div>
	<div id="content">


	<!-- all you need with Tablecloth is a regular, well formed table. No need for id's, class names... --> 
	
	
		<table cellspacing="0" cellpadding="0">
			<tr>
				<th>序号</th>
				<th>标题</th>
				<th>删除时间</th>
				<th>管理员</th>
				<th>恢复</th>
			</tr>

            <asp:Repeater ID="RptRecoverList" runat="server"  OnItemDataBound="RptRecoverList_ItemDataBound" OnItemCommand="RptRecoverList_ItemCommand" >
                <ItemTemplate>
                    <tr>
				        <td><asp:Label ID="No" runat="server" Text =""></asp:Label></td>
				        <td><asp:LinkButton ID="lbTitle" runat ="server" Text ='<%# Eval("Title") %>'  CommandName="jumpPage" CommandArgument='<%# Eval("Id")+","+Eval("Link") %>'></asp:LinkButton> ></td>
				        <td><%#Eval("Time")%></td>
				        <td><asp:LinkButton ID="lbAdmin" runat="server" Text ='<%#Eval("AdminName")%>'  CommandName="jumpAdmin" CommandArgument='<%# Eval("AdminId ") %>' ></asp:LinkButton></td>
				        <td><asp:LinkButton ID="lbDelete" runat="server" Text="恢复" OnClientClick="return confirm('请问确定要恢复这篇文章吗？')" CommandName="recover" CommandArgument='<%#Eval("Id")+","+Eval("DelCate") %>'></asp:LinkButton></td>
				        
			        </tr>	
                </ItemTemplate>
            </asp:Repeater>														
		</table>	
	</div>

           <div id="divTool" runat="server" visible="false" style="margin:0 auto; width:400px; height:100px;border:0;">
            <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
            <asp:Button ID="btnUp" runat="server" Text="上一页" OnClick="btnUp_Click" />
            <asp:Button ID="btnDrow" runat="server" Text="下一页" OnClick="btnDrow_Click" />

            <asp:Button ID="btnLast" runat="server" Text="尾页" OnClick="btnLast_Click" />
            页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
            /<asp:Label ID="lbTotal" runat="server" Text="1"></asp:Label>

            转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="30px" TextMode="Number"></asp:TextBox>
            <asp:Button ID="btnJump" runat="server" Text="Go" OnClick="btnJump_Click" />

        </div>



<!--</div>	-->
    </form>
</body>
</html>


