<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeFile="PassageAdd.aspx.cs" Inherits="PassageAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="webUploader/jquery-1.7.1.min.js"></script>
    <link href="webUploader/webuploader.css" rel="stylesheet" />
    <script src="webUploader/webuploader.nolog.js"></script>
    <script src="webUploader/fileUpload.js"></script>
   <style type="text/css">
        div{
            width:100%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <div  >
    标题：<asp:TextBox ID="title" MaxLength="20" runat="server" ></asp:TextBox>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        作者：<asp:DropDownList ID="author" runat="server"></asp:DropDownList>
        <asp:LinkButton ID="authorAdd" runat="server" Text="如果未找到该作者请添加" PostBackUrl="AuthorAdd.aspx"></asp:LinkButton>
            
        <br />
    分类:<asp:DropDownList ID="category" runat="server"></asp:DropDownList> 
         <asp:LinkButton ID="categoryAdd" runat="server" Text="如果未找到该分类请添加" PostBackUrl="PCategoryAdd.aspx"></asp:LinkButton>

        <br />

    封面：<br />
    
        <div id="uploader" runat="server"  class="wu-example">
        <!--用来存放文件信息-->
        <div id="thelist" class="uploader-list"></div>        
        <div class="btns">
        <div style="width:90px" id="picker">选择图片</div>
        <div id="ctlBtn" style="width:90px" class="webuploader-pick" onmouseover="mouseO();" onmouseout="mouseOt();" >开始上传</div>
        </div>
        <input id="lb" type="hidden" runat="server" />
        </div>    

       <br /> 
        <textarea id="editor" runat="server" type="text/plain"  style="width:1024px;height:500px;" ></textarea>
        <script type="text/javascript">
        var ue = UE.getEditor('<%=editor.ClientID %>');</script>
        <br />

        <h4> <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" /> </h4>
        <br />
        <br />

    </div>
        </form>
</body>
</html>
