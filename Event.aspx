<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Event.aspx.cs" Inherits="Event" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title> ::CampusCare :: - Calendar  </title>
<link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
<link href="CSS/NewGrid.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="Scripts/jsValidation.js" type="text/javascript" ></script>  
 <script language="javascript" type="text/javascript" src="Scripts/GridScript.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/jsSpecialCharacterValidation.js"></script>
<script language="javascript" type="text/javascript" >
    addLoadEvent(pLoad);
    function pLoad() {
        document.getElementById('btnDelete').disabled = true;
    }
    function fCheckPermission() {
        var varEdit = document.getElementById('hidCache').value;
        if (varEdit != "Y") {
            alert("You Don't Have Permission To Edit");
            return false;
        }
        document.getElementById('txtClassSection').value = '';
        if (document.getElementById('chkClassSection') != null) {
            if (document.getElementById('chkClassSection').rows.length != 0) {
                for (var inti = 0; inti < document.getElementById('chkClassSection').rows.length; inti++) {
                    if (document.getElementById('chkClassSection').rows[inti].getElementsByTagName('INPUT')[0].checked == true) {
                        document.getElementById('txtClassSection').value = document.getElementById('txtClassSection').value + document.getElementById('chkClassSection').rows[inti].getElementsByTagName('LABEL')[0].id + "~";
                    }
                }
            }
        }
        if (stripBlanks(document.getElementById('txtClassSection').value) == "") {
            alert('Please select Class&section');
              return false;
          } 
    } 

    function f_ValidateCalender(e, varDate) {
        var event = e || window.event;
        var target = event.target || event.srcElement
        var varRow = target.id.split('.');
        target.style.backgroundColor="Purple";
        document.getElementById('txtDate').value= varDate; 
        var requestUrl = "Event.aspx?StrQuery=" + encodeURIComponent('Event') + "&Value=" + varDate + "";
        fillGridView('gvEventDetails', requestUrl);
        document.getElementById('gvEventDetails').style.display = '';
        fBindCheckBoxList('chkClassSection',varDate);
        document.getElementById('txtClassSection').value = "";
        document.getElementById('btnDelete').disabled = false;
        return false;
    } 
    function fValidation_On_Preview() {
        //ReplaceSpecialcharacter('form1');
    }
    function fValidation_On_Export() {
        //ReplaceSpecialcharacter('form1');
    }
    function fValidation_On_Close() {
        //ReplaceSpecialcharacter('form1');
    }

    function fSelectDeSelect(e) {
        if (document.getElementById('btnSave').disabled == true)
            return false;
        var xPosition = getPosition(e).x + 5;
        var yPosition = getPosition(e).y + 5;
        document.getElementById('divSelectDeSelect').style.position = "absolute";
        document.getElementById('divSelectDeSelect').style.top = String(yPosition) + "px";
        document.getElementById('divSelectDeSelect').style.left = String(xPosition) + "px";
        document.getElementById('divSelectDeSelect').style.display = "inline";
        return false;
    }
    document.onclick = fInvisibleMenu;
    function fInvisibleMenu() {
        document.getElementById('divSelectDeSelect').style.display = 'none';
    }

    function fClassSubject(eType) {
        var varSelectedVoucher;
        if (document.getElementById('chkClassSection') != null)
            if (document.getElementById('chkClassSection').rows.length > 0)
                for (var i = 0; i < document.getElementById('chkClassSection').rows.length; i++) {
                    for (var j = 0; j < document.getElementById('chkClassSection').rows[i].cells.length; j++) {
                        if (document.getElementById('chkClassSection').rows[i].cells[j].firstChild != null)
                            if (eType == 1) {
                                document.getElementById('chkClassSection').rows[i].cells[j].firstChild.checked = true;
                            }
                            else {
                                document.getElementById('chkClassSection').rows[i].cells[j].firstChild.checked = false;
                            }
                    }
                }
        document.getElementById('divSelectDeSelect').style.display = 'none';
        return false;
    }
function fBindCheckBoxList(ID,varID)
{
    try
    {
        chkListBox=document.getElementById(ID);
        var varClTime=new Date();
        var requestUrl = "Event.aspx?ControlID="+encodeURIComponent(ID)+"&Value="+varID+"";
        var responseStream=getAjaxInfo(requestUrl);
        var data=eval("(responseStream)");
        for (var intForLoop=chkListBox.rows.length-1;intForLoop>=0;intForLoop--)
        {
            chkListBox.deleteRow(intForLoop);
        }
        var arrData=data.split('~');
        if (arrData.length>=0 && data!="")
        {
            var txt;
            for(var i = 0;i<arrData.length;i++)
                {
                    txt =  arrData[i].split(',');
                    var varTR=document.createElement('TR');
                    var varTD=document.createElement('TD');
 
                        if (txt[2].toLowerCase()== txt[0] )
                            varTD.innerHTML="<INPUT id=" + chkListBox.id+'_'+String(i) + " type=checkbox CHECKED><LABEL class=MyLabel id=" + txt[0] + ">" + txt[1] + "</LABEL>"
                        else
                            varTD.innerHTML="<INPUT id=" + chkListBox.id+'_'+String(i) + " type=checkbox><LABEL class=MyLabel id=" + txt[0] + ">" + txt[1] + "</LABEL>"
 
                    varTR.appendChild(varTD);
                    chkListBox.getElementsByTagName('TBODY')[0].appendChild(varTR);
                
            }
        }
    }
    catch (ex)
    {
         
    }
    return false;
} 
</script>
</head>
<body style="background-image:url(Images/backgroundImg.jpg); background-repeat :repeat ; background-position: center center; background-attachment: scroll;">
    <form id="form1" runat="server">
    <div align="center">
        <table>
               <tr>
                <td class="divCircle">
                <table class="MyTableBorder">
                <tr><td id="tblHeading" class="MyTableHeader"   align="center" colspan="2" >
                    Event Detail</td>
                    <td class="MyTableHeader" >
                    Option </td>
                    </tr>
                <tr>
                <td id="tblCalendar" valign="top"  >
                                   <asp:Calendar ID="calDetails" runat="server" BackColor="White" 
                                       BorderColor="Black" Font-Names="Arial" Font-Size="9pt" ForeColor="Black" 
                                       Height="240px" NextPrevFormat="ShortMonth" Width="357px" 
                                       OnDayRender="calDetails_DayRender" 
                                       OnVisibleMonthChanged="calDetails_VisibleMonthChanged"  BorderStyle="Solid" 
                                       CellPadding="1" CellSpacing="1" SelectionMode="None" >
                                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                    <TodayDayStyle BackColor="DarkKhaki" ForeColor="White" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                                    <DayHeaderStyle  Font-Bold="True" Font-Size="8pt" BorderColor="#FFC1A4" ForeColor="#333333" Height="8pt" BackColor="#FFC1A4" BorderStyle="Solid" BorderWidth="1px" />
                                    <TitleStyle BackColor="#400000" Font-Bold="True"
                                        Font-Size="12pt" ForeColor="White" BorderStyle="Solid" CssClass="MyTAbleHead" Height="12pt" />
                                    <DayStyle BackColor="#EBEBEB" BorderColor="#FFC1A4" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:Calendar>
                </td> 
                  <td valign="top" align="left" >
                    <asp:Panel id="pnlClass" runat="server"  CssClass="MyTableBorder" Height="240px" ScrollBars="Both" Width="200px" 
                                    ForeColor="Transparent" >
                                    <asp:CheckBoxList ID="chkClassSection" runat="server" Width="150px" 
                                        CssClass="MyLabel" ForeColor="Black"  >
                                    </asp:CheckBoxList></asp:Panel>
                  </td>
                  <td valign="top">
                      <table>
                          <tr>
                              <td>
                                  <asp:Button ID="btnSave" runat="server" CssClass="MyButton" Text="Save" OnClientClick="return fCheckPermission()" OnClick="btnSave_Click"  />
                              </td>
                          </tr>
                          <tr style="display:none;">
                              <td>
                                  <asp:Button ID="btnPrint" runat="server" CssClass="MyButton" Text="Preview" OnClientClick="return fValidation_On_Preview()" OnClick="btnPrint_Click"  />
                              </td>
                          </tr>
                          <tr style="display:none;">
                              <td>
                                  <asp:Button ID="btnExport" runat="server" CssClass="MyButton" Text="Export" OnClientClick="return fValidation_On_Export()" OnClick="btnExport_Click" />
                              </td>
                          </tr>
                          <tr>
                              <td>
                                  <asp:Button ID="btnDelete" runat="server" CssClass="MyButton" Text="Delete" 
                                      onclick="btnDelete_Click"  />
                              </td>
                          </tr>
                          <tr>
                              <td>
                                  <asp:Button ID="btnClose" runat="server" CssClass="MyButton" Text="Close" OnClientClick="return fValidation_On_Close()" OnClick="btnClose_Click"  />
                              </td>
                          </tr>
                      </table>
                  </td>
                </tr>
               <tr>
                <td colspan="3"  style="height:25px;" class="MyTableHeader">
                 Date:-<asp:TextBox ID="txtDate" runat="server" CssClass="MyDynamicText" ForeColor="White" Font-Bold="true"></asp:TextBox>
                  
                </td>
               </tr>
                <tr><td colspan="3" valign="top" align="center" >
                   <asp:Panel runat="server" id="pnlCalendar"  class="MyTableBorder" Height="220px"  Width="640px" ScrollBars="Vertical" HorizontalAlign="Left">
                     <asp:GridView ID="gvEventDetails" runat="server" AutoGenerateColumns="False"     Width="620px" HorizontalAlign="Left"  CssClass="mGrid"     AlternatingRowStyle-CssClass="alt" >
                    <Columns>   
                    <asp:TemplateField HeaderText="Time">
                     <ItemTemplate>
                      <asp:TextBox ID="txtTime" Font-Bold="true" runat="server" Width="60px" Text='<%# Bind("EventTime") %>' ReadOnly="true" CssClass="MyDynamicText" ></asp:TextBox>
                     </ItemTemplate>
                     <ItemStyle Width="60px" />
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Subject">
                     <ItemTemplate>
                      <asp:TextBox ID="txtEventSubject" Width="130px" runat="server" Text='<%# Bind("EventSubject") %>'  MaxLength="80" CssClass="MyDynamicText" ></asp:TextBox>
                     </ItemTemplate>
                      <ItemStyle Width="150px" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Venue">
                     <ItemTemplate>
                      <asp:TextBox ID="txtVenue" runat="server"  Width="150px" Text='<%# Bind("Venue") %>'  MaxLength="80" onkeypress="javascript:return Restrict_Name(event)" CssClass="MyDynamicText" ></asp:TextBox>
                     </ItemTemplate>
                     <ItemStyle Width="150px" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Discription">
                     <ItemTemplate>
                      <asp:TextBox ID="txtDiscription" runat="server" Width="240px"  Text='<%# Bind("Discription") %>' MaxLength="100"  onkeypress="javascript:return Restrict_Name(event)" CssClass="MyDynamicText" ></asp:TextBox>
                     </ItemTemplate>
                      <ItemStyle Width="240px" />
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

       <div id="divSelectDeSelect" class="MyLabel" style="z-index: 102;position:absolute; display:none; background-color:White;">
        <table cellpadding="0" cellspacing="0" style="border-width:1px;border-style:solid;border-color:#FFC1A4;">
        <tr>
        <td> <asp:Button ID="btnSelectAll" runat="server"  Text="Select&nbsp;All"  CssClass="MyButton" Width="85px" BorderWidth="0px" /></td>
        </tr>
        <tr>
        <td> <asp:Button ID="btnDeSelect" runat="server"  Text="DeSelect&nbsp;All" CssClass="MyButton" Width="85px" BorderWidth="0px" /></td>
        </tr>
        </table>
        </div>
       
    <asp:HiddenField ID="hidCells" runat="server" />
    <asp:HiddenField ID="hidCache" runat="server" /> 
    <div align="center" style="display:none;"> 
         <asp:Button ID="btnDoubleClick" runat="server" CssClass="MyButton" Text="Close" OnClick="btnDoubleClick_Click"  /> 
          <asp:TextBox ID="txtClassSection" runat="server" ></asp:TextBox>
    </div>     
    </form>
</body>
</html>
