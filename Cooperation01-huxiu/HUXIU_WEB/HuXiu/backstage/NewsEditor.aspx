<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="NewsEditor.aspx.cs" Inherits="NewsFile_NewsEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<%--    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <script type="text/javascript" charset="utf-8" src="ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="/webUploader/jquery-1.7.1.min.js"></script>

    <style type="text/css">
        div {
            width: 100%;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    标题：<asp:TextBox ID="title" MaxLength="20" Enabled="false" runat="server" Width="454px" ></asp:TextBox>
        &nbsp;
                <asp:LinkButton ID="lbtnEditor" runat="server" Text="编辑" OnClick="lbtnEditor_Click"></asp:LinkButton>
        &nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        内容：
                <br />
       <asp:TextBox ID="content"  runat="server" TextMode="MultiLine" Enabled="false" Height="115px" Width="519px"></asp:TextBox>

        <br />

        <br />
        详情链接：<asp:TextBox ID="link" MaxLength="95" TextMode="MultiLine"  Enabled="false" runat="server" Width="423px" Height="60px" ></asp:TextBox>
        &nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <br />
        发布时间：<asp:Label ID="dates" runat="server" ></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnEditor" Visible="false" runat="server" Text="编辑" OnClick="btnEditor_Click" />
    </div>
    </form>
</body>
</html>
