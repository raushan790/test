using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolOnline;
using System.Globalization;

public partial class SchoolOnline_uc_EventList : System.Web.UI.UserControl
{
    protected CultureInfo cinfo = new CultureInfo("hi-IN");
    dalDashboard objDashboard;
    dalCommon objCommon;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            NewsEventBind();
    }
    protected void NewsEventBind()
    {
        objDashboard = new dalDashboard();
        objCommon = new dalCommon();
        objCommon.AcaStart = Session["AcaStart"].ToString();
        objCommon.SchoolId = Session["SchoolID"].ToString();
        objCommon.StudEmp = Session["StudentID"].ToString();
        try
        {
            rptrEventList.DataSource = objDashboard.GetEventList(objCommon);
            rptrEventList.DataBind();

        }
        catch (Exception)
        {

            throw;
        }
    }
}