<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="SchoolOnline_uc_header" %>
    <style type="text/css">
    .school-logo img {
    width: 25%;
}
        @media screen and (max-width: 970px) {

          
        }
 </style>
  

<div class="header">
    <div class="logo">
        <div class="school-logo">
            <a href="../SchoolOnline/Default.aspx">
                <img src="images/logo.png" />
            </a>
        </div>
        <div class="school-name">
     <%=SchoolName.ToUpper() %>
        </div>
    </div>
    <div class="headerinner">
        <ul class="headmenu">
            <li class="odd"><a class="dropdown-toggle" data-toggle="dropdown" href="#"><span
                class="count">
                <%=URMsgCount %></span> <span class="head-icon head-message"></span><span class="headmenu-label">
                    Messages</span> </a>
                <ul class="dropdown-menu">
                    <li class="nav-header">Messages</li>
                    <asp:Literal ID="ltrlMessages" runat="server"></asp:Literal>
                    <li class="viewmore"><a href="../SchoolOnline/messages.aspx">View More Messages</a></li>
                </ul>
            </li>
            <li><a class="dropdown-toggle" data-toggle="dropdown" data-target="#"><span class="count">
            </span><span class="head-icon head-users"></span><span class="headmenu-label">Profile</span>
            </a>
                <ul class="dropdown-menu newusers">
                    <li class="nav-header">Profile Detail</li>
                    <asp:Literal ID="ltrlProfileDetail" runat="server"></asp:Literal>
                </ul>
            </li>
             <li class="odd">
                    <a href="../SchoolOnline/onlinePayment.aspx" > 
                    <span class="count"></span>
                    <span class="head-icon online-payment"></span>
                    <span class="headmenu-label">Online Payment</span>
                    </a>
                   </li>
                  <li class="odd"><a href="../SchoolOnline/assignment.aspx?Circular=Circular">
                 <%-- <span class="count" id="lblCountCircular" runat="server"> </span>--%>
                  <asp:Label class="count" ID="lblCountCircular" runat="server"></asp:Label>
                   <span class="head-icon circular"></span><span class="headmenu-label">
                    Unread Circulars</span> </a>
               
            </li>
            <li class="right">
                 <div class="userloggedinfo">
                    <asp:Image ID="imgStudent" runat="server" style=" max-height:90px; max-width:90px;"  ImageUrl="~/SchoolOnline/images/profilethumb.png" />
                    <div class="userinfo s-info">
                        <ul>
                            <li class="s-name "><span class="field">
                                <asp:DropDownList ID="ddlStudent" runat="server" class="uniformselect student-detail"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span></li>
                            <li class="s-year"><span class="field">
                                <asp:DropDownList ID="ddlAcademic" runat="server" AutoPostBack="True"  class="uniformselect student-detail" OnSelectedIndexChanged="ddlAcademic_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span></li>
                            <li class="s-pass" ><a href="../SchoolOnline/ChangePassword.aspx">Change Password</a></li>
                            <li class="s-pass">
                                <asp:LinkButton ID="lnkSignout" runat="server" OnClick="lnkSignout_Click"> Sign Out</asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
            </li>
        </ul>
        <!--headmenu-->
    </div>
</div>
