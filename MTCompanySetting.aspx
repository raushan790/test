<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MTCompanySetting.aspx.cs"
    Inherits="MTInstitutionMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: CampusCare Online :: MtInstitutionMaster</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
          <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/jquery-1.4.2.min.js"type="text/javascript"></script>
<script language="javascript" src="Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="Scripts/jsSpecialCharacterValidation.js"></script>
    <script language="javascript" type="text/javascript">
 jQuery(function($){
        $("#txtPLPackDate").mask("99/99/9999");
           $("#txtPLPackDateStaff").mask("99/99/9999");
        });
  var curSelRow=null;
  var curSelRowIndex=-1;
    addLoadEvent(fEnableDisable);
    function fEnableDisable()
    {    
    var strValue=document.getElementById('hidFlag').value.split('^');
        if(strValue[0]=="")
        {
            document.getElementById('btnSave').disabled=true;
            document.getElementById('btnEdit').disabled=true;
            document.getElementById('btnDelete').disabled=true;
            document.getElementById('txtInstitution1').readOnly=true;
            document.getElementById('txtInstitution2').readOnly=true;
            document.getElementById('txtAddress').readOnly=true;
            document.getElementById('txtReportHeader').readOnly=true;
            document.getElementById('txtCity').readOnly=true;
            document.getElementById('txtPincode').readOnly=true;
            document.getElementById('txtState').readOnly=true;
            document.getElementById('txtTelephone').readOnly=true;
            document.getElementById('txtFax').readOnly=true;
            document.getElementById('txtEmail').readOnly=true;
            document.getElementById('txtAffiliation').readOnly=true;
            document.getElementById('txtMedium').readOnly=true;
            document.getElementById('txtEstablishedOn').readOnly=true;
            document.getElementById('txtEstablishmentCode').readOnly=true;
            document.getElementById('txtBankACNo').readOnly=true;
            document.getElementById('txtMotto').readOnly=true;
            document.getElementById('txtDirector').readOnly=true;
            document.getElementById('txtDirPhone').readOnly=true;
            document.getElementById('txtPrincipal').readOnly=true;
            document.getElementById('txtPriPhone').readOnly=true;
            document.getElementById('txtVicePrincipal').readOnly=true;
            document.getElementById('txtVicePriPhone').readOnly=true;
            document.getElementById('txtAdministrator').readOnly=true;
            document.getElementById('txtAdmPhone').readOnly=true;
            document.getElementById('txtPLPackDate').readOnly=true;
            document.getElementById('txtPLPackDateStaff').readOnly=true;
            document.getElementById('img').disabled=true;
            document.getElementById('img1').disabled=true;
            document.getElementById('btnClick').style.display='none';
      }
      else if(strValue[0]=="E")
      {
            document.getElementById('btnEdit').disabled=false;
            document.getElementById('btnSave').disabled=true;
            document.getElementById('btnDelete').disabled=false;
            document.getElementById('btnNew').disabled=true;
            document.getElementById('txtInstitution1').readOnly=true;
            document.getElementById('txtInstitution2').readOnly=true;
            document.getElementById('txtAddress').readOnly=true;
            document.getElementById('txtReportHeader').readOnly=true;
            document.getElementById('txtCity').readOnly=true;
            document.getElementById('txtPincode').readOnly=true;
            document.getElementById('txtState').readOnly=true;
            document.getElementById('txtTelephone').readOnly=true;
            document.getElementById('txtFax').readOnly=true;
            document.getElementById('txtEmail').readOnly=true;
            document.getElementById('txtAffiliation').readOnly=true;
            document.getElementById('txtMedium').readOnly=true;
            document.getElementById('txtEstablishedOn').readOnly=true;
            document.getElementById('txtEstablishmentCode').readOnly=true;
            document.getElementById('txtBankACNo').readOnly=true;
            document.getElementById('txtMotto').readOnly=true;
            document.getElementById('txtDirector').readOnly=true;
            document.getElementById('txtDirPhone').readOnly=true;
            document.getElementById('txtPrincipal').readOnly=true;
            document.getElementById('txtPriPhone').readOnly=true;
            document.getElementById('txtVicePrincipal').readOnly=true;
            document.getElementById('txtVicePriPhone').readOnly=true;
            document.getElementById('txtAdministrator').readOnly=true;
            document.getElementById('txtPLPackDate').readOnly=true;
            document.getElementById('txtPLPackDateStaff').readOnly=true;
            document.getElementById('img').disabled=true;
            document.getElementById('img1').disabled=true;
            document.getElementById('txtAdmPhone').readOnly=true;
            document.getElementById('btnClick').style.display='none';
      }
       if(document.getElementById('hidFlag').value=="S")
      {
          document.getElementById('btnSave').disabled=false;
          document.getElementById('btnNew').disabled=true;
          document.getElementById('btnEdit').disabled=true;
          document.getElementById('btnDelete').disabled=true;
          
      }
      document.getElementById('trBankacc').style.display='none';
        document.getElementById('trSchool').style.display='none';   
        fChangeButtonColor('frmMTInstitutionMaster','#400000');   
    }
     function fNew()
     {
          if(fUserLimit('N')==false)
          {
               return false;
          }         
        document.getElementById('hidFlag').value="N";
        document.getElementById('btnSave').disabled=false;
        document.getElementById('btnDelete').disabled=true;
        document.getElementById('btnNew').disabled=true;
        document.getElementById('btnEdit').disabled=true;
        document.getElementById('txtInstitution1').readOnly=false;
        document.getElementById('txtInstitution2').readOnly=false;
        document.getElementById('txtInstitution1').focus();        
        document.getElementById('txtAddress').readOnly=false;
        document.getElementById('txtReportHeader').readOnly=false;
        document.getElementById('txtCity').readOnly=false;
        document.getElementById('txtPincode').readOnly=false;
        document.getElementById('txtState').readOnly=false;
        document.getElementById('txtTelephone').readOnly=false;
        document.getElementById('txtFax').readOnly=false;
        document.getElementById('txtEmail').readOnly=false;
        document.getElementById('txtAffiliation').readOnly=false;
        document.getElementById('txtMedium').readOnly=false;
        document.getElementById('txtEstablishedOn').readOnly=false;
        document.getElementById('txtEstablishmentCode').readOnly=false;
        document.getElementById('txtBankACNo').readOnly=false;
        document.getElementById('txtMotto').readOnly=false;
        document.getElementById('txtDirector').readOnly=false;
        document.getElementById('txtDirPhone').readOnly=false;
        document.getElementById('txtPrincipal').readOnly=false;
        document.getElementById('txtPriPhone').readOnly=false;
        document.getElementById('txtVicePrincipal').readOnly=false;
        document.getElementById('txtVicePriPhone').readOnly=false;
        document.getElementById('txtAdministrator').readOnly=false;
        document.getElementById('txtAdmPhone').readOnly=false;
        document.getElementById('txtPLPackDate').readOnly=false;
        document.getElementById('txtPLPackDateStaff').readOnly=false;
        document.getElementById('img').disabled=false;
          document.getElementById('img1').disabled=false;
        //document.getElementById('ImgEmblem').src="StudentPhoto/NoImage.JPG";
        //document.getElementById('fUploadEmblem').disabled=false;
//        document.getElementById('txtStudCount').readOnly=false;
//        document.getElementById('txtBoys').readOnly=false;
//        document.getElementById('txtGirls').readOnly=false;
        document.getElementById('btnClick').style.display='none';
        fChangeButtonColor('frmMTInstitutionMaster','#400000');   
        return false;
     }
    function fUserLimit(Val)
    {
        if(Val=="N")
        {
            var strNew=document.getElementById('hidCache').value.split(";")[0];
            if(strNew!="Y")
            {
                pDisplayMessageclient("<%=Session["Type"].ToString() %>","1","");
                return false;
            }
        }
        else if(Val=="E")
        {
            var strEdit=document.getElementById('hidCache').value.split(";")[1];
            if(strEdit!="Y")
            {
                 pDisplayMessageclient("<%=Session["Type"].ToString() %>","2","");
                 return false;   
            }
        }
        else if(Val=="D")
        {
            var strEdit=document.getElementById('hidCache').value.split(";")[2];
            if(strEdit!="Y")
            {
                 pDisplayMessageclient("<%=Session["Type"].ToString() %>","3",""); 
                 return false;   
            }
        }
    }

    function fValidateSave()
    {    
        if(stripBlanks(document.getElementById('txtInstitution1').value)=="")
        {
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblSchool1').innerHTML);                
            document.getElementById('txtInstitution1').focus();
            return false;
        }
       if(stripBlanks(document.getElementById('txtAddress').value)=="")
       {
//            alert('Please Enter Address Of School');
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblAddress').innerHTML);                
            document.getElementById('txtAddress').focus();
            return false;
       }
       if(document.getElementById('txtEmail').value!="")
            {
                if(validateEmail(document.getElementById('txtEmail').value)==false)
                {
//                    alert('Please Enter Valid Email ID.');                
                    pDisplayMessageclient("<%=Session["Type"].ToString() %>","17","" + document.getElementById('lblEmail').innerHTML);                
                    document.getElementById('txtEmail').focus();
                    return false;
                }
            }
            if(stripBlanks(document.getElementById('txtPLPackDate').value)!="")
            {
                if (!validateDate(document.getElementById('txtPLPackDate').value))
                {
                    alert('Please Enter Date In [dd/MM/yyyy] Format');
                    document.getElementById('txtPLPackDate').focus();
                    return false;
                }
            }



             if(stripBlanks(document.getElementById('txtPLPackDateStaff').value)!="")
            {
                if (!validateDate(document.getElementById('txtPLPackDateStaff').value))
                {
                    alert('Please Enter Date In [dd/MM/yyyy] Format');
                    document.getElementById('txtPLPackDateStaff').focus();
                    return false;
                }
            }
            //ReplaceSpecialcharacter('frmMTInstitutionMaster');    
    }




function fValidate_Image()
    { 
        var checkFormat=document.getElementById('fUploadEmblem').value;
        var valueFormat=checkFormat.split('.');       
        if((valueFormat[valueFormat.length-1].toLowerCase()=="jpeg") || (valueFormat[valueFormat.length-1].toLowerCase()=="gif") || (valueFormat[valueFormat.length-1].toLowerCase()=="jpg"))
        {
            document.getElementById('ImgEmblem').src=document.getElementById('fUploadEmblem').value;            
            return true;               
        }  
        else
        {
//            alert('Please Select .jpeg/.gif Files');
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","16","");
            return false;  
        }      
    }
    function fVerify_Edit()
    {
        if(fUserLimit('E')==false)
        {
           return false;
        }
        document.getElementById('btnSave').disabled=false;
        document.getElementById('btnEdit').disabled=true;
        document.getElementById('btnDelete').disabled=true;
        document.getElementById('txtInstitution1').readOnly=false;
        document.getElementById('txtInstitution2').readOnly=false;
        document.getElementById('txtInstitution1').focus();        
        document.getElementById('txtAddress').readOnly=false;
        document.getElementById('txtReportHeader').readOnly=false;
        document.getElementById('txtCity').readOnly=false;
        document.getElementById('txtPincode').readOnly=false;
        document.getElementById('txtState').readOnly=false;
        document.getElementById('txtTelephone').readOnly=false;
        document.getElementById('txtFax').readOnly=false;
        document.getElementById('txtEmail').readOnly=false;
        document.getElementById('txtAffiliation').readOnly=false;
        document.getElementById('txtMedium').readOnly=false;
        document.getElementById('txtEstablishedOn').readOnly=false;
        document.getElementById('txtEstablishmentCode').readOnly=false;
        document.getElementById('txtBankACNo').readOnly=false;
        document.getElementById('txtMotto').readOnly=false;
        document.getElementById('txtDirector').readOnly=false;
        document.getElementById('txtDirPhone').readOnly=false;
        document.getElementById('txtPrincipal').readOnly=false;
        document.getElementById('txtPriPhone').readOnly=false;
        document.getElementById('txtVicePrincipal').readOnly=false;
        document.getElementById('txtVicePriPhone').readOnly=false;
        document.getElementById('txtAdministrator').readOnly=false;
        document.getElementById('txtAdmPhone').readOnly=false;
        document.getElementById('txtPLPackDate').readOnly=false;
        document.getElementById('txtPLPackDateStaff').readOnly=false;
        document.getElementById('img').disabled=false;
        document.getElementById('img1').disabled=false;
//        document.getElementById('txtStudCount').readOnly=false;
//        document.getElementById('txtBoys').readOnly=false;
//        document.getElementById('txtGirls').readOnly=false;
        //document.getElementById('fUploadEmblem').disabled=false;        
        fChangeButtonColor('frmMTInstitutionMaster','#400000');   
        return false;
    }
    
  function fGridClick(varRowIndex)
  {    
        var Da1 =new Date();
        curSelRow=document.getElementById("gvInstitute").rows[varRowIndex+1];
        curSelRowIndex = varRowIndex;
        document.getElementById('hidFlag').value="E"+"^"+document.getElementById('gvInstitute').rows[varRowIndex+1].cells[1].firstChild.nodeValue+"^"+varRowIndex+'^'+document.getElementById('gvInstitute').rows[varRowIndex+1].cells[4].firstChild.nodeValue;
        //ReplaceSpecialcharacter('frmMTInstitutionMaster');  
        fChangeButtonColor('frmMTInstitutionMaster','#400000'); 
        document.getElementById('btnClick').click();
        return false;
      
  }
    function fDelete()
    {
       if(fUserLimit('D')==false)
       {
           return false;
       }
       if(confirm(pDisplayMessageclient("<%=Session["Type"].ToString() %>","5","")))
       {
            //ReplaceSpecialcharacter('frmMTInstitutionMaster');  
           return true;
       }
       else
       {
        //ReplaceSpecialcharacterToNormal('frmMTInstitutionMaster');  
           return false;
       }
    }    
    
  function fValidation_On_Cancel()
    {
        //ReplaceSpecialcharacter('frmMTInstitutionMaster');  
    }
    function fValidation_On_Export()
    {
        //ReplaceSpecialcharacter('frmMTInstitutionMaster');  
    }
    function fValidation_On_Close()
    {
        //ReplaceSpecialcharacter('frmMTInstitutionMaster');  
    } 
    </script>

</head>
<body dir="<%=strType %>" style="background-image:url(Images/backgroundImg.jpg); background-repeat :repeat ; background-position: center center; background-attachment: scroll;">
    <form id="frmMTInstitutionMaster" runat="server" dir="<%=strType %>">
        <div align="center">
            <table>
                <tr>
                    <td class="divCircle">
                        <table class="MyTableBorder">
                            <tr>
                                <td class="MyTableHeader" colspan="4" align="center">
                                    <asp:Label ID="lblSchoolInformation" runat="server" Text="Our Company Details" CssClass="MyLableHeader"></asp:Label>&nbsp;</td>
                                <td align="center" class="MyTableHeader" colspan="1">
                                    <asp:Label ID="lblOptions" runat="server" Text="Options" CssClass="MyLableHeader"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblSchool1" runat="server" Text="Company Name" CssClass="MyLabel"
                                        Width="90px"></asp:Label>&nbsp;</td>
                                <td align="left" valign="top" colspan="3">
                                    <asp:TextBox ID="txtInstitution1" runat="server" CssClass="MyTextBox" TabIndex="1" Width="536px"
                                        MaxLength="100"></asp:TextBox>
                                </td>
                                <td align="left" rowspan="17" valign="top">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnNew" runat="server" CssClass="MyButton" Text="New" OnClientClick="return fNew()"
                                                    TabIndex="28" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnEdit" runat="server" CssClass="MyButton" OnClientClick="return fVerify_Edit()"
                                                    TabIndex="29" Text="Edit" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSave" runat="server" CssClass="MyButton" OnClick="btnSave_Click"
                                                    OnClientClick="return fValidateSave()" TabIndex="30" Text="Save" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnDelete" runat="server" CssClass="MyButton" Text="Delete" OnClick="btnDelete_Click"
                                                    OnClientClick="return fDelete()" TabIndex="31" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" CssClass="MyButton" Text="Cancel" OnClientClick="return fValidation_On_Cancel()" OnClick="btnCancel_Click"
                                                    TabIndex="32" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnExport" runat="server" CssClass="MyButton" Text="Export" OnClientClick="return fValidation_On_Export()" OnClick="btnExport_Click"
                                                    TabIndex="33" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnClose" runat="server" CssClass="MyButton" OnClientClick="return fValidation_On_Close()"  OnClick="btnClose_Click"
                                                    TabIndex="34" Text="Close" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trSchool">
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblSchool2" runat="server" Text="School(Arabic)" CssClass="MyLabel"
                                        Width="90px"></asp:Label></td>
                                <td align="left" colspan="3" valign="top">
                                    <asp:TextBox ID="txtInstitution2" runat="server" CssClass="MyTextBox" Width="536px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblAddress" runat="server" Text="P.O Box" CssClass="MyLabel" Width="90px"></asp:Label></td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="MyTextBox" TabIndex="2" Width="536px"
                                        MaxLength="60"></asp:TextBox></td>
                            </tr>
                            <tr style="display:none;">
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblReportHeader" runat="server" Text="Report Header" CssClass="MyLabel"
                                        Width="90px"></asp:Label></td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtReportHeader" runat="server" CssClass="MyTextBox" TabIndex="3" Width="536px"
                                        MaxLength="60"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblCity" runat="server" Text="City" CssClass="MyLabel" Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtCity" runat="server" CssClass="MyTextBox" TabIndex="4" Width="200px"
                                        MaxLength="40"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblPinCode" runat="server" Text="TRN" CssClass="MyLabel" Width="100px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtPincode" runat="server" CssClass="MyTextBox" TabIndex="5" Width="200px"
                                        MaxLength="15"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblState" runat="server" Text="State" CssClass="MyLabel" Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtState" runat="server" CssClass="MyTextBox" TabIndex="6" Width="200px"
                                        MaxLength="40"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblTelephone" runat="server" CssClass="MyLabel" Text="Telephone" Width="100px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="MyTextBox" TabIndex="7" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblFax" runat="server" CssClass="MyLabel" Text="Fax" Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtFax" runat="server" CssClass="MyTextBox" TabIndex="8" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblEmail" runat="server" CssClass="MyLabel" Text="Email" Width="100px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="MyTextBox" TabIndex="9" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblAffiliation" runat="server" CssClass="MyLabel" Text="Web Site"
                                        Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtAffiliation" runat="server" CssClass="MyTextBox" TabIndex="10" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblMedium" runat="server" CssClass="MyLabel" Text="Medium" Width="100px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtMedium" runat="server" CssClass="MyTextBox" TabIndex="11" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblEstablishedOn" runat="server" CssClass="MyLabel" Text="Established On"
                                        Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtEstablishedOn" runat="server" CssClass="MyTextBox" TabIndex="12"
                                        Width="200px" MaxLength="40"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblMotto" runat="server" CssClass="MyLabel" Text="Motto" Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMotto" runat="server" CssClass="MyTextBox" TabIndex="15" Width="200px"
                                        MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="trBankacc">
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblBankACNo" runat="server" CssClass="MyLabel" Text="Bank A/C No."
                                        Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtBankACNo" runat="server" CssClass="MyTextBox" TabIndex="14" Width="200px"
                                        MaxLength="40"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblEstablishmentCode" runat="server" CssClass="MyLabel" Text="Establishment Code"
                                        Width="100px"></asp:Label>&nbsp;</td>
                                <td align="left">
                                    <asp:TextBox ID="txtEstablishmentCode" runat="server" CssClass="MyTextBox" TabIndex="13"
                                        Width="200px" MaxLength="40"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblDirector" runat="server" CssClass="MyLabel" Text="Director" Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtDirector" runat="server" CssClass="MyTextBox" TabIndex="16" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblDTelephone" runat="server" CssClass="MyLabel" Text="Telephone"
                                        Width="100px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtDirPhone" runat="server" CssClass="MyTextBox" TabIndex="17" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                            </tr>
                            <tr style="display:none;">
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblPrincipal" runat="server" CssClass="MyLabel" Text="Principal" Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtPrincipal" runat="server" CssClass="MyTextBox" TabIndex="18" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblPTelephone" runat="server" CssClass="MyLabel" Text="Telephone"
                                        Width="100px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtPriPhone" runat="server" CssClass="MyTextBox" TabIndex="19" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                            </tr>
                            <tr style="display:none;">
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblVicePrincipal" runat="server" CssClass="MyLabel" Text="Vice Principal"
                                        Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtVicePrincipal" runat="server" CssClass="MyTextBox" TabIndex="20"
                                        Width="200px" MaxLength="60"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblVTelephone" runat="server" CssClass="MyLabel" Text="Telephone"
                                        Width="100px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtVicePriPhone" runat="server" CssClass="MyTextBox" TabIndex="21"
                                        Width="200px" MaxLength="60"></asp:TextBox></td>
                            </tr>
                            <tr style="display:none;">
                                <td align="right" class="MyLabel" valign="top">
                                    <asp:Label ID="lblAdministrator" runat="server" CssClass="MyLabel" Text="Administrator"
                                        Width="90px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtAdministrator" runat="server" CssClass="MyTextBox" TabIndex="22"
                                        Width="200px" MaxLength="60"></asp:TextBox></td>
                                <td align="right" class="MyLabel">
                                    <asp:Label ID="lblATelephone" runat="server" CssClass="MyLabel" Text="Telephone"
                                        Width="100px"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtAdmPhone" runat="server" CssClass="MyTextBox" TabIndex="23" Width="200px"
                                        MaxLength="60"></asp:TextBox></td>
                            </tr>
                            <tr style="display:none;">
                                <td colspan="2" style="vertical-align: top;">
                                    <table>
                                        <tr style="text-align: left;" class="MyLabel">
                                            <td align="right" class="MyLabel" valign="top">
                                                <asp:Label ID="lblStudCount" runat="server" CssClass="MyLabel" Text="Total Strength" Width="90px"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtStudCount" runat="server" CssClass="MyTextBox" Width="200px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align:left;">
                                                <div style="margin-left:95px;">
                                                <span style="width:100px;"><span><asp:Label ID="lblBoys" runat="server" CssClass="MyLabel" Text="Boys" Width="30px"></asp:Label></span>
                                                <span style="padding-left:3px;"><asp:TextBox ID="txtBoys" runat="server" CssClass="MyTextBox" MaxLength="60" TabIndex="22"
                                                    Width="56px"></asp:TextBox></span></span>
                                                <span style="width:100px; margin-left:8px;"><span style="text-align:right;"><asp:Label ID="lblGirls" runat="server" CssClass="MyLabel" Text="Girls" Width="28px"></asp:Label></span>
                                                <span style="padding-left:3px;padding-right:2px;"><asp:TextBox ID="txtGirls" runat="server" CssClass="MyTextBox" MaxLength="60" TabIndex="22"
                                                    Width="56px"></asp:TextBox></span></span></div>
                                            </td>
                                            <%--<td align="right" class="MyLabel" valign="top">
                                                
                                                </td>
                                            <td align="left" class="MyLabel" valign="top">
                                                
                                                </td>--%>
                                        </tr>
                                        <%--<tr>
                                            <td align="right" class="MyLabel" valign="top">
                                                </td>
                                            <td>
                                                </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="right" class="MyLabel" valign="top">
                                                <asp:Label ID="lblEmblem" runat="server" CssClass="MyLabel" Text="Emblem" Width="90px"></asp:Label></td>
                                            <td align="left" >
                                                <asp:FileUpload ID="fUploadEmblem" runat="server"  Width="200px"
                                                    onchange="return fValidate_Image()" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" class="MyLabel">
                                    <div align="left">
                                        <asp:Image ID="ImgEmblem" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                                            BorderWidth="1px" Height="110px" Width="110px" /></div>
                                </td>
                                <td align="left" valign="top">
                                    <table style="width: 100%">
                                       
                                        <tr>
                                            <td class="MyLabel" style="text-align: left" >
                                                Pack&nbsp;Date&nbsp;For&nbsp;Student&nbsp;Profile&nbsp;Editing</td>
                                        </tr>
                                        <tr>
                                            <td class="MyLabel" style="text-align: left">
                                                <table cellpadding="0" cellspacing="0" >
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtPLPackDate" runat="server" CssClass="MyTextBox" MaxLength="10"
                                                                TabIndex="5" Width="70px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:ImageButton ID="img" runat="server" CssClass="CalendarStyle" Height="20px"
                                                                ImageUrl="~/Images/calendar1.jpg" OnClientClick="javascript:return false;"
                                                                TabIndex="7" Width="22px" /></td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>                                       
                                    </table>
                                     <table style="width: 100%">
                                       
                                        <tr>
                                            <td class="MyLabel" style="text-align: left" >
                                                Pack&nbsp;Date&nbsp;For&nbsp;Staff&nbsp;Profile&nbsp;Editing</td>
                                        </tr>
                                        <tr>
                                            <td class="MyLabel" style="text-align: left">
                                                <table cellpadding="0" cellspacing="0" >
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtPLPackDateStaff" runat="server" CssClass="MyTextBox" MaxLength="10"
                                                                TabIndex="5" Width="70px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:ImageButton ID="img1" runat="server" CssClass="CalendarStyle" Height="20px"
                                                                ImageUrl="~/Images/calendar1.jpg" OnClientClick="javascript:return false;"
                                                                TabIndex="7" Width="22px" /></td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>                                       
                                    </table>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="MyTableHead" colspan="5" valign="top">
                                    <asp:Label ID="lblSchoolInformation1" runat="server" CssClass="MyLabel" Text="Company Information"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="5" valign="top" style="height: 223px">
                                    <asp:Panel ID="pnlGridView" runat="server" CssClass="MyTableBorder"
                                         Width="715px" Height="200px" ScrollBars="Vertical">
                                        <asp:GridView ID="gvInstitute" runat="server" Width="698px" Height="23px" 
                                        OnRowDataBound="gvInstitute_RowDataBound" CssClass="mGrid" AlternatingRowStyle-CssClass="alt" >
                                            
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnClick" runat="server" Text="Click" BackColor="White" BorderColor="White"
                BorderWidth="1px" ForeColor="White" OnClick="btnClick_Click" /><br />
                <asp:HiddenField ID="hidCache" runat="server" />
            <asp:HiddenField ID="hidFlag" runat="server" />
            <asp:HiddenField ID="hdnSImagePath" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <cc1:calendarextender id="CalendarExtender1" runat="server" cssclass="MyCalendarStyle"
                format="dd/MM/yyyy" popupbuttonid="img" targetcontrolid="txtPLPackDate"></cc1:calendarextender>
                <cc1:calendarextender id="CalendarExtender2" runat="server" cssclass="MyCalendarStyle"
                format="dd/MM/yyyy" popupbuttonid="img1" targetcontrolid="txtPLPackDateStaff"></cc1:calendarextender>
            &nbsp; &nbsp;
            <asp:ListBox Style="display: none; z-index: 1000" ID="ListBox" runat="server" Height="59px">
            </asp:ListBox>

             <cc1:AutoCompleteExtender ID="AutoCompleteExtender" runat="server" CompletionInterval="1000"
             EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="GetdAffNo"
            ServicePath="WSStudentSearch.asmx" TargetControlID="txtAffiliation" CompletionListElementID="divAff">
            </cc1:AutoCompleteExtender>
          <div class="MyText" id="divAff" ></div>


        </div>
        <div style="display:none;">
         <tr>
                                            <td align="left" class="MyLabel" colspan="1">
                                                <asp:Label ID="lblVisibleInReport" runat="server" CssClass="MyLabel" Text="Visible In Report"
                                                    Width="100px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" class="MyLabel" >
                                            <table>
                                            <tr>
                                            <td><asp:RadioButton ID="rbtnYes" runat="server" CssClass="MyLabel" GroupName="rbtnGpEmblem"
                                                    Text="Yes" TabIndex="26" /></td>
                                             <td><asp:RadioButton ID="rbtnNo" runat="server" CssClass="MyLabel" GroupName="rbtnGpEmblem"
                                                    Text="No" TabIndex="27" /></td>
                                            </tr>
                                            </table>
                                                
                                                    
                                                    
                                                    </td>
                                        </tr>
        </div>
    </form>
</body>
</html>
