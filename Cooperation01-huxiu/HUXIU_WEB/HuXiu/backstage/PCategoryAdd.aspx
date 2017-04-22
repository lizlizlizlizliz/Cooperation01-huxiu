<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PCategoryAdd.aspx.cs" Inherits="PCategoryAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
    类名：<asp:TextBox ID="name" runat="server" MaxLength="4" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />
    </div>
    </form>
</body>
</html>
