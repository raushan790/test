using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SchoolOnline;

/// <summary>
///  DashBoard Methods Include Latest Assignment, News & Event etc
/// </summary>
/// 

namespace SchoolOnline
{
    public class dalDashboard
    {
        CCWeb objCCWeb = new CCWeb();

        #region Get Recent Assignment List
        public DataTable GetRecentAssignmentList(dalCommon objCommonpara, int noofRow)
        {
            DataTable dt;
            string SQLQuery = "SELECT  DISTINCT TOP " + noofRow + " Convert(VARCHAR,Date,103) as Date,MAM.AssignmentID,ISnull(SubjectName,'')As SubjectName, " +
            " ISNULL(AssignmentTitle,'') as AssigntmentTitle,substring(Assignment,1,70) AS Assignment,2 as Priority,UserName,EAssignmentPath,    " +
            " ISnull(MAD.ExamSubjectID,0)As ExamSubjectID  ,VideoLinkPath ,substring(CAST(Date as varchar),1,3)  as Month,DATE AS Date1  from MTAssignmentDetails MAD " +
            " INNER JOIN MTAssignmentMaster MAM ON MAM.AssignmentID=MAD.AssignmentID INNER JOIN SIStudentYearWiseDetails SYD ON SYD.ClassID=MAD.ClassID " +
            " AND SYD.SectionID=MAD.SectionID  AND (SYD.StudentID=MAD.StudEmpID OR MAD.StudEmpID=0)  " +
            " INNER JOIN  MTUsermaster UM on UM.UID=MAD.EntryUSerID  Left join AssignmentSubjectMaster ESM on ESM.SubjectID=MAD.ExamSubjectID and  " +
            " ESM.AcaStart=" + objCommonpara.AcaStart + " Where SYD.StudentID=" + objCommonpara.StudEmp + " AND SYD.AcaStart=" + objCommonpara.AcaStart + " and  MAM.AcaStart=" + objCommonpara.AcaStart + " " +
            " and MAM.SchoolID=" + objCommonpara.SchoolId + "  and AssignmentType='H' order by Date1 Desc   ";
            try
            {
                dt = objCCWeb.BindDataTable(SQLQuery);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region Get UpComing Events
        public SqlDataReader GetEventList(dalCommon objCommonPara)
        {
            SqlDataReader sqlDR;
            string SQLQuery = "SELECT EventSubject,ED.EventTime,EM.EventDate,Convert(varchar,EventDate,103) AS Date,substring(CAST(EventDate as varchar),1,3)  as Month,Venue,Discription FROM EventMaster EM INNER JOIN EventDetail ED ON EM.EventID=ED.EventID WHERE EM.EventID IN(Select EventID from EventClassDetail ED INNER JOIN SIStudentYearWiseDetailS SYD ON SYD.ClassID=ED.ClassID AND SYD.SectionID=ED.SectionID Where StudentID=" + objCommonPara.StudEmp + ")" +
            "AND EventDate>=(select AcaStartDate from MTAcademicSessionMaster Where Acastart=" + objCommonPara.AcaStart + ")AND EventDate <=(select AcaEndDate from MTAcademicSessionMaster Where Acastart=" + objCommonPara.AcaStart + ") " +
            "AND (EventSubject<>'' OR Venue<> '' OR EventSubject<>'') ORDER BY  EventDate DESC";
        try
            {
                sqlDR = objCCWeb.BindReader(SQLQuery);
                return sqlDR;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objCCWeb = null;
            }
        }
        #endregion

        #region Get News and Events List
        public SqlDataReader GetNewsAndEventList(dalCommon objCommonPara)
        {
            SqlDataReader sqlDR;

            string SQLQuery = "SELECT DISTINCT MD.MessageID,ISNULL(MessageTitle,'') AS MessageTitle, Message AS Message,ISNULL(NewsFileName,'') as NewsFileName,MessageDate" +
              " from MTMessageMaster MM INNER JOIN MDMessageDetails MD ON MD.MessageID=MM.MessageID " +
              " WHERE (StudentID=" + objCommonPara.StudEmp + " AND UserType='S') OR UserType='A' AND MessageStatus='Y' AND  '" + objCommonPara.strDate + "' between MessageDate  And MessageTillDate  AND SchoolID=" + objCommonPara.SchoolId + " ORDER BY MessageDate desc";
            try
            {
                sqlDR = objCCWeb.BindReader(SQLQuery);

                return sqlDR;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objCCWeb = null;
            }
        }
        #endregion

        #region Get Fee Details
        public SqlDataReader GetFeeDetails(dalCommon objCommonPara)
        {
            SqlDataReader sqlDR;
            string SQLQuery = "EXEC [SpFeeSummary]  " + objCommonPara.SchoolId + "," + objCommonPara.AcaStart + "," + objCommonPara.StudEmp + ",4,0";
            try
            {
                sqlDR = objCCWeb.BindReader(SQLQuery);
                return sqlDR;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objCCWeb = null;
            }
        }
        #endregion


        #region Return StudentProfile
        public SqlDataReader GetStudentProfile(dalCommon objCommonPara)
        {
           

            SqlDataReader sqlDR;
            //string SQLQuery = "Select SIM.StudentID , FirstName+' '+MiddleName+' '+LastName As Name,COnvert(varchar,DateOfBirth,103) As DateOfBirth,ClassName1+' '+SectionNAme1 from SIStudentMaster SIM inner join " +
            //                    " SistudentYearwiseDetails SYD on SYD.StudentID=SIM.StudentID inner join MtClassMaster CM on SYD.ClassID=CM.ClassID inner join MTSectionMaster SM on SYD.SectionID=SM.SectionID " +
            //                    " Where SIM.StudentID=" + objCommonPara.StudEmp + " and SYD.AcaStart=" + objCommonPara.AcaStart + "";

            string SQLQuery = "EXEC[spFILLStudentData] " + objCommonPara.StudEmp + "," + objCommonPara.AcaStart + "";
            try
            {
                sqlDR = objCCWeb.BindReader(SQLQuery);

                return sqlDR;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objCCWeb = null;
            }
        }
        #endregion

        #region ReturnClassIDbyStudentIDandAcaStart
        public int GetClassID(dalCommon objCommonPara)
        {
            CCWeb objCCWeb = new CCWeb();
            int ClassID = 0;
            string SQLQuery = "Select classID from SistudentyearwiseDetails where StudentID=" + objCommonPara.StudEmp + " and AcaStart=" + objCommonPara.AcaStart + "";
            try
            {
                ClassID = objCCWeb.ReturnNumericValue(SQLQuery);

                return ClassID;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objCCWeb = null;
            }
        }
        #endregion

        #region ReturnSectionIDbyStudentIDandAcaStart
        public int GetSectionID(dalCommon objCommonPara)
        {
            CCWeb objCCWeb = new CCWeb();
            int SectionID = 0;
            string SQLQuery = "Select SectionID From SistudentyearwiseDetails where StudentID=" + objCommonPara.StudEmp + " and AcaStart=" + objCommonPara.AcaStart + "";
            try
            {
                SectionID = objCCWeb.ReturnNumericValue(SQLQuery);

                return SectionID;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objCCWeb = null;
            }
        }
        #endregion

        #region LogoutSessionSessionStore
        public SqlDataReader LogoutSessionStore(dalCommon objCommonPara)
        {
            CCWeb objCCWeb = new CCWeb();
            SqlDataReader sqlDR;
            string SQLQuery = "UPDATE MDUserLoginDetails SET LoggedOutTime=GETDATE() WHERE LoggedOutTime IS NULL AND  SessionDetails='" + objCommonPara.Userlogin.ToString().Replace("'", "''") + "'";
            try
            {
                sqlDR = objCCWeb.BindReader(SQLQuery);
                return sqlDR;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objCCWeb = null;
            }
        }
        #endregion

    }
}