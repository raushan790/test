<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MTConfirmPassword.aspx.cs" Inherits="MTConfirmPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="CSS/MyStyle.css" type="text/css" rel="stylesheet" />
    <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <link href="CSS/styleasn.css" rel="stylesheet" media="all" type="text/css" />
    <script type="text/javascript" src="Scripts/shadedborder.js"></script>

     <style type="text/css"> 
        /* For the first shadowed border container */     
             
      
        
         #shadowed-border {padding:1px; width:60%; margin:1px auto; color:#fff;}
        #shadowed-border, #shadowed-border .sb-inner { background:#fff url(Images/j1.jpg) repeat-x; }
     
    </style>
    <script language ="javascript" type="text/javascript">
         var shadowedBorder    = RUZEE.ShadedBorder.create({ corner:8, shadow:16 });  

        function Validate_ChangePassword()
        {
            if( document.frmMTConfirmPassword.txtPassword.value=='')
                {
//                    alert('Please Enter Your Password.');
                    pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblPassword').innerHTML);                
                    document.frmMTConfirmPassword.txtPassword.focus();                   
                    return false;
                }        
                     
              return true;
        }
        function colorchange(ctl)
        {        
          ctl.style.backgroundColor='White';
             return true;
        }        

        
    </script>
</head>
<body style="background-image:url(Images/backgroundImg.jpg); background-repeat :repeat ; background-position: center center; background-attachment: scroll;" dir="<%=strType %>"><%--style="  text-align :center; vertical-align:sub;background-color:#ABC5ff;"--%>
<form id="frmMTConfirmPassword" runat="server" dir="<%=strType %>">
    <div id="divMain" align="center" >
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div style="width:40%;" class="divCircle">
    <table id="tblMain" style="width:100%;"  class="MyTableBorder" cellpadding="0" cellspacing="0"  >
    <tr><td  style="height:86px" align="center">
        
        <table>
            <tr>
                <td class="heading" colspan="2" align="center" style="height:30px"> 
                    <asp:Label ID="lblConfirmPassword" runat="server" CssClass="MyLabelHeader" Text="Please Confirm Your Password"></asp:Label></td>
            </tr>
            <tr>
                <td class="heading" colspan="2" align="center" > 
                    </td>
            </tr>
            <tr>
                <td  align="center" style="height:30px">
                    <asp:Label ID="lblPassword" runat="server"  Text="Password"  ></asp:Label></td>
                
                <td align="center" style="height:30px">
                    <asp:TextBox ID="txtPassword" runat="server"   TextMode="Password" CssClass="MyTextBox" MaxLength="350" TabIndex="1"></asp:TextBox>
                    <asp:TextBox ID="txtTemp" runat="server"  CssClass="MyTextBox" MaxLength="15" style="display:none;"
                       
                        TabIndex="1" TextMode="Password" ></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td align="center" class="name">
                    </td>
                <td align="center" >
                    </td>
            </tr>
            <tr>
                <td align="center" colspan="2" >
                    <asp:Button ID="btnOK" runat="server"  OnClientClick ="return Validate_ChangePassword();"
                        Text="OK" OnClick="btnOK_Click" CssClass="MyButton" TabIndex="2" />
                    <asp:Button ID="btnClose" runat="server"  CausesValidation="False"
                        Text="Close" OnClick="btnClose_Click" CssClass="MyButton" TabIndex="3" /></td>
            </tr>
        </table>
        </td>
    </tr>
    </table>
    </div>
    </div>
    
    </form>
</body>
</html>