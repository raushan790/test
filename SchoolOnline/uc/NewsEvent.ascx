<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsEvent.ascx.cs" Inherits="SchoolOnline_uc_NewsEvent" %>
<script language="javascript" src="../Scripts/jsValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../Scripts/GridScript.js" type="text/javascript"></script>
 <script type="text/javascript">
     function pShowAssignmentDetail(e) {
         debugger;
            var varKey;
            if (window.event)
                varKey = window.event.keyCode;
            else
                varKey = e.which;
            var event = e || window.event;
            var target = event.target || event.srcElement;
            var varid = target.id.split('_');
            var varCID = "ctl00_body_ucnewsevent_rptrNewsEventList_" + varid[4] + "_hdnNewsAttachment"
            var varPDFCHECKING = document.getElementById(varCID).value.split('.');
            if (varPDFCHECKING[varPDFCHECKING.length - 1] == "PDF" || varPDFCHECKING[varPDFCHECKING.length - 1] == "pdf") {
                var image = document.getElementById(varCID).value;
                window.open("../News/" + image +"");
            }
            else
            {
                document.getElementById('ctl00_body_ucnewsevent_imgEventPopUp').src = "../News/" + document.getElementById(varCID).value;
                document.getElementById('ctl00_body_ucnewsevent_hypPopUP').click(); 
            }
            return false;
        } 
</script>
<!--News & Event-->
<div class="widgetbox box-info box-border event-height">
    <h4 class="widgettitle">
        School &amp; News <a class="close">×</a>
    </h4>
    <div class="widgetcontent">
        <marquee height="230px;" behavior="scroll" direction="up" onmouseover="this.stop();"
            onmouseout="this.start(); ">
      <%-- <ul class="event-highlights"> --%> 
    <asp:Repeater ID="rptrNewsEventList" runat="server" OnItemDataBound="rptrNewsEventList_ItemDataBound">
    <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
      <%--  <li> --%>
                
                  <div class="slide-wrap-event">
                 <div class="slide-img-event">                                
     <asp:ImageButton ID="imgEvent"  name="imgEvent" Width="50px" Height="50px" OnClientClick="javascript:return pShowAssignmentDetail(event)" ImageUrl='<%# (Eval("NewsFileName")==""?"":"~/News/"+Eval("NewsFileName")) %>'  runat="server"></asp:ImageButton> 
     <asp:HiddenField ID="hdnNewsAttachment" runat="server" Value='<%# Eval("NewsFileName") %>' />

    </div>
                <div class="slide-content-event">
                <h4 style="color:Orange">
                <%#Eval("MessageTitle")%></h4> 
                <p><%#Eval("Message")%>...</p>
                </div>
            </div>    
       <%--  </li>--%>

        </ItemTemplate>
    </asp:Repeater>




<%--</ul>--%>
</marquee>
    </div>
     <!--popup box starts-->
                            <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1"
                                class="modal hide fade in" id="myModal">
                                <div class="modal-header">
                                    <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                                        ×</button>
                                    <h4 id="H1">
                                        Attachment Detail</h4>
                                </div>
                                
                                <div class="modal-body">
                                    <table class="table table-bordered responsive ">
                                        <thead>
                                            <tr>
                                                <th class="center">
                                                   Attachment
                                                </th>
                                               
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td class="center">
                                                   <asp:Image ID="imgEventPopUp"  name="imgEvent"    runat="server"></asp:Image>
                                                </td>
                                               
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <button data-dismiss="modal" class="btn">
                                        Close</button>
                                </div>
                            </div>
                            <!--popup box ends-->
                            <asp:HyperLink ID="hypPopUP" href="#myModal" data-toggle="modal" runat="server"></asp:HyperLink>
</div>
