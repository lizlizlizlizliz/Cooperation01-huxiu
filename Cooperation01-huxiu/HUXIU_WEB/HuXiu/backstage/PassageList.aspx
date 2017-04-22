<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PassageList.aspx.cs" Inherits="PassageList" %>

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
	width:1680px;
	background:#fff;
	padding-bottom:20px;
}
#content{
	margin:0 20px;
	width: 1600px;
}
#content table {
	table-layout:fixed;
}
#content tr td {
	width:1000px;
	height: 20px;
	overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap; 
}

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

<div id="container">
	
	<div id="content">

        <form runat="server" >
	<!-- all you need with Tablecloth is a regular, well formed table. No need for id's, class names... --> 
	
	

		    <asp:TextBox ID="txtSearch" MaxLength="45" runat="server"></asp:TextBox>

		    分类：<asp:DropDownList ID="DropDownList" runat="server" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>

            <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" />
            
		    <br />
            类型:<asp:RadioButton ID="RbtnPassage" runat="server" Checked="True" GroupName="type" OnCheckedChanged="RbtnPassage_CheckedChanged" Text="文章" />
            <asp:RadioButton ID="RbtnAuthor" runat="server" GroupName="type" OnCheckedChanged="RbtnAuthor_CheckedChanged" Text="作者" />
            <br />
            排序:
            <asp:RadioButton ID="RbtnTime" runat="server" Checked="True" GroupName="order" Text="按时间排序" OnCheckedChanged="RbtnTime_CheckedChanged" />
            <asp:RadioButton ID="RbtnViews" runat="server" GroupName="order" Text="按热度排序" OnCheckedChanged="RbtnViews_CheckedChanged" />
            
         
	

		<br /><table cellspacing="0" cellpadding="0">
			<tr>
				<th>标题</th>
				<th>内容</th>
				<th>分类</th>
				<th>作者</th>
                <th>发布时间</th>
                <th>阅读量</th>
				<th>删除</th>
			</tr>

			<asp:Repeater ID="Rpt" runat="server" OnItemCommand="Rpt_ItemCommand">
                <ItemTemplate>

                    <tr>
				        <td> <asp:LinkButton ID="lbTitle" runat="server" Text='<%#Eval("PassageTitle") %>' PostBackUrl='<%# "PassageEditor.aspx?id="+ Eval("PassageId") %>'></asp:LinkButton></td>
				        <td><%#Eval("PassageBody") %></td>
				        <td><%#Eval("CategoryName") %></td>
				        <td> <asp:LinkButton ID="lbName" runat="server" Text='<%#Eval("AuthorName") %>' PostBackUrl='<%# "AuthorEditor.aspx?id="+ Eval("AuthorId") %>'></asp:LinkButton></td>
                        <td><%#Eval("PublishDate") %></td>
                        <td><%#Eval("PageViews") %></td>
				        <td><asp:LinkButton ID="lbDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("PassageId") %>'></asp:LinkButton></td>
			        </tr>	

                </ItemTemplate>
            </asp:Repeater>
            																	
		</table>	

        <asp:Button ID="btnUp" runat="server" Text="上一页" OnClick="btnUp_Click" />
        <asp:Button ID="btnDrow" runat="server" Text="下一页"  OnClick="btnDrow_Click"/>
        <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
        页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lbTotal" runat="server" Text="1"></asp:Label>

        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="25px"></asp:TextBox>
        <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/>

        
	</form>
	</div>
</div>	
</body>
</html>
