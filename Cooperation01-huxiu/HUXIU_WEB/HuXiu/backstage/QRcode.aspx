<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QRcode.aspx.cs" Inherits="QRcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type ="text/javascript" src="Scripts/jquery-3.1.1.min.js" ></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img id="QRimg"  width="100" height="100" src="#" />
        <button onclick ="display();return false">test</button>
        <script type="text/javascript">
          //  alert(window.location.href);
            
            function display() {
                var str=window.location.href;
                var url="QRshare.ashx?str="+str;
                $("#QRimg").attr('src',url);
            };
            
     

        </script>
    </div>
    </form>
</body>
</html>
