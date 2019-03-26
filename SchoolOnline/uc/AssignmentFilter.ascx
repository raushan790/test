<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssignmentFilter.ascx.cs" Inherits="SchoolOnline_uc_AssignmentFilter" %>
   <div class="filter-box">
                                    <div class="span3">
                                        <label class="span4 top-margin">
                                            From Date</label>
                                        <span class="field span8">
                                            <asp:TextBox ID="txthmfromdate" runat="server" type="text" name="date" class="span11 hasDatepicker"></asp:TextBox>
                                        </span>
                                    </div>
                                    <div class="span3">
                                        <label class="span3 top-margin">
                                            To Date</label>
                                        <span class="field span9">
                                            <asp:TextBox ID="txthmTodate" runat="server" type="text" name="date" class="span11 hasDatepicker"></asp:TextBox>
                                        </span>
                                    </div>
                                    <div class="span4">
                                        <label class="control-label span3 top-margin" for="">
                                            Subject</label>
                                        <span class="span9">
                                            <div class="selector">
                                                <span>Circulars</span>
                                                <asp:DropDownList ID="ddlSubject" runat="server" class="uniformselect" Style="opacity: 0;">
                                                    <asp:ListItem Text="Account" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Accountfasd" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Accounfst" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </span>
                                    </div>
                                    <div class="span1">
                                        <button class="btn ">
                                            Display</button>
                                    </div>
                                </div>