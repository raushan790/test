using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Globalization;
using System.Data.SqlClient;

public partial class Event : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();

    protected static ArrayList alSelectDate = new ArrayList();
    protected static ArrayList alHolidayDays = new ArrayList();
    CultureInfo CInfo = new CultureInfo("hi-IN");
    protected int intRowIndex;
    protected string EditOption;
    protected DateTime dtDate;
    protected int intMonth;
    protected DateTime dtDate1;
    protected int intMonth1;
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetNoStore();
        Response.AddHeader("Cache-control", "no-store,must-revalidate,private,no-cache,no-store,pre-check=0,post-check=0,max-stale=0");
        Response.AddHeader("Pragma", "no-cache");
        Response.AddHeader("Expires", "0");

        if (Session["UID"] == null || Session["SchoolID"] == null)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_Parent');</script>");
            return;
        }
        if ((objCCWeb.ReturnNumericValue("SELECT Count(*) FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=26 AND MenuName='mnuEventAssigner'") == 0) || (objCCWeb.ReturnSingleValue("SELECT ISNULL(VisibleOption,'N') FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=26 AND MenuName='mnuEventAssigner'") == "N"))
        {
            Session.Clear();
            Response.Redirect("Logon.aspx");
            return;
        }
        if (objCCWeb.pCheckText(form1) == true)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
            return;
        }
        if (Request.QueryString["StrQuery"] != null)
        {
            string strResult = "";
            string strQuery = "";
            if (Request.QueryString["StrQuery"] == "Event")
            {
                strQuery = " EXEC spEvent '" + objCCWeb.ChangeYYYYMMDD(Request.QueryString["Value"].ToString()) + "'";
            } 
            SqlDataReader sqlRdr = objCCWeb.BindReader(strQuery);
            while (sqlRdr.Read())
            {
                for (int intForLoop = 0; intForLoop < sqlRdr.FieldCount; intForLoop++)
                {
                    strResult = strResult + sqlRdr.GetValue(intForLoop).ToString() + "^";
                }
                if (strResult != "") strResult = strResult.Remove(strResult.Length - 1);
                strResult = strResult + "~";
            }

            if (strResult != "") strResult = strResult.Remove(strResult.Length - 1);
            sqlRdr.Close();
            sqlRdr.Dispose();
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(strResult);
            Response.End();
        }
        if (Request.QueryString["ControlID"] != null)
        {
            string strResult = "";
            string strQuery = "";
            string strControl = Request.QueryString["ControlID"].ToString();
            if (strControl == "chkClassSection")
            {
                strQuery = "SELECT ClassID,ClassName,EventClassID From(select DISTINCT CM.PriorityNo, CAST(CM.ClassID AS NVARCHAR)+'^'+CAST(SM.SectionID AS NVARCHAR) AS ClassID,CM.ClassName1+'-'+SM.SectionName1 AS ClassName,ISNULL(CAST(ECD.ClassID AS NVARCHAR)+'^'+CAST(ECD.SectionID AS NVARCHAR),'') AS EventClassID " +
                " FROM SISTudentYearWiseDetails SYD  " +
                " INNER JOIN MTClassMaster CM On SYD.ClassID= CM.ClassID  " +
                " INNER JOIN MTSectionMAster SM ON SYD.SectionID= SM.SectionID  " +
                " LEFT JOIN EventClassDetail ECD ON ECD.classID=SYD.ClassID AND ECD.SectionID=SYD.SectionID " +
                " AND ECD.EventID IN(SELECT Top 1 EventID From EventMaster Where EventDate='" + objCCWeb.ChangeYYYYMMDD(Request["Value"].ToString()) + "') " +
                " WHERE SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + Session["AcaStart"] + " AND  CM.PriorityNo<>0)SUB  ORDER BY PriorityNo";
            }
            
            SqlDataReader rdrVal = objCCWeb.BindReader(strQuery);
            while (rdrVal.Read())
            {
                strResult = strResult + rdrVal.GetValue(0).ToString() + "," + rdrVal.GetValue(1).ToString() + "," + rdrVal.GetValue(2).ToString() + "~";
            }
            if (strResult != "") strResult = strResult.Remove(strResult.Length - 1);

            rdrVal.Close();
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(strResult);
            Response.End();
        }
        if (Request.QueryString["Flag"] != null)
        {
            string strQuery = "";
             if (Request.QueryString["Flag"] == "Report")
            {
                    strQuery = "DECLARE @Var nvarchar(200) SET @Var=''  "+
                       " Select  @Var=@Var+  Class+',' From ( SELECT Distinct CAST(ECD.ClassID AS NVARCHAR)+'^'+CAST(ECD.SectionID AS NVARCHAR) AS Class "+
                       " FROM SISTudentYearWiseDetails SYD  "+
                       " INNER JOIN EventClassDetail ECD ON ECD.classID=SYD.ClassID AND ECD.SectionID=SYD.SectionID "+
                       " AND ECD.EventID IN(SELECT Top 1 EventID From EventMaster "+
                       " Where EventDate='" + objCCWeb.ChangeYYYYMMDD(Request.QueryString["Value"].ToString()) + "'))SUB " +
                       " SELECT CASE WHEN LEN(@Var )>1  THEN SUBSTRING(@Var,1,LEN(@Var)-1) ELSE '' END";
            }
             
            string strResult = objCCWeb.ReturnSingleValue(strQuery);
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(strResult);
            Response.End();
        }
        if (!IsPostBack)
        {
            hidCache.Value = ""; 
            gvEventDetails.Attributes.Add("bordercolor", "#FFC1A4");
            btnSelectAll.Attributes.Add("onclick", "javascript:return fClassSubject(1);");
            btnDeSelect.Attributes.Add("onclick", "javascript:return fClassSubject(0);");
            chkClassSection.Attributes.Add("oncontextmenu", "javascript:return fSelectDeSelect(event)");
            btnDoubleClick_Click(sender, e);
            ClientScript.RegisterStartupScript(this.GetType(), "dis", "<script language=javascript>fBindCheckBoxList('chkClassSection','" + DateTime.Now.ToString("dd/MM/yyyy") + "');</script>");
            //fBindCheckBoxList('chkClassSection',varDate);
        }
        pGetOption();
    }
    protected void pGetOption()
    { 
        hidCache.Value = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(EDITOPTION),'N') FROM MTUserLimitMaster " +
              " WHERE ModuleID=26 AND MenuName='mnuEventAssigner' AND UID=" + Convert.ToInt32(Session["UID"]));
    } 
    protected void btnClose_Click(object sender, EventArgs e)
    {
        hidCache.Value = "";
        Response.Redirect("MainForm.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult = string.Empty;
            string strVal = "";
            List<string> lstQuery = new List<string>();
            string strEventID = "";
            string strClassID="";
            string strSectionID="";
            string strDate = txtDate.Text.Trim();
            string[] strClassSectionID = txtClassSection.Text.Trim().ToString().Split('~');
            strEventID = objCCWeb.ReturnSingleValue("SELECT EventID From EventMaster Where EventDate='" + objCCWeb.ChangeYYYYMMDD(strDate) + "'");

            if (strEventID == "")
            {
                strEventID = objCCWeb.ReturnSingleValue("SELECT ISNULL(Max(EventID),0)+1 From EventMaster");  
            }
            lstQuery.Add("Delete from EventMaster where EventID=" + strEventID + "");
            //lstQuery.Add("Delete from eventclassDetail where EventID=" + strEventID + "");
            //lstQuery.Add("Delete from EventDetail where EventID=" + strEventID + "");

            lstQuery.Add("INSERT INTO EventMaster (EventID,EventDate,EntryUID,EntryDate) Values(" + strEventID + ",'" + objCCWeb.ChangeYYYYMMDD(strDate) + "'," + Session["UID"] + ",getdate())");

            for (int intLoop = 0; intLoop < strClassSectionID.Length-1; intLoop++)
            {
                strClassID = strClassSectionID[intLoop].Split('^')[0];
                strSectionID = strClassSectionID[intLoop].Split('^')[1];
                lstQuery.Add("INSERT INTO eventclassDetail (EventID,ClassID,SectionID) Values(" + strEventID + ",'" + strClassID + "','" + strSectionID + "')");
            }
            for (int intRow = 0; intRow < gvEventDetails.Rows.Count; intRow++)
            {
                string strTime = Request.Form[gvEventDetails.Rows[intRow].UniqueID + "$txtTime"].Trim().Replace("'", "''");
                string strEventSubject = Request.Form[gvEventDetails.Rows[intRow].UniqueID + "$txtEventSubject"].Trim().Replace("'", "''");
                string strVenue = Request.Form[gvEventDetails.Rows[intRow].UniqueID + "$txtVenue"].Trim().Replace("'", "''");
                string strDescription = Request.Form[gvEventDetails.Rows[intRow].UniqueID + "$txtDiscription"].Trim().Replace("'", "''");
                lstQuery.Add("INSERT INTO EventDetail (EventID,EventTime,EventSubject,Venue,Discription) " +
                    " Values(" + strEventID + ",'" + strTime + "','" + strEventSubject + "','" + strVenue + "','" + strDescription + "')");

            }
            strResult = objCCWeb.ExecuteQueryList(lstQuery);
             
            if (strResult == "")
            {
                btnDoubleClick_Click(sender, e);
                ClientScript.RegisterStartupScript(this.GetType(), "displaySave", "<script language=javascript> alert('Saved Successfully');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "disError", "<script language=javascript>alert('" + strResult + "')</script>");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + ex.Message + "')</script>");
        }

    }
    protected void calDetails_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Cell.ID = "Cell." + e.Day.Date.ToString("dd.MM.yyyy");
        e.Cell.Attributes.Add("ondblclick", "javascript:return f_ValidateCalender(event,'" + e.Day.Date.ToString("dd/MM/yyyy") + "')");
        e.Cell.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
        if (e.Day.Date.DayOfWeek.ToString() == "Sunday")
        {
            e.Cell.BackColor = System.Drawing.Color.#f3f1ee;
        }
        if (objCCWeb.ReturnNumericValue("SELECT Count(*) From EventMaster Where EventDate='" + objCCWeb.ChangeYYYYMMDD(e.Day.Date.ToString("dd/MM/yyyy")) + "'") > 0)
        {
            e.Cell.BackColor = System.Drawing.Color.Purple;
        }  
    }
    protected void calDetails_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        hidCells.Value = ""; 
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    { 
        dtDate1 = calDetails.VisibleDate.Year != 1 ? calDetails.VisibleDate.Date : DateTime.Today.Date;
        intMonth1 = dtDate1.Month; 
        Session["Formula"] = dtDate1.Month + "^" + dtDate1.Year; ;
        Session["Check"] = "CalendarDetails";
        Session["Option"] = "1";
        Response.Redirect("SIReports.aspx"); 
    }
    protected void btnExport_Click(object sender, EventArgs e)
    { 
        dtDate1 = calDetails.VisibleDate.Year != 1 ? calDetails.VisibleDate.Date : DateTime.Today.Date;
        objCCWeb.ExportToExcel(gvEventDetails, form1, "Event Details For " + dtDate1.ToString("MMMM") + " - " + dtDate1.Year, "Excel");
   }
     
    protected void btnDoubleClick_Click(object sender, EventArgs e)
    {
        try
        {
            string strDate=DateTime.Today.ToString("dd/MM/yyyy");
            txtDate.Text = strDate;
            int checkedClasses = 0;
            
            SqlDataReader rdr = objCCWeb.BindReader("Select DISTINCT CM.PriorityNo, CAST(CM.ClassID AS NVARCHAR)+'^'+CAST(SM.SectionID AS NVARCHAR) AS ClassID,CM.ClassName1+'-'+SM.SectionName1 " +
                " AS ClassName, ISNULL(CAST(ECD.ClassID AS NVARCHAR)+'^'+CAST(ECD.SectionID AS NVARCHAR),'') AS EventClass    " +
                " FROM SISTudentYearWiseDetails SYD  " +
                " INNER JOIN MTClassMaster CM On SYD.ClassID= CM.ClassID  " +
                " INNER JOIN MTSectionMAster SM ON SYD.SectionID= SM.SectionID  " +
                " LEFT JOIN EventClassDetail ECD ON ECD.classID=SYD.ClassID AND ECD.SectionID=SYD.SectionID " +
                " AND ECD.EventID IN(SELECT Top 1 EventID From EventMaster Where EventDate='" + objCCWeb.ChangeYYYYMMDD(strDate) + "') " +
                " WHERE SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + Session["AcaStart"] + " AND  CM.PriorityNo<>0  ORDER BY CM.PriorityNo");


            chkClassSection.Items.Clear();
            while (rdr.Read())
            {
                chkClassSection.Items.Add(new ListItem(rdr.GetValue(2).ToString(), rdr.GetValue(1).ToString()));
                if (rdr.GetValue(3).ToString() != "")
                {
                  chkClassSection.Items[chkClassSection.Items.Count-1].Selected=true; 
                }
            }

             

            rdr.Close();
            rdr.Dispose(); 


            gvEventDetails.DataSource = objCCWeb.BindDataSet(" EXEC spEvent '" + objCCWeb.ChangeYYYYMMDD(strDate) + "'");
            gvEventDetails.DataBind(); 

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayFill", "<script language=javascript>alert('" + ex.Message + "')</script>");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strDate = txtDate.Text.Trim();
            string strEventID = "";
            strEventID = objCCWeb.ReturnSingleValue("SELECT EventID From EventMaster Where EventDate='" + objCCWeb.ChangeYYYYMMDD(strDate) + "'");
            string strResult = objCCWeb.ReturnSingleValue("Delete from EventMaster where EventID=" + strEventID + "");

            if (strResult == "")
            {
                btnDoubleClick_Click(sender, e);
                ClientScript.RegisterStartupScript(this.GetType(), "displaySave", "<script language=javascript> alert('Deleted Successfully');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "disError", "<script language=javascript>alert('" + strResult + "')</script>");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disError", "<script language=javascript>alert('" + ex.Message.ToString() + "')</script>");
        }
    }
}

