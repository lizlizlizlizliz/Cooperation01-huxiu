<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthorEditor.aspx.cs" Inherits="AuthorFile_AuthorEditor" %>

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
           
            <br />
           
            作者名字：<asp:TextBox ID="name" MaxLength="8" Enabled="false" runat="server" Width="229px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <%--按下去就可以编辑了--%>
    <asp:LinkButton ID="btnEditors" runat="server" Text="编辑" OnClick="btnEditors_Click" />    
            <br /><br />
            作者头像：<br />
        <asp:Image runat="server" ID="image" Height="100" Width="100" />
        <%--编辑的时候再显示出来--%>
       <div id="uploader" runat="server" hidden="hidden"  class="wu-example">
       <!--用来存放文件信息-->
       <div id="thelist" class="uploader-list"></div>
        <div class="btns">
        <div id="picker">选择文件</div>
        <div id="ctlBtn" class="webuploader-pick" onmouseover="mouseO();" onmouseout="mouseOt();" >开始上传</div>
        </div>
        <input id="lb" type="hidden" runat="server" />
        </div>

         
            <br /> <br />
            作者性别：<asp:RadioButtonList ID="sex" runat="server" Enabled="false"  ><asp:ListItem Selected="True" Value="1">男</asp:ListItem><asp:ListItem Value="0">女</asp:ListItem></asp:RadioButtonList>
            作者简介：<br />
            <asp:TextBox ID="summary" runat="server" MaxLength="20" Enabled="false" BorderStyle="Dashed" TextMode="MultiLine" Height="95px" Width="329px" ></asp:TextBox>
            <br />
    <br />
            <asp:Button ID="btnEditor" runat="server" Visible="false" Text="修改" OnClick="btnEditor_Click" />
 
    </div>
    </form>
</body>
</html>
