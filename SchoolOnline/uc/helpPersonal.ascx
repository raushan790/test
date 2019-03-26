<%@ Control Language="C#" AutoEventWireup="true" CodeFile="helpPersonal.ascx.cs" Inherits="SchoolOnline_uc_helpPersonal" %>
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
                                                        Student Info
                                                    </td>
                                                    <td class="center">
                                                     Click on Student Info Button to get student information which can be edited to click on edit button.    </td>
                                                </tr>
                                                <tr>
                                                    <td class="center">
                                                        Calender
                                                    </td>
                                                    <td class="center">
                                                     Click on Calender Button to see today's and weekly events. 
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="center">
                                                        Personal Diary
                                                    </td>
                                                    <td class="center">
                                                   Click on Personal Diary Button to see Achievements,Class Teacher Remarks,Discipline, General Observation and Subjects Teachers Remarks.  </td>
                                                </tr>
                                                <tr>
                                                    <td class="center">
                                                       Messages
                                                    </td>
                                                    <td class="center">
                                                    Click on Message Button to see inbox mails, draft mail or to send mails to schools.
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td class="center">
                                                       Staff Directory
                                                    </td>
                                                    <td class="center">
                                                    Click on Staff Directory button to get class teacher and subject teacher information. Also you can sent mail to teachers.
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td class="center">
                                                       Medical History
                                                    </td>
                                                    <td class="center">
                                                   Click on Medical History button to get vaccination, Diseases and Allergies Details of student.
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
      