using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Inbox : System.Web.UI.Page
{
    CCWeb ObjccWeb = new CCWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetNoStore();
        Response.AddHeader("Cache-control", "no-store,must-revalidate,private,no-cache,no-store,pre-check=0,post-check=0,max-stale=0");
        Response.AddHeader("Pragma", "no-cache");
        Response.AddHeader("Expires", "0");

        if (Session["UID"] == null || Session["SchoolID"] == null || Session["StudentID"] == null)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
            return;

        }
        if (Session["TOUserID"] != null )
        {
            HidUserToID.Value = Session["TOUserID"].ToString();
            txtMailTo.Text = Session["TOUserID"].ToString();
            Session["TOUserID"] = null;
        }
        if (Request.QueryString["Flag"] != null)
        {
            string strQuery = "";
            if (Request.QueryString["Flag"] == "Read")
            {
            //    strQuery = "Update MessageSendDetails set ReadUnread='R' where MessageID in (" + Request.QueryString["Value"] + ")";
            }

            string strResult = ObjccWeb.ReturnSingleValue(strQuery);
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(strResult);
            Response.End();
        }
        if (!IsPostBack)
        {
            HidType.Value = "I";
            btnMailCancel_Click(sender, e);
            if (gvDetails.Rows.Count > 10)
            {
                Blank.Style.Add("display", "none");
            }
            else
            {
                Blank.Style.Add("display", "block");
            }
        }

    }
    protected void gvAdmin_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.EmptyDataRow)
        {
            e.Row.Cells[1].Style.Add("display", "none");
        }
    }
    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.EmptyDataRow && e.Row.RowType != DataControlRowType.Pager)
        {

            e.Row.Cells[1].Style.Add("display", "none");
            e.Row.Cells[5].Style.Add("display", "none");
            e.Row.Cells[6].Style.Add("display", "none");
            e.Row.Cells[7].Style.Add("display", "none");
            //e.Row.Cells[8].Style.Add("display", "none");
            //if (HidType.Value != "I")
            //e.Row.Cells[9].Style.Add("display", "none");
            if (e.Row.Cells[6].Text.Trim().ToUpper() == "UR")
            {
                e.Row.ForeColor = System.Drawing.Color.Blue;
                e.Row.Style.Add("font-weight", "bold;");
            }
        }
        
        if (e.Row.RowIndex >= 0)
        {
            //if (HidType.Value == "I")
            //{
            //    ((LinkButton)e.Row.Cells[9].FindControl("linkReply")).Attributes.Add("onclick", "javascript:return fReply(" + e.Row.RowIndex + ")");
            //}
            e.Row.Attributes.Add("ondblclick", "return fSelctedIndexChange(" + e.Row.RowIndex + ")");
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer';this.style.cursor='pointer';"); 
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strID = "";
        txtMessage.Text = ObjccWeb.fReplaceChars(txtMessage.Text);
        for (int i = 0; i < gvDetails.Rows.Count; i++)
        {
            if (((CheckBox)gvDetails.Rows[i].Cells[0].FindControl("ChbSelect")).Checked == true)
            {
                strID = strID + gvDetails.Rows[i].Cells[1].Text.Trim() + ","; 
            }
        }

        if (strID != "")
        {
            strID = strID.Remove(strID.Length - 1);

            if (ddlSelect.SelectedValue == "D")
            {
                //if (ObjccWeb.ReturnSingleValue("select distinct status from MessageSendDetails where MessageID in (" + strID + ")") == "S")
                //{
                //    ObjccWeb.ExecuteQuery("DELETE FROM MessageSendDetails where MessageID in (" + strID + ")"); 
                //}
                //else
                //{ 
                //    ObjccWeb.ExecuteQuery("Update MessageSendDetails set Status='D' where MessageID in (" + strID + ")");
                //}
            }

            if (ddlSelect.SelectedValue == "S")
            {
            //   ObjccWeb.ExecuteQuery("Update MessageSendDetails set Status='S' where MessageID in (" + strID + ")"); 
            }
            if (ddlSelect.SelectedValue == "UR")
            {
              //  ObjccWeb.ExecuteQuery("Update MessageSendDetails set ReadUnread='UR' where MessageID in (" + strID + ")");

            }
            if (ddlSelect.SelectedValue == "R")
            {
                //ObjccWeb.ExecuteQuery("Update MessageSendDetails set ReadUnread='R' where MessageID in (" + strID + ")");
            }

            if (ddlSelect.SelectedValue == "I")
            {
               // ObjccWeb.ExecuteQuery("Update MessageSendDetails set Status='' where MessageID in (" + strID + ")");

            }
        }
            gvDetails.DataSource = ObjccWeb.BindDataSet(" Exec SpMessageBind  " + Session["UID"] + ",'I'");
            gvDetails.DataBind();
            HidType.Value = "I";
       
    }
    //protected void chkAdmin_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkAdmin.Checked == true)
    //    {
    //        gvsendClas.DataSource = ObjccWeb.BindReader("Exec sp_UserMessageSend 'A',0,0");
    //        gvsendClas.DataBind();
    //    }
    //}
    protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (HidType.Value == "I")
        {
            gvDetails.PageIndex = e.NewPageIndex;
            gvDetails.DataSource = ObjccWeb.BindDataSet(" Exec SpMessageBind  " + Session["UID"] + ",'I'");
            gvDetails.DataBind();
        }
        if (HidType.Value == "O")
        {
            gvDetails.PageIndex = e.NewPageIndex;
            gvDetails.DataSource = ObjccWeb.BindDataSet(" Exec SpMessageBind  " + Session["UID"] + ",'O'");
            gvDetails.DataBind();
        }
        if (HidType.Value == "S")
        {
            gvDetails.PageIndex = e.NewPageIndex;
            gvDetails.DataSource = ObjccWeb.BindDataSet(" Exec SpMessageBind  " + Session["UID"] + ",'S'");
            gvDetails.DataBind();
        }

    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        HidType.Value = "O";
        gvDetails.DataSource = ObjccWeb.BindDataSet(" Exec SpMessageBind  " + Session["UID"] + ",'O'");
        gvDetails.DataBind();
        

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        HidType.Value = "S";
        gvDetails.DataSource = ObjccWeb.BindDataSet(" Exec SpMessageBind  " + Session["UID"] + ",'S'");
        gvDetails.DataBind();
       
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        HidType.Value = "I";
        gvDetails.DataSource = ObjccWeb.BindDataSet(" Exec SpMessageBind  " + Session["UID"] + ",'I'");
        gvDetails.DataBind();
       
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            List<string> strQuery = new List<string>();
            string UpdatedFile = "";
            txtMessage.Text = ObjccWeb.fReplaceChars(txtMessage.Text);
            string File = FileUpload1.FileName.ToString();            
            string strAttachID = ObjccWeb.ReturnSingleValue("Select Isnull(Max(AttachmentID)+1,0) From MessageFileUpload");
            /*-----Added By Manju on 19-07-2012--------*/
            string strUserName = "";
            /*-----End of Added By Manju on 19-07-2012--------*/
            if (strAttachID == "0")
            {
                strAttachID = "1";
            }
            
            HidAttach.Value = strAttachID;


            if (txtMailTo.Text != "" && txtMailFrom.Text != "")
            {

                string file = FileUpload1.FileName.ToString();
                if (file != "")
                {
                    UpdatedFile = "";
                    UpdatedFile = file;
                    SaveFile(FileUpload1);
                    strQuery.Add("Insert into MessageFileUpload values (" + strAttachID + ",'" + HidFilename.Value + "'," + Session["UID"] + ",getdate())");
                    SqlDataReader rdr1 = ObjccWeb.BindReader("Select UID From MTUSerMaster Where UserID in ('" + txtMailTo.Text.Trim().Replace(",", "','") + "')");
                    while (rdr1.Read())
                    {
                      //  strQuery.Add("Insert Into MessageSendDetails select ISNULL(Max(MessageID),0)+1," + Session["UID"] + "," + rdr1.GetValue(0).ToString() + ",'" + txtMailSubject.Text.Trim() + "','" + txtMessage.Text.Trim().Replace("'", "''") + "',getdate(),'UR'," + Session["AcaStart"] + "," + Session["StudentID"] + ",''," + strAttachID + " from MessageSendDetails");
                     }
                    rdr1.Close();
                    rdr1.Dispose();
                }
                else
                {
                    SqlDataReader rdr1 = ObjccWeb.BindReader("Select UID From MTUSerMaster Where UserID in ('" + txtMailTo.Text.Trim().Replace(",", "','") + "')");
                    while (rdr1.Read())
                    {
                       // strQuery.Add("Insert Into MessageSendDetails select ISNULL(Max(MessageID),0)+1," + Session["UID"] + "," + rdr1.GetValue(0).ToString() + ",'" + txtMailSubject.Text.Trim() + "','" + txtMessage.Text.Trim().Replace("'", "''") + "',getdate(),'UR'," + Session["AcaStart"] + "," + Session["StudentID"] + ",'',0 from MessageSendDetails");
                    }
                    rdr1.Close();
                    rdr1.Dispose();

                }


                //string file = FileUpload1.FileName.ToString();
                //if (file != "")
                //{
                //    UpdatedFile = "";
                //    UpdatedFile = file;
                //    SaveFile(FileUpload1);
                //    SqlDataReader rdr1 = ObjccWeb.BindReader("Select UID,UserTypeID,UserName,UserID From MTUSerMaster Where UserID in ('" + txtMailTo.Text.Trim().Replace(",", "','") + "')");
                //    SqlDataReader rdr3 = ObjccWeb.BindReader("Select UID,UserTypeID,UserName,UserID From MTUSerMaster Where UserID in ('" + txtMailTo.Text.Trim().Replace(",", "','") + "') AND UserTypeID=3");
                //    while (rdr3.Read())
                //    {
                //        strUserName += rdr3.GetValue(2).ToString() + "(" + rdr3.GetValue(3).ToString() + "),";

                //    }
                //    rdr3.Close();
                //    rdr3.Dispose();
                //    while (rdr1.Read())
                //    {
                //        if (rdr1.GetValue(1).ToString() == "3")
                //        {
                //            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>HideComposeBox();alert('This Message Cannot Be Send To User " + strUserName + "');</script>");
                //            //return;
                //        }
                //        else
                //        {
                //            if (ObjccWeb.ReturnNumericValue("SELECT COUNT(*) FROM MessageSendDetails") == 0)
                //            {
                //                strResult = ObjccWeb.ExecuteQuery("Insert Into MessageSendDetails(MessageID,FromUID,ToUID,Subject,Contents,Date,ReadUnread,AcaStart,StudentID,Status,AttachmentID) VALUES (0,0,0,'','',NULL,'',0,0,'',0)");
                //            }
                //            strQuery.Add("Insert Into MessageSendDetails select Isnull(Max(MessageID)+1,1)," + Session["UID"] + "," + rdr1.GetValue(0).ToString() + ",'" + txtMailSubject.Text.Trim() + "','" + txtMessage.Text.Trim().Replace("'", "''") + "',getdate(),'UR'," + Session["AcaStart"] + "," + Session["StudentID"] + ",''," + strAttachID + " from MessageSendDetails");
                //            strQuery.Add("Insert into MessageFileUpload values (" + strAttachID + ",'" + HidFilename.Value + "'," + Session["UID"] + ",getdate())");
                //        }
                //     }
                //    rdr1.Close();
                //    rdr1.Dispose();
                //}
                //else
                //{
                //    SqlDataReader rdr1 = ObjccWeb.BindReader("Select UID,UserTypeID,UserName,UserID From MTUSerMaster Where UserID in ('" + txtMailTo.Text.Trim().Replace(",", "','") + "')");
                //    SqlDataReader rdr2 = ObjccWeb.BindReader("Select UID,UserTypeID,UserName,UserID From MTUSerMaster Where UserID in ('" + txtMailTo.Text.Trim().Replace(",", "','") + "') AND UserTypeID=3");
                //    while (rdr2.Read())
                //    {
                //        strUserName += rdr2.GetValue(2).ToString() + "(" + rdr2.GetValue(3).ToString() + "),";

                //    }
                //    rdr2.Close();
                //    rdr2.Dispose();
                //    while (rdr1.Read())
                //    {
                //        if (rdr1.GetValue(1).ToString() == "3")
                //        {

                //            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>HideComposeBox();alert('This Message Cannot Be Send To User " + strUserName + "');</script>");

                //            //return;
                //        }
                //        else
                //        {
                //            if (ObjccWeb.ReturnNumericValue("SELECT COUNT(*) FROM MessageSendDetails") == 0)
                //            {
                //                strResult = ObjccWeb.ExecuteQuery("Insert Into MessageSendDetails(MessageID,FromUID,ToUID,Subject,Contents,Date,ReadUnread,AcaStart,StudentID,Status,AttachmentID) VALUES (0,0,0,'','',NULL,'',0,0,'',0)");
                //            }
                //            strQuery.Add("Insert Into MessageSendDetails select Isnull(Max(MessageID)+1,1)," + Session["UID"] + "," + rdr1.GetValue(0).ToString() + ",'" + txtMailSubject.Text.Trim() + "','" + txtMessage.Text.Trim().Replace("'", "''") + "',getdate(),'UR'," + Session["AcaStart"] + "," + Session["StudentID"] + ",'',0 from MessageSendDetails");
                //        }
                        
                //    }
                //    rdr1.Close();
                //    rdr1.Dispose();
                
                //}
            }
            //if (File != "")
            //{
            //    SaveFile(FileUpload1);
            //    strQuery.Add("Insert Into MessageFileUpload ");

            //}

            strResult = ObjccWeb.ExecuteQueryList(strQuery);
            if (strResult == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>document.getElementById('divCompose').style.display='none';document.getElementById('divInbox').style.display='';document.getElementById('divSendTo').style.display='none';document.getElementById('divdet').style.display='none';alert('Send SucessFully');</script>");
                hidEnabl.Value = "";
            }

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }

    protected void SaveFile(FileUpload UploadAssignment)
    {
        try
        {
            string strEbookPath = "";
            string strEbookName = "";
            string strPathExt = "";
            string[] strFile ;
            string strPre = "";
            if (FileUpload1.HasFile)
            {
                strEbookPath = FileUpload1.PostedFile.FileName.ToString();
                strEbookName = FileUpload1.FileName.ToString();
                //strEbookName = strEbookName.Split('.')[0];
                strFile = strEbookName.Split('.');
                strPathExt = strEbookPath.Split('.')[1];
                if (strFile.Length > 2)
                {
                    //strPre = strFile.Length - 1 + '.' + HidAttach.Value;
                    strPre = strEbookName.Replace("." + strFile[strFile.Length - 1], "");
                    strPre = strPre + '.' + HidAttach.Value;

                    HidFilename.Value = strPre + '.' + strFile[strFile.Length - 1];
                }
                else
                {
                    strPre = strFile[0] + '.' + HidAttach.Value;

                    HidFilename.Value = strPre + '.' + strPathExt;
                }
                

                if (File.Exists(Server.MapPath("Messages/") + strEbookPath) == true)
                {
                    File.Delete(Server.MapPath("Messages/") + strEbookPath);
                }
                FileUpload1.SaveAs(Server.MapPath("Messages/") + HidFilename.Value);
            
            }

        }
        catch (System.IO.IOException)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('The File Is In Use or Already Exist At Destination Location.');</script>");
        }
    
    
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        if(HidUserToID.Value=="")
        {
            Response.Redirect("Inbox.aspx");
        }
        else
        {
            Response.Redirect("PLStaffDirectory.aspx");
        
        }

    }
    protected void gvsendClas_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType != DataControlRowType.EmptyDataRow)
        {
            e.Row.Cells[1].Style.Add("display", "none");
        
        }

    }
    protected void gvSubTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.EmptyDataRow)
        {
            e.Row.Cells[1].Style.Add("display", "none");

        }
    }
    protected void gvSubTeacher_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.EmptyDataRow)
        {
            e.Row.Cells[1].Style.Add("display", "none");

        }
    }
    protected void gvClassTchr_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.EmptyDataRow)
        {
            e.Row.Cells[1].Style.Add("display", "none");

        }

    }

    protected void gvPrin_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.EmptyDataRow)
        {
            e.Row.Cells[1].Style.Add("display", "none");

        }

    }
    protected void btnMailCancel_Click(object sender, EventArgs e)
    {
        txtMailFrom.Text = "";
        txtMailTo.Text = "";
        txtMailSubject.Text = "";
        txtMessage.Text = "";

        gvDetails.DataSource = ObjccWeb.BindDataSet(" Exec SpMessageBind  " + Session["UID"].ToString() + ",'I'");
        gvDetails.DataBind();

        txtMailFrom.Text = ObjccWeb.ReturnSingleValue("Select UserName from MTUserMaster Where UID=" + Session["UID"] + "");
        txtMailFrom.ReadOnly = true;

        gvsendClas.DataSource = ObjccWeb.BindDataSet("Select UID,USerID,UserNAme From SIStudentYearwiseDetails SYD inner join MTUserMaster UM on SYD.StudentID=UM.EmployeeIDStudentID " +
                               " Where ClassID in(Select ClassID From SIStudentYearwiseDetails where StudentID=" + Session["StudentID"] + " and AcaStart=" + Session["AcaStart"] + ")" +
                               " and SectionID in (Select SectionID From SIStudentYearwiseDetails where StudentID=" + Session["StudentID"] + " and AcaStart=" + Session["AcaStart"] + ")and UserTypeID=3 and  StudentID <>" + Session["StudentID"] + " ");
        gvsendClas.DataBind();
        gvSubTeacher.DataSource = ObjccWeb.BindDataSet("Select UID,UserID,SubjectName1 ,FirstName+' '+MiddleName+' '+LastName AS UserName From SubjectTeacherAssignment STA inner join ExamSubjectMaster SM on " +
                                 " SM.ExamSubjectID=STA.SubjectID inner join PRLEmployeeMAster PEM  on STA.EmpID=PEM.PrlEmployeeID Inner join PrlQualificationMaster PQM on PQM.PRLQualificationID=PEM.PRLQualificationID " +
                                 " inner join MTUserMaster UM on UM.EmployeeIDStudentID=PEM.PrlEmployeeID  where STA.ClassID=(Select classID from SistudentyearwiseDetails where StudentID=" + Session["StudentID"] + " and AcaStart=" + Session["AcaStart"] + ") " +
                                 " and STA.SectionID=(Select SectionID From SistudentyearwiseDetails where StudentID=" + Session["StudentID"] + " and AcaStart=" + Session["AcaStart"] + ") and  STA.SchoolID=" + Session["SchoolID"] + " and STA.AcaStart=" + Session["AcaStart"] + " " +
                                 " and UserTypeID=1");
        gvSubTeacher.DataBind();

        gvClassTchr.DataSource = ObjccWeb.BindDataSet("Select UID,UserID,FirstName+' '+MiddleName+' '+LastName AS UserName From MTClassTeacherAssigner STA " +
                                                        " INNER join PRLEmployeeMAster PEM  on STA.PRLEmployeeID=PEM.PrlEmployeeID " +
                                                        " INNER join MTUserMaster UM on UM.EmployeeIDStudentID=PEM.PrlEmployeeID  where STA.ClassID=(Select classID from SistudentyearwiseDetails " +
                                                        " where StudentID=" + Session["StudentID"] + " and AcaStart=" + Session["AcaStart"] + ")  and STA.SectionID=(Select SectionID From SistudentyearwiseDetails " +
                                                        " where StudentID=" + Session["StudentID"] + " and AcaStart=" + Session["AcaStart"] + ") and  STA.SchoolID=" + Session["SchoolID"] + " and STA.AcaStart=" + Session["AcaStart"] + "  and UserTypeID=1 ");

        gvClassTchr.DataBind();
        
        gvAdmin.DataSource = ObjccWeb.BindDataSet("Select UID,UserID,UserName AS UserName From    MTUSerMaster   " +
        " where  UserTypeID=0 AND UserStatus='Y' AND UID=1  AND UID<>" + Session["UID"] + "");
        gvAdmin.DataBind();




        //////gvPrin.DataSource = ObjccWeb.BindDataSet("Select UID,UserID,UserName AS UserName From    MTUSerMaster   " +
        //////" where  UserTypeID=4 AND UserStatus='Y'  AND UID<>" + Session["UID"] + "");
        //////gvPrin.DataBind();


        gvPrin.DataSource = ObjccWeb.BindDataSet("Select UID,UserID,UserName AS UserName From    MTUSerMaster   " +
        " where  UserTypeID=1 AND UserStatus='Y'  and EmployeeIDStudentID=1 AND UID<>" + Session["UID"] + "");
        gvPrin.DataBind();

        HidPrincipal.Value = ObjccWeb.ReturnSingleValue("Select Cast (UID as varchar)+'~'+UserID+'~'+Username From MTUserMaster Where UserTypeID=4");
        hidAdmin.Value = ObjccWeb.ReturnSingleValue("Select Cast (UID as varchar)+'~'+UserID+'~'+Username From MTUserMaster Where UserTypeID=0");
            
    }
}
