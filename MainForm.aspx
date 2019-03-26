<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainForm.aspx.cs" Inherits="MainForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>welcome Page</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/shadedborder.js"></script>
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
    <style media="screen" type="text/css">
.MyButtonLink
{
    background-image: -ms-linear-gradient(top, #FFFFFF 0%, #f8b64b 100%); 
    background-image: -moz-linear-gradient(top, #FFFFFF 0%, #f8b64b 100%); 
    background-image: -o-linear-gradient(top,#FFFFFF 0%,#f8b64b 100%); 
    background-image: -webkit-gradient(linear, left top, left bottom, color-stop(0, #FFFFFF), color-stop(1,#f8b64b)); 
    background-image: -webkit-linear-gradient(top, #FFFFFF 0%, #f8b64b 100%); 
    background-image: linear-gradient(to bottom, #FFFFFF 0%, #f8b64b 100%); 
    color:#CC6600;	
    font-size :8pt;	
    width:72px;
    height:20px;
    FONT-WEIGHT: bold;
    text-align:center; 
    -moz-border-radius: 5px;
    -moz-box-shadow: 1px 1px 10px rgba(248,182,75,0.7);
    border-radius: 5px;
    box-shadow: 1px 1px 10px rgba(248,182,75,0.7);           	
    transition: width 1s, height 1s, box-shadow 1s, color 1s;
    -webkit-transition: width 1s, height 1s,  box-shadow 1s, color 1s;
    -o-transition-property: width 1s, height 1s, box-shadow 1s, color 1s;
    -o-transition-duration:1s;  
}
.MyButtonLink:hover
{
	-moz-border-radius: 5px;
    -moz-box-shadow: 1px 1px 20px rgba(255,0,0,0.7);
    border-radius: 5px;
    box-shadow: 1px 1px 20px rgba(255,0,0,0.7);  
    width: 72px;
    height: 20px;
    color:Red;
}
.MyButtonLink:disabled
{
	color:Gray;
}
.divTask
 {
    width:20px;
    height:200px; 
    text-align:center;
    fony-width:bold;
    cursor:pointer; 
    float:left;  
   background:#fff url(Images/j1.gif) repeat-x;  
    font-weight: bold;
    font-size :11px;	 
    -moz-border-radius: 5px;
    -moz-box-shadow: 1px 1px 10px rgba(248,182,75,0.7);
    border-radius: 5px;
    box-shadow: 1px 1px 10px rgba(248,182,75,0.7);  

 } 
.divMessage
{
    width:20px;
    height:150px; 
    text-align:center;
    fony-width:bold;
    cursor:pointer; 
    float:left;   
    background:#fff url(Images/j1.gif) repeat-x;  
    font-weight: bold;
    font-size :11px;	 
    -moz-border-radius: 5px;
    -moz-box-shadow: 1px 1px 10px rgba(248,182,75,0.7);
    border-radius: 5px;
    box-shadow: 1px 1px 10px rgba(248,182,75,0.7);     
} 
 #MainTask
 {
        width:500px;
        height:200px; 
        text-align:center;
        fony-width:bold;
        cursor:pointer;
        float:left;
        position:relative;  
        background:#fff url(Images/j1.gif) repeat-x; 
        -moz-border-radius: 5px;
        -moz-box-shadow: 1px 1px 10px rgba(248,182,75,0.7);
        border-radius: 5px;
        box-shadow: 1px 1px 10px rgba(248,182,75,0.7);     
 }
 #divDesktop
 {
        width:500px;
        height:200px; 
        text-align:center;
        fony-width:bold;
        cursor:pointer;
        float:left;
        vartical-align:middle;
        position:relative;  
        background:#fff url(Images/j1.gif) repeat-x; 
        -moz-border-radius: 5px;
        -moz-box-shadow: 1px 1px 10px rgba(248,182,75,0.7);
        border-radius: 5px;
        box-shadow: 1px 1px 10px rgba(248,182,75,0.7);    
	 
 }
 #divMessage
 { 
    width:500px;
    height:150px; 
    text-align:center;
    fony-width:bold;
    cursor:pointer;
    float:left;
    vartical-align:middle;
    position:relative;  
    background:#fff url(Images/j1.gif) repeat-x; 
    -moz-border-radius: 5px;
    -moz-box-shadow: 1px 1px 10px rgba(248,182,75,0.7);
    border-radius: 5px;
    box-shadow: 1px 1px 10px rgba(248,182,75,0.7); 
 }
@keyframes Task
{
      0% {width:00px;}
    100% {width:500px;}   
}
@-webkit-keyframes Task
{
    0% {width:0px;}
    100% {width:500px;}   
}
@keyframes TaskReverse
{
    0% {width:500px;}
    100% {width:0px;}   
}
@-webkit-keyframes TaskReverse
{
    0% {width:500px;}
    100% {width:0px;}   
} 
.AnimateTask
{
    z-index:10; 
    position:relative; 
    animation: Task 1s;
    animation-timing-function:linear;
    animation-delay:0s;
    animation-iteration-count:1;
    animation-direction:normal;
    animation-play-state:running;   
    -webkit-animation: Task 1s;
    -webkit-animation-timing-function:linear;
    -webkit-animation-delay:0s;
    -webkit-animation-iteration-count:1;
    -webkit-animation-direction:normal;
    -webkit-animation-play-state:running;  
} 
.AnimateTaskReverse
{
    z-index:10; 
    position:relative; 
    animation: TaskReverse 1s;
    animation-timing-function:linear;
    animation-delay:0s;
    animation-iteration-count:1;
    animation-direction:normal;
    animation-play-state:running;   
    -webkit-animation: TaskReverse 1s;
    -webkit-animation-timing-function:linear;
    -webkit-animation-delay:0s;
    -webkit-animation-iteration-count:1;
    -webkit-animation-direction:normal;
    -webkit-animation-play-state:running;  
} 
 .dvPopupClass
 {
      position:relative;
     background:#fff url(Images/j1.gif) repeat-x;
    font-size:11px;
    -moz-border-radius: 2px;
    border-radius: 5px;        	
    padding: .5em .9em; 
    color: rgba(0,0,0, .8); 
    line-height: 1;
    margin: 0px auto;
    box-shadow: 1px 1px 15px rgba(248,182,75,0.7);
    -webkit-border-radius: 2px auto;
    box-shadow: 0px 0px 10px rgba(248,182,75,0.7);  
    -moz-box-shadow: 0px 0px 10px  rgba(248,182,75,0.7);   
    -webkit-box-shadow: 0px 0px 10px  rgba(248,182,75,0.7);  
     }
</style>
    <script language="javascript" type="text/javascript"> 
addLoadEvent(fEnable);
function fEnable()
{
    if("<%=strCompany %>"!=null && "<%=strCompany %>"!="")
    { 
            window.parent.document.getElementById('lblCompany').innerHTML = "<%=strCompany %>"; 
    } 
}
function fMouseOver(Me)
{
    Me.style.cursor='hand';
    Me.style.color="Red"; 
    Me.style.fontWeight='bold';
    Me.style.fontFamily='Verdana';
}
function fMouseOut(Me)
{
    Me.style.color="Blue"; 
    Me.style.fontWeight='normal'; 
}
function fOpenwindow()
{
    var NewWindow=window.open("frmAbout.aspx","AboutUs","resizable=yes,location=no,status=no,menubar=no,toolbar=no");
    return false;
}
document.oncontextmenu=f_hideMenu;
function f_hideMenu()
{
    return false;
}
function AssignError()
{ 
    document.getElementById('imgPhoto').src="EmployeePhotos/NoImage.JPG"; 
    return false;
}
function ChangeSchool(varSchool)
{  
    if(top.document.getElementById('defaultform')!=null)
         { top.document.getElementById('defaultform').getElementsByTagName("span")['SchoolMaruqeeName'].innerHTML=
            "<span style=\"color: #666666; font-family: Verdana;font-size:13px;\"> " +
            " <SPAN onmouseover=\"javascript:this.style.color='#33ff66';this.style.cursor='crosshair';\" " + 
            " onmouseout=\"javascript:this.style.color='#666666';\"><STRONG>" + varSchool + "</STRONG></SPAN></SPAN>";
            
          if (window.parent.document.getElementById('ddlSchools') !=null)
           {
             window.parent.document.getElementById('ddlSchools').value = "<%=Session["SchoolID"].ToString() %>";
           }
          if (window.parent.document.getElementById('ddlSchools') !=null)
          {
           window.parent.document.getElementById('ddlSession').value = "<%=Session["AcaStart"].ToString() %>";
          }
            
            if("<%=strLink %>"!=null && "<%=strLink %>"!="")
            {
                document.getElementById('Button1').click();
            }
            if("<%=strCompany %>"!=null && "<%=strCompany %>"!="")
            { 
                    window.parent.document.getElementById('lblCompany').innerHTML = "<%=strCompany %>"; 
            }
        }
    }
     
     
    function testColl(id)
    { 
        var str = id.split('_');
        var newID = str[0] + '_' + str[1] + '_MessageLabel';
         var newID1 = str[0] + '_' + str[1] + '_MessageLabel1';
        var varimg=str[0] + '_' + str[1] +'_description_ToggleImage';
        if(document.getElementById(newID).style.display == 'block')
        {
            document.getElementById(newID).style.display = 'none';
            document.getElementById(newID1).style.display = 'none';
            document.getElementById(varimg).src="Images/collapse.jpg";
         }
        else
        {
            document.getElementById(newID).style.display = 'block';
             document.getElementById(newID1).style.display = 'block';
             document.getElementById(varimg).src="images/expand.jpg";
        }

    }
    
    
    function fLoadForm(VarCaption)
    {     
       var varText = document.getElementById(VarCaption).defaultValue;
       varID= pReturnSingleValue("SELECT MenuLinkPage FROM MTUserMenuMaster WHERE MenuCaption1='"+varText+"'");
       window.parent.document.getElementById('MainFrame').src=varID;
       return false; 
    }
    
    
     function fLoadEnquiryRegPage(VarCaption)
    {
        document.getElementById('hidFlag').value="";
        document.getElementById('hidFlag').value=VarCaption;
        document.getElementById('btnOpenEnqReg').click();         
        return false;
    }
    function fLoadFormDirect(linkpage)
    { 
         window.parent.document.getElementById('MainFrame').src=linkpage;
         return false; 
    }
    function Task() {
        
          document.getElementById('MyTesk').style.display = 'none';
        if (document.getElementById('MainTask').className != "AnimateTask") {
            document.getElementById('MainTask').className = "AnimateTask";
            document.getElementById('MainTask').style.display = ''; 
            setTimeout(displayTask, 1000);
        }
        else {
            document.getElementById('MainTask').className = "AnimateTaskReverse";
            setTimeout(displayNone, 1000);
        }
    }
    function displayNone() {
        document.getElementById('MainTask').style.display = 'none';
    }
    function displayTask() {
        document.getElementById('MyTesk').style.display = '';
    }
    function Desktop()
    {
        document.getElementById('tblDesktop').style.display = 'none';
        if (document.getElementById('divDesktop').className != "AnimateTask") {
            document.getElementById('divDesktop').className = "AnimateTask";
            document.getElementById('divDesktop').style.display = ''; 
            setTimeout(displayDesk, 1000);
        }
        else {
        document.getElementById('divDesktop').className = "AnimateTaskReverse";
        setTimeout(displayDesktop, 1000);
        }
    }
    function displayDesktop() {
        document.getElementById('divDesktop').style.display = 'none';
    }
    function displayDesk() {
        document.getElementById('tblDesktop').style.display = '';
    }
    function Message()
    {
       document.getElementById('tblMessage').style.display = 'none';
        if (document.getElementById('divMessage').className != "AnimateTask") {
            document.getElementById('divMessage').className = "AnimateTask";
            document.getElementById('divMessage').style.display = ''; 
            setTimeout(displaMess, 1000);
        }
        else {
        document.getElementById('divMessage').className = "AnimateTaskReverse";
        setTimeout(displaMessage, 1000);
        }
    }
     function displaMessage() {
        document.getElementById('divMessage').style.display = 'none';
    }
    function displaMess() {
        document.getElementById('tblMessage').style.display = '';
    }
    function pfunctionPopUp(divChildID) {
            var varWidth = this.innerWidth;
            var varheight = this.innerHeight;   
            
            document.getElementById(divChildID).style.display = '';
            document.getElementById(divChildID).style.top = "100px";
            document.getElementById(divChildID).style.left = "180px";
            document.getElementById(divChildID).style.display = "inline";                      
            return false;
        }
    function fShowAttachment(e) {     
            var varKey;
            if(window.event)
            varKey=window.event.keyCode;
            else
            varKey=e.which;
            var event=e || window.event;
            var target=event.target || event.srcElement;    
            var varid=target.id.split('_');    
            var varID=varid[0]+"_"+varid[1]+"_hdnNewsAttachment";            
            if (document.getElementById(varID).value=="")
            { 
                alert('No News Attachment uploaded');    
                return false;
            } 
            var str= document.getElementById(varID).value;
            document.getElementById('hdnImageName').value=str;
            var chkimage = document.getElementById('hdnImageName').value.split('.');
            if (chkimage[chkimage.length - 1] == "PDF" || chkimage[chkimage.length - 1] == "pdf") {
                window.open("News/" + str + "");
            }
            else
            {
            document.getElementById('dvImagePopup').style.display="";
            document.getElementById('dvDullScreen').style.display="";
            document.getElementById('imgNews').src="News/"+str;   
            pfunctionPopUp('dvImagePopup');
            }
            return false;
        }
      function DownloadAttachment() {
            if (document.getElementById("hdnImageName").value=="")
            { 
                alert('No News Attachment uploaded');    
                return false;
            }
            fChangeButtonColor('form1','#400000');
            window.open("MTAssignment.aspx?NewsAttachment=" + document.getElementById("hdnImageName").value+"")
            return false;
      }
      function closedvImagePopup() {
        document.getElementById('hdnImageName').value="";
        document.getElementById('dvDullScreen').style.display="none";
        document.getElementById('dvImagePopup').style.display="none";        
        return false;
      } 
    </script>
</head>
<body scroll="no" style="overflow: hidden; background-image: url(Images/M3.jpg);
    background-repeat: repeat; background-position: center bottom; background-attachment: fixed;">
    <form id="form1" runat="server"> 
    <asp:HiddenField ID="hdnImageName" runat="server" />
    <div id="dvDullScreen" style="height: 100%; width: 100%; background-color:rgb(102,102,102);
        position: absolute; z-index: 300;display:none;filter:alpha(Opacity=50);opacity:0.5; ">
    </div>   
    <cc1:DragPanelExtender ID="DragPanelExtender1" DragHandleID="dvDragpanel" TargetControlID="dvImagePopup"
        runat="server">
    </cc1:DragPanelExtender>
    <asp:Panel ID="dvImagePopup" runat="server" CssClass="dvPopupClass" Style="z-index: 500;
        display: none; width: 500px; height: 400px; position: absolute;" align="center">
        <asp:Panel ID="dvDragpanel" runat="server" CssClass="MyTableHeader" Style="cursor: move;
            width: 100%;" align="center">
            <div style="float: left; padding-left: 10px; padding-top: 2px; text-decoration: underline;
                font-weight: bold; cursor: pointer;" onclick="return DownloadAttachment();">
                Download</div>
            <div style="float: right; padding-top: 2px; padding-right: 10px; text-decoration: underline;
                font-weight: bold; cursor: pointer;" onclick="return closedvImagePopup();">
                Close</div>
        </asp:Panel>
        <div align="center" style="padding-top: 20px; width: 495px; height: 360px; overflow: auto;">
            <img alt="Image" class="MyWebImage" src="Images/NoImage.jpg" id="imgNews" />
        </div>
    </asp:Panel>
    <div id="divMain" style="width: 100%; height: 100%;">
        <table style="width: 100%">
            <tr>
                <td style="width: 60%">
                </td>
                <td style="width: 25%">
                </td>
                <td style="width: 15%">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <div id="MainTask" style="display: none;">
                        <%----%>
                        <table id="MyTesk">
                            <tr>
                                <td class="MyTableHeader">
                                    My Task
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="description_ContentPanel" runat="server" Height="150px" ScrollBars="Vertical"
                                        Width="480px">
                                        <asp:DataList ID="DLHeader" runat="server" CellPadding="3" CellSpacing="2" ShowHeader="False"
                                            ShowFooter="False" Width="460px" BorderColor="Transparent" BorderStyle="None">
                                            <ItemTemplate>
                                                <asp:Panel ID="description_HeaderPanel" runat="server" Style="cursor: pointer;">
                                                    <div class="heading">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Image ID="description_ToggleImage" runat="server" onclick="javascript:return testColl(this.id);"
                                                                                    ImageUrl="~/images/collapse.jpg" />
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="MessageTitleLabel" runat="server" Text='<%# Eval("Header") %>' Style="font-weight: bold;
                                                                                    color: #666644; font-family: Arial, Helvetica, sans-serif; font-size: 10pt; font-style: italic;">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <br />
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("Detail") %>' Style="font-size: 10px;
                                                                        font-weight: bold; color: #4E8669; font-family: Arial, Helvetica, sans-serif;
                                                                        font-size: 8pt; background-color: Transparent; display: none; position: relative;"
                                                                        Width="440px" Height="100%" BackColor="Transparent"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="MessageLabel1" runat="server" Text='<%# Eval("Remark") %>' Style="font-size: 10px;
                                                                        font-weight: bold; color: #4E8669; font-family: Arial, Helvetica, sans-serif;
                                                                        font-size: 8pt; background-color: Transparent; display: none; position: relative;"
                                                                        Width="99%" Height="100%" Font-Size="9pt"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </asp:Panel>
                                            </ItemTemplate>
                                            <SeparatorStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Top"></SeparatorStyle>
                                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                                        </asp:DataList>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divTask" style="display:none !important"  class="divTask" onclick="return Task();">
                        <br />
                        <br />
                        <br />
                        M<br />
                        Y<br />
                        <br />
                        T<br />
                        A<br />
                        S<br />
                        K<br />
                    </div>
                </td>
                <td align="center" style="display:none">
                    <asp:ImageButton ID="imgPhoto" runat="server" Height="112px" Width="105px" CssClass="MyButton"
                        OnClientClick="javascript:return false;" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="divMessage" style="display: none !important">
                        <table id="tblMessage">
                            <tr>
                                <td>
                                    <asp:Image ID="imgInbox" runat="server" ImageUrl="~/MailImages/mail.jpg" Width="27px" />
                                </td>
                                <td class="MyLabel" onclick="javascript:return fLoadFormDirect('EmployeeMessages.aspx');"
                                    style="cursor: pointer">
                                    <asp:Label ID="lblInboxStatus" runat="server" CssClass="MyLabel" Text="Message" Width="110px"
                                        ForeColor="#024BA0" Font-Bold="true" Font-Size="10px"></asp:Label>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td class="MyLabel" onclick="javascript:return fLoadEnquiryRegPage('Enquiry~Today');"
                                    style="cursor: pointer">
                                    <asp:Label ID="lblTodayEnquiry" runat="server" CssClass="MyLabel" Text="Today Enquiry"
                                        Width="120px" ForeColor="#024BA0" Font-Bold="true" Font-Size="10px"></asp:Label>
                                </td>
                                <td class="MyLabel" onclick="javascript:return fLoadEnquiryRegPage('Enquiry~LastWeek');"
                                    style="cursor: pointer">
                                    <asp:Label ID="lblLastWeekEnquiry" runat="server" CssClass="MyLabel" Text="Last Week Enquiry"
                                        ForeColor="#024BA0" Font-Bold="true" Font-Size="10px"></asp:Label>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td class="MyLabel" onclick="javascript:return fLoadEnquiryRegPage('Registration~Today');"
                                    style="cursor: pointer;">
                                    <asp:Label ID="lblTodayRegistration" runat="server" CssClass="MyLabel" Text="Today Registration"
                                        Width="120px" ForeColor="#024BA0" Font-Bold="true" Font-Size="10px"></asp:Label>
                                </td>
                                <td class="MyLabel" onclick="javascript:return fLoadEnquiryRegPage('Registration~LastWeek');"
                                    style="cursor: pointer;">
                                    <asp:Label ID="lblLastWeekRegistration" runat="server" CssClass="MyLabel" Text="Last Week Registration"
                                        ForeColor="#024BA0" Font-Bold="true" Font-Size="10px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="div2" class="divMessage" style="display:none !important"  onclick="return Message();">
                        <br />
                        M<br />
                        Y
                        <br />
                        <br />
                        M<br />
                        E<br />
                        S<br />
                        S<br />
                        A<br />
                        G<br />
                        E
                    </div>
                </td>
                <td rowspan="2">
                    <table cellspacing="0" cellpadding="0" width="100%" align="right">
                        <tr>
                            <th valign="top" scope="col" align="center" style="color: #04032D; font-family: Arial,Helvetica,sans-serif;
                                font-size: Medium;">
                                <br />
                                <span style=" display: none !important; underline">News&nbsp;&&nbsp;Events</span>
                            </th>
                        </tr>
                        <tr style="height: 300px; width: 100%">
                            <td align="left" valign="bottom" rowspan="5">
                                <div style="overflow: hidden; height: 300px; text-align: center;">
                                    <marquee direction="up" scrollamount="2" style="height: 300px; text-align: left;
                                        z-index: 101; margin: 0; width: 251px;" scrolldelay="20" onmouseover="this.stop();"
                                        onmouseout="this.start();"><span>
                                        <asp:DataList ID="DLMessageList" runat="server" Width="259px" ShowFooter="False"
                                            ShowHeader="False" OnItemDataBound="DLMessageList_ItemDataBound" CellPadding="0">
                                            <ItemTemplate>
                                                <table style="width: 229px" cellpadding="0" cellspacing="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="border-bottom: solid 1px black;" height="50px" width="50px" title="Click here to download"
                                                                rowspan="2" id="tdimg" runat="server" visible='<%# (Eval("NewsFileName")==""?false:true) %>'>
                                                                <asp:ImageButton ID="imgbtnNews" CssClass="MyWebImage" Height="40px" OnClientClick="javascript:return fShowAttachment(event);"
                                                                    ImageUrl='<%# (Eval("NewsFileName")==""?"":"News/"+Eval("NewsFileName")) %>'
                                                                    runat="server"></asp:ImageButton>
                                                                <br />
                                                                <asp:HiddenField ID="hdnNewsAttachment" runat="server" Value='<%# Eval("NewsFileName") %>' />                                                                
                                                            </td>
                                                            <td style="width: 187px" align="center">
                                                                <asp:Label Style="font-weight: bold; font-size: 9pt; left: 2px; color: #5C8533; font-style: italic;
                                                                    font-family: Arial, Helvetica, sans-serif; position: relative; top: 0px" ID="MessageTitleLabel"
                                                                    runat="server" Width="100%" Text='<%# Eval("MessageTitle") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 187px; border-bottom: solid 1px black;" align="center">
                                                                <asp:Label Style="font-weight: bold; font-size: 8pt; color: #04032d; font-family: Arial, Helvetica, sans-serif;
                                                                    position: relative; background-color: transparent" ID="MessageLabel" runat="server"
                                                                    Width="100%" Height="100%" Text='<%# Eval("Message") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <SeparatorStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Top"></SeparatorStyle>
                                            <HeaderStyle VerticalAlign="Top"></HeaderStyle>
                                        </asp:DataList>                          
                                     </span></marquee>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             
            <tr>
                <td colspan="2">
                    <div id="divDesktop" style="display: none;">
                        <table style="margin: 15px;" id="tblDesktop">
                            <tr>
                                <td class="MyTableHeader">
                                    My Desktop
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Panel ID="Panel1" runat="server" Width="480px">
                                        <asp:DataList ID="DLCaption" runat="server" RepeatColumns="3" Width="450px" RepeatDirection="Horizontal">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td valign="middle" style="height: 45px;">
                                                            <asp:Button runat="server" ID="LinkButton1" Width="140px" Height="35px" CssClass="MyButton"
                                                                Text='<%# Eval("MenuCaption1") %>' BorderStyle="None" OnClientClick="return fLoadForm(this.id)" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="div1" style="display:none !important" class="divTask" onclick="return Desktop();">
                        <br />
                        <br />
                        <br />
                        M<br />
                        Y
                        <br />
                        <br />
                        D<br />
                        E<br />
                        S<br />
                        K<br />
                        T<br />
                        O<br />
                        P
                    </div>
                </td>
            </tr>
        </table>        
    </div>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="display: none"
        Text="Button" />
    <asp:Button ID="btnOpenEnqReg" runat="server" Text="Open Enq Reg" Style="display: none;"
        OnClick="btnOpenEnqReg_Click" />
    <asp:HiddenField ID="hidFlag" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </form>
    <script type="text/javascript"> 
    </script>
</body>
</html>
