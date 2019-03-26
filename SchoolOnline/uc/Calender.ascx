<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calender.ascx.cs" Inherits="SchoolOnline_uc_Calender" %>
<!--My Calendar-->
      <div class="widgetbox box-info box-border">
                            <h4 class="widgettitle">
                                My Event <a class="close">&times;</a>
                            </h4>
                            <div class="widgetcontent nopadding" style="height:375px;">
                                <asp:UpdatePanel ID="upCalenderevent" runat="server">
                                <ContentTemplate>
                            <asp:Calendar ID="calDetails" runat="server"  OnDayRender="calDetails_DayRender" OnVisibleMonthChanged="calDetails_VisibleMonthChanged"
                                                    SelectionMode="None" Width="100%" 
                                        DayNameFormat="FirstTwoLetters" Font-Names="Times New Roman" Font-Size="10pt" 
                                        ForeColor="Black" Height="320px" ShowGridLines="True" >                                                 
                                                 
                                                <DayHeaderStyle BackColor="#E8E8E8" Font-Bold="False" Font-Size="7pt" 
                                                    ForeColor="#333333" Height="15pt" Wrap="True" />
                                                <DayStyle BorderColor="#E8E8E8" BorderStyle="Solid" BorderWidth="1px" 
                                                    Width="14%" />
                                                <NextPrevStyle BorderColor="White" Font-Size="8pt" ForeColor="White" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <OtherMonthDayStyle CssClass=" ui-datepicker-week-end " ForeColor="#999999" />
                                                <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                                                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" 
                                                    Font-Size="8pt" ForeColor="#333333" Width="1%" />
                                                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" 
                                                    ForeColor="White" Height="22pt" HorizontalAlign="Center" 
                                                    VerticalAlign="Middle" />
                                                <TodayDayStyle BackColor="#CCCC99" />
                                                 
                                                </asp:Calendar>
                                                </ContentTemplate>
                                </asp:UpdatePanel>
                                 <div class="attendance-button">
            <div class="btn btn-present">
                Event</div>
        </div>
                                 <asp:HiddenField ID="hidSunday" runat="server" />
                                <%--<div id="datepicker1">
                                </div>--%>
                            </div>
                        </div>
<!---Calender End--->
