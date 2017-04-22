<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetHeadline.aspx.cs" Inherits="headline" %>

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

    

   
	
	<div id="content">

     <h3>当前头条<asp:Label ID="lblCanAdd" runat="server" ></asp:Label></h3>
	
		<table cellspacing="0" cellpadding="0">
			<tr>
				<th>序号</th>
				<th>标题</th>
				<th>倒计时</th>
				<th>修改</th>
				<th>删除</th>
			</tr>

            <asp:Repeater ID="RptDisplaying" runat="server" OnItemDataBound="RptDisplaying_ItemDataBound"  OnItemCommand="RptDisplaying_ItemCommand">
                <ItemTemplate>
                    <tr>
				        <td><asp:Label ID="No" runat="server" Text =""></asp:Label></td>
				        <td><asp:LinkButton ID="lbTitle" runat ="server" Text ='<%# Eval("Htitle") %>'  PostBackUrl=' <%#"PassageEditor.aspx?id="+Eval("HId") %> ' ></asp:LinkButton> ></td>
				        <td><asp:Label ID="headLeftTime" runat="server" Text=""></asp:Label>></td>
				        <td><asp:LinkButton ID="lbEdit" runat="server" Text ="修改" CommandName="jumpEidt" CommandArgument='<%# Eval("Id ")+","+Eval("Hdeadline") %>'></asp:LinkButton></td>
				        <td><asp:LinkButton ID="lbDelete" runat="server" Text="删除" OnClientClick="return confirm('请问确定要删除头条吗？')" CommandName="deleteHead" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton></td>
				        
			        </tr>	
                </ItemTemplate>
            </asp:Repeater>														
		</table>
        
        
        
        <h3>等待上头条<asp:Label ID="lblqueue" runat="server"  ></asp:Label></h3>	


        <table cellspacing="0" cellpadding="0">
			<tr>
				<th>序号</th>
				<th>标题</th>
				<th>倒计时</th>
				<th>上头条</th>
				<th>删除</th>
			</tr>

            <asp:Repeater ID="rptQueue" runat="server"  OnItemDataBound="rptQueue_ItemDataBound" OnItemCommand="rptQueue_ItemCommand">
                <ItemTemplate>
                    <tr>
				        <td><asp:Label ID="No" runat="server" Text =""></asp:Label></td>
				        <td><asp:LinkButton ID="lbTitle" runat ="server" Text ='<%# Eval("Htitle") %>' PostBackUrl=' <%#"PassageEditor.aspx?id="+Eval("HId") %> '></asp:LinkButton> ></td>
				        <td><asp:Label ID="waitLeftTime" runat="server" Text=""></asp:Label>></td>
				        <td><asp:LinkButton ID="lbGoHead" runat="server" Text ="上头条" CommandName="goHead" CommandArgument='<%# Eval("Id ") %>'></asp:LinkButton></td>
				        <td><asp:LinkButton ID="lbDelete" runat="server" Text="删除" OnClientClick="return confirm('请问确定要删除头条吗？')" CommandName="deleteHead" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton></td>
				        
			        </tr>	
                </ItemTemplate>
            </asp:Repeater>														
		</table>


        <h4><asp:Button ID="btnAddItem" runat="server" Text="增加头条"  OnClick="btnAddItem_Click"/></h4>




        <div id="divAddRecord" runat ="server" visible="false">
            <h4>ID:<asp:TextBox ID="txtId" runat ="server" TextMode="Number"></asp:TextBox><br /></h4>
            <h4>截至时间:<asp:TextBox ID="txtShowTime" runat ="server"  MaxLength="14"></asp:TextBox></h4>
            <h4><asp:Button ID="btnSubmit" runat ="server"  Text="保存" OnClick="btnSubmit_Click"/></h4>

        </div>

          <div id="divEditRecord" runat ="server" visible="false">
            <h4>ID:<asp:TextBox ID="txtEditID" runat ="server"  ReadOnly="true"></asp:TextBox><br /></h4>
            <h4>截至时间:<asp:TextBox ID="txtEditTime" runat ="server"  MaxLength="14"></asp:TextBox></h4>
            <h4><asp:Button ID="btnSubmitEdit" runat ="server"  Text="修改" OnClick="btnSubmitEdit_Click"/></h4>


        </div>


	</div>





    </form>
</body>
</html>

