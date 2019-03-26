<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MonthControl.ascx.cs" Inherits="MonthControl" %>
<style type="text/css">
.MyMonthLabel
{	
    FONT-SIZE: 9pt;
    FONT-FAMILY: Arial;
    }
.MyMonthText
{font-size :9pt;
	FONT-FAMILY: Arial;
	/*border-color:#8CDAFF;*/
	border-color:#000000;
	border-width:1px;
	border-style:solid;
	
	 
}
.MyCalenderButtonUP
{font-size :5pt;
border-color:InactiveCaption;
FONT-FAMILY:Webdings;
border-width:1px;
width:15px;
height:10px;
COLOR:#400000;	
FONT-WEIGHT: normal;
text-align:center;
valign:top;
padding:0;
margin:0;
}
.MyCalenderButtonDOWN
{font-size :5pt;
border-color:InactiveCaption;
FONT-FAMILY:Webdings;
border-width:1px;
width:15px;
height:10px;
COLOR:#400000;	
FONT-WEIGHT: normal;
text-align:center;
valign:top;
padding:0;
margin:0;
}
</style>
<%--<script type="text/javascript" language="javascript">
     var varObject='Month';
     var vartxtFinMonth='<%=strtxtFinMonth %>';
     var vartxtYear='<%=strtxtYear %>';
     var varbtnUpMonth='<%=strbtnUpMonth %>';
     var varbtnDownMonth='<%=strbtnDownMonth %>';
     var varbtnUpYear='<%=strbtnUpYear %>';
     var varbtnDownYear='<%=strbtnDownYear %>';
     var strhdnDate='<%=strhdnDate %>';
function pAdjust(varObject)
{
debugger;
    if (varObject=='Year')
    {
        document.getElementById(vartxtYear).select();
        document.getElementById(varbtnUpMonth).style.display='none';
        document.getElementById(varbtnDownMonth).style.display='none';
        document.getElementById(varbtnUpYear).style.display='block';
        document.getElementById(varbtnDownYear).style.display='block';
    }
    else
    {
        document.getElementById(vartxtFinMonth).select();
        document.getElementById(varbtnUpMonth).style.display='block';
        document.getElementById(varbtnDownMonth).style.display='block';
        document.getElementById(varbtnUpYear).style.display='none';
        document.getElementById(varbtnDownYear).style.display='none';
    }
}
function validateValue(varValue)
{
    var varDate=new Date();
     var arrMonth=new Array("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");
     
     document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
    if (varValue=='Month')
    {
        if (isNaN(document.getElementById(vartxtFinMonth).value)==false)
        {
            if (Number(document.getElementById(vartxtFinMonth).value)<=12 && Number(document.getElementById(vartxtFinMonth).value)>=1)
            {
                document.getElementById(vartxtFinMonth).value=arrMonth[Number(document.getElementById(vartxtFinMonth).value)-1];
            }
            else
            {
                document.getElementById(vartxtFinMonth).value=arrMonth[varDate.getMonth()];
            }
        }
    }
    else
    {
        if (isNaN(document.getElementById(vartxtYear).value)==false)
        {
            if (Number(document.getElementById(vartxtYear).value)<=2099 && Number(document.getElementById(vartxtYear).value)>=1900)
                return true;
            else if (Number(document.getElementById(vartxtYear).value)<=99 && Number(document.getElementById(vartxtYear).value)>=0)
                document.getElementById(vartxtYear).value=2000 + Number(document.getElementById(vartxtYear).value);
            else
                document.getElementById(vartxtYear).value=varDate.getFullYear();
        }
    }
    document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
}
function fClick(e)
{
    var varkey;
     if(window.event)
        varkey=window.event.keyCode;
     else
        varkey=e.which;  
    if (varkey==40)
    {
        document.getElementById(varbtnDownMonth).click();
        return false;
    }
    else if(varkey==38)
    {
        document.getElementById(varbtnUpMonth).click();
        return false;
    }
    else if ((varkey>=96 && varkey<=105) || (varkey>=48 && varkey<=57) || varkey==8 || varkey==46)
    {
        if (isNaN(document.getElementById(vartxtFinMonth).value)==true) document.getElementById(vartxtFinMonth).value='';
        //alert(isNaN(document.getElementById(vartxtFinMonth).value));
        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
        return true;
    }
    else if (varkey==9)
    {
        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
        return true;
    }
    else
        return false;
}
function fYearClick(e)
{
    var varkey;
     if(window.event)
        varkey=window.event.keyCode;
     else
        varkey=e.which;   
    if (varkey==40)
    {
        document.getElementById(varbtnUpYear).click();
        return false;
    }
    else if(varkey==38)
    {
        document.getElementById(varbtnDownYear).click();
        return false;
    }
     else if ((varkey>=96 && varkey<=105 ) || (varkey>=48 && varkey<=57) || varkey==8 || varkey==46 || varkey==9)
        return true;
    else
        return false;
}
function ChangeYearValue(varPm,varType,varTargetID)
{
debugger;
    var varDate=new Date();
     var arrMonth=new Array("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");
    if (varPm=='DOWN')
    {

        if (varType=='Month')
        {
            
            for (var varForLoop=0;varForLoop<=arrMonth.length-1;varForLoop++)
            {
                if (arrMonth[varForLoop]==document.getElementById(varTargetID).value)
                {
                    if (varForLoop==0) 
                    {
                        document.getElementById(varTargetID).value=arrMonth[arrMonth.length-1];
                        document.getElementById(varTargetID).select();
                        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
                        return false
                    }
                    else
                    {
                        document.getElementById(varTargetID).value=arrMonth[varForLoop-1];
                        document.getElementById(varTargetID).select();
                        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
                        return false
                    }
                }
            }
            document.getElementById(varTargetID).value=arrMonth[varDate.getMonth()];
            document.getElementById(varTargetID).select();
            document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
            return false
        }
        else if (varType=='Year')
        {
            if (document.getElementById(varTargetID).value=='')  document.getElementById(varTargetID).value=varDate.getFullYear()-1;
            document.getElementById(varTargetID).value=Number(document.getElementById(varTargetID).value)+1;
            if (document.getElementById(varTargetID).value>2099)
                document.getElementById(varTargetID).value=1900;
            document.getElementById(varTargetID).select();
            document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
            return false;
        }
    }
    else
    {
       if (varType=='Month')
       {
            for (var varForLoop=0;varForLoop<=arrMonth.length-1;varForLoop++)
            {
                if (arrMonth[varForLoop]==document.getElementById(varTargetID).value)
                {
                   if (varForLoop==arrMonth.length-1)
                    {
                        document.getElementById(varTargetID).value=arrMonth[0];
                        document.getElementById(varTargetID).select();
                        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
                        return false
                    }
                    else
                    {
                        document.getElementById(varTargetID).value=arrMonth[varForLoop+1];
                        document.getElementById(varTargetID).select();
                        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
                        return false
                    }
                }
            }
            document.getElementById(varTargetID).value=arrMonth[varDate.getMonth()];
            document.getElementById(varTargetID).select();
            document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
            return false
       }
       else if (varType=='Year')
       { 
            if (document.getElementById(varTargetID).value=='')  document.getElementById(varTargetID).value=varDate.getFullYear()+1;
            document.getElementById(varTargetID).value=Number(document.getElementById(varTargetID).value)-1;
            if (document.getElementById(varTargetID).value<1900)
                document.getElementById(varTargetID).value=2099;
            document.getElementById(varTargetID).select();
            document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
             return false;
        }
       
    }
    document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
    return false;
}

</script>--%>

<table border="0" cellpadding="0" cellspacing="0" style="border-top-width: 0px; border-left-width: 0px;
    border-bottom-width: 0px; border-right-width: 0px">
    <tr>
        <td align="right" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
            border-right-width: 0px" valign="middle">
            <table border="0" cellpadding="0" cellspacing="0" style="border-top-width: 0px; border-left-width: 0px;
                border-bottom-width: 0px; border-right-width: 0px">
                <tr>
                    <td style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                        height: 21px; border-right-width: 0px">
                        <asp:TextBox ID="txtFinMonth" runat="server" CssClass="MyMonthText" onfocus="return pAdjust('Month',this.id)"
                            onblur="return validateValue('Month',this.id)" onkeydown="return fClick(event)" ReadOnly="false"
                            Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #8cdaff;
                            border-bottom-width: 1px; border-bottom-color: #8cdaff; border-top-color: #8cdaff;
                            text-align: right; border-right-width: 0px; border-right-color: #8cdaff" Width="75px">April</asp:TextBox></td>
                    <td style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                        height: 21px; border-right-width: 0px">
                        <asp:TextBox ID="txtYear" runat="server" CssClass="MyMonthText" MaxLength="4" onfocus="return pAdjust('Year',this.id)"
                            onblur="return validateValue('Year',this.id)" onkeydown="return fYearClick(event)"
                            ReadOnly="false" Style="border-top-width: 1px; border-left-width: 0px; border-left-color: #8cdaff;
                            border-bottom-width: 1px; border-bottom-color: #8cdaff; border-top-color: #8cdaff;
                            text-align: right; border-right-width: 0px; border-right-color: #8cdaff" Width="36px">2009</asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td align="left" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
            border-right-width: 0px" valign="middle">
            <table border="0" cellpadding="0" cellspacing="0" style="border-top-width: 0px; border-left-width: 0px;
                border-bottom-width: 0px; border-right-width: 0px">
                <tr>
                    <td align="left" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px;
                        border-right-width: 0px" valign="top">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnUpYear" runat="server" BorderColor="Black" BorderStyle="Solid"
                                        BorderWidth="1px" CssClass="MyCalenderButtonUP"
                                        Style="display: none; border-bottom-width: 1px" Text="5" Font-Bold="True" Font-Names="Webdings" Font-Size="5pt" UseSubmitBehavior="False" /><asp:Button ID="btnDownYear" runat="server" BorderColor="#404040" BorderStyle="Solid"
                                        BorderWidth="1px" CssClass="MyCalenderButtonDOWN"
                                        Style="display: none" Text="6" Font-Bold="True" Font-Names="Webdings" Font-Size="5pt" UseSubmitBehavior="False" />
                                    <asp:Button ID="btnUpMonth" runat="server" BorderColor="#404040" BorderStyle="Solid"
                                        BorderWidth="1px" CssClass="MyCalenderButtonUP"
                                        Style="display: block; border-bottom-width: 1px" Text="5" Font-Bold="True" Font-Names="Webdings" Font-Size="5pt" UseSubmitBehavior="False" />
                                    <asp:Button ID="btnDownMonth" runat="server" BorderColor="Black" BorderStyle="Solid"
                                        BorderWidth="1px" CssClass="MyCalenderButtonDOWN"
                                        Style="display: block" Text="6" Font-Bold="True" Font-Names="Webdings" Font-Size="5pt" UseSubmitBehavior="False" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:HiddenField ID="Date" runat="server" />
