<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetActiveHeadline.aspx.cs" Inherits="SetActiveHeadline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>活动头条设置</h1>
        <asp:Repeater ID="rptActHead" runat ="server" OnItemCommand="rptActHead_ItemCommand">
            <ItemTemplate>
                 <div>
            <h3>
             标题： <asp:LinkButton ID="lkbOne" runat ="server" Text='<%# Eval("ActivityTitle") %>' PostBackUrl='<%# "ActivityEditor.aspx?id="+ Eval("ActivityId") %>'></asp:LinkButton>
            </h3>
                     
           <a href='<%# "ActivityEditor.aspx?id="+ Eval("ActivityId") %>'><img alt="点击查看详情" src='<%# Eval("ActivityImage") %>'  width="700" height="400"/></a>
            <asp:Button ID="btnEdit1" runat ="server" Text="修改"  CommandName="editHead"/>
            
                <h4><asp:Label ID="labID" Text ="ID:" runat ="server" Visible="false"  ></asp:Label><asp:TextBox ID="txtID" runat ="server"   Visible="false" MaxLength="10" TextMode="Number"></asp:TextBox></h4>
                  <h4><asp:Button ID="btnSub" runat ="server" Visible="false" Text="提交更改"  CommandName="SubChange" CommandArgument='<%# Eval("ActivityId") %>'/></h4>
          
          
        </div>
            </ItemTemplate>
        </asp:Repeater>
        <!--

       
         <div>
            <h3>
                头条二：<asp:LinkButton ID="lbkTwo" runat ="server" ></asp:LinkButton>
            </h3>
             <asp:Image ID="Image2" runat ="server" Width="700" Height="400" />
                <asp:Button ID="btnEdit2" runat ="server" Text="修改" />
               <div id="divEdit2" runat ="server" visible="false">
                <h4>ID:<asp:TextBox ID="txtID2" runat ="server" MaxLength="10" TextMode="Number"></asp:TextBox></h4>
            </div>
        </div>
         <div>
            <h3>
                头条三：<asp:LinkButton ID="lbkThree" runat ="server" ></asp:LinkButton>
            </h3>
             <asp:Image ID="Image3" runat ="server" Width="700" Height="400" />
                <asp:Button ID="btnEdit3" runat ="server" Text="修改" />
             <div id="divEdit3" runat ="server" visible="false">
                <h4>ID:<asp:TextBox ID="txtID3" runat ="server" MaxLength="10" TextMode="Number"></asp:TextBox></h4>
        
                </div>
          -->
            </div>
      
        
    </form>
</body>
</html>
