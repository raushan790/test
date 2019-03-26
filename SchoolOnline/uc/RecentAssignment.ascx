<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentAssignment.ascx.cs"
    Inherits="SchoolOnline_uc_RecentAssignment" %>
<!-- Recent Assignments -->
<div class="widgetbox box-info box-border">
    <h4 class="widgettitle">
        Recent Assignments <a class="close">&times;</a>
    </h4>
    <div class="row-fluid">
        <ul id="slidercontent" class="assignment-height">
               <asp:Literal ID="ltrlRecentAssignment" runat="server"></asp:Literal>

             
        </ul>
        <!--span6-->
    </div>
</div>
<!--- Recent Assignments--->
