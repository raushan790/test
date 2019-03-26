<%@ Control Language="C#" AutoEventWireup="true" CodeFile="helpAcademic.ascx.cs" Inherits="SchoolOnline_uc_helpAcademic" %>
<%@ Register TagName="ucLastLogin" TagPrefix="ucLastLogin" Src="~/SchoolOnline/uc/lastlogin.ascx" %>

            <div class="link-rgt">
                <ul class="breadcrumbs rgt-float">
                   <ucLastLogin:ucLastLogin ID="uclastlogin" runat="server" />
                    <li class="no-margin"><a class=" popup-btn" href="#myModal3" data-toggle="modal">
                        <button type="button" class="btn btn-danger btn-rounded help-tab">
                            Help <i class="icon-question-sign icon-white"></i>
                        </button>
                    </a>
                        <!--popup box starts-->
                        <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1"
                            class="modal hide fade in" id="myModal3">
                            <div class="modal-header">
                                <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                                    &times;</button>
                                <h4 id="myModalLabel" class="txt-cntr">
                                    Help Text</h4>
                            </div>
                            <div class="modal-body">
                             
                                 
                                <div class="row-fluid">
                                    <table class="table table-bordered responsive  ">
                                        <thead>
                                            <tr>
                                                <th class="center">
                                                    How To Use
                                                </th>
                                            </tr>
                                        </thead>
                                    </table>
                                    <div class="table-scroll">
                                        <table class="table table-bordered responsive  help-font ">
                                            <tbody>
                                                <tr>
                                                    <td class="center">
                                                        Assignment
                                                    </td>
                                                    <td class="center">
                                                  Click on Assignment Button to get information about assigned assignment, activity and projects to student.Click on view button to see details and download button to download assignments, activity and project related uploaded files(pdf, text etc).  </td>   </tr>
                                                <tr>
                                                    <td class="center">
                                                        Evaluation
                                                    </td>
                                                    <td class="center">
                                                  Click on Evalution Button to see Evalution Marks and Download Report.      </td>
                                                </tr>
                                                <tr>
                                                    <td class="center">
                                                        Calender
                                                    </td>
                                                    <td class="center">
                                                   Click on Calender Button to see today's and weekly events.  </td>
                                                </tr>
                                                <tr>
                                                    <td class="center">
                                                       Library
                                                    </td>
                                                    <td class="center">
                                                  Click on Library button to see information about assign book to student, return due date of books assign and fine details.
                                                    </td>
                                                </tr>
                                                
                                                 
                                              
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button data-dismiss="modal" class="btn">
                                    Close</button>
                            </div>
                        </div>
                        <!--popup box ends-->
                    </li>
                </ul>
            </div>
      
