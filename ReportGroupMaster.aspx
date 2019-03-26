<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportGroupMaster.aspx.cs" Inherits="ReportGroupMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>::CampusCare Online ::-Report Group Master</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
     <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
     <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
      <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
      <script language="javascript" type="text/javascript">
        addLoadEvent(fEnableDisable);       
        function fEnableDisable() 
        {       
        // debugger;
            document.getElementById('divSelectDeSelect').style.display='none';
            document.getElementById('trReportGroup').style.display='none';           
            var strArray=document.getElementById('hidFlag').value.split('^');       
            if (document.getElementById('hidFlag').value=="")
            {
                document.getElementById('ddlModuleID').disabled=true;
                document.getElementById('btnNew').disabled=false;
                document.getElementById('btnSave').disabled=true;
                document.getElementById('btnEdit').disabled=true;
                document.getElementById('btnDelete').disabled=true;
                document.getElementById('txtReportGroupName1').readOnly=true;
                document.getElementById('txtReportGroupName2').readOnly=true;
                document.getElementById('txtpriority').readOnly=true;
                if((document.getElementById('chkReportName'))!=null)
                {
                    var varchkList=document.getElementById('chkReportName').getElementsByTagName('input');
                    for(var i=0;i<varchkList.length;i++)
                    {
                        varchkList[i].disabled=true;
                    }
               }                
            }
            if(document.getElementById('hdnVal').value=="AB")
            {
                document.getElementById('btnNew').disabled=true;
                document.getElementById('btnSave').disabled=false;
                 document.getElementById('btnEdit').disabled=true;
                document.getElementById('btnDelete').disabled=true;
                document.getElementById('txtReportGroupName1').readOnly=false;
                document.getElementById('txtReportGroupName2').readOnly=false;
                document.getElementById('pnlClassSection').disabled=false;
                 document.getElementById('txtpriority').readOnly=false;
                if((document.getElementById('chkReportName'))!=null)
                {
                    var varchkList=document.getElementById('chkReportName').getElementsByTagName('input');
                    for(var i=0;i<varchkList.length;i++)
                    {
                        varchkList[i].disabled=false;
                    }
                }                   
            }

            else if (document.getElementById('hidFlag').value!="")
            {
            
                document.getElementById('btnNew').disabled=true;
                document.getElementById('btnSave').disabled=true;
                 document.getElementById('btnEdit').disabled=false;
                document.getElementById('btnDelete').disabled=false;
                document.getElementById('txtReportGroupName1').readOnly=false;
                document.getElementById('txtReportGroupName2').readOnly=false;
                document.getElementById('txtpriority').readOnly=false;
            }
            if(strArray[0]=="E")
           
            {
                document.getElementById('ddlModuleID').disabled=true;
                document.getElementById('btnEdit').disabled=false;              
                document.getElementById('btnDelete').disabled=false;               
                document.getElementById('btnNew').disabled=true;
                document.getElementById('btnSave').disabled=true;
                document.getElementById('pnlClassSection').disabled=true; 
                document.getElementById('txtReportGroupName1').readOnly=true;
                document.getElementById('txtpriority').readOnly=true;
                if((document.getElementById('chkReportName'))!=null)
                {
                    var varchkList=document.getElementById('chkReportName').getElementsByTagName('input');
                    for(var i=0;i<varchkList.length;i++)
                    {
                        varchkList[i].disabled=true;
                    }
                }                                
                }
                if(strArray[0]=="E'")
                {
                    document.getElementById('txtReportGroupName1').readOnly=false;
                    document.getElementById('txtReportGroupName2').readOnly=false;
                    document.getElementById('txtpriority').readOnly=false;        
                    document.getElementById('txtReportGroupName1').focus();
                    document.getElementById('ddlModuleID').disabled=false; 
                    //document.getElementById('ddlCurrency').disabled=false; 
                    //document.getElementById('ddlModuleID').value=GetInnerText(document.getElementById('gvReportGroup').rows[intRowIndex+1].cells[4]);
                    document.getElementById('pnlClassSection').disabled=false; 
                    if((document.getElementById('chkReportName'))!=null)
                    {
                        var varchkList=document.getElementById('chkReportName').getElementsByTagName('input');
                        for(var i=0;i<varchkList.length;i++)
                        {
                            varchkList[i].disabled=false;
                        }
                    }                 
                    document.getElementById('btnNew').disabled=true;
                    document.getElementById('btnEdit').disabled=true;
                    document.getElementById('btnSave').disabled=false;
                    document.getElementById('btnDelete').disabled=true;
                    fChangeButtonColor('frmReportGroupMaster','#400000');
                }
            
            fChangeButtonColor('frmReportGroupMaster','#400000');
            }                           
        
 function fAssign_New()
    {
 
        if(fUserLimit('N')==false)
        {
            return false;
        }        
        document.getElementById('hidFlag').value='N^N^N^N';
        document.getElementById('txtReportGroupName1').readOnly=false;
        document.getElementById('txtReportGroupName2').readOnly=false;
        document.getElementById('txtpriority').readOnly=false;
        document.getElementById('txtReportGroupName1').focus();
        document.getElementById('ddlModuleID').disabled=false; 
       // document.getElementById('ddlCurrency').disabled=false; 
        document.getElementById('btnNew').disabled=true;
        document.getElementById('btnEdit').disabled=true;
        document.getElementById('btnSave').disabled=false;
        document.getElementById('btnDelete').disabled=true;       
        if(document.getElementById('chkReportName')!=null)
        {
            document.getElementById('btnNew').disabled=true;
            document.getElementById('btnSave').disabled=false;
            var varchkList=document.getElementById('chkReportName').getElementsByTagName('input');
            for(var i=0;i<varchkList.length;i++)
            {
                varchkList[i].disabled=false;
            }
        }        
        fChangeButtonColor('frmReportGroupMaster','#400000');
        return false;
    }
       
    function fAssign_Edit()
    {
  
        if(fUserLimit('E')==false)
        {
            return false;
        }
        document.getElementById('txtReportGroupName1').readOnly=false;
        document.getElementById('txtReportGroupName2').readOnly=false;
        document.getElementById('txtpriority').readOnly=false;        
        document.getElementById('txtReportGroupName1').focus();
        document.getElementById('ddlModuleID').disabled=false; 
        //document.getElementById('ddlCurrency').disabled=false; 
            document.getElementById('pnlClassSection').disabled=false; 
                if((document.getElementById('chkReportName'))!=null)
                {
                    var varchkList=document.getElementById('chkReportName').getElementsByTagName('input');
                    for(var i=0;i<varchkList.length;i++)
                    {
                        varchkList[i].disabled=false;
                    }
                }                 
        document.getElementById('btnNew').disabled=true;
        document.getElementById('btnEdit').disabled=true;
        document.getElementById('btnSave').disabled=false;
        document.getElementById('btnDelete').disabled=true;
        fChangeButtonColor('frmReportGroupMaster','#400000');
        return false;
    }

document.onclick=fInvisibleMenu;   
function fInvisibleMenu()
{
 document.getElementById('divSelectDeSelect').style.display='none';
}    
 
function fClassSubject(eType)
 {
    //alert(document.getElementById('chkReportName').rows.cells.length);
    //return false;
    var varSelectedVoucher;
    if(document.getElementById('chkReportName')!=null)
    if(document.getElementById('chkReportName').rows.length>0)
    for(var i=0;i<document.getElementById('chkReportName').rows.length;i++)
    {
        //debugger;
        for(var j=0;j<document.getElementById('chkReportName').rows[i].cells.length;j++)
        {
             if(document.getElementById('chkReportName').rows[i].cells[j].firstChild!=null)
            if(eType==1)
            {
                document.getElementById('chkReportName').rows[i].cells[j].firstChild.checked=true;
            }
            else
            { 
                document.getElementById('chkReportName').rows[i].cells[j].firstChild.checked=false;
            }
        }
    }
    document.getElementById('divSelectDeSelect').style.display='none';
    return false;
 }

  function fSelectDeSelect(e)
 {  
    if(document.getElementById('btnSave').disabled == true)
        return false;        
    var xPosition=getPosition(e).x+5;
    var yPosition=getPosition(e).y+5;
    document.getElementById('divSelectDeSelect').style.position="absolute";
    document.getElementById('divSelectDeSelect').style.top = String(yPosition)+"px";
    document.getElementById('divSelectDeSelect').style.left = String(xPosition)+"px";
    document.getElementById('divSelectDeSelect').style.display = "inline";
    return false;
 }


      function fUserLimit(varVal)
      {
        //debugger;
           if(varVal=="N")
            {
                
                var strNew=document.getElementById('hidCache').value.split(';')[0];
                if(strNew!="Y")
                {
                    pDisplayMessageclient("<%=Session["Type"].ToString() %>","1","");
                    return false;
                }
            }
            else if(varVal=="E")
            {
                var strEdit=document.getElementById('hidCache').value.split(';')[1];
                if(strEdit!="Y")
                {
                    pDisplayMessageclient("<%=Session["Type"].ToString() %>","2","");
                    return false;   
                }
            }
            else if(varVal=="D")
            {
                var strEdit=document.getElementById('hidCache').value.split(';')[2];
                if(strEdit!="Y")
                {
                    pDisplayMessageclient("<%=Session["Type"].ToString() %>","3","");
                    return false;   
                }
            }
        }
    function fCheckEntry()
    {  
    //debugger;
      var strArray=document.getElementById('hidFlag').value.split('^');
           if(strArray[0]=='N' || strArray[0]=='E')
           {
           
             if(document.getElementById('chkReportName')==null)
             {
               alert('There Is No More Report In This Module');
               return false;
             }
           }
    
    
    
    
        if (stripBlanks(document.getElementById('txtReportGroupName1').value)=='')
        {
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblReportGroupName1').innerHTML);                
            document.getElementById('txtReportGroupName1').focus();
            return false;
         }
//         if (stripBlanks(document.getElementById('txtReportGroupName2').value)=='')
//        {
//            pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblFeeGroupName2').innerHTML);                
//            document.getElementById('txtReportGroupName2').focus();
//            return false;
//         }
         if(document.getElementById('ddlModuleID').value==0)
         {
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","8","" + document.getElementById('lblReportModuleID').innerHTML);                
            document.getElementById('ddlModuleID').focus();
            return false;
         } 
         if(Number(stripBlanks(document.getElementById('txtpriority').value)==""))
        {  pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblpriority').innerHTML);
            document.getElementById('txtpriority').focus();
            return false;
        }
        if(Number(document.getElementById('txtpriority').value)==0)
        {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","6","");
            document.getElementById('txtpriority').focus();
            return false;
        }    
//           if(strArray[0]=="E" && strArray[2]==document.getElementById('txtReportGroupName1').value  && strArray[6]==document.getElementById('txtpriority').value)
//        {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","4","");
//            document.getElementById('txtReportGroupName1').focus();
//            return false;
//        }  
            var strFlag;
           
           if(strArray[0]=='N' || strArray[0]=='E')
           {
         for(varLoop = 0 ; varLoop< document.getElementById("chkReportName").rows[0].cells.length;varLoop++)
         {
               var varchkList=document.getElementById('chkReportName').getElementsByTagName('input');
                for(var i=0;i<varchkList.length;i++)
                {
                    if(varchkList[i].checked==true)
                    {
                      strFlag ='C';
                    }
                }
         }
         if(strFlag!="C")
         {
             //pDisplayMessageclient("<%=Session["Type"].ToString() %>","1004_1","");
             alert("Please Select Report");
              return false;
         }
        
        }   
    }
     function fValidate_On_Delete()
        {
          if(fUserLimit('D')==false)
            {
                 return false;
            }
            if(confirm(pDisplayMessageclient("<%=Session["Type"].ToString() %>","5","")))
            {
                 return true;
            }     
            else
            {
                 return false;    
            }     
        }
    var varSelRow=null
     var varSelRowIndex=-1
    function fGridDoubleClick(intRowIndex)
    {    
        if (intRowIndex!=-1)
        {
                if(varSelRow!=null)
                { 
                    if(varSelRowIndex % 2 == 0 )
                        varSelRow.style.cssText="font-weight: normal; background: #fff;"
                    else   
                        varSelRow.style.cssText="font-weight: normal;"
                }  
                document.getElementById('gvReportGroup').rows[intRowIndex+1].style.cssText="color: green; font-weight: bold; cursor: pointer;  background: #ffc0cb;"
                varSelRow=document.getElementById('gvReportGroup').rows[intRowIndex+1];
                varSelRowIndex=intRowIndex;                                                                                       
                document.getElementById('txtReportGroupName1').value=GetInnerText(document.getElementById('gvReportGroup').rows[intRowIndex+1].cells[2]);
                document.getElementById('ddlModuleID').value=GetInnerText(document.getElementById('gvReportGroup').rows[intRowIndex+1].cells[4]);
                document.getElementById('txtpriority').value=GetInnerText(document.getElementById('gvReportGroup').rows[intRowIndex+1].cells[5]);
                document.getElementById('hidFlag').value="E"+"^"+document.getElementById('gvReportGroup').rows[intRowIndex+1].cells[1].firstChild.nodeValue+"^"+GetInnerText(document.getElementById('gvReportGroup').rows[intRowIndex+1].cells[2])+"^"+intRowIndex+"^"+document.getElementById('gvReportGroup').rows[intRowIndex+1].cells[3].firstChild.nodeValue+"^"+document.getElementById('gvReportGroup').rows[intRowIndex+1].cells[4].firstChild.nodeValue+"^"+document.getElementById('gvReportGroup').rows[intRowIndex+1].cells[5].firstChild.nodeValue;                
             
                document.getElementById('ddlModuleID').disabled=true;
                document.getElementById('btnEdit').disabled=false;
                document.getElementById('btnDelete').disabled=false;
                document.getElementById('btnNew').disabled=true;
                document.getElementById('btnSave').disabled=true;
                document.getElementById('pnlClassSection').disabled=true; 
                document.getElementById('btnSelect').click(); 
                if((document.getElementById('chkReportName'))!=null)
                {
                    var varchkList=document.getElementById('chkReportName').getElementsByTagName('input');
                    for(var i=0;i<varchkList.length;i++)
                    {
                        varchkList[i].disabled=true;
                    }
                }         
                fChangeButtonColor('frmReportGroupMaster','#400000');
                return false;                     
        }
    }
    
    function pFocus(fld)
    {    
    fld.className='FocusText';
    }
    function pBlur(fld)
    {    
    fld.className='MyText';
    }
   function fddlBind()
    {  //debugger;
            //document.getElementById('btnNew').disabled=true;
           // document.getElementById('btnEdit').disabled=true;
           // document.getElementById('btnSave').disabled=false;
           // document.getElementById('btnDelete').disabled=true;
            document.getElementById('btnNew').disabled=true;
            document.getElementById('btnEdit').disabled=true;
            document.getElementById('btnSave').disabled=false;
            document.getElementById('btnDelete').disabled=true;
            fChangeButtonColor('frmReportGroupMaster','#400000');
            document.getElementById('btnBind').click();
           return true;
    }

      </script>
</head>
<body style="background-image:url(Images/backgroundImg.jpg); background-repeat :repeat ; background-position: center center ; background-attachment: scroll;"  dir="<%=strType %>">
    <form id="frmReportGroupMaster" runat="server" dir="<%=strType %>" onpaste="return false;">
    <div align="center">
         <table>
            <tr>
                <td class="divCircle">
                    <table class="MyTableBorder">
                        <tr>
                            <td align="center" class="MyTableHeader" colspan="6">
                                <asp:Label ID="trReportGroupName" runat="server" CssClass="MyLabelHeader" Text="Report Group Master"></asp:Label></td>
                                
                            <td align="center" class="MyTableHeader" colspan="1">
                                <asp:Label ID="lblOptions" runat="server" CssClass="MyLabelHeader" Text="Options"></asp:Label></td>
                        </tr>
                        <tr>                                                   
                                <td align="right" class="MyLabel" style="height: 22px">
                                <asp:Label ID="lblReportGroupName1" runat="server" CssClass="MyLabel" Text="Report Group" ></asp:Label></td>
                            <td align="left" colspan="5" style="width: 476px">
                                <asp:TextBox ID="txtReportGroupName1" runat="server" Width="282px" CssClass="MyTextBox" MaxLength="60" TabIndex="1"></asp:TextBox>&nbsp;
                                <asp:Label ID="lblpriority" runat="server" CssClass="MyLabel" Text="Priority" ></asp:Label>
                                <asp:TextBox ID="txtpriority" runat="server" Width="82px" CssClass="MyTextBox" MaxLength="4" TabIndex="2"></asp:TextBox>&nbsp;
                                </td>
                                <td align="left" colspan="1" rowspan="4" valign="top">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnNew" runat="server" CssClass="MyButton" OnClientClick="return fAssign_New()"
                                                TabIndex="6" Text="New" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnEdit" runat="server" CssClass="MyButton" OnClientClick="return fAssign_Edit()"
                                                TabIndex="7" Text="Edit" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" CssClass="MyButton" OnClick="btnSave_Click"
                                                OnClientClick="return fCheckEntry()" TabIndex="8" Text="Save" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnDelete" runat="server" CssClass="MyButton" OnClick="btnDelete_Click"
                                                OnClientClick="return fValidate_On_Delete()" TabIndex="9" Text="Delete" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" CssClass="MyButton" OnClick="btnCancel_Click"
                                                TabIndex="10" Text="Cancel" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnExport" runat="server" CssClass="MyButton" OnClick="btnExport_Click"
                                                TabIndex="11" Text="Export" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnClose" runat="server" CssClass="MyButton" OnClick="btnClose_Click"
                                                TabIndex="12" Text="Close" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="trReportGroup">
                            <td align="right" class="MyLabel" style="height: 22px">
                                <asp:Label ID="lblReportGroupName2" runat="server" CssClass="MyLabel" Text="Name(Arabic)" ></asp:Label></td>
                            <td align="left" colspan="5" style="height: 22px; width: 476px;">
                                <asp:TextBox ID="txtReportGroupName2" runat="server" CssClass="MyTextBox" Width="426px" TabIndex="3" MaxLength="60"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblReportModuleID" runat="server" CssClass="MyLabel" Text="Module Name" ></asp:Label></td>
                            <td align="left">
                                <asp:DropDownList ID="ddlModuleID" runat="server" CssClass="MyTextBox" Width="430px" TabIndex="4"  onchange="javascript:return fddlBind()" >
                                </asp:DropDownList></td>
                            
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblReportName" runat="server" Text="Report Name" CssClass="MyLabel" ></asp:Label></td>
                            <td align="left" colspan="5" valign="top" style="width: 476px">
                            <asp:Panel ID="pnlClassSection" runat="server" Height="100px" ScrollBars="Vertical" BorderWidth="1px" Width="440px">
                        <asp:CheckBoxList ID="chkReportName" runat="server" Width="100%" CssClass="MyLabel" CellPadding="0" CellSpacing="0" TabIndex="5" RepeatColumns="2"  RepeatDirection="Vertical" AppendDataBoundItems="True">  </asp:CheckBoxList>
                        </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center" class="MyTableHead">
                                <asp:Label ID="lblReportGroupDetails" runat="server" CssClass="MyLabel" Text="Report Group Details"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="6" valign="top">
                                <asp:Panel ID="pnlGridView" runat="server" class="MyTableBorder"
                                   Width="520px" ScrollBars="Vertical" Height="250px">
                                    <asp:GridView ID="gvReportGroup" runat="server" Width="502px" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowDataBound="gvReportGroup_RowDataBound"
                                    CssClass="mGrid"     AlternatingRowStyle-CssClass="alt" >
                                       
                                        <Columns>
                                            <asp:BoundField DataField="Sl.No" HeaderText="Sl.No.">
                                                <ItemStyle HorizontalAlign="Right" Width="40px"/>
                                                <HeaderStyle HorizontalAlign="Right" Width="40px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ReportGroupID" HeaderText="ReportGroupID"/>                                            
                                            <asp:BoundField DataField="ReportGroup Name" HeaderText="Report Group">
                                                <ItemStyle HorizontalAlign="Left" Width="120px"/>
                                                <HeaderStyle HorizontalAlign="Left" Width="120px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Module Name" HeaderText="Module">
                                                <ItemStyle HorizontalAlign="Left" Width="140px"/>
                                                <HeaderStyle HorizontalAlign="Left" Width="140px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ModuleID" HeaderText="Module ID" />
                                            
                                            <asp:BoundField DataField="PriorityNo" HeaderText="Priority">
                                            <ItemStyle HorizontalAlign="Right" Width="20px"/>
                                                <HeaderStyle HorizontalAlign="Right" Width="20px"/>
                                            </asp:BoundField>   
                                        </Columns>
                                  
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                            <td align="left" colspan="1" valign="top">
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hidFlag" runat="server" />
        <asp:HiddenField ID="hidCache" runat="server" />
         <asp:HiddenField ID="hidID" runat="server" />
        <asp:HiddenField ID="hdnVal" runat="server" />
        <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click" style="display:none"/>       
                <asp:Button ID="btnBind" runat="server" Text="Bind" OnClick="btnBind_Click" style="display:none"/>       

          <div id="divSelectDeSelect" class="MyLabel" style="z-index: 102;position:absolute;background-color:White;">
        <table cellpadding="0" cellspacing="0" style="border-width:1px;border-style:solid;border-color:#FFC1A4;">
        <tr>
        <td> <asp:Button ID="btnSelectAll" runat="server"  Text="Select&nbsp;All"  CssClass="MyButton" Width="85px" BorderWidth="0px" /></td>
        </tr>
        <tr>
        <td> <asp:Button ID="btnDeSelect" runat="server"  Text="DeSelect&nbsp;All" CssClass="MyButton" Width="85px" BorderWidth="0px" /></td>
        </tr>
        </table>
        </div>
    </form>
</body>
</html>
