<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewGuideLine.aspx.cs" Inherits="NewGuideLine"  EnableEventValidation="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
<base target="_self" />
    <title>Information</title>
            <link type="text/css" href="theme/jquery.ui.all.css" rel="stylesheet" />
            <script type="text/javascript" src="Scripts/shadedborder.js"></script>
            <script language="javascript" src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
            <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
            <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
           <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
            <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
            <script type="text/javascript" src="Scripts/shadedborder.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.position.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.core.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.widget.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.datepicker.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.mouse.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.droppable.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.resizable.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.dialog.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.mouse.js"></script>
            <script type="text/javascript" src="Scripts/jquery.ui.button.js"></script>
            <link href="CSS/admin.css" rel="stylesheet" media="all" type="text/css" />
            <link href="CSS/styleasn.css" rel="stylesheet" media="all" type="text/css" />
 
       <script language="javascript" type="text/javascript">

        addLoadEvent(pEnableDisable);
        function pEnableDisable()
        {

           document.getElementById('trSchoolHead').style.display='none';
           document.getElementById('trSchoolHead1').style.display='none';
           return false;  
        }

        function pPrint()
        {  
        document.getElementById('tbagree').style.display='none';
        document.getElementById('trlnk').style.display='none';
        document.getElementById('trSchoolHead').style.display='';
        document.getElementById('trSchoolHead1').style.display='';
        document.getElementById('header').style.display='none';
        window.print();
        document.getElementById('tbagree').style.display='';
        document.getElementById('trSchoolHead').style.display='none';
        document.getElementById('trSchoolHead1').style.display='none';
        document.getElementById('header').style.display='';
        document.getElementById('trlnk').style.display='';
        return false;
        }
        
        
     var shadowedBorder    = RUZEE.ShadedBorder.create({ corner:8, shadow:16 });        
     function testColl(id)
    {
    //debugger;
    //debugger;DlSubjects_ctl00_Label3
        var str = id.split('_');
        //var newID = str[0] + '_' + str[1] + '_Label2';
         var newID1 = str[0] + '_' + str[1] + '_Label3';
        var varimg=str[0] + '_' + str[1] +'_description_ToggleImage';
        if(document.getElementById(newID1).style.display == 'block')
        {
            //document.getElementById(newID).style.display = 'none';
            document.getElementById(newID1).style.display = 'none';
            document.getElementById(varimg).src="Images/collapse.jpg";
         }
        else
        {
            //document.getElementById(newID).style.display = 'block';
            document.getElementById(newID1).style.display = 'block';
             document.getElementById(varimg).src="images/expand.jpg";
        }

    }      
         
 function fValidation_On_Submit()
      { 
//            var varBrowername=GetBrowser();
//             if(varBrowername!="msie")
//             {
//               if(varBrowername!="firefox" )
//                { 
//                   alert('Use Internet Explorer 8.0 or Mozilla 3.6 only')
//                   return false;   
//                }         
//             }
//             if(varBrowername!="firefox")
//             {
//               if(varBrowername!="msie" )
//               { 
//                    alert('Use Internet Explorer 8.0 or Mozilla 3.6 only')
//                    return false;   
//               }         
//             }  
             
             
         if (document.getElementById('chkCheked').checked ==false)
       
       {
            alert('Please Select I Agree Before Proceed !!!');
            document.getElementById('chkCheked').focus();
            return false;
       }
      }
  </script>
</head>
<body style="background-image:url(Images/backgroundImg.jpg); background-repeat :repeat ; background-position: center center; background-attachment: scroll; text-align:center;padding:0px 0px 0px 0px;margin-top:0px;margin-bottom:0px;margin-right:0px;margin-left:0px;" >
    <form id="form1" runat="server" >
 <div id="header" align="center"  >
<table cellpadding="0" cellspacing="0" width="865px"  Height="100px" 
        class="divCircle">
<tr style="width:100%; height:100px;">
  <td style="text-align: left; vertical-align:top; "   valign="top" width="85%">

 <iframe id="I1" name="I1" frameborder="0"  scrolling="no"   src="AnimateHead2.aspx" 
          width="100%" height="110px"></iframe>
   
</td>
</tr>
</table>
</div>
       <div align ="center" id="information"  width="865px">
   <table  class="divCircle" width="865px">
    <tr >
                <td align="center" style="font-size:11pt;color:Black;font-family:Arial; height: 440px; text-align:left" valign="top" >
                   <table>
                       
                       <tr id="trSchoolHead">
                           <td align="right" colspan="2">
                                 
                                    <table style="width:100%">
                                        <%--BANNER--%>         
                                         <tr>
                                            <td style="width:100px; height: 105px;">
                                                <asp:Image ID="OSchoolImage" runat="server" Width="100px" Height="100px" />
                                             </td>
                                            <td style="vertical-align:middle; text-align:center; height: 105px;" colspan="">
                                                <div style="font-family: Times New Roman;font-size:28px;width:100%;font-weight:bold;"><%=SchoolName %></div>
                                                <div style="font-family: Times New Roman; font-size:16px; width: 100%;"><%=Address1%></div>
                                                <div style="font-family: Times New Roman; font-size: 14px; width: 100%;"><%=Address2%></div>
                             
                                              </td>
                                          </tr>
                                     </table>
                               </td>
                       </tr>
                       <tr id="trSchoolHead1" style="font-family: Arial">
                           <td ____________________________________________________________________________________________________
                           
                        </td>
                              </tr>
        <tr id="trlnk" style="font-family: Arial">
            <td align="left" valign="top">
                <asp:Label ID="Label2" runat="server"  ForeColor="#C00000" Text="Turn off Pop-up Blocker of your Browser." Font-Names="Arial" Font-Size="11pt"></asp:Label><br />
                <br />
                <asp:Label ID="Label3" runat="server"  ForeColor="#C00000" Text="For Internet Explorer : - Go to Tools> Pop-up Blocker >Click on Turn Off Pop-up Blocker" Font-Names="Arial" Font-Size="10pt"></asp:Label><br />
                <br />
                <asp:Label ID="Label4" runat="server"  ForeColor="#C00000" Text='Mozilla 3.6 :  - Go to Tools>Options>Content>Uncheck the " Block pop-up windows  " >Click on OK'
                    Width="639px" Font-Names="Arial" Font-Size="10pt"></asp:Label><br />
                <br />
                <asp:Label ID="Label1" runat="server" ForeColor="#C00000" Text="Before you register online please read all instructions carefully and click on the Proceed Link given at Bottom." Font-Names="Arial" Font-Size="11pt" Width="650px"></asp:Label></td>
            <td align="right" valign="top">
        <asp:LinkButton id="lnkExists" runat="server" style="text-decoration:none;" Width="150px" OnClick="lnkExists_Click" Font-Size="11pt" Font-Names="Arial" >[Already Registered]</asp:LinkButton>
         <%--<asp:ImageButton ID="imgPrint" runat="server" Height="30px" ImageUrl="~/Images/print2.gif"  Width="51px" OnClientClick="javascript:return pPrint();"/>--%>
          |                          
          <asp:LinkButton id="lnkPrint"   Text="`"  runat="server" Width="40px"  style="font-size:15px; text-decoration:none; padding-left:1px;" OnClientClick="javascript:return pPrint();"  >[Print]</asp:LinkButton>
        </td>
        <%--<td></td>--%>
       
        </tr>
        </table>
               <asp:Panel ID="colPnl1" runat="server" Width="100%" >                  
                   <p><font color="black" face="Arial" size="2">You must have the following documents with
                           you at the time of registering online, as these need to be uploaded with the registration
                           form:</font>
                   </p>
                    <font face="Arial" size="2" color="Black">
                        <ol>
                      <li> Photograph of the child (In Jpeg, Jpg format) not more than
                          3 months old.</li><br /><li> A Valid&nbsp; personal e-mail Id for communication.</li><br />
                            <li>The system will automatically generate your Username/Password when you complete and upload your registration form adequately. </li>
                        </ol>
                    </font>
                    <p>
                    </p>
                   <p>
                       <b><font color="black" face="Arial" size="2">
  IMPORTANT INFORMATION REGARDING ADMISSION</font></b></p>
<ol>
  <li><font face="Arial" size="2" color="Black">The Original Date of Birth Certificate issued by the Municipal Corporation or  Registrar of Deaths and Births, ) along with a Photostat copy of the same must be submitted at the time of verification of the forms. The original certificate will be returned to the parents immediately after the verification.&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
          &nbsp; &nbsp; &nbsp;</font><font color="black" face="Arial" size="2"><strong><br />
              (A photo copy attested by the Notary will not be accepted)</strong></font>.<br /></li>
    <br /><li><font color="black" face="Arial" size="2">You are required to submit a Photostat copy of any one of the following documents at the time of verification of the forms, as proof of the residence.<br />(a) Passport<br />(b) Rent agreement<br />
       (c) Voter I Card.<br />(d) Telephone Bill.<br /> <br />The original document will be returned to the parents immediately after the verification:&nbsp;</font><br />&nbsp;</li><li><font face="Arial" size="2" color="Black">Fill in the particulars of the child (i.e. name, parents’ names, and date of birth) correctly. The date of birth filled in the form must tally with the one recorded  
       in the Date of Birth certificate.  No change whatsoever will be made after the admission.  </font><br />&nbsp;</li><li><font face="Arial" size="2" color="Black"><b> </b>The Management of the school reserves all 
       rights of admission or rejection and is not bound to give reasons for admission or rejection of any particular candidate. (The selection procedure is designed by a Committee and the selection of the candidate is done by the Management.).</font></li><br /><li>
                        <font color="black" face="Arial" size="2">Incomplete registration forms  or those with incorrect information will  automatically stand rejected. </font><br /></li><br />
                          <li>The <span style="font-size: 10pt">School does not accept any donation for admissions. Parents should beware  of third parties making false claims of procuring admission and collecting money on behalf of the School. 
                          If they enter into any transaction with such parties, they will be doing so at their own risk and the school shall not be responsible for it. The School will appreciate to know if there is any such person or persons so that proper legal action can be taken against them.</span><br/>
  </li><br /><li>
  <span style="font-size: 10pt">No telephonic enquiry about admissions will be entertained.</span><br/>
  </li><br /><li>
      <font color="black" face="Arial" size="2">If your registration form is successfully uploaded the  computerized system 
      will generate an Acknowledgement  Receipt with a reference number which you must use in all further correspondence.  The Acknowledgement Receipt will also generate an USERID and a PASSWORD. ( Please make sure Pop - up
          Blocker is Turn Off, to get the Acknowledgement Receipt ).</font>
          <br/>
      <br/>
       <li><font color="black" face="Arial" size="2">The candidates whose names do not appear in this short list, will regretfully not be part of the next level of the 
       admission process and their parents would be advised to look for admission elsewhere.</font><br/>
      
      </li>
           <br/>
      <br/>
       <li><font color="black" face="Arial" size="2">It is mandatory to carry a hard - copy of online form in school for completion of Registration Process.</font><br/>
      
      </li>
      </ol>
             <p>
                      <font face="Arial" size="2" color="Black"><b>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                          &nbsp;</b></asp:Panel>
      
        <table id="tbagree" style="font-family: Arial; width:100%">
        <tr style="height:5px;">
        <%--<td class="MyHeadLabel" style="height: 10px">
        </td>
         <td style=" width: 102px;">
         </td>
                 
                  <td style="text-align: left; width: 465px; " align="right">
                      </td>--%>
             <td align="right" style="width:80%;" valign="top">
             <asp:CheckBox ID="chkCheked" runat="server" TabIndex="83" ForeColor="Blue" Font-Names="Arial" Font-Size="11pt" />&nbsp;
             </td>
            
            <td align="left" style="width: 63px; color: blue;" valign="top">
            I Agree &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
            </td>
            
            <td align="left" valign="top">
                  <asp:LinkButton ID="lnkSubmit" runat="server" style="text-decoration:none;" OnClientClick="return fValidation_On_Submit()"
                     OnClick="lnkSubmit_Click" Font-Size="11pt" Font-Names="Arial" >[Proceed]</asp:LinkButton>
            </td>
        </tr>
        </table>
          </td>
            </tr>
        </table>
        </div>
  
    </form>
</body>
</html>
