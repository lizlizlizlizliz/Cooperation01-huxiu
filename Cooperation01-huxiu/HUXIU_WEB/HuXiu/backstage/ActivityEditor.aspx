<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ActivityEditor.aspx.cs" Inherits="ActivityEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
<%--    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/lang/zh-cn/zh-cn.js"></script>--%>
    <script src="webUploader/jquery-1.7.1.min.js"></script>
    <link href="webUploader/webuploader.css" rel="stylesheet" />
    <script src="webUploader/webuploader.nolog.js"></script>
    <script src="webUploader/fileUpload.js"></script>
<%--    <style type="text/css">
        div {
            width: 100%;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        活动标题：<asp:TextBox ID="title" runat="server" MaxLength="10" Enabled="false" Width="361px" ></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnEditor" runat="server" Text="编辑" OnClick="lbtnEditor_Click"></asp:LinkButton>
        <br />
        活动封面：
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
        活动内容：
        <br />
               <asp:TextBox ID="content"  runat="server" Enabled="false" TextMode="MultiLine" MaxLength="150" Height="166px" Width="458px" ></asp:TextBox>


        <br />


        <br />
        活动地点：<asp:TextBox ID="where" MaxLength="10" runat="server" Enabled="false" Width="353px" ></asp:TextBox>
        <br />
        <br />
        活动时间：<br />
        <asp:Label ID="when" runat="server" ></asp:Label>
        <%--日期--%>
        <asp:UpdatePanel ID="UpdatePanel1" Visible="false" runat="server">
        <ContentTemplate> 
        <asp:TextBox ID="requestedDeliveryDateTextBox" Enabled="false" MaxLength="45" runat="server" Width="288px" />
        <asp:ImageButton id="imageButton" runat="server" Width="36px" Height="25px" ImageUrl="~/File/timg.jpg" AlternateText="calendar" OnClick="ImageButton_Click" CausesValidation="false" />
        <br />
        <div id="calendar" class="calendar" visible="false" runat="server">
        <asp:Calendar ID="requestedDeliveryDateCalendar"  runat="server" OnSelectionChanged="RequestedDeliveryDateCalendar_SelectionChanged" />
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        备注：<asp:TextBox ID="tips" Enabled="false"  MaxLength="15" runat="server" Height="29px" Width="401px" ></asp:TextBox>
        <br />
        <br />
        <asp:Button runat="server" Visible="false" Text="修改" ID="btnEditor" OnClick="btnEditor_Click" />
    </div>
    </form>
</body>
</html>
