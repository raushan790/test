using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class ReportGroupMaster : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    protected static string strNewOption;
    protected static string strEditOption;
    protected static string strDeleteOption;
    protected static string strType;
    String varData;
    protected static string strHideID = "document.getElementById('divSelectDeSelect').style.display='none';document.getElementById('trReportGroup').style.display='none';";
    protected static string strHideInput = "";
    //protected static string strHideID = " document.getElementById('trReportGroup').style.display='none';" +
    //    "if (document.getElementById('gvReportGroup')!=null){if (document.getElementById('gvReportGroup').rows.length>1) {for(var intForLoop=0;intForLoop<document.getElementById('gvReportGroup').rows.length;intForLoop++)" +
    //        " {  document.getElementById('gvReportGroup').rows[intForLoop].cells[1].style.display='none'; " +
    //       // " document.getElementById('gvReportGroup').rows[intForLoop].cells[4].style.display='none'; "  +
    //        "document.getElementById('divSelectDeSelect').style.display='none';}}}";

    //protected static string strHidepriority = "if(document.getElementById('gvReportGroup')!=null) " +
    //                               " if(document.getElementById('gvReportGroup').rows.length>1) " +
    //                               "  for(var varLoop= 0 ; varLoop<document.getElementById('gvReportGroup').rows.length;varLoop++) { " +
    //                               " document.getElementById('gvReportGroup').rows[varLoop].cells[5].style.display='none'; }";

    protected void Page_Load(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script language='javascript'>" + strHideID + "</script>");
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

        if ((objCCWeb.ReturnNumericValue("SELECT Count(*) FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuReportGroupMaster'") == 0) || (objCCWeb.ReturnSingleValue("SELECT ISNULL(VisibleOption,'N') FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuReportGroupMaster'") == "N"))
        {
            Session.Clear();
            Response.Redirect("Logon.aspx");
            return;
        }
        if (objCCWeb.pCheckText(frmReportGroupMaster) == true)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_Parent');</script>");
            return;
        }
        if ((Session["Type"] == null) || (Session["Type"].ToString() == "1"))
        {
            strType = "ltr";
        }
        else
        {
            strType = "rtl";
            pnlClassSection.HorizontalAlign = HorizontalAlign.Right;
        }
        if (!IsPostBack)
        {
            hidCache.Value = "";
            pGetOption();
            gvReportGroup.Attributes.Add("bordercolor", "#FFC1A4");
            txtReportGroupName1.Attributes.Add("onkeypress", "javascript:return Restrict_Name(event)");
            txtReportGroupName2.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event)");
            txtpriority.Attributes.Add("onkeypress", "javascript:return Restrict_Priority(event)");
            txtReportGroupName2.Style.Add("text-align", "right");
            txtReportGroupName1.Attributes.Add("AutoComplete", "off");
            txtReportGroupName2.Attributes.Add("AutoComplete", "off");
            gvReportGroup.Attributes.Add("onkeypress", "javascript:return searchName(event,'gvReportGroup',2)");
            objCCWeb.FillDDLs(ddlModuleID, "SELECT 0 AS ModuleID,'' AS ModuleName" + Session["Type"] + " UNION Select Distinct MTRM.ModuleID,MTUMM.ModuleNAME From MTReportMaster MTRM Inner JOIN MTUserModuleMaster MTUMM ON MTRM.ModuleID=MTUMM.ModuleID  WHERE MTRM.ModuleID>'0'  ORDER BY ModuleID ", "ModuleID", "ModuleName" + Session["Type"].ToString() + "", "");
            
            //objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID>0 ORDER BY ReportID, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");
          
                btnCancel_Click(sender, e);
          
            //pDisplayType();
            gvReportGroup.EmptyDataText = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "1023", "");
            btnSelectAll.Attributes.Add("onclick", "javascript:return fClassSubject(1);");
            btnDeSelect.Attributes.Add("onclick", "javascript:return fClassSubject(0);");
            chkReportName.Attributes.Add("oncontextmenu", "javascript:return fSelectDeSelect(event)");
            if (ddlModuleID.Items.Count > 0)
            {
                ddlModuleID.Items[0].Text = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "6", lblReportModuleID.Text);
            }
           
            ClientScript.RegisterStartupScript(this.GetType(), "DisplayScript", "<script language='javascript'>" + strHideID + "</script>");
            chkReportName.Items.Add(new ListItem("", ""));

        }

    }
   
    protected void pGetOption()
    {
        try
        {
            SqlDataReader rdrOption = objCCWeb.BindReader("SELECT ISNULL(MAX(NewOption),'N'),ISNULL(MAX(EditOption),'N'),ISNULL(MAX(DeleteOption),'N') FROM MTUserLimitMaster " +
                                      "WHERE ModuleID=1 AND MenuName='mnuReportGroupMaster' AND UID=" + Session["UID"] + "");
            if (rdrOption.Read())
            {
                hidCache.Value = rdrOption.GetValue(0).ToString() + ";" + rdrOption.GetValue(1).ToString() + ";" + rdrOption.GetValue(2).ToString(); 
                //strNewOption = rdrOption.GetValue(0).ToString();
                //strEditOption = rdrOption.GetValue(1).ToString();
                //strDeleteOption = rdrOption.GetValue(2).ToString();
            }
            rdrOption.Close();
            rdrOption.Dispose();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>" + strHideID + "alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //objCCWeb.FillCheckedBoxList(chkReportName, "SELECT CM.PriorityNo,CAST(CM.ClassID AS NVARCHAR)+'^'+CAST(SM.SectionID AS NVARCHAR) AS ModuleIDID,ClassName" + Session["Type"] + "+' # '+SM.SectionName" + Session["Type"] + " AS ModuleIDName" + Session["Type"] + " FROM MTClassMaster CM " +
        //    " INNER JOIN SIStudentYearWiseDetails SYWD ON CM.ClassID=SYWD.ClassID INNER JOIN MTSectionMaster SM ON SYWD.SectionID=SM.SectionID WHERE SYWD.AcaStart=" + Session["AcaStart"] + " AND  SYWD.SchoolID=" + Session["SchoolID"] + " GROUP BY CM.PriorityNo,CM.ClassID,SM.SectionID,CM.ClassName" + Session["Type"] + ",SM.SectionName" + Session["Type"] + " ORDER BY CM.PriorityNo", "ModuleIDID", "ModuleIDName" + Session["Type"] + "", ""); 
        chkReportName.Items.Clear();
        //chkReportName.Items.Add(new ListItem("", ""));
        //if (ddlModuleID.SelectedValue == "0")
        //{
        //    objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID<>0 ORDER BY ReportName" + Session["Type"] + "", "ReportID", "ReportName" + Session["Type"] + "", " ");
        //}
        //else
        //{
        //    objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID<>0 AND  ModuleID="+ddlModuleID.SelectedValue+" ORDER BY ReportName" + Session["Type"] + "", "ReportID", "ReportName" + Session["Type"] + "", " ");

        //}
        //    for (int i = 0; i < chkReportName.Items.Count; i++)
        //    {
        //        if (chkReportName.Items[i].Selected == true)
        //        {
        //            chkReportName.Items[i].Selected = false;
        //        }
        //    }

        txtReportGroupName1.Text = "";
        txtReportGroupName2.Text = "";
        txtpriority.Text = "";
        ddlModuleID.SelectedValue = "0";
        hidFlag.Value = "";
        hdnVal.Value = "";
        gvReportGroup.DataSource = objCCWeb.BindReader("EXEC [spBindGridReportGroup] 'MTReportGroupMaster','" + Session["Type"] + "'");
        gvReportGroup.DataBind();
       
       if (Session["Type"] == "2")
        {
            if (gvReportGroup.Rows.Count > 0)
            {
                for (int intLoop = 0; intLoop < gvReportGroup.Rows.Count; intLoop++)
                {
                    gvReportGroup.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    gvReportGroup.Rows[intLoop].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    gvReportGroup.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    gvReportGroup.Rows[intLoop].Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    gvReportGroup.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                    gvReportGroup.Rows[intLoop].Cells[3].HorizontalAlign = HorizontalAlign.Left;
                    gvReportGroup.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                    gvReportGroup.Rows[intLoop].Cells[5].HorizontalAlign = HorizontalAlign.Right;

                }
            }
        }
        if (gvReportGroup.Rows.Count > 0)
        {
            varData = objCCWeb.ReturnSingleValue("DECLARE @varSelected AS VARCHAR(2000); SET @varSelected=''; SELECT @varSelected=@varSelected+'^'+ Caption" + Session["Type"].ToString() + "  " +
                 " FROM MTFormControlMaster WHERE ControlName LIKE 'gvReportGroup%'  AND FormID=1004 ORDER BY PriorityNo  SELECT CASE WHEN LEN(@varSelected)>1  THEN SUBSTRING(@varSelected,1,LEN(@varSelected)) " +
                 " ELSE '0' END AS  GridDetails");
            string[] StrData = varData.ToString().Split('^');

        }
        ClientScript.RegisterStartupScript(this.GetType(), "DisplayScript", "<script language='javascript'>" + strHideID + "</script>");
    }
      
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {            
            string strResult;
            string strResult1;
            string[] astrFlag = hidFlag.Value.Split('^');
            if (astrFlag[0] == "N")
                astrFlag[1] = "0";
            List<string> lstArray = new List<string>();
            
            if (astrFlag[0] == "N")
            {
              //  objCCWeb.FillCheckedBoxList(chkReportName, "SELECT 0 AS ReportID,'' AS ReportName" + Session["Type"] + " UNION SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID>0 AND ModuleID="+Convert.ToInt32(ddlModuleID.SelectedValue)+"ORDER BY ReportID, ReportName" + Session["Type"] + "", "ReportID", "ReportName" + Session["Type"] + "", " ");

                if (objCCWeb.ReturnNumericValue("SELECT Count(*) FROM MTReportGroupMaster WHERE ModuleID=" + ddlModuleID.SelectedValue + "") == 5)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "alert('Only Five Group Per Module Is Allowed To Create')</script>");
                    return;
                }
                if (objCCWeb.ReturnNumericValue("SELECT COUNT(GroupId) FROM MTReportGroupMaster WHERE UPPER(PriorityNo)='" + txtpriority.Text.Trim() + "' AND GroupId<>" + astrFlag[1] + " AND ModuleID=" + ddlModuleID.SelectedValue) > 0)
                {
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblpriority.Text);
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "alert('" + strResult + "')</script>");
                    txtpriority.Focus();
                    return;
                }


                if (objCCWeb.ReturnNumericValue("SELECT COUNT(GroupId) FROM MTReportGroupMaster WHERE UPPER(GroupName)='" + txtReportGroupName1.Text.Trim().Replace("'", "''").ToUpper() + "' AND GroupId<>" + astrFlag[1]) > 0)
                {
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblpriority.Text);
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "alert('" + strResult + "');</script>");
                    txtReportGroupName1.Focus();
                    return;
                }
                
                
                if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MTReportGroupMaster") == 0)
                {
                    strResult = objCCWeb.ExecuteQuery("INSERT INTO MTReportGroupMaster(GroupID,GroupName,ModuleID,PriorityNo) values(0,'',0,0)");
                }
                strResult = objCCWeb.ExecuteQuery("INSERT INTO MTReportGroupMaster(GroupID,GroupName,ModuleID,PriorityNo) SELECT ISNULL(MAX(GroupID),0)+1,'" + txtReportGroupName1.Text.Trim().Replace("'", "''") + "'," + ddlModuleID.SelectedValue + ","+ txtpriority.Text.Trim() +" FROM MTReportGroupMaster ");
                int GroupID = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(GroupID),0) FROM MTReportGroupMaster");
                for (int intForLoop = 0; intForLoop < chkReportName.Items.Count; intForLoop++)
                {

                    if (chkReportName.Items[intForLoop].Selected == true)
                    {
                        string[] ReportName = chkReportName.Items[intForLoop].Text.Split('#');
                        int INTModuleID = objCCWeb.ReturnNumericValue("SELECT ModuleID FROM MTReportMaster where ReportName" + Session["Type"] + "='" + ReportName[0].Trim() + "'");
                        int INTReportID = objCCWeb.ReturnNumericValue("SELECT ReportID FROM MTReportMaster where ReportName" + Session["Type"] + "='" + ReportName[0].Trim() + "'");
                        //lstArray.Add("INSERT INTO MTReportGroupMaster(ModuleID) VALUES("+  INTModuleID + ")");
                        lstArray.Add("INSERT INTO MTReportGroupDetails(GroupID,ReportID) Values(" + GroupID+ "," + INTReportID + ")");
                    }
                }
                strResult1 = objCCWeb.ExecuteQueryList(lstArray);
            }
            else
            {

                if (astrFlag[0] == "E" && astrFlag[6].Trim() != txtpriority.Text.Trim())
                {
                    //int moduleid = int.Parse(ddlModuleID.SelectedValue);
                    // int i = objCCWeb.ReturnNumericValue("SELECT COUNT(GroupId) FROM MTReportGroupMaster WHERE UPPER(PriorityNo)='" + txtpriority.Text.Trim() + "' AND GroupId<>" + astrFlag[1] + " AND ModuleID=" + ddlModuleID.SelectedValue);
                    if (objCCWeb.ReturnNumericValue("SELECT COUNT(GroupId) FROM MTReportGroupMaster WHERE UPPER(PriorityNo)='" + txtpriority.Text.Trim() + "' AND GroupId<>" + astrFlag[1] + " AND ModuleID=" + astrFlag[5]) > 0)
                    {
                        strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblpriority.Text);
                        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "alert('" + strResult + "')</script>");
                        hidFlag.Value = "E'" + "^" + "^" + "^" + "^" + "^" + "^";
                        //string str = hidFlag.Value.Split('^');
                        //  str.Replace('E','U');
                        //  hidFlag.Value = str;
                        //string temp="U";
                        //for (int i = 0; i < str.Length; i++)
                        //{
                        //    if (str[i] == 'E')
                        //    {
                        //        temp = temp + str[i];
                        //    }
                        //}

                        //  astrFlag[0].Replace('E','U');
                        //hidFlag.Value = "";
                        txtpriority.Focus();
                        return;
                    }
                }

                if (astrFlag[0] == "E" && astrFlag[2].Trim().ToUpper() != txtReportGroupName1.Text.Trim().ToUpper())
                {
                    if (objCCWeb.ReturnNumericValue("SELECT COUNT(GroupID) FROM MTReportGroupMaster WHERE UPPER(GroupName)='" + txtReportGroupName1.Text.Trim().Replace("'", "''").ToUpper() + "' AND GroupId<>" + astrFlag[1]) > 0)
                    {
                        strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblReportGroupName1.Text);
                        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "alert('" + strResult + "')</script>");
                        hidFlag.Value = "E'" + "^" + "^" + "^" + "^" + "^" + "^";
                        //hidFlag.Value = "";
                        txtReportGroupName1.Focus();
                        return;
                    }
                }
            

                //lstArray.Add("DELETE FROM MTReportGroupMaster WHERE GroupID =" + Convert.ToInt32(astrFlag[1]) + "");
                lstArray.Add("DELETE FROM MTReportGroupDetails Where GroupID=" + Convert.ToInt32(astrFlag[1]) + "");
                strResult = objCCWeb.ExecuteQuery("UPDATE MTReportGroupMaster SET GroupName='" + txtReportGroupName1.Text.Trim().Replace("'", "''") + "',ModuleID=" + astrFlag[5] +",PriorityNo="+ txtpriority.Text.Trim() + "WHERE GroupId=" + Convert.ToInt32(astrFlag[1]) + "");
                int GroupID = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(GroupID),0)  FROM MTReportGroupMaster");
                for (int intForLoop = 0; intForLoop < chkReportName.Items.Count; intForLoop++)
                {

                    if (chkReportName.Items[intForLoop].Selected == true)
                    {
                        string[] ReportName = chkReportName.Items[intForLoop].Text.Split('#');
                        
                        int INTModuleID = Convert.ToInt32(ddlModuleID.SelectedValue); //objCCWeb.ReturnNumericValue("SELECT Moduleid FROM MTUserGroupMaster where ModuleName" + Session["Type"] + "='" + ModuleID[0].Trim() + "'");
                        //int INTReportID = objCCWeb.ReturnNumericValue("SELECT ReportID FROM MTReportMaster where ReportName" + Session["Type"] + "='" + ReportName[intForLoop].Trim() + "'");
                        int INTReportID = Convert.ToInt32(chkReportName.Items[intForLoop].Value);
                        //lstArray.Add("INSERT INTO MTReportGroupMaster(GroupID,ModuleID) VALUES(" + Convert.ToInt32(astrFlag[1]) + "," + INTModuleID + ")");
                        lstArray.Add("Insert INTO MTReportGroupDetails(GroupID,ReportID) VALUES("+Convert.ToInt32(astrFlag[1]) +","+INTReportID+")");
                    }
                }
                strResult1 = objCCWeb.ExecuteQueryList(lstArray);
            }
            btnCancel_Click(sender, e);
            //strResult1 = objCCWeb.ExecuteQueryList(lstArray);
            if (strResult == "")
            {
                if (astrFlag[0] == "N")
                {
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "1", "");
                }
                else
                {
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "2", "");
                }
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>" + strHideID + "alert('" + strResult + "');</script>");
                objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID>0 ORDER BY ReportID, ReportName" + Session["Type"] + "","ReportID","ReportName"+ Session["Type"] + "", "");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>" + strHideID + "alert('" + strResult + "')</script>");
            }
            hidFlag.Value = "";
            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disError", "<script language='javascript'>" + strHideID + "alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] astrFlag = hidFlag.Value.Split('^');
            
            strResult = objCCWeb.ExecuteQuery("Delete From MTreportGroupDetails Where GroupID="+ astrFlag[1] +"");
            strResult = objCCWeb.ExecuteQuery("Delete From MTReportGroupMaster Where GroupID=" + astrFlag[1] + "");

            if (strResult == "")
            {
                strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "3", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>" + strHideID + "alert('" + strResult + "')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>" + strHideID + "alert('" + strResult + "')</script>");
            }

            //if (objCCWeb.ReturnNumericValue("EXEC spGetPrimaryValueExists 'GroupID','MTReportGroupMaster','" + (astrFlag[1]) + "'") > 0)
            //{

            //    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
            //    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "alert('" + strResult + "')</script>");
            //}
            //else
            //{
            //    strResult = objCCWeb.ExecuteQuery("DELETE FROM MTReportGroupMaster WHERE GroupID=" + Convert.ToInt32(astrFlag[1]));
            //   // strResult = objCCWeb.ExecuteQuery("DELETE FROM MTReportGroupMaster WHERE GroupID=" + Convert.ToInt32(astrFlag[1]));
            //    if (strResult == "")
            //    {
            //        strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "3", "");
            //        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>" + strHideID + "alert('" + strResult + "')</script>");
            //    }
            //    else
            //    {
            //        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>" + strHideID + "alert('" + strResult + "')</script>");
            //    }
            //}
            btnCancel_Click(sender, e);
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disError", "<script language='javascript'>" + strHideID + " alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        hidCache.Value = "";
        Response.Redirect("~/MainForm.aspx");
    }

    protected void gvReportGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        int intRowIndex = e.Row.RowIndex - 1;
        if (e.Row.RowIndex > -1)
        {
            e.Row.Attributes.Add("ondblclick", "fGridDoubleClick(" + e.Row.RowIndex + ")");
            e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
        }
        if (e.Row.Cells.Count - 1 > 0)
        {
            e.Row.Cells[1].Style.Add("display", "none");
            
            e.Row.Cells[4].Style.Add("display", "none");
            //e.Row.Cells[5].Style.Add("display", "none");
        
        }
        if (e.Row.Cells.Count > 0)
        {
            
        }
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {

            e.Row.Cells[0].Text = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "1023", "");
        }

        
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (gvReportGroup.Rows.Count > 0)
        {
            gvReportGroup.Columns[1].Visible = false;
            gvReportGroup.Columns[2].Visible = false;
            gvReportGroup.Columns[3].Visible = false;
            objCCWeb.ExportToExcel(gvReportGroup, frmReportGroupMaster, lblReportGroupDetails.Text, "Excel");
            gvReportGroup.Columns[0].Visible = true;
            gvReportGroup.Columns[1].Visible = true;
            gvReportGroup.Columns[2].Visible = true;
            gvReportGroup.Columns[3].Visible = true;
        }
    }
  /*  private void Check_box2()
    {
        //string strID ="";
        string strID1 = "";
        // int checkedReport = 0;
        string[] strIndex = hidFlag.Value.Split('^');
        //SqlDataReader rdr = objCCWeb.BindReader("Select MTRM.ReportID,MTRM.ReportName1 from MTReportMaster MTRM LEFT JOIN MTReportGroupMaster MTRGM ON MTRM.ModuleID=MTRGM.ModuleID Where ReportID<>0");
        ////SqlDataReader rdr = objCCWeb.BindReader("Select RD.ReportID From MTReportGroupMaster RM INNER JOIN MTReportGroupDetails RD ON RM.GroupID=RD.GroupID " +
        ////                " WHERE RM.GroupID=" + Convert.ToInt32(strIndex[1]) + ""); 
        SqlDataReader rdr = objCCWeb.BindReader("select ReportID from MTReportMaster where ReportID Not in (select ReportID from MTReportGroupDetails)");
        chkReportName.Items.Clear();

        while (rdr.Read())
        {
            strID1 = strID1 + rdr.GetValue(0).ToString() + ',';
        }

        rdr.Close();
        rdr.Dispose();
        if (strID1.Length > 0)
        {
            strID1 = strID1.Remove(strID1.Length - 1);
        }
        if (strID1 != "")
        {

            objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + ",1 as id  FROM MTReportMaster WHERE ReportID>0  AND ReportID  IN (" + strID1 + ") UNION SELECT ReportID,ReportName" + Session["Type"] + ",2 as id  FROM MTReportMaster WHERE ReportID>0 AND ModuleID=" + Convert.ToInt32(strIndex[5]) + "  AND ReportID  NOT IN(" + strID1 + ")    ORDER BY id, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");
        }
        else if (strID1 == "")
        {
            objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID>0 ORDER BY ReportID, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");
        }

        string[] varStr = strID1.Split(',');

        for (int i = 0; i < varStr.Length; i++)
        {
            if (chkReportName.Items.Count > 0)
            {
                for (int inti = 0; inti < chkReportName.Items.Count; inti++)
                {
                    if (chkReportName.Items[inti].Value == varStr[i])
                    {
                        chkReportName.Items[inti].Selected = true;
                    }

                }
            }
        }

    }
*/
    private void Check_box()
    {
        //string strID ="";
        string strID1="" ;
       // int checkedReport = 0;
        string[] strIndex = hidFlag.Value.Split('^');
        //SqlDataReader rdr = objCCWeb.BindReader("Select MTRM.ReportID,MTRM.ReportName1 from MTReportMaster MTRM LEFT JOIN MTReportGroupMaster MTRGM ON MTRM.ModuleID=MTRGM.ModuleID Where ReportID<>0");
        SqlDataReader rdr = objCCWeb.BindReader("Select RD.ReportID From MTReportGroupMaster RM INNER JOIN MTReportGroupDetails RD ON RM.GroupID=RD.GroupID " +
                        " WHERE RM.GroupID=" + Convert.ToInt32(strIndex[1]) + "");
        chkReportName.Items.Clear();

        while (rdr.Read())
        {
             strID1 = strID1 + rdr.GetValue(0).ToString()+',';
        }

        rdr.Close();
        rdr.Dispose();
        if (strID1.Length > 0)
        {
            strID1 = strID1.Remove(strID1.Length - 1);
        }
        if (strID1 != "")
        {
            
            ////objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + ",1 as id  FROM MTReportMaster WHERE ReportID>0  AND ReportID  IN (" + strID1 + ") UNION SELECT ReportID,ReportName" + Session["Type"] + ",2 as id  FROM MTReportMaster WHERE ReportID>0 AND ModuleID="+Convert.ToInt32(strIndex[5]) +"  AND ReportID  NOT IN(" + strID1 + ")    ORDER BY id, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");
            objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + ",1 as id  FROM MTReportMaster WHERE ReportID>0  AND ReportID  IN (" + strID1 + ") UNION SELECT ReportID,ReportName" + Session["Type"] + ",2 as id  FROM MTReportMaster WHERE ReportID>0 AND ModuleID=" + Convert.ToInt32(strIndex[5]) + "  AND ReportID  NOT IN(" + strID1 + ") AND ReportID Not in (select ReportID from MTReportGroupDetails)   ORDER BY id, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");

            
        }
        else if (strID1 == "")
        {
            
            ////objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID>0 ORDER BY ReportID, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");
            objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID>0 AND ReportID Not in (select ReportID from MTReportGroupDetails) AND ModuleID=" + Convert.ToInt32(strIndex[5]) + " ORDER BY ReportID, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");

        }

        string[] varStr = strID1.Split(',');

         for (int i = 0; i < varStr.Length; i++)
                       {
                           if (chkReportName.Items.Count > 0)
                           {
                               for (int inti = 0; inti < chkReportName.Items.Count; inti++)
                               {
                                   if (chkReportName.Items[inti].Value == varStr[i])
                                   {
                                       chkReportName.Items[inti].Selected = true;
                                   }

                               }
                           }
                       }

    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        try
        {
            string[] strIndex = hidFlag.Value.Split('^');
            SqlDataReader rdrM= objCCWeb.BindReader("Select MTRGM.ModuleID,MTUMM.ModuleName1 From MTReportGroupMaster MTRGM Inner JOIN MTUserModuleMaster MTUMM on MTRGM.ModuleID=MTUMM.ModuleID Where GroupID="+Convert.ToInt32(strIndex[1]) + "");
            SqlDataReader rdrVal = objCCWeb.BindReader("SELECT  MTRM.ReportID,MTRM.ReportName1 FROM MTReportMaster MTRM " +
                                        " INNER JOIN MTReportGroupDetails MTRGD ON MTRM.ReportID = MTRGD.ReportID" +
                                       "  WHERE MTRGD.GroupID=" +Convert.ToInt32(strIndex[1]) + "");
            if (rdrM.Read())
            {
                ddlModuleID.SelectedValue = rdrM.GetValue(0).ToString();
                
            }
            rdrVal.Close();
            rdrVal.Dispose();
            rdrM.Close();
            rdrM.Dispose();
            Check_box();
            //gvReportGroup.Rows[Convert.ToInt32(strIndex[3])].BackColor = System.Drawing.Color.FromName("#ffc0cb;");
            //gvReportGroup.Rows[Convert.ToInt32(strIndex[3])].Font.Bold = true;

            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script langauge='javascript'>document.getElementById('gvReportGroup').rows[Number(" + strIndex[3] + ")+1].style.cssText='color: green; font-weight: bold; cursor: pointer;  background: #ffc0cb';" + strHideID + strHideInput + "</script>");
            hidID.Value = "A";
            txtReportGroupName1.Attributes.Add("readOnly", "true");
            txtpriority.Attributes.Add("readOnly","true");
            //ddlModuleID.Attributes.Add("disabled", "true");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disError", "<script language='javascript'>" + strHideID + " alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }
    ////protected void ddlModuleID_SelectedIndexChanged(object sender, EventArgs e)
    ////{
    ////   ddlModuleID.Attributes.Add("onclick", "javascript:return fddlBind();");
    ////   //objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID>0 AND ModuleID="+Convert.ToInt32(ddlModuleID.SelectedValue)+" ORDER BY ReportID, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");
       
    ////}

    protected void btnBind_Click(object sender, EventArgs e)
    {
        //objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID>0 AND ModuleID=" + Convert.ToInt32(ddlModuleID.SelectedValue) + " ORDER BY ReportID, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");
        try
        {
            chkReportName.Items.Clear();
            objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE ReportID>0 AND ReportID Not in (select ReportID from MTReportGroupDetails) AND ModuleID=" + Convert.ToInt32(ddlModuleID.SelectedValue) + " ORDER BY ReportID, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");
            //objCCWeb.FillCheckedBoxList(chkReportName, "SELECT ReportID,ReportName" + Session["Type"] + " FROM MTReportMaster WHERE  ReportID Not in (select ReportID from MTReportGroupDetails) AND ModuleID=" + Convert.ToInt32(ddlModuleID.SelectedValue) + " ORDER BY ReportID, ReportName" + Session["Type"] + " ", "ReportID", "ReportName" + Session["Type"].ToString() + "", "");

            hdnVal.Value = "AB";
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disError", "<script language='javascript'>" + strHideID + " alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }

    
}










 