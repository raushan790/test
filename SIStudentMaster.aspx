<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SIStudentMaster.aspx.cs"
    Inherits="SIStudentMaster" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <base target="_self" />
    <title>:: CampusCare Online :: - Student Master</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <style media="screen" type="text/css">
        .Arrow-right
        {
            width: 0px;
            height: 0px;
            border-top: 15px solid transparent;
            border-bottom: 15px solid transparent;
            border-left: 25px solid rgba(10,150,0,0.7);
        }
        
        .divInner
        {
            border: 3px solid #ceddc0;
            border-radius: 2%;
            background: #ceddc0;
            z-index: 2;
            box-shadow: 0px 0px 10px rgba(10,150,0,0.7);
            -moz-box-shadow: 0px 0px 10px rrgba(10,150,0,0.7);
            -webkit-box-shadow: 0px 0px 10px rgba(10,150,0,0.7);
        }
        
        #divToolTip
        {
            position: absolute;
            left: 18%;
            top: 14%;
        }
        </style>
    <script language="javascript" type="text/javascript">
    
   
        
    addLoadEvent(pLoad); 
    function pLoad() 
    { //alert(document.getElementById('hdnFlag').value);

//        debugger;

           //document.getElementById('divToolTip').style.display='none';
            if(document.getElementById('hidAutoClear').value=="C")
            {
                document.getElementById('chkAClear').checked=true;
            }
            else
            {
                document.getElementById('chkAClear').checked=false;
            }
            if(document.getElementById('hdnFlag').value=="PID")
            {
                pHandleOnEdit();
               
            }
            if (document.getElementById('hdnFlag').value=='^^')
            {    
               
                pEnableDisable('CANCEL');
                
                document.getElementById('tdNoimage').style.display="none";
                document.getElementById('tbImageCaption').style.display="none";
                 document.getElementById('lblCaption1').innerHTML=""; 
                document.getElementById('txtStuSelect').disabled=false; 
                document.getElementById('trRoutedetails').style.display="none";
                document.getElementById('lblStudentStatus').innerHTML=""; 
                document.getElementById('lblBusMorning').style.display="none";
                document.getElementById('lblBusMorninghr').style.display="none";
                document.getElementById('lblBusAfterNoonhr').style.display="none";
                document.getElementById('lblBusAfterNoon').style.display="none";
                 
                 /*-----------Added By Manju on 06-02-2012-------------*/ 
                 if(document.getElementById('hdnFlagPresCity') =="R")
                 {
                 document.getElementById('btnNew').disabled=true;
                 document.getElementById('btnEdit').disabled=true;
                 document.getElementById('btnSave').disabled=false;
                 document.getElementById('btnDropOut').disabled=true;
                 document.getElementById('btnDetails').disabled=true;
                 document.getElementById('btnTC').disabled=true;
                 document.getElementById('btnRemarks').disabled=true;
                 document.getElementById('btnCancel').disabled=false;
                 document.getElementById('btnClose').disabled=false;
                 
                 }
               
                 if(document.getElementById('hdnFlagPerCity') =="P")
                 {
                     document.getElementById('btnNew').disabled=true;
                     document.getElementById('btnEdit').disabled=true;
                     document.getElementById('btnSave').disabled=false;
                     document.getElementById('btnDropOut').disabled=true;
                     document.getElementById('btnDetails').disabled=true;
                     document.getElementById('btnTC').disabled=true;
                     document.getElementById('btnRemarks').disabled=true;
                     document.getElementById('btnCancel').disabled=false;
                     document.getElementById('btnClose').disabled=false;
                 }
                 /*-----------End of Added By Manju on 06-02-2012-------------*/ 
                 
                 if(document.getElementById('hdnFindSearch').value=="F")  
                 { 
                     //window.parent.document.getElementById('leftTD').style.width = "1%";
                     //window.parent.document.getElementById('rightTD').style.width = "99%";
                     document.getElementById('divFind').style.left="5px"
                     document.getElementById('divFind').style.top="12px"
                     document.getElementById('divFind').style.display="";
                     document.getElementById('divFind').style.position="absolute";         
                     document.getElementById('divMain').align="center";
                 }
                 fChangeButtonColor('frmStudentmaster','#400000');
                 return false;
            }  
            if(document.getElementById('hdnFlag').value=="A" ||document.getElementById('hdnFlag').value=="E^")
            {
                pEnableDisable('DISPLAY'); 
                fChangeButtonColor('frmStudentmaster','#400000'); 
                pAddGridAttributesDisplay('frmStudentmaster');
                if(document.getElementById('hdnFlag').value=="A")
                {
                    document.getElementById('trRoutedetails').style.display='';
                    if(document.getElementById('lblBusMorning').innerHTML!="")
                    {
                        document.getElementById('lblBusMorning').style.display='';
                        document.getElementById('lblBusMorninghr').style.display='';
                    }
                    else
                    {
                        document.getElementById('lblBusMorning').style.display='none';
                        document.getElementById('lblBusMorninghr').style.display='none';
                    }
                    if(document.getElementById('lblBusAfterNoon').innerHTML!="")
                    {
                        document.getElementById('lblBusAfterNoonhr').style.display='';
                        document.getElementById('lblBusAfterNoon').style.display='';
                    }  
                    else
                    {
                        document.getElementById('lblBusAfterNoonhr').style.display='none';
                        document.getElementById('lblBusAfterNoon').style.display='none';
                    }    
                }
            }
            if(document.getElementById('hdnFlag').value=="S")
            {
                pEnableDisable('SEARCH'); 
            }
            if(document.getElementById('hdnFlag').value =="N^")
            {
                document.getElementById('btnNew').disabled=true;
                document.getElementById('btnEdit').disabled=true;
                document.getElementById('btnSave').disabled=false;
                document.getElementById('btnDropOut').disabled=true;
                document.getElementById('btnDetails').disabled=true;
                document.getElementById('btnTC').disabled=true;
                document.getElementById('btnRemarks').disabled=true;
                document.getElementById('trRoutedetails').style.display="none";
                 document.getElementById('tdNoimage').style.display="none";
                document.getElementById('tbImageCaption').style.display="none";
                 document.getElementById('lblCaption1').innerHTML=""; 
                document.getElementById('btnCancel').disabled=false;
                document.getElementById('btnClose').disabled=false;
                document.getElementById('ddlFeeGroup').value=0;
                document.getElementById('ddlFeeApplnFrom').value=0;
                document.getElementById("txtLiveEduID").readOnly=true;
                fChangeButtonColor('frmStudentmaster','#400000'); 
            }
            if (document.getElementById('hdnFlag').value.split('^')[0]=="E" || document.getElementById('hdnFlag').value.split('^')[0]=="N")                       
            {
                pAddGridAttributesDisplay('frmStudentmaster');
                fChangeButtonColor('frmStudentmaster','#400000'); 
            }
            if(document.getElementById('hdnFlag').value=='ADVSER') // advance search
            {
                pLockControls('frmStudentmaster');
                document.getElementById('trSearch').style.display='none';
                document.getElementById('tblButton').style.display='none';
                document.getElementById('tdOption').style.display='none';
                document.getElementById('AddPhoto').style.display='none';
                document.getElementById('RemovePhoto').style.display='none';
                document.getElementById('imgbtnAddress').disabled=true;
                document.getElementById('txtAdmNo').disabled=true;
               // document.getElementById('txtFeeNo').disabled=true;
              
                var offset=(navigator.userAgent.indexOf("Mac")!=-1 || navigator.userAgent.indexOf("Gecko")!=-1 || navigator.userAgent.indexOf("Netscape")!=-1)?0:4;
                window.moveTo(200,70);
                //window.moveTo(-offset,-offset);
                window.resizeTo(785,700);
                // window.resizeTo(screen.availWidth+(2*offset),screen.availHeight+(2*offset));
                return false; 
            }
            document.getElementById('trName').style.display='none'; 
            /*---------------- Added by poonam on 14.11.2012 ------------------------*/ 
            fChangeButtonColor('frmStudentmaster','#400000'); 
            /*----------------End of Added by poonam on 14.11.2012 ------------------------*/ 
    }
    
     function callreturn()
    {
        return false;
    }
   
    function pEnableDisable(varAction)
    {  
    //debugger;
        switch(varAction)
        {  case "NEW":
                pClearFields('frmStudentmaster');  
                pUnLockControls('frmStudentmaster');
                document.getElementById("txtLiveEduID").readOnly=true;
                StateCityDiable();
                
            case "EDIT":
                document.getElementById('btnNew').disabled=true;
                document.getElementById('btnEdit').disabled=true;
                document.getElementById('btnSave').disabled=false;               
                document.getElementById('btnDropOut').disabled=true;
                document.getElementById('txtStuSelect').readOnly=true;
                document.getElementById('btnDetails').disabled=true; 
                document.getElementById('btnTC').disabled=true;  
                document.getElementById('btnRemarks').disabled=true;    
               document.getElementById("txtLiveEduID").readOnly=true;
                //document.getElementById('chkParentDetailUpdate').checked=true;
                document.getElementById('chkParentDetailUpdate').checked=false;
                StateCityDiable();
                break; 
                /*===========Added By Manju on 28-04-2012==============*/
            case "SEARCH":   
                //document.getElementById('divFind').style.display='block';
                
                //document.getElementById('ddlFindClass').disabled=false; 
                document.getElementById('btnNew').disabled=false;
                document.getElementById('btnEdit').disabled=true;
                document.getElementById('btnSave').disabled=true;            
                document.getElementById('btnDropOut').disabled=true;  
                document.getElementById('btnTC').disabled=true; 
                document.getElementById('btnRemarks').disabled=true;
                document.getElementById('btnDetails').disabled=true;         
                //pClearFields('frmStudentmaster');
                pLockControls('frmStudentmaster'); 
                document.getElementById('ddlFindClass').disabled=false;   
                document.getElementById('ddlFindSection').disabled=false;  
                
                document.getElementById('divFind').style.left="5px"
                document.getElementById('divFind').style.top="12px"
                document.getElementById('divFind').style.display="";
                document.getElementById('divFind').style.position="absolute";         
                document.getElementById('divMain').align="center";
                
                
                break;
               /*===========Added By Manju on 28-04-2012==============*/
            case "CANCEL":
                document.getElementById('btnNew').disabled=false;
                document.getElementById('btnEdit').disabled=true;
                document.getElementById('btnSave').disabled=true;            
                document.getElementById('btnDropOut').disabled=true;  
                document.getElementById('btnTC').disabled=true; 
                document.getElementById('btnRemarks').disabled=true;
                document.getElementById('btnDetails').disabled=true;         
                pClearFields('frmStudentmaster');
                pLockControls('frmStudentmaster'); 
                document.getElementById('txtStuSelect').readOnly=false;
                document.getElementById('txtAdmNo').readOnly=false;     
                 document.getElementById('txtFeeNo').readOnly=false;     
                
                document.getElementById('txtParentID').readOnly=false;
                document.getElementById('chkAClear').checked=false;  
                document.getElementById("txtLiveEduID").readOnly=true;
                break;
            case "DISPLAY":
                document.getElementById('btnNew').disabled=false;
                document.getElementById('btnEdit').disabled=false;
                document.getElementById('btnSave').disabled=true;
                document.getElementById('btnTC').disabled=false;    
                document.getElementById('btnRemarks').disabled=false;    
                document.getElementById('btnCancel').disabled=false;
                document.getElementById('btnDropOut').disabled=false;   
                pLockControls('frmStudentmaster');    
                if(document.getElementById('hidStatusdisplay').value!="")
                {
                   document.getElementById('tdNoimage').style.display="";
                 document.getElementById('tbImageCaption').style.display="";
                 //document.getElementById('lblCaption1').innerHTML=""; 
                }
                 if(document.getElementById('hidStatusdisplay').value=="")
                {
                 document.getElementById('tdNoimage').style.display="none";
                 document.getElementById('tbImageCaption').style.display="none";
                 //document.getElementById('lblCaption1').innerHTML=""; 
                }
               
                document.getElementById('txtStuSelect').readOnly=true;
                document.getElementById('txtAdmNo').readOnly=true; 
                 document.getElementById('txtFeeNo').readOnly=true;        
                document.getElementById('txtParentID').readOnly=true;     
                document.getElementById("txtLiveEduID").readOnly=true;
                document.getElementById('ddlFindClass').disabled=false;
                document.getElementById('ddlFindSection').disabled=false;
                document.getElementById('txtFindFatherName').readOnly=false;
                document.getElementById('txtFindMotherName').readOnly=false;
                document.getElementById('txtFindStudent').readOnly=false; 
                document.getElementById('btnDetails').disabled=false;
                break;
            default:
                break;
        }
         if(document.getElementById('gvSibling')!=null)
           {  if(document.getElementById('gvSibling').rows.length>1)
               {   
                    for(var varLoop = 1; varLoop < document.getElementById('gvSibling').rows.length; varLoop++)
                    {  document.getElementById('gvSibling').rows[varLoop].cells[2].getElementsByTagName('INPUT')[0].readOnly=true;   
                    }                      
                 
               }
             }
        fChangeButtonColor('frmStudentmaster','#400000');
        return false;
    }
    
    function StateCityDiable()
    {    document.getElementById('txtPresState').readOnly=true;
         document.getElementById('txtPresCountry').readOnly=true;
         document.getElementById('txtPerState').readOnly=true;
         document.getElementById('txtPerCountry').readOnly=true; 
    }
          
    function fAssign_New()
    {    
      //debugger;
        
        if (document.getElementById('hidCache').value.split(';')[0]=='N')
        {  pDisplayMessageclient("1","1","");
            return false;
        }    
        pClearFields('frmStudentmaster');  
        pUnLockControls('frmStudentmaster');
        StateCityDiable();
      /*---------------- Added by poonam on 14.11.2012 ------------------------*/ 
         fChangeButtonColor('frmStudentmaster','#400000');
     /*----------------End of Added by poonam on 14.11.2012 ------------------------*/ 
 
                
        document.getElementById('lblStudentStatus').innerHTML=""; 
        document.getElementById('lblCaption1').innerHTML=""; 
              
        document.getElementById('hdnFlag').value="N";
        document.getElementById('hdntxtStuSelect').value='^';
       // document.getElementById('ddlFeeApplnFrom').value='';
        document.getElementById('imgStudent').src="StudentPhoto/NoImage.JPG";
         document.getElementById('tdNoimage').style.display="none";
          document.getElementById('lblCaption1').innerHTML=""; 
        document.getElementById('tbImageCaption').style.display="none";
        document.getElementById('txtAdmNo').focus();
       document.getElementById("txtLiveEduID").readOnly=true;
        fCloseFind();

    }
    
    function Assign_StudentAddress()
    {   document.getElementById('txtPerAddress').value=document.getElementById('txtPresAddress').value;
        document.getElementById('txtPerCity').value=document.getElementById('txtResiCity').value;
        document.getElementById('txtPerState').value=document.getElementById('txtPresState').value;
        document.getElementById('txtPerCountry').value=document.getElementById('txtPresCountry').value;
        document.getElementById('txtPerPincode').value=document.getElementById('txtPresPincode').value;
        document.getElementById('txtPerPhone').value=document.getElementById('txtPresPhone').value;
        return false;            
    }
    
    function pValidateOnSave()
    { 
       document.getElementById('hidFeeGrpID').value=document.getElementById('ddlFeeGroup').value;
       document.getElementById('hidFeeAppID').value=document.getElementById('ddlFeeApplnFrom').value;
       
       if (stripBlanks(document.getElementById('txtAdmNo').value)==''|| stripBlanks(document.getElementById('txtAdmNo').value)=='0')
        {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblAdmissionNo').innerHTML);
            document.getElementById('txtAdmNo').focus();
            return false;
        }
       else  if (stripBlanks(document.getElementById('txtFeeNo').value)=='')
        {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblFeeNo').innerHTML);
            document.getElementById('txtFeeNo').focus();
            return false;
        }       
       else  if (stripBlanks(document.getElementById('txtParentID').value)=='' ||  stripBlanks(document.getElementById('txtParentID').value)=="0")
        {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblParentID').innerHTML);
            document.getElementById('txtParentID').focus();
            return false;
        }
        else  if (stripBlanks(document.getElementById('txtFirstName').value)=='')
        {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblName').innerHTML);
            document.getElementById('txtFirstName').focus();
            return false;
        }
       else if (document.getElementById('ddlClass').value<=0)
        {   
        //pDisplayMessageclient("<%=Session["Type"].ToString() %>","8","" + document.getElementById('lblClass').innerHTML);
        alert("Please Select Class");
            document.getElementById('ddlClass').focus();
            return false;
        }
       else if (document.getElementById('ddlSection').value<=0)
        {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","8","" + document.getElementById('lblSection').innerHTML);
            document.getElementById('ddlSection').focus();
            return false;
        }
       else if (document.getElementById('ddlFeeGroup').value<=0)
        {  if (document.getElementById("ddlFeeGroup").length==0)
            { pDisplayMessageclient("<%=Session["Type"].ToString() %>","307_1","" + document.getElementById('lblFeeGroup').innerHTML);
               document.getElementById('ddlFeeGroup').focus();
              return false;
            }
            else
            { pDisplayMessageclient("<%=Session["Type"].ToString() %>","8","" + document.getElementById('lblFeeGroup').innerHTML);
              document.getElementById('ddlFeeGroup').focus();
              return false;
            }
        }
          else if (isNaN(document.getElementById('txtParentID').value)==true)
                {
                alert("Please enter a valid ParentID ");
                document.getElementById('txtParentID').value="";
                document.getElementById('txtParentID').focus();
                
                return false;
               }
       else if (document.getElementById('ddlFeeApplnFrom').value<=0)
       { if (document.getElementById("ddlFeeGroup").length==0)
            { pDisplayMessageclient("<%=Session["Type"].ToString() %>","307_1","" + document.getElementById('lblFeeApplnFrom').innerHTML);
              document.getElementById('ddlFeeApplnFrom').focus();
              return false;
            }
            else
            {pDisplayMessageclient("<%=Session["Type"].ToString() %>","8","" + document.getElementById('lblFeeApplnFrom').innerHTML);
             document.getElementById('ddlFeeApplnFrom').focus();
             return false;
           }
        }
           if(stripBlanks(document.getElementById('txtStuEmail').value)!="")
            {  if(validateEmail(document.getElementById('txtStuEmail').value)==false)
                {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","17","" + document.getElementById('lblStuEmail').innerHTML);                
                    document.getElementById('txtStuEmail').focus();
                    return false;
                 }
            }
            
           if (stripBlanks(document.getElementById('txtDOA').value) !="")
           {   
                if(!validateDate(document.getElementById('txtDOA').value))
                {   
                    pDisplayMessageclient("<%=Session["Type"].ToString() %>","14","" + document.getElementById('lblDateOfAdmission').innerHTML);
                    document.getElementById('txtDOA').focus();
                    return false;
                }
           }
           if (stripBlanks(document.getElementById('txtStuDOB').value) !="")
           {   
                if(!validateDate(document.getElementById('txtStuDOB').value))
                {  
                    pDisplayMessageclient("<%=Session["Type"].ToString() %>","14","" + document.getElementById('lblStuDOB').innerHTML);
                    document.getElementById('txtStuDOB').focus();
                    return false;
                }
           }
           if (stripBlanks(document.getElementById('txtDateOFJoin').value) !="")
           {   
                if(!validateDate(document.getElementById('txtDateOFJoin').value))
                {   
                    alert("Please Enter the valid Date Of Join in [Date Format dd/MM/yyyy]");     
                    document.getElementById('txtDateOFJoin').focus();
                    return false;
                }
           } 
           if (stripBlanks(document.getElementById('txtStuDOB').value)=="")
           {
                alert("Please Enter Date of Birth");
                document.getElementById('txtStuDOB').focus();
                return false;
           }
            if (stripBlanks(document.getElementById('txtSiqmaExpiryDate').value) !="")
            {   if(!validateIqamaDate(document.getElementById('txtSiqmaExpiryDate').value))
                {  
                    alert('Please Enter Res Perm No. & ExpiryDate In [dd/MM/yyyy] Format ');
                    document.getElementById('txtSiqmaExpiryDate').focus();
                    return false;
                }
            }
           fCloseFind();                  
          
    }
 function fFillListBox(varAction,e)
  { 
        try
        {
            var varKey;
            if (window.event)
            varKey=window.event.keyCode;
            else 
            varKey=e.which; 
         
            if(e=='13')
            varKey=e;

           
            if (varAction=='txtAdmNo')
            {
                if (varKey==13)
                {   
                    if(document.getElementById('txtAdmNo').value=="")
                    {
                    alert('Please Enter AdmissionNo!');
                    document.getElementById('txtAdmNo').focus();  
                    return false;           
                    }
                    else
                    {
                    document.getElementById('btnDisplay').click();             
                    document.getElementById('txtAdmNo').focus();       
                    return false;      
                    }
                }
                else if (<%=Session["Type"].ToString() %>=="1")
                {    
                    if((varKey>=48 && varKey<=57) || varKey==45 || varKey==8 || varKey==0 || varKey==47 || (varKey>=65 && varKey<=90) || (varKey>=97 && varKey<=122))
                    {
                    return true;
                    }
                    else
                    {
                    return false;
                    }
                }
            }
            
              if (varAction=='txtFeeNo')
            {
                if (varKey==13)
                {   
                    if(document.getElementById('txtFeeNo').value=="")
                    {
                    alert('Please Enter FeeNo!');
                    document.getElementById('txtFeeNo').focus(); 
                    return false;            
                    }
                    else
                    {
                    document.getElementById('btnDisplay').click();             
                    document.getElementById('txtFeeNo').focus();       
                    return false;      
                    }
                }
                else if (<%=Session["Type"].ToString() %>=="1")
                {    
                     if((varKey>=48 && varKey<=57) || varKey==45 || varKey==8 || varKey==0 || varKey==47 || (varKey>=65 && varKey<=90) || (varKey>=97 && varKey<=122))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                }
            }            
            else
            { 
            return true; 
            }         
        }  
        catch (ex)
        {
        return false;
        }
}

function HandleResponse(e)
 {//debugger;

    if(XmlHttp.readyState == 4)
    {
        if(XmlHttp.status == 200)
        {
            try
            { //
                var varStudent=XmlHttp.responseText.split('^');
                if (varStudent.length>10)
                {
                   var intIncr=0;
                    document.getElementById('hdnSImagePath').value='';
                    document.getElementById('imgStudent').src="StudentPhoto/S"+varStudent[0].replace(/\//g,"-")+".JPG";
                    document.getElementById('hdntxtStuSelect').value=varStudent[0];
                    document.getElementById('hdnSDID').value=varStudent[0];
                    
                    document.getElementById('txtFirstName').value=varStudent[1];
                    document.getElementById('txtMiddleName').value=varStudent[2];
                    document.getElementById('txtLastName').value=varStudent[3];
                    document.getElementById('txtArabicName').value=varStudent[4];
                     if (varStudent[5]=='M') 
                        document.getElementById('rbtnMale').checked=true;
                    else 
                        document.getElementById('rbtnFemale').checked=true;               
                    document.getElementById('txtStuDOB').value=varStudent[6];
                    document.getElementById('txtDOA').value=varStudent[7];
                    document.getElementById('ddlAdmittedClass').value=varStudent[8];
                    document.getElementById('ddlSocCategory').value=varStudent[9];
                    document.getElementById('ddlReligion').value=varStudent[10];
                    document.getElementById('ddlCaste').value=varStudent[11];
                    document.getElementById('txtStuEmergencyNo').value=varStudent[12];
                    document.getElementById('txtStuEmail').value=varStudent[13];
                    document.getElementById('ddlBloodGroup').value=varStudent[14];
                    document.getElementById('ddlNationality').value=varStudent[15];
                    document.getElementById('ddlMotherTongue').value=varStudent[16];
                    
                    document.getElementById('txtParentID').value=varStudent[17];
                   
                    document.getElementById('txtSiqmano').value=varStudent[18];
                    document.getElementById('txtNoOfChild').value=varStudent[19];
                    document.getElementById('txtPositionChild').value=varStudent[20];
                                                                               
                    document.getElementById('txtAdmNo').value=varStudent[21];
                    document.getElementById('txtFeeNo').value=varStudent[22];
                    document.getElementById('ddlClass').value=varStudent[23];
                    //////document.getElementById('ddlStream').value=varStudent[23];
                    document.getElementById('ddlSection').value=varStudent[24];
                    //
                   if (varStudent[25]=='N') 
                        document.getElementById('rbtnAdmissionNew').checked=true;
                    else 
                        document.getElementById('rbtnAdmissionOld').checked=true;     
                        //
                                 
                    document.getElementById('txtRollNo').value=varStudent[26];
                    
                    document.getElementById('ddlHouse').value=varStudent[27];
                    document.getElementById('ddlBoard').value=varStudent[28];
                    document.getElementById('txtBoardRegNo').value=varStudent[29];
                    document.getElementById('ddlBoardingCategory').value=varStudent[30];
                    document.getElementById('txtChildCode').value=varStudent[31];                    
                  
                    document.getElementById('txtRemarks').value=varStudent[32];                    
                    document.getElementById('txtPresAddress').value=varStudent[33];
                    document.getElementById('hdntxtResiCity').value=varStudent[34];
                   
                 // AssignState('txtResiCity',varStudent[62]);
                    document.getElementById('txtPresPincode').value=varStudent[35];
                    document.getElementById('txtPresPhone').value=varStudent[36];
                    
                    document.getElementById('txtPerAddress').value=varStudent[37];
                   document.getElementById('hdntxtPerCity').value=varStudent[38];
                   //AssignState('txtPerCity',varStudent[66]);
                    document.getElementById('txtPerPincode').value=varStudent[39];
                    document.getElementById('txtPerPhone').value=varStudent[40];
                                 
              
                    document.getElementById('txtResiCity').value=varStudent[41];  
                    document.getElementById('txtPresState').value=varStudent[42];
                    document.getElementById('txtPresCountry').value=varStudent[43];
                   
                    document.getElementById('txtPerCity').value=varStudent[44];
                    document.getElementById('txtPerState').value=varStudent[45];
                    document.getElementById('txtPerCountry').value=varStudent[46];
                    
                    document.getElementById('ddlFTitle').value=varStudent[47];
                    document.getElementById('txtFName').value=varStudent[48];
                    document.getElementById('ddlMTitle').value=varStudent[49];                     
                    document.getElementById('txtMName').value=varStudent[50];
                    document.getElementById('ddlFeeGroup').value=varStudent[51];
                    document.getElementById('ddlFeeApplnFrom').value=varStudent[52]; 
                    //document.getElementById('ddlStop').value=varStudent[67];
                  
                    if (stripBlanks(varStudent[53])=="T")
                    {  document.getElementById('lblStudentStatus').innerHTML=pReturnSingleValue("Select Caption<%=Session["Type"] %> FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");           
                    }
                    else if (stripBlanks(varStudent[53])=="D")
                    {document.getElementById('lblStudentStatus').innerHTML=pReturnSingleValue("Select Caption<%=Session["Type"] %> FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");           
                    }
                    else
                    {document.getElementById('lblStudentStatus').innerHTML="";
                    }
                    document.getElementById('txtSiqmaExpiryDate').value=varStudent[54];
                    document.getElementById('ddlConcessionType').value=varStudent[55];
                    document.getElementById('ddlMeal').value=varStudent[56];
                    document.getElementById('ddlSchoolBus').value=varStudent[57];
                    document.getElementById('ddlSecondLanguage').value=varStudent[58];
                    document.getElementById('ddlThirdLanguage').value=varStudent[59];
                    document.getElementById('ddlStuLiving').value=varStudent[60]; 
                  
                   if (varStudent[61]=='Y') 
                       { document.getElementById('rbtProvYes').checked=true;}
                    else 
                        {document.getElementById('rbtProvNo').checked=true;}
                    document.getElementById('txtDateOFJoin').value=varStudent[62];
                   document.getElementById("txtLiveEduID").value=varStudent[63];
                   
                   
                   document.getElementById ('txtCBSERollNo').value=varStudent[65];
                   document.getElementById ('txtCaste').value=varStudent[68];
                   
                  return false;                    
              }
               else
               {   
                  pDisplayMessageclient("<%=Session["Type"].ToString() %>","17",""); 
                   // alert('Invalid Number' ); 
                    return false;
               }
            }
            catch (ex)
            {
                return false;
            }
           
        }
        else
        {     
          pDisplayMessageclient("<%=Session["Type"].ToString() %>","12","");      
        }
    }
}

  function pHandleOnEdit()
    {
 
        var strEdit=document.getElementById('hidCache').value.split(';')[1];
             if(strEdit!="Y")
             {     pDisplayMessageclient("<%=Session["Type"].ToString() %>","2","");                  
                   return false;
             }   
                   
        pUnLockControls('frmStudentmaster');

      
      /*========================================End of Modified By Manju on 25-04-2012==============================================================*/
        document.getElementById('hdnFlag').value="E^"+document.getElementById('hdntxtStuSelect').value+"^"+document.getElementById('txtAdmNo').value+"^"+document.getElementById('txtRollNo').value+"^"+document.getElementById('txtFeeNo').value;
        pEnableDisable('EDIT');     
        document.getElementById("txtLiveEduID").readOnly=true;
        fChangeButtonColor('frmStudentmaster','#400000');
        return false;
    }          
        
    function pChangePhoto(varAction)
    { 
      if (varAction=='Add')
        {
             var returnValue="";
            if (window.showModalDialog) 
            {
                //returnValue=window.showModalDialog('MTUploadPhoto.aspx','',"dialogWidth:360px;dialogHeight:175px;status=no;location=no;left=100;top=100");
                returnValue=window.showModalDialog('MTUploadSIPhoto.aspx','',"dialogWidth:360px;dialogHeight:175px;status=no;location=no;left=100;top=100");
            }
            else
            {
                //returnValue=window.open("MTUploadPhoto.aspx","","height=10%,width=30%,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes");
                returnValue=window.open("MTUploadSIPhoto.aspx","","height=10%,width=30%,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes");
            }
            if (returnValue==null || returnValue==undefined || returnValue =="")
                    {
     
                            var varDate=new Date();
                            //var requestUrl = "MTUploadPhoto.aspx?varDate=" + varDate +"&TypeID=ImgePath";
                            var requestUrl = "MTUploadSIPhoto.aspx?varDate=" + varDate +"&TypeID=ImgePath";
                           CreateXmlHttp();
                
                            if(XmlHttp)
                            {
                              XmlHttp.onreadystatechange = HandleImage;
                                          if (navigator.userAgent.toLowerCase().indexOf("msie")!=-1)
                                    XmlHttp.open("GET", requestUrl,  false);
                                else
                                    XmlHttp.open("GET", requestUrl,  true);
                                XmlHttp.send(null); 
                            }

                        return false;

                     }
                     else
                     {

                var CheckFormat=returnValue.split('.');
                if(CheckFormat[CheckFormat.length-1].toLowerCase()=='JPG' || CheckFormat[CheckFormat.length-1].toLowerCase()=='gif' || CheckFormat[CheckFormat.length-1].toLowerCase()=='jpeg' || CheckFormat[CheckFormat.length-1].toLowerCase()=='jpg') 
                {
                    var varClTime=new Date();
                    document.getElementById('hdnSImagePath').value=returnValue;
                    //document.getElementById('imgStudent').src="MTUploadPhoto.aspx?TypeID=Image&DtTime="+varClTime+"&strFileName=" + encodeURIComponent(document.getElementById('hdnSImagePath').value) + "";

                    document.getElementById('imgStudent').src="MTUploadSIPhoto.aspx?TypeID=Image&DtTime="+varClTime+"&strFileName=" + encodeURIComponent(document.getElementById('hdnSImagePath').value) + "";

                    document.getElementById('RemovePhoto').style.display='block';
                    document.getElementById('AddPhoto').innerHTML="<%=strChangePhoto%>";
                    return false;
                }
                else
                {
                    //alert('Please Select JPG,GIF,JPEG Format Photos Only');
                    pDisplayMessageclient("<%=Session["Type"].ToString() %>","16",""); 
                    return false;
                }    
                }
        }
        else
        {
            document.getElementById('imgStudent').src="StudentPhoto/NoImage.JPG";
            document.getElementById('imgQRCode').src="StudentPhoto/NoImage.JPG";    
            document.getElementById('RemovePhoto').style.display='none';
            document.getElementById('hdnSImagePath').value='noimage';
            document.getElementById('AddPhoto').innerHTML="<%=strAddPhoto%>";
        }
    }


     function HandleImage(e)
         {  
            if(XmlHttp.readyState == 4)
            {
                if(XmlHttp.status == 200)
                {  
                          var CheckFormat=XmlHttp.responseText.split('.');                 

                            if(CheckFormat[CheckFormat.length-1].toLowerCase()=='jpg' || CheckFormat[CheckFormat.length-1].toLowerCase()=='gif' || CheckFormat[CheckFormat.length-1].toLowerCase()=='jpeg') 
                            {
                               retHttp = XmlHttp.responseText; 
                               var varClTime=new Date();
                                document.getElementById('hdnSImagePath').value=retHttp;
                                //document.getElementById('hdnSPhoto').value="Y";
                                //document.getElementById('imgStudent').src="MTUploadPhoto.aspx?TypeID=Image&DtTime="+varClTime+"&strFileName=" + encodeURIComponent(document.getElementById('hdnSImagePath').value) + "";
                                document.getElementById('imgStudent').src="MTUploadSIPhoto.aspx?TypeID=Image&DtTime="+varClTime+"&strFileName=" + encodeURIComponent(document.getElementById('hdnSImagePath').value) + "";
                                document.getElementById('RemovePhoto').style.display='';
                                document.getElementById('AddPhoto').innerHTML="<%=strChangePhoto%>";
                                 return false; 

                             }
                            else
                            {
                                alert('Please Select JPG,GIF,JPEG Format Photos Only');
                                return false;
                            }  

                 }
        }
        }

  
    function AssignError()
    { 
        document.getElementById('imgStudent').src="StudentPhoto/NoImage.JPG";
        document.getElementById('AddPhoto').value="<%=strAddPhoto%>";
        document.getElementById('RemovePhoto').style.display='none';
        return false;
    }
    
    function AssignDocumentsError()
    { 
        document.getElementById('imgPickup').src="Documents/NoImage.JPG"; 
        return false;
    }
    
    
  function AssignPathStudent()
   {   
   //
    if (document.getElementById('UploadPhoto')!=null)
        { if (document.getElementById('hdnSImagePath')!=null && document.getElementById('UploadPhoto').value!='') 
            {  document.getElementById('hdnSImagePath').value=document.getElementById('UploadPhoto').value;               
            }
        }
       if (document.getElementById('imgStudent').src.split('/')[document.getElementById('imgStudent').src.split('/').length-1].toLowerCase()=="noimage.jpg")
        {  document.getElementById('RemovePhoto').style.display='none';
            if (document.getElementById('hdnSImagePath')!=null) document.getElementById('hdnSImagePath').value='noimage';
            document.getElementById('AddPhoto').value="<%=strAddPhoto%>";
        }
        else 
        {   document.getElementById('RemovePhoto').style.display='block';
            document.getElementById('RemovePhoto').innerHTML="<%=strRemovePhoto%>";
            document.getElementById('AddPhoto').innerHTML="<%=strChangePhoto%>";
        }
        return false;
    }
   

    
function pInsertgridRow(gridName,e,blnSlNo,varType,varfield)  
   { 
   try
       {
           document.getElementById('imgPickup').src=="AuthorisedPickup/NoImage.JPG";
            var varKey;
            var event=e || window.event;
            var target=event.target || event.srcElement; 
            if (window.event)
                varKey=window.event.keyCode;
            else
                varKey=e.which;
            var varRow=Number(target.id.substring(gridName.length+4,gridName.length+6))-2;            
              var VarItemId=target.id.split('_');
                
           if (varKey==13 || varKey==0) 
            { 
              if (target.id.split('_')[2]=='txtName')
                {if (document.getElementById(gridName).rows[varRow+1].cells[1].getElementsByTagName('INPUT')[0].value=='')
                     {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById(gridName).rows[0].cells[1].innerHTML);
                         document.getElementById(gridName).rows[varRow+1].cells[1].getElementsByTagName('INPUT')[0].focus();
                         return false;
                        }                
                    document.getElementById(target.id.replace('txtName','txtRelationship')).focus();
                    return false;
                }
                if (target.id.split('_')[2]=='txtRelationship')
                {if (document.getElementById(gridName).rows[varRow+1].cells[2].getElementsByTagName('INPUT')[0].value=='')
                     {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById(gridName).rows[0].cells[2].innerHTML);
                         document.getElementById(gridName).rows[varRow+1].cells[2].getElementsByTagName('INPUT')[0].focus();
                         return false;
                        }                
                    document.getElementById(target.id.replace('txtRelationship','txtPhoneNo')).focus();
                    return false;
                }
                
               if (target.id.split('_')[2]=='txtPhoneNo')
                {if (document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].value=='')
                     {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById(gridName).rows[0].cells[3].innerHTML);
                         document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].focus();
                         return false;
                        }                
                    document.getElementById(target.id.replace('txtPhoneNo','txtRemarks')).focus();
                    return false;
                }                   
                if (target.id.split('_')[2]=='txtRemarks')
                { 
                  if (document.getElementById(gridName).rows[varRow+1].cells[1].getElementsByTagName('INPUT')[0].value !='' && document.getElementById(gridName).rows[varRow+1].cells[2].getElementsByTagName('INPUT')[0].value !='' && document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].value !='')
                     {   if(document.getElementById(gridName).rows[varRow+2].style.display=="")
                            {   return false;
                            }
                           else
                            { 
                            
                                addRow(gridName,blnSlNo);                           
                                document.getElementById(gridName).rows[varRow+2].cells[1].getElementsByTagName('INPUT')[0].focus();
                                if (varKey==0) return true;
                                return false;
                             } 
                    }
                    else
                    { return false;
                    }
             }
             
             
  /*------------------------ Added By Manju on 29.08.2012 ----------- START------------*/
             if (target.id.split('_')[2]=='txtSchoolName')
                {if (document.getElementById(gridName).rows[varRow+1].cells[1].getElementsByTagName('INPUT')[0].value=='')
                     {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById(gridName).rows[0].cells[1].innerHTML);
                         document.getElementById(gridName).rows[varRow+1].cells[1].getElementsByTagName('INPUT')[0].focus();
                         return false;
                        }                
                    document.getElementById(target.id.replace('txtSchoolName','txtLocation')).focus();
                    return false;
                }
                
                if (target.id.split('_')[2]=='txtLocation')
                {if (document.getElementById(gridName).rows[varRow+1].cells[2].getElementsByTagName('INPUT')[0].value=='')
                     {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById(gridName).rows[0].cells[2].innerHTML);
                         document.getElementById(gridName).rows[varRow+1].cells[2].getElementsByTagName('INPUT')[0].focus();
                         return false;
                        }                
                    document.getElementById(target.id.replace('txtLocation','txtClassCompleted')).focus();
                    return false;
                }
                
               if (target.id.split('_')[2]=='txtClassCompleted')
                {if (document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].value=='')
                     {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById(gridName).rows[0].cells[3].innerHTML);
                         document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].focus();
                         return false;
                        }                
                    document.getElementById(target.id.replace('txtClassCompleted','txtYearAttended')).focus();
                    return false;
                }    
                if (target.id.split('_')[2]=='txtYearAttended')
                {if (document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].value=='')
                     {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById(gridName).rows[0].cells[3].innerHTML);
                         document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].focus();
                         return false;
                        }                
                    document.getElementById(target.id.replace('txtYearAttended','txtLanguage')).focus();
                    return false;
                }   
                 if (target.id.split('_')[2]=='txtLanguage')
                {
                    if (document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].value=='')
                     {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById(gridName).rows[0].cells[3].innerHTML);
                         document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].focus();
                         return false;
                     }                
                    document.getElementById(target.id.replace('txtLanguage','txtResult')).focus();
                    return false;
                }                     
                if (target.id.split('_')[2]=='txtResult')
                {   if (document.getElementById(gridName).rows[varRow+1].cells[1].getElementsByTagName('INPUT')[0].value !='' && document.getElementById(gridName).rows[varRow+1].cells[2].getElementsByTagName('INPUT')[0].value !='' && document.getElementById(gridName).rows[varRow+1].cells[3].getElementsByTagName('INPUT')[0].value !='')
                     {   
                          if(document.getElementById(gridName).rows[varRow+2].style.display=="")
                            {   return false;
                            }
                           else
                            { 
                              addRow(gridName,blnSlNo);                           
                              document.getElementById(gridName).rows[varRow+2].cells[1].getElementsByTagName('INPUT')[0].focus();
                              if (varKey==0) return true;
                              return false;
                             } 
                     }
                 else
                    { return false;
                    }
             }
           
        } 
       /*------------------------ Modified By manju on 29.08.2012 ----------- END ------------*/         
      if(document.getElementById(target.id).value.length<varfield)
           {  return true;   
           } 
           else
           {return false;
           }
    }
        catch (ex)
        {   return false;
        }
 }
 

function pAddGridAttributes(varForm)
{
 try
    {   var frmElements=document.getElementById(varForm).getElementsByTagName("TABLE");
        for (var varForLoop=0;varForLoop<frmElements.length;varForLoop++)
        {  
            
            if(frmElements[varForLoop].id=="gvDocuments")
            {
                if (frmElements[varForLoop].className.toLowerCase()=="mgrid" && frmElements[varForLoop].className.toLowerCase()=="alt")
                {  
                    for (var intForLoop=1;intForLoop<frmElements[varForLoop].rows.length;intForLoop++)
                    {  
                        if (intForLoop<frmElements[varForLoop].rows.length-1) 
                        frmElements[varForLoop].rows[intForLoop+1].style.display='none';
                    }      
                }
            }
            else
            {
                if (frmElements[varForLoop].className.toLowerCase()=="mgrid")
                {  
                    for (var intForLoop=1;intForLoop<frmElements[varForLoop].rows.length;intForLoop++)
                    {  
                        if (intForLoop<frmElements[varForLoop].rows.length-1) 
                        frmElements[varForLoop].rows[intForLoop+1].style.display='none';
                    }      
                }
            }
            GridName=frmElements[varForLoop];
        }
         
    }
    catch (ex)
    {
        return false;
    }
}

/*==========Added BY Manju (For Binding all the grids) on 08-05-2012==================*/
function pAddGridAttributesDisplay(varForm)
{
    //
 try
    {   var frmElements=document.getElementById(varForm).getElementsByTagName("TABLE");

         for (var varForLoop=0;varForLoop<frmElements.length;varForLoop++)
        {  
            
            if(frmElements[varForLoop].id=="gvDocuments")
            {
                if (frmElements[varForLoop].className.toLowerCase()=="mgrid" && frmElements[varForLoop].className.toLowerCase()=="alt")
                {  for (var intForLoop=1;intForLoop<frmElements[varForLoop].rows.length;intForLoop++)
                    {  if (intForLoop<frmElements[varForLoop].rows.length-1) 
                        {
                            if (frmElements[varForLoop].rows[intForLoop+1].getElementsByTagName('INPUT')[0] !=null)
                            {
                             if (stripBlanks(frmElements[varForLoop].rows[intForLoop+1].getElementsByTagName('INPUT')[0].value)=="")
                                    {          
                                        frmElements[varForLoop].rows[intForLoop+1].style.display='none';  
                                    }    
                                    else
                                    {  frmElements[varForLoop].rows[intForLoop+1].style.display='';  
                                    }
                            }
                        }                
                    }        
                }
            }
            else
            {
                if (frmElements[varForLoop].className.toLowerCase()=="mgrid")
                    {  for (var intForLoop=1;intForLoop<frmElements[varForLoop].rows.length;intForLoop++)
                        {  if (intForLoop<frmElements[varForLoop].rows.length-1) 
                            {
                                if (frmElements[varForLoop].rows[intForLoop+1].getElementsByTagName('INPUT')[0] !=null)
                                {
                                 if (stripBlanks(frmElements[varForLoop].rows[intForLoop+1].getElementsByTagName('INPUT')[0].value)=="")
                                        {          
                                            frmElements[varForLoop].rows[intForLoop+1].style.display='none';  
                                        }    
                                        else
                                        {  frmElements[varForLoop].rows[intForLoop+1].style.display='';  
                                        }
                                }
                            }                
                        }        
                    }
            }
            GridName=frmElements[varForLoop]; 


        }

    }
    catch (ex)
    {
        return false;
    }
}

/*========================================End of Modified BY Manju on 26-04-2012==========================================*/
  
 function pChangePageNext()    
     {  
       try
        {  
        //
            //document.getElementById('divFind').style.display="none";
           // window.parent.document.getElementById('leftTD').style.width = "20%";
            //window.parent.document.getElementById('rightTD').style.width = "80%"; 
           if (document.getElementById('txtAdmNo').value==''|| document.getElementById('txtAdmNo').value=='0')
                {   pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblAdmissionNo').innerHTML);
                    document.getElementById('txtAdmNo').focus();
                    return false;
                } 
           
         if  (document.getElementById('btnSave').disabled==false)
           {       pDisplayMessageclient("<%=Session["Type"].ToString() %>","22","");
                   return false;                
           }    
         }
        catch(exception)
        {
         
        }   
     }   
 function Validate_On_Cancel()
   {document.getElementById('hdnFlag').value='^^';
   fCloseFind();
   }
 function fClose()
 {
    fCloseFind();
 }
   
    var curSelRow=null;
  var curSelRowIndex =-1;
    function fSiblingGridDoubleClick(varRowIndex)
    {
 
        curSelRow1=document.getElementById("gvSibling").rows[varRowIndex+1];
        curSelRowIndex=varRowIndex;
        document.getElementById('hdnAdmNo').value = GetInnerText(document.getElementById("gvSibling").rows[varRowIndex+1].cells[1]);
        document.getElementById('btnDisplay').click();
        return false;
    } 
    

////********Search Form***********//    
   function fDisplay_Find()
   {
   //debugger;
        //
        //window.parent.document.getElementById('leftTD').style.width = "1%";
       // window.parent.document.getElementById('rightTD').style.width = "99%";
        
        document.getElementById('divFind').style.left="5px"
        document.getElementById('divFind').style.top="12px"
        document.getElementById('divFind').style.display="";
        document.getElementById('divFind').style.position="absolute";         
        document.getElementById('divMain').align="center";
        document.getElementById('txtStuSelect').value="";
        //document.getElementById('txtStuSelect').value="";
        document.getElementById('ddlFindClass').disabled=false;
        document.getElementById('ddlFindSection').disabled=false;
        document.getElementById('txtFindFatherName').readOnly=false;
        document.getElementById('txtFindMotherName').readOnly=false;
        document.getElementById('txtFindStudent').readOnly=false;
        
        fillGrid('gvFindStudent',"SELECT 1 AS SNO, '' AS AdmissionNo,'' AS RollNo,'' As SName");  
        
        var dDayName = new Date();
        var strRequestUrl = "SIStudentMaster.aspx?BindFindClass="+encodeURIComponent(dDayName.getTime());
        CreateXmlHttp();
        if(XmlHttp)
        {
            XmlHttp.onreadystatechange=HandleResponseClass;
            XmlHttp.open("GET",strRequestUrl,true);
            XmlHttp.send(null);
        } 
        return false;
   }

    function HandleResponseClass()
    {
        if(XmlHttp.readyState == 4)
        {
            if(XmlHttp.status == 200)
            {   
                var ResponseData = XmlHttp.responseText;                                                        
                var StrArray=ResponseData.split('~'); 
                document.getElementById('ddlFindClass').length = 0;                   
                var max = StrArray.length-1;                    
                var item = document.createElement("option");
                if(max!=0)
                     {
                        item.text = '***Select Class***';
                        item.value = 0 ;                     
                     }
                     document.getElementById('ddlFindClass').options.add(item);
                for(var i = 0;i<max;i++)
                {
                    var txt =  StrArray[i].split('^');
                    var item = document.createElement("option");
                    item.text =  txt[1];
                    item.value =txt[0];                     
                    document.getElementById('ddlFindClass').options.add(item);                         
                }                               
            } 
            else
            {
                alert("There was a problem retrieving data from the server." );
            }
        }
    } 


        function fCloseStrength()
   {
       document.getElementById('divToolTip').style.display="none";
       return false;
   }   


     
 function fStrength(varobj)
 { 
    //debugger
       var day1= new Date();
        if (document.getElementById('ddlClass').value>0)
        {
        var requestUrl = "SIStudentMaster.aspx?Classwise="+encodeURIComponent(document.getElementById('ddlClass').value+'~'+day1.getTime());
        }
        if ((document.getElementById('ddlClass').value>0) && (document.getElementById('ddlSection').value>0))
        {
          var requestUrl = "SIStudentMaster.aspx?Classwise="+encodeURIComponent(document.getElementById('ddlClass').value+'~'+day1.getTime())+'~'+encodeURIComponent(document.getElementById('ddlSection').value+'~'+day1.getTime());
        }
        if (document.getElementById('ddlClass').value>0)
         {
            CreateXmlHttp();
            if(XmlHttp)
            {
                XmlHttp.onreadystatechange=HandleResponseStregth;
                XmlHttp.open("GET",requestUrl,true);
                XmlHttp.send(null);
           
            }
        }
         return false;
 }



     function HandleResponseStregth()
     {
      
          if(XmlHttp.readyState == 4)
             {
               
                if(XmlHttp.status == 200)
                {   
                     var ResponseData = XmlHttp.responseText;                                                        
                      var StrArray=ResponseData.split('@'); 
                      var result="";
                       for(var i = 0;i<StrArray.length;i++)
                     {
                        result=result+StrArray[i]+"<br />";
                     }

                  
                    if ((StrArray.length>0) && (StrArray!=""))
                    { 
                             document.getElementById('divToolTip').style.display="";
                             document.getElementById('ClassStrength').innerHTML="";
                             document.getElementById('ClassStrength').innerHTML= result;


                     }
                     else
                     {
                       document.getElementById('divToolTip').style.display="none";
                        document.getElementById('ClassStrength').innerHTML="";
                     }
                  
                }
                
            }
         } 



    function fSection(varobj)
    {
      
        var day1= new Date();
        if(varobj=='ddlsec')
        {
        var requestUrl = "SIStudentMaster.aspx?SectionID="+encodeURIComponent(document.getElementById('ddlClass').value+'~'+day1.getTime());
        }
        else if (varobj=='DivFindSec') 
        {
           var requestUrl = "SIStudentMaster.aspx?FindSectionID="+encodeURIComponent(document.getElementById('ddlFindClass').value+'~'+day1.getTime());
        }
        else if(varobj=='ddlfeegrp')
        {
        var requestUrl = "SIStudentMaster.aspx?FeeGroupID="+encodeURIComponent(document.getElementById('ddlClass').value+'~'+day1.getTime())+'~'+encodeURIComponent(document.getElementById('ddlSection').value+'~'+day1.getTime());
        
        }
        else if(varobj=='ddlfeeAppfrm')
        {
            
            if(document.getElementById("ddlFeeGroup").length==1)
             {
               var requestUrl = "SIStudentMaster.aspx?FeeGrpLenEq1="+encodeURIComponent(document.getElementById('ddlFeeGroup').value+'~'+day1.getTime());
             }
             if (document.getElementById("ddlFeeGroup").length==0)
             {
               var requestUrl = "SIStudentMaster.aspx?FeeGrpLenEq0="+encodeURIComponent(document.getElementById('ddlFeeGroup').value+'~'+day1.getTime());
             }
             if (document.getElementById("ddlFeeGroup").length>0)
             {
               var requestUrl = "SIStudentMaster.aspx?FeeGrpLenGrt0="+encodeURIComponent(document.getElementById('ddlFeeGroup').value+'~'+day1.getTime());
             }
        }
        else if (varObject=='FeeAppl') 
        {
           var requestUrl = "SIStudentMaster.aspx?FeeApplGrt0="+encodeURIComponent(document.getElementById('ddlFeeGroup').value+'~'+day1.getTime());
        }
        CreateXmlHttp();
        if(XmlHttp)
        {
           if(varobj=='ddlsec')
           {
           XmlHttp.onreadystatechange=HandleResponseSection;
           }
           else if(varobj=='ddlfeegrp')
           {
           XmlHttp.onreadystatechange=HandleResponseFeeGroup;
           }
           else if(varobj=='ddlfeeAppfrm')
           {
           XmlHttp.onreadystatechange=HandleResponseFeeAppfrm;
           }
           else if (varobj=='FeeAppl') 
           {
           XmlHttp.onreadystatechange=HandleResponseFeeAppfrm;
           }
           else if (varobj=='DivFindSec') 
           {
           XmlHttp.onreadystatechange=HandleResponseDivFindSec;
           }

           XmlHttp.open("GET",requestUrl,true);
           XmlHttp.send(null);
           
        } 
           return false;
    }
    
   
         
      function HandleResponseFeeGroup()
     {
       //
       if(XmlHttp.readyState == 4)
            {
                if(XmlHttp.status == 200)
                {   
                     var ResponseData = XmlHttp.responseText;                                                        
                     var StrArray=ResponseData.split('~'); 
                     document.getElementById('ddlFeeGroup').length = 0;                   
                     var max = StrArray.length-1;                    
                     var item = document.createElement("option");
                
                     for(var i = 0;i<max;i++)
                     {
                       var txt =  StrArray[i].split('^');
                       var item = document.createElement("option");
                       item.text =  txt[1];
                       item.value =txt[0];                     
                       document.getElementById('ddlFeeGroup').options.add(item);                         
                     } 
                       var StrArray=ResponseData.split('@'); 
                       
                       document.getElementById('lblCaption1').innerHTML="Strength";
                       document.getElementById('lblClassStrength').innerHTML="Class :" + "" + StrArray[1];
                       document.getElementById('lblTotalStrength').innerHTML="School :" + "" + StrArray[2];
                       
                       fSection('ddlfeeAppfrm');       
                                                  
                }
                
                else
                {
                    alert("There was a problem retrieving data from the server." );
                }
             //   fSection('HomeAdvisor');
            }
         } 
         
    function HandleResponseFeeAppfrm()
     {
    //
       if(XmlHttp.readyState == 4)
            {
                if(XmlHttp.status == 200)
                {   
                     var ResponseData = XmlHttp.responseText;                                                        
                     var StrArray=ResponseData.split('~'); 
                     document.getElementById('ddlFeeApplnFrom').length = 0;                   
                     var max = StrArray.length-1;                    
                     var item = document.createElement("option");
            
                     for(var i = 0;i<max;i++)
                     {
                       var txt =  StrArray[i].split('^');
                       var item = document.createElement("option");
                       item.text =  txt[1];
                       item.value =txt[0];                     
                       document.getElementById('ddlFeeApplnFrom').options.add(item);                         
                     } 
                     
                     fStrength();                      
                }
                else
                {
                    alert("There was a problem retrieving data from the server." );
                }
            }
         } 
         
         
     function HandleResponseDivFindSec()
     {
    //
       if(XmlHttp.readyState == 4)
            {
                if(XmlHttp.status == 200)
                {   
                     var ResponseData = XmlHttp.responseText;                                                        
                     var StrArray=ResponseData.split('~'); 
                     document.getElementById('ddlFindSection').length = 0;                   
                     var max = StrArray.length-1;                    
                     var item = document.createElement("option");
                     if(max!=0)
                     {
                        item.text = '***Select Section***';
                        //item.text=pDisplayMessageclient("<%=Session["Type"].ToString() %>","9","" + document.getElementById('tdscection').innerHTML);
                        item.value = 0 ;                     
                     }
                     document.getElementById('ddlFindSection').options.add(item);                   
                     for(var i = 0;i<max;i++)
                     {
                       var txt =  StrArray[i].split('^');
                       var item = document.createElement("option");
                       item.text =  txt[1];
                       item.value =txt[0];                     
                       document.getElementById('ddlFindSection').options.add(item);                         
                     }                       
                }
                else
                {
                    alert("There was a problem retrieving data from the server." );
                }
            }
         } 

   
   function fBindSerach()
   {
       //
        /*====================Added BY Manju on 28-04-2012=========================*/
        var strSearch="<%=strSearchOption %>"
        document.getElementById('hdnFlag').value="S^";
        document.getElementById('btnFindDisplay').click();
        pEnableDisable('SEARCH'); 
        return false;
       /*====================End of Added BY Manju on 28-04-2012=========================*/
    }
    var curSelRow=null;   
    var curSelRowIndex=-1;
    function fGridDoubleClick(varRowIndex)
    { 
    
        curSelRow=document.getElementById("gvFindStudent").rows[varRowIndex+1];
        curSelRowIndex=varRowIndex;
        /*--------------Modified By Manju on 28-05-2012------------------------------------------------------------------------*/
         //pClearFields('frmStudentmaster');  
        document.getElementById('txtAdmNo').value=GetInnerText(document.getElementById("gvFindStudent").rows[varRowIndex+1].cells[3]);
        document.getElementById('txtParentID').value="";
        document.getElementById('btnDisplay').click();
        //pBindFeilds(GetInnerText(document.getElementById("gvFindStudent").rows[varRowIndex+1].cells[3]));
        
        //window.parent.document.getElementById('leftTD').style.width = "1%";
        //window.parent.document.getElementById('rightTD').style.width = "99%";
        
        document.getElementById('divFind').style.left="5px"
        document.getElementById('divFind').style.top="12px"
        document.getElementById('divFind').style.display="";
        document.getElementById('divFind').style.position="absolute";         
        document.getElementById('divMain').align="center";
        return false;
     
    }
    function fCloseFind()
    {   
        //window.parent.document.getElementById('leftTD').style.width = "20%";
        //window.parent.document.getElementById('rightTD').style.width = "80%"; 
        document.getElementById('divFind').style.display="none";
        document.getElementById('divMain').align="center";
        /*---------Added By Manju on 29-05-2012-------------*/
        document.getElementById('hdnFindSearch').value=" ";
        document.getElementById('ddlFindClass').value=" ";
        document.getElementById('ddlFindSection').value=" ";
        /*---------Added By Manju on 29-05-2012-------------*/
        if (document.getElementById('txtAdmNo').value=="")
        {
            document.getElementById('txtStuSelect').readOnly=false;
            document.getElementById('txtAdmNo').readOnly=false;
        }
        return false;
    }
    function fDetCloseFind()
    {
        fCloseFind();
    }
    
   function OpenDropOutform() 
   { 
        if(document.getElementById('hdnSDID').value!=document.getElementById('hdntxtStuSelect').value)
        {
            alert('Please select the record again');
            document.getElementById('txtStuSelect').focus();
            return false;
        }
   
     var varClTime=new Date();
     if (stripBlanks(document.getElementById('txtAdmNo').value) !="")
     {
           window.open("SIStudentDropoutDetail.aspx?DtTime="+varClTime+"&Adm=" + encodeURIComponent(document.getElementById('txtAdmNo').value) + "","","height=470%,width=770%,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes");
           return false;
     }
    return false;     
  }  
  
  function OpenTCform()
  {
  
        if(document.getElementById('hdnSDID').value!=document.getElementById('hdntxtStuSelect').value)
        {
            alert('Please select the record again');
            document.getElementById('txtStuSelect').focus();
            return false;
        }
  
     var varClTime=new Date();
     if (stripBlanks(document.getElementById('txtAdmNo').value) !="")
     {
           window.open("SIStudentTransferCertificate.aspx?DtTime="+varClTime+"&Adm=" + encodeURIComponent(document.getElementById('txtAdmNo').value) + "","","height=470%,width=770%,toolbar=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,modal=yes");
           return false;
     }
    return false;     
  }
  
  function pFocus(fld)
  {    
    fld.className='FocusText';        
  }
  function pBlur(fld)
  {    
    fld.className='MyText';
  }
  
  
   function pPickupPhoto(varAction,varRowIndex,varGridName)
   { 
        //debugger;
        if(varAction == "ADD")
        {   var returnValue="";
            document.getElementById('imgPickup').src="";
             document.getElementById('hdngvtype').value="";
           document.getElementById('hdngvtype').value=varGridName;
           
            if (varGridName=='gvDocuments')
            {
                if (window.showModalDialog) 
                {
                    returnValue=window.showModalDialog('MTUploadDocument.aspx','',"dialogWidth:360px;dialogHeight:175px;status=no;location=no;left=100;top=100");
                }
                else
                {   returnValue=window.open("MTUploadDocument.aspx","","height=10%,width=30%,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes");
                }
                    
                    
                     if (returnValue==null || returnValue==undefined || returnValue =="")
                     {
                          document.getElementById('hdnRow').value=varRowIndex;
                            returnValue= "<%=Session["Path"] %>" ;                      
                            var varDate=new Date();
                            var requestUrl = "MTUploadDocument.aspx?varDate=" + varDate +"&TypeID=ImgePath";
                           CreateXmlHttp();
                
                            if(XmlHttp)
                            {
                              XmlHttp.onreadystatechange = HandleDocuments;
                                          if (navigator.userAgent.toLowerCase().indexOf("msie")!=-1)
                                    XmlHttp.open("GET", requestUrl,  false);
                                else
                                    XmlHttp.open("GET", requestUrl,  true);
                                XmlHttp.send(null); 
                            }

                        return false;

                      }
            }
           else
           {

                if (window.showModalDialog) 
                {
                    //returnValue=window.showModalDialog('MTUploadPhoto.aspx','',"dialogWidth:360px;dialogHeight:175px;status=no;location=no;left=100;top=100");
                    returnValue=window.showModalDialog('MTUploadSIPhoto.aspx','',"dialogWidth:360px;dialogHeight:175px;status=no;location=no;left=100;top=100");
                }
                else
                {  
                //returnValue=window.open("MTUploadPhoto.aspx","","height=10%,width=30%,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes");
                returnValue=window.open("MTUploadSIPhoto.aspx","","height=10%,width=30%,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes");
                }


                if (returnValue==null || returnValue==undefined || returnValue =="")
                     {
                          document.getElementById('hdnRow').value=varRowIndex;
                            returnValue= "<%=Session["Path"] %>" ;                      
                            var varDate=new Date();
                            //var requestUrl = "MTUploadPhoto.aspx?varDate=" + varDate +"&TypeID=ImgePath";
                            var requestUrl = "MTUploadSIPhoto.aspx?varDate=" + varDate +"&TypeID=ImgePath";
                           CreateXmlHttp();
                
                            if(XmlHttp)
                            {
                              XmlHttp.onreadystatechange = HandleDocuments;
                                          if (navigator.userAgent.toLowerCase().indexOf("msie")!=-1)
                                    XmlHttp.open("GET", requestUrl,  false);
                                else
                                    XmlHttp.open("GET", requestUrl,  true);
                                XmlHttp.send(null); 
                            }

                        return false;

                      }
           }
            //if (returnValue==null || returnValue==undefined || returnValue=="") return false;
                  
            
            
            var CheckFormat=returnValue.split('.');
            if(CheckFormat[CheckFormat.length-1].toLowerCase()=='JPG' || CheckFormat[CheckFormat.length-1].toLowerCase()=='jpg' || CheckFormat[CheckFormat.length-1].toLowerCase()=='gif' || CheckFormat[CheckFormat.length-1].toLowerCase()=='jpeg' || CheckFormat[CheckFormat.length-1].toLowerCase()=='pdf' || CheckFormat[CheckFormat.length-1].toLowerCase()=='doc') 
            {

                 
                if (varGridName=='gvDocuments')
                {
                    document.getElementById(varGridName).rows[varRowIndex+1].cells[4].getElementsByTagName('INPUT')[0].value=returnValue;
                }
                else
                {  
                    document.getElementById(varGridName).rows[varRowIndex+1].cells[5].getElementsByTagName('INPUT')[0].value=returnValue;
                }

             
                return false;
            }
            else
            {
                pDisplayMessageclient("<%=Session["Type"].ToString() %>","16",""); 
                return false;
            }
       }
               
 }
  


  function HandleDocuments(e)
 {  
    if(XmlHttp.readyState == 4)
    {
        if(XmlHttp.status == 200)
        {
                  var CheckFormat=XmlHttp.responseText.split('.');                 

                     if(CheckFormat[CheckFormat.length-1].toLowerCase()=='JPG' || CheckFormat[CheckFormat.length-1].toLowerCase()=='jpg' || CheckFormat[CheckFormat.length-1].toLowerCase()=='gif' || CheckFormat[CheckFormat.length-1].toLowerCase()=='jpeg' || CheckFormat[CheckFormat.length-1].toLowerCase()=='pdf' || CheckFormat[CheckFormat.length-1].toLowerCase()=='doc') 
                      {
                        returnValue= XmlHttp.responseText;

                        if(document.getElementById('hdngvtype').value=="gvDocuments")
                        {
                         document.getElementById('gvDocuments').rows[Number(document.getElementById('hdnRow').value)+1].cells[4].getElementsByTagName('INPUT')[0].value=returnValue;
                         }
                         else
                         {
                           document.getElementById('gvAuthorisedPickUp').rows[Number(document.getElementById('hdnRow').value)+1].cells[5].getElementsByTagName('INPUT')[0].value=returnValue;
                          
                         }

                         return false;
                     }
                    else
                    {
                        alert('Please Select JPG,GIF,JPEG,PDF Format document ');
                        return false;
                    }  

         }
}
} 
  
   function pPickImgResize()
    {
        document.getElementById('pnlPickupPhoto').style.left="250px";
        document.getElementById('pnlPickupPhoto').style.top="750px";
        document.getElementById('pnlPickupPhoto').style.height = "400px";
        document.getElementById('pnlPickupPhoto').style.width = "400px";
        document.getElementById('imgPickup').style.height = "400px";
        document.getElementById('imgPickup').style.width = "400px";
        return false;
    }
  function fpickupClose()
    {   
        //
        document.getElementById('pnlPickupPhoto').style.display="none"; 
        return false;
    }
  
   function fimgAssignError()
    {
       document.getElementById('imgPickup').src=="StudentPhoto/NoImage.JPG";
    }

 function PRemovePickUPDocuments(varCurrRow,gridName)          
   {     
        document.getElementById(gridName).rows[varCurrRow+1].cells[5].getElementsByTagName('INPUT')[0].value="AuthorisedPickup/NoImage.JPG";
         return false; 
   }
    
  function OpenSIStudentRemarksform()
  {
  
        if(document.getElementById('hdnSDID').value!=document.getElementById('hdntxtStuSelect').value)
        {
            alert('Please select the record again');
            document.getElementById('txtStuSelect').focus();
            return false;
        }
  
     var varClTime=new Date();
     if (stripBlanks(document.getElementById('txtAdmNo').value) !="")
     {
           window.open("SIStudentRemarks.aspx?DtTime="+varClTime+"&Adm=" + encodeURIComponent(document.getElementById('txtAdmNo').value) + "","","height=470%,width=770%,toolbar=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,modal=yes");
           return false;
     }
    return false;     
  }
   
              
              
    function fGridClick(varRowIndex,varGridName)                //Authorized PickUp
    {  
        if(document.getElementById('imgPickup').src != "")
        {  
            if (varGridName=='gvAuthorisedPickUp')
            {  
                if (stripBlanks(document.getElementById('gvAuthorisedPickUp').rows[varRowIndex+1].cells[5].getElementsByTagName('INPUT')[0].value) !="")
                { 
                    if (document.getElementById('gvAuthorisedPickUp').rows[varRowIndex+1].cells[5].getElementsByTagName('INPUT')[0].value.substring(0,17) !="AuthorisedPickup/")
                    {  
                        alert('Please Save image first');
                        return false;
                    }
                }      
                document.getElementById('imgPickup').src = document.getElementById('gvAuthorisedPickUp').rows[varRowIndex+1].cells[5].getElementsByTagName('INPUT')[0].value; 
                document.getElementById('pnlPickupPhoto').style.display="block"; 
                document.getElementById('pnlPickupPhoto').style.left="600px";
                document.getElementById('pnlPickupPhoto').style.top="920px";
                document.getElementById('pnlPickupPhoto').style.height = "100px";
                document.getElementById('pnlPickupPhoto').style.width = "100px";
                document.getElementById('imgPickup').style.height = "100px";
                document.getElementById('imgPickup').style.width = "100px";
                document.getElementById('pnlPickupPhoto').style.position="absolute";  
            
            }
            else
            {     
                if (stripBlanks(document.getElementById('gvDocuments').rows[varRowIndex+1].cells[4].getElementsByTagName('INPUT')[0].value) !="")
                { 
                    if (document.getElementById('gvDocuments').rows[varRowIndex+1].cells[4].getElementsByTagName('INPUT')[0].value.substring(0,10) !="Documents/")
                    {  
                        alert('Please Save Document first');
                        return false;
                    }
                }       
                var CheckFormat=document.getElementById('gvDocuments').rows[varRowIndex+1].cells[4].getElementsByTagName('INPUT')[0].value.split('.'); 
                if(CheckFormat[CheckFormat.length-1]=='jpg' || CheckFormat[CheckFormat.length-1]=='JPG' || CheckFormat[CheckFormat.length-1]=='') 
                {
                    document.getElementById('imgPickup').src = document.getElementById('gvDocuments').rows[varRowIndex+1].cells[4].getElementsByTagName('INPUT')[0].value; 
                    document.getElementById('pnlPickupPhoto').style.display="block"; 
                    document.getElementById('pnlPickupPhoto').style.left= "520px";
                    document.getElementById('pnlPickupPhoto').style.top="1000px";
                    document.getElementById('pnlPickupPhoto').style.height = "100px";
                    document.getElementById('pnlPickupPhoto').style.width = "100px";
                    document.getElementById('imgPickup').style.height = "100px";
                    document.getElementById('imgPickup').style.width = "100px";
                    document.getElementById('pnlPickupPhoto').style.position="absolute";
                }
                else
                {
                    window.open("MTAssignment.aspx?Documents="+document.getElementById('gvDocuments').rows[varRowIndex+1].cells[4].getElementsByTagName('INPUT')[0].value+"")
                    return false;
                }           
            }
       } 
       }
        
 function fpickupClose()
{
      document.getElementById('pnlPickupPhoto').style.display="none"; 
      return false;
}



function fBind_Student(e)
    {    
    //
    var varKey;
         if(window.event)
            varKey=window.event.keyCode;
         else
            varKey=e.which; 
          if (document.getElementById('txtStuSelect').readOnly==true)
            {return false;
            } 
           if (document.getElementById('txtStuSelect').value.length>0)
           {  if(varKey==13 || varKey==0)
                 { 
                 var strArray= document.getElementById('txtStuSelect').value.split('#');
                      if (strArray[1]!=undefined)
                        { 
                           document.getElementById('txtAdmNo').value=stripBlanks(strArray[1]);
                            document.getElementById('btnDisplay').click();
                            return false;
                        }    
                       return false;
                  }
            }  
    }
    
    
  

    function fBind_Parent(e)
    { 
      var varKey;
         if(window.event)
            varKey=window.event.keyCode;
         else
            varKey=e.which; 
             //if(varKey==9) return false;
           if(varKey==39) return false;
          
          if (document.getElementById('txtParentID').readOnly==true)
            {
               return false;
            }  
           if (document.getElementById('txtParentID').value.length>0)
           {  
                //alert(varKey);
                //if(varKey==13 || varKey==0)
                if(varKey==13)
                 { 
                 var strArray= document.getElementById('txtParentID').value.split('#');
                      if (strArray[2]!=undefined)
                        {
                            document.getElementById('txtParentID').value=stripBlanks(strArray[2]);
                            document.getElementById('hidParentID').value=strArray[0];
                            document.getElementById('btnDisplay').click();
                            return false;
                        }  
                        else  if(strArray[0]!=undefined)
                        {   
                          document.getElementById('hidParentID').value=strArray[0];
                          document.getElementById('btnDisplay').click();
                         return false;
                        }
                       return false;
                  }
            }  
     
    }
    function fBind_ResiCity(e)
    { 
       var varKey;
         if(window.event)
            varKey=window.event.keyCode;
         else
            varKey=e.which; 
          if (document.getElementById('txtResiCity').readOnly==true)
            {return false;
            } 
           if (document.getElementById('txtResiCity').value.length>0)
           {  if(varKey==13 || varKey==0)
                 { var strArray= document.getElementById('txtResiCity').value.split('#');
                      if (strArray[0]!=undefined)
                        {   document.getElementById('txtResiCity').value=stripBlanks(strArray[0]);
                            document.getElementById('btnResiCity').click();
    
                        }    
                       return false;
                  }
            } 
           
    }
    
   function fBind_PerCity(e)
    { 
        //
       var varKey;
         if(window.event)
            varKey=window.event.keyCode;
         else
            varKey=e.which; 
          if (document.getElementById('txtPerCity').readOnly==true)
            {return false;
            } 
           if (document.getElementById('txtPerCity').value.length>0)
           {  if(varKey==13 || varKey==0)
                 { var strArray= document.getElementById('txtPerCity').value.split('#');
                      if (strArray[0]!=undefined)
                        {   document.getElementById('txtPerCity').value=stripBlanks(strArray[0]);
                            document.getElementById('btnPerCity').click();
                            
                        }    
                       return false;
                  }
            } 
           
    }
    
    function ShowBusRoute()
  {
    document.getElementById('trRoutedetails').style.display='';
    if(document.getElementById('lblBusMorning').innerHTML!="")
    {
     document.getElementById('lblBusMorning').style.display="";
     document.getElementById('lblBusMorninghr').style.display="";
    }
    if(document.getElementById('lblBusAfterNoon').innerHTML!="")
     {
     document.getElementById('lblBusAfterNoonhr').style.display="";
     document.getElementById('lblBusAfterNoon').style.display="";
     }   
               
   }             
  


 function CheckLenOnPaste(e,Varlen)
        {
        //debugger;
            var event=e || window.event;
            var target=event.target || event.srcElement;         
            if(document.getElementById(target.id).value.length>Varlen)
            { 
                var str= document.getElementById(target.id).value;    
                document.getElementById(target.id).value=str.substring(0,Varlen);    
                return false;
            }      
          
        } 


        function ffillImage() {
        //debugger;
        if (document.getElementById('hdnImage').value != "") {
            var returnValue = document.getElementById('hdnImage').value;
            document.getElementById('hdnSImagePath').value=returnValue;
            var CheckFormat = returnValue.split('.');
            if (CheckFormat[CheckFormat.length - 1].toLowerCase() == 'JPG' || CheckFormat[CheckFormat.length - 1].toLowerCase() == 'gif' || CheckFormat[CheckFormat.length - 1].toLowerCase() == 'jpeg' || CheckFormat[CheckFormat.length - 1].toLowerCase() == 'jpg') {
                var varClTime = new Date();
                document.getElementById('hdnImage').value = returnValue;
                document.getElementById('imgStudent').src = "MTUploadSIPhoto.aspx?TypeID=Image&DtTime=" + varClTime + "&strFileName=" + encodeURIComponent(document.getElementById('hdnImage').value) + "";
                document.getElementById('RemovePhoto').style.display = 'block';
                document.getElementById('AddPhoto').innerHTML = "<%=strChangePhoto%>";
                return false;
            }
            else {
                alert('Please Select JPG,GIF,JPEG Format Photos Only');

                return false;
            }
        }
        else {
            alert('Please Select JPG,GIF,JPEG Format Photos Only');

            return false;

        }
    }


        function fBindSiblingOnAdm(e,value)
    {     
      var varKey;
         if(window.event)
            varKey=window.event.keyCode;
         else
            varKey=e.which;              
           if(varKey==39) return false;
          
          if (document.getElementById('txtSiblingAdmNo').readOnly==true)
            {
               return false;
            }  
           if (document.getElementById('txtSiblingAdmNo').value.length>0)
           {                  
                if(varKey==13)
                 { 
                 var strArray= document.getElementById('txtSiblingAdmNo').value.split('#');
                      if (strArray[1]!=undefined)
                        {
                            document.getElementById('txtSiblingAdmNo').value=stripBlanks(strArray[1]);
                            document.getElementById('hidSiblingAdm').value=strArray[1];
                            document.getElementById('btnSiblingSearch').click();
                            return false;
                        }  
                        else  if(strArray[0]!=undefined)
                        {   
                          document.getElementById('hidSiblingAdm').value=strArray[0];
                          document.getElementById('btnSiblingSearch').click();
                         return false;
                        }
                       return false;
                  }
            }  
     
    }


    </script>
</head>
<body dir="<%=strType %>" style="background-image: url(Images/backgroundImg.jpg);
    background-repeat: repeat; background-position: center center; background-attachment: scroll;">
    <form id="frmStudentmaster" runat="server" dir="<%=strType %>" oncontextmenu="return false;">
    <div id="divMain" align="center">
        <table style="border-width: 0px;">
            <tr>
                <td class="divCircle" align="left" valign="top">
                    <table class="MyTableBorder">
                        <tr class="MyTableHeader">
                            <td align="center" colspan="3">
                                &nbsp;
                                <asp:LinkButton ID="linkBasic" runat="server" class="MyTableHeader" OnClick="linkAddition_Click"
                                    ForeColor="Silver">
                                    <asp:Label ID="lbllinkBasic" runat="server">Student&nbsp;Basic&nbsp;Information</asp:Label>
                                </asp:LinkButton>
                                <asp:Label ID="lblLastMDate" runat="server" Font-Bold="False" ForeColor="#0000C0"
                                    Style="display: none;"></asp:Label>
                            </td>
                            <td align="center" colspan="3">
                                <asp:LinkButton ID="linkAddition" runat="server" class="MyTableHeader" OnClientClick="javascript:return pChangePageNext();"
                                    OnClick="linkAddition_Click">
                                    <asp:Label ID="lbllinkAddition" runat="server">Student&nbsp;Additional&nbsp;Information</asp:Label></asp:LinkButton>
                            </td>
                            <td class="MyTableHeader">
                            </td>
                        </tr>
                        <tr id="trSearch">
                            <td align="right" class="MyLabel">
                                <a id="asear" href="#" onclick="fDisplay_Find();">Search</a>
                                <%--<input type="button" value="...." onclick="fDisplay_Find();"  CssClass="MyButton" style="width: 30px" class="MyButton" size=""  />--%>                                <%-- <asp:Button ID="btnFind" runat="server" CssClass="MyButton" 
                                    Text="....." Width="22px" OnClientClick="fDisplay_Find()"  />
                                --%>                                <%-- /*============================Modified By Manju on 23-04-2012==================================*/--%>                                <%--<asp:Label ID="lblStuSelect"  runat="server" Width="80px"> Select</asp:Label>--%>
                                <asp:Label ID="lblStuSelect" runat="server" Width="80px"> Student</asp:Label>
                                <%--/*============================Modified By Manju on 23-04-2012==================================*/--%>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="txtStuSelect" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    Width="300px"></asp:TextBox>
                            </td>
                            <td align="right" class="MyLabel" nowrap="nowrap">
                                <asp:Label ID="lblSiblingAdmNo" runat="server">Sibling Adm No</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSiblingAdmNo" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    Width="126px" TabIndex="3" ToolTip="Enter Sibling or Admission No"></asp:TextBox>
                            </td>
                            <td rowspan="8" valign="top">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgStudent" runat="server" Width="94px" ImageUrl="~/StudentPhoto/NoImage.JPG"
                                                Height="127px" TabIndex="79" CssClass="MyButton" OnClientClick="javascript:return false;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle">
                                            <a id="AddPhoto" runat="server" class="MyLabel" href="#" onclick="pChangePhoto('Add');">
                                            </a>
                                            <%--   <asp:Label ID="lblAddSphoto" runat="server" CssClass="MyLabel" Width="70px">Add Photo</asp:Label> --%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle">
                                            <a id="RemovePhoto" class="MyLabel" href="#" onclick="pChangePhoto('Remove');return;"
                                                style="display: none">
                                            <%--  <asp:Label ID="lblRemoveSPhoto" runat="server" Width="70px">
                                             Remove</asp:Label>--%>
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblAdmissionNo" runat="server" Width="110px">Adm.No. </asp:Label><span
                                    style="color: #ff0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAdmNo" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="50" Width="107px" TabIndex="1"></asp:TextBox>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblFeeNo" runat="server" Width="50px">Fee No.</asp:Label><span style="color: #ff0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFeeNo" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="50" Width="70px" TabIndex="2"></asp:TextBox>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblParentID" runat="server" Width="50px">Parent ID</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtParentID" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="8" Width="126px" TabIndex="3" ToolTip="EnterFather Name or ParentID"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                &nbsp;
                                <asp:Label ID="lblName" runat="server" Width="110px">Name </asp:Label><span style="color: #ff0000">*</span>
                            </td>
                            <td align="left" colspan="5">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="Server" ID="txtFirstName" CssClass="MyTextBox" TabIndex="4" Width="130px"
                                                MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="Server" ID="txtMiddleName" CssClass="MyTextBox" TabIndex="5"
                                                Width="115px" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="Server" ID="txtLastName" CssClass="MyTextBox" TabIndex="6" Width="115px"
                                                MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td id="tdNoimage">
                                            <asp:Image ID="imgATD" runat="server" />
                                            <%--<asp:Label ID="lblStudentStatus" runat="server" CssClass="MyLabel" Font-Bold="true"  ForeColor="#C00000" BackColor="Transparent" >Status:Active</asp:Label>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <a id="a1" href="#" onclick="fStrength();" style="text-decoration: none; color: Black;"
                                    title="Select Class & Click to check Class Strength">Class</a>
                                <%-- <asp:Label ID="lblClass" runat="server" Width="110px" >Class </asp:Label>--%>
                                <span style="color: #ff0000">*</span>
                            </td>
                            <td align="left">
                                <%--/*========================================Modified BY Manju on 26-04-2012===============================================================*/--%>                                <%--<asp:DropDownList ID="ddlClass" runat="server" CssClass="MyTextBox" Width="120px" TabIndex="7"  onchange="return fSection('ddlsec');" >
                                </asp:DropDownList></td>--%>
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="MyTextBox" Width="120px"
                                    TabIndex="7" onclick="fStrength();">
                                </asp:DropDownList>
                            </td>
                            <%--/*===================================End of Modified BY Manju on 26-04-2012===============================================================*/--%>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblSection" runat="server" Width="50px">Section</asp:Label><span style="color: #ff0000">*</span>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSection" runat="server" CssClass="MyTextBox" Width="120px"
                                    TabIndex="8" onchange="return fSection('ddlfeegrp');">
                                    <%--onchange="return fSection('ddlfeegrp');"--%>
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblRollNo" runat="server" Width="50px"> Roll&nbsp;No.</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRollNo" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    Width="126px" MaxLength="4" TabIndex="9"></asp:TextBox>
                            </td>
                        </tr>
                        <%--onchange="return fSection('ddlfeegrp');"--%>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblStuDOB" runat="server" Width="110px">Date of Birth</asp:Label><span
                                    style="color: #ff0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStuDOB" runat="server" CssClass="MyTextBox" MaxLength="10" onkeypress="javascript:return RestrictEnterDate(event);"
                                    Width="115px" TabIndex="10"></asp:TextBox>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblAdmittedClass" runat="server" Width="70px">Admitted&nbsp;Class </asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAdmittedClass" runat="server" CssClass="MyTextBox" Width="120px"
                                    TabIndex="11">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblGender" runat="server" Width="50px">Gender</asp:Label>
                            </td>
                            <td align="left">
                                <asp:RadioButton ID="rbtnMale" runat="server" CssClass="MyLabel" Text="Boy" Width="50px"
                                    GroupName="Sex" Checked="True" TabIndex="12" /><asp:RadioButton ID="rbtnFemale" runat="server"
                                        CssClass="MyLabel" Text="Girl" Width="50" GroupName="Sex" TabIndex="13" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right" class="MyLabel">
                                <asp:Label ID="Label1" runat="server" Width="110px">Stream</asp:Label>
                            </td>
                            <td align="Left">
                                <asp:DropDownList ID="ddlStream" runat="server" CssClass="MyTextBox" Width="120px">
                                    <asp:ListItem Value="0">Select Stream</asp:ListItem>
                                    <asp:ListItem Value="1">ARTS</asp:ListItem>
                                    <asp:ListItem Value="2">COM</asp:ListItem>
                                    <asp:ListItem Value="3">MED</asp:ListItem>
                                    <asp:ListItem Value="4">NON MED</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr >
                            <td align="right" class="MyLabel">
                                GGN No.</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtGGNNo" runat="server" CssClass="MyTextBox" Width="173px" 
                                    MaxLength="50" TabIndex="18"></asp:TextBox>
                            </td>
                            <td class="MyLabel" align="right">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr id="trName">
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblArabicName" runat="server" Width="110px">Arabic&nbsp;Name </asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtArabicName" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="150" Width="288px" TabIndex="10"></asp:TextBox>
                            </td>
                            <td class="MyLabel" align="right">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <%--  <tr>
                         <td class="MyLabel" align="right">
                             <asp:Label ID="lblName" runat="server" Width="160px">Name </asp:Label></td>
                            
                             <td align="left"  colspan="5" class="MyLabel"><asp:TextBox runat="Server" ID="txtFirstName" CssClass="MyTextBox" TabIndex="4" Width="150px" MaxLength="50"></asp:TextBox> 
                              <asp:TextBox runat="Server" ID="txtMiddleName" CssClass="MyTextBox" TabIndex="5" Width="150px" MaxLength="50" ></asp:TextBox> 
                              <asp:TextBox runat="Server" ID="txtLastName" CssClass="MyTextBox" TabIndex="6" Width="142px" MaxLength="50"></asp:TextBox></td>
                                                    
                        </tr>--%>
                        <tr>
                            <td align="right" class="MyLabel">
                                <%--   <tr>
                           <td align="left" class="MyLabel" colspan="7">
                               <asp:Label ID="lblStudentStatus" runat="server" Width="524px">Student Staus : Active </asp:Label></td> 
                        
                        </tr>--%>                                <%--/*=====================Modified BY Manju on 23-04-2012====================================*/--%>
                                <asp:Label ID="lblFName" runat="server" Width="110px">Father's&nbsp;Name </asp:Label>
                            </td>
                            <%--<asp:Label ID="lblFName" runat="server" Width="110px">Father&nbsp;Name </asp:Label></td>--%>
                            <td align="left" class="MyLabel" colspan="5">
                                <asp:DropDownList ID="ddlFTitle" runat="server" CssClass="MyTextBox" Width="100px"
                                    TabIndex="14">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtFName" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="120" Width="393px" TabIndex="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <%--/*=====================End of Modified BY Manju on 23-04-2012====================================*/--%>                                <%--/*=====================Modified BY Manju on 23-04-2012====================================*/--%>
                                <asp:Label ID="lblMName" runat="server" Width="110px">Mother's&nbsp;Name </asp:Label>
                            </td>
                            <%--<asp:Label ID="lblMName" runat="server" Width="110px">Mother&nbsp;Name </asp:Label></td>--%>
                            <td align="left" class="MyLabel" colspan="5">
                                <asp:DropDownList ID="ddlMTitle" runat="server" CssClass="MyTextBox" Width="100px"
                                    TabIndex="16">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtMName" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="120" Width="393px" TabIndex="17"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <%--/*=====================End of Modified BY Manju on 23-04-2012====================================*/--%>                                <%-- /*======================================Modified by Manju on 23-04-2012===================================*/--%>
                                <asp:Label ID="lblDateOfAdmission" runat="server" Width="110px"> Date of Admission</asp:Label>
                            </td>
                            <%--<asp:Label ID="lblDateOfAdmission" runat="server" Width="110px"> Date&nbsp;Of&nbsp;Admission</asp:Label></td>--%>
                            <td align="left" colspan="2">
                                <asp:TextBox ID="txtDOA" runat="server" CssClass="MyTextBox" Width="173px" onkeypress="javascript:return RestrictEnterDate(event);"
                                    MaxLength="10" TabIndex="18"></asp:TextBox>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblDateOFJoin" runat="server" Width="110px"> Date of Join</asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:TextBox ID="txtDateOFJoin" runat="server" CssClass="MyTextBox" MaxLength="10"
                                    onkeypress="javascript:return RestrictEnterDate(event);" TabIndex="19" Width="177px"></asp:TextBox>
                            </td>
                            <td align="center" class="MyLabel">
                                <asp:Label ID="lblCaption1" runat="server" Font-Bold="true" Font-Size="12px" CssClass="MyLabel"
                                    ForeColor="Black"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblFeeGroup" runat="server" Width="110px">Fee Group </asp:Label><span
                                    style="color: #ff0000">*</span>
                            </td>
                            <%--/*======================================Modified by Manju on 23-04-2012===================================*/--%>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlFeeGroup" runat="server" CssClass="MyTextBox" Width="179px"
                                    TabIndex="20">
                                </asp:DropDownList>
                            </td>
                            <%--/*============================Modified BY Manju on 26-04-2012==========================================================*/--%>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblFeeApplnFrom" runat="server" Width="110px">Fee Appl. From </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlFeeApplnFrom" runat="server" CssClass="MyTextBox" Width="183px"
                                    TabIndex="21">
                                </asp:DropDownList>
                            </td>
                            <td align="center" class="MyLabel">
                                <asp:Label ID="lblClassStrength" runat="server" Font-Bold="true" CssClass="MyLabel"
                                    ForeColor="#C00000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblHouse" runat="server" Width="110px">House </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlHouse" runat="server" CssClass="MyTextBox" Width="179px"
                                    TabIndex="22">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblSocCategory" runat="server" Width="110px">Social&nbsp;Category </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlSocCategory" runat="server" CssClass="MyTextBox" Width="183px"
                                    TabIndex="23">
                                </asp:DropDownList>
                            </td>
                            <td align="center" class="MyLabel">
                                <asp:Label ID="lblTotalStrength" runat="server" Font-Bold="true" CssClass="MyLabel"
                                    ForeColor="#C00000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblReligion" runat="server" Width="110px">Religion</asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlReligion" runat="server" CssClass="MyTextBox" Width="179px"
                                    TabIndex="24">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblCaste" runat="server" Width="110px">Caste </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCaste" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="50" TabIndex="25" Width="177px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td align="right" class="MyLabel">
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlCaste" runat="server" CssClass="MyTextBox" Width="179px"
                                    TabIndex="25">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblStop" runat="server" Width="110px">Stop Name </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlStop" runat="server" CssClass="MyTextBox" Width="177px"
                                    TabIndex="41">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblStuEmergencyNo" runat="server" Width="110px">Emergency&nbsp;No. </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtStuEmergencyNo" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="60" Width="173px" TabIndex="26"></asp:TextBox>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblStuEmail" runat="server" Width="110px"> E-Mail </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtStuEmail" runat="server" BorderWidth="1px" Style="text-transform: lowercase"
                                    CssClass="MyTextBox" MaxLength="50" Width="177px" TabIndex="27"></asp:TextBox>
                            </td>
                            <td align="center" rowspan="4">
                                <table id="tbImageCaption">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblImgNote" runat="server" Font-Bold="true" CssClass="MyLabel" ForeColor="Black"
                                                Text="Status"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Image ID="I1" runat="server" ImageUrl="~/Images/Present.png" />
                                            T C
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Image ID="I2" runat="server" ImageUrl="~/Images/Absent.png" />
                                            Drop Out
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Image ID="I3" runat="server" ImageUrl="~/Images/HalfDay.png" />
                                            Repeater
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblAdmission" runat="server" Width="110px">Admission </asp:Label><%--/*============================End of Modified BY Manju on 26-04-2012==========================================================*/--%>
                            </td>
                            <td colspan="2">
                                <asp:RadioButton ID="rbtnAdmissionNew" runat="server" CssClass="MyLabel" Text="New"
                                    Width="88px" GroupName="Admission" Checked="True" TabIndex="28" /><asp:RadioButton
                                        ID="rbtnAdmissionOld" runat="server" CssClass="MyLabel" Text="Old" Width="80"
                                        GroupName="Admission" TabIndex="29" />
                            </td>
                            <td align="right" class="MyLabel">
                                <%--  <asp:Label ID="lblStuLivingWith" runat="server"  Text="StuLivingWith" Width="130px" style="left: 456px; position: relative; top: 0px"></asp:Label>--%>                                <%-- /*========================Modified BY Manju on 23-04-2012============================================*/--%>
                                <asp:Label ID="lblStuLivingWith" runat="server" Text="Living With" Width="88px"></asp:Label>
                            </td>
                            <%--<asp:Label ID="lblStuLivingWith" runat="server"  Text="StuLivingWith" Width="88px" ></asp:Label></td>--%>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlStuLiving" runat="server" CssClass="MyTextBox" Width="183px"
                                    TabIndex="30">
                                    <%--<asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value=" "></asp:ListItem>
                                    <asp:ListItem Value="Y">Parent</asp:ListItem>
                                     <asp:ListItem Value="N">Other</asp:ListItem>--%>
                                    <asp:ListItem Value="0">Parent</asp:ListItem>
                                    <asp:ListItem Value="1">Father</asp:ListItem>
                                    <asp:ListItem Value="2">Mother</asp:ListItem>
                                    <asp:ListItem Value="3">Local Gaurdian</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblMotherTongue" runat="server" Width="110px">Mother&nbsp;Tongue </asp:Label>&nbsp;
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlMotherTongue" runat="server" CssClass="MyTextBox" Width="177px"
                                    TabIndex="31">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel" rowspan="">
                                <asp:Label ID="lblConcession" runat="server" Width="110px">Concession Type </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlConcessionType" runat="server" CssClass="MyTextBox" Width="183px"
                                    TabIndex="32">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="MyLabel" align="right">
                                <asp:Label ID="lblNationality" runat="server" Width="110px">Nationality </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlNationality" runat="server" CssClass="MyTextBox" Width="177px"
                                    TabIndex="33">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblBloodGroup" runat="server" Width="110px">Blood&nbsp;Group </asp:Label>
                            </td>
                            <td colspan="2" align="left" valign="top">
                                <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="MyTextBox" Width="183px"
                                    TabIndex="34">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblBoardingCategory" runat="server" Width="110px"> Boarding&nbsp;Category</asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlBoardingCategory" runat="server" CssClass="MyTextBox" Width="177px"
                                    TabIndex="35">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblBoardRegNo" runat="server" Width="110px">Board&nbsp;Reg.&nbsp;No. </asp:Label>
                            </td>
                            <td align="left" colspan="2" valign="top">
                                <asp:TextBox ID="txtBoardRegNo" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="50" TabIndex="36" Width="177px"></asp:TextBox>
                            </td>
                            <td rowspan="1" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblBoard" runat="server" Width="110px">Board </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlBoard" runat="server" CssClass="MyTextBox" Width="177px"
                                    TabIndex="37">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblCBSERollNo" runat="server" Width="110px">Board&nbsp;Roll&nbsp;No. </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCBSERollNo" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="50" Width="177px" TabIndex="38"></asp:TextBox>
                            </td>
                            <td align="center" class="MyTableHeader" id="tdOption">
                                <asp:Label ID="LblOptionsHr" runat="server">Options</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblNoOfChild" runat="server" Width="110px"> Children in Family</asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:TextBox ID="txtNoOfChild" runat="server" CssClass="MyTextBox" Width="173px"
                                    MaxLength="4" TabIndex="39"></asp:TextBox>
                            </td>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblPositionChild" runat="server" Width="110px">Position.of Child </asp:Label>
                            </td>
                            <td colspan="2" align="left" valign="top">
                                <asp:TextBox ID="txtPositionChild" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    Width="177px" MaxLength="4" TabIndex="40"></asp:TextBox>
                            </td>
                            <td colspan="1" rowspan="20" valign="top" align="Center">
                                <table style="position: relative" id="tblButton">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnNew" runat="server" CssClass="MyButton" Text="New" OnClientClick="return fAssign_New();"
                                                OnClick="btnNew_Click" TabIndex="80" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnEdit" runat="server" CssClass="MyButton" Text="Edit" OnClientClick="javascript:return pHandleOnEdit();"
                                                TabIndex="81" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" CssClass="MyButton" OnClientClick="javascript:return pValidateOnSave();"
                                                Text="Save" OnClick="btnSave_Click" TabIndex="82" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnDropOut" runat="server" CssClass="MyButton" Text="Dropout" TabIndex="83"
                                                OnClientClick="return OpenDropOutform();" />
                                        </td>
                                        <%--/*========================Modified BY Manju on 23-04-2012============================================*/--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnTC" runat="server" CssClass="MyButton" Text="TC" TabIndex="84"
                                                OnClientClick="return OpenTCform();" />
                                        </td>
                                        <%--<asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value=" "></asp:ListItem>
                                    <asp:ListItem Value="Y">Parent</asp:ListItem>
                                     <asp:ListItem Value="N">Other</asp:ListItem>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnRemarks" runat="server" CssClass="MyButton" Text="Remarks" TabIndex="85"
                                                OnClientClick="return OpenSIStudentRemarksform();" />
                                        </td>
                                        <%--OnClientClick=" return Validate_On_DropOut()" OnClick="btnDropOut_Click"--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnDetails" runat="server" CssClass="MyButton" Text="Details" OnClick="btnDetails_Click"
                                                OnClientClick="return fDetCloseFind();" TabIndex="86" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" CssClass="MyButton" OnClientClick="javascript:return Validate_On_Cancel();"
                                                Text="Cancel" OnClick="btnCancel_Click" TabIndex="87" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnClose" runat="server" CssClass="MyButton" Text="Close" OnClientClick="javascript:return fClose();"
                                                OnClick="btnClose_Click" TabIndex="88" />
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:CheckBox ID="chkParentDetailUpdate" runat="server" CssClass="MyLabel" TabIndex="86"
                                                Text="Update Sibling" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkAClear" runat="server" CssClass="MyLabel" Text="Auto Clear"
                                                TabIndex="89" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <%--OnClientClick=" return Validate_On_DropOut()" OnClick="btnDropOut_Click"--%><%--OnClientClick=" return Validate_On_DropOut()" OnClick="btnDropOut_Click"--%>
                            </td>
                            <%--/*==========================Modified BY Manju on 23-04=2012=================================*/--%>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td align="right" class="MyLabel" colspan="1">
                                <asp:Label ID="lblChildCode" runat="server" Width="110px">ChildCode </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtChildCode" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    Width="177px" MaxLength="4" TabIndex="42"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<asp:Label ID="lblNoOfChild" runat="server" Width="110px" > No.Of.Chold</asp:Label></td>--%>                        <%--/*==========================Modified BY Manju on 23-04=2012=================================*/--%>
                        <tr style="display: none">
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblProvision" runat="server" Width="110px">Provi. Admission </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:RadioButton ID="rbtProvYes" runat="server" CssClass="MyLabel" Text="Yes" Width="50px"
                                    GroupName="Pro" TabIndex="43" /><asp:RadioButton ID="rbtProvNo" runat="server" CssClass="MyLabel"
                                        Text="No" Width="75px" Checked="True" GroupName="Pro" TabIndex="44" />
                            </td>
                            <td align="right" class="MyLabel" colspan="1">
                                <asp:Label ID="lblLiveEduID" runat="server">Office365 ID</asp:Label>
                            </td>
                            <td colspan="2">
                                &nbsp;<asp:TextBox ID="txtLiveEduID" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="50" TabIndex="49" Width="173px"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                                        <td align="right" class="MyLabel">
                            </td>
                                        <td  colspan="2" valign="top" >
                                </td>
                                         
                                    </tr>--%>                        <%--<tr>
                                        <td align="right" class="MyLabel" >
                                            <asp:Label ID="lblPositionChild" runat="server" Text="Position of Child"></asp:Label></td>
                                        <td  colspan="2" valign="top" style="height: 10px"  >
                                <asp:TextBox ID="txtPositionChild" runat="server" BorderWidth="1px" CssClass="MyTextBox" Width="173px" MaxLength="4" TabIndex="42" ></asp:TextBox></td>                                        
                                     
                                       </tr>--%>                        <%--      <tr>
                      
                            <td align="right" class="MyLabel"  >
                                </td>
                            <td align="left" colspan="2" rowspan="1"   valign="top">
                                </td>
                                           <td align="left" colspan="1" rowspan="1" valign="top">
                                           </td>
                                           <td align="left" colspan="2" rowspan="1" valign="top">
                                           </td>
                            

                        </tr>--%>                        <%--<tr>
                            <td align="right" class="MyLabel">
                            </td>
                            <td align="left" colspan="2" rowspan="1" valign="top">
                            </td>
                            <td align="right" class="MyLabel" rowspan="1">
                            </td>
                            <td align="left" colspan="2" rowspan="1" valign="top">
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblSiqmano" runat="server" Width="130px">Res Perm No. & ExpiryDate</asp:Label>
                            </td>
                            <td align="left" colspan="2" rowspan="1" valign="top">
                                <asp:TextBox ID="txtSiqmano" runat="server" CssClass="MyTextBox" MaxLength="50" TabIndex="47"
                                    Width="102px"></asp:TextBox><asp:TextBox ID="txtSiqmaExpiryDate" runat="server" CssClass="MyTextBox"
                                        onkeypress="javascript:return RestrictEnterDate(event);" MaxLength="10" TabIndex="48"
                                        Width="65px"></asp:TextBox>
                            </td>
                            <td align="right" class="MyLabel">
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <%-- <tr>
                            <td align="right" class="MyLabel">
                               </td>
                            <td align="left" colspan="2" rowspan="1" valign="top">
                                </td>
                            <td align="right" class="MyLabel">
        </td>
                            <td colspan="2">
        </td>
                        </tr>--%>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblRemarks" runat="server" Width="110px">Remarks </asp:Label>
                            </td>
                            <td align="left" colspan="5" rowspan="1" valign="top">
                                <asp:TextBox ID="txtRemarks" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    Width="497px" TextMode="MultiLine" TabIndex="50" MaxLength="250"></asp:TextBox>
                            </td>
                        </tr>
                        <%--                 <tr style="display:none;">
                            <td align="right" class="MyLabel">
        </td>
                            <td align="left" colspan="2" rowspan="1" valign="top">
        </td>
                            <td align="right" class="MyLabel">
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>--%>
                        <tr id="trRoutedetails">
                            <td id="tdBusMorninghr" align="right" style="color: Red; height: 16px;" class="MyLabel">
                                <asp:Label ID="lblBusMorninghr" runat="server"></asp:Label>
                            </td>
                            <td align="left" id="tdBusMorning" colspan="2" style="color: Red; height: 16px;"
                                class="MyLabel">
                                <asp:Label ID="lblBusMorning" runat="server"></asp:Label>
                            </td>
                            <td id="tdBusAfterNoonhr" align="right" style="color: Red; height: 16px;" class="MyLabel">
                                <asp:Label ID="lblBusAfterNoonhr" runat="server"></asp:Label>
                            </td>
                            <td align="left" id="tdBusAfterNoon" colspan="2" style="color: Red; height: 16px;"
                                class="MyLabel">
                                <asp:Label ID="lblBusAfterNoon" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%-- <tr>
                            <td align="right" class="MyLabel" valign="top" >
                                   </td>
                            <td align="left" colspan="2" rowspan="1"  valign="top">
                                    <table cellpadding="0" cellspacing="0" style="position: relative" >
                                        <tr>
                                            <td >
                                                </td>
                                            <td >
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" class="MyLabel" valign="top">
                                   </td>
                                <td colspan="2" valign="top"><table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnSchTransYes" runat="server" CssClass="MyLabel" Text="Yes" Width="85px" GroupName="Pro"  TabIndex="44" Visible="False" /></td>
                                        <td>
                                            <asp:RadioButton ID="rbtnSchTransNo" runat="server" CssClass="MyLabel" Text="No" Width="75px"  GroupName="Pro" TabIndex="45" Visible="False" /></td>
                                    </tr>
                                </table>
                                </td>
                        </tr>--%>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblMeals" runat="server" Text="Meals" Width="110px"></asp:Label>
                            </td>
                            <td align="left" class="MyLabel" colspan="2">
                                <asp:DropDownList ID="ddlMeal" runat="server" CssClass="MyTextBox" Width="175px"
                                    TabIndex="51">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="1">No</asp:ListItem>
                                    <asp:ListItem Value="2">Veg</asp:ListItem>
                                    <asp:ListItem Value="3">Non Veg</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblLanguageKnown" runat="server" Width="110px">Lang.&nbsp;Known </asp:Label>
                            </td>
                            <td align="left" class="MyLabel" colspan="2" rowspan="4">
                                <asp:Panel ID="pnlLanguageKnown" runat="server" BorderWidth="1px" Height="95px" ScrollBars="Vertical"
                                    Width="174px" TabIndex="56">
                                    <asp:CheckBoxList ID="chkLanguageKnown" runat="server" CellPadding="0" CellSpacing="0"
                                        CssClass="MyLabel" Width="150px">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                            <td align="center" rowspan="1" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblSchoolBus" runat="server" Text="School Bus" Width="110px"></asp:Label>
                            </td>
                            <td align="left" class="MyLabel" colspan="2">
                                <asp:DropDownList ID="ddlSchoolBus" runat="server" CssClass="MyTextBox" Width="177px"
                                    TabIndex="52">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value=" "></asp:ListItem>
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel" valign="top">
                                &nbsp;
                            </td>
                            <td align="center" valign="top">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblThirdLanguage" runat="server" Text="Third Language" Width="110px"></asp:Label>
                            </td>
                            <td align="left" class="MyLabel" colspan="2">
                                <asp:DropDownList ID="ddlThirdLanguage" runat="server" CssClass="MyTextBox" Width="177px"
                                    TabIndex="54">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel" valign="top">
                                &nbsp;
                            </td>
                            <td align="center" rowspan="1" valign="top">
                            </td>
                        </tr>
                        <%--/*===============Modified By Manju on 01-06-2012=================================*/--%>                        <%--/*===============End of Modified By Manju on 01-06-2012=================================*/--%>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblSecondLanguage" runat="server" Text="Second Language" Width="110px"></asp:Label>
                            </td>
                            <td align="left" class="MyLabel" colspan="2">
                                <asp:DropDownList ID="ddlSecondLanguage" runat="server" CssClass="MyTextBox" Width="175px"
                                    TabIndex="53">
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="MyLabel" valign="top">
                                &nbsp;
                            </td>
                            <td align="center" valign="top">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right" class="MyLabel" valign="top">
                                Type of Impairment
                            </td>
                            <td align="left" class="MyLabel" colspan="2">
                                <asp:Panel ID="pnlImpairment" runat="server" BorderWidth="1px" Height="95px" ScrollBars="Vertical"
                                    Width="174px" TabIndex="55">
                                    <asp:CheckBoxList ID="chkImpairment" runat="server" CellPadding="0" CellSpacing="0"
                                        CssClass="MyLabel" Width="150px">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                            <td align="right" class="MyLabel" valign="top">
                                Free Ship
                            </td>
                            <td align="left" class="MyLabel" colspan="2" valign="top">
                                <asp:RadioButton ID="rbtnFreeShipYes" runat="server" CssClass="MyLabel" Text="Yes"
                                    Width="50px" GroupName="FreeShip" TabIndex="45" /><asp:RadioButton ID="rbtnFreeShipNo"
                                        runat="server" CssClass="MyLabel" Text="No" Width="75px" Checked="True" GroupName="FreeShip"
                                        TabIndex="46" />
                            </td>
                            <td align="center" rowspan="1" valign="top">
                            </td>
                        </tr>
                        <tr class="MyTableHead">
                            <td class="MyTableHeader">
                            </td>
                            <td class="MyTableHeader" align="center" colspan="2">
                                <asp:Label ID="lblResidentAdressHr" runat="server">Residence&nbsp;Address </asp:Label>
                            </td>
                            <td class="MyTableHeader" align="center" colspan="3">
                                <asp:Label ID="lblPermanentAdressHr" runat="server">Permanent&nbsp;Address </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblPresAddress" runat="server" Width="110px">Address </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPresAddress" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="150" TextMode="MultiLine" Width="173px" TabIndex="57" OnTextChanged="txtPresAddress_TextChanged"></asp:TextBox>
                            </td>
                            <td rowspan="6" align="center">
                                <asp:ImageButton ID="imgbtnAddress" runat="server" Height="48px" ImageUrl="~/Images/Arrow.gif"
                                    Width="51px" OnClientClick="return Assign_StudentAddress();" TabIndex="63" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPerAddress" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="150" TextMode="MultiLine" Width="179px" TabIndex="64"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblResiCity" runat="server" Width="110px">City/&nbsp;District</asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtResiCity" runat="server" CssClass="MyTextBox" Width="173px" MaxLength="120"
                                    TabIndex="58"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPerCity" runat="server" CssClass="MyTextBox" Width="179px" MaxLength="120"
                                    TabIndex="65"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblPresState" runat="server" Width="110px">State</asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPresState" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="20" Width="173px" ReadOnly="True" TabIndex="59"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPerState" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    Width="179px" ReadOnly="True" TabIndex="66"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblPresCountry" runat="server" Width="110px">Country</asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPresCountry" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="20" Width="173px" ReadOnly="True" TabIndex="60"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPerCountry" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    Width="179px" ReadOnly="True" TabIndex="67"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblPresPincode" runat="server" Width="110px">Pincode</asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPresPincode" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="15" Width="173px" TabIndex="61"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPerPincode" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="30" Width="179px" TabIndex="68"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel">
                                <asp:Label ID="lblPresPhone" runat="server" Width="110px">Phone </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPresPhone" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="60" Width="173px" TabIndex="62"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPerPhone" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                    MaxLength="60" Width="179px" TabIndex="69"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="MyTableHead" colspan="7">
                                <asp:Label ID="lblSiblingDetails" runat="server" Width="160px">Sibling&nbsp;Details</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" align="left">
                                <asp:Panel ID="pnlSibiling" runat="server" class="MyTableBorder" Height="100px" ScrollBars="Auto"
                                    Width="730px" TabIndex="70">
                                    <asp:GridView ID="gvSibling" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                        EmptyDataText="No Records Found" Width="710px" OnRowDataBound="gvSibling_RowDataBound"
                                        TabIndex="71" CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                                        <Columns>
                                            <asp:BoundField HeaderText="Sl.No." DataField="SNo">
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                                <HeaderStyle HorizontalAlign="Right" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Admission No" DataField="AdmissionNo">
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="StudentName">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="StudentName" runat="server" Text='<%# Bind("StudentName") %>' CssClass="MyDynamicText"
                                                        Width="170px" MaxLength="50"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="170px" HorizontalAlign="Left" />
                                                <HeaderStyle CssClass="Text" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Class &amp; Section" DataField="ClassSection">
                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                <HeaderStyle HorizontalAlign="Left" Width="150px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="MyTableHead" colspan="7">
                                <asp:Label ID="lblEmergencyContact" runat="server" Width="160px">Emergency&nbsp;Contact</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" colspan="7">
                                <asp:Panel ID="pnlEmergencyContact" runat="server" class="MyTableBorder" Height="100px"
                                    ScrollBars="Auto" Width="730px" TabIndex="72">
                                    <asp:GridView ID="gvEmergencyContact" runat="server" AutoGenerateColumns="False"
                                        CellPadding="0" EmptyDataText="No Records Found" Width="710px" TabIndex="73"
                                        OnRowDataBound="gvEmergencyContact_RowDataBound" CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                                        <Columns>
                                            <asp:BoundField HeaderText="Sl.No." DataField="SNo">
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                                <HeaderStyle HorizontalAlign="Right" Width="60px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <%-- /*==================================Modified By Manju on 23-04-2012=================================*/--%>
                                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("PersonName") %>' CssClass="MyDynamicText"
                                                        Width="150px" onkeypress="javascript:return pInsertgridRow('gvEmergencyContact',event,true,'txtName',120);"></asp:TextBox>
                                                    <%--/*==================================End of Modified By Manju on 23-04-2012=================================*/--%>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" HorizontalAlign="Left" />
                                                <HeaderStyle CssClass="Text" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Relationship">
                                                <ItemTemplate>
                                                    <%-- /*==================================Modified By Manju on 23-04-2012=================================*/--%>
                                                    <asp:TextBox ID="txtRelationship" runat="server" Text='<%# Bind("Relationship") %>'
                                                        CssClass="MyDynamicText" Width="100px" onkeypress="javascript:return pInsertgridRow('gvEmergencyContact',event,true,'txtRelationship',100);"></asp:TextBox>
                                                    <%--/*==================================End of Modified By Manju on 23-04-2012=================================*/--%>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                <HeaderStyle CssClass="Text" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Phone. No.">
                                                <ItemTemplate>
                                                    <%-- /*==================================Modified By Manju on 23-04-2012=================================*/--%>
                                                    <asp:TextBox ID="txtPhoneNo" runat="server" Text='<%# Bind("PhoneNo") %>' CssClass="MyDynamicText"
                                                        Width="120px" onkeypress="javascript:return pInsertgridRow('gvEmergencyContact',event,true,'txtPhoneNo',60);"></asp:TextBox>
                                                    <%--/*==================================End of Modified By Manju on 23-04-2012=================================*/--%>
                                                </ItemTemplate>
                                                <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                <HeaderStyle CssClass="Text" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <%-- /*==================================Modified By Manju on 23-04-2012=================================*/--%>
                                                    <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' CssClass="MyDynamicText"
                                                        Width="200px" onkeypress="javascript:return pInsertgridRow('gvEmergencyContact',event,true,'txtRemarks',300);"></asp:TextBox>
                                                    <%--/*==================================End of Modified By Manju on 23-04-2012=================================*/--%>
                                                </ItemTemplate>
                                                <ItemStyle Width="200px" HorizontalAlign="Left" />
                                                <HeaderStyle CssClass="Text" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="MyTableHead" colspan="7">
                                <asp:Label ID="lblAuthorised" runat="server" Width="160px">Authorised&nbsp;PickUp</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" colspan="7">
                                <asp:Panel ID="pnlAuthorised" runat="server" class="MyTableBorder" Height="100px"
                                    ScrollBars="Auto" Width="730px" TabIndex="73">
                                    <asp:GridView ID="gvAuthorisedPickUp" runat="server" AutoGenerateColumns="False"
                                        CellPadding="0" EmptyDataText="No Records Found" Width="710px" OnRowDataBound="gvAuthorisedPickUp_RowDataBound"
                                        TabIndex="74" CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                                        <Columns>
                                            <asp:BoundField HeaderText="Sl.No." DataField="SNo">
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                                <HeaderStyle HorizontalAlign="Right" Width="60px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("PersonName") %>' CssClass="MyDynamicText"
                                                        Width="130px" onkeypress="javascript:return pInsertgridRow('gvAuthorisedPickUp',event,true,'txtName',120);"
                                                        MaxLength="120"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" HorizontalAlign="Left" />
                                                <HeaderStyle Width="80px" CssClass="Text" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Relationship">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRelationship" runat="server" Text='<%# Bind("Relationship") %>'
                                                        CssClass="MyDynamicText" Width="80px" onkeypress="javascript:return pInsertgridRow('gvAuthorisedPickUp',event,true,'txtRelationship',50);"
                                                        MaxLength="50"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" HorizontalAlign="Left" />
                                                <HeaderStyle Width="80px" CssClass="Text" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Phone. No.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPhoneNo" runat="server" Text='<%# Bind("PhoneNo") %>' CssClass="MyDynamicText"
                                                        Width="120px" onkeypress="javascript:return pInsertgridRow('gvAuthorisedPickUp',event,true,'txtPhoneNo',60);"
                                                        MaxLength="60"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" HorizontalAlign="Left" />
                                                <HeaderStyle Width="80px" CssClass="Text" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' CssClass="MyDynamicText"
                                                        Width="150px" onkeypress="javascript:return pInsertgridRow('gvAuthorisedPickUp',event,true,'txtRemarks',300);"
                                                        MaxLength="300"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                <HeaderStyle Width="100px" CssClass="Text" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="imgpath">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtimgPath" runat="server" Text='<%# Bind("imgPath") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="5px" HorizontalAlign="Left" />
                                                <HeaderStyle Width="5px" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Browse">
                                                <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                <HeaderStyle Width="60px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <a href="#">....</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                <HeaderStyle Width="60px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <a href="#">View</a><%--fAssignPhoto() onclick=" fGridClick()"--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remove">
                                                <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                <HeaderStyle Width="60px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <a href="#">Remove</a><%--fAssignPhoto() onclick=" fGridClick()"--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="MyTableHead" colspan="7" valign="top">
                                <%--<tr>
                            <td align="right" class="MyLabel">
                                </td>
                            <td align="left" class="MyLabel" colspan="2">
                                &nbsp;</td>
                                <td align="right" class="MyLabel">
                                </td>
                            <td align="left" class="MyLabel" colspan="2">
                                </td>
                            <td align="center" rowspan="8" valign="top">
                            </td>
                        </tr>--%>                                <%--<tr>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblHomeAdvisor" runat="server" Text="Home Advisor" Width="110px"></asp:Label></td>
                            <td align="left" class="MyLabel" colspan="2">
                                <asp:DropDownList ID="ddlHomeAdvisor" runat="server" CssClass="MyTextBox" TabIndex="53"
                                    Width="175px">
                                </asp:DropDownList></td>
                            <td align="right" class="MyLabel" valign="top">
                            </td>
                            <td align="left" class="MyLabel" colspan="2">
                            </td>
                            <td align="center" rowspan="1" valign="top">
                            </td>
                        </tr>--%>
                                <asp:Label ID="lblDocuments" runat="server" Text="Label" Width="175px">Documents Submitted</asp:Label>
                            </td>
                            <%-- /*==================================Modified By Manju on 23-04-2012=================================*/--%>
                        </tr>
                        <tr>
                            <td align="left" colspan="7" valign="top">
                                <asp:Panel ID="pnlgvdocuments" runat="server" class="MyTableBorder" Height="120px"
                                    ScrollBars="Auto" Width="730px" TabIndex="75">
                                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                        EmptyDataText="No Records Found" Width="710px" OnRowDataBound="gvDocuments_RowDataBound"
                                        TabIndex="76" CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                                        <Columns>
                                            <asp:BoundField HeaderText="Sl.No." DataField="SNo">
                                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                                                <HeaderStyle HorizontalAlign="Right" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="DID" DataField="DocumentID">
                                                <ItemStyle HorizontalAlign="Left" Width="5px" />
                                                <HeaderStyle HorizontalAlign="Left" Width="5px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Document" DataField="Documen">
                                                <ItemStyle HorizontalAlign="Left" Width="400px" />
                                                <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="YES" runat="server" Checked='<%#Bind("YES") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="imgpath">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtimgPath" runat="server" Text='<%# Bind("imgPath") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="5px" HorizontalAlign="Left" />
                                                <HeaderStyle Width="5px" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Browse">
                                                <ItemStyle Width="70px" HorizontalAlign="Center" />
                                                <HeaderStyle Width="70px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <a href="#">....</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemStyle Width="75px" HorizontalAlign="Center" />
                                                <HeaderStyle Width="75px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <a href="#">View</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="MyTableHead" colspan="7" valign="top">
                                <asp:Label ID="lblgvPreviousDeatils" runat="server" Width="209px">Previous&nbsp;Education&nbsp;Details</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="7" valign="top">
                                <asp:Panel ID="Panel1" runat="server" class="MyTableBorder" Height="120px" Width="730px"
                                    ScrollBars="Vertical" TabIndex="77">
                                    <asp:GridView ID="gvPreviousEducation" runat="server" EmptyDataText="No Records Found"
                                        CssClass="mGrid" AlternatingRowStyle-CssClass="alt" Width="710px" AutoGenerateColumns="False"
                                        TabIndex="78" OnRowDataBound="gvPreviousEducation_RowDataBound">
                                        <Columns>
                                            <asp:BoundField HeaderText="Sl.No" DataField="SNo">
                                                <ItemStyle HorizontalAlign="Right" Width="40px" />
                                                <HeaderStyle HorizontalAlign="Right" Width="40px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Name of School">
                                                <ItemTemplate>
                                                    <%--/*==================================Modified By Manju on 23-04-2012======================================*/--%>
                                                    <asp:TextBox ID="txtSchoolName" runat="server" Text='<%# Bind("NameOfSchool") %>'
                                                        CssClass="MyDynamicText" Width="130px" onkeypress="javascript:return pInsertgridRow('gvPreviousEducation',event,true,'txtSchoolName',120);"></asp:TextBox>
                                                    <%--/*==================================End of Modified By Manju on 23-04-2012======================================*/--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtLocation" runat="server" Text='<%# Bind("Location") %>' CssClass="MyDynamicText"
                                                        Width="90px" onkeypress="javascript:return pInsertgridRow('gvPreviousEducation',event,true,'txtLocation',60);"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class Completed">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtClassCompleted" runat="server" Text='<%# Bind("ClassCompleted") %>'
                                                        CssClass="MyDynamicText" Width="70" onkeypress="javascript:return pInsertgridRow('gvPreviousEducation',event,true,'txtClassCompleted',50);"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Years Attended">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtYearAttended" runat="server" Text='<%# Bind("YearAttended") %>'
                                                        CssClass="MyDynamicText" Width="65" MaxLength="4" onkeypress="javascript:return pInsertgridRow('gvPreviousEducation',event,true,'txtYearAttended',4);"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Langauge of Instruction">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtLanguage" runat="server" Text='<%# Bind("LanguageOfInstruction") %>'
                                                        CssClass="MyDynamicText" Width="60px" onkeypress="javascript:return pInsertgridRow('gvPreviousEducation',event,true,'txtLanguage',50);"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Result">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtResult" runat="server" Text='<%# Bind("Result") %>' CssClass="MyDynamicText"
                                                        Width="65px" onkeypress="javascript:return pInsertgridRow('gvPreviousEducation',event,true,'txtResult',25);"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
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
        <div style="display: none;">
            <asp:Button ID="btnBind" runat="server" BackColor="White" BorderColor="White" BorderWidth="0px"
                ForeColor="White" Text="Button" />
        </div>
        <%--/*==================================End of Modified By Manju on 23-04-2012=================================*/--%>        <%-- /*==================================Modified By Manju on 23-04-2012=================================*/--%>        <%--/*==================================End of Modified By Manju on 23-04-2012=================================*/--%>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="1000"
            EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="GetCompletionList"
            ServicePath="WSStudentSearch.asmx" TargetControlID="txtStuSelect" CompletionListElementID="divAutoComplete">
        </cc1:AutoCompleteExtender>
        <div id="divAutoComplete" class="MyText">
        </div>
        <div class="MyText" id="divResiCity">
        </div>
        <div class="MyText" id="divPerCity">
        </div>
        <div class="MyText" id="divParentID">
        </div>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="1000"
            EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="GetResiCityList"
            ServicePath="WSStudentSearch.asmx" TargetControlID="txtResiCity" CompletionListElementID="divResiCity">
        </cc1:AutoCompleteExtender>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="1000"
            EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="GetPerCityList" ServicePath="WSStudentSearch.asmx"
            TargetControlID="txtPerCity" CompletionListElementID="divPerCity">
        </cc1:AutoCompleteExtender>
        <asp:Button ID="btnResiCity" runat="server" Text="ResiCity" Style="display: none;"
            OnClick="btnResiCity_Click" />
        <asp:Button ID="btnPerCity" runat="server" Text="PerCity" Style="display: none;"
            OnClick="btnPerCity_Click" />
        <asp:HiddenField ID="hdnFlagPresCity" runat="server" />
        <asp:HiddenField ID="hdnFlagPerCity" runat="server" />
        <%-- /*==================================Modified By Manju on 23-04-2012=================================*/--%>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="1000"
            EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="GetParentList" ServicePath="WSStudentSearch.asmx"
            TargetControlID="txtParentID" CompletionListElementID="divParentID">
        </cc1:AutoCompleteExtender>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" CompletionInterval="1000"
            EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="GetStudentListWIthAdmissionNo"
            ServicePath="WSStudentSearch.asmx" TargetControlID="txtSiblingAdmNo" CompletionListElementID="divSiblingAdmNo">
        </cc1:AutoCompleteExtender>
        <asp:HiddenField ID="hdnSImagePath" runat="server" />
        <asp:HiddenField ID="hdnFlag" runat="server" />
        <asp:HiddenField ID="hdntxtStuSelect" runat="server" />
        <asp:HiddenField ID="hdntxtParentID" runat="server" />
        <asp:HiddenField ID="hidAutoClear" runat="server" />
        <asp:HiddenField ID="hdntxtResiCity" runat="server" />
        <asp:HiddenField ID="hdntxtPerCity" runat="server" />
        <asp:HiddenField ID="hdnChkLanguage" runat="server" />
        <asp:HiddenField ID="hdnSDID" runat="server" />
        <asp:HiddenField ID="hdnAdmNo" runat="server" />
        <asp:HiddenField ID="hdnFindSearch" runat="server" />
        <asp:HiddenField ID="hidParentID" runat="server" />
        <%--/*==================================End of Modified By Manju on 23-04-2012=================================*/--%>
        <asp:HiddenField ID="hidFeeGrpID" runat="server" />
        <asp:HiddenField ID="hidFeeAppID" runat="server" />
        <asp:HiddenField ID="hidCache" runat="server" />
        <asp:HiddenField ID="hdnRow" runat="server" />
        <asp:HiddenField ID="hdngvtype" runat="server" />
        <asp:HiddenField ID="hdnFImagePath" runat="server" />
        <asp:HiddenField ID="hdnMImagePath" runat="server" />
        <asp:HiddenField ID="hidStatusdisplay" runat="server" />
        <asp:HiddenField ID="hdnImage" runat="server" />
        <%-- /*==================================Modified By Manju on 23-04-2012=================================*/--%>
        <div id="divFind" style="height: 500px; width: 270px; display: none">
            <%--/*==================================End of Modified By Manju on 23-04-2012=================================*/--%>
            <table style="border-width: 0px;">
                <tr>
                    <td valign="top" class="divCircle">
                        <table id="tdFind" class="MyTableBorder">
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <a href="#" onclick="return fCloseFind();">X</a>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFindClass" runat="server" Text="Class" Width="90px" CssClass="MyLabel"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFindClass" runat="server" CssClass="MyTextBox" onchange="fSection('DivFindSec')"
                                        Width="117px">
                                    </asp:DropDownList>
                                    <%--fAssignPhoto() onclick=" fGridClick()"--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Section
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFindSection" runat="server" CssClass="MyTextBox" Width="117px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFindStudent" runat="server" Text="Student" Width="90px" CssClass="MyLabel"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFindStudent" runat="server" CssClass="MyTextBox" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFindFatherName" runat="server" Text="Father's Name" Width="90px"
                                        CssClass="MyLabel"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFindFatherName" runat="server" CssClass="MyTextBox" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFindMotherName" runat="server" Text="Mother's Name" Width="90px"
                                        CssClass="MyLabel"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFindMotherName" runat="server" CssClass="MyTextBox" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                    <%--fAssignPhoto() onclick=" fGridClick()"--%>
                                    <asp:Button ID="btnFindSearch" runat="server" Text="Search" CssClass="MyButton" OnClientClick=" return fBindSerach()" />
                                </td>
                                <%--/*============================Modified BY Manju on 23-04-2012============================*/--%>                                <%--<asp:Label ID="lblDocuments" runat="server"  Text="Label" Width="175px">Documents</asp:Label></td>--%>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" valign="top">
                                    <asp:Panel ID="pnlFind" runat="server" class="MyTableBorder" ScrollBars="Vertical"
                                        Height="340px" Width="230px">
                                        <asp:GridView ID="gvFindStudent" runat="server" Width="212px" AutoGenerateColumns="False"
                                            OnRowDataBound="gvFindStudent_RowDataBound" CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl.No."></asp:TemplateField>
                                                <asp:BoundField DataField="StudentID" HeaderText="StudentID" />
                                                <asp:BoundField DataField="RollNo" HeaderText="R No.">
                                                    <ItemStyle HorizontalAlign="Right" Width="40px" />
                                                    <HeaderStyle HorizontalAlign="Right" Width="40px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AdmNo" HeaderText="Adm No.">
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SName" HeaderText="Name">
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundField>
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
        <%--/*============================End of Modified BY Manju on 23-04-2012============================*/--%>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    &nbsp;&nbsp;
    <%--/*==================================Modified By Manju on 23-04-2012======================================*/--%>
    <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click"
        Style="display: none;" />
    <asp:Button ID="btnFindDisplay" runat="server" Text="FindDisplay" Style="display: none;"
        OnClick="btnFindDisplay_Click" />
    <asp:Button ID="btnShowSave" runat="server" Text="ShowSave" Style="display: none;"
        OnClick="btnShowSave_Click" />
    <%--/*==================================End of Modified By Manju on 23-04-2012======================================*/--%>
    <asp:ListBox ID="ListBox" Style="z-index: 1000; display: none;" runat="server" Height="59px">
    </asp:ListBox>
    <asp:Panel ID="pnlPickupPhoto" runat="server" Height="250px" Style="position: absolute;
        display: none;" Width="250px">
        <asp:ImageButton ID="imgPickup" runat="server" Style="position: absolute" Width="250px"
            Height="250px" OnClientClick="return pPickImgResize();" ImageUrl="~/AuthorisedPickup/NoImage.JPG" />
    </asp:Panel>
    <%--   <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnFind" PopupControlID="divFind">
        </cc1:ModalPopupExtender>
        document.getElementById('hdnParentID').value=  varStudent[0];
                  document.getElementById('hdnRollNo').value=  varStudent[0];
        --%>
    <div style="display: none;">
        <asp:Image ID="imgQRCode" runat="server" Width="94px" ImageUrl="~/StudentPhoto/NoImage.JPG"
            Height="95px" />
    </div>
    <%--/*=============Added BY Manju on 25-04-2012=====================*/--%>
    <div id="divToolTip" style="font-size: 11px; float: left; font-weight: bold;">
        <div align="left">
            <div class="Arrow-right" style="float: right;">
            </div>
            <div class="divInner" style="width: 100px; float: left;">
                <div style="width: 100px;">
                    <table class="MyTableHeader" style="width: 100px;">
                        <tr>
                            <td style="width: 90%">
                                Strength
                            </td>
                            <td style="width: 10%">
                                <a href="#" onclick="return fCloseStrength();" style="text-decoration: none; color: White;">
                                    X</a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divText" style="margin: 5px" align="center">
                    <asp:Label ID="ClassStrength" runat="server" CssClass="MyLabel" Font-Size="12px"
                        ForeColor="Blue" Font-Italic="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidSiblingAdm" runat="server" />
    <asp:Button ID="btnSiblingSearch" runat="server" Style="display: none;" Text="Button"
        OnClick="btnSiblingSearch_Click" />
    <%-- <asp:HiddenField ID="hdnParentID" runat="server" />--%>
    </form>
</body>
</html>
