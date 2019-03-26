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

public partial class LoadImage : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["TypeName"] != null)
            {
                string srtTypeID;
                if (Request.QueryString["TypeName"] == "InstitutionEmblem")
                {
                    SqlDataReader rdrImage = objCCWeb.BindReader("SELECT ISNULL(Emblem,'') AS Emblem,ISNULL(EmblemLength,0) AS EmblemLength FROM MTClientCompany where SchoolID=" + Request.QueryString["SchoolID"].ToString() + "");
                    if (rdrImage.Read())
                    {
                        if (Convert.ToInt32(rdrImage.GetValue(1).ToString()) > 0)
                        {
                            int intLength = (int)Convert.ToInt32(rdrImage.GetValue(1).ToString());
                            byte[] image = new byte[intLength];
                            image = (byte[])rdrImage["Emblem"];
                            Response.BinaryWrite(image);
                        }

                    }
                    rdrImage.Close();
                    rdrImage.Dispose();
                }
                if (Request.QueryString["TypeName"] == "GroupCompany")
                {
                    srtTypeID = Request.QueryString["TypeID"].ToString();
                    SqlDataReader rdrImage1 = objCCWeb.BindReader("SELECT ISNULL(Emblem,'') AS Logo,CAST(EmblemLength AS INT) AS LogoLength FROM FAGroupCompanyMaster WHERE FAGroupCompanyID=" + srtTypeID);
                    if (rdrImage1.Read())
                    {
                        int intLength = (int)rdrImage1["LogoLength"];
                        byte[] image = new byte[intLength];
                        image = (byte[])rdrImage1["Logo"];
                        Response.BinaryWrite(image);
                    }
                    rdrImage1.Close();
                    rdrImage1.Dispose();
                }
                if (Request.QueryString["TypeName"] == "Company")
                {
                    srtTypeID = Request.QueryString["TypeID"].ToString();
                    SqlDataReader rdrImage2 = objCCWeb.BindReader("SELECT ISNULL(Emblem,'') AS Logo,CAST(EmblemLength AS INT) AS LogoLength FROM FACompanyMaster WHERE FACompanyID=" + srtTypeID );
                    if (rdrImage2.Read())
                    {
                        int intLength = (int)rdrImage2["LogoLength"];
                        byte[] image = new byte[intLength];
                        image = (byte[])rdrImage2["Logo"];
                        Response.BinaryWrite(image);
                    }
                    rdrImage2.Close();
                    rdrImage2.Dispose();
                }
            }
            
        }
    }
}
