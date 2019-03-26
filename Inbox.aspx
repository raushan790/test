<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="Inbox" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>CampusCare</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="theme/jquery.ui.all.css" rel="stylesheet" />
    <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/shadedborder.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.position.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.core.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.mouse.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.draggable.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.droppable.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.resizable.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.dialog.js"></script>
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
    <style type="text/css">
        .PopUp
        {
            display: block;
            position: absolute;
            z-index: 1002;
            border-radius: 10px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            background: #ceddc0;
            font-size: 11px;
            -moz-border-radius: 2px;
            border-radius: 5px;
            padding: .5em .9em;            
            color: rgba(0,0,0, .8);
            line-height: 1;
            margin: 0px auto;
            box-shadow: 1px 1px 15px rgba(10,150,0,0.7);
            -webkit-border-radius: 2px auto;
            box-shadow: 0px 0px 10px rgba(10,150,0,0.7);
            -moz-box-shadow: 0px 0px 10px rgba(10,150,0,0.7);
            -webkit-box-shadow: 0px 0px 10px rgba(10,150,0,0.7);
        }
    </style>
    <script language="javascript" type="text/javascript">  
    addLoadEvent(pEnableDisable); 
    function pEnableDisable()
    {     
        if(document.getElementById("HidUserToID").value=="")
        { 
            if(document.getElementById("hidEnabl").value=="")
            {
                document.getElementById('divCompose').style.display="none";
                document.getElementById('divInbox').style.display="";          
                document.getElementById('divSendTo').style.display="none";
                document.getElementById('divdet').style.display="none";
                return false;        
            }
            if(document.getElementById("hidEnabl").value=="C")
            {
                document.getElementById('divInbox').style.display="none";
                document.getElementById('divCompose').style.display="";
                document.getElementById('divSendTo').style.display="none"
                document.getElementById('divdet').style.display="none"
                document.getElementById("gvSubTeacher").style.display="none";
                document.getElementById("gvAdmin").style.display="none";
                document.getElementById("gvClassTchr").style.display="none"; 
                return false;    
            }
            else
            {
                document.getElementById('divInbox').style.display="none";
                document.getElementById('divCompose').style.display="";
                document.getElementById('divSendTo').style.display="none"
                document.getElementById('divdet').style.display="none"
                document.getElementById("gvSubTeacher").style.display="none";
                document.getElementById("gvAdmin").style.display="none";
                document.getElementById("gvClassTchr").style.display="none"; 
                return false; 
            }
        }
        else
        {
                document.getElementById('divInbox').style.display="none";
                document.getElementById('divCompose').style.display="";
                document.getElementById('txtMailTo').value=document.getElementById('HidUserToID').value;
                document.getElementById('divSendTo').style.display="none"
                document.getElementById('divdet').style.display="none"
                document.getElementById('divSendTo').style.display="none";
                return false;    
        } 
    }
    
    function fCompose()
    {
        document.getElementById("hidEnabl").value="C";
        document.getElementById('divInbox').style.display="none";
        document.getElementById('divCompose').style.display="";
        document.getElementById('divSendTo').style.display="none";
        document.getElementById("gvSubTeacher").style.display="none";
        document.getElementById("gvAdmin").style.display="";
        document.getElementById("gvsendClas").style.display="none"; 
        document.getElementById("gvClassTchr").style.display="none";
        document.getElementById("gvPrin").style.display="none";
        document.getElementById("chkAdmin").checked= true;
        return false;
    
    }
    

    
    function fStudent(varAdm)
    {         
        if(varAdm=="S")
        {
            document.getElementById("gvsendClas").style.display="";           
            document.getElementById("gvAdmin").style.display="none";                
            document.getElementById("gvSubTeacher").style.display="none";  
            document.getElementById("gvClassTchr").style.display="none";
            document.getElementById("gvPrin").style.display="none";     
            document.getElementById("ChkStudent").checked=true;
            document.getElementById("chkAdmin").checked=false;                 
            document.getElementById("chkSubject").checked=false; 
            document.getElementById("ChkClassTeac").checked=false; 
            document.getElementById("ChkPrinc").checked=false;            
        } 
        else if(varAdm=="SB")
        {
            document.getElementById("gvsendClas").style.display="none";           
            document.getElementById("gvAdmin").style.display="none";
            document.getElementById("gvSubTeacher").style.display="";  
            document.getElementById("gvClassTchr").style.display="none";
            document.getElementById("gvPrin").style.display="none";         
            document.getElementById("ChkStudent").checked=false;
            document.getElementById("chkAdmin").checked=false;              
            document.getElementById("chkSubject").checked=true;      
            document.getElementById("ChkClassTeac").checked=false;
            document.getElementById("ChkPrinc").checked=false;               
        }
        else if(varAdm=="A")
        {   document.getElementById("gvsendClas").style.display="none";           
            document.getElementById("gvAdmin").style.display="";                   
            document.getElementById("gvSubTeacher").style.display="none"; 
            document.getElementById("gvClassTchr").style.display="none";
            document.getElementById("gvPrin").style.display="none";     
            document.getElementById("ChkStudent").checked=false;
            document.getElementById("chkAdmin").checked=true;                
            document.getElementById("chkSubject").checked=false;  
            document.getElementById("ChkClassTeac").checked=false;
            document.getElementById("ChkPrinc").checked=false;              
        }
        else if(varAdm=="T")
        {   document.getElementById("gvsendClas").style.display="none";           
            document.getElementById("gvAdmin").style.display="none";
            document.getElementById("gvClassTchr").style.display="";   
            document.getElementById("gvSubTeacher").style.display="none";
            document.getElementById("gvPrin").style.display="none";   
            document.getElementById("ChkStudent").checked=false;
            document.getElementById("chkAdmin").checked=false;              
            document.getElementById("chkSubject").checked=false;
            document.getElementById("ChkClassTeac").checked=true;
            document.getElementById("ChkPrinc").checked=false; 
        }
        else if(varAdm=="P")
        {   
            document.getElementById("gvPrin").style.display=""; 
            document.getElementById("gvsendClas").style.display="none";           
            document.getElementById("gvAdmin").style.display="none";
            document.getElementById("gvClassTchr").style.display="none";   
            document.getElementById("gvSubTeacher").style.display="none"; 
            document.getElementById("ChkPrinc").checked=true;
            document.getElementById("ChkStudent").checked=false;
            document.getElementById("chkAdmin").checked=false;              
            document.getElementById("chkSubject").checked=false;
            document.getElementById("ChkClassTeac").checked=false;
        } 
            return true;
    
    }    
    
  
    
    
    function fSelectall()
    { 
        var varRow=document.getElementById("gvDetails").getElementsByTagName('tr');
        if(varRow[0].getElementsByTagName('input')[0].checked==true)
        {
            for(var i=1;i<varRow.length;i++)
            {
                varRow[i].getElementsByTagName('input')[0].checked=true; 
            } 
        }
         if(varRow[0].getElementsByTagName('input')[0].checked==false)
        {
            for(var i=1;i<varRow.length;i++)
            {
                varRow[i].getElementsByTagName('input')[0].checked=false; 
            }  
        }
        
     }
       function fSelctedIndexChange(varRow)
        { 
            var RowInd=varRow+1;
            document.getElementById('lbDate').innerHTML=document.getElementById('gvDetails').rows[RowInd].cells[2].firstChild.nodeValue;
            document.getElementById('lbsender').innerHTML=document.getElementById('gvDetails').rows[RowInd].cells[3].firstChild.nodeValue;
            document.getElementById('lbSub').innerHTML=document.getElementById('gvDetails').rows[RowInd].cells[4].firstChild.nodeValue;
            document.getElementById('lbCon').innerHTML= html_entity_Decode(document.getElementById('gvDetails').rows[RowInd].cells[5].firstChild.nodeValue);
            document.getElementById('HidFileDwn').value=document.getElementById('gvDetails').rows[RowInd].cells[7].firstChild.nodeValue;
            document.getElementById('gvDetails').rows[RowInd].cells[2].style.cssText="font-weight: normal;"
            document.getElementById('gvDetails').rows[RowInd].cells[3].style.cssText="font-weight: normal;"
            document.getElementById('gvDetails').rows[RowInd].cells[4].style.cssText="font-weight: normal;"
            if(document.getElementById('HidType').Value = "I")
            {
                pReturnSingle('Read',GetInnerText(document.getElementById('gvDetails').rows[RowInd].cells[1]));
            }
            pfunctionPopUp('divDialog', 'divdet');
            return true;
        
        }
        function html_entity_Decode(str)
        {
                 var ta=document.createElement("textarea");
                 ta.innerHTML=str;
                 return ta.value;
         
        }
     function fShowEbook()
    {     
       if (stripBlanks(document.getElementById('HidFileDwn').value).toLowerCase()=="noimage")
       { 
         pDisplayMessageclient("<%=Session["Type"].ToString() %>","47","");        
         return false;
       }
        var str= document.getElementById('HidFileDwn').value;
        window.open("MTAssignment.aspx?Message=" + document.getElementById('HidFileDwn').value+"")
        return false;
    }
        
    function Validate_On_Save()
    {            
        if(document.getElementById('txtMailFrom').value=="")
        {
            alert('Please Enter From.');
            document.getElementById('txtMailFrom').focus();
            return false;
        }           
        
        
        if(document.getElementById('txtMailTo').value=="")
        {
            alert('Please Enter To User ID.');
            document.getElementById('txtMailTo').focus();
            return false;
        }
         if (document.getElementById('FileUpload1').value != '') {
         var CheckFormat = document.getElementById('FileUpload1').value.split('.');
            if (CheckFormat[CheckFormat.length - 1].toLowerCase() == 'JPG' || CheckFormat[CheckFormat.length - 1].toLowerCase() == 'jpeg' || CheckFormat[CheckFormat.length - 1].toLowerCase() == 'jpg' || CheckFormat[CheckFormat.length - 1].toLowerCase() == 'pdf') 
            { 
            
            }
            else
            {
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","16",""); 
            return false;
            }   
     }      
        return true;
    }
    
    function pFocus(fld)
    {    
        fld.className='FocusText';
    }
    function pBlur(fld)
    {    
        fld.className='MyTextBoxLogin';
    } 
    
function fAssignTO()
        {        
            if(document.getElementById("ChkStudent").checked==true)
            {
                var varUserID="";
                var varRow=document.getElementById("gvsendClas").getElementsByTagName('tr');
                for(var i=1;i<varRow.length;i++)
                {
                   if(varRow[i].getElementsByTagName('input')[0].checked==true) 
                    {
                         varUserID=varUserID+varRow[i].getElementsByTagName('td')[2].innerHTML+',';
                    }       
                }
                if(varUserID!="")
                {
                varUserID=varUserID.substring(0,varUserID.length-1);
                document.getElementById('txtMailTo').value=varUserID;
                }
            }
            
         else  if(document.getElementById("chkSubject").checked==true)
            {
                var varUserID="";
                var varRow=document.getElementById("gvSubTeacher").getElementsByTagName('tr');
                for(var i=1;i<varRow.length;i++)
                {
                   if(varRow[i].getElementsByTagName('input')[0].checked==true) 
                    {
                         varUserID=varUserID+varRow[i].getElementsByTagName('td')[2].innerHTML+',';
                    }          
                }
                if(varUserID!="")
                {
                varUserID=varUserID.substring(0,varUserID.length-1);
                document.getElementById('txtMailTo').value=varUserID;
                }   
            }
          else  if(document.getElementById("chkAdmin").checked==true)
            {
                var varUserID="";
                var varRow=document.getElementById("gvAdmin").getElementsByTagName('tr');
                for(var i=1;i<varRow.length;i++)
                {
                   if(varRow[i].getElementsByTagName('input')[0].checked==true) 
                    {
                         varUserID=varUserID+varRow[i].getElementsByTagName('td')[2].innerHTML+',';
                    }        
                }
                if(varUserID!="")
                {
                varUserID=varUserID.substring(0,varUserID.length-1);
                document.getElementById('txtMailTo').value=varUserID;
                }   
            } 
           else  if(document.getElementById("ChkClassTeac").checked==true)
            {
                var varUserID="";
                var varRow=document.getElementById("gvClassTchr").getElementsByTagName('tr');
                for(var i=1;i<varRow.length;i++)
                {
                   if(varRow[i].getElementsByTagName('input')[0].checked==true) 
                    {
                         varUserID=varUserID+varRow[i].getElementsByTagName('td')[2].innerHTML+',';
                    }          
                }
                if(varUserID!="")
                {
                varUserID=varUserID.substring(0,varUserID.length-1);
                document.getElementById('txtMailTo').value=varUserID;
                }   
            }
            else  if(document.getElementById("ChkPrinc").checked==true)
            {
                var varUserID="";
                var varRow=document.getElementById("gvPrin").getElementsByTagName('tr');
                for(var i=1;i<varRow.length;i++)
                {
                   if(varRow[i].getElementsByTagName('input')[0].checked==true) 
                    {
                         varUserID=varUserID+varRow[i].getElementsByTagName('td')[2].innerHTML+',';
                    }           
                }
                if(varUserID!="")
                {
                varUserID=varUserID.substring(0,varUserID.length-1);
                document.getElementById('txtMailTo').value=varUserID;
                }   
            }
          
            
        }   
     function testColl(id)
    {
    
        var str = id.split('_'); 
         var newID1 = str[0] + '_' + str[1] + '_Label3';
        var varimg=str[0] + '_' + str[1] +'_description_ToggleImage';
        if(document.getElementById(newID1).style.display == 'block')
        { 
            document.getElementById(newID1).style.display = 'none';
            document.getElementById(varimg).src="Images/collapse.jpg";
         }
        else
        { 
            document.getElementById(newID1).style.display = 'block';
             document.getElementById(varimg).src="images/expand.jpg";
        }

    } 
    /*----------Added BY Manju on 19-07-2012-------------------*/
    function  HideComposeBox()
    {
        document.getElementById('divCompose').style.display="none";
        document.getElementById('divSendTo').style.display="none";
        document.getElementById('divdet').style.display="none"; 
    }
    /*----------End of Added BY Manju on 19-07-2012-------------------*/
   
   

       function fSelectAllCheck(varValue)
        {
            var varRow=document.getElementById(varValue).getElementsByTagName('tr');
            if(varRow[0].getElementsByTagName('input')[0].checked==true)
            {
                for(var i=1;i<varRow.length;i++)
                {
                    varRow[i].getElementsByTagName('input')[0].checked=true;                
                }            
            }
             if(varRow[0].getElementsByTagName('input')[0].checked==false)
                {
                   for(var i=1;i<varRow.length;i++)
                    {
                        varRow[i].getElementsByTagName('input')[0].checked=false;                    
                   }    
                }        
        }
function pReturnSingle(varFlag,varValue)
{
    try
    {
        var requestUrl =  "Inbox.aspx?Flag="+encodeURIComponent(varFlag)+"&Value="+varValue+"";
        var responseStream=getAjaxInfo(requestUrl);
        var varAction=eval("(responseStream)");
        return varAction;
    }
    catch (ex)
    {
        return false;
    }
}
function pfunctionPopUp(divParentID, divChildID) {
if(document.getElementById("HidUserToID").value!="")
        fCompose();
             var varWidth = this.outerWidth;
           var varheight = this.outerHeight;  
           document.getElementById(divParentID).style.height =varWidth + "px";
           document.getElementById(divParentID).style.width ="100%";// varWidth + "px";
           document.getElementById(divParentID).style.position = "absolute";
           document.getElementById(divParentID).style.top = "0px";
           document.getElementById(divParentID).style.left = "0px";
           document.getElementById(divParentID).style.display = "inline";
           document.getElementById(divChildID).style.display = '';
           document.getElementById(divChildID).style.top ="80px";
           document.getElementById(divChildID).style.left = "120px";
           if(divChildID=='divSendTo')
           document.getElementById(divChildID).style.left = "100px";
           document.getElementById(divChildID).style.display = "inline"; 
           return false;
       }
       function pClose() {
           fAssignTO();
           document.getElementById('divDialog').style.display = 'none';
           document.getElementById('divdet').style.display = 'none'; 
           document.getElementById('divSendTo').style.display = 'none';
           return false;
       }  
       function Cancel()
       {
           document.getElementById('divDialog').style.display = 'none';
           document.getElementById('divdet').style.display = 'none'; 
           document.getElementById('divSendTo').style.display = 'none';
           return false;
       }
    </script>
</head>
<body class="BodyBackGroupColor">
    <form id="form1" runat="server">
    <div align="center" id="divInbox" style="width:100%;">
        <table style="width: 100%;" class="divParentLogin">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td align="center" colspan="4" class="MyTableHeader">
                                Inbox
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <td style="width: 100px" class="MyLabel">
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return fCompose()"
                                                CssClass="MyPLLinkBtn" Font-Size="Small" Width="60px">Compose</asp:LinkButton>
                                        </td>
                                        <td style="width: 100px" class="MyLabel">
                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="MyPLLinkBtn"
                                                Font-Size="Small" Width="52px">Inbox</asp:LinkButton>
                                        </td>
                                        <td style="width: 100px" class="MyLabel">
                                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="MyPLLinkBtn"
                                                Font-Size="Small">Draft</asp:LinkButton>
                                        </td>
                                        <td style="width: 100px" class="MyLabel">
                                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="MyPLLinkBtn"
                                                Font-Size="Small" Width="40px">Sent</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="center" colspan="3" valign="top">
                                <table>
                                    <tr>
                                        <td class="MyPLLinkBtn">
                                            Mark
                                        </td>
                                        <td style="height: 24px">
                                            <asp:DropDownList ID="ddlSelect" runat="server" CssClass="MyTextBoxLoginLogin" Font-Bold="True"
                                                ForeColor="RoyalBlue">
                                                <asp:ListItem Value="I">Inbox</asp:ListItem>
                                                <asp:ListItem Value="S">As Draft</asp:ListItem>
                                                <asp:ListItem Value="D">As Delete</asp:ListItem>
                                                <asp:ListItem Value="R">As Read</asp:ListItem>
                                                <asp:ListItem Value="UR">As UnRead</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 12px; height: 24px;">
                                            <asp:Button ID="btnSave" runat="server" Font-Bold="True" Height="21px" Text="GO"
                                                Width="37px" OnClick="btnSave_Click" CssClass="MyButtonLogin" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlShubh" runat="server" Width="100%">
                                                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    OnRowDataBound="gvDetails_RowDataBound" EmptyDataText="No Records Found" OnPageIndexChanging="gvDetails_PageIndexChanging"
                                                    CssClass="mGrid" AlternatingRowStyle-CssClass="alt" ForeColor="Black" AllowPaging="True">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="10px" />
                                                            <HeaderStyle Width="10px" />
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChbSelect" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbselectall" runat="server" OnClick="fSelectall()" />
                                                            </HeaderTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="MessageID" HeaderText="MessageID" />
                                                        <asp:BoundField DataField="Date" HeaderText="Date">
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Sender" HeaderText="Sender">
                                                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                            <HeaderStyle HorizontalAlign="Left" Width="110px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Subject" HeaderText="Subject">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Contents" HeaderText="Contents" />
                                                        <asp:BoundField DataField="ReadUnread" HeaderText="ReadUnread" />
                                                        <asp:BoundField DataField="Attachment" HeaderText="Attachment" />
                                                    </Columns>
                                                    <%-- <RowStyle  Font-Size="10px"/>
                            <HeaderStyle CssClass="MyPLGridHeader"  Font-Size="10px" /> --%>
                                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                        NextPageText="Next" PreviousPageText="Previous" />
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
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divCompose">
        <table class="divParentLogin">
            <tr>
                <td colspan="2" align="center" class="MyTableHeader">
                    <asp:Label ID="lblMailSystem" runat="server" Text="Message System-(Compose Box)"
                        CssClass="MyButtonLogin" Width="636px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="MyLabel">
                    From
                </td>
                <td align="left">
                    <asp:TextBox ID="txtMailFrom" runat="server" BorderWidth="1px" CssClass="MyTextBoxLogin"
                        Width="399px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="MyLabel">
                    <a href="#" id="btnTo" onclick="return pfunctionPopUp('divDialog', 'divSendTo')">To</a>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtMailTo" runat="server" BorderWidth="1px" CssClass="MyTextBoxLogin"
                        Width="399px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="MyLabel">
                    Subject
                </td>
                <td align="left">
                    <asp:TextBox ID="txtMailSubject" runat="server" BorderWidth="1px" CssClass="MyTextBoxLogin"
                        Width="399px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="MyLabel" valign="top" style="height: 176px">
                    Message
                </td>
                <td align="left" style="height: 176px">
                    <asp:TextBox ID="txtMessage" runat="server" CssClass="MyTextBoxLogin" Height="166px"
                        TextMode="MultiLine" Width="546px" Onkeypress=" return Restrict_Multiline(event,8000)"></asp:TextBox>
            </tr>
            <tr>
                <td align="right" class="MyLabel" valign="top">
                    Attachment
                </td>
                <td align="left">
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="MyTextBoxLogin" Height="20px"
                        Width="326px" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnSend" runat="server" CssClass="MyButtonLogin" Text="Send" OnClientClick="return Validate_On_Save();"
                                    OnClick="btnSend_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnMailCancel" runat="server" CssClass="MyButtonLogin" Text="Cancel"
                                    OnClick="btnMailCancel_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnClose" runat="server" CssClass="MyButtonLogin" Text="Close" OnClick="btnClose_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <cc1:DragPanelExtender ID="DragPanelExtender1" runat="server" DragHandleID="pnlDragHandle"
        TargetControlID="divSendTo">
    </cc1:DragPanelExtender>
    <asp:Panel ID="divSendTo" runat="server" CssClass="PopUp" Style="height: 500px; width: 580px;
        text-align: center;">
        <asp:Panel ID="pnlSendTo" runat="server">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="pnlDragHandle" runat="server" Style="width: 100%; cursor: move;" CssClass="MyTableHeader">
                            <div class="divPopupContent">
                                Contact Details
                            </div>
                            <div class="divPopUpClose">
                                <a href="#" onclick="return pClose()">X</a>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkAdmin" runat="server" Text="IT Admin" onclick="return fStudent('A');"
                            Font-Italic="True" Font-Size="Small" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chkSubject" runat="server" Text="Subject Teacher" onclick="return fStudent('SB');"
                            Font-Italic="True" Font-Size="Small" />
                    </td>
                    <td>
                        <asp:CheckBox ID="ChkClassTeac" runat="server" Text="Class Teacher" onclick="return fStudent('T');"
                            Font-Italic="True" Font-Size="Small" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="left">
                        <asp:CheckBox ID="ChkStudent" runat="server" Text="Student" onclick="return fStudent('S');"
                            Font-Italic="True" Font-Size="Small" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chkVicePric" runat="server" Text="Vice Principal" Font-Italic="True"
                            Font-Size="Small" Visible="false" />
                    </td>
                    <td>
                        <asp:CheckBox ID="ChkPrinc" runat="server" Text="Principal" Font-Italic="True" Font-Size="Small"
                            Visible="true" onclick="return fStudent('P');" />
                    </td>
                </tr>
                <%--<tr>
                <td align="right" colspan="5">
                </td>
            </tr>--%>
            </table>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:Panel ID="Panel1" runat="server" Height="400px" CssClass="MyTableBorder" ScrollBars="Auto"
                            Width="100%">
                            <asp:GridView ID="gvsendClas" runat="server" AutoGenerateColumns="False" Width="100%"
                                EmptyDataText="No Records Found" CssClass="mGrid" AlternatingRowStyle-CssClass="alt"
                                OnRowDataBound="gvsendClas_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="Chkselall" runat="server" onclick="fSelectAllCheck('gvsendClas')" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSel" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UID" HeaderText="UID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UserID" HeaderText="UserID" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="#FFC0C0" />
                                <HeaderStyle CssClass="MyPLGridHeader" />
                            </asp:GridView>
                            <asp:GridView ID="gvSubTeacher" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt" Width="100%" OnRowDataBound="gvSubTeacher_RowDataBound1"
                                EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="Chkseletedall" runat="server" onclick="fSelectAllCheck('gvSubTeacher')" />
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UID" HeaderText="UID" />
                                    <asp:BoundField DataField="UserID" HeaderText="UserID" />
                                    <asp:BoundField DataField="SubjectName1" HeaderText="Subject" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="gvClassTchr" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt" Width="100%" EmptyDataText="No Record Found"
                                OnRowDataBound="gvClassTchr_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="Chkseletedall" runat="server" onclick="fSelectAllCheck('gvClassTchr')" />
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UID" HeaderText="UID" />
                                    <asp:BoundField DataField="UserID" HeaderText="UserID" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="gvAdmin" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt" EmptyDataText="No Record Found" OnRowDataBound="gvAdmin_RowDatabound"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="Chkseletedall" runat="server" onclick="fSelectAllCheck('gvAdmin')" />
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UID" HeaderText="UID" />
                                    <asp:BoundField DataField="UserID" HeaderText="UserID" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="gvPrin" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt" EmptyDataText="No Record Found" OnRowDataBound="gvPrin_RowDatabound"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="Chkseletedall" runat="server" onclick="fSelectAllCheck('gvPrin')" />
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UID" HeaderText="UID" />
                                    <asp:BoundField DataField="UserID" HeaderText="UserID" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button ID="btnOK" runat="server" CssClass="MyButtonLogin" OnClientClick="return pClose();"
            Text="OK" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="MyButtonLogin"
            OnClientClick="return Cancel();" />
    </asp:Panel>
    <cc1:DragPanelExtender ID="DragPanelExtender2" runat="server" DragHandleID="pnlHandel"
        TargetControlID="divdet">
    </cc1:DragPanelExtender> 
    <asp:Panel ID="divdet" runat="server" CssClass="PopUp" Style="height: 400px; width: 500px;
        text-align: center;">     
        <div id="pnlHandel" style="width: 100%; cursor: move;" class="MyTableHeader">
            <div class="divPopupContent">
                <asp:Label ID="lblFeeHeader" Font-Bold="true" Text="Message Details" runat="server"></asp:Label></div>
            <div class="divPopUpClose">
                <a href="#" onclick="return pClose()">X</a></div>
        </div>
        <div style="width: 100%; height: 370px; overflow: auto;">
            <table>
                <tr>
                    <td style="width: 24px" class="MyLabel">
                        Sender
                    </td>
                    <td style="width:100%" align="left">
                        <asp:Label ID="lbsender" runat="server" Text="Label" Width="100%" CssClass="MyLabel"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 24px;" colspan="2" class="MyLabel">
                        <hr style="width: 100%" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 24px" class="MyLabel">
                        Date
                    </td>
                    <td style="width: 100%" align="left">
                        <asp:Label ID="lbDate" runat="server" Text="Label" Width="236px" CssClass="MyLabel"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="MyLabel">
                        <hr style="width: 100%" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 24px" class="MyLabel">
                        Subject
                    </td>
                    <td style="width:100%;text-align:justify;" align="left">
                        <asp:Label ID="lbSub" runat="server" Text="Label" Width="100%" CssClass="MyLabel"></asp:Label>
                    </td>
                </tr>
                <tr>
                <td colspan="2" class="MyLabel">
                    <hr style="width: 100%" />
                </td>
                </tr>
               <%-- <tr>
                    <td style="width: 24px" class="MyLabel">
                        &nbsp;
                    </td>
                    <td style="width: 100%">
                        &nbsp;
                    </td>
                </tr>--%>
                <tr>
                    <td style="width: 24px">
                        <asp:LinkButton ID="LinkButton5" runat="server" OnClientClick="javascript:return fShowEbook()"
                            Font-Size="Small">Download</asp:LinkButton>
                    </td>
                    <td style="width: 100%">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" valign="top" width="100%">
                        <%-- <asp:Label ID="lbCon" runat="server" Text="Label" Width="390px"></asp:Label>--%>
                        <div id="lbCon" contenteditable="true" style="width:100%; height: 300x; border: 2px solid grau;text-align:justify;">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
     </asp:Panel>
    <asp:HiddenField ID="hidEnabl" runat="server" />
    <asp:HiddenField ID="hidAdmin" runat="server" />
    <asp:HiddenField ID="HidPrincipal" runat="server" />
    <asp:HiddenField ID="HidClassteac" runat="server" />
    <asp:HiddenField ID="HidVicePrinc" runat="server" />
    <asp:HiddenField ID="HidUserToID" runat="server" />
    <asp:HiddenField ID="HidAttach" runat="server" />
    <asp:HiddenField ID="HidFilename" runat="server" />
    <asp:HiddenField ID="HidFileDwn" runat="server" />
    <asp:HiddenField ID="HidType" runat="server" />
    <asp:Button ID="Click" runat="server" Text="Button" Style="display: none" />
    <div id="Blank" runat="server" style="height: 350px;">
    </div>
    <div id="divDialog" style="filter: alpha(Opacity=50); opacity: 0.5; background-color: rgb(102,102,102);">
    </div>
    </form>
</body>
</html>
