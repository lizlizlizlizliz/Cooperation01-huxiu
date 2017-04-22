<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ActivityAdd.aspx.cs" Inherits="ActivityFile_ActivityAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%-- <script type="text/javascript" charset="utf-8" src="ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="ueditor/lang/zh-cn/zh-cn.js"></script>--%>
    <script src="webUploader/jquery-1.7.1.min.js"></script>
    <link href="webUploader/webuploader.css" rel="stylesheet" />
    <script src="webUploader/webuploader.nolog.js"></script>
    <script src="webUploader/fileUpload.js"></script>
  <%-- <style type="text/css">
        div{
            width:100%;
        }
    </style>--%>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div>
        活动标题：<asp:TextBox ID="title" MaxLength="10" runat="server" Width="362px" ></asp:TextBox>
            <br />
        <br />
        活动封面：<br />

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
       活动内容：<br />
            <asp:TextBox ID="content"  runat="server"  TextMode="MultiLine" MaxLength="150" Height="182px" Width="452px" ></asp:TextBox>
            <br />
        <br />
        活动地点：<asp:TextBox ID="where" MaxLength="10" runat="server" Width="349px" ></asp:TextBox>
            <br />
        <br />
        活动时间：
        <%--日期--%>
        <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
        <ContentTemplate>
        <asp:TextBox ID="requestedDeliveryDateTextBox" Enabled="false" runat="server" Width="286px" />
        <asp:ImageButton id="imageButton"  Width="36px" runat="server" ImageUrl="~/File/timg.jpg" AlternateText="calendar" OnClick="ImageButton_Click" CausesValidation="false" Height="25px" />
        <br />
        <div id="calendar" class="calendar" visible="false" runat="server">
        <asp:Calendar ID="requestedDeliveryDateCalendar"  runat="server" OnSelectionChanged="RequestedDeliveryDateCalendar_SelectionChanged" />
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        备注：<asp:TextBox ID="tips" runat="server"  MaxLength="15" Height="33px" Width="379px" ></asp:TextBox>
            <br />
        <br />
        <asp:Button runat="server" Text="增加" ID="btnAdd" OnClick="btnAdd_Click" />

    </div>
    </form>
</body>
</html>
