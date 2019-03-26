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

public partial class NewGuideLine : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    CCUserFunc objUserFunc = new CCUserFunc();
    protected string SchoolName = "";
    protected string Address1 = "";
    protected string Address2 = "";
    protected string Telephone = "";
    protected string strImage = "";

    protected static string strType;

    protected void Page_Load(object sender, EventArgs e)
    {
        fillEnquiryDetails();
    }
    protected void fillEnquiryDetails()
    {
        try
        {


            SqlDataReader sqlRdr = objCCWeb.BindReader("SELECT   MIM.SchoolID, ISNULL(MIM.SchoolName1,''),ISNULL(MIM.Address,''), ISNULL(MIM.Telephone,'')" +
                                   "  From MTClientCompany MIM  " +
                                " WHERE  MIM.SchoolID=1");
            if (sqlRdr.Read())
            {

                string image = "LoadImage.aspx?TypeName=InstitutionEmblem&SchoolID=" + sqlRdr.GetValue(0).ToString();
                OSchoolImage.ImageUrl = image;

                SchoolName = sqlRdr.GetValue(1).ToString();
                Address1 = sqlRdr.GetValue(2).ToString();
                Address2 = "Phone: " + sqlRdr.GetValue(3).ToString();
            }
            sqlRdr.Close();
            sqlRdr.Dispose();

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\">window.close();</script>");
        }

    }
  protected void lnkExists_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logon.aspx");
    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("SRStudentonlineRegistration.aspx");
    }
    
}