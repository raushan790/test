using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SchoolOnline;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class SchoolOnline_uc_NewsEvent : System.Web.UI.UserControl
{
    protected CultureInfo cinfo = new CultureInfo("hi-IN");
    dalCommon objCommon;
    dalDashboard objDashboard;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetNewsEventList();
    }
    protected void GetNewsEventList()
    {
        objCommon = new dalCommon();
        objDashboard = new dalDashboard();
        objCommon.AcaStart = Session["AcaStart"].ToString();
        objCommon.SchoolId = Session["SchoolID"].ToString();
        objCommon.StudEmp = Session["StudentID"].ToString();
        objCommon.strDate = DateTime.Now.Date.ToString("yyyy/MM/dd");
        DataTable dt = new DataTable();


        try
        {
            //dt.Load(objDashboard.GetNewsAndEventList(objCommon));
            //if (dt.Rows.Count > 0)
            //{
            rptrNewsEventList.DataSource = objDashboard.GetNewsAndEventList(objCommon);
            rptrNewsEventList.DataBind();
            //}
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            objCommon = null;
            objDashboard = null;
        }
    }


    protected void rptrNewsEventList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hdd;
        Image imgEvent = new Image();
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            hdd = new HiddenField(); 
            hdd = (HiddenField)e.Item.FindControl("hdnNewsAttachment");
            imgEvent = (Image)e.Item.FindControl("imgEvent");
            if (!File.Exists(Server.MapPath("../News") + "/" + hdd.Value + ""))
            {
                imgEvent.Visible = false;
            }
            else
            {
                if( hdd.Value.Split('.')[hdd.Value.Split('.').Length-1].ToUpper()=="PDF")
                imgEvent.ImageUrl = "~/News/pdf.JPG";
            }
        }
    }
}
