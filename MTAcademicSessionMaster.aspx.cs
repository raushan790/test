/*
    Project Name            :   CampusCare
    Client                  :   
    Database                :   SQL Server 2000
    Front-End               :   ASP.NET With C#, Java Script, Ajax
    Reporting Tool          :   Crystal Report 11.0
    Team                    :   Sandhya,Tinu,Ushas,Jitender Kumar
    Tables                  :   MTAcademicSessionMaster
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
using System.Data.SqlClient;

public partial class MTAcademicSessionMaster : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    protected static string strType;
    String varData; 
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
        if ((objCCWeb.ReturnNumericValue("SELECT Count(*) FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuAcademicSession'") == 0) || (objCCWeb.ReturnSingleValue("SELECT ISNULL(VisibleOption,'N') FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuAcademicSession'") == "N"))
        {
            Session.Clear();
            Response.Redirect("Logon.aspx");
            return;
        }
        if (objCCWeb.pCheckText(frmMTAcademicSessionMaster) == true)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
            return;
        }
        if ((Session["Type"] == null) || (Session["Type"].ToString() == "1"))
        {
            strType = "ltr";
        }
        else
        {
            strType = "rtl";
        } 
        if (!IsPostBack)
        {
            hidCache.Value = "";
            gvAcademicSession.Attributes.Add("bordercolor", "#FFC1A4");
            txtAcaSession1.Attributes.Add("onkeypress", "javascript:return Restrict_Pincode(event);");
            txtAcaSession2.Attributes.Add("onkeypress", "javascript:return Restrict_Pincode(event);");
            txtSessionStart.Attributes.Add("onkeypress", "javascript:return Restrict_Date(event);");
            txtSessionEnd.Attributes.Add("onkeypress", "javascript:return Restrict_Date(event);");
            txtAcaSession1.Attributes.Add("onkeyup", "javascript:return f_OnChangeAcademicSession(event);");
            pGetOption();
            txtAcaSession1.Attributes.Add("AutoComplete", "off");
            txtAcaSession2.Attributes.Add("AutoComplete", "off");
            txtSessionEnd.Attributes.Add("AutoComplete", "off");
            txtSessionStart.Attributes.Add("AutoComplete", "off");
            BindDDL();            
        }
    }
    
    protected void pGetOption()
    {
        SqlDataReader rdroption = objCCWeb.BindReader("SELECT NewOption,EditOption,DeleteOption FROM MTUserLimitMaster ULM INNER JOIN MTUserModuleMaster UMM ON ULM.ModuleID=UMM.ModuleID " +
                " WHERE UMM.ModuleID=1 AND MenuName='mnuAcademicSession' AND UID=" + Session["UID"] + "");
        if (rdroption.Read())
        {
            hidCache.Value = rdroption.GetValue(0).ToString() + ";" + rdroption.GetValue(1).ToString() + ";" + rdroption.GetValue(2).ToString();               
        }
        rdroption.Close();
        rdroption.Dispose();
    }
    protected void BindDDL()
    {
        txtAcaSession1.Text = "";
        txtAcaSession2.Text = "";
        txtSessionStart.Text = "";
        txtSessionEnd.Text = "";
        chkShowParentLogin.Checked = false;
        chkPayGatewayFlag.Checked = false;
        txtAcaSession2.ReadOnly = true;
        hidFlag.Value = "^";
        gvAcademicSession.DataSource = objCCWeb.BindDataSet("EXEC spBindGrid 'MTAcademicSessionMaster'");
        gvAcademicSession.DataBind();
        if (Session["Type"] == "2")
        {
            if (gvAcademicSession.Rows.Count > 0)
            {
                for (int intLoop = 0; intLoop < gvAcademicSession.Rows.Count; intLoop++)
                {
                    gvAcademicSession.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    gvAcademicSession.Rows[intLoop].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    gvAcademicSession.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvAcademicSession.Rows[intLoop].Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    gvAcademicSession.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    gvAcademicSession.Rows[intLoop].Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    gvAcademicSession.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    gvAcademicSession.Rows[intLoop].Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    gvAcademicSession.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    gvAcademicSession.Rows[intLoop].Cells[4].HorizontalAlign = HorizontalAlign.Right;
                }
            }
        }
        if (gvAcademicSession.Rows.Count > 0)
        {
            varData = objCCWeb.ReturnSingleValue("DECLARE @varSelected AS VARCHAR(2000); SET @varSelected=''; SELECT @varSelected=@varSelected+'^'+ Caption" + Session["Type"].ToString() + "  " +
                 " FROM MTFormControlMaster WHERE ControlName LIKE 'gvAcademicSession%'  AND FormID=101 ORDER BY PriorityNo  SELECT CASE WHEN LEN(@varSelected)>1  THEN SUBSTRING(@varSelected,1,LEN(@varSelected)) " +
                 " ELSE '0' END AS  GridDetails");
            string[] StrData = varData.ToString().Split('^');
            gvAcademicSession.HeaderRow.Cells[0].Text = StrData[1];
            gvAcademicSession.HeaderRow.Cells[1].Text = StrData[2];
            gvAcademicSession.HeaderRow.Cells[2].Text = StrData[3];
            gvAcademicSession.HeaderRow.Cells[3].Text = StrData[4];
            gvAcademicSession.HeaderRow.Cells[4].Text = StrData[5];
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BindDDL();        
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
            string[] strArray = hidFlag.Value.Split('^');
            string strResult;
            string strShowFlag = "N";
            string PayGatewayFlag="N";
            if (chkShowParentLogin.Checked == true)
                strShowFlag = "Y";
            if(chkPayGatewayFlag.Checked==true)
                PayGatewayFlag="Y";

            if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MTAcademicSessionMaster WHERE AcaStart<" + txtAcaSession1.Text.Trim() + " AND AcaEndDate>" + objCCWeb.ReturnDateorNull(txtSessionStart.Text.Trim())) > 0)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('Existing Academic Session Overlapping')</script>");
                strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "101_1", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('"+strResult+"')</script>");
                return;
            }
            if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MTAcademicSessionMaster WHERE AcaStart>" + txtAcaSession1.Text.Trim() + " AND AcaStartDate<" + objCCWeb.ReturnDateorNull(txtSessionEnd.Text.Trim())) > 0)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('Existing Academic Session Overlapping')</script>");
                strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "101_1", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "')</script>");
                return;
            }
            if (strArray[0] == "N")
            {
                if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MTAcademicSessionMaster WHERE AcaStart='" + txtAcaSession1.Text.Trim() + "'") > 0)
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('Academic Session already Exist')</script>");
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "5",lblAcademicSession1.Text);
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "')</script>");
                    return;
                }

                strResult = objCCWeb.ExecuteQuery("INSERT INTO MTAcademicSessionMaster(AcaStart,AcaStartDate,AcaEndDate,EntryUserID,EntryDate,ShowFlag,PayGatewayFlag) "+
                " VALUES(" + txtAcaSession1.Text.Trim() + "," + objCCWeb.ReturnDateorNull(txtSessionStart.Text.Trim()) + "," + objCCWeb.ReturnDateorNull(txtSessionEnd.Text.Trim()) + ","+
                " " + Session["UID"].ToString() + ",GETDATE(),'" + strShowFlag + "','" + PayGatewayFlag + "')");
                strResult = objCCWeb.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuAcademicSession','Academic Session: " + txtAcaSession1.Text.Trim() + " - " + (Convert.ToInt32(txtAcaSession1.Text.Trim()) + 1) + " ,Is Added')");
            }
            else
            {
                strResult = objCCWeb.ExecuteQuery("UPDATE MTAcademicSessionMaster SET AcaStartDate=" + objCCWeb.ReturnDateorNull(txtSessionStart.Text.Trim()) + ","+
                 "AcaEndDate=" + objCCWeb.ReturnDateorNull(txtSessionEnd.Text.Trim()) + ",UpdateUserID=" + Session["UID"].ToString() + ",UpdateDate=GETDATE(),"+
                 "ShowFlag='" + strShowFlag + "',PayGatewayFlag='" + PayGatewayFlag + "' WHERE AcaStart=" + gvAcademicSession.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text);
                strResult = objCCWeb.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuAcademicSession','Academic Session: " + txtAcaSession1.Text.Trim() + " - " + (Convert.ToInt32(txtAcaSession1.Text.Trim()) + 1) + " ,Is Modified')");

            }
            if (strResult == "")
            {
                if (strArray[0] == "N")
                {
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "1", "");
                }
                else
                {
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "2", "");
                }
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('"+strResult+"')</script>");                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "')</script>");
            }            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + ex.Message + "')</script>");
        }
        BindDDL();
        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string[] strArray = hidFlag.Value.Split('^');
            string strResult;
            if (objCCWeb.ReturnNumericValue("EXEC spGetPrimaryValueExists 'AcaStart','MTAcademicSessionMaster','" + Convert.ToInt32(gvAcademicSession.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + "'") > 0)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('Academic Session Is In Use')</script>");
                strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('"+strResult+"')</script>");
                BindDDL();
                return;
            }
            if (Convert.ToInt32(Session["AcaStart"])==Convert.ToInt32(gvAcademicSession.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text))
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "disp", "<script>alert('Current Session Cannot Be Deleted')</script>");
                strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "101_2", "");
                ClientScript.RegisterStartupScript(this.GetType(), "disp", "<script>alert('"+strResult+"')</script>");
                BindDDL();
                return;
            }
            strResult = objCCWeb.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuAcademicSession','Academic Session: " + txtAcaSession1.Text.Trim() + " - " + (Convert.ToInt32(gvAcademicSession.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + 1) + " ,Is Deleted')");

            strResult = objCCWeb.ExecuteQuery("DELETE FROM MTAcademicSessionMaster WHERE AcaStart=" + gvAcademicSession.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text);
            if (strResult == "")
            {
                strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "3", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayD", "<script language=javascript>alert('"+strResult+"')</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "displayD", "<script language=javascript>alert('Deleted Successfully')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayE", "<script language=javascript>alert('" + strResult + "')</script>");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScriptE", "<script language=javascript>alert('" + ex.Message + "')</script>");
        }
        BindDDL();
    }
    protected void gvAcademicSession_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("ondblclick", "Change_SelectedRow(" + e.Row.RowIndex + ")");
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer';");
        }
        if (e.Row.RowType!=DataControlRowType.EmptyDataRow)
        {
            e.Row.Cells[5].Style.Add("display", "none");
            e.Row.Cells[6].Style.Add("display", "none");
        }        
    }
    protected void btnPrintgrid_Click(object sender, EventArgs e)
    {
        objCCWeb.ExportToExcel(gvAcademicSession, frmMTAcademicSessionMaster, lblAcademicSessionDetails.Text, "Excel");       
    }
}
