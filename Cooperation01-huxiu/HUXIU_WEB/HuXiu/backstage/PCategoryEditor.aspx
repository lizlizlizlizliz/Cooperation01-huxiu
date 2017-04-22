<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PCategoryEditor.aspx.cs" Inherits="PCategoryEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="name" runat="server"  Enabled="false" MaxLength="4"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton runat="server" ID="editor" OnClick="editor_Click" Text="编辑"></asp:LinkButton>
        <br />
        <asp:Button ID="btnEditor" Text="修改" Visible="false" runat="server" OnClick="btnEditor_Click" />
    </div>
    </form>
</body>
</html>
