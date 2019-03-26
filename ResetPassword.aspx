<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc11" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <base target="_self"></base>
    <title>:: InnoSoft® Online :: - Password Reset</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        jQuery(function ($) {
            $("#txtDOB").mask("99/99/9999");

        });
        function Checking() {
            if (stripBlanks(document.getElementById('txtFirstName').value) == "") {
                alert("Please Enter First Name of the Child");
                document.getElementById('txtFirstName').focus();
                return false;
            }
            //        if(stripBlanks(document.getElementById('txtFirstName').value)!="")
            //            {  
            //               if(validateEmail(document.getElementById('txtFirstName').value)==false)
            //                {   
            //  //                  alert("Please Enter Valid Email");
            //                    document.getElementById('txtFirstName').focus();
            //                    return false;
            //                 }
            //            }
            if (stripBlanks(document.getElementById('txtMobileNo').value) == "") {
                alert("Please Enter Mobile No.");
                document.getElementById('txtMobileNo').focus();
                return false;
            }

            if (stripBlanks(document.getElementById('txtMobileNo').value) != "") {//debugger;
                var Arr = document.getElementById('txtMobileNo').value.split(',');
                for (var inti = 0; inti < Arr.length; inti++) {
                    if ((Arr[inti].length) < 10 || Arr[inti].length > 10) {
                        alert("Please Enter 10 digit Mobile No");
                        document.getElementById('txtMobileNo').focus();
                        return false;
                    }
                }
            }
            if (stripBlanks(document.getElementById('txtDOB').value) == "") {
                alert("Please Enter Date of Birth of the Child");
                document.getElementById('txtDOB').focus();
                return false;
            }
            if (!validateDate(document.getElementById('txtDOB').value)) {
                alert("Please Enter Valid Date");
                document.getElementById('txtDOB').focus();
                return false;
            }
            if (stripBlanks(document.getElementById('txtCapText').value) == "") {
                alert("Please Enter the Code...");
                document.getElementById('txtCapText').focus();
                return false;
            }
        }
        function pCancel() {
            document.getElementById('txtFirstName').value = "";
            document.getElementById('txtMobileNo').value = "";
            document.getElementById('txtDOB').value = "";
            return false;
        }
        function Close() {
            window.close();
        }
    </script>
</head>
<body style="background-image: url(Images/backgroundImg.jpg); background-repeat: repeat;
    background-position: center center; background-attachment: scroll;">
    <form id="frmResetPassword" runat="server">
    <div align="center">
        <table>
            <tr>
                <td class="divCircle">
                    <table class="MyTableBorder">
                        <tr>
                            <td align="center" class="MyTableHeader" colspan="3" style="height: 17px">
                                Reset Password
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lbl" runat="server">First&nbsp;Name&nbsp;of&nbsp;Child</asp:Label><span
                                    style="color: red"></span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="MyTextBox" Width="200px"
                                    MaxLength="50" TabIndex="1"></asp:TextBox>
                            </td>
                            <td align="center" rowspan="3" valign="top">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnReset" runat="server" CssClass="MyButton" Text="Reset" OnClientClick="javascript:return Checking();"
                                                TabIndex="5" OnClick="btnReset_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" CssClass="MyButton" Text="Cancel" OnClientClick="javascript:return pCancel();"
                                                TabIndex="6" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnClose" runat="server" CssClass="MyButton" Text="Close" OnClientClick="javascript:return Close();"
                                                TabIndex="7" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="trClass">
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblClassMasterName2" runat="server" Width="80px">Mobile No.</asp:Label><span
                                    style="color: #ff0000"></span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="MyTextBox" MaxLength="10"
                                    TabIndex="2" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblClassMasterPriority" runat="server">Date&nbsp;of&nbsp;Birth&nbsp;of&nbsp;Child</asp:Label>
                            </td>
                            <td align="left">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass="MyTextBox" MaxLength="50" TabIndex="3"
                                                Width="100px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgDOBDate" runat="server" CssClass="CalendarImage" Height="15px"
                                                ImageUrl="~/Images/calendar1.jpg" OnClientClick="javascript:return false;" Width="20px"
                                                TabIndex="4" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                Reset Password for
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="text-align: left;" valign="top" >
                                <asp:RadioButton ID="rbtnReg" runat="server"  CssClass="MyLabel" GroupName="a"
                                    Text="Registration" Visible="false" />&nbsp;
                                <asp:RadioButton ID="rbtnParentlogin" runat="server" Checked="True" CssClass="MyLabel" GroupName="a"
                                    Text="Parent" />&nbsp;
                                <asp:RadioButton ID="rbtnStudentlogin" runat="server" CssClass="MyLabel" GroupName="a"
                                    Text="Student" />
                            </td>
                            <td style="text-align: left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2" rowspan="1" valign="top">
                                <cc11:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="low" CaptchaLength="6"
                                    CaptchaHeight="40" CaptchaWidth="200" CaptchaLineNoise="none" CaptchaMinTimeout="5"
                                    CaptchaMaxTimeout="240" Width="200" FontColor="#B54539" BackColor="#FAD08A" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                Enter Code
                            </td>
                            <td align="center" colspan="2" style="text-align: left" valign="top">
                                <asp:TextBox ID="txtCapText" runat="server" Width="164px" TabIndex="113" MaxLength="70"
                                    Style="text-transform: uppercase;" CssClass="MyLabel" ToolTip="Enter Name"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" colspan="3">
                                <asp:Label ID="lblCode" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#FF3300"
                                    Width="100%" Style="text-align: center"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" colspan="3">
                                <strong></strong>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: right" class="MyLabel">
                    <span style="color: #990000">* All fields are&nbsp; mandatory.
                        <br />
                        * Your UserID and Password will be send on your Registered Mobile No.</span>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hidFlag" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendarStyle"
        Format="dd/MM/yyyy" PopupButtonID="imgDOBDate" TargetControlID="txtDOB">
    </cc1:CalendarExtender>
    </form>
</body>
</html>
