using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class VisitorForm : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    CCUserFunc objUserFunc = new CCUserFunc();
    
    //protected int AcaSession = 0;
    protected string VisitorNo = "";
    protected string SchoolName = "";
    protected string Address1 = "";
    protected string Address2 = "";
    protected string Phone = "";
    protected string Email = "";
    protected string VisitPurpose = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (Session["AcaStart"] == null)
            Response.Redirect("Logon.aspx");

        if (Request["VisitorNo"] != null && Request["VisitorNo"] != "")
        {
            VisitorNo = Request["VisitorNo"].ToString();
            fillVisitorDetails();
           
            return;
        }
        else
        {
            fillVisitorDetails();
        }
    }

    protected void fillVisitorDetails()
    {
        try
        {
            //AcaSession = Convert.ToInt32(Session["AcaStart"].ToString());

            SqlDataReader sqlReader = objCCWeb.BindReader("Select VisitorNo,VisitorName,FOM.address,contactNo,Personcontact,Purpose,VisitorIcardNo,rtrim(RIGHT(CONVERT(VARCHAR,INTime,100),7)) AS VisitorTime,CONVERT(VARCHAR,InTime,104) AS Date,schoolname1,MTM.Address ,telephone,Email,emblem  FROM FOMVisitorDetail FOM " +
                "LEFT JOIN FOMPurposeMAster PM ON FOM.PurposeID=PM.PurposeID " +
                "LEFT JOIN MTClientCompany MTM on  FOM.SchoolID=MTM.SchoolID" +
                 " where VisitorNo=" + VisitorNo + " and FOM.Acastart=" + Session["AcaStart"].ToString() + " and MTM.schoolID=" + Session["SchoolID"].ToString() + " ");

            if (sqlReader.HasRows)
            {
                sqlReader.Read();

                OVisitorNo.Text = ": " + sqlReader.GetValue(0).ToString();
                OVName.Text = ": " + sqlReader.GetValue(1).ToString();
                OVaddresss.Text = ": " + sqlReader.GetValue(2).ToString();
                OVContactNo.Text = ": " + sqlReader.GetValue(3).ToString();
                ONameOff.Text = ": " + sqlReader.GetValue(4).ToString();
                VisitPurpose = ": " + sqlReader.GetValue(5).ToString();
                //OPurVisit.Text = ": " + sqlReader.GetValue(5).ToString();
                OVIcard.Text = ": " + sqlReader.GetValue(6).ToString();
                OvInDateTime.Text = ": " + sqlReader.GetValue(7).ToString() + " / " + sqlReader.GetValue(8).ToString();

                SchoolName = sqlReader.GetValue(9).ToString();
                Address1 = sqlReader.GetValue(10).ToString();
                if (sqlReader.GetValue(11).ToString().Trim() != "")
                    Phone += "Contact No:" + sqlReader.GetValue(11).ToString();
                if (sqlReader.GetValue(12).ToString().Trim() != "")
                    Email = "E-Mail:" + sqlReader.GetValue(12).ToString();

                string image = "LoadImage.aspx?TypeName=InstitutionEmblem&SchoolID=" + Session["SchoolID"].ToString() ;
                OSchoolImage.ImageUrl = image;
               
            }
            sqlReader.Close();
            sqlReader.Dispose();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\">window.close();</script>");
        }
    }

   
}





