<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnimateHead.aspx.cs" Inherits="AnimateHead" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="animate/css/iview.css" type="text/css" />
    <link rel="stylesheet" href="animate/css/skin 5/style.css" type="text/css" />
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <script src="animate/scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="animate/scripts/jquery.easing.js"></script>
    <script src="animate/scripts/iview.js" type="text/javascript"></script>
    <%--  <style media="screen" type="text/css">   
     .DivRadius
        {        	        	
        	position:relative;
        	background:#ceddc0;
        	-moz-border-radius: 2px;
        	border-radius: 5px;        	
        	padding: .2em .2em; 
        	color: rgba(0,0,0, .8);
        	/*text-shadow: 0 1px 0 green;*/
        	line-height: 1;
        	margin: 0px auto;
        	box-shadow: 1px 1px 15px rgba(10,150,0,0.7);           
        	         	        	     
        }     
        </style>--%>
    <style media="screen" type="text/css">
        .DivRadius
        {
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#iview').iView({
                strips: 20,
                blockCols: 20,
                blockRows: 3,
                pauseTime: 7000,
                pauseOnHover: true,
                directionNavHoverOpacity: 0,
                timer: "Bar",
                timerDiameter: 120,
                timerPadding: 3,
                timerStroke: 4,
                timerBarStroke: 0,
                timerColor: "#0F0",
                timerPosition: "bottom-right"
            });
        });
    </script>
    <link rel="stylesheet" href="jquery-ui-1.10.1/demos/demos.css" />
</head>
<body class="BodyBackGroupColor">
    <form id="form1" runat="server">    
    <table style="width:950px;height:130px; background-image: url(Images/LoginTop2.jpg);" cellpadding="0" cellspacing="2">
        <tr>
            <td style="vertical-align: middle;" rowspan="2" class="style16">
                <%--<asp:Image ID="img" runat="server" ImageUrl="~/Images/logo.gif" Height="100px" Width="100px" />--%>
            </td>
            <td rowspan="2" style="width: 60px;">
            </td>
            <td style="text-align: left; vertical-align: top;">
                <%-- <asp:Label ID="lblSchoolName" runat="server" Font-Bold="True" Font-Italic="True"
                                        ForeColor="#9b0d0a" Font-Size="25px" Font-Names="Times New Roman" Style="font-size: 25px"></asp:Label>--%>
            </td>
            <td style="text-align: right; vertical-align: top; padding-right: 2px;">
                <asp:Label ID="lblShowLoginDetail" Width="180px" Font-Bold="true" CssClass="MyLabel"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;" colspan="2" align="right">
                <div class="DivRadius" style="width: 805px; text-align: center; float: right; padding-right: 1px;">
                    <div class="container" style="width: 805px">
                        <div id="iview" class="iview" style="margin: 0; padding: 0;">
                            <%=strImates%>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
