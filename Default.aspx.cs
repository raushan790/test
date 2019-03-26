using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    protected static string Caption; 
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (Session["UID"] == null)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
            return;
        }
        int intUserTypeID = objCCWeb.ReturnNumericValue("Select UserTypeiD From  MTUserMaster Where UID=" + Session["UID"] + " ");//AND UserTypeiD NOT in(0,1,4)
        if (intUserTypeID == 3 || intUserTypeID == 2)
        {
            Response.Write("<script>window.open('PlParentLoginForm.aspx','_parent');</script>");
            return;
        }
        if (intUserTypeID == 6)
        {
            string UserID = objCCWeb.ReturnSingleValue("Select Case when UserId like 'SE%' then 'SE' else 'SR' end as UserID  from MTUserMaster Where  UID=" + Session["UID"] + "  AND UserTypeID=6");

            if (UserID == "SE")
            {
                Response.Write("<script>window.open('SRStudentonlineRegistration11.aspx','_parent');</script>");
            }
            else
            {
                Response.Write("<script>window.open('SRStudentonlineRegistration.aspx','_parent');</script>");
            }
           return;
        }
        if (Request.QueryString["Flag"] != null)
        {
            string strQuery = "";
            if (Request.QueryString["Flag"] == "DisplayID")
            {
                strQuery = "Declare @VarMinMark as Varchar(2000);SET @VarMinMark='';  Select @VarMinMark=@VarMinMark+Cast (DisplayID  as varchar)+'^'from MTDisplayMaster  ORDER BY  DisplayID  "+
                  "  Select CASE WHEN LEN(@VarMinMark)>1 THEN SubString(@VarMinMark,1,LEN(@VarMinMark)-1) ELSE '0' END as MinMark";
            }
            if (Request.QueryString["Flag"] == "OutTime")
            {
                strQuery = "UPDATE MDUserLoginDetails SET LoggedOutTime=GETDATE() WHERE LoggedOutTime IS NULL AND SessionDetails='" + Session["UserLogin"] + "'";
            }
            
            string strResult = objCCWeb.ReturnSingleValue(strQuery);
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(strResult);
            Response.End();
        }
        if (!IsPostBack)
        {
            if (Session["CollegeName"] != null)
            {
                Session["CollegeName"] = Session["CollegeName"].ToString().Replace(" ", "&nbsp;");
            }
            else
            {
                Session["CollegeName"] = "Campus Care";
            }
            if (Session["EmployeeID"] == null)
                lnkPortal.Visible = false;
            Session["Date"] = DateTime.Now.Date.ToString("yyyy/MM/dd");

            lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            lblDate.Style.Add("text-align", "right");
            //imgbtnExpand.Attributes.Add("onclick", "javascript:return fResize()");
            btnAbout.Attributes.Add("onmouseover", "javascript:return fMouseOver(this)");
            btnAbout.Attributes.Add("onmouseout", "javascript:return fMouseOut(this)");
            lblUser.Text = "WELCOME " + Session["UserName"].ToString();
            DataList1.DataSource = objCCWeb.BindReader("EXEC  spBindCaption " + Session["SchoolID"] + "," + Session["AcaStart"] + ",'" + DateTime.Now.Date.ToString("yyyy/MM/dd") + "',1," + Session["UID"] + " ");
            DataList1.DataBind();
            ////objCCWeb.FillDDLs(ddlSession, "SELECT AcaStart AS AcaStart,CAST(AcaStart AS VARCHAR)+' - '+CAST(AcaStart+1 AS VARCHAR) AS AcademicSession" +
            ////        " FROM MTAcademicSessionMaster WHERE AcaStart<>0 ORDER BY AcaStart", "AcaStart", "AcademicSession", "");
            objCCWeb.FillDDLs(ddlSchools, "SELECT SchoolID,SchoolName1 AS SchoolName FROM MTInstitutionMaster WHERE SchoolID IN (SELECT SchoolID FROM MTUserInstitutionMaster WHERE UID=" + Convert.ToInt32(Session["UID"]) + ") ORDER BY SchoolName1", "SchoolID", "SchoolName", "");
            if (ddlSchools.Items.Count > 0)
            {
                ddlSchools.Visible = true;
                string q = Session["SchoolID"].ToString();
                ddlSchools.SelectedValue = Session["SchoolID"].ToString();
                q = ddlSchools.SelectedItem.ToString();
            }
            else
                ddlSchools.Visible = false;


            //if (ddlSession.Items.Count > 0)
            //{
            //    ddlSession.Visible = true;
            //    string q = Session["AcaStart"].ToString();
            //    ddlSession.SelectedValue = Session["AcaStart"].ToString();
            //    q = ddlSession.SelectedItem.ToString();
            //}
            //else
            //    ddlSession.Visible = false;

            lblSchoolName.Text = "1";// Session["SchoolName"].ToString();
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["Cache"] != null)
        {
            Cache.Remove(Session["Cache"].ToString());
        }
        objCCWeb.ExecuteQuery("UPDATE MDUserLoginDetails SET LoggedOutTime=GETDATE() WHERE  LoggedOutTime IS NULL AND  SessionDetails='" + Session["UserLogin"] + "'");
        Session.Clear();
        Response.Redirect("Logon.aspx");        
    }

    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["AcaStart"] = ddlSession.SelectedValue.ToString();
        //Session["AcademicSession"] = ddlSession.SelectedItem.ToString();
        Session["SchoolName"] = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(SchoolName1),'Campus Care') FROM MTInstitutionMaster WHERE SchoolID=" + Session["SchoolID"] + "") + " :: " + Session["AcademicSession"];
        Session["Date"] = DateTime.Now.Date.ToString("yyyy/MM/dd");
        //string q = ddlSession.SelectedValue.ToString() + " ---------- " + ddlSession.SelectedItem.ToString();
        //ddlSession.SelectedValue = Session["AcaStart"].ToString();
        Response.Redirect("Default.aspx");
    }
    protected void ddlSchools_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SchoolID"] = ddlSchools.SelectedValue.ToString();
        Session["SchoolName"] = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(SchoolName),'Campus Care') FROM MTInstitutionMaster WHERE SchoolID=" + Session["SchoolID"] + "") + " :: " + Session["AcademicSession"];
        //ddlSchools.SelectedValue = Session["SchoolID"].ToString();
        Response.Redirect("Default.aspx");
    }
    protected void FillGridLoad()
    {
        // gvDisplayCaption.DataSource = objCCWeb.BindReader("EXEC [spSISchoolStrength] '2010','',0,1 ,1,1 ");
        //gvDisplayCaption.DataBind();

    }
    //protected void btnBind_Click(object sender, EventArgs e)
    //{
    //    ////gvDisplayCaption.DataSource = objCCWeb.BindReader("EXEC [spSISchoolStrength] '2010','',0,1 ,1,1 ");
    //    ////gvDisplayCaption.DataBind();
    //    ////Response.Redirect("MTDashBoardDetails.aspx");
    //   //Response.Write("<script>window.popen('MTDashBoardDetails.aspx','_parent',);</script>");
    //    string []strArray = hidFlag.Value.Split('^');

       
       

    //}
    protected void gvDisplayCaption_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowIndex > -1)
        //{
            e.Row.Attributes.Add("ondblclick", "fGridDoubleClick(" + e.Row.RowIndex + ")");
            e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
        //}
    }


    protected void lnkPortal_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffLoginForm.aspx");
    }
}