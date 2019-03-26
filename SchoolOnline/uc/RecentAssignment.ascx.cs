using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolOnline;
using System.Globalization;
using System.Data;

public partial class SchoolOnline_uc_RecentAssignment : System.Web.UI.UserControl
{
    protected CultureInfo cinfo = new CultureInfo("hi-IN");
    dalDashboard objDashboard = new dalDashboard();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GeRecentAssignmentList();
        }
    }

    protected void GeRecentAssignmentList()
    {
        DataTable dt = new DataTable();
        dalCommon objCommon = new dalCommon();
        objCommon.AcaStart = Session["AcaStart"].ToString();
        objCommon.SchoolId = Session["SchoolID"].ToString();
        objCommon.StudEmp = Session["StudentID"].ToString();
        dt = objDashboard.GetRecentAssignmentList(objCommon, 5);
        if (dt.Rows.Count > 0)
        {
           
            ltrlRecentAssignment.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltrlRecentAssignment.Text += "<li>";
                ltrlRecentAssignment.Text += "";
                ltrlRecentAssignment.Text += "<div class='slide_wrap'>";
                ltrlRecentAssignment.Text += " <div class='slide_date'>";
                ltrlRecentAssignment.Text += "<span class='date-dash'>" + Convert.ToDateTime(dt.Rows[i]["Date"], cinfo).ToString("dd") + " </span><span class='month'> " + dt.Rows[i]["Month"] + " </span>";
                ltrlRecentAssignment.Text += "</div>";
                ltrlRecentAssignment.Text += " <div class='slide_content'>";
                ltrlRecentAssignment.Text += " <h4>";
                ltrlRecentAssignment.Text += "" + dt.Rows[i]["AssigntmentTitle"] + "</h4>";
                ltrlRecentAssignment.Text += " <p>";
                ltrlRecentAssignment.Text += "" + dt.Rows[i]["Assignment"] + "</p>";
                ltrlRecentAssignment.Text += "<p>";
                ltrlRecentAssignment.Text += "<a class='btn btn-primary' href='assignment.aspx?AssignmentID=" + dt.Rows[i]["AssignmentID"] + "'>";
                ltrlRecentAssignment.Text += "  View More</a>";
                ltrlRecentAssignment.Text += "</p>";
                ltrlRecentAssignment.Text += "</div>";
                ltrlRecentAssignment.Text += "</div>";



                ltrlRecentAssignment.Text += "<div class='assignment-border'>";
                ltrlRecentAssignment.Text += "</div>";
                if (i + 1 == dt.Rows.Count)
                {
                    break;
                }
                else
                    i = i + 1;

                ltrlRecentAssignment.Text += "<div class='slide_wrap'>";
                ltrlRecentAssignment.Text += " <div class='slide_date'>";
                ltrlRecentAssignment.Text += "<span class='date-dash'>" + Convert.ToDateTime(dt.Rows[i]["Date"], cinfo).ToString("dd") + "  </span><span class='month'> " + dt.Rows[i]["Month"] + " </span>";
                ltrlRecentAssignment.Text += " </div>";
                ltrlRecentAssignment.Text += " <div class='slide_content'>";
                ltrlRecentAssignment.Text += "<h4>";
                ltrlRecentAssignment.Text += "  " + dt.Rows[i]["AssigntmentTitle"] + "</h4>";
                ltrlRecentAssignment.Text += " <p>";
                if (dt.Rows[i]["Assignment"].ToString().Length > 30)
                    ltrlRecentAssignment.Text += " " + dt.Rows[i]["Assignment"].ToString().Substring(1, 30) + "...</p>";
                else
                    ltrlRecentAssignment.Text += " " + dt.Rows[i]["Assignment"].ToString() + "...</p>";
                ltrlRecentAssignment.Text += "  <p>";
                ltrlRecentAssignment.Text += " <a class='btn btn-primary'  href='assignment.aspx?AssignmentID=" + dt.Rows[i]["AssignmentID"] + "'>";
                ltrlRecentAssignment.Text += "  View More</a>";
                ltrlRecentAssignment.Text += " </p>";
                ltrlRecentAssignment.Text += " </div>";
                ltrlRecentAssignment.Text += " </div>";
                ltrlRecentAssignment.Text += " </li>";
            }
        }

        //rptrRecentAssignments.DataSource = 
        //rptrRecentAssignments.DataBind();
    }



    protected void GtRecet()
    {
        ltrlRecentAssignment.Text = "";




    }
}