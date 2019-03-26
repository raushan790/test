<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MTUserManagement.aspx.cs" Inherits="frmUserManagement" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>::InnoSoft® Online:: User Management</title>
      <link href="CSS/MyStyle.css" rel="Stylesheet" type ="text/css"/>
      <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="Scripts/jsSpecialCharacterValidation.js"></script>
    <script language="javascript" type="text/javascript">
    //addLoadEvent(showName);
    function fUIDChange()
    {
      // debugger;
        if(document.getElementById('ddlUserType').value=="6")
        {
            document.getElementById('ddlEmployee').style.display='none';
            document.getElementById('lblEmployeeName').style.display='none';
            //return true;
        }
        else
        {
            document.getElementById('ddlEmployee').style.display='';
            document.getElementById('lblEmployeeName').style.display='';
             //return true;
        }
        return true;
    }
    
function RestrictEntry(e)
    {
     var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;  
       
       if (varKey==13 && document.frmMTUserManagement.txtUserId.value == "") 
       {
//       alert("Please Enter User Id");
        pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblUserId').innerHTML);                
        return false; 
       }
       else
       {        
            if(varKey==13 || (varKey>=65 && varKey<=90) || (varKey>=97 && varKey<=122) || varKey==95 || varKey==46 || (varKey>=38 && varKey<=43) || (varKey>=45 && varKey<=57) || varKey==8)
            return true;
            else
            return false;  
        } 
   
    }
  
/*=============================================Modified By Himanshu on 31.07.2012=================================*/      
function ChangeOption(rowIndex,colIndex)
{
    try
    {
        if (document.getElementById('btnSave').disabled==true) return false;
        //var id=document.getElementById('gvMenuMaster').rows[41].column[0].value;
        /*================================FOR DISABLING STUDENT CHECKBOX=========================================*/
                //for (var intForLoop=rowIndex+2;intForLoop<document.getElementById('gvMenuMaster').rows.length;intForLoop++)
                //    {
                // if(GetInnerText(document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[0])=="Student Information")
                //            {
                //            if (Number(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[0]))==0)
                //                {
                //                 if (colIndex==3)
                //                  {
                //                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[4].getElementsByTagName('INPUT')[0].disabled=true;
                //                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[5].getElementsByTagName('INPUT')[0].disabled=true;
                //                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[6].getElementsByTagName('INPUT')[0].disabled=true;
                //                document.getElementById('gvMenuMaster').rows[intForLoop].cells[4].getElementsByTagName('INPUT')[0].disabled=true;
                //                document.getElementById('gvMenuMaster').rows[intForLoop].cells[5].getElementsByTagName('INPUT')[0].disabled=true;
                //                document.getElementById('gvMenuMaster').rows[intForLoop].cells[6].getElementsByTagName('INPUT')[0].disabled=true;
                //                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[4].getElementsByTagName('INPUT')[0].checked=false;
                //                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[5].getElementsByTagName('INPUT')[0].checked=false;
                //                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[6].getElementsByTagName('INPUT')[0].checked=false;
                //                document.getElementById('gvMenuMaster').rows[intForLoop].cells[4].getElementsByTagName('INPUT')[0].checked=false;
                //                document.getElementById('gvMenuMaster').rows[intForLoop].cells[5].getElementsByTagName('INPUT')[0].checked=false;
                //                document.getElementById('gvMenuMaster').rows[intForLoop].cells[6].getElementsByTagName('INPUT')[0].checked=false;
                //                 }
                //               }
                //                 else
                //                { 
                //                 return;
                //                }
                //            }
                //           // if(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[0])=="")
                //           // {
                //          //  debugger;
                //          //  break;
                //          //  }
                //          // else
                //          //  { 
                //          //  return;
                //          //  }
                //     }  
             /*====================================================END==============================================*/
             /*===========================================FOR DISABLING FEE & BILING CHECKBOX=================================*/
                //             for (var intForLoop=rowIndex+2;intForLoop<document.getElementById('gvMenuMaster').rows.length;intForLoop++)
                //                 {
                //                   if(GetInnerText(document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[0])=="Fee & Billing")
                //                       {
                //                        if (Number(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[0]))==0)
                //                          {
                //                           if (colIndex==3)
                //                              {
                //                                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[4].getElementsByTagName('INPUT')[0].disabled=true;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[5].getElementsByTagName('INPUT')[0].disabled=true;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[6].getElementsByTagName('INPUT')[0].disabled=true;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop].cells[4].getElementsByTagName('INPUT')[0].disabled=true;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop].cells[5].getElementsByTagName('INPUT')[0].disabled=true;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop].cells[6].getElementsByTagName('INPUT')[0].disabled=true;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[4].getElementsByTagName('INPUT')[0].checked=false;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[5].getElementsByTagName('INPUT')[0].checked=false;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[6].getElementsByTagName('INPUT')[0].checked=false;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop].cells[4].getElementsByTagName('INPUT')[0].checked=false;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop].cells[5].getElementsByTagName('INPUT')[0].checked=false;
                //                                document.getElementById('gvMenuMaster').rows[intForLoop].cells[6].getElementsByTagName('INPUT')[0].checked=false;
                //                               }
                //                            }
                //                            else
                //                            { 
                //                             return;
                //                            }
                //                          }
                //           // if(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[0])=="")
                //           // {
                //          //  debugger;
                //          //  break;
                //          //  }
                //          // else
                //         //  { 
                //          //  return;
                //          //  }
                //     }
             /*==============================================END===================================================*/     
             
        var ddlvalue = document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[colIndex].getElementsByTagName('INPUT')[0].checked;  
        
        //senthil
        //if (colIndex!=3 && document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[3].getElementsByTagName('INPUT')[0].checked==false) return false;
//        if (colIndex==3 && document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[3].getElementsByTagName('INPUT')[0].checked==false) 
//        {
//            document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[4].getElementsByTagName('INPUT')[0].checked=false;
//            document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[5].getElementsByTagName('INPUT')[0].checked=false;
//            document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[6].getElementsByTagName('INPUT')[0].checked=false;
//        }
        if (Number(GetInnerText(document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[0]))!=0)
        {
            for (var intForLoop=rowIndex+2;intForLoop<document.getElementById('gvMenuMaster').rows.length;intForLoop++)
            {
                if (Number(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[0]))==0)
                {
                if(document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].disabled==false)
                {
                    document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                }
                    if (colIndex==3 && ddlvalue==false)
                    {
                   
                        document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[4].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[5].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[6].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop].cells[4].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop].cells[5].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop].cells[6].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                    }
                    if (document.getElementById('gvMenuMaster').rows[intForLoop].cells[3].getElementsByTagName('INPUT')[0].checked==false) document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].checked=false;
                }
                else 
                    return;
            }
            return true;
        }    
        else
        {
            
            var varSelect="";
            for (intForLoop=Number(rowIndex)+2;intForLoop<document.getElementById('gvMenuMaster').rows.length ;intForLoop++)
            {
                if(varSelect=="")
                {
                     if (Number(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[0]))==0 && stripBlanks(GetInnerText(document.getElementById('gvMenuMaster').rows[Number(rowIndex)+1].cells[2]))=="" && stripBlanks(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[2]))!="" && stripBlanks(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[1]))=="")
                     {
                        
                        document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        if(ddlvalue==false && colIndex==3)
                        {
                               document.getElementById('gvMenuMaster').rows[Number(rowIndex)+1].cells[4].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                               document.getElementById('gvMenuMaster').rows[Number(rowIndex)+1].cells[5].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                               document.getElementById('gvMenuMaster').rows[Number(rowIndex)+1].cells[6].getElementsByTagName('INPUT')[0].checked=ddlvalue;

                               document.getElementById('gvMenuMaster').rows[intForLoop].cells[4].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                               document.getElementById('gvMenuMaster').rows[intForLoop].cells[5].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                               document.getElementById('gvMenuMaster').rows[intForLoop].cells[6].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        }
                     }
                     else
                     {
                        varSelect="S";
                     }
                 }
            }
            
            var varSecLevel="";
            var varModuleLevel="";
            for (intForLoop=rowIndex;intForLoop>0;intForLoop--)
            {               
              if(ddlvalue==false)
                 {
                    for (k=rowIndex+2;k>0 && k<document.getElementById('gvMenuMaster').rows.length;k++)
                    {
                        if(document.getElementById('gvMenuMaster').rows.length>k)
                        { 
                            if(Number(GetInnerText(document.getElementById('gvMenuMaster').rows[k].cells[0]))!=0)
                                k=-1;
                            else if(document.getElementById('gvMenuMaster').rows[k].cells[colIndex].getElementsByTagName('INPUT')[0].checked==true)
                                ddlvalue=true;
                        }
                    }
                 }
                 if ((Number(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[0]))!=0  && varModuleLevel=="")|| (stripBlanks(GetInnerText(document.getElementById('gvMenuMaster').rows[Number(rowIndex)+1].cells[2]))!="" && stripBlanks(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[2]))=="" && stripBlanks(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[1]))!="" && varSecLevel==""))
                 {
                    if(intForLoop!=rowIndex && document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].checked==true)
                    {
                        ddlvalue=true;
                    }
                    varSecLevel="S";  
                    if(Number(GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[0]))!=0)
                        varModuleLevel="S";           
                    document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                 }
//                    if (document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].checked==false)
//                        return false;
//                    else
//                        break;
            }
        }  
        
        if (document.getElementById('gvMenuMaster').rows.length<=rowIndex+2) return;
        if (GetInnerText(document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[1])!=null && GetInnerText(document.getElementById('gvMenuMaster').rows[rowIndex+2].cells[1])==null && Number(GetInnerText(document.getElementById('gvMenuMaster').rows[rowIndex+2].cells[0]))==0)
        {
            for (var intForLoop=rowIndex+2;intForLoop<document.getElementById('gvMenuMaster').rows.length;intForLoop++)
            {
                if (GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[1])==null)
                {
                    document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                    if (colIndex==3 && ddlvalue==false)
                    {
                    
                        document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[4].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[5].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop-1].cells[6].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop].cells[4].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop].cells[5].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                        document.getElementById('gvMenuMaster').rows[intForLoop].cells[6].getElementsByTagName('INPUT')[0].checked=ddlvalue;
                    }
                    if (document.getElementById('gvMenuMaster').rows[intForLoop].cells[3].getElementsByTagName('INPUT')[0].checked==false) document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].checked=false;
                }
                else 
                    return;
            }
        }  
        else if (GetInnerText(document.getElementById('gvMenuMaster').rows[rowIndex+1].cells[1])==null)
        {
            for (intForLoop=rowIndex;intForLoop>0;intForLoop--)
            {
                 if (GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop].cells[1])!=null && GetInnerText(document.getElementById('gvMenuMaster').rows[intForLoop+1].cells[1])==null)
                    if (document.getElementById('gvMenuMaster').rows[intForLoop].cells[colIndex].getElementsByTagName('INPUT')[0].checked==false)
                        return false;
                    else
                        return true;
            }
        } 
        return true; 
    }
    catch(err)
    {
//        alert('Sorry, an error Occured');
        pDisplayMessageclient("<%=Session["Type"].ToString() %>","129_1","");
        return false;
    }
}    
        
   
function checkEmpty()
{   
        var strvalue=document.frmMTUserManagement.txtUserId.value;
        var strArray=document.getElementById('hidFlag').value.split('^');
        if (strvalue=="")
        {
//         alert("Please Enter User Id");
         pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblUserId').innerHTML);                
         document.frmMTUserManagement.txtUserId.focus();
         return false;
        }
        var strvalue=document.frmMTUserManagement.txtUserName.value;
        if(strvalue=="")
        {
        //   alert("Please Enter User Name");
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblUserName').innerHTML);                
            document.frmMTUserManagement.txtUserName.focus();
            return false;
        }
          
      var strvalue=document.frmMTUserManagement.txtPassword.value;
         if (strvalue =="" && strArray[0]!="E")
         { alert("Please Enter Your Password");
           //pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblPassword').innerHTML);                
           document.frmMTUserManagement.txtPassword.focus();
           return false;
         }
          var strvalue1 = document.frmMTUserManagement.txtConfirmPassword.value;
          if(strvalue != strvalue1)
          {
//          alert("Password and Confirm Password should be same");
          pDisplayMessageclient("<%=Session["Type"].ToString() %>","129_2","");
          document.frmMTUserManagement.txtPassword.focus();
          return false;
          }
         if (document.getElementById('ddlUserType').value=="1" && document.getElementById('ddlEmployee').value=="")
         {
//            alert('Select Employee Name');
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","8","" + document.getElementById('lblEmployeeName').innerHTML);                
            document.getElementById('ddlEmployee').focus();
            return false;
         }
        else if (Number(document.getElementById('ddlUserType').value)>1 && document.getElementById('ddlEmployee').value=="")
         {
//            alert('Select Student Name');
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","8","" + document.getElementById('lblUserType').innerHTML);                
            document.getElementById('ddlEmployee').focus();
            return false;
         }
         document.getElementById("txtUserId").disabled  = false;
         
    var Flag=false;
    if (Number(document.getElementById('ddlUserType').value)<=1)
    { if(document.getElementById('gvMenuMaster')!=null)
        {
            var varRowLength=document.getElementById('gvMenuMaster').rows.length;
            var varFieldLength=document.getElementById('gvMenuMaster').rows[1].cells.length;
            for(var i=1;i<varRowLength;i++)
            {  if(document.getElementById('gvMenuMaster').rows[i].cells[varFieldLength-4].getElementsByTagName('INPUT')[0].checked==true)
                {   Flag=true;
                    break;
                }
            }            
        }
        if(!Flag)
        {
//            alert('Assign atleast one option for the User');
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","129_3","");
            return false;
        }
    }
        Flag=false;
        for (var intForLoop=0;intForLoop<document.getElementById('chkSchool').rows.length;intForLoop++)
        {  if (document.getElementById('chkSchool').rows[intForLoop].cells[0].getElementsByTagName('INPUT')[0].checked==true)
           {    Flag=true;
                break;
           }
        }
     if(!Flag)
        {
//            alert('Assign atleast one school for the User');
            pDisplayMessageclient("<%=Session["Type"].ToString() %>","129_4","");
            return false;
        }
//     if (confirm("Do You Want To Save ?")==false)
     if(confirm(pDisplayMessageclient("<%=Session["Type"].ToString() %>","18",""))==false)
      {
      return false;
      document.getElementById("txtUserId").disabled  = false;
      }
      //ReplaceSpecialcharacter('frmMTUserManagement'); 
    return true;
}
      
     function UserLimit(Val)
        {  
        if(Val=="N")
            { var strNew=document.getElementById('hidCache').value.split(';')[0];
                if(strNew!="Y")
                {
//                    alert("You Don't Have Permission To Create");
                    pDisplayMessageclient("<%=Session["Type"].ToString() %>","1","");
                    return false;                    
                }
            }
            else if(Val=="E")
            {  var strEdit=document.getElementById('hidCache').value.split(';')[1];
                if(strEdit!="Y")
                {
//                     alert("You Don't Have Permission To Edit");
                     pDisplayMessageclient("<%=Session["Type"].ToString() %>","2","")
                     return false;   
                }
            }
            else if(Val=="D")
            {
                var strEdit=document.getElementById('hidCache').value.split(';')[1];
                if(strEdit!="Y")
                {
//                     alert("You Don't Have Permission To Delete");
                     pDisplayMessageclient("<%=Session["Type"].ToString() %>","3",""); 
                     return false;   
                }
            }
        }

    function User_Control()
     { if(UserLimit('N')==false)
        { return false;
        } 
        //ReplaceSpecialcharacter('frmMTUserManagement');  
      }
    function UserE_Control()
    { if(UserLimit('E')==false)
        {return false;
        } 
        pEnableDisable('EDIT');        
        return false;
    }
    function UserD_Control()
    {  if(UserLimit('D')==false)
        { return false;
        } 
//        if(confirm("Do You Want To Delete?"))
        if(confirm(pDisplayMessageclient("<%=Session["Type"].ToString() %>","5","")))
        {
            //ReplaceSpecialcharacter('frmMTUserManagement');  
            return true;
            }
        else
        {
        //ReplaceSpecialcharacterToNormal('frmMTUserManagement');  
            return false;
            }
    }
    
  
   function pEnableDisable(varAction)
    {  switch(varAction)
        {   case "NEW":
                 document.getElementById('txtUserId').readOnly=false;      
            case "EDIT":
            
                document.getElementById('btnNew').disabled=true;
                document.getElementById('btnEdit').disabled=true;
                document.getElementById('btnSave').disabled=false;
                document.getElementById('btnCancel').disabled=false;
                document.getElementById('btnDelete').disabled=true;
                document.getElementById('ddlUserType').disabled=false; 
                document.getElementById('ddlUserGroup').disabled=false;     
                document.getElementById('txtUserName').readOnly=false;
                document.getElementById('txtPassword').readOnly=false;
                document.getElementById('txtConfirmPassword').readOnly=false;
                
                if ((document.getElementById('ddlUserType').value )== "0" ||(document.getElementById('ddlUserType').value )== "6" )
                { 
                    document.getElementById('ddlEmployee').disabled=true; 
                }
                else 
                {
                    document.getElementById('ddlEmployee').disabled=false;
                }
                break;
            case "LOAD":
            case "SAVE":
            case "CANCEL":
                document.getElementById('btnNew').disabled=false;
                document.getElementById('btnEdit').disabled=true;
                document.getElementById('btnSave').disabled=true;
                document.getElementById('btnCancel').disabled=true;
                document.getElementById('btnDelete').disabled=true;
                document.getElementById('ddlUserType').disabled=true;
                document.getElementById('ddlUserGroup').disabled=true;
                document.getElementById('ddlEmployee').disabled=true;
                break;
            case "DISPLAY":
                document.getElementById('btnNew').disabled=false;
                document.getElementById('btnEdit').disabled=false;
                document.getElementById('btnSave').disabled=true;
                document.getElementById('btnCancel').disabled=false;
                document.getElementById('btnDelete').disabled=false;
                document.getElementById('ddlUserType').disabled=true;
                document.getElementById('ddlUserGroup').disabled=true;
                document.getElementById('ddlEmployee').disabled=true;
                break;
                
            default:
                break;
        }
         fChangeButtonColor('frmMTUserManagement','#400000');
    }
    
    
    
     var varSelRow=null;
        function fGridDoubleClick(intRowIndex)
        { 
        if(varSelRow!=null)
        {
            varSelRow.style.backgroundColor = (varSelRowIndex % 2 == 0 ? "#EBEBEB":"activeborder") ;
            }
            document.getElementById("gvUserDetails").rows[intRowIndex+1].style.backgroundColor  = '#ffc0cb';
            varSelRow=document.getElementById("gvUserDetails").rows[intRowIndex+1];
            varSelRowIndex=intRowIndex;
            document.getElementById('txtUserId').value=GetInnerText(document.getElementById("gvUserDetails").rows[intRowIndex+1].cells[1]);
            document.getElementById('txtUserName').value=GetInnerText(document.getElementById("gvUserDetails").rows[intRowIndex+1].cells[2]);
            document.getElementById('btnEdit').disabled=false;
            document.getElementById('btnDelete').disabled=false;
            document.getElementById('btnNew').disabled=true;
            document.getElementById('btnSave').disabled=true;

            fChangeButtonColor('frmMTUserManagement','#400000');
        }
   
 

function fValidation_On_Cancel() {
         //ReplaceSpecialcharacter('frmMTUserManagement');
     }
     function fValidation_On_Close() {
         //ReplaceSpecialcharacter('frmMTUserManagement');
     }

       function fValidation_On_Search() {
         //ReplaceSpecialcharacter('frmMTUserManagement');
     }

 </script>
</head>
<body  dir="<%=strType %>" style="background-image:url(Images/backgroundImg.jpg); background-repeat :repeat ; background-position: center center; background-attachment: scroll;"><%--bgcolor="whitesmoke"--%>
    <form id="frmMTUserManagement" runat="server" dir="<%=strType %>">
    <div id="divMain" align="center">
    <table id="tblMain" style="width:731px;" class="divCircle" cellpadding="0" cellspacing="0" >
    <tr><td class="MyTableBorder">
            <table border="0" class="myLabel" style="width:731px;" >
                
                
                <tr>
                    <td align="center" class="MyTableHeader" colspan="5"
                        valign="top"  >
                        <strong><span>
                            <asp:Label ID="lblUserManagement" runat="server" Text="User Management" CssClass="MyLabelHeader"></asp:Label></span></strong></td>
                </tr>
                <tr>
                    <td align="right"  valign="top" class="MyLabel" >
                        <asp:Label ID="lblUserId" runat="server" CssClass="MyLabel" Text="User Id"></asp:Label></td>
                    <td align="left" valign="top">
                    <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td ><asp:TextBox ID="txtUserId" runat="server"  Width="127px" CssClass="MyTextBox" MaxLength="30" TabIndex="1"></asp:TextBox></td>
                        <td><asp:Button ID="btnSearch" runat="server"  Font-Bold="True" Height="18px"  Width="20px" CssClass="MyButton" Text="?" OnClientClick="return fValidation_On_Search()"  OnClick="btnSearch_Click" /></td>
                    </tr>
                    </table></td>
                    <td align="right" valign="top" class="MyLabel">
                        <asp:Label ID="lblUserName" runat="server" CssClass="MyLabel" Text="User Name"></asp:Label>&nbsp;</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtUserName" runat="server"  CssClass="MyTextBox" MaxLength="100" TabIndex="2" Width="127px"></asp:TextBox></td>
                    <td align="left" colspan="0" rowspan="3" valign="top" dir="ltr"  >                    
                    <asp:Panel ID="pnlSchool" runat="server" GroupingText="School" CssClass="MyLabel">
                    <asp:Panel ID="pnlchkBox" runat="server" Height="60px" ScrollBars="Auto" BorderWidth="1px">
                        <asp:CheckBoxList ID="chkSchool" runat="server" CssClass="MyLabel" CellPadding="0" CellSpacing="0" TabIndex="7">  </asp:CheckBoxList>
                        </asp:Panel>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" class="MyLabel">
                        <asp:Label ID="lblPassword" runat="server" CssClass="MyLabel" Text="Password"></asp:Label>&nbsp;</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password"
                            Width="127px" CssClass="MyTextBox" MaxLength="250" TabIndex="3" ></asp:TextBox>
                    </td>
                    <td align="right" valign="top" class="MyLabel">
                        <asp:Label ID="lblConfirmPassword" runat="server" CssClass="MyLabel" Text="Confirm Password"></asp:Label></td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtConfirmPassword" runat="server"  TextMode="Password"
                            Width="127px" CssClass="MyTextBox" MaxLength="250" TabIndex="4"></asp:TextBox></td>
                </tr>
               <%-- <tr id="trUserType" runat="server">--%>
               <tr>
                    <td align="right" class="MyLabel" 
                        valign="top" >
                        <asp:Label ID="lblUserType" runat="server" CssClass="MyLabel" Text="User Type"></asp:Label></td>
                    <td align="left" valign="top">
                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="MyTextBox" Width="131px" TabIndex="5" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged"  AutoPostBack="True" >
                            <asp:ListItem Value="0">Administrator</asp:ListItem>
                            <asp:ListItem Value="1">Employee</asp:ListItem>
                            <%--<asp:ListItem Value="6">Guest</asp:ListItem>--%>
                            
                    <%--        <asp:ListItem Value="2">Student</asp:ListItem>
                            <asp:ListItem Value="3">Parent</asp:ListItem>--%>
                        </asp:DropDownList></td>
                   <%-- <td align="right" class="MyLabel"  id="tdEmployee" runat="server"
                        valign="top" >--%>
                         <td align="right" class="MyLabel" valign="top" >
                        <asp:Label ID="lblEmployeeName" runat="server" CssClass="MyLabel" Text="Employee Name"></asp:Label></td>
                    <td align="left"   valign="top">
                                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="MyTextBox" Width="131px" TabIndex="6" onkeypress="return false" onkeyup="return false" onkeydown="AutoCompleteDDL('ddlEmployee',event)">
                                    </asp:DropDownList></td>
                </tr>
                <%--<tr runat="server" id="Tr1">--%>
           <tr>
                    <td align="right" class="MyLabel" valign="top">
                        User Group</td>
                    <td align="left" valign="top">
                        <asp:DropDownList ID="ddlUserGroup" runat="server" CssClass="MyTextBox" Width="131px" TabIndex="5"  AutoPostBack="True" OnSelectedIndexChanged="ddlUserGroup_SelectedIndexChanged" >
                        </asp:DropDownList></td>
                    <td align="right" class="MyLabel" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
               <td align="left" colspan="0" rowspan="3" valign="top" dir="ltr"  >  
                     <asp:Panel ID="pnlLIB" runat="server" CssClass="MyLabel" GroupingText="Library"   >
                    <asp:Panel ID="pnlLIBrary" runat="server" Height="80px" ScrollBars="Auto"  BorderWidth="1px">
                        <asp:CheckBoxList ID="chkLibrary" runat="server" CellPadding="0" CellSpacing="0" CssClass="MyLabel" TabIndex="7" >  </asp:CheckBoxList>
                    </asp:Panel>
                        </asp:Panel>
                    
               </td>
                </tr>
                <tr>
                    <td align="right" class="MyLabel" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
                    <td align="right" class="MyLabel" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" valign="top" >
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td><asp:Button ID="btnNew" runat="server"   OnClick="btnNew_Click" OnClientClick="javascript:return User_Control();" Text="New" CssClass="MyButton" TabIndex="8" /></td>
                                 <td><asp:Button ID="btnEdit" runat="server"  OnClick="btnEdit_Click" Text="Edit" CssClass="MyButton" TabIndex="9" /></td>
                                 <td><asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" Text="Delete" CssClass="MyButton" TabIndex="10" /></td>
                                 <td><asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" Text="Save" OnClientClick="javascript:return fvalidate_Save()" CssClass="MyButton" TabIndex="11" /></td>
                                 <td><asp:Button ID="btnCancel" runat="server"  OnClientClick="return fValidation_On_Cancel()" OnClick="btnCancle_Click" Text="Cancel" CssClass="MyButton" TabIndex="12"/></td>
                                <td><asp:Button ID="btnClose" runat="server"  OnClientClick="return fValidation_On_Close()" OnClick="btnClose_Click" Text="Close" CssClass="MyButton" TabIndex="13"/></td>
                            </tr> 
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="5" valign="top">
                        
                        <asp:Panel ID="Panel2" runat="server" class="MyTableBorder" Height="300px" ScrollBars="Auto"
                            Width="731px">
                            <asp:GridView ID="gvMenuMaster" runat="server" CellPadding="0" Height="1px" 
                                Width="714px" TabIndex="14" GridLines="Horizontal" AutoGenerateColumns="False" 
                                OnRowDataBound="gvMenuMaster_RowDataBound" CssClass="mGrid"     AlternatingRowStyle-CssClass="alt" >
                                
                                <Columns>
                                    <asp:BoundField DataField="ModuleID" HeaderText="ModuleID">
                                    <ItemStyle HorizontalAlign="Right"/>
                                    <HeaderStyle HorizontalAlign="Right"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MenuLevel" HeaderText="MenuLevel">
                                    <ItemStyle HorizontalAlign="Left"/>
                                    <HeaderStyle HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MenuName" HeaderText="MenuName">
                                    <ItemStyle HorizontalAlign="Left"/>
                                    <HeaderStyle HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Module Name" HeaderText="Module Name">
                                    <ItemStyle HorizontalAlign="Left"/>
                                    <HeaderStyle HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Menu Name" HeaderText="Menu Name">
                                    <ItemStyle HorizontalAlign="Left"/>
                                    <HeaderStyle HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Menu Name1">
                                    <ItemStyle HorizontalAlign="Left"/>
                                    <HeaderStyle HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Visible">                                        
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkVisible" runat="server" Checked='<%# Bind("Visible") %>' Enabled="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="New">
                                        
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkNew" runat="server" Checked='<%# Bind("New") %>' Enabled="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkEdit" runat="server" Checked='<%# Bind("Edit") %>' Enabled="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkDelete" runat="server" Checked='<%# Bind("Delete") %>' Enabled="true" />
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

    </div>
     <%-- <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="txtUserId" PopupControlID="trUser" CancelControlID="btnClose"   >
        </cc1:ModalPopupExtender>--%>
        <asp:HiddenField ID="hidFlag" runat="server" />
        <asp:HiddenField ID="hidCache" runat="server" />
         <asp:HiddenField ID="hdntxtUserId" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

            <cc1:AutoCompleteExtender ID="AutoCompleteExtender" runat="server" CompletionInterval="1000"
             EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="GetUserAdminEmployee"
            ServicePath="WSStudentSearch.asmx" TargetControlID="txtUserId" CompletionListElementID="divUserName">
            </cc1:AutoCompleteExtender>

          <div class="MyLabel" id="divUserName" ></div>

        <asp:ListBox ID="ListBox" style="z-index:1000;display:none;" runat="server" Height="59px"></asp:ListBox>
    </form>   
</body>
</html>
