<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Wait.aspx.cs" Inherits="Wait" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script   type="text/javascript" >
//         function pIncreaseDot() {
//             if (document.getElementById('lblDot').innerHTML.length <= 60)
//                 document.getElementById('lblDot').innerHTML = document.getElementById('lblDot').innerHTML + ".";
//             else
//                 document.getElementById('lblDot').innerHTML = "Please wait while we are preparing your dashboard ";
//         }
//         window.setInterval(pIncreaseDot, 100);
        </script>
    <style type="text/css">
        .style1
        {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div  style="padding-left:300px">
        <strong><span class="style1">Please wait while we are preparing your dashBoard</span>
        </strong>&nbsp;&nbsp;
        <asp:Image ID="Image1" runat="server" Height="16px" 
            ImageUrl="~/Images/remembermilk_orange.gif" Width="19px" />
            
    </div>
    </form>
</body>
</html>
