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

public partial class MonthControl : System.Web.UI.UserControl
{
    
    protected string strbtnDownYear ="";
    protected  string strbtnDownMonth = "";
    protected  string strbtnUpYear = "";
    protected  string strbtnUpMonth = "";
    protected  string strtxtYear = "";
    protected  string strtxtFinMonth = "";
    protected  string strhdnDate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFinMonth.Attributes.Add("autocomplete", "off");
            txtYear.Attributes.Add("autocomplete", "off");
            strbtnDownYear = btnDownYear.ClientID;
            strbtnDownMonth = btnDownMonth.ClientID;
            strbtnUpYear = btnUpYear.ClientID;
            strbtnUpMonth = btnUpMonth.ClientID;
            strtxtYear = txtYear.ClientID;
            strtxtFinMonth = txtFinMonth.ClientID;
            strhdnDate = Date.ClientID;
            btnUpYear.Attributes.Add("onclick", "javascript:return ChangeYearValue('UP','Year','" + txtYear.ClientID + "')");
            btnDownYear.Attributes.Add("onclick", "javascript:return ChangeYearValue('DOWN','Year','" + txtYear.ClientID + "')");
            btnUpMonth.Attributes.Add("onclick", "javascript:return ChangeYearValue('UP','Month','" + txtFinMonth.ClientID + "')");
            btnDownMonth.Attributes.Add("onclick", "javascript:return ChangeYearValue('DOWN','Month','" + txtFinMonth.ClientID + "')");
           // txtYear.Text = DateTime.Now.Year.ToString();
           // txtFinMonth.Text = DateTime.Today.ToString("MMMM");
            if (Session["ParentMonth"] == null)
            {
                txtYear.Text = DateTime.Now.Year.ToString();
                txtFinMonth.Text = DateTime.Today.ToString("MMMM");
            }
            else
            {
                string[] strDate = Session["ParentMonth"].ToString().Split('-');
                txtYear.Text = strDate[2];
                txtFinMonth.Text = strDate[1];
                Session["ParentMonth"] = null;
            }
            Date.Value = "15 " + txtFinMonth.Text + " " + txtYear.Text;
        }
    }
}
