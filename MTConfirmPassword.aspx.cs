/*
    Project Name            :   CampusCare
    Client                  :   
    Database                :   SQL Server 2000
    Front-End               :   ASP.NET With C#, Java Script, Ajax
    Reporting Tool          :   Crystal Report 11.0
    Team                    :   Sandhya,Tinu,Ushas,Jitender Kumar
    Tables                  :   MTUserMaster
    Procedures              :   spBindGrid
    Page Created            :   Tinu  
    Codes                   :   Tinu
    Testing & Modification  :   Jitender Kumar
    Remarks                 :      
*/
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
public partial class MTConfirmPassword : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    protected static string strType;
    protected string strUserID;
    string strMenuName;
    int intCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["MenuName"] != null)
        {
            strMenuName = Request.QueryString["MenuName"].ToString();
        }
        if ((Session["Type"] == null) || (Session["Type"].ToString() == "1"))
        {
            strType = "ltr";
        }
        else
        {
            strType = "rtl";
        } 
        if (Session["UID"] == null)
        {
            Response.Write("<script language='javascript'> window.close();window.open('Logon.aspx','_parent');</script>");
        }
        if (!IsPostBack)
        {
            txtPassword.Focus();
            //pDisplayType();
        }
    }
 
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string strCPwd = objCCWeb.ReturnSingleValue("SELECT UserPassword FROM MTUserMaster WHERE UID=" + Session["UID"]);
        if (strCPwd != FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "SHA1"))
        {
            intCount = intCount + 1;
            if (intCount <= 3)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "disp", "<script>alert('Incorrect Password');</script>");
                string strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "128_1", "");
                ClientScript.RegisterStartupScript(this.GetType(), "disp", "<script>alert('"+strResult+"');</script>");
            }
            else
            {
                Response.Redirect("~/MainForm.aspx");
            }
            txtPassword.Focus();
        }
        else
        {
            Session["ConfirmPassword"] = "OK";
            Response.Redirect(strMenuName);
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainForm.aspx");
    }

}
