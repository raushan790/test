<%@ Control Language="C#" AutoEventWireup="true" CodeFile="attendance.ascx.cs" Inherits="SchoolOnline_uc_attendance" %>
<!-- Attendance -->
<div class="widgetbox box-info box-border">
    <h4 class="widgettitle">
        Attendance <a class="close">&times;</a>
    </h4>
    <div class="widgetcontent nopadding" style="height: 322px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upCalenderevent" runat="server">
            <ContentTemplate>
                <asp:Calendar ID="calendarAttentance" runat="server" OnDayRender="calendarAttentance_DayRender"
                    OnVisibleMonthChanged="calendarAttentance_VisibleMonthChanged" SelectionMode="None" Width="100%"
                    DayNameFormat="FirstTwoLetters" Font-Names="Times New Roman" Font-Size="10pt"
                    ForeColor="Black" Height="320px" ShowGridLines="True">
                    <DayHeaderStyle BackColor="#E8E8E8" Font-Bold="False" Font-Size="7pt" ForeColor="#333333"
                        Height="15pt" Wrap="True" />
                    <DayStyle BorderColor="#E8E8E8" BorderStyle="Solid" BorderWidth="1px" Width="14%" />
                    <NextPrevStyle BorderColor="White" Font-Size="8pt" ForeColor="White" HorizontalAlign="Center"
                        Wrap="True" />
                    <OtherMonthDayStyle CssClass=" ui-datepicker-week-end " ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White"
                        Height="22pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- <div id="datepicker">
        </div>--%>
        <!--    <div class="jquery-calendar"></div>-->
        <div class="attendance-button">
            <button class="btn btn-present">
                Present</button>
            &nbsp;
            <button class="btn btn-absent">
                Absent</button>
            &nbsp;
            <button class="btn btn-halfday">
                HalfDay</button>
            <span class="full-width text-center">
                <asp:Label runat="server" ID="lblTotalAttendance"></asp:Label></span>
        </div>
    </div>
</div>
<div id="divToolTip" style="display: none; font-size: 11px; font-weight: bold; width: 180px;">
    <div align="center" class="divMain">
        <div class="classdiv">
        </div>
        <div class="divInner">
            <div id="divText" style="margin: 10px;">
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hidSunday" runat="server" />
<!-- Attendance -->
