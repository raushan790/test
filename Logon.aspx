
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logon.aspx.cs" Inherits="logon" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="cache-control" content="no-cache">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>KBMTech, Dubai</title>
    <link rel="stylesheet" href="SchoolOnline/css/style.css" type="text/css" />
    <link rel="stylesheet" href="SchoolOnline/css/responsive.css" type="text/css" />
    <link rel="stylesheet" href="SchoolOnline/css/responsiveslides.css">
    <link rel="stylesheet" href="SchoolOnline/css/uniform.tp.css">
    <!--Script-->
    <script type="text/javascript" src="SchoolOnline/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="SchoolOnline/js/jquery-migrate-1.1.1.min.js"></script>
    <script type="text/javascript" src="SchoolOnline/js/jquery-ui-1.9.2.min.js"></script>
    <script type="text/javascript" src="SchoolOnline/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="SchoolOnline/js/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="SchoolOnline/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="SchoolOnline/js/custom.js"></script>
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <%@ Register TagName="ucFooter" TagPrefix="ucFooter" Src="~/SchoolOnline/uc/Footer.ascx" %>
    <script src="SchoolOnline/js/jquery-1.8.3.min.js"></script>
    <script src="SchoolOnline/js/responsiveslides.min.js"></script>
    <script type="text/javascript">
        // You can also use "$(window).load(function() {"
        $(function () {
            // Slideshow 
            $("#slider1").responsiveSlides({
                maxwidth: 2000,
                speed: 600
            });
        });
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#login').submit(function () {
                var u = jQuery('#username').val();
                var p = jQuery('#password').val();
                if (u == '' && p == '') {
                    jQuery('.login-alert').fadeIn();
                    return false;
                }
            });
        });
    </script>
    <script type="text/javascript">
        function fGetHashpwd() {
            try {

                if (document.getElementById('Login1_UserName').value == "") {
                    document.getElementById('Login1_UserName').style.border = '#e52213 solid 1px';
                    return false;
                } else {
                    document.getElementById('Login1_UserName').style.border = '';
                }
                if (document.getElementById('Login1_Password').value == "") {
                    document.getElementById('Login1_Password').style.border = '#e52213 solid 1px';
                    return false;
                }
                else {
                    document.getElementById('Login1_Password').style.border = '';
                }
                //if (document.getElementById('Login1_txtCapText').value == "") {
                //    document.getElementById('Login1_txtCapText').style.border = '#e52213 solid 1px';
                //    return false;
                //}
                //else {
                //    document.getElementById('Login1_txtCapText').style.border = '';
                //}
                var varSHAPwd = calcSHA1(document.getElementById('Login1_Password').value).toLowerCase();
                var varPwdSalt = varSHAPwd + document.getElementById('hid').value;
                document.getElementById('Login1_Password').value = calcSHA1(varPwdSalt.toLowerCase());

            }
            catch (ex) {
                return false;
            }
        }
        function Validate() {
            if (document.getElementById('UserName').value == "") {
                alert("Please Enter UserName");
            }
            if (document.getElementById('Password').value == "") {
                alert("Please Enter Password");
            }
        }
        function onClick(linkID, Position) {
            
            if (document.getElementById('hdncheck').value == Position || document.getElementById('hdncheck').value == '') {
                document.getElementById('Login1_FailureText').style.display = '';
            }
            else {
                document.getElementById('Login1_FailureText').style.display = 'none';
            }
            document.getElementById('Login1_UserName').value = '';
            document.getElementById('Login1_Password').value = '';
            //document.getElementById('Login1_txtCapText').value = '';
            document.getElementById('hdnFlag').value = Position;
            document.getElementById('hdncheck').value = Position;
            document.getElementById('txtPosition').value = linkID;
            document.getElementById('Login1_UserName').style.border = '';
            document.getElementById('Login1_Password').style.border = '';
           // document.getElementById('Login1_txtCapText').style.border = '';
            if (Position == '0') {
                document.getElementById('lblHeader').innerHTML = "Admin Login";
                document.getElementById('loginicon').src = "SchoolOnline/images/icons/admin.png";
                document.getElementById('Login1_lnkforget').style.display = 'none';

            }
            if (Position == '1') {
                document.getElementById('lblHeader').innerHTML = "Staff Login";
                document.getElementById('loginicon').src = "SchoolOnline/images/icons/staff-01.png";
                document.getElementById('Login1_lnkforget').style.display = 'none';


            }
            if (Position == '2') {
                document.getElementById('lblHeader').innerHTML = "Student Login";
                document.getElementById('loginicon').src = "SchoolOnline/images/icons/student-01.png";
                document.getElementById('Login1_lnkforget').style.display = '';


            }
            if (Position == "3") {
                document.getElementById('lblHeader').innerHTML = "Parents Login";
                document.getElementById('loginicon').src = "SchoolOnline/images/icons/family.png";
                document.getElementById('Login1_lnkforget').style.display = '';

            }
            if (Position == '6') {
                document.getElementById('lblHeader').innerHTML = "Already Registered Login";
                document.getElementById('loginicon').src = "SchoolOnline/images/icons/student-01.png";
                document.getElementById('Login1_lnkforget').style.display = 'none';

            }
            setTimeout(onDisplaylogon, 1000);
            setTimeout(onDisplaylogon, 500);
            // onDisplaylogon();
            return false;
        }
        function pShowReset() {
            var varClTime = new Date();
            if (window.showModalDialog) {
                window.showModalDialog("ResetPassword.aspx", "", "dialogWidth:540px;dialogHeight:350px;status=no;");
            }
            else {
                window.open("ResetPassword.aspx", "", "height=150px,width=450px,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes");
            }
            return false;
        }
    </script>
    <style type="text/css">
        .loginbutton
        {
            display: block;
            border: 1px solid #F30;
            padding: 10px;
            background: #fe7f19;
            width: 100%;
            color: #fff;
            text-transform: uppercase;
            float: left;
           
        }
        .loginbutton:hover
        {
            background: #F30;
        }
        .droplogon-box
        {
            width: 20%;
            float: left;
        }
        .circle
        {
            text-align: center;
            margin: 0px auto;
            border-radius: 70%;
            background-color: White;
            width: 174px;
            height: 145px;
            opacity: 0.8;
        }
        .logowidget
        {
            -moz-box-shadow: 1px 1px 8px rgba(0,0,0,0.3);
            -webkit-box-shadow: 1px 1px 8px rgba(0,0,0,0.3);
            box-shadow: 12px 10px 17px;
        }
        .schoolName {
             font-size:30px !important; font-family: Times New Roman; color:#287249;
        }
        .schoolNamesmall{
         font-size:25px !important; font-family: Times New Roman; color:#287249;
        }
        @media screen and (max-width:380px) {

            .schoolName {
                font-size: 25px !important;
                font-family: Times New Roman;
                color: #287249;
            }

            .schoolNamesmall {
                font-size: 15px !important;
                font-family: Times New Roman;
                color: #287249;
                display: none;
            }
        }

    </style>
</head>
<body class="loginpage">
    <form id="form1" runat="server">
    <div class="row-fluid">
        <div class="image-gallery box-shadow" style="opacity: 0.5">
            <ul class="rslides" id="slider1">
                <li>
                    <img src="images/kbmheader.png"></li>
            </ul>
        </div>
        <!--banner end-->
        <div class="main-login-logo">
            <p class="circle logowidget" style="background-image: url('./Images/logo.jpg'); background-repeat: no-repeat;
                background-position: center center;">
                <%--   <img src="../../Images/logo.jpg" width="168px" alt="" />--%>
            </p>
            <span class="text-center">
                 <h4 class="text_shadow bold-txt schoolName" >
                    <%--  <img src="images/thehdfc.png" style=" height:35px;" alt="" />--%>
                   KBMTech, Dubai
                </h4>
            </span>
        </div>
    </div>
    <div class="clearfix">
        <br>
    </div>
    <div class="login-side">
        <!----AdminLogin---->
        <div class="login-cnt">
            <asp:LinkButton ID="lnkbtnAdmin" runat="server" OnClientClick="onClick('lnkbtnAdmin',0);"
                class="popup-btn" href="#myModal" data-toggle="modal"> <%--<a class=" popup-btn" href="#myModal" data-toggle="modal">--%><div class="login-inner img-shadow">
		<div class=" logincnt"> 
			<div class="login-title">
			<p class="focused-view-subtitle uppercase text-center border-center btn-space">
			<span> Admin </span></p></div><div class="text-center">
			<span class="login-image"> <img src="SchoolOnline/images/icons/admin.png" ></span> </div></div></div></asp:LinkButton>
            <%-- </a>--%>
            <!--popup box starts-->
            <!--popup box ends-->
        </div>
        <!---EndAdminLogin----->
        <!---StaffLogin---->
        <div class="login-cnt" style="display:none;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="onClick('LinkButton1',1);"
                class="popup-btn " href="#myModal" data-toggle="modal"> <div class="login-inner img-shadow">
                    <div class=" logincnt">
                        <div class="login-title">
                            <p class="focused-view-subtitle uppercase text-center border-center btn-space">
                                <span>Staff</span> </p></div><div class="text-center">
                            <span class="login-image">
                                <img src="SchoolOnline/images/icons/staff-01.png"></span> </div></div></div></asp:LinkButton>
            <!--popup box starts-->
            <!--popup box ends-->
        </div>
        <!----EndStafflogin--->
        <!---ParentLogin---->
        <div class="login-cnt" style="display:none;">
            <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="onClick('LinkButton2',3);"
                class=" popup-btn " href="#myModal" data-toggle="modal"> <div class="login-inner img-shadow">
                    <div class=" logincnt">
                        <div class="login-title">
                            <p class="focused-view-subtitle uppercase text-center border-center btn-space">
                                <span>Parents </span></p></div><div class="text-center">
                            <span class="login-image">
                                <img src="SchoolOnline/images/icons/family.png"></span> </div></div></div></asp:LinkButton>
            <!--popup box starts-->
            <!--popup box ends-->
        </div>
        <!---ParentLogin---->
        <!---StudentLogin-->
        <div class="login-cnt" style="display:none;">
            <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="onClick('LinkButton3',2);"
                class=" popup-btn " href="#myModal" data-toggle="modal"> <div class="login-inner img-shadow">
                    <div class=" logincnt">
                        <div class="login-title">
                            <p class="focused-view-subtitle uppercase text-center border-center btn-space">
                                <span>Student</span> </p></div><div class="text-center">
                            <span class="login-image">
                                <img src="SchoolOnline/images/icons/student-01.png"></span> </div></div></div></asp:LinkButton>
            <!--popup box starts-->
            <!--popup box ends-->
        </div>
        <asp:Login ID="Login1" runat="server" FailureText="Invalid User Name or Password"
            Width="100%" OnAuthenticate="Login1_Authenticate">
            <FailureTextStyle CssClass="forgot" />
            <LayoutTemplate>
                <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1"
                    class="modal hide fade in" id="myModal">
                    <div class="modal-header">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                            ×</button>
                        <h4 id="myModalLabel">
                            <asp:Label ID="lblHeader"></asp:Label>
                        </h4>
                    </div>
                    <div class="modal-body" style="background: #ccc;">
                        <div style="width: 40%; float: left">
                            <span>
                                <img id="loginicon"></span>
                        </div>
                        <div style="width: 60%; float: left">
                            <div class="inputwrapper login-alert">
                                <div class="alert alert-error">
                                </div>
                            </div>
                            <div class="inputwrapper animate3 ">
                                <asp:TextBox ID="UserName" runat="server" TabIndex="1" type="text" class="full-width"
                                    name="username" placeholder="enter username"></asp:TextBox>
                            </div>
                            <div class="inputwrapper animate3 ">
                                <asp:TextBox ID="Password" runat="server" type="password" TabIndex="2" class="full-width"
                                    name="password" placeholder="enter password"></asp:TextBox>
                            </div>
                            <div style="padding-bottom: 10px;">
                                <asp:DropDownList Visible="false" ID="ddlAcademicYear" runat="server" Width="157px" CssClass="TxtBox"
                                    AutoPostBack="false">
                                </asp:DropDownList>
                            </div>
                            <div class="inputwrapper animate3 ">
                                <div style="float: left; width: 160px;">
                                    <asp:TextBox Visible="false" ID="txtCapText" Text="gfhdhdg" CssClass="select" runat="server" type="text" TabIndex="3"
                                        Style="width: 138px;" name="captcha" placeholder="Enter Captcha"></asp:TextBox>
                                </div>
                                <div style="float: left;">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <cc1:CaptchaControl Visible="false" ID="ccJoin" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="6"
                                                CaptchaHeight="40" CaptchaWidth="200" CaptchaLineNoise="none" CaptchaMinTimeout="5"
                                                CaptchaMaxTimeout="240" Width="158px" FontColor="Black" BackColor="#CCCCCC" />
                                            <asp:LinkButton Visible="false" ID="imgRefresh" runat="server" TabIndex="5" OnClick="imgRefresh_Click1"
                                                Style="font-size: small; float: right;">Refresh Code</asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="animate3">
                                <%--<button onclick="return LogIN()">Sign In--%>
                                <%--<asp:LinkButton ID="loginButton" runat="server" CommandName="Login" ValidationGroup="Login1"
                    TabIndex="4" class="white-text " OnClientClick="javascript:return fGetHashpwd();"></asp:LinkButton>--%>
                                <asp:Button ID="loginButton" runat="server" CommandName="Login" Text="Sign In" ValidationGroup="Login1"
                                    Style="min-width: 205px;" TabIndex="4" class="loginbutton" OnClientClick="javascript:return fGetHashpwd();">
                                </asp:Button><%--OnClientClick="javascript:return fGetHashpwd();"--%>
                                <%-- </button>--%>
                            </div>
                            <div class="inputwrapper animate4">
                                <label class="txt-black">
                                    <asp:LinkButton ID="lnkforget" runat="server" OnClientClick="javascript:return pShowReset();">Forgot your password?</asp:LinkButton>
                                </label>
                            </div>
                            <div class="inputwrapper animate4">
                                <br />
                                <label class="error">
                                    <asp:Label ID="FailureText" ForeColor="Red" Text="" runat="server"></asp:Label></label>
                            </div>
                        </div>
                    </div>
                </div>
            </LayoutTemplate>
        </asp:Login>
        <!----hiddenfields---->
        <input id="hid" runat="server" name="hid" type="hidden" />
        <input id="hidBrsr" runat="server" name="hidBrsr" type="hidden" />
        <asp:HiddenField ID="hdnFlag" runat="server" />
        <asp:HiddenField ID="hdncheck" runat="server" />
        <asp:TextBox ID="txtCapText" Text="jbjbds"  runat="server" Width="150px" TabIndex="3" CssClass="TxtBox"
            Visible="false"></asp:TextBox>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!---hiddern fieldsend---->
    </div>
    <!---endStudentlogin--->

         <!--footer starts-->
    <ucFooter:ucFooter ID="ucFooter" runat="server" />
    <!--Footer End--->
    <%--<div class="loginfooter edit-profile-right margin-top">
        <p>
            &copy; 2015 Entab. All Rights Reserved.</p>
    </div>--%>




    <div style="display: none;">
        <asp:TextBox ID="txtPosition" runat="server"></asp:TextBox>
    </div>
    </form>
    <script>
        function onDisplaylogon() {
            document.getElementById('Login1_UserName').focus();
            return false;
        }
    </script>
</body>
</html>
