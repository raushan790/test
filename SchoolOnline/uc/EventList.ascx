<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventList.ascx.cs" Inherits="SchoolOnline_uc_EventList" %>
<!--Event Lists-->
<div class="widgetbox box-info box-border">
    <h4 class="widgettitle">
        Event Lists <a class="close">×</a>
    </h4>
    <div class="event-list-table">
        <ul class="entrylist">
            <asp:Repeater ID="rptrEventList" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="entry_wrap">
                            <div class="slide_date">
                                <span class="date-dash"><%#Convert.ToDateTime(Eval("EventDate"), cinfo).ToString("dd")%> </span><span class="month"><%#Eval("Month")%> </span>
                            </div>
                            <div class="entry_content">
                                <h4>
                                    <%#Eval("EventSubject") %></h4>
                                <p>
                                   <%#Eval("Venue") %></p>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
<!---End Event List---->
