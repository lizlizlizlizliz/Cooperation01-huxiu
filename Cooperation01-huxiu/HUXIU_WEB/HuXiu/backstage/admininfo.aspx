<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admininfo.aspx.cs" Inherits="Admininfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <link href="webUploader/webuploader.css" rel="stylesheet" />
    <script src="webUploader/webuploader.nolog.js"></script>
    <script src="webUploader/fileUpload.js"></script>
       <script>
           $(function () {

               $(".password").focus(function () {
                   $(".password").attr("type", "password");

                   if (this.value == "●●●●●●●●●●")
                       $(this).val("");
               })
               $(".password").blur(function () {

                   if ($(this).val() == "")
                       $(this).val("●●●●●●●●●●").attr("type", "password");


               })


           })</script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>管理员信息</h1>

        头像：<asp:Image runat="server" ID="image" Height="100" Width="100" />

        <div id="uploader" visible="false" runat="server" class="wu-example">
        <!--用来存放文件信息-->
        <div id="thelist" class="uploader-list"></div>        
        <div class="btns">
        <div id="picker">选择图片</div>
        <div id="ctlBtn" class="webuploader-pick" onmouseover="mouseO();" onmouseout="mouseOt();" >开始上传</div>
        </div>
            <%--用来存图片名--%>
        <input id="lb" type="hidden" runat="server" />
        </div>


        <h3>姓名：<asp:Label ID="lblName" runat="server"></asp:Label></h3>
        <h3>性别：<asp:Label ID="lblSex" runat="server"></asp:Label></h3>

        <div id="divPwd" runat ="server" visible="false">
        <h3>修改密码：<asp:TextBox ID="txtPwd" runat ="server"  CssClass="password" MaxLength="16"  Text="●●●●●●●●●●"></asp:TextBox></h3>
        <h3>再次确认：<asp:TextBox ID="txtRptPwd" runat ="server"  MaxLength="16"  CssClass="password" Text="●●●●●●●●●●"></asp:TextBox></h3>
     
        
        </div>

        <h3>密保问题:<asp:TextBox ID="txtProProtect" runat ="server" MaxLength="18" ReadOnly="true" ></asp:TextBox></h3>
        <h3>密保答案:<asp:TextBox ID="txtProAnswer" runat ="server" MaxLength="18" ReadOnly="true"></asp:TextBox></h3>
        <h3><asp:Button ID="btnEdit" runat ="server" Text="编辑信息"  OnClick="btnEdit_Click"/></h3>
        <h3><asp:Button ID="btnSubmit" runat ="server" Text="提交修改" Visible="false" OnClick="btnSubmit_Click" /></h3>
    </div>
    </form>
</body>
</html>
