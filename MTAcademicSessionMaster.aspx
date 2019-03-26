<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MTAcademicSessionMaster.aspx.cs"
    Inherits="MTAcademicSessionMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: CampusCare Online :: - Academic Session</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">


        jQuery(function ($) {
            $("#txtSessionStart").mask("99/99/9999");
            $("#txtSessionEnd").mask("99/99/9999");
        });


        addLoadEvent(fEnableDisable);
        function fEnableDisable() {
            var strArray = document.getElementById('hidFlag').value.split('^');
            if (strArray[0] == "") {
                document.getElementById('txtAcaSession1').readOnly = true;
                document.getElementById('txtSessionStart').readOnly = true;
                document.getElementById('txtSessionEnd').readOnly = true;
                document.getElementById('ImgCalPopUp').disabled = true;
                document.getElementById('ImgCalPopUp2').disabled = true;
                document.getElementById('btnNew').disabled = false;
                document.getElementById('btnEdit').disabled = true;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnDelete').disabled = true;
            }
            if (strArray[0] == "N") {
                document.getElementById('btnNew').disabled = true;
                document.getElementById('btnEdit').disabled = true;
                document.getElementById('btnSave').disabled = false;
                document.getElementById('btnDelete').disabled = true;
            }
            if (strArray[0] == "E") {
                document.getElementById('txtAcaSession1').readOnly = true;
                document.getElementById('btnNew').disabled = true;
                document.getElementById('btnEdit').disabled = true;
                document.getElementById('btnSave').disabled = false;
                document.getElementById('btnDelete').disabled = true;
            }
            fChangeButtonColor('frmMTAcademicSessionMaster', '#400000');
        }
        function pFocus(fld) {
            fld.className = 'FocusText';
        }
        function pBlur(fld) {
            fld.className = 'MyText';
        }
        function UserLimit(Val) {
            if (Val == "N") {
                var strNew = document.getElementById('hidCache').value.split(';')[0];
                if (strNew != "Y") {
                    pDisplayMessageclient('<%=Session["Type"].ToString() %>', "1", "");
                    return false;
                }
            }
            else if (Val == "E") {
                var strEdit = document.getElementById('hidCache').value.split(';')[1];
                if (strEdit != "Y") {
                    pDisplayMessageclient('<%=Session["Type"].ToString() %>', "2", "");
                    return false;
                }
            }
            else if (Val == "D") {
                var strDelete = document.getElementById('hidCache').value.split(';')[2];
                if (strDelete != "Y") {
                    pDisplayMessageclient('<%=Session["Type"].ToString() %>', "3", "");
                    return false;
                }
            }
        }

        function fNewEnable() {
            if (UserLimit('N') == false) {
                return false;
            }

            document.getElementById('txtAcaSession1').readOnly = false;
            document.getElementById('txtSessionStart').readOnly = false;
            document.getElementById('txtSessionEnd').readOnly = false;
            document.getElementById('ImgCalPopUp').disabled = false;
            document.getElementById('ImgCalPopUp2').disabled = false;
            document.getElementById('txtAcaSession1').value = "";
            document.getElementById('txtAcaSession2').value = "";
            document.getElementById('txtSessionStart').value = "";
            document.getElementById('txtSessionEnd').value = "";
            document.getElementById('txtAcaSession1').focus();
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnEdit').disabled = true;
            document.getElementById('btnSave').disabled = false;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('hidFlag').value = "N^";
            fChangeButtonColor('frmMTAcademicSessionMaster', '#400000');
            return false;
        }
        function f_OnChangeAcademicSession() {

            if (stripBlanks(document.getElementById('txtAcaSession1').value) != "") {
                document.getElementById('txtAcaSession2').value = String(Number(document.getElementById('txtAcaSession1').value) + 1);
                return true;
            }
            else {
                document.getElementById('txtAcaSession2').value = "";
                return false;
            }
        }
        function fValidateSave() {
            var strArray = document.getElementById('hidFlag').value.split('^');
            if (document.getElementById('txtAcaSession1').value == "") {
                //        alert("Please Enter Academic Session");
                pDisplayMessageclient('<%=Session["Type"].ToString() %>', "7", "" + document.getElementById('lblAcademicSession1').innerHTML);
                document.getElementById("txtAcaSession1").focus();
                return false;
            }
            if (!validateDate(document.getElementById('txtSessionStart').value)) {
                //        alert('Please Enter The Valid Date[Date Format dd/MM/yyyy]');
                pDisplayMessageclient('<%=Session["Type"].ToString() %>', "14", "" + document.getElementById('lblSessionStart').innerHTML);
                document.getElementById('txtSessionStart').focus();
                return false;
            }
            if (!validateDate(document.getElementById('txtSessionEnd').value)) {
                //        alert('Please Enter The Valid Date[Date Format dd/MM/yyyy]');
                pDisplayMessageclient('<%=Session["Type"].ToString() %>', "14", "" + document.getElementById('lblSessionEnd').innerHTML);
                document.getElementById('txtSessionEnd').focus();
                return false;
            }
            if (CompareDate(document.getElementById('txtSessionStart').value, document.getElementById('txtSessionEnd').value) != 1) {
                //        alert('Session Start Date Should be lesser than Session End Date');
                pDisplayMessageclient('<%=Session["Type"].ToString() %>', "101_1", "");
                document.getElementById('txtSessionEnd').focus();
                return false;
            }

            if (Number(getDParts(document.getElementById('txtSessionStart').value, "year")) != Number(document.getElementById('txtAcaSession1').value)) {
                //        alert('Academic Session Not Matching With Session Start Date');
                pDisplayMessageclient('<%=Session["Type"].ToString() %>', "101_2", "");
                document.getElementById('txtSessionStart').focus();
                return false;
            }
            with (document.getElementById('gvAcademicSession').rows[Number(strArray[1]) + 1]) {
                var varShowFlag = "";
                var PayGatewayFlag = "";
                if (document.getElementById('chkShowParentLogin').checked == true) {
                    varShowFlag = "Y";
                }
                else {
                    varShowFlag = "N";
                }
                if (document.getElementById('chkPayGatewayFlag').checked == true) {
                    PayGatewayFlag = "Y";
                }
                else {
                    PayGatewayFlag = "N";
                }
                if (strArray[0] == "S" && document.getElementById('txtAcaSession1').value == cells[1].firstChild.nodeValue && document.getElementById('txtAcaSession2').value == cells[2].firstChild.nodeValue.substring(5, 9) && document.getElementById('txtSessionStart').value == cells[3].firstChild.nodeValue && document.getElementById('txtSessionEnd').value == cells[4].firstChild.nodeValue && varShowFlag == cells[5].firstChild.nodeValue && PayGatewayFlag == cells[6].firstChild.nodeValue) {
                    pDisplayMessageclient('<%=Session["Type"].ToString() %>', "4", "");
                    return false;
                }
            }
        }
        var curSelRow = null;
        var curSelRowIndex = -1;
        function Change_SelectedRow(varRowIndex) {
            var strArray = document.getElementById('hidFlag').value.split('^');
            if (varRowIndex > -1 && strArray[0] != "N" && strArray[0] != "E") {
                if (curSelRow != null) {
                    if (curSelRowIndex % 2 == 0)
                        curSelRow.style.cssText = "font-weight: normal; background: #fff;"
                    else
                        curSelRow.style.cssText = "font-weight: normal;"
                }
                document.getElementById("gvAcademicSession").rows[varRowIndex + 1].style.cssText = "color: green; font-weight: bold; cursor: pointer;  background: #ffc0cb;"
                curSelRow = document.getElementById("gvAcademicSession").rows[varRowIndex + 1];
                curSelRowIndex = varRowIndex;
                document.getElementById('txtAcaSession1').value = document.getElementById("gvAcademicSession").rows[varRowIndex + 1].cells[1].firstChild.nodeValue;
                document.getElementById('txtAcaSession2').value = String(Number(document.getElementById('txtAcaSession1').value) + 1);
                document.getElementById('txtSessionStart').value = document.getElementById("gvAcademicSession").rows[varRowIndex + 1].cells[3].firstChild.nodeValue;
                document.getElementById('txtSessionEnd').value = document.getElementById("gvAcademicSession").rows[varRowIndex + 1].cells[4].firstChild.nodeValue;
                var varShowFlag = GetInnerText(document.getElementById("gvAcademicSession").rows[varRowIndex + 1].cells[5]);
                if (varShowFlag == "Y") {
                    document.getElementById('chkShowParentLogin').checked = true;
                }
                else {
                    document.getElementById('chkShowParentLogin').checked = false;
                }
                if (GetInnerText(document.getElementById("gvAcademicSession").rows[varRowIndex + 1].cells[6])=="Y") {
                    document.getElementById('chkPayGatewayFlag').checked = true;
                }
                else {
                    document.getElementById('chkPayGatewayFlag').checked = false;
                }
                document.getElementById('hidFlag').value = "S^" + varRowIndex;
                document.getElementById('txtAcaSession1').readOnly = true;
                document.getElementById('txtSessionStart').readOnly = true;
                document.getElementById('txtSessionEnd').readOnly = true;
                document.getElementById('ImgCalPopUp').disabled = true;
                document.getElementById('ImgCalPopUp2').disabled = true;
                document.getElementById('btnNew').disabled = true;
                document.getElementById('btnEdit').disabled = false;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnDelete').disabled = false;
                fChangeButtonColor('frmMTAcademicSessionMaster', '#400000');
                return false;
            }
        }

        function fVerify_Edit() {
            if (UserLimit('E') == false) {
                return false;
            }
            var strArray = document.getElementById('hidFlag').value.split('^');
            document.getElementById('txtAcaSession1').readOnly = true;
            document.getElementById('txtSessionStart').readOnly = false;
            document.getElementById('txtSessionEnd').readOnly = false;
            document.getElementById('ImgCalPopUp').disabled = false;
            document.getElementById('ImgCalPopUp2').disabled = false;
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnEdit').disabled = true;
            document.getElementById('btnSave').disabled = false;
            document.getElementById('btnDelete').disabled = true;
            fChangeButtonColor('frmMTAcademicSessionMaster', '#400000');
            return false;
        }
        function fValidateDelete() {
            if (UserLimit('D') == false) {
                return false;
            }
            if (confirm(pDisplayMessageclient('<%=Session["Type"].ToString() %>', "5", ""))) {
                return true;
            }
            else {
                return false;
            }
        }

    </script>
</head>
<body dir="<%=strType %>" style="background-image: url(Images/backgroundImg.jpg);
    background-repeat: no-repeat; background-position: center center; background-attachment: scroll;">
    <form id="frmMTAcademicSessionMaster" runat="server" dir="<%=strType %>" onpaste="return false;">
    <div align="center">
        <table>
            <tr>
                <td class="divCircle">
                    <table class="MyTableBorder">
                        <tr>
                            <td class="MyTableHeader" colspan="4" align="center">
                                <asp:Label ID="lblAcademicSession" runat="server" Text="Academic Session" CssClass="MyLabelHeader"></asp:Label>&nbsp;
                            </td>
                            <td class="MyTableHeader" align="center">
                                <asp:Label ID="lblOptions" runat="server" Text="Options" CssClass="MyLabelHeader"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblAcademicSession1" runat="server" Text="Academic Session" CssClass="MyLabel"
                                    Width="103px"></asp:Label>
                            </td>
                            <td align="left" valign="top">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" style="width: 68px;">
                                            <asp:TextBox ID="txtAcaSession1" runat="server" CssClass="MyTextBox" Width="62px"
                                                MaxLength="4" TabIndex="1" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td align="center" style="width: 49px;">
                                            -
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAcaSession2" runat="server" CssClass="MyTextBox" Width="62px"
                                                MaxLength="4" TabIndex="2"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right" class="MyLabel" valign="top">
                            </td>
                            <td align="left" valign="top">
                            </td>
                            <td align="center" rowspan="6" valign="top">
                                <table cellpadding="1" cellspacing="1">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnNew" runat="server" CssClass="MyButton" Text="New" OnClientClick="return fNewEnable()"
                                                TabIndex="7" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnEdit" runat="server" CssClass="MyButton" Text="Edit" OnClientClick="return fVerify_Edit()"
                                                TabIndex="8" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" CssClass="MyButton" Text="Save" OnClientClick="return fValidateSave()"
                                                OnClick="btnSave_Click" TabIndex="9" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnDelete" runat="server" CssClass="MyButton" Text="Delete" OnClientClick="return fValidateDelete()"
                                                OnClick="btnDelete_Click" TabIndex="10" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" CssClass="MyButton" Text="Cancel" OnClick="btnCancel_Click"
                                                TabIndex="11" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnExport" runat="server" CssClass="MyButton" Text="Export" TabIndex="12"
                                                OnClick="btnPrintgrid_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnClose" runat="server" CssClass="MyButton" Text="Close" OnClick="btnClose_Click"
                                                TabIndex="13" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                                <asp:Label ID="lblSessionStart" runat="server" Text="Session Start" CssClass="MyLabel"
                                    Width="103px"></asp:Label>
                            </td>
                            <td align="left" valign="top">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="vertical-align: top;">
                                            <asp:TextBox ID="txtSessionStart" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                                MaxLength="10" Width="62px" TabIndex="3"></asp:TextBox>
                                        </td>
                                        <td style="vertical-align: top;">
                                            <asp:ImageButton ID="ImgCalPopUp" runat="server" CssClass="CalendarImage" ImageUrl="~/Images/calendar1.jpg"
                                                OnClientClick="javascript:return false;" TabIndex="4" />
                                        </td>
                                        <td align="right" class="MyLabel" valign="top">
                                            <asp:Label ID="lblSessionEnd" runat="server" Text="End" CssClass="MyLabel" Width="30px"></asp:Label>&nbsp;
                                        </td>
                                        <td align="left" valign="top">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="vertical-align: top;">
                                                        <asp:TextBox ID="txtSessionEnd" runat="server" BorderWidth="1px" CssClass="MyTextBox"
                                                            MaxLength="10" Width="62px" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ImgCalPopUp2" runat="server" CssClass="CalendarImage" ImageUrl="~/Images/calendar1.jpg"
                                                            OnClientClick="javascript:return false;" TabIndex="6" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <%--<td align="right" class="MyLabel" valign="top">
            <asp:Label ID="lblSessionEnd" runat="server" Text="End" CssClass="MyLabel" Width="90px"></asp:Label>&nbsp;</td>
        <td align="left" valign="top">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td >
                        <asp:TextBox ID="txtSessionEnd" runat="server" BorderWidth="1px" CssClass="MyText"
                            MaxLength="10" Width="62px" TabIndex="5"></asp:TextBox></td>
                    <td >
                        <asp:ImageButton ID="ImgCalPopUp2" runat="server" CssClass="CalendarImage" ImageUrl="~/Images/calendar1.jpg"
                            OnClientClick="javascript:return false;" TabIndex="6" /></td>
                </tr>
            </table>
        </td>--%>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                            </td>
                            <td align="left" valign="top">
                                <asp:CheckBox ID="chkShowParentLogin" runat="server" Text="Show In Parent Login" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="MyLabel" valign="top">
                            </td>
                            <td align="left" valign="top" colspan="3">
                                <asp:CheckBox ID="chkPayGatewayFlag" runat="server" Text="Enable Payment Gateway In Parent Login" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" class="MyTableHead">
                                <asp:Label ID="lblAcademicSessionDetails" runat="server" Text="Academic Session Details"
                                    CssClass="MyLabel"></asp:Label>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" valign="top">
                                <asp:Panel runat="server" ID="pnlGridView" CssClass="MyTableBorder" Width="550px"
                                    Height="300px" ScrollBars="Vertical">
                                    <div id="divPrint">
                                        <asp:GridView ID="gvAcademicSession" runat="server" Width="533px" AutoGenerateColumns="False"
                                            EmptyDataText="No Records Found" OnRowDataBound="gvAcademicSession_RowDataBound"
                                            CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                                            <Columns>
                                                <asp:BoundField DataField="Sl. No." HeaderText="Sl.No">
                                                    <ItemStyle HorizontalAlign="Right" Width="40px" />
                                                    <HeaderStyle HorizontalAlign="Right" Width="40px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AcaStart" HeaderText="Session Start Year">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Academic Session" HeaderText="Academic Session">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Start" HeaderText="Start">
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="End" HeaderText="End">
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ShowFlag" HeaderText="ShowFlag">
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="PayGatewayFlag" HeaderText="PayGatewayFlag"/>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendarStyle"
        Format="dd/MM/yyyy" PopupButtonID="ImgCalPopUp" TargetControlID="txtSessionStart">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendarStyle"
        Format="dd/MM/yyyy" PopupButtonID="ImgCalPopUp2" TargetControlID="txtSessionEnd">
    </cc1:CalendarExtender>
    <asp:HiddenField ID="hidFlag" runat="server" />
    <asp:HiddenField ID="hidCache" runat="server" />
    </form>
</body>
</html>
