<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthorAdd.aspx.cs" Inherits="AuthorFile_AuthorAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="webUploader/jquery-1.7.1.min.js"></script>
    <link href="webUploader/webuploader.css" rel="stylesheet" />
    <script src="webUploader/webuploader.nolog.js"></script>
    <script src="webUploader/fileUpload.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
        <div >          
            作者名字：<asp:TextBox ID="name" MaxLength="8" runat="server" Width="218px"></asp:TextBox>
            <br /><br />
            作者头像：
            <br /><br />

        <div id="uploader" runat="server" class="wu-example">
        <!--用来存放文件信息-->
        <div id="thelist" class="uploader-list"></div>        
        <div class="btns">
        <div id="picker">选择图片</div>
        <div id="ctlBtn" class="webuploader-pick" onmouseover="mouseO();" onmouseout="mouseOt();" >开始上传</div>
        </div>
        <input id="lb" type="hidden" runat="server" />
        </div>
    

            <br /> <br />
            作者性别：<asp:RadioButtonList ID="sex" runat="server"  ><asp:ListItem Selected="True" Value="1">男</asp:ListItem><asp:ListItem Value="0">女</asp:ListItem></asp:RadioButtonList>
            作者简介：<br />
            <asp:TextBox ID="summary" runat="server" MaxLength="20" BorderStyle="Dashed" TextMode="MultiLine" Height="64px" Width="307px" ></asp:TextBox>
            <br />
    <br />
            <asp:Button ID="btnAdd" runat="server" Text="增加" OnClick="btnAdd_Click" />

        </div>
    </form>
</body>
</html>
