<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="SchoolOnline_uc_LeftMenu" %>
<div class="leftpanel"> 
        <div class="leftmenu">        
            <ul class="nav nav-tabs nav-stacked">
            <li class="active"><a href="../SchoolOnline/Default.aspx"><span class="iconfa-home"></span> Home </a></li>
                <li class="dropdown "><a href=""><span class=" iconfa-user"></span> Personal </a>
                <ul>
                    	<li><a href="PLStudentInformation.aspx">Student Info</a></li>
                        <li><a href="../SchoolOnline/calender.aspx">Calendar</a></li>
                        <li><a href="personaldiary.aspx">Personal Diary</a></li>
                        <li><a href="messages.aspx">Messages</a></li>
                        <li><a href="staffdirectory.aspx">Staff Directory</a></li>
                </ul>
                </li>
                 <li class="dropdown"><a href=""><span class="iconsweets-globe2"></span> Academic</a> 
                  <ul>
                    	<li><a href="assignment.aspx">Assignment</a></li>
                        <li><a href="attendance.aspx">Attendance</a></li>
                        <li><a href="evaluation.aspx">Evaluation</a></li>
                      <%--  <li><a href="../SchoolOnline/history.aspx">Library</a></li>--%>
                         <li><a href="../SchoolOnline/library.aspx">Library</a></li>
                        <li><a href="syllabus.aspx">Syllabus</a></li>
                         <li><a href="timetable.aspx">Time Table</a></li>
                </ul>
			  </li>
                <li class="dropdown"><a href=""><span class="iconfa-money"></span>Fee Details</a> 
                 <ul>
                    	<li><a href="fee.aspx">Fees</a></li>
                        <li><a href="../SchoolOnline/ComingSoon.aspx">List of bank Available for Online Payment</a></li>
                </ul>
                </li> <li><a href="../SchoolOnline/onlinePayment.aspx"><span class="iconfa-money"></span>Online Payment</a> </li>
                <li><a href="http://www.dpsgurgaon.org/photogallery.php" target="_blank" runat="server"><span class="iconfa-money"></span>Photo Album</a> </li>
                <li><a href="../SchoolOnline/PLSchPride.aspx"><span class="iconfa-money"></span>School Pride</a> </li>
				</ul>
        </div><!--leftmenu-->
        
    </div>