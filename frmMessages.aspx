<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMessages.aspx.cs" Inherits="frmMessages"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: CampusCare Online::-News Master</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="Scripts/jsSpecialCharacterValidation.js"></script>
    <script language="javascript" src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">


        jQuery(function ($) {
            $("#txtNewsDate").mask("99/99/9999");
            $("#txtmessageTillDate").mask("99/99/9999");
        });

        //OnSelectedIndexChanged="gvMessages_SelectedIndexChanged"
        var curSelRow = null;
        addLoadEvent(pEnableDisable);
        function addLoadEvent(func) {
            var oldonload = window.onload;
            if (typeof window.onload != 'function') {
                window.onload = func;
            }
            else {
                window.onload = function () {
                    if (oldonload) {
                        oldonload();
                    }
                    func();
                }
            }
        }

        function pEnableDisable() {
            document.getElementById('lnkShowAttachment').style.display = 'none';
            document.getElementById('btnGridBind').style.display = 'none';
            document.getElementById('btndblClick').style.display = 'none';
            if (document.getElementById('hidMessage').value != "") {
                document.getElementById('lnkShowAttachment').style.display = "";
            }
            if (document.getElementById("gvMessages") != null)
                if (document.getElementById("gvMessages").rows.length > 1)
                    for (var i = 0; i < document.getElementById("gvMessages").rows.length; i++) {
                        document.getElementById('gvMessages').rows[i].cells[1].style.display = 'none';
                        document.getElementById('gvMessages').rows[i].cells[5].style.display = 'none';
                    }
            ////////            if(document.getElementById('gvMessages')!=null)
            ////////                FreezeGridViewHeader('gvMessages','pnlMessages');
            ////////            if(document.getElementById('gvStudentList')!=null)
            ////////                FreezeGridViewHeader('gvStudentList','pnlStudentList');
            ////////            if(document.getElementById('gvEmployeeList')!=null)
            ////////                FreezeGridViewHeader('gvEmployeeList','pnlEmployee');
            ////////                
            // ReplaceSpecialcharacterToNormal('frmMessage');

            document.getElementById('txtNewsDate').focus();
            fChangeButtonColor('frmMessage', '#400000');

        }
        function Assign_New() {
            if (UserLimit('N') == false) {
                return false;
            }
            //OnSelectedIndexChanged="gvMessages_SelectedIndexChanged"
            //            document.getElementById('btnNew').disabled=true;
            //            document.getElementById('btnEdit').disabled=true;
            //            document.getElementById('btnDelete').disabled=true;
            //            document.getElementById('btnSave').disabled=false;
            //            document.getElementById('ddlUserType').disabled=false;
            //            document.getElementById('hidEditNew').value='N~N';
            //            document.getElementById('hidLoad').value="N";
            //            document.getElementById('txtMessageTitle').value='';
            //            document.getElementById('txtMessageTitle').readOnly=false;
            //            document.getElementById('txtMessageTitle').focus();
            //            document.getElementById('txtMessage').value='';
            //            document.getElementById('txtMessage').readOnly=false;
            //            document.getElementById('ddlStatus').disabled=false;
            //            return false;
            document.getElementById('txtNewsDate').focus();
            fChangeButtonColor('frmMessage', '#400000');
            return true;
        }
        function Assign_Edit() {
            if (UserLimit('E') == false) {
                return false;
            }

            //            document.getElementById('btnEdit').disabled=true;
            //            document.getElementById('btnDelete').disabled=true;
            //            document.getElementById('ddlUserType').disabled=true;
            //            document.getElementById('btnSave').disabled=false;
            //            document.getElementById('btnNew').disabled=true;
            //            document.getElementById('txtMessageTitle').readOnly=false;
            //            document.getElementById('txtMessage').readOnly=false;
            //            document.getElementById('ddlStatus').disabled=false;
            //            if(document.getElementById('tblStudent')!=null)
            //            {
            //                document.getElementById('ddlCourse').disabled=false;
            //                document.getElementById('ddlBatch').disabled=false;
            //                
            //            }
            //            //tblEmployee
            //            if(document.getElementById('tblEmployee')!=null)
            //            {
            //                document.getElementById('ddlDesignation').disabled=false;
            //               
            //            }
            //            return false;
            document.getElementById('txtNewsDate').focus();
            //ReplaceSpecialcharacter('frmMessage');
            fChangeButtonColor('frmMessage', '#400000');
        }

        function Change_SelectedRow(varRowIndex) {
            var strArray = document.getElementById('hidEditNew').value.split('~');
            if (varRowIndex > -1 && strArray[0] != 'N') {
                if (curSelRow != null) {
                    if (curSelRowIndex % 2 == 0)
                        curSelRow.style.cssText = "font-weight: normal; background: #fff;"
                    else
                        curSelRow.style.cssText = "font-weight: normal;"
                }
                document.getElementById('gvMessages').rows[varRowIndex + 1].style.cssText = "color: green; font-weight: bold; cursor: pointer;  background: #ffc0cb;"


                curSelRow = document.getElementById("gvMessages").rows[varRowIndex + 1];
                //                document.getElementById('txtMessageTitle').value=document.getElementById("gvMessages").rows[varRowIndex+1].cells[2].firstChild.nodeValue;
                //                document.getElementById('txtMessage').value=document.getElementById("gvMessages").rows[varRowIndex+1].cells[3].firstChild.nodeValue;
                //                document.getElementById('ddlStatus').value=document.getElementById("gvMessages").rows[varRowIndex+1].cells[5].firstChild.nodeValue;
                //                document.getElementById('btnEdit').disabled=false;
                //                document.getElementById('btnDelete').disabled=false;
                //                document.getElementById('btnNew').disabled=true;
                //                document.getElementById('btnSave').disabled=true
                //                document.getElementById('txtMessageTitle').readOnly=true;
                //                document.getElementById('txtMessage').readOnly=true;
                //                document.getElementById('ddlStatus').disabled=true;
                //                document.getElementById('ddlUserType').disabled=true;
                document.getElementById('hidEditNew').value = 'E~' + String(varRowIndex);
                document.getElementById('lnkShowAttachment').style.display = "";
                //ReplaceSpecialcharacter('frmMessage');
                fChangeButtonColor('frmMessage', '#400000');
                document.getElementById('btndblClick').click();

            }
        }

        function Validate_On_Save() {

            if (document.getElementById('txtNewsDate').value == '') {
                alert("Please Enter From Date");
                document.getElementById('txtNewsDate').focus();
                return false;
            }
            if (document.getElementById('txtNewsDate').value != '') {
                if (!validateDate(document.getElementById('txtNewsDate').value)) {
                    alert('Please Enter The Valid Date[Date Format dd/MM/yyyy]');
                    document.getElementById('txtNewsDate').value = "";
                    document.getElementById('txtNewsDate').focus();
                    return false;
                }
            }
            if (document.getElementById('txtmessageTillDate').value == '') {
                alert("Please Enter To Date");
                document.getElementById('txtmessageTillDate').focus();
                return false;
            }

            if (document.getElementById('txtmessageTillDate').value != '') {
                if (!validateDate(document.getElementById('txtmessageTillDate').value)) {
                    alert('Please Enter The Valid Date[Date Format dd/MM/yyyy]');
                    document.getElementById('txtmessageTillDate').value = "";
                    document.getElementById('txtmessageTillDate').focus();
                    return false;
                }
            }
            if (CompareDate(document.getElementById('txtNewsDate').value, document.getElementById('txtmessageTillDate').value) == 2)
            //if ((document.getElementById('txtNewsDate').value)>(document.getElementById('txtmessageTillDate').value))
            {
                alert(' From Date Should be lesser than ToDate');
                document.getElementById('txtNewsDate').focus();
                return false;
            }
            if (document.getElementById('txtMessageTitle').value == '') {
                alert("Please Enter News Title");
                document.getElementById('txtMessageTitle').focus();
                return false;
            }
            if (document.getElementById('txtMessage').value == '') {
                alert("Please Enter News");
                document.getElementById('txtMessage').focus();
                return false;
            }


            if (document.getElementById('ddlUserType').value == 'S' && document.getElementById('ddlBatch').value != "0") {
                var Check = "S";
                for (var i = 1; i < document.getElementById('gvStudentList').rows.length; i++) {
                    if (document.getElementById('gvStudentList').getElementsByTagName('TR')[i].getElementsByTagName('input')[0].checked == true) {
                        Check = 'Y';
                    }
                }
                if (Check == 'S') {
                    alert('Please Select Any One Student');
                    return false;
                }
            }
            if (document.getElementById('ddlUserType').value == 'E') {
                var Check = "S";
                for (var i = 1; i < document.getElementById('gvEmployeeList').rows.length; i++) {
                    if (document.getElementById('gvEmployeeList').getElementsByTagName('TR')[i].getElementsByTagName('input')[0].checked == true) {
                        Check = 'Y';
                    }
                }
                if (Check == 'S') {
                    alert('Please Select Any One Employee');
                    return false;
                }
            }
             if (document.getElementById('flUploadAttachment').value != '') {
         var CheckFormat = document.getElementById('flUploadAttachment').value.split('.');
            if (CheckFormat[CheckFormat.length - 1].toLowerCase() == 'JPG' || CheckFormat[CheckFormat.length - 1].toLowerCase() == 'jpeg' || CheckFormat[CheckFormat.length - 1].toLowerCase() == 'jpg' || CheckFormat[CheckFormat.length - 1].toLowerCase() == 'pdf') 
            { 
             return true;
            }
            else
            {
//            pDisplayMessageclient("<%=Session["Type"].ToString() %>","16",""); 
                //            return false;
                alert("Only PDF/JPG files.");
                return false;
            }   
     }

        }

        function Validate_On_Delete() {
            if (UserLimit('D') == false) {

                return false;
            }
            if (confirm("Do You Want To Delete?")) {
                //ReplaceSpecialcharacter('frmMessage');  
                return true;
            }
            else {
                //ReplaceSpecialcharacterToNormal('frmMessage');  
                return false;
            }
        }

        function UserLimit(Val) {
            if (Val == "N") {
                var strNew = document.getElementById('hidCache').value.split(';')[0];
                if (strNew != "Y") {
                    alert("You Don't Have Permission To Create");
                    return false;
                }
            }
            else if (Val == "E") {
                var strEdit = document.getElementById('hidCache').value.split(';')[1];
                if (strEdit != "Y") {
                    alert("You Don't Have Permission To Edit");
                    return false;
                }
            }
            else if (Val == "D") {
                var strEdit = document.getElementById('hidCache').value.split(';')[2];
                if (strEdit != "Y") {
                    alert("You Don't Have Permission To Delete");
                    return false;
                }
            }

        }

        //     function PrintGrid(strid)
        //     {
        //        var prtContent = document.getElementById(strid);
        //       var WinPrint =  window.open('','','left=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
        //      // var WinPrint =  window.open('','');
        //        WinPrint.document.write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+"S U B J E C T &nbsp; D E T A I L S");
        //        WinPrint.document.write(prtContent.innerHTML);
        //        WinPrint.document.close();
        //        WinPrint.focus();
        //        WinPrint.print();
        //        WinPrint.close();
        //        //prtContent.innerHTML=strOldOne;
        //        return false;
        //     }
        function Restrict_Message(e) {
            if (document.getElementById('txtMessage').value.length > 250)
                return false;
            var varKey;
            if (window.event)
                varKey = window.event.keyCode;
            else
                varKey = e.which;
            if (varKey >= 32 && varKey <= 93 || varKey >= 97 && varKey <= 122 || varKey == 8)
                return true;
            else
                return false;
        }
        //**************************Httprequest Start

        var XmlHttp;
        //Creating and setting the instance of appropriate XMLHTTP Request object to a “XmlHttp” variable  
        function CreateXmlHttp() {
            //Creating object of XMLHTTP in IE
            try {
                XmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
            }
            catch (e) {
                try {
                    XmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                catch (oc) {
                    XmlHttp = null;
                }
            }
            //Creating object of XMLHTTP in Mozilla and Safari 
            if (!XmlHttp && typeof XMLHttpRequest != "undefined") {
                XmlHttp = new XMLHttpRequest();
            }
        }

        //*********************Fill Batch DDL****************      
        function FillBatch() {

            var da3 = new Date();

            var requestUrl = "frmHttpRequestSenthil.aspx?TypeID=" + encodeURIComponent(document.getElementById('ddlCourse').value + '~' + da3.getTime()) + "&TypeName=FillBatchMessage";
            CreateXmlHttp();

            if (XmlHttp) {
                XmlHttp.onreadystatechange = HandleTimeSlotResponse;
                XmlHttp.open("GET", requestUrl, true);
                XmlHttp.send(null);
            }
            return false;
        }

        function HandleTimeSlotResponse() {
            if (XmlHttp.readyState == 4) {
                if (XmlHttp.status == 200) {
                    HandleTimeSlotResponse(XmlHttp.responseText);
                    //ClearAndSetCityListItems(XmlHttp.responseXML.documentElement);
                }
                else {
                    alert("There was a problem retrieving data from the server.");
                }
            }
        }

        function HandleTimeSlotResponse() {
            if (XmlHttp.readyState == 4) {
                if (XmlHttp.status == 200) {
                    var ResponseData = XmlHttp.responseText;
                    //alert(ResponseData);                    
                    if (document.getElementById('gvStudentList') != null)
                        document.getElementById('gvStudentList').style.display = 'none';
                    var StrArray = ResponseData.split('~');
                    //alert(StrArray);                         
                    document.getElementById('ddlBatch').length = 0;
                    var max = StrArray.length - 1;
                    var item = document.createElement("option");
                    if (max != 0) {
                        item.text = '-Select Batch-';
                        item.value = 0;
                    }
                    document.getElementById('ddlBatch').options.add(item);
                    for (var i = 0; i < max; i++) {
                        var txt = StrArray[i].split('^');
                        var item = document.createElement("option");
                        //alert(txt[0]+''+ txt[1]);
                        item.text = txt[1];
                        item.value = txt[0];
                        document.getElementById('ddlBatch').options.add(item);
                    }
                }
                else {
                    alert("There was a problem retrieving data from the server.");
                }
            }
        }
        //******************************************END TimeSlot DDL***************************** 

        function Bind_Enrollee() {
            if (Number(document.getElementById('ddlBatch').value) != 0) {
                document.getElementById('btnGridBind').click();
                return true;
            }
        }

        function Select_Student_All() {
            if (document.getElementById('gvStudentList') != null) {
                var varRows = document.getElementById('gvStudentList').getElementsByTagName('TR');
                if (document.getElementById('chkSSelectAll').checked == true) {
                    for (var i = 1; i < varRows.length; i++) {
                        varRows[i].getElementsByTagName('input')[0].checked = true;

                    }
                }
                else {
                    for (var i = 1; i < varRows.length; i++) {
                        varRows[i].getElementsByTagName('input')[0].checked = false;
                    }
                }
            }
        }
        function Select_Employee_All() {
            if (document.getElementById('gvEmployeeList') != null)
                if (document.getElementById('chkESelectAll').checked == true) {
                    for (var i = 1; i < document.getElementById('gvEmployeeList').rows.length; i++) {
                        document.getElementById('gvEmployeeList').rows[i].getElementsByTagName('input')[0].checked = true;
                    }
                }
                else {
                    for (var i = 1; i < document.getElementById('gvEmployeeList').rows.length; i++) {
                        document.getElementById('gvEmployeeList').rows[i].getElementsByTagName('input')[0].checked = false;
                    }
                }
        }



        function fValidation_On_Cancel() {
            //ReplaceSpecialcharacter('frmMessage');
        }
        function fValidation_On_Export() {
            //ReplaceSpecialcharacter('frmMessage');
        }
        function fValidation_On_Close() {
            //ReplaceSpecialcharacter('frmMessage');
        }
        function fShowAttachment() {
            debugger;
            if (stripBlanks(document.getElementById('hidMessage').value).toLowerCase() == "") {
                pDisplayMessageclient('<%=Session["Type"].ToString() %>', "47", "");
                return false;
            }
            var str = document.getElementById('hidMessage').value;
            var chkimage = document.getElementById('hidMessage').value.split('.');
            if (chkimage[chkimage.length - 1] == "PDF" || chkimage[chkimage.length - 1] == "pdf") {
                window.open("News/" + str + "");
            }
            else {
                document.getElementById('dvImagePopup').style.display = "";
                document.getElementById('dvDullScreen').style.display = "";
                document.getElementById('imgNews').src = "News/" + str;
            }
                        return false;
//            if (stripBlanks(document.getElementById('hidMessage').value).toLowerCase() == "noimage") {
//                pDisplayMessageclient('<%=Session["Type"].ToString() %>', "47", "");
//                return false;
//            }
//            var str = document.getElementById('hidMessage').value;
//            fChangeButtonColor('frmMessage', '#400000');
//            window.open("MTAssignment.aspx?News=" + document.getElementById('hidMessage').value + "")
//            return false;
        }
        function DownloadAttachment() {
            if (document.getElementById("hidMessage").value == "") {
                alert('No News Attachment uploaded');
                return false;
            }
            fChangeButtonColor('frmMessage', '#400000');
            window.open("MTAssignment.aspx?NewsAttachment=" + document.getElementById('hidMessage').value + "")
            return false;
        }
        function closedvImagePopup() {
            document.getElementById('dvDullScreen').style.display = "none";
            document.getElementById('dvImagePopup').style.display = "none";
            return false;
        }  
    </script>
    <style type="text/css">
        .dvPopupClass
        {
            position: relative;
            background: #fff url(Images/j1.gif) repeat-x;
            font-size: 11px;
            -moz-border-radius: 2px;
            border-radius: 5px;
            padding: .5em .9em;
            color: rgba(0,0,0, .8);
            line-height: 1;
            margin: 0px auto;
            box-shadow: 1px 1px 15px rgba(248,182,75,0.7);
            -webkit-border-radius: 2px auto;
            box-shadow: 0px 0px 10px rgba(248,182,75,0.7);
            -moz-box-shadow: 0px 0px 10px rgba(248,182,75,0.7);
            -webkit-box-shadow: 0px 0px 10px rgba(248,182,75,0.7);
        }
    </style>
</head>
<body style="background-image: url(Images/backgroundImg.jpg); background-repeat: repeat;
    background-position: center center; background-attachment: scroll;">
    <form id="frmMessage" runat="server" onpaste="return false;">
    <asp:HiddenField ID="hidMessage" runat="server" />
    <asp:HiddenField ID="hdnImageName" runat="server" />
    <div id="dvDullScreen" style="height: 100%; width: 100%; position: absolute; z-index: 300;
        display: none; filter: Auto(Opacity=50); opacity: 0.5; background-color: rgb(102,102,102);">
    </div>
    <div id="dvImagePopup" class="dvPopupClass" style="z-index: 500; display: none; width: 500px;
        height: 400px; overflow: auto; position: absolute; margin: 100px 100px 100px;"
        align="center">
        <div class="MyTableHeader" style="cursor: move;" align="center">
            <div style="float: left; padding-left: 10px; padding-top: 2px; text-decoration: underline;
                font-weight: bold; cursor: pointer;" onclick="return DownloadAttachment();">
                Download</div>
            <div style="float: right; padding-top: 2px; padding-right: 10px; text-decoration: underline;
                font-weight: bold; cursor: pointer;" onclick="return closedvImagePopup();">
                Close</div>
        </div>
        <div align="center" style="padding-top: 20px;">
            <img alt="Image" class="MyWebImage" src="Images/NoImage.jpg" id="imgNews" />
        </div>
    </div>
    <div id="divMain" align="center">
        <table id="tblMain" cellpadding="0" cellspacing="0">
            <tr>
                <td class="divCircle">
                    <table class="MyTableBorder">
                        <tr>
                            <td align="center" class="MyTableHeader" colspan="4">
                                News&nbsp;Master
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="middle">
                                From&nbsp;Date
                            </td>
                            <td align="left">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNewsDate" runat="server" CssClass="MyTextBox" MaxLength="25"
                                                Width="80px" Style="position: relative" TabIndex="1"></asp:TextBox>
                                        </td>
                                        <td align="right" class="MyLabel">
                                            To&nbsp;Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtmessageTillDate" runat="server" CssClass="MyTextBox" MaxLength="25"
                                                Width="80px" TabIndex="2"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right" class="MyLabel" style="width: 100px">
                                Display&nbsp;Status
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="MyTextBox" Width="120px"
                                    Style="position: relative">
                                    <asp:ListItem Value="N" Text="NO"></asp:ListItem>
                                    <asp:ListItem Value="Y" Text="YES"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                News&nbsp;Title&nbsp;With&nbsp;Date
                            </td>
                            <td align="left">
                                <table cellspacing="1" cellpadding="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtMessageTitle" runat="server" CssClass="MyTextBox" MaxLength="25"
                                                Width="360px" TabIndex="3"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right" class="MyLabel">
                                User&nbsp;Type
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUserType" runat="server" CssClass="MyTextBox" Width="120px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged"
                                    Style="position: relative">
                                    <asp:ListItem Value="A">All</asp:ListItem>
                                    <asp:ListItem Value="S">Student</asp:ListItem>
                                    <asp:ListItem Value="E">Employee</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                                News
                            </td>
                            <td align="left" rowspan="2">
                                <asp:TextBox ID="txtMessage" runat="server" CssClass="MyTextBox" Height="61px" MaxLength="200"
                                    TextMode="MultiLine" Width="365px" TabIndex="4"></asp:TextBox>
                            </td>
                            <td align="right" class="MyLabel" valign="top">
                                Select&nbsp;Month&amp;Year
                            </td>
                            <td valign="top">
                                <asp:DropDownList ID="ddlNewsMonthYear" runat="server" CssClass="MyTextBox" Width="120px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlNewsMonthYear_SelectedIndexChanged"
                                    Style="position: relative">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                            </td>
                            <td align="right" class="MyLabel" valign="top">
                            </td>
                            <td valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                Attachment
                            </td>
                            <td colspan="2" align="left">
                                <asp:FileUpload ID="flUploadAttachment" Height="20px" runat="server" CssClass="MyTextBox"
                                    Width="200px" />&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkShowAttachment" CssClass="MyLabel" OnClientClick="javascript:return fShowAttachment();"
                                    runat="server">Show Attachment</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table id="tblStudent" border="1" runat="server">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td align="right" class="MyLabel">
                                                        Class
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlBatch" runat="server" CssClass="MyTextBox" Width="449px"
                                                            AutoPostBack="True" onchange="return Bind_Enrollee()" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="MyLabel">
                                                    </td>
                                                    <td align="right">
                                                        <asp:CheckBox ID="chkSSelectAll" runat="server" CssClass="MyLabel" Text="Select All"
                                                            onclick="return Select_Student_All()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="background-image: url(Images/tab_inactive.jpg); height: 16px;" align="center"
                                                        class="MyTableHead" colspan="2">
                                                        Student List
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:Panel ID="pnlStudentList" runat="server" class="MyTableBorder" Height="150px"
                                                            ScrollBars="Auto" Width="550px">
                                                            <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                                                EmptyDataText="There is no data to display" OnRowDataBound="gvStudentList_RowDataBound"
                                                                Width="525px" CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                                                                <Columns>
                                                                    <asp:BoundField HeaderText="Sl. No.">
                                                                        <ItemStyle HorizontalAlign="Right" Width="40px" />
                                                                        <HeaderStyle HorizontalAlign="Right" Width="40px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="StudentID" HeaderText="StudentID" />
                                                                    <asp:BoundField DataField="AdmissionNo" HeaderText="Admission No">
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="EnrolleeName" HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Select">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSelectS" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table id="tblEmployee" border="1" runat="server">
                                    <tr>
                                        <td align="left" colspan="3" valign="top">
                                            <table style="width: 575px">
                                                <tr>
                                                    <td align="right" class="MyLabel">
                                                        Designation
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="MyTextBox" Width="449px"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="MyLabel">
                                                        Department
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="MyTextBox" Width="449px"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <asp:CheckBox ID="chkESelectAll" runat="server" CssClass="MyLabel" Text="Select All"
                                                            onclick="return Select_Employee_All()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="MyTableHead" colspan="2" style="background-image: url(Images/tab_inactive.jpg)">
                                                        Employee List
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel ID="pnlEmployee" runat="server" class="MyTableBorder" Width="575px" Height="125px"
                                                            ScrollBars="Auto">
                                                            <asp:GridView ID="gvEmployeeList" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                                                EmptyDataText="There is no data to display" Width="555px" OnRowDataBound="gvEmployeeList_RowDataBound"
                                                                CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                                                                <Columns>
                                                                    <asp:BoundField HeaderText="Sl. No.">
                                                                        <ItemStyle HorizontalAlign="Right" Width="40px" />
                                                                        <HeaderStyle HorizontalAlign="Right" Width="40px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="PRLEmployeeID" HeaderText="EmployeeID" />
                                                                    <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code">
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Employee" HeaderText="Employee ">
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Select">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSelectE" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="MyTableHead" colspan="3" style="background: Images/tab_inactive.jpg;">
                                News
                            </td>
                            <td class="MyTableHeader">
                                Options
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3" valign="top">
                                <asp:Panel ID="pnlMessages" runat="server" class="MyTableBorder" ScrollBars="Vertical"
                                    Width="625px" Height="313px">
                                    <div id="divPrint">
                                        <asp:GridView ID="gvMessages" runat="server" Width="607px" AutoGenerateColumns="False"
                                            EmptyDataText="There Are No Items To Display" OnRowDataBound="gvMessages_RowDataBound"
                                            CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl. No.">
                                                    <HeaderStyle Width="50px" HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="MessageID" HeaderText="Message ID" />
                                                <asp:BoundField DataField="MessageTitle" HeaderText="Title">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MessageDate1" HeaderText="News&#160;Date">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MessageDate2" HeaderText="&#160;To&#160;Date">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Message" HeaderText="News">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="250px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MessageStatus" HeaderText="Display Status">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="StatusValue" HeaderText="Status Value" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            </td>
                            <td align="center" colspan="1" valign="top">
                                <table cellpadding="1" cellspacing="1">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnNew" runat="server" CssClass="MyButton" Text="New" OnClientClick="return Assign_New()"
                                                OnClick="btnNew_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnEdit" runat="server" CssClass="MyButton" Text="Edit" OnClientClick="return Assign_Edit()"
                                                OnClick="btnEdit_Click" TabIndex="6" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" CssClass="MyButton" Text="Save" OnClientClick="return Validate_On_Save()"
                                                OnClick="btnSave_Click" TabIndex="5" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnDelete" runat="server" CssClass="MyButton" Text="Delete" OnClientClick="return Validate_On_Delete()"
                                                OnClick="btnDelete_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" CssClass="MyButton" Text="Cancel" OnClientClick="return fValidation_On_Cancel()"
                                                OnClick="btnCancel_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPrintgrid" runat="server" CssClass="MyButton" Text="Export" OnClientClick="return fValidation_On_Export()"
                                                OnClick="btnPrintgrid_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnClose" runat="server" CssClass="MyButton" Text="Close" OnClientClick="return fValidation_On_Close()"
                                                OnClick="btnClose_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hidEditNew" runat="server" />
        <asp:HiddenField ID="hidLoad" runat="server" />
        <asp:HiddenField ID="hidCache" runat="server" />
        <asp:Button ID="btnGridBind" runat="server" CssClass="MyButton" Text="Button" OnClick="btnGridBind_Click" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="btndblClick" runat="server" CssClass="MyButton" Text="dblClick" OnClick="btndblClick_Click" /></div>
    </form>
</body>
</html>
