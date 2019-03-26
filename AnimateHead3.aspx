<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnimateHead3.aspx.cs" Inherits="AnimateHead3" %>

<%@ Register Src="~/SchoolOnline/uc/Footer.ascx" TagName="ucfooter" TagPrefix="ucfooter" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head>
     
     <link rel="stylesheet" href="SchoolOnline/css/responsiveslides.css">
    <script src="SchoolOnline/js/jquery-1.8.3.min.js"></script>
    <script src="SchoolOnline/js/responsiveslides.min.js"></script>
    <script type="text/javascript"> 
        $(function () { 
            $("#slider1").responsiveSlides({
                maxwidth: 2000,
                speed: 600
            });
        });
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
<body style="margin:0;padding:0;">
    <form id="form1" runat="server">
            <ul id="slider1">
                <li>
                    <img src="SchoolOnline/images/slider/banner-01.jpg"></li>
                <li>
                    <img src="SchoolOnline/images/slider/banner-02.jpg"></li> 
            </ul>  
    </form> 
</body>
</html>
