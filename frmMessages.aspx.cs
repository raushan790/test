using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Collections.Generic;
using System.IO;

public partial class frmMessages : System.Web.UI.Page
{
    protected int intSlNo;
    CCWeb objCCWeb = new CCWeb();
    //protected static string NewOption, EditOption, DeleteOption;
    protected int intSlNoS,intSlNoE;

    protected static string strCon1 = "";
    protected static string strCon2 = "";
    protected static string strCon3 = "";
    protected static string strCon4 = "";
    protected static string strCon5 = "";
    protected static string strCon6 = "";
    protected static string strCon7 = "";
    protected static string strCon8 = "";
    protected static string strCon9 = "";
    protected static string strCon10 = "";
    protected static string strCon11 = "";
    protected static string strCon12 = "";
    protected static string strCon13 = "";
    protected static string strCon14 = "";

    string strResult;

    CultureInfo cinfo = new CultureInfo("hi-IN");
    protected static string strHideID = " document.getElementById('btnGridBind').style.display='none'; document.getElementById('btndblClick').style.display='none';";
    protected string strHide = "if (document.getElementById('gvMessages')!=null)if (document.getElementById('gvMessages').rows.length>1) {for(var intForLoop=0;intForLoop<document.getElementById('gvMessages').rows.length;intForLoop++)" +
            " { document.getElementById('gvMessages').rows[intForLoop].cells[1].style.display='none'; document.getElementById('gvMessages').rows[intForLoop].cells[7].style.display='none';document.getElementById('gvMessages').rows[intForLoop].cells[5].style.display='none';}}";

    //protected string strHide = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script language='javascript'>" + strHide + "</script>");
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

        if ((objCCWeb.ReturnNumericValue("SELECT Count(*) FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuMessage'") == 0) || (objCCWeb.ReturnSingleValue("SELECT ISNULL(VisibleOption,'N') FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuMessage'") == "N"))
        {
            Session.Clear();
            Response.Redirect("Logon.aspx");
            return;
        }
        if (objCCWeb.pCheckText(frmMessage) == true)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
            return;
        }
        if (!IsPostBack)
        {
            hidCache.Value = "";
            BindGrid();
            txtMessage.Attributes.Add("onkeypress", "return Restrict_Message(event)");
            txtMessageTitle.Attributes.Add("onkeypress", "return Restrict_Address(event)");
            txtMessage.Attributes.Add("autocomplete","off");
            txtMessageTitle.Attributes.Add("autocomplete","off");
            PGetOption();
            gvMessages.Attributes.Add("bordercolor", "#FFC1A4");
            gvEmployeeList.Attributes.Add("bordercolor", "#FFC1A4");
            gvStudentList.Attributes.Add("bordercolor", "#FFC1A4");

            txtMessage.Attributes.Add("onkeypress", "javascript:return Restrict_Multiline(event,200);");
            ddlNewsMonthYear.Enabled = true;
            tblStudent.Visible = false;
            tblEmployee.Visible = false;
            hidLoad.Value = "";
            objCCWeb.FillDDLs(ddlBatch, "SELECt ClassID,ClassName1 FROM MTClassMAster  ORDER BY PriorityNo", "ClassID", "ClassName1", "");
            objCCWeb.FillDDLs(ddlDesignation, "SELECT PRLDesignationID,StaffDesignationName1 FROM PRLDesignationMaster", "PRLDesignationID", "StaffDesignationName1", "");
            ClientScript.RegisterStartupScript(this.GetType(), "DisplayScript", "<script language='javascript'>" + strHideID + "</script>");
        }
    }
    protected void PGetOption()
    {
        SqlDataReader rdroption = objCCWeb.BindReader("SELECT NewOption,EditOption,DeleteOption FROM MTUserLimitMaster ULM INNER JOIN MTUserModuleMaster UMM ON ULM.ModuleID=UMM.ModuleID " +
                " WHERE UMM.ModuleID=1 AND MenuName='mnuMessage' AND UID=" + Session["UID"] + "");
        if (rdroption.Read())
        {
            //NewOption = rdroption.GetValue(0).ToString();
            //EditOption = rdroption.GetValue(1).ToString();
            //DeleteOption = rdroption.GetValue(2).ToString();
           hidCache.Value = rdroption.GetValue(0).ToString() + ";" + rdroption.GetValue(1).ToString() + ";" + rdroption.GetValue(2).ToString();               
        }
        rdroption.Close();
        rdroption.Dispose();
    }
   
    protected void btnClose_Click(object sender, EventArgs e)
    {
        hidCache.Value = "";
        Response.Redirect("MainForm.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlNewsMonthYear.Enabled = true;
        ddlNewsMonthYear.SelectedValue = "";
        BindGrid();
        hidLoad.Value = "";
        hidMessage.Value = "";
        tblEmployee.Visible = false;
        tblStudent.Visible = false;
        ddlUserType.SelectedIndex = -1;
    }

    protected void gvMessages_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       // e.Row.Cells[1].Style.Add("display", "none");
        if (e.Row.RowIndex >= 0)
        {
            e.Row.Cells[0].Text = intSlNo.ToString();
            intSlNo += 1;
            e.Row.Attributes.Add("ondblclick", "Change_SelectedRow(" + e.Row.RowIndex + ")");
            e.Row.Attributes.Add("onmouseover","javascript:this.style.cursor='pointer';this.style.cursor='hand';");

         
        }
        else
            intSlNo = 1;
        if (e.Row.Cells.Count - 1 > 0)
        {
            e.Row.Cells[1].Style.Add("display", "none");
            e.Row.Cells[5].Style.Add("display", "none");
            e.Row.Cells[7].Style.Add("display", "none");
        }
    }
    protected void BindGrid()
    {
        string strCondition = string.Empty;
        if (ddlNewsMonthYear.SelectedValue != "")
        {
            strCondition = " AND Month(MessageDate)=" + Convert.ToInt32(ddlNewsMonthYear.SelectedValue.Split('~')[0]) + " AND Year(MessageDate)=" + Convert.ToInt32(ddlNewsMonthYear.SelectedValue.Split('~')[1]) + "";
        }

        SqlDataReader rdr1 = objCCWeb.BindReader("SELECT MessageID AS MessageID,Messagetitle AS MessageTitle,CONVERT(VARCHAR,MessageDate,103) AS MessageDate1,Message AS Message,CONVERT(VARCHAR,MessageTillDate,103) AS MessageDate2,Message AS Message," +
                                "CASE MessageStatus WHEN 'Y' THEN 'YES' WHEN 'N' THEN 'NO' END AS MessageStatus,MessageStatus AS StatusValue FROM MTMessageMaster WHERE MessageID>0 " + strCondition + " AND SchoolID=" + Session["SchoolID"].ToString() + " ORDER BY MessageDate DESC,MessageStatus DESC");
        gvMessages.DataSource = rdr1;
        gvMessages.DataBind();
        rdr1.Close();
        rdr1.Dispose();
        txtMessageTitle.Text = "";
        txtMessage.Text = "";
        txtNewsDate.Text = "";
        txtmessageTillDate.Text = "";
        //
        txtMessageTitle.ReadOnly = true;
        txtNewsDate.ReadOnly = true;
        txtmessageTillDate.ReadOnly = true;
         txtMessage.ReadOnly = true;
        ddlUserType.Enabled = false;
        ddlStatus.Enabled = false;
        btnNew.Enabled = true;
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
        btnSave.Enabled = false;
        hidEditNew.Value = "";
        objCCWeb.FillDDLs(ddlNewsMonthYear, "SELECT '' as  MessageDateID, '' AS MessageDate ,100000 as MessageMonth,100000 as MessageYear UNION SELECT DISTINCT CAST(MONTH(MessageDate) AS VARCHAR)+'~'+CAST(YEAR(MessageDate)AS VARCHAR) AS MessageDateID,DATENAME(mm,MessageDate)+'-'+ CAST(YEAR(MessageDate) AS VARCHAR) AS MessageDate, MONTH(MessageDate) as MessageMonth,YEAR(MessageDate) as MessageYear  FROM MTMessageMaster WHERE MessageDate IS NOT NULL ORDER BY MessageYear DESC,MessageMonth DESC", "MessageDateID", "MessageDate", "");
        //ddlNewsMonthYear.SelectedValue = Request.Form["ddlNewsMonthYear"];
       // ddlNewsMonthYear.Items.FindByValue(Request.Form["ddlNewsMonthYear"].ToString()).Selected = true;
        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string[] strArray = hidEditNew.Value.ToString().Split('~');
            FileName = objCCWeb.ReturnSingleValue("SELECT Isnull(NewsFileName,'') FROM MTMessageMaster WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + "");
            objCCWeb.ExecuteQuery("DELETE FROM MTMessageMaster WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + " AND SchoolID=" + Session["SchoolID"].ToString() + "");
            objCCWeb.ExecuteQuery("DELETE FROM MDMessageDetails WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text));
            if (FileName!="")
            {
                if (File.Exists(Server.MapPath("News/") + FileName))
                {
                    File.Delete(Server.MapPath("News/") + FileName);
                }
            }
            
            FileName = "";
            btnCancel_Click(sender, e);
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>" + strHideID + strHide + "alert('Deleted Successfully')</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>" + strHideID + strHide + "parent.frames['leftFooterFrame'].location.reload();</script>");
        }
        catch (Exception exMyError)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>" + strHideID + strHide + " alert('" + exMyError.Message.Replace("'", "") + "')</script>");
        }
    }
    protected bool CheckFormat(string strfileName)
    {
        var varFileName = strfileName.Split('.');
        if (varFileName[varFileName.Length - 1].ToLower() == "JPG" || varFileName[varFileName.Length - 1].ToLower() == "jpeg" || varFileName[varFileName.Length - 1].ToLower() == "jpg" || varFileName[varFileName.Length - 1].ToLower() == "pdf")
            return true;
        else
            return false;
    }
    string FileName = "";
    private void UploadNewsFile(FileUpload flUpload,int MessageID)
    {
        string PathName = "";
        int intMsgID = 0;
        try
        {
            if (flUpload.HasFile)
            {
                FileName = flUpload.FileName;
                if (FileName != "")
                {
                    if (CheckFormat(FileName))
                    {
                        if (MessageID==0)
                        {
                            intMsgID = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(MessageID),0)+1 FROM MTMessageMaster");                            
                        }
                        else
                        {
                            intMsgID = MessageID;
                        }
                        
                        FileName = "NE_" + intMsgID + "_" + FileName;
                        PathName = "News/";                        
                        if (!Directory.Exists(Server.MapPath(PathName)))
                        {
                            Directory.CreateDirectory(Server.MapPath(PathName));                            
                        }
                        if (File.Exists(Server.MapPath(PathName) + FileName))
                        {
                            File.Delete(Server.MapPath(PathName) + FileName);
                        }
                        flUploadAttachment.SaveAs(Server.MapPath(PathName) + FileName);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Only JPG File can be attached');</script>");
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('The File Is In Use or Already Exist At Destination Location. "+ex.Message.Replace("'","")+"');</script>");
            return;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        List<string> lstArray = new List<string>();
        string strQuery = "";
        string strDetailQuery = "";

        try
        {
            string[] strArray = hidEditNew.Value.ToString().Split('~');            
            if (strArray[0] == "N")
            {
                UploadNewsFile(flUploadAttachment,0);
                if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MTMessageMaster") < 1)
                    objCCWeb.ExecuteQuery("INSERT INTO MTMessageMaster(MessageID,MessageTitle,Message,MessageStatus) VALUES(0,'','','')");
                if (ddlUserType.SelectedValue == "A")
                {
                    int intMsgID = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(MessageID),0)+1 FROM MTMessageMaster");

                    strQuery = "INSERT INTO MTMessageMaster(MessageID,MessageTitle,Message,MessageStatus,MessageDate,EntryUserID,EntryDate,MessageTillDate,SchoolID,NewsFileName) Values( " + intMsgID + "," + objCCWeb.fReplaceChar(txtMessageTitle) + "," + objCCWeb.fReplaceChar(txtMessage) + ",'" + Request["ddlStatus"] + "'," + objCCWeb.ReturnDateorNull(txtNewsDate.Text) + "," + Convert.ToInt32(Session["UID"]) + ",GetDate()" + "," + objCCWeb.ReturnDateorNull(txtmessageTillDate.Text) + "," + Session["SchoolID"].ToString() + ",'" + FileName + "') ~";

                    lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + intMsgID + ",'" + ddlUserType.SelectedValue + "'," +
                                     " 0,0,0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                }
                else if (ddlUserType.SelectedValue == "S")
                {
                    int intMsgID = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(MessageID),0)+1 FROM MTMessageMaster");                    
                    strQuery = "INSERT INTO MTMessageMaster(MessageID,MessageTitle,Message,MessageStatus,MessageDate,EntryUserID,EntryDate,MessageTillDate,SchoolID,NewsFileName) VALUES(" + intMsgID + "," + objCCWeb.fReplaceChar(txtMessageTitle) + "," + objCCWeb.fReplaceChar(txtMessage) + ",'" + Request["ddlStatus"] + "'," + objCCWeb.ReturnDateorNull(txtNewsDate.Text) + "," + Convert.ToInt32(Session["UID"]) + ",GetDate()" + "," + objCCWeb.ReturnDateorNull(txtmessageTillDate.Text) + "," + Session["SchoolID"].ToString() + ",'" + FileName + "')~";
                    if (Request.Form["ddlBatch"] != null)
                    {
                        if (Request.Form["ddlBatch"] != "0")
                        {
                            gvStudentList.Columns[1].Visible = true;
                            for (int i = 0; i < gvStudentList.Rows.Count; i++)
                            {
                                string strCheck = (i + 2 > 9) ? Request.Form["gvStudentList$ctl" + (i + 2) + "$chkSelectS"] : Request.Form["gvStudentList$ctl0" + (i + 2) + "$chkSelectS"];
                                if (strCheck == "on")
                                {
                                    lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + intMsgID + ",'" + ddlUserType.SelectedValue + "'," +
                                        " 0," + gvStudentList.Rows[i].Cells[1].Text + ",0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                                }
                            }                            
                            if (lstArray.Count == 0)
                            {
                                lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + intMsgID + ",'" + ddlUserType.SelectedValue + "'," +
                                        " " + Request.Form["ddlBatch"] + ",0,0,0 ," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                            }
                        }
                        else
                        {
                            for (int i = 0; i < gvStudentList.Rows.Count; i++)
                            {
                                string strCheck = (i + 2 > 9) ? Request.Form["gvStudentList$ctl" + (i + 2) + "$chkSelectS"] : Request.Form["gvStudentList$ctl0" + (i + 2) + "$chkSelectS"];
                                if (strCheck == "on")
                                {
                                    lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + intMsgID + ",'" + ddlUserType.SelectedValue + "'," +
                                            " 0," + gvStudentList.Rows[i].Cells[1].Text + ",0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                                }
                            }

                            if (strDetailQuery == "")
                            {
                                if (ddlBatch.SelectedValue != "0")
                                {
                                    lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + intMsgID + ",'" + ddlUserType.SelectedValue + "'," +
                                            " 0,0,0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                                }
                                else
                                {
                                    lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + intMsgID + ",'" + ddlUserType.SelectedValue + "'," +
                                            " 0,0,0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                                }
                            }
                        }
                    }
                    else
                    {
                        lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + intMsgID + ",'" + ddlUserType.SelectedValue + "'," +
                                    " 0,0,0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                    }
                }
                else
                {
                    int intMsgID = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(MessageID),0)+1 FROM MTMessageMaster");
                    strQuery = "INSERT INTO MTMessageMaster(MessageID,MessageTitle,Message,MessageStatus,MessageDate,EntryUserID,EntryDate,MessageTillDate,SchoolID,NewsFileName) VALUES(" + intMsgID + "," + objCCWeb.fReplaceChar(txtMessageTitle) + "," + objCCWeb.fReplaceChar(txtMessage) + ",'" + Request["ddlStatus"] + "'," + objCCWeb.ReturnDateorNull(txtNewsDate.Text) + "," + Convert.ToInt32(Session["UID"]) + ",GetDate()" + "," + objCCWeb.ReturnDateorNull(txtmessageTillDate.Text) + "," + Session["SchoolID"].ToString() + ",'" + FileName + "')~";

                    for (int i = 0; i < gvEmployeeList.Rows.Count; i++)
                    {
                        string strCheck = (i + 2 > 9) ? Request.Form["gvEmployeeList$ctl" + (i + 2) + "$chkSelectE"] : Request.Form["gvEmployeeList$ctl0" + (i + 2) + "$chkSelectE"];
                        if (strCheck == "on")
                        {                            
                            lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + intMsgID + ",'" + ddlUserType.SelectedValue + "'," +
                                   " 0,0,0," + gvEmployeeList.Rows[i].Cells[1].Text + "," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                        }
                    }
                }
            }
            else//Edit Case
            {
                UploadNewsFile(flUploadAttachment, Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text));
                if (FileName == "")
                {
                    FileName = objCCWeb.ReturnSingleValue("SELECT ISNULL(NewsFileName,'') FROM MTMessageMaster WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + "");
                }
                if (ddlUserType.SelectedValue == "A")
                {
                    //int intMsgID = Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) ;//objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(MessageID),0)+1 FROM MTMessageMaster");
                    strQuery = "UPDATE MTMessageMaster SET MessageTitle=" + objCCWeb.fReplaceChar(txtMessageTitle) + ",Message=" + objCCWeb.fReplaceChar(txtMessage) + ","+
                     " MessageStatus='" + ddlStatus.SelectedValue.Substring(0, 1) + "',MessageDate=" + objCCWeb.ReturnDateorNull(txtNewsDate.Text) + ","+
                     " UpdateUserID=" + Convert.ToInt32(Session["UID"]) + ",UpdateDate=GetDate(), MessageTillDate=" + objCCWeb.ReturnDateorNull(txtmessageTillDate.Text) + ", "+
                     " NewsFileName='"+FileName+"'  WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + " AND SchoolID=" + Session["SchoolID"].ToString() + "~";
                    lstArray.Add("DELETE FROM MDMessageDetails WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + "");
                    lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) "+
                    " SELECT ISNULL(MAX(MessageDetailID),0)+1," + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + ",'" + ddlUserType.SelectedValue + "',0,0,0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() " +
                    " FROM MDMessageDetails");
                }
                else if (ddlUserType.SelectedValue == "S")
                {
                    lstArray.Add("UPDATE MTMessageMaster SET MessageTitle=" + objCCWeb.fReplaceChar(txtMessageTitle) + ",Message=" + objCCWeb.fReplaceChar(txtMessage) + ","+
                     " MessageStatus='" + ddlStatus.SelectedValue.Substring(0, 1) + "',MessageDate=" + objCCWeb.ReturnDateorNull(txtNewsDate.Text) + ","+
                     " UpdateUserID=" + Convert.ToInt32(Session["UID"]) + ",UpdateDate=GetDate(),MessageTillDate=" + objCCWeb.ReturnDateorNull(txtmessageTillDate.Text) + ","+
                     " NewsFileName='"+FileName+"'  WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + "AND SchoolID=" + Session["SchoolID"].ToString() + "");
                    lstArray.Add("DELETE FROM MDMessageDetails WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + "");
                    if (Request.Form["ddlBatch"] != null)
                    {
                        if (Request.Form["ddlBatch"] != "0")
                        {
                            gvStudentList.Columns[1].Visible = true;
                            for (int i = 0; i < gvStudentList.Rows.Count; i++)
                            {
                                string strCheck = (i + 2 > 9) ? Request.Form["gvStudentList$ctl" + (i + 2) + "$chkSelectS"] : Request.Form["gvStudentList$ctl0" + (i + 2) + "$chkSelectS"];
                                if (strCheck == "on")
                                {
                                    lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + ",'" + ddlUserType.SelectedValue + "'," +
                                        " 0," + gvStudentList.Rows[i].Cells[1].Text + ",0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                                }
                            }
                            if (strDetailQuery == "")
                            {
                                lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + ",'" + ddlUserType.SelectedValue + "'," +
                                        " " + Request.Form["ddlBatch"] + ",0,0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate()  FROM MDMessageDetails");
                            }
                        }
                        else
                        {
                            for (int i = 0; i < gvStudentList.Rows.Count; i++)
                            {
                                string strCheck = (i + 2 > 9) ? Request.Form["gvStudentList$ctl" + (i + 2) + "$chkSelectS"] : Request.Form["gvStudentList$ctl0" + (i + 2) + "$chkSelectS"];
                                if (strCheck == "on")
                                {
                                    lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + ",'" + ddlUserType.SelectedValue + "'," +
                                            " 0," + gvStudentList.Rows[i].Cells[1].Text + ",0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                                }
                            }
                        }
                    }
                    else
                    {
                        lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + ",'" + ddlUserType.SelectedValue + "'," +
                                   " 0,0,0,0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                    }
                }
                else
                {
                    lstArray.Add("UPDATE MTMessageMaster SET MessageTitle=" +objCCWeb.fReplaceChar(txtMessageTitle) + ",Message=" + objCCWeb.fReplaceChar(txtMessage) + ","+
                     " MessageStatus='" + ddlStatus.SelectedValue.Substring(0, 1) + "',MessageDate=" + objCCWeb.ReturnDateorNull(txtNewsDate.Text) + ","+
                     " UpdateUserID=" + Convert.ToInt32(Session["UID"]) + ",UpdateDate=GetDate(),MessageTillDate=" + objCCWeb.ReturnDateorNull(txtmessageTillDate.Text) + ", "+
                     " NewsFileName='" + FileName + "'  WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + "AND SchoolID=" + Session["SchoolID"].ToString() + "");
                    
                    lstArray.Add("DELETE FROM MDMessageDetails WHERE MessageID=" + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + "");
                    for (int i = 0; i < gvEmployeeList.Rows.Count; i++)
                    {
                        string strCheck = (i + 2 > 9) ? Request.Form["gvEmployeeList$ctl" + (i + 2) + "$chkSelectE"] : Request.Form["gvEmployeeList$ctl0" + (i + 2) + "$chkSelectE"];
                        if (strCheck == "on")
                        {
                                lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + ",'" + ddlUserType.SelectedValue + "'," +
                                  " 0,0,0," + gvEmployeeList.Rows[i].Cells[1].Text + "," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                        }
                    }
                    if (strDetailQuery == "")
                    {
                        if (ddlDesignation.SelectedValue != "0")
                        {
                            lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + ",'" + ddlUserType.SelectedValue + "'," +
                                 " 0,0," + ddlDesignation.SelectedValue + ",0," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                        }
                        else
                        {
                            lstArray.Add("INSERT INTO MDMessageDetails (MessageDetailID,MessageID,UserType,ClassID,StudentID,DesignationID,EmployeeID,EntryUserID,EntryDate) SELECT ISNULL(MAX(MessageDetailID),0)+1," + Convert.ToInt32(gvMessages.Rows[Convert.ToInt32(strArray[1])].Cells[1].Text) + ",'" + ddlUserType.SelectedValue + "'," +
                                " 0,0,0,0 ," + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MDMessageDetails");
                        }
                    }
                }
                //Execute Edit Query
            }

            //strQuery = strQuery.Remove(strQuery.Length - 1, 1);
            if (strArray[0] == "N")
            {
                strQuery = strQuery.Remove(strQuery.Length - 1, 1);
                objCCWeb.ExecuteQuery(strQuery);
                objCCWeb.ExecuteQueryList(lstArray);
            }
            else
            {
                if (ddlUserType.SelectedValue == "A")
                {
                    strQuery = strQuery.Remove(strQuery.Length - 1, 1);
                }
                objCCWeb.ExecuteQuery(strQuery);
                objCCWeb.ExecuteQueryList(lstArray);
            }

            btnCancel_Click(sender, e);
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>" + strHideID + strHide + " alert('Saved Successfully')</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>" + strHideID + strHide + " parent.frames['leftFooterFrame'].location.reload();</script>");

            //BindGrid();
        }
        catch (Exception exMyError)
        {
            Response.Write("<script>" + strHideID + "alert('" + exMyError.Message.Replace("'", "") + "')</script>");
        }
    }
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch(ddlUserType.SelectedValue)
        {
            case "S":
                tblEmployee.Visible = false;
                tblStudent.Visible = true;
                //ddlCourse.Enabled = true;
                ddlBatch.Enabled = true;
                chkSSelectAll.Enabled = true; 
                gvStudentList.Visible = false;
                ddlBatch.Items.Clear();
                objCCWeb.FillDDLs(ddlBatch, "SELECt ClassID,ClassName1 FROM MTClassMAster  ORDER BY PriorityNo", "ClassID", "ClassName1", "");
                gvStudentList.Visible = true;
                gvStudentList.Columns[1].Visible = true;
                SqlDataReader rdr3s = objCCWeb.BindReader("SELECT SIM.StudentID,SYD.AdmissionNo,(FirstName+' '+MiddleName+' '+LastName) as EnrolleeName FROM SIStudentmaster SIM INNER JOIN SISTudentYearWiseDetails SYD on SYD.StudentID=SIM.StudentID where StudentStatus ='S' and SYD.AcaStart=" + Session["AcaStart"] + " AND SYD.SchoolID=" + Session["SchoolID"] + "");
                gvStudentList.DataSource = rdr3s;
                gvStudentList.DataBind();
                rdr3s.Close();
                rdr3s.Dispose();

               // objCCWeb.FillDDLs(ddlCourse, "SELECT CourseID,CourseName FROM MTCourseMaster WHERE CourseID=0 OR CourseID IN(SELECT DISTINCT EM.CourseID FROM MTEnrolleeMaster EM INNER JOIN MTBatchMaster BM ON EM.BatchID=BM.BatchID WHERE EnrolleeStatus='S' AND BM.BatchStatus='A' AND EM.BatchID<>0) ORDER BY CourseName", "CourseID", "CourseName", "");

                break;
            case "E":
                tblEmployee.Visible = true;
                tblStudent.Visible = false;
                ddlDesignation.Enabled = true;
                chkESelectAll.Enabled = true;
                //objCCWeb.FillDDLs(ddlDesignation, "SELECT PRLDesignationID,StaffDesignationName1 FROM PRLDesignationMaster", "PRLDesignationID", "StaffDesignationName1", "");

                objCCWeb.FillDDLs(ddlDesignation, "SELECT 0 as PRLDesignationID,'' as StaffDesignationName1 UNION SELECT PRLDesignationID,StaffDesignationName1 FROM PRLDesignationMaster WHERE PRLDesignationID IN (SELECT DISTINCT PRLDesignationID FROM PRLEmployeeMaster WHERE EmployeeStatus='N') ORDER BY StaffDesignationName1", "PRLDesignationID", "StaffDesignationName1", "");
                ddlDepartment.Enabled = true;
                objCCWeb.FillDDLs(ddlDepartment, "SELECT 0 as PRLDepartmentID,'' as DepartmentName1 UNION SELECT PRLDepartmentID,DepartmentName1 FROM PRLDepartmentMaster  WHERE PRLDepartmentID<>0 ORDER BY DepartmentName1", "PRLDepartmentID", "DepartmentName1", "");
                gvEmployeeList.Visible = true;
                gvEmployeeList.Columns[1].Visible = true;
                SqlDataReader rdr3 = objCCWeb.BindReader("SELECT PRLEmployeeID,EmployeeCode,(FirstName+' '+MiddleName+' '+LastName) AS Employee,1 AS SelectValue FROM PRLEmployeeMaster WHERE PRLEmployeeID<>0 AND EmployeeStatus='N'");
                gvEmployeeList.DataSource = rdr3;
                gvEmployeeList.DataBind();
                rdr3.Close();
                rdr3.Dispose();
                gvEmployeeList.Columns[1].Visible = false;
                break;       
            default :
                tblEmployee.Visible = false;
                tblStudent.Visible = false;
                break;
        }
        if (hidLoad.Value == "N")
        {
            txtMessageTitle.ReadOnly = false;
            txtMessage.ReadOnly = false;
            ddlUserType.Enabled = true;
            ddlNewsMonthYear.Enabled = false;
            ddlStatus.Enabled = true;
        }
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnGridBind_Click(object sender, EventArgs e)
    {
        gvStudentList.Visible = true;
        gvStudentList.Columns[1].Visible = true;
        SqlDataReader rdr4 = objCCWeb.BindReader("SELECT SYD.StudentID,AdmissionNo,(FirstName+' '+MiddleName+' '+LastName) AS EnrolleeName,1 AS SelectValue  " +
            " FROM SIStudentMaster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID= SYD.StudentID " +
            "WHERE ClassID=" + ddlBatch.SelectedValue + " AND SYD.AcaStart=" + Session["AcaStart"] + " AND SYD.SchoolID= " + Session["SchoolID"] + " ANd StudentStatus='S'");
        gvStudentList.DataSource = rdr4;
        gvStudentList.DataBind();
        rdr4.Close();
        rdr4.Dispose();
        gvStudentList.Columns[1].Visible = false;
        //objCCWeb.FillDDLs(ddlBatch, "SELECT BatchID,BatchName FROM MTBatchMaster WHERE BatchStatus='A' AND BatchID IN(SELECT DISTINCT BatchID FROM MTEnrolleeMaster WHERE EnrolleeStatus='S' AND CourseID=" + ddlCourse.SelectedValue + " ) ORDER BY ExpectedStartDate DESC", "BatchID", "BatchName", "");
        //ddlBatch.Items.FindByValue(Request.Form["ddlBatch"]).Selected = true;
    }
    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            e.Row.Cells[0].Text = intSlNoS.ToString();
            intSlNoS += 1;
            //CheckBox chkSelectS = new CheckBox();
            //chkSelectS.ID = "chkSelectS";// +e.Row.RowIndex;
            //e.Row.Cells[4].Controls.Add(chkSelectS);
        }
        else
            intSlNoS = 1;

        if (e.Row.Cells.Count - 1 > 0)
        {
            e.Row.Cells[1].Style.Add("display", "none");

        }
        
    }
    protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            e.Row.Cells[0].Text = intSlNoE.ToString();
            intSlNoE += 1;
            //CheckBox chkSelectE = new CheckBox();
            //chkSelectE.ID = "chkSelectE";// +e.Row.RowIndex;
            //e.Row.Cells[4].Controls.Add(chkSelectE);
        }
        else
            intSlNoE = 1;

        if (e.Row.Cells.Count - 1 > 0)
        {
            e.Row.Cells[1].Style.Add("display", "none");

        }
    }

    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strWhere = "";
        if (ddlDesignation.SelectedValue != "")
        {
            if (ddlDesignation.SelectedValue != "0")
                strWhere = " AND PRLDesignationID=" + ddlDesignation.SelectedValue;
        }
        if (ddlDepartment.SelectedValue != "")
        {
            if (ddlDepartment.SelectedValue != "0")
            {
                if (strWhere == "")
                    strWhere = " AND PRLDepartmentID=" + ddlDepartment.SelectedValue;
                else
                    strWhere += " AND PRLDepartmentID=" + ddlDepartment.SelectedValue;
            }
        }
        gvEmployeeList.Visible = true;
        gvEmployeeList.Columns[1].Visible = true;
        SqlDataReader rdr6 = objCCWeb.BindReader("SELECT PRLEmployeeID,EmployeeCode,(FirstName+' '+MiddleName+' '+LastName) AS Employee,1 AS SelectValue FROM PRLEmployeeMaster WHERE PRLEmployeeID<>0 AND employeeStatus='N' " + strWhere + "");
        gvEmployeeList.DataSource = rdr6;
        gvEmployeeList.DataBind();
        rdr6.Close();
        rdr6.Dispose();
        gvEmployeeList.Columns[1].Visible = false;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        hidMessage.Value = "";
        btnNew.Enabled=false;
        btnEdit.Enabled=false;
        btnDelete.Enabled=false;
        btnSave.Enabled=true;
        ddlUserType.Enabled=true;
        ddlNewsMonthYear.Enabled = false;
        hidEditNew.Value="N~N";
        hidLoad.Value="N";
        txtMessageTitle.Text="";
        txtMessageTitle.ReadOnly=false;
        txtNewsDate.ReadOnly = false;
        txtmessageTillDate.ReadOnly = false;
        txtMessageTitle.Focus();
        txtMessage.Text="";
        txtMessage.ReadOnly=false;
        ddlStatus.Enabled=true;
        objCCWeb.FillDDLs(ddlBatch, "SELECt ClassID,ClassName1 FROM MTClassMAster  ORDER BY PriorityNo", "ClassID", "ClassName1", "");
        objCCWeb.FillDDLs(ddlDesignation, "SELECT PRLDesignationID,StaffDesignationName1 FROM PRLDesignationMaster", "PRLDesignationID", "StaffDesignationName1", "");
        
    }
    protected void btndblClick_Click(object sender, EventArgs e)
    {
        
        string[] strRow = hidEditNew.Value.Split('~');

        txtMessageTitle.Text = gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[2].Text;
        txtNewsDate.Text = gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[3].Text.Replace("&nbsp;", "");
        txtmessageTillDate.Text = gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[4].Text.Replace("&nbsp;", "");
        txtMessage.Text = gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[5].Text;
        ddlStatus.SelectedValue = gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[7].Text;
        ddlNewsMonthYear.SelectedValue = ((gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[3].Text == "&nbsp;") ? "" : Convert.ToDateTime(gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[3].Text, cinfo).Month.ToString() + '~' + Convert.ToDateTime(gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[3].Text, cinfo).Year.ToString());
        btnEdit.Enabled = true;
        btnDelete.Enabled = true;
        btnNew.Enabled = false;
        btnSave.Enabled = false;
        txtMessageTitle.ReadOnly = true;
        txtNewsDate.ReadOnly = true;
        txtmessageTillDate.ReadOnly = true;
        txtMessage.ReadOnly = true;
        ddlStatus.Enabled = false;
        ddlUserType.Enabled = false;
        gvMessages.Rows[Convert.ToInt32(strRow[1])].BackColor = System.Drawing.Color.FromName("#ffc0cb");
        hidMessage.Value = objCCWeb.ReturnSingleValue("SELECT Isnull(NewsFileName,'') FROM MTMessageMaster WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + ""); 
        SqlDataReader rdrUser = objCCWeb.BindReader("Select UserType,ClassID,StudentID,DesignationID,EmployeeID from MDMessageDetails WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + "");

        if (rdrUser.HasRows == false)//For All
        {
            ddlUserType.SelectedValue = "A";
            tblStudent.Visible = false;
            tblEmployee.Visible = false;
        }
        else
        {
            rdrUser.Read();

            if (rdrUser.GetValue(0).ToString() == "A")//For All
            {
                tblStudent.Visible = false;
                tblEmployee.Visible = false;
            }
            else if (rdrUser.GetValue(0).ToString() == "S")//For Student
            {
                tblStudent.Visible = true;
                tblEmployee.Visible = false;
                chkSSelectAll.Enabled = false;
                ddlBatch.Enabled = false;
                objCCWeb.FillDDLs(ddlBatch, "SELECT ClassID,ClassName1 FROM MTClassMAster ORDER BY PriorityNo", "ClassID", "ClassName1", "");
                ddlUserType.SelectedValue = "S";
                int intCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MDMessageDetails WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + "");
                if (intCount >= 1 )//For All Student
                {
                    if (Convert.ToInt32(rdrUser.GetValue(1)) == 0)
                    {
                        //gvStudentList.Visible = false;
                        gvStudentList.Visible = true;
                        gvStudentList.Columns[1].Visible = true;
                        SqlDataReader rdr81 = objCCWeb.BindReader("SELECT SYD.StudentID,AdmissionNo,(FirstName+''+MiddleName+''+LastName) AS EnrolleeName,1 AS SelectValue FROM SIStudentMAster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID= SYD.StudentID " +
                           " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND AcaStart=" + Session["AcaStart"] + " ANd StudentStatus='S'");
                        gvStudentList.DataSource = rdr81;
                        gvStudentList.DataBind();
                        rdr81.Close();
                        rdr81.Dispose();
                        SqlDataReader rdrEnrollee1 = objCCWeb.BindReader("SELECT StudentID FROM MDMessageDetails WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + "");
                        while (rdrEnrollee1.Read())
                        {
                            for (int i = 0; i < gvStudentList.Rows.Count; i++)
                            {
                                if (gvStudentList.Rows[i].Cells[1].Text == rdrEnrollee1.GetValue(0).ToString())
                                {
                                    ((CheckBox)gvStudentList.Rows[i].Cells[4].FindControl("chkSelectS")).Checked = true;
                                }
                                gvStudentList.Rows[i].Cells[4].Enabled = false;
                            }
                        }
                        rdrEnrollee1.Close();
                        rdrEnrollee1.Dispose();
                        gvStudentList.Columns[1].Visible = false;   


                    }
                    else//Particular Batch
                    {
                        
                        objCCWeb.FillDDLs(ddlBatch, "SELECT BatchID,BatchName FROM MTBatchMaster WHERE BatchStatus='A' AND BatchID IN(SELECT DISTINCT BatchID FROM MTEnrolleeMaster WHERE EnrolleeStatus='S') ORDER BY ExpectedStartDate DESC", "BatchID", "BatchName", "");
                        ddlBatch.SelectedValue = rdrUser.GetValue(1).ToString();
                        gvStudentList.Visible = true;
                        gvStudentList.Columns[1].Visible = true;
                        SqlDataReader rdr7 = objCCWeb.BindReader("SELECT EnrolleeID,EnrollmentNo,(FirstName+''+MiddleName+''+LastName) AS EnrolleeName,1 AS SelectValue FROM MTEnrolleeMaster WHERE BatchID=" + Convert.ToInt32(rdrUser.GetValue(1)));
                        gvStudentList.DataSource = rdr7;
                        gvStudentList.DataBind();
                        rdr7.Close();
                        rdr7.Dispose();
                        gvStudentList.Columns[1].Visible = false;
                    }

                    gvStudentList.Visible = true;
                    gvStudentList.Columns[1].Visible = true;
                    SqlDataReader rdr8 = objCCWeb.BindReader("SELECT SYD.StudentID,AdmissionNo,(FirstName+''+MiddleName+''+LastName) AS EnrolleeName,1 AS SelectValue FROM SIStudentMAster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID= SYD.StudentID " +
                       " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND AcaStart=" + Session["AcaStart"] + " ANd StudentStatus='S'");
                    gvStudentList.DataSource = rdr8;
                    gvStudentList.DataBind();
                    rdr8.Close();
                    rdr8.Dispose();

                    SqlDataReader rdrEnrollee = objCCWeb.BindReader("SELECT StudentID FROM MDMessageDetails WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + "");
                    while (rdrEnrollee.Read())
                    {
                        for (int i = 0; i < gvStudentList.Rows.Count; i++)
                        {
                            if (gvStudentList.Rows[i].Cells[1].Text == rdrEnrollee.GetValue(0).ToString())
                            {
                                ((CheckBox)gvStudentList.Rows[i].Cells[4].FindControl("chkSelectS")).Checked = true;
                            }
                            gvStudentList.Rows[i].Cells[4].Enabled = false;
                        }
                    }
                    rdrEnrollee.Close();
                    rdrEnrollee.Dispose();
                    gvStudentList.Columns[1].Visible = false;                    
                    

                }
                else//Particular Students
                {
                    string[] strCBID = objCCWeb.ReturnSingleValue("SELECT CAST(ClassID AS VARCHAR) FROM SIStudentMaster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID= SYD.StudentID WHERE SYD.SchoolID=" + Session["SchoolID"] + " AND AcaStart=" + Session["AcaStart"] + " and SYD.StudentID=" + Convert.ToInt32(rdrUser.GetValue(2)) + "").Split('~');
                    ddlBatch.SelectedValue = strCBID[0];
                    gvStudentList.Visible = true;
                    gvStudentList.Columns[1].Visible = true;
                    SqlDataReader rdr8 = objCCWeb.BindReader("SELECT SYD.StudentID,AdmissionNo,(FirstName+''+MiddleName+''+LastName) AS EnrolleeName,1 AS SelectValue FROM SIStudentMAster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID= SYD.StudentID " +
                       " WHERE ClassID=" + Convert.ToInt32(strCBID[0]) + " AND SYD.SchoolID=" + Session["SchoolID"] + " AND AcaStart=" + Session["AcaStart"] + " ANd StudentStatus='S'");
                    gvStudentList.DataSource = rdr8;
                    gvStudentList.DataBind();
                    rdr8.Close();
                    rdr8.Dispose();

                    SqlDataReader rdrEnrollee = objCCWeb.BindReader("SELECT StudentID FROM MDMessageDetails WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + "");
                    while (rdrEnrollee.Read())
                    {
                        for (int i = 0; i < gvStudentList.Rows.Count; i++)
                        {
                            if (gvStudentList.Rows[i].Cells[1].Text == rdrEnrollee.GetValue(0).ToString())
                            {
                                ((CheckBox)gvStudentList.Rows[i].Cells[4].FindControl("chkSelectS")).Checked = true;
                            }
                            gvStudentList.Rows[i].Cells[4].Enabled = false;
                        }
                    }
                    rdrEnrollee.Close();
                    rdrEnrollee.Dispose();
                    gvStudentList.Columns[1].Visible = false;
                }
            }
           
            if (rdrUser.GetValue(0).ToString() == "E")//For Employee
            
            {
                tblStudent.Visible = false;
                tblEmployee.Visible = true;
                chkESelectAll.Enabled = false;
                ddlDesignation.Enabled = false;
                ddlDepartment.Enabled = false;
                objCCWeb.FillDDLs(ddlDesignation, "SELECT 0 as PRLDesignationID,'' as StaffDesignationName1 UNION SELECT PRLDesignationID,StaffDesignationName1 FROM PRLDesignationMaster WHERE PRLDesignationID IN (SELECT DISTINCT PRLDesignationID FROM PRLEmployeeMaster WHERE EmployeeStatus='N') ORDER BY StaffDesignationName1", "PRLDesignationID", "StaffDesignationName1", "");
                objCCWeb.FillDDLs(ddlDepartment, "SELECT 0 as PRLDepartmentID,'' as DepartmentName1 UNION SELECT PRLDepartmentID,DepartmentName1 FROM PRLDepartmentMaster WHERE PRLDepartmentID<>0 ORDER BY DepartmentName1", "PRLDepartmentID", "DepartmentName1", "");
                ddlUserType.SelectedValue = "E";
                int intECount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MDMessageDetails WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + " and DesignationID <>0");
                if (intECount == 0)
                {
                    if (Convert.ToInt32(rdrUser.GetValue(3)) == 0)//All Employee
                    {
                        gvEmployeeList.Visible = false;
                        gvEmployeeList.Visible = true;
                        gvEmployeeList.Columns[1].Visible = true;
                        SqlDataReader rdr9 = objCCWeb.BindReader("SELECT PRLEmployeeID,EmployeeCode,(FirstName+' '+MiddleName+' '+LastName) AS Employee,1 AS SelectValue FROM PRLEmployeeMaster WHERE PRLEmployeeID<>0 AND EmployeeStatus='N'");
                        gvEmployeeList.DataSource = rdr9;
                        gvEmployeeList.DataBind();
                        rdr9.Close();
                        rdr9.Dispose();

                        SqlDataReader rdrAEmployee = objCCWeb.BindReader("SELECT EmployeeID FROM MDMessageDetails WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + "");
                        while (rdrAEmployee.Read())
                        {
                            for (int i = 0; i < gvEmployeeList.Rows.Count; i++)
                            {
                                if (gvEmployeeList.Rows[i].Cells[1].Text == rdrAEmployee.GetValue(0).ToString())
                                {
                                    ((CheckBox)gvEmployeeList.Rows[i].Cells[4].FindControl("chkSelectE")).Checked = true;
                                }
                                gvEmployeeList.Rows[i].Cells[4].Enabled = false;
                            }
                        }
                        gvEmployeeList.Columns[1].Visible = false;
                        rdrAEmployee.Close();
                        rdrAEmployee.Dispose();
                    }

                    else//Particular Employee
                    {
                        string[] strCBID = objCCWeb.ReturnSingleValue("select PRLDesignationID from PRLDesignationMaster PRL inner join MDMessageDetails MD on MD.DesignationID = PRl. PRLDesignationID where MD.DesignationID=" + Convert.ToInt32(rdrUser.GetValue(3)) + "").Split('~');
                        ddlDesignation.SelectedValue = strCBID[0];
                        //ddlDesignation.SelectedValue = rdrUser.GetValue(3).ToString();
                        gvEmployeeList.Visible = true;
                        gvEmployeeList.Columns[1].Visible = true;
                        SqlDataReader rdr10 = objCCWeb.BindReader("SELECT PRLEmployeeID,EmployeeCode,(FirstName+' '+MiddleName+' '+LastName) AS Employee,1 AS SelectValue FROM PRLEmployeeMaster WHERE PRLEmployeeID<>0 AND EmployeeStatus='N' AND PRLDesignationID=" + Convert.ToInt32(rdrUser.GetValue(3)) + "");
                        gvEmployeeList.DataSource = rdr10;
                        gvEmployeeList.DataBind();
                        rdr10.Close();
                        rdr10.Dispose();

                      
                        SqlDataReader rdrAEmployee = objCCWeb.BindReader("SELECT EmployeeID FROM MDMessageDetails WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + "");
                        while (rdrAEmployee.Read())
                        {
                            for (int i = 0; i < gvEmployeeList.Rows.Count; i++)
                            {
                                if (gvEmployeeList.Rows[i].Cells[1].Text == rdrAEmployee.GetValue(0).ToString())
                                {
                                    ((CheckBox)gvEmployeeList.Rows[i].Cells[4].FindControl("chkSelectE")).Checked = true;
                                }
                                gvEmployeeList.Rows[i].Cells[4].Enabled = false;
                            }
                        }

                        gvEmployeeList.Columns[1].Visible = false;

                        rdrAEmployee.Close();
                        rdrAEmployee.Dispose();
                        
                    }
                }
                
                else //Particular Designation Employee
                {

                    string strEmployeeID = "";
                    string EmployeeID = objCCWeb.ReturnSingleValue("SELECt Max(EmployeeID) From MDMessageDetails Where MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + "");
                    string strEmpDepDes = objCCWeb.ReturnSingleValue("SELECT  Convert(varchar,PRLDesignationID)+'^'+Convert(Varchar,PRLDepartmentID) From PRLEmployeeMaster WHERE PRLEmployeeID='" + EmployeeID + "'");
                    string[] strDep = strEmpDepDes.Split('^');
                    if (strDep[1] != "")
                        ddlDepartment.SelectedValue = strDep[1];
                    if (strDep[0] != "")
                        ddlDesignation.SelectedValue = strDep[0];

                    SqlDataReader rdr = objCCWeb.BindReader("SELECT PRLEmployeeID,EmployeeCode,(FirstName+' '+MiddleName+' '+LastName) AS Employee  FROM PRLEmployeeMaster WHERE PRLEmployeeID<>0 AND EmployeeStatus='N' AND PRLDesignationID=" + strDep[0] + " AND PRLDepartmentID=" + strDep[1] + "");
                    gvEmployeeList.DataSource = rdr;
                    gvEmployeeList.DataBind();

                    SqlDataReader rdrEmployeeID = objCCWeb.BindReader("SELECT EmployeeID FROM MDMessageDetails WHERE MessageID=" + gvMessages.Rows[Convert.ToInt32(strRow[1])].Cells[1].Text + "");
                    while (rdrEmployeeID.Read())
                    {
                        strEmployeeID = rdrEmployeeID.GetValue(0).ToString();
                        for (int i = 0; i < gvEmployeeList.Rows.Count; i++)
                        {
                            if (gvEmployeeList.Rows[i].Cells[1].Text.Trim() == rdrEmployeeID.GetValue(0).ToString())
                            {
                                ((CheckBox)gvEmployeeList.Rows[i].Cells[4].FindControl("chkSelectE")).Checked = true;
                            }
                            gvEmployeeList.Rows[i].Cells[4].Enabled = false;
                        }
                    }

                    gvEmployeeList.Columns[1].Visible = false;
                    rdrEmployeeID.Close();
                    rdrEmployeeID.Dispose();
                }
            }

            if (rdrUser.GetValue(0).ToString() == "A")
            {
                ddlUserType.SelectedValue = "A";
                tblStudent.Visible = false;
                tblEmployee.Visible = false;
            }
            
        }
        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>document.getElementById('gvMessages').rows[" + Convert.ToInt32(strRow[1]) + " + 1].style.cssText = 'color: green; font-weight: bold; cursor: pointer;  background: #ffc0cb;'</script>");   
    }
   
    
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string[] strRow = hidEditNew.Value.Split('~');
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
        ddlUserType.Enabled = false;
        btnSave.Enabled = true; ;
        btnNew.Enabled = false;
        txtMessageTitle.ReadOnly = false;
        ddlNewsMonthYear.Enabled = false;
        txtNewsDate.ReadOnly = false;
        txtmessageTillDate.ReadOnly = false;
        txtMessage.ReadOnly = false;
        ddlStatus.Enabled = true;
        
        if (tblStudent.Visible == true)
        {
            //ddlCourse.Enabled = true;
            ddlBatch.Enabled = true;
            chkSSelectAll.Enabled = true;
            for (int i = 0; i < gvStudentList.Rows.Count; i++)
            {
                gvStudentList.Rows[i].Cells[4].Enabled = true;
            }
        }
        if (tblEmployee.Visible == true)
        {
            ddlDesignation.Enabled = true;
            ddlDepartment.Enabled = true;
            chkESelectAll.Enabled = true;
            for (int i = 0; i < gvEmployeeList.Rows.Count; i++)
            {
                gvEmployeeList.Rows[i].Cells[4].Enabled = true;
            }
        }
        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>document.getElementById('gvMessages').rows[" + Convert.ToInt32(strRow[1]) + " + 1].style.cssText = 'color: green; font-weight: bold; cursor: pointer;  background: #ffc0cb;'</script>");   

        //gvMessages.Rows[Convert.ToInt32(strRow[1])].BackColor = System.Drawing.Color.FromName("#ffc0cb");
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strWhere = "";
        if (ddlDepartment.SelectedValue != "")
        {
            if (ddlDepartment.SelectedValue != "0")
                strWhere = " AND PRLDepartmentID=" + ddlDepartment.SelectedValue;
        }
        if (ddlDesignation.SelectedValue != "")
        {
            if (ddlDesignation.SelectedValue != "0")
            {
                if(strWhere == "")
                    strWhere = " AND PRLDesignationID=" + ddlDesignation.SelectedValue;
                else
                    strWhere += " AND PRLDesignationID=" + ddlDesignation.SelectedValue;
            }
        }
        gvEmployeeList.Columns[1].Visible = false;
        SqlDataReader rdr6 = objCCWeb.BindReader("SELECT PRLEmployeeID,EmployeeCode,(FirstName+' '+MiddleName+' '+LastName) AS Employee,1 AS SelectValue FROM PRLEmployeeMaster WHERE PRLEmployeeID<>0 AND EmployeeStatus='N' " + strWhere + "");
        gvEmployeeList.DataSource = rdr6;
        gvEmployeeList.DataBind();
        rdr6.Close();
        rdr6.Dispose();
        //gvEmployeeList.Columns[1].Visible = false;
    }
    protected void ddlNewsMonthYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (hidLoad.Value != "N")
        {
            tblEmployee.Visible = false;
            tblStudent.Visible = false;
            BindGrid();

        }
    }
    protected void btnPrintgrid_Click(object sender, EventArgs e)
    {
        if (gvMessages.Rows.Count > 0)
        {
            gvMessages.Columns[1].Visible = false;
            objCCWeb.ExportToExcel(gvMessages, frmMessage, "News List", "Excel");
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>" + strHideID + "</script>");
            gvMessages.Columns[3].Visible = true;
        }
    }
  
}
