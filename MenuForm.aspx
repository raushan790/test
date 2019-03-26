<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuForm.aspx.cs" Inherits="MenuForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="margin:0;" >
<head runat="server">
    <title>Untitled Page</title>
        <link rel="Stylesheet" href="TableTemplates.css" type="text/css" />

    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <link href="CSS/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language='javascript'>
        document.oncontextmenu=function()
        {
        //alert('Right Click Is Not Allowed'); 
        return false;
        };
    </script>
</head>
<body style="margin-left:0px; background-image:url(Images/backgroundImg.jpg); background-repeat :repeat ; background-position: center center; background-attachment: scroll; background-color: #EFEFEF;margin-right:0px;margin-bottom:0px;margin-top:0px;">
    <form id="form1" runat="server" >
    <div style="width:100%" align="left">
<%--        <asp:Menu ID="menuBar" runat="server" Orientation="Horizontal" Width="100%" 
                CssClass="MenuBar" MaximumDynamicDisplayLevels="2">
                <StaticMenuStyle CssClass="StaticMenuItem" />                
                <StaticMenuItemStyle CssClass="StaticMenuItemStyle" />
                <StaticHoverStyle CssClass="StaticHoverStyle" />  
                <StaticSelectedStyle CssClass="StaticSelectedStyle" />              
                <DynamicMenuItemStyle CssClass="DynamicMenuItemStyle" />
                <DynamicHoverStyle CssClass="DynamicHoverStyle" />
            </asp:Menu>--%>
       <table width="100%" border="0" >
      <tr width="100%">
        <td width="100%" height="17" align="center" bgcolor="#487EB2" class="style8" background="Images/orange_bg.gif" >M E N U</td>
      </tr>
      <tr width="100%">
      <td bgcolor="#EFEFEF" align="left" width="100%" >

        <table width="100%" border="0" >

      <tr width="100%">
      <td bgcolor="#EFEFEF" align="left" width="100%" >
     <asp:TreeView ID="trvMenu" runat="server" ShowLines="True" ExpandDepth="0" BackColor="#dcdcda" NodeIndent="10" Width="100%">
            <HoverNodeStyle ForeColor="SaddleBrown" BackColor="Goldenrod" Font-Bold="True" />
            <LeafNodeStyle ImageUrl="~/Images/circle.JPG"  BackColor="#f3f1ee" CssClass="style5" BorderColor="#f3f1ee" VerticalPadding="1px" />
            <NodeStyle ImageUrl="~/Images/arrow.JPG" BackColor="#f3f1ee" BorderColor="#f3f1ee" VerticalPadding="1px" Width="100%" />
          <ParentNodeStyle CssClass="style6" NodeSpacing="1px" ForeColor="DimGray" />
          <RootNodeStyle CssClass="style6" ForeColor="DimGray" />
        </asp:TreeView>       
        
      </td>
      </tr>
      </table>
        </td>
          </tr></table>
        
      </div>                  
    
    </form>
</body>
</html>
