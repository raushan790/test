<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About Us</title>
    <!--
    <link href="CSS/MyStyle.css" rel=Stylesheet type="text/css" />
    <script language="javascript" src="Script/jsValidation.js" type="text/javascript"></script>
    -->
    <script language="javascript" type="text/javascript">
        addLoadEvent(pEnableDisable);
        function addLoadEvent(func) {
            var oldonload = window.onload;
            if (typeof window.onload != 'function') {
                window.onload = func;
            }
            else {
                window.onload = function () {
                    if (oldonload) {
                        oldonload();
                    }
                    func();
                }
            }
        }
        function pEnableDisable() {
            //var offset=(navigator.userAgent.indexOf("Mac")!=-1 || navigator.userAgent.indexOf("Gecko")!=-1 || navigator.userAgent.indexOf("Netscape")!=-1)?0:4;

            window.resizeTo(Number(window.screen.availWidth * 2 / 3), Number(window.screen.availHeight * 2 / 3));
            self.moveTo(Number(window.screen.availWidth / 6), Number(window.screen.availHeight / 6));

            return false;

        }

    </script>
</head>
<body bgcolor="#FFFFFF">
    <form id="form1" runat="server">
    <div align="center">
        <table style="width: 100%">
            <tr style="width: 100%">
                <td align="center" colspan="2">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/EntabLogo.gif" />
                </td>
            </tr>
            <tr>
            <td align="center" colspan="2"  
                    
                    style="font-style:italic;font-family: Arial; font-size: 12px; color: #800000;">Version 14.0</td>
            </tr>
                        <tr>
            <td align="center" colspan="2"  
                    style="font-style:italic;font-family: Arial; font-size: 11px;"></td>
            </tr>
            <tr style="width: 100%" align="center">
                <td align="left" style="font-size: 11pt; color: White; font-family: Arial;">
                    <asp:Panel ID="pnlText" runat="server" Width="100%">
                        <ol>
                            <li><font face="Arial" size="2" color="Blue">Entab – InnoSoft® : The administration
                                simplified the electronic way. </font></li>
                            <li></li>
                            <li><font face="Arial" size="2" color="Blue">Entab Infotech Pvt Ltd, is an Information
                                Technology company specialized in providing integrated software solutions /ERP to
                                Schools, Colleges. “<strong>InnoSoft®</strong>” is the flagship application software
                                that is automating and sophisticating the administration, academic, finance and
                                communication to home. With a clientele of more than 1000 successful institutions
                                spread across 26 states in India and 06 countries in Middle East, Africa etc. </font>
                            </li>
                            <li></li>
                            <li><font face="Arial" size="2" color="Blue">The CampusCare is evolved out of many years
                                (since 2000) of continues development based on the association with schools. It
                                reflects the knowledge and experience that we have accumulated since 2000 in this
                                domain and today we are delivering the best campus management software /ERP available
                                in the country with more than 95% success rate. </font></li>
                            <li></li>
                            <li><font face="Arial" size="2" color="Blue"><strong>Salient features of CampusCare</strong>-
                                The powerful, integrated and easy to use tool for any educational institutions.
                            </font></li>
                            <li></li>
                            <li><font face="Arial" size="2" color="Blue">1. Entab – CampusCare serving the schools
                                since 2000. </font></li>
                            <li><font face="Arial" size="2" color="Blue">2. Highest rate of retention : Clients
                                and technical hands. </font></li>
                            <li><font face="Arial" size="2" color="Blue">3. There is no successful replacement of
                                CampusCare software in the country. </font></li>
                            <li><font face="Arial" size="2" color="Blue">4. Experienced software tech consultants
                                for guidance and implementation. </font></li>
                            <li><font face="Arial" size="2" color="Blue">5. Higher level of automation and sophistication
                                ensuring higher level of accountability. </font></li>
                            <li><font face="Arial" size="2" color="Blue">6. State of the art parental engagement
                                tool for communication to parents, students and staff. </font></li>
                            <li><font face="Arial" size="2" color="Blue">7. CampusCare improves the school productivity,
                                accountability, reputation and saves valuable time & money. </font></li>
                            <li><font face="Arial" size="2" color="Blue">8. Seamlessly integrated with all modules
                                and payment gateway for fee collection. </font></li>
                            <li><font face="Arial" size="2" color="Blue">9. Providing technical consultancy and
                                software solution for examination projects of educational boards in the country and abroad. </font></li>
                            <li><font face="Arial" size="2" color="Blue">10. Ensures limited customization to assure
                                your schools functionality is achieved and successful. </font></li>
                            <li><font face="Arial" size="2" color="Blue">11. Efficient and effective online services
                                and support on all days, except Sundays (Mondays to Saturdays). </font></li>
                            <li><font face="Arial" size="2" color="Blue">12. ‘Pay as you grow’ or ‘Pay as you go’
                                are the model of our business giving no major upfront charges. </font></li>
                        </ol>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 93px">
                    <strong><em><span style="font-size: 8pt; color: #3399ff; font-family: Verdana">CopyRight
                        © 2011 Entab Infotech Pvt. Ltd.,
                        <br />
                        B-214, Okhla Industrial Area Phase-1,<br />
                        NewDelhi-110020.<br />
                        Phone : +91-11-43193333(100 Lines)<br />
                        Fax : +91-11-43193340<br />
                        Email id : support@entab.in<br />
                        Visit us : www.entab.in </span></em></strong>
                </td>
                <%-- <td  align="center" style="height: 93px">
                        <strong><em><span style="font-size: 8pt; color: #3399ff; font-family: Verdana">Marketed
                            By : <strong>BAPNA</strong>  TECH&nbsp; Pvt. Ltd.,
                            <br />
                            A-7, Green Avenue Street, behind
                            Sector-D, 
                            <br />
                            Pocket-3
                            Vasant Kunj, New Delhi-110070<br />
                            Phone : +91-11-26892706<br />
                            Fax : +91-11-26892705<br />
                            Email id : Sales@bapnatech.com
                            </span></em></strong>
                            </td>--%>
            </tr>
            <%-- <tr>
                <td align="center" style="font-size:11pt;color:White;font-family:Arial;" colspan="2">
                    Marketted By : <strong>BAPAN</strong>  TECH</td>
            </tr>--%>
            <tr style="width: 100%">
                <td align="center" colspan="2">
                    <asp:LinkButton ID="lnkExpand" runat="server" Width="100%" OnClientClick="javascript:return false;"
                        Font-Bold="True" Font-Names="Arial" Font-Size="10pt" Font-Underline="False" ForeColor="Olive">
                        <table cellpadding="0" cellspacing="0" width="100%" onmouseover="javascript:this.style.cursor='hand'"
                            onmouseout="javascript:this.style.cursor='default'">
                            <tr>
                                <td width="50%" style="font-size:12px;" align="left">
                                    BINARY&nbsp;CODE&nbsp;LICENSE&nbsp;AGREEMENT
                                </td>
                                <td width="40%" align="left">
                                    <asp:Label ID="lblcolHeader" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt"
                                        ForeColor="Black"></asp:Label>
                                </td>
                                <td width="10%" align="right">
                                    <asp:Image ID="imgExpand" runat="server" Height="15px" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </asp:LinkButton>
                </td>
            </tr>
            <tr style="width: 100%">
                <td align="left" style="font-size: 11pt; color: White; font-family: Arial;" colspan="2">
                    <asp:Panel ID="colPnl1" runat="server" Width="100%">
                        <p>
                            <b><font face="Arial" size="2" color="Blue">BY INSTALLING CAMPUSCARE YOU HAVE AGREED
                                TO THE TERMS OF THIS AGREEMENT.</font></b></p>
                        <ol>
                            <li><font face="Arial" size="2" color="Blue">License to Use. Entab grants to you a non-exclusive
                                and non-transferable license for the internal use only of the accompanying software
                                and documentation and any error corrections provided by Entab (collectively &quot;Software&quot;).
                                You have no right to distribute the Software any one including your sister concern
                                or branches inside or outside the country. </font></li>
                            <li><font face="Arial" size="2" color="Blue">Restrictions. Software is confidential
                                and copyrighted. Title to Software and all associated intellectual property rights
                                is retained by Entab and/or its licensors. You may make copies of Software only
                                for your internal use provided that you reproduce all notices in and on Software,
                                including this Agreement. Unless enforcement is prohibited by applicable law, you
                                may not modify, decompile, disassemble, or otherwise reverse engineer Software.
                                You acknowledge that the Software is not designed or intended for use in on-line
                                control of aircraft, air traffic, aircraft navigation or aircraft communications;
                                or in the design, construction, operation or maintenance of any nuclear facility.
                                Entab disclaims any express or implied warranty of fitness for such uses. No right,
                                title or interest in or to any trademark, service mark, logo, or trade name of Entab
                                or its licensors is granted under this Agreement. </font></li>
                            <li><font face="Arial" size="2" color="Blue">Limited Warranty. Entab warrants to you
                                that for a period of ninety (90) days from the date of purchase (If otherwise not
                                specified), as evidenced by a copy of the receipt, the media on which Software is
                                furnished (if any) will be free of defects in materials and workmanship under normal
                                use. Except for the foregoing, Software is provided &quot;AS IS&quot;. Your exclusive
                                remedy and Entab's entire liability under this limited warranty will be at Entab's
                                option to replace the Software media or refund the fee paid for the Software. Customisation
                                and visits if any and done that part will be deducted while refund. </font></li>
                            <li><font face="Arial" size="2" color="Blue">Disclaimer of Warranty. UNLESS SPECIFIED
                                IN THIS AGREEMENT, ALL EXPRESS OR IMPLIED CONDITIONS, REPRESENTATIONS AND WARRANTIES,
                                INCLUDING ANY IMPLIED WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE,
                                OR NON-INFRINGEMENT, ARE DISCLAIMED, EXCEPT TO THE EXTENT THAT THESE DISCLAIMERS
                                ARE HELD TO BE LEGALLY INVALID.Customisation and visits if any and done that part
                                will be deducted while refund. </font></li>
                            <li><font face="Arial" size="2" color="Blue">Limitation of Liability. TO THE EXTENT
                                NOT PROHIBITED BY APPLICABLE LAW, IN NO EVENT WILL ENTAB OR ITS LICENSORS BE LIABLE
                                FOR ANY LOST REVENUE, PROFIT OR DATA, OR FOR SPECIAL, INDIRECT, CONSEQUENTIAL, INCIDENTAL
                                OR PUNITIVE DAMAGES, HOWEVER CAUSED AND REGARDLESS OF THE THEORY OF LIABILITY, ARISING
                                OUT OF OR RELATED TO THE USE OF OR INABILITY TO USE SOFTWARE, EVEN IF ENTAB HAS
                                BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. In no event will Entab's liability
                                to you, whether in contract, tort (including negligence), or otherwise, exceed the
                                amount paid by you for Software under this Agreement. The foregoing limitations
                                will apply even if the above stated warranty fails of its essential purpose. Customisation
                                and visits if any, and done that part will be deducted while refund. </font>
                            </li>
                            <li><font face="Arial" size="2" color="Blue">Termination. This Agreement is effective
                                until terminated. You may terminate this Agreement at any time by destroying all
                                copies of Software. This Agreement will terminate immediately without notice from
                                Entab if you fail to comply with any provision of this Agreement. Upon termination,
                                you must destroy all copies of Software, further use in any form is also banned.
                            </font></li>
                            <li><font face="Arial" size="2" color="Blue">Export Regulations. All Software and technical
                                data delivered under this Agreement are subject to Indian export control laws and
                                may be subject to export or import regulations in other countries. You agree to
                                comply strictly with all such laws and regulations and acknowledge that you have
                                the responsibility to obtain such licenses to export, re-export, or import as may
                                be required after delivery to you. </font></li>
                            <li><font face="Arial" size="2" color="Blue">Governing Law. Any action related to this
                                Agreement will be governed by Indian law . No choice of law rules of any jurisdiction
                                will apply. All disputes subject to New Delhi jurisdiction only. </font></li>
                            <li><font face="Arial" size="2" color="Blue">Severability. If any provision of this
                                Agreement is held to be unenforceable, this Agreement will remain in effect with
                                the provision omitted, unless omission of the provision would frustrate the intent
                                of the parties, in which case this Agreement will immediately terminate. </font>
                            </li>
                            <li><font face="Arial" size="2" color="Blue">Integration. This Agreement is the entire
                                agreement between you and Entab relating to its subject matter. It supersedes all
                                prior or contemporaneous oral or written communications, proposals, representations
                                and warranties and prevails over any conflicting or additional terms of any quote,
                                order, acknowledgment, or other communication between the parties relating to its
                                subject matter during the term of this Agreement. No modification of this Agreement
                                will be binding, unless in writing and signed by an authorized representative of
                                each party. </font></li>
                        </ol>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="colPnl1"
        CollapsedSize="0" Collapsed="True" AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
        ExpandedText="Hide Details" ExpandControlID="lnkExpand" CollapseControlID="lnkExpand"
        ExpandedImage="~/Images/collapse.jpg" CollapsedImage="~/Images/expand.jpg" TextLabelID="lblcolHeader"
        ImageControlID="imgExpand">
    </cc1:CollapsiblePanelExtender>
    </form>
</body>
</html>
