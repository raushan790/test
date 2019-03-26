<%@ Control Language="C#" AutoEventWireup="true" CodeFile="helpDefault.ascx.cs" Inherits="SchoolOnline_uc_helpDefault" %>
<%@ Register TagName="ucLastLogin" TagPrefix="ucLastLogin" Src="~/SchoolOnline/uc/lastlogin.ascx" %>
   
            <div class="">
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
                                                        Personal
                                                    </td>
                                                    <td class="center">
                                                     Click on Personal Button to get Student Information, Calender, Personal Diary, Messages, Staff Directory and Medical History related details.</td>
                                                </tr>
                                                <tr>
                                                    <td class="center">
                                                        Academics
                                                    </td>
                                                    <td class="center">
                                                    Click on Academics Button to get Student Assignments,Exam Evaluation and Library related details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="center">
                                                       Finance
                                                    </td>
                                                    <td class="center">
                                                  Click on Finance Button to get Student Fees related details. </td>
                                                </tr>
                                                <tr>
                                                    <td class="center">
                                                       Change Password
                                                    </td>
                                                    <td class="center">
                                                   Click on Change Password Button to Change Your Password
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td class="center">
                                                     Logout
                                                    </td>
                                                    <td class="center">
                                                Click on Logout Button to Logout.
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td class="center">
                                                       Home
                                                    </td>
                                                    <td class="center">
                                                 Click on Home Button to go Home Page.
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
     