<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>KBMTech, Dubai</title>
    <link rel="shortcut icon" href="Images/Logo.jpg" />
    <link rel="icon" type="image/jpg" href="Images/Logo.jpg" /> 
       <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <link href="CSS/MyStyle.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/admin.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript" ></script>  
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>  
    <style media="screen" type="text/css">
        html,
        body {
                margin:0;
                padding:0;
                height:100%;                
              }
        #container2 {
                min-height:100%;
                position:relative;                
        }
        #header {
                background:#ff0;
                padding:0px;
                min-height:20%;
        }
        #body {
                padding:0px;
                padding-bottom:16px;
                position:relative;
                min-height:100%;
                min-width:100%;
        }
        #footer {
                position:absolute;
                bottom:0;
                width:99.9%;
                height:16px;
                background:#6cf;
        }
        #header p,
        #header h1 {
                margin:0;
                padding:10px;
        }
        #footer p {
                margin:0;
                padding:10px;
        }
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

    </style> 
    
    <script language="javascript" type="text/javascript">
    window.history.forward(1) ;
  
    var FrameFlag=true;
    function fResize()
            {
                
                if(FrameFlag)
                {
                document.getElementById('leftTD').style.width = "1%";
                document.getElementById('rightTD').style.width = "99%";
                document.getElementById('imgbtnExpand').src="Images/buttonplus.JPG";    
                    
                    FrameFlag=false;
                }
                else
                {
                   document.getElementById('leftTD').style.width = "20%";
                    document.getElementById('rightTD').style.width = "80%"; 
                    document.getElementById('imgbtnExpand').src="Images/buttonminus.JPG"; 
                      
                    FrameFlag=true;
                }
                return false;
            }
    function updateTime()
            {
                var label = document.getElementById('lblTime');
                if (label) {
                    var time = (new Date()).toLocaleTimeString();
                    time = time.match(/^(\s*\d{1,2}\s*\:\s*\d{1,2}\s*\:\s*\d{1,2}\s*[A-Za-z]{2}).*$/)[1];
                    label.innerHTML = time;
                }
            }            
            updateTime();
            window.setInterval(updateTime, 1000);
            
    function fMouseOver(Me)
            {
             Me.style.cursor='hand';
             Me.style.color='Red'; 
             Me.style.fontWeight='bold';
             Me.style.fontFamily='Verdana';
            }
     function fMouseOut(Me)
            {
             Me.style.color='Blue'; 
             Me.style.fontWeight='normal';
             
            }
      function fOpenwindow()
            {
                var NewWindow=window.open("About.aspx","AboutUs","resizable=yes,location=no,status=no,menubar=no,toolbar=no,scrollbars=1");
                return false;
            }
            
            
            function fDisplayDashBoard()
            { 
               document.getElementById('divDashBoard').style.display="block";
                document.getElementById('divDashBoard').style.right="50px"
                document.getElementById('divDashBoard').style.top="20px"
                document.getElementById('divDashBoard').style.position="absolute";         
                document.getElementById('divDashBoard').align="right"; 
                return false;
            }
            function fCloseFind()
            {
                document.getElementById('divDashBoard').style.display="none";
                return false;
            }
             function fCloseDisplay()
            { 
                return false;
            }
            
            function fBindGrid(VarCaption) { 
                 var varClTime=new Date(); 
                document.getElementById('divDashBoard').style.display="none";  
                var varData=pReturnSingle('DisplayID');
                var varCaptionID=varData.split('^');
 
               for(var intLoop =0;intLoop<varCaptionID.length;intLoop++)
                 {
                 for(var intCellLoop =0;intCellLoop<document.getElementById('DataList1').rows[0].cells.length;intCellLoop++)
                { 
                  var strColvalue = (intLoop ) > 9 ? String((intLoop )) : "0" + String ((intLoop ));
               
                    if(document.getElementById("DataList1_ctl" + strColvalue + "_LinkButton1").id==VarCaption)
                      {
                     document.getElementById('MainFrame').src="MTDashBoardDetails.aspx?TypeID="+stripBlanks(varCaptionID[intLoop])+"";
                      document.getElementById('divDashBoard').style.display="none";
                       return false;                                                   
                     }
               }   
              }

               return false;
            } 
    var curSelRow=null;   
    var curSelRowIndex=-1;
    function fGridDoubleClick(varRowIndex)
    { 
        if(curSelRow!=null)
        {
        curSelRow.style.backgroundColor = (curSelRowIndex % 2== 0 ? "#EBEBEB":"activeborder");
        }
        document.getElementById("gvDisplayCaption").rows[varRowIndex+1].style.backgroundColor='#ffc0cb';
        curSelRow=document.getElementById("gvDisplayCaption").rows[varRowIndex+1];
        curSelRowIndex=varRowIndex; 
        return false;
    } 
     
        function adtHeight()
        { 
             var mframe=document.getElementById("MainFrame");             
             var frame=document.getElementById("MenuFrame");             
             frame.style.height=(document.body.offsetHeight-61)+"px";
             mframe.style.height =(document.body.offsetHeight-61)+"px";
        }

function disableContextMenu()
        {
            window.frames["MainFrame"].document.oncontextmenu = function(){ return false;};   
            window.frames["MenuFrame"].document.oncontextmenu = function(){ return false;};  
            window.document.defaultform.oncontextmenu = function(){return false;} ;
        } 
        
    function HandleClose() {
        var varData = pReturnSingle('OutTime'); 
    }
function pReturnSingle(varFlag)
{
    try
    {
        var requestUrl =  "Default.aspx?Flag="+encodeURIComponent(varFlag)+"";
        var responseStream=getAjaxInfo(requestUrl);
        var varAction=eval("(responseStream)");
        return varAction;
    }
    catch (ex)
    {
        return false;
    }
}
function pOpenPrivacy() {
    var NewWindow = window.open("PrivacyPolicy.aspx", "PrivacyPolicy", "height=500px,width=800px,resizable=yes,location=no,status=no,menubar=no,toolbar=no,scrollbars=1");
    return false;
}
               
    </script>
</head>
<body style="text-align:center;margin:0;padding:0;" onload="adtHeight();"  onunload="return HandleClose();" style="background-image: url(Images/M3.jpg);
    background-repeat: repeat; background-position: center bottom; background-attachment: fixed" oncontextmenu="return false;">
<div id="container2" >
<form runat="server" id="defaultform" style="height:100%; width:100%" >
<div align="center" style="width:100%">
<table id="tblMain" cellpadding="0" cellspacing="0" style="border-width:1px;border-style:solid;border-color:InactiveBorder;" width="100%">
<tr style=" width:100%">
<td style="border-width:0px; width: 100%;">
<div id="header">
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr style="width:100%">
    <td style="width:100%">
    <table cellpadding="0" cellspacing="0" width="100%" style=" background-color:#f3efe8">  
        
    <tr style="width:100%">
    <td align="center" style="width: 15%; height: 20px;">
        <strong><span style="color: #526666;font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 12px;">
            InnoSoft®</span> <em></em></strong></td>
             <td  align="left" style="width: 80%; height: 20px;">
            <span id="SchoolMaruqeeName">
                <span style="color:#526666;font-family: Verdana;font-size:13px;width:60%;text-align:right;">
                <span onmouseover="javascript:this.style.color='#3065A3';this.style.cursor='crosshair';" 
                onmouseout="javascript:this.style.color='#024BA0';">
                   <asp:Label ID="lblSchoolName" runat="server" Font-Bold="true"></asp:Label>
                </span>
                </span>
            </span>
            <span style="width:40%; text-align:right">
                <asp:DropDownList ID="ddlSchools" runat="server"  OnSelectedIndexChanged="ddlSchools_SelectedIndexChanged" AutoPostBack="true" CssClass="MyTextBox">
                </asp:DropDownList>
             <%--   <asp:DropDownList Visible="false" ID="ddlSession" runat="server" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" AutoPostBack="true" CssClass="MyTextBox">
                </asp:DropDownList>--%>
        <asp:Label id="lblUser" runat="server" ForeColor="#526666" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" CssClass="MyLabel" ></asp:Label>
        </span>
        </td>
            
             <td align="center" valign="top" style="height:20px; display: none;">
                 <asp:Button ID="btnDashBoard" runat="server" Text="DashBoard" BackColor="Transparent" BorderWidth="0px"  OnClientClick="return fDisplayDashBoard();"
                 Font-Names="Verdana" Width="100px" Font-Size="13px" Font-Bold="true" ForeColor="#526666" /></td>
           <td  align="center" valign="top" style="height:20px; "  >
           <asp:Button ID="LinkButton1" runat="server" Text="Logout" BackColor="Transparent" BorderWidth="0px" OnClick="LinkButton1_Click"
                Font-Names="Verdana"  Width="100px" Font-Size="13px" Font-Bold="true" ForeColor="#526666"   />
            </td>
          </tr>    
    <tr style="width:100%">
    <td colspan="2" align="left" style="border-width:0px;border-style:solid;border-color:Maroon; width:100%">
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr style="width:100%">
    <td style="width:18%" align="center">
 <%--   <table cellpadding="0" cellspacing="0"><tr>
    <td style="height: 19px">
    <asp:Label id="Label1" runat="server" ForeColor="#000053" Font-Underline="False" Font-Size="10pt" Font-Names="Tahoma" Text="Menu Choice" Font-Bold="True"></asp:Label>
    </td>
    <td style="height: 19px">
        <asp:ImageButton ID="imgbtnExpand" runat="server" Height="16px" ImageUrl="~/Images/buttonminus.JPG"
            Width="16px" /></td>
     </tr></table>  --%>     
    </td>        
           <td valign="top" style="width:30%">
         <asp:Label ID="lblCompany" runat="server" CssClass="MyLabel"  Font-Bold="True" Font-Names="Verdana"
                Font-Size="8pt" ForeColor="#000053"></asp:Label> </td>
                <td valign="top" align="right" colspan="2">
          <asp:LinkButton ID="lnkPortal"  ForeColor="#526666" runat="server"  Font-Bold="True" 
            Font-Names="Times New Roman" Font-Size="16px" Font-Underline="True" Font-Italic="True" 
            OnClick="lnkPortal_Click">Web Portal</asp:LinkButton></td>
                
                
               
                
                
        <td valign="top" style="text-align: right" colspan="5">&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblDate" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="10pt"
             ForeColor="#000053"  
            CssClass="MyLabel"></asp:Label>
            <asp:Label id="lblTime" runat="server" CssClass="MyLabel" Font-Bold="False" Font-Names="Verdana" Font-Size="10pt" ForeColor="#000053"></asp:Label></td>
    </tr>
    </table>
    </td>


        
    </tr>
    </table>
    </td>    
    </tr>
    </table>
</div>
<div id="body">
<table cellpadding="0" cellspacing="0" style="width:100%;">
    <tr style="width:100%;">
        <td style="width:100%; colspan="2">
            <table cellpadding="0" cellspacing="0" style="width:100%;">            
                <tr style="width:100%;">                
                    <td align="left" valign="top" style="border-color:#f3f1ee;border-width:2px;border-style:solid; width:20%; height: 300px;"  id="leftTD" >
                        <iframe id="MenuFrame" frameborder="0"  onload="return disableContextMenu();" style="border-color:InactiveBorder;" width="100%" src="MenuForm.aspx" scrolling="no"></iframe>
                    </td>
                    <%-- </tr>     
                    <tr style="width:100%;">  --%>
                    <td valign="top" id="rightTD" align="center" style="border-color:#f3f1ee;border-width:2px;border-style:solid; width:100%; height: 154px;">
                        <iframe id="MainFrame" name="MainFrame"  onload="return disableContextMenu();" scrolling="auto" width="100%px" src="MainForm.aspx" frameborder="0"></iframe>
                    </td>                
                </tr>                
            </table>
        </td>
    </tr>
</table>
</div> 

<div id="footer">
    <table cellpadding="0" cellspacing="0" width="99.9%">
    <tr style="width:100%;">
    <td style="width:100%;" >
        <div align="center" style="width:100%;border-width:1px;border-style:solid;border-color:ActiveBorder;" >
        <table cellpadding="0" cellspacing="0" width="100%" style=" background-image:url(Images/2tab_tile1.gif); background-repeat:repeat;">
            <tr style="width:100%">
            <td align="left" style="width: 40%">            
            <asp:HyperLink ID="HyperLink1" runat="server" Text="InnoSoft® Application" CssClass="linkBlue" NavigateUrl="#" Target="_blank"></asp:HyperLink>            
            </td>
                <td align="center" valign="top" style="border-style:solid;border-width:1px;border-top-width:0px;border-bottom-width:0px;border-left-color:Black;border-right-color:Black;vertical-align:middle; width: 10%;">
                <asp:Button ID="btnPrivacy" runat="server" BackColor="Transparent" BorderWidth="0px"
                    Font-Names="Verdana" Font-Size="10px" ForeColor="Blue" Text="Privacy" Width="65px" Height="14px" 
                     OnClientClick="javascript:return pOpenPrivacy();" />
                </td>
                <td align="center" valign="top" style="border-style:solid;border-width:1px;border-top-width:0px;border-bottom-width:0px;border-left-color:Black;border-right-color:Black;vertical-align:middle; width:10%">
                <asp:Button ID="btnAbout" runat="server" BackColor="Transparent" BorderWidth="0px"
                    Font-Names="Verdana" Font-Size="10px" ForeColor="Blue" Text="About Us" Width="65px" Height="14px" 
                    OnClientClick="javascript:return fOpenwindow()" />
                </td>
                <td align="center" style="width:40%;">
                <asp:Label ID="lbl" runat="server" BackColor="Transparent" BorderWidth="0px"
                    Font-Names="Verdana" Font-Size="10px" ForeColor="Blue" 
                        Text="Best View in 1024 x 768 pxl On IE 10, Mozilla 22.0, Chrome 28 " 
                        Height="14px" 
                          />                                       
                </td>
            </tr>
        </table>
        </div>
    </td>
    </tr>
    </table>
</div>

 
</td>
</tr>
</table>
</div>
<div id="divDashBoard" style="display: none; width: 380px;height: 120px;" class="divCircle"   >
        <div id="divClose" style="float: right; width: 15px; height: 15px">
            <a href="#" onclick="return fCloseFind();" style="text-decoration:none; color: Black;">X</a>
        </div>
        <br />
        <table > 
            <tr> 
                <td colspan="4" align="left" valign="top" style="height: 100px">
                   <asp:DataList ID="DataList1" runat="server" Style="position: relative"  RepeatColumns="2" Width="300px" RepeatDirection="Horizontal"  CellSpacing="4" >
                    <ItemTemplate>
                    <table ><tr><td>
                           <asp:Button runat="server" ID="LinkButton1"  Width="160px"  Height="35px" CssClass="MyButton" Text='<%# Eval("Caption") %>'  BorderStyle="None" OnClientClick="return fBindGrid(this.id)" />
                    </td></tr></table>
                     
                    </ItemTemplate> 
                    <SeparatorStyle Width="40px" Height="50px" />
                </asp:DataList>
                </td>
            </tr>
        </table>
    </div>
<asp:HiddenField ID="hidFlag" runat="server" />  
</form>    
</div>
</body>
</html>
