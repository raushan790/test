using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Text;
using SchoolOnline;

public partial class SchoolOnline_uc_header : System.Web.UI.UserControl
{
    protected string Name = "";
    protected string ClassSection = "";
    protected string strClass = "";
    protected int ClassID = 0;
    protected int SectionID = 0;
    protected string strSection = "";
    protected string ImageUrl = "";
    string strDate = DateTime.Now.ToString("yyyy/MM/dd");
    protected string strAtten;
    protected string StrMon;
    protected int month = System.DateTime.Today.Month;
    protected int Year = System.DateTime.Today.Year;
    protected int URMsgCount = 0;
    protected int URAssignmentCount = 0;
    static public string PayGatewayFlag;
    string SQLQuery;
    protected string SchoolName = "";
    protected int CountDiaryRemark = 0;


    CCWeb ObjccWeb = new CCWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetTop5UnreadMail();
            BindDropDownStudent();
            GetStudentProfile();
            CountDiaryRemarkval();
            CountAssignment();
        }
    
      
    }

    protected void BindDropDownStudent()
    {
        SchoolName = ObjccWeb.ReturnSingleValue("select SchoolName1 from MTClientCompany");
        if (ObjccWeb.ReturnNumericValue("Select UserTypeID from MTUserMaster Where UID=" + Session["UID"] + "") == 3)
        {
            ObjccWeb.FillDDLs(ddlStudent, "Select Distinct SM.StudentID As StudentID,FirstName From SIStudentMaster SM Inner Join SIStudentYearWiseDetails SYD on SYD.StudentID=SM.StudentID where " +
            "ParentID=" + Session["ParentID"] + " AND StudentStatus='S' order by SM.StudentID", "StudentID", "Firstname", "");
           
            ObjccWeb.FillDDLs(ddlAcademic, "SELECT SYD.AcaStart AS AcaStart,CAST(SYD.AcaStart AS VARCHAR)+' - '+CAST(SYD.AcaStart+1 AS VARCHAR) AS AcademicSession From SIStudentYearwiseDetails SYD INNER JOIN MTAcademicSessionMaster ASM ON ASM.AcaStart=SYD.AcaStart" +
              " WHERE SYD.AcaStart<>0 and StudentID=" + Session["StudentID"] + " AND ShowFlag='Y' ORDER BY SYD.AcaStart DESC", "AcaStart", "AcademicSession", "");
        }
    }
    protected void GetStudentProfile()
    {
        dalCommon objCommon = new dalCommon();
        dalDashboard objDashboard = new dalDashboard();
        try
        {
            objCommon.AcaStart = Session["AcaStart"].ToString();
            objCommon.StudEmp = Session["StudentID"].ToString();
            SqlDataReader rdr1 = objDashboard.GetStudentProfile(objCommon);

            if (rdr1.Read())
            {
                Name = rdr1.GetValue(1).ToString();
                ClassSection = rdr1.GetValue(2).ToString();
                ltrlProfileDetail.Text = "";
                ltrlProfileDetail.Text += "<li><a href=''>";
                if (File.Exists(Server.MapPath("../FatherPhoto") + "/F" + Session["ParentID"] + ".jpg") == true)
                {
                    ltrlProfileDetail.Text += "<img src='../FatherPhoto/F" + Session["ParentID"] + ".jpg' height='32px' alt='' class='userthumb' />";
                }
                else
                {
                    ltrlProfileDetail.Text += "<img src='images/photos/thumb1.png' alt='' class='userthumb' />";
                }
               
                ltrlProfileDetail.Text += "<strong>Mr. " + Convert.ToString(rdr1["FatherName"]) + "</strong>Father Name<small></small> </a></li>";
                ltrlProfileDetail.Text += "<li><a href=''>";

               
                if (File.Exists(Server.MapPath("../MotherPhoto") + "/M" + Session["ParentID"] + ".jpg") == true)
                {
                    ltrlProfileDetail.Text += "<img src='../MotherPhoto/M" + Session["ParentID"] + ".jpg' height='32px' alt='' class='userthumb' />";
                }
                else
                {
                    ltrlProfileDetail.Text += "<img src='images/photos/thumb1.png' alt='' class='userthumb' />";
                }
                ltrlProfileDetail.Text += "<strong>Mrs. " + Convert.ToString(rdr1["MotherName"]) + "</strong> <small>Mother Name</small> </a></li>";
                ltrlProfileDetail.Text += "<li class='viewmore'><a href='../SchoolOnline/PLStudentInformation.aspx'>View Full Details</a></li>";


            }
            rdr1.Close();
            rdr1.Dispose();
            ClassID = objDashboard.GetClassID(objCommon);
            SectionID = objDashboard.GetSectionID(objCommon);

            if (File.Exists(Server.MapPath("~/StudentPhoto") + "/S" + Session["StudentID"].ToString() + ".jpg") == true)
            {
                imgStudent.ImageUrl = "~/StudentPhoto/S" + Session["StudentID"].ToString() + ".jpg?" + System.DateTime.Now.ToFileTimeUtc();
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            objDashboard = null;
        }
    }
    
    private void GetPaymentGetWayStatus()
    {
        SQLQuery = "Select ISNULL(PayGatewayFlag,'N') FROM MTAcademicSessionMaster WHERE AcaStart=" + Session["AcaStart"] + "";
        PayGatewayFlag = ObjccWeb.ReturnSingleValue(SQLQuery);
        Session["PayGatewayFlag"] = PayGatewayFlag;
    }

    protected void GetTop5UnreadMail()
    {
        DataSet ds = new DataSet();
        dalCommon objCommon = new dalCommon();
        dalLibMail objLibMail = new dalLibMail();
        try
        {
            objCommon.UID = Session["UID"].ToString();
            ds = objLibMail.GetTop5UnreadMail(objCommon, "UR");
            if (ds.Tables[0].Rows.Count > 0)
            {
                URMsgCount = ds.Tables[0].Rows.Count;
                ltrlMessages.Text = "";
                int dsRowcount = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ltrlMessages.Text += "<li><a href=\"../SchoolOnline/messages.aspx\"><span class=\"icon-envelope\"></span>New message from <strong>" + ds.Tables[0].Rows[i]["Sender"] + "</strong><small class='muted'>- " + ds.Tables[0].Rows[i]["Date"] + "</small></a></li>";
                    if (dsRowcount == 5)
                    { break; }
                    else
                    dsRowcount = dsRowcount + 1;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void CountDiaryRemarkval()
    {
        DataTable dt = new DataTable();
        dt = ObjccWeb.BindDataTable("exec SP_Assignment 1512,2014,1,'H','','',''");
        CountDiaryRemark = dt.Rows.Count;
    }
    protected void CountAssignment()
    {
        int val;
        //val = ObjccWeb.ReturnNumericValue("select count(*) from MTAssignmentDetails MD inner join MTAssignmentMaster MA ON MA.AssignmentID=MD.AssignmentID " +
        //                " WHERE MA.AcaStart=" + Session["AcaStart"] + " AND MA.SchoolID=" + Session["SchoolID"] + " AND (MD.StudEmpID=" + Session["StudentID"] + " or MD.StudEmpID=0) and ma.AssignmentType='C' " +
        //                " and MD.AssignmentID not in (select mad.AssignmentID from MTAssignmentDetails mad inner join AssignmentParentRead apr on mad.AssignmentID=apr.AssignmentID and  mad.StudEmpID=apr.UID where mad.StudEmpID=" + Session["StudentID"] + ")");

        val = ObjccWeb.ReturnNumericValue("select count(*) from MTAssignmentDetails MD inner join MTAssignmentMaster MA ON MA.AssignmentID=MD.AssignmentID " +
                               " WHERE MA.AcaStart=" + Session["AcaStart"] + " AND MA.SchoolID=" + Session["SchoolID"] + " AND (MD.StudEmpID=" + Session["StudentID"] + " or MD.StudEmpID=0) and ma.AssignmentType='C' " +
                               " and MD.AssignmentID not in (select AssignmentID from AssignmentParentRead where UID=" + Session["UID"] + ")");



        URAssignmentCount = val;
        lblCountCircular.Text = URAssignmentCount.ToString();
    }




    protected void GetParentsProfile()
    {
        dalCommon objCommon = new dalCommon();
        dalDashboard objDashboard = new dalDashboard();
        try
        {

        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void ddlAcademic_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["AcaStart"] = ddlAcademic.SelectedValue;
        GetPaymentGetWayStatus();
        GetStudentProfile();
        GetTop5UnreadMail();
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["StudentID"] = ddlStudent.SelectedValue;
        ObjccWeb.FillDDLs(ddlAcademic, "SELECT AcaStart AS AcaStart,CAST(AcaStart AS VARCHAR)+' - '+CAST(AcaStart+1 AS VARCHAR) AS AcademicSession From SIStudentYearwiseDetails WHERE AcaStart<>0 and StudentID=" + Session["StudentID"] + " ORDER BY AcaStart DESC", "AcaStart", "AcademicSession", "");
        try
        {
            ddlAcademic.Items.FindByValue(Session["AcaStart"].ToString()).Selected = true;
            GetStudentProfile();
            GetTop5UnreadMail();
        }
        catch
        {

        }
        Session["AcaStart"] = ddlAcademic.SelectedValue;
    }
    protected void lnkSignout_Click(object sender, EventArgs e)
    {
        dalCommon objCommon = new dalCommon();
        dalDashboard objDashboard = new dalDashboard();
        if (Session["Cache"] != null)
        {
            Cache.Remove(Session["Cache"].ToString());
        }
        Session.Clear();
        Response.Redirect("~/Logon.aspx");
    }
}