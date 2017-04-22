<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="PassageEditor.aspx.cs" Inherits="PassageEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="webUploader/jquery-1.7.1.min.js"></script>
    <link href="webUploader/webuploader.css" rel="stylesheet" />
    <script src="webUploader/webuploader.nolog.js"></script>
    <script src="webUploader/fileUpload.js"></script>
    <style type="text/css">
        div {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            标题：<asp:TextBox ID="title" Enabled="false" MaxLength="20" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    作者：<asp:DropDownList ID="author" Enabled="false" runat="server"></asp:DropDownList>
            <asp:LinkButton ID="authoradd"  runat="server" Text="如果未找到该作者请添加" PostBackUrl="AuthorAdd.aspx"></asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <%--按下去就可以编辑了--%>
            <asp:LinkButton ID="btnEditors" runat="server" Text="编辑" OnClick="btnEditors_Click" />
            <br />
            分类:<asp:DropDownList ID="category" Enabled="false" runat="server"></asp:DropDownList>
            <asp:LinkButton ID="categoryAdd" runat="server" Text="如果未找到该分类请添加" PostBackUrl="PCategoryAdd.aspx"></asp:LinkButton>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    发布时间：<asp:Label ID="dates" runat="server"></asp:Label>
            <br />
            封面：<br />
            <asp:Image runat="server" ID="image" Height="100" Width="100" />
            <%--编辑的时候再显示出来--%>
            <div id="uploader" runat="server" hidden="hidden" class="wu-example">
                <!--用来存放文件信息-->
                <div id="thelist" class="uploader-list"></div>
                <div class="btns">
                    <div style="width: 90px" id="picker">选择图片</div>
                    <div id="ctlBtn" style="width: 90px" class="webuploader-pick" onmouseover="mouseO();" onmouseout="mouseOt();">开始上传</div>
                </div>
                <input id="ChangeFlag" runat="server" type="hidden" />
                <input id="lb" type="hidden" runat="server" />
            </div>

            <br />
            <textarea id="editor" runat="server" type="text/plain" style="width: 1024px; height: 500px;"></textarea>
            <script type="text/javascript">
                var CheckF = $('#ChangeFlag').val();

                var ue = UE.getEditor('<%=editor.ClientID %>');
                ue.addListener('ready', function () {
                    if (CheckF != '1') {
                        ue.setDisabled();
                    }
                });       
            </script>
            <br />
            <asp:Button ID="btnEditor" runat="server" Visible="false" Text="修改" OnClick="btnEditor_Click" />
        </div>
    </form>
</body>
</html>
