<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisitorsPass.aspx.cs" Inherits="VisitorForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<base target="_self" />
    <title>Visitor Pass</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript" ></script>  
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>  
    <script language="javascript" type="text/javascript">  
        addLoadEvent(pEnableDisable);
        function pEnableDisable()
        {
            var offset=(navigator.userAgent.indexOf("Mac")!=-1 || navigator.userAgent.indexOf("Gecko")!=-1 || navigator.userAgent.indexOf("Netscape")!=-1)?0:4;
            window.moveTo(-offset,-offset);
           
            window.resizeTo(screen.availWidth+(2*offset),screen.availHeight+(2*offset));

            pPrint();
            return false;  
        }

        function pPrint()
        {   
            document.getElementById('printBtnDiv').style.display='none';
            window.print();
            document.getElementById('printBtnDiv').style.display='';
            return false;
        }


    </script>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div style="width:550px;">
        <table style="width:100%; text-align:left;" >
            <tr>
                <%--OFFICE COPY--%>
                <td style="vertical-align:top;">
                    <table cellpadding="0px" cellspacing="0px" id="officeCopy" style="width:100%; border:ridge 1px black;">   
                        <tr>
                            <td style="width: 544px">
                                <div>
                                    <table style="width:100%">
                                        <%--BANNER--%>         
                                         <tr>
                                            <td style="width:100px;">
                                                <asp:Image ID="OSchoolImage" runat="server" Width="96px" Height="75px" />
                                             </td>
                                            <td style="vertical-align:middle; text-align:center;">
                                                <div style="font-family:Arial;font-size:larger;width:100%;"><%=SchoolName %></div>
                                                <div style="font-family: Arial; font-size:small; width: 100%;"><%=Address1%></div>
                                                  <div style="font-family: Arial; font-size:x-small; width: 100%;"><%=Email%></div> 
                                                <div style="font-family: Arial; font-size:x-small; width: 100%;"><%=Phone %></div> 
                                              </td>
                                          </tr>
                                     </table>
                                 </div>
                             </td>
                         </tr>
                          
                        <tr>
                            <td style="width: 544px">
                                <div style="border-top:ridge thin black; border-bottom:ridge thin black;">
                                    <table style="width:100%;" cellpadding="0px" cellspacing="0px">
                                         <%--Visitor's CAPTIOM--%>
                                         <tr>
                                            <td colspan="2" style="text-align:center; height:20px;"> 
                                                <asp:Label ID="Label17" runat="server" CssClass="MyLabel" Font-Bold="True" Text="VISITOR'S PASS"></asp:Label> 
                                             </td>
                                          </tr>              
                                     </table>
                                 </div>
                             </td>
                         </tr>
                         
                           
                        <tr>
                            <td style="height: 175px; width: 544px;">
                                <div style="width: 100%">
                                    <table cellpadding="0px" cellspacing="0px" style="width:100%;">
                                         <%--Visitor's INFO--%>                                     
                                          <tr style="vertical-align:top;height:24px">
                                            <td colspan="2" style="height: 137px">
                                                <table style="width:100%" id="TABLE1" onclick="return TABLE1_onclick()">
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td align="left">
                                                            <asp:Label ID="Label8" runat="server" CssClass="MyLabel" Text="Visit Time/Date"></asp:Label></td>
                                                        <td style="width: 151px; height: 24px">
                                                            <asp:Label ID="OvInDateTime" runat="server" CssClass="MyLabel" Width="190px"></asp:Label></td>
                                                        <td class="MyLabel" style="width: 128px">
                                                            <asp:Label ID="Label10" runat="server" CssClass="MyLabel" Text="Visitor No. " Width="130px"></asp:Label></td>
                                                        <td style="width: 80px">
                                                            <asp:Label ID="OVisitorNo" runat="server" CssClass="MyLabel" Width="80px"></asp:Label></td>
                                                    </tr>
                                                    <tr style="vertical-align:top;height:24px">
                                                        <td class="MyLabel" style="height: 18px">
                                                            <asp:Label ID="LblVName" CssClass="MyLabel" runat="server" Text="Visitor's Name"></asp:Label>&nbsp;
                                                         </td>
                                                        <td style="width:151px; height:24px">
                                                            <asp:Label ID="OVName" runat="server" CssClass="MyLabel" Width="190px"></asp:Label>
                                                         </td>
                                                       <td class="MyLabel" style="width: 128px">
                                                            <asp:Label ID="Label3" runat="server" CssClass="MyLabel" Text="Visitor's I-Card No. If any" Width="130px"></asp:Label>
                                                         </td>
                                                        <td style="width:80px;">
                                                            <asp:Label ID="OVIcard" runat="server" CssClass="MyLabel" Width="80px"></asp:Label>
                                                         </td>
                                                     </tr>
                                                    
                                                    <tr style="vertical-align:top; height:24px">
                                                        <td class="MyLabel" style="height: 18px">
                                                            <asp:Label ID="Label5" CssClass="MyLabel" runat="server" Text="Visitor's Address"></asp:Label>
                                                         </td>
                                                        <td style="width: 151px; height: 18px;">
                                                            <asp:Label ID="OVaddresss" runat="server" CssClass="MyLabel" Width="190px"></asp:Label>
                                                         </td>
                                                        <td class="MyLabel" style="width: 128px; height: 18px;">
                                                           
                                                            <asp:Label ID="Label9" CssClass="MyLabel" runat="server" Text="Visitor's Contact No. "></asp:Label>
                                                            
                                                         </td>
                                                        <td style="height: 18px">
                                                         
                                                      <asp:Label ID="OVContactNo" runat="server" CssClass="MyLabel" Width="80px"></asp:Label>
                                                         </td>
                                                     </tr>    
                                                    
                                                    
                                                    <tr style="vertical-align:top; height:24px">
                                                         <td class="MyLabel">
                                                            
                                                            <asp:Label ID="Label7" runat="server" CssClass="MyLabel" Text="Officer's name to visit" Width="117px" Height="13px"></asp:Label>
                                                         </td>
                                                        <td style="width: 151px">
                                                          
                                                             <asp:Label ID="ONameOff" runat="server" CssClass="MyLabel" Width="190px"></asp:Label>
                                                         </td>
                                                       <td class="MyLabel" style="width: 128px">
                                                           &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                     </tr>    
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td class="MyLabel">
                                                            <asp:Label ID="Label12" runat="server" CssClass="MyLabel" Text="Purpose of Visit"></asp:Label></td>
                                                        <td style="width: 151px" colspan="3">
                                                            <div style="font-family: Arial; font-size:x-small; width: 100%;"><%=VisitPurpose %></div> 
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr style="vertical-align:top; height:24px">
                                                        <td colspan="4" rowspan="3">
                                                        </td>
                                                     </tr>
                                                    <tr style="vertical-align: top; height: 24px">
                                                    </tr>
                                                    <tr style="vertical-align: top; height: 24px">
                                                    </tr>
                                                    <tr style="vertical-align: top; height: 24px;  ">
                                                        <td colspan="4">
                                                            <table style="width:100%">
                                                                <tr>
                                                                    <td class="MyLabel" style="height: 24px; text-align: left; " valign="bottom">
                                                                     <asp:Label ID="Label1" runat="server" CssClass="MyLabel" Text="Signature of Visitor" Width="102px"></asp:Label>
                                                                    </td>
                                                                    <td style="height: 24px; text-align:center;"  valign="bottom">
                                                                        <asp:Label ID="Label2" runat="server" CssClass="MyLabel" Text="Signature of Issuing Authority "></asp:Label></td>
                                                                    <td style="height: 24px; text-align:right;" valign="bottom" >
                                                                        <asp:Label ID="Label4" runat="server" CssClass="MyLabel" Text="Signature of Officer Visited"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        
                                                    </tr>
                                                    
                                                 </table>
                                             </td>
                                          </tr>
                         
                                     </table>
                                 </div>
                             </td>
                         </tr>
                         
                       
                     </table>
                      <div style="text-align:center; width:100%;height: 23px;">
                      <table cellpadding="0px" cellspacing="0px" id="Table2" style="width:100%; border:ridge 1px black;">   
                        <tr>
                            <td valign="bottom" style="height: 24px; text-align:center;">
                                <asp:Label ID="Label6" runat="server" CssClass="MyLabel" Text="This pass should be handed over to the reception without fail while leaving the premises"
                                    Width="535px"></asp:Label></td>
                         </tr>
                         </table>
                     </div>
                </td>               
                
             </tr>
         </table>
    </div>
    
    <div id="printBtnDiv" style="width:550px;; text-align:center; vertical-align:bottom; height:20px;display:none;">
        <asp:Button ID="Button1" runat="server" OnClientClick="javascript:return pPrint();" Text="Click Here To Print" />
     </div>
    
    </form>
    </center>
</body>
</html>
