/*
    Project Name            :   CampusCare
    Client                  :   
    Database                :   SQL Server 2000
    Front-End               :   ASP.NET With C#, Java Script, Ajax
    Reporting Tool          :   Crystal Report 11.0
    Team                    :   Sandhya,Tinu,Ushas,Jitender Kumar
    Tables                  :   MTInstitutionMaster
    Procedures              :   spInstitutionMaster
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
using System.Collections.Generic;
using System.IO;
using System.Text;

public partial class MTInstitutionMaster : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
 //   protected static string strNewOption;
  //  protected static string strEditOption;
 //   protected static string strDeleteOption;
    protected static string strType;
    protected static string strAddPhoto = "Add Photo";
    protected static string strRemovePhoto = "Remove Photo";
    protected static string strChangePhoto = "Change Photo";
    String varData;
    protected static string strHideID = "document.getElementById('txtStudCount').readOnly=true; " +
            " document.getElementById('txtBoys').readOnly=true; document.getElementById('txtGirls').readOnly=true; " +
            " document.getElementById('trSchool').style.display='none'; document.getElementById('trBankacc').style.display='none';" +
            " document.getElementById('btnNew').style.display='none';  document.getElementById('btnDelete').style.display='none'; ";
                                    
    protected void Page_Load(object sender, EventArgs e)
    {        
        ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script language='javascript'>" + strHideID + "</script>");
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
        if ((objCCWeb.ReturnNumericValue("SELECT Count(*) FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuInstitutionMaster'") == 0) || (objCCWeb.ReturnSingleValue("SELECT ISNULL(VisibleOption,'N') FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuInstitutionMaster'") == "N"))
        {
            Session.Clear();
            Response.Redirect("Logon.aspx");
            return;
        }
        if (objCCWeb.pCheckText(frmMTInstitutionMaster) == true)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
            return;
        }
        //if ((Session["Type"] == null) || (Session["Type"].ToString() == "1"))
        //{
        //    strType = "ltr";
        //}
        //else
        //{
        //    strType = "rtl";
        //} 
        if (!IsPostBack)
        {
            hidCache.Value = "";
            strAddPhoto = "Add Photo";
            strRemovePhoto = "Remove Photo";
            strChangePhoto = "Change Photo";
            gvInstitute.Attributes.Add("bordercolor", "#FFC1A4");
            txtInstitution1.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
            txtInstitution2.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            txtEmail.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
            txtPincode.Attributes.Add("onkeypress", "javascript:return Restrict_Pincode(event);");
            //if (Session["Type"]== "1")
            //{                             
                txtAddress.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtReportHeader.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtCity.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtState.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtTelephone.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtFax.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");                
                txtAffiliation.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtMedium.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtEstablishedOn.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtEstablishmentCode.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtBankACNo.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtMotto.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtDirector.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtDirPhone.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtPrincipal.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtPriPhone.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtVicePrincipal.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtVicePriPhone.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtAdministrator.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                txtAdmPhone.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event);");
                //txtAffiliation.Attributes.Add("onkeyup", "javascript:return fFillListBox('FillAffiCode',event)");
                AutoCompleteExtender.CompletionSetCount = Convert.ToInt32(Session["SchoolID"].ToString() + "000" + Session["AcaStart"].ToString());
          
            //}
            //else
            //{                
            //    txtAddress.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtReportHeader.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtCity.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtState.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtTelephone.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtFax.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");                
            //    txtAffiliation.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtMedium.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtEstablishedOn.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtEstablishmentCode.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtBankACNo.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtMotto.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtDirector.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtDirPhone.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtPrincipal.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtPriPhone.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtVicePrincipal.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtVicePriPhone.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtAdministrator.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");
            //    txtAdmPhone.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event);");                
            //}
            PGetOption();
            BindDDL();
            foreach (Control C in frmMTInstitutionMaster.Controls)
            {
                if (C.GetType().FullName == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)C).Attributes.Add("AutoComplete", "off");
                }
            }
            btnCancel_Click(sender, e);
            pDisplayType();
        }

    }
    protected void pDisplayType()
    {
        try
        {
            //foreach (Control frmControl in frmMTInstitutionMaster.Controls)
            //{                
            //    if (frmControl.GetType().FullName == "System.Web.UI.WebControls.Label")
            //    {
            //        ((Label)frmControl).Text = objCCWeb.ReturnSingleValue("SELECT  Caption" + Session["Type"].ToString() + " FROM MTFormControlMaster WHERE   FormID=116 AND ControlName='" + ((Label)frmControl).ID.Trim() + "' ");
            //    }
            //    if (frmControl.GetType().FullName == "System.Web.UI.WebControls.Button")
            //    {
            //        ((Button)frmControl).Text = objCCWeb.ReturnSingleValue("SELECT  Caption" + Session["Type"].ToString() + " FROM MTFormControlMaster WHERE FormID=116 AND ControlName='" + ((Button)frmControl).ID.Trim() + "' ");
            //    } 
            //    if (frmControl.GetType().FullName == "System.Web.UI.WebControls.RadioButton")
            //    {
            //        ((RadioButton)frmControl).Text = objCCWeb.ReturnSingleValue("SELECT  Caption" + Session["Type"].ToString() + " FROM MTFormControlMaster WHERE FormID=116 AND ControlName='" + ((RadioButton)frmControl).ID.Trim() + "' ");
            //    } 
            //}
            if (gvInstitute.Rows.Count > 0)
            {
                varData = objCCWeb.ReturnSingleValue("DECLARE @varSelected AS VARCHAR(2000); SET @varSelected=''; SELECT @varSelected=@varSelected+'^'+ Caption" + Session["Type"].ToString() + "  " +
                     " FROM MTFormControlMaster WHERE ControlName LIKE 'gvInstitute%'  AND FormID=116 ORDER BY PriorityNo  SELECT CASE WHEN LEN(@varSelected)>1  THEN SUBSTRING(@varSelected,1,LEN(@varSelected)) " +
                     " ELSE '0' END AS  GridDetails");
                string[] StrData = varData.ToString().Split('^');
                gvInstitute.HeaderRow.Cells[0].Text = StrData[1];
                gvInstitute.HeaderRow.Cells[2].Text = StrData[2];
                gvInstitute.HeaderRow.Cells[3].Text = StrData[3];
                gvInstitute.HeaderRow.Cells[4].Text = StrData[4];
                gvInstitute.HeaderRow.Cells[5].Text = StrData[5];
                gvInstitute.HeaderRow.Cells[6].Text = StrData[6];
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>" + strHideID + "alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        hidCache.Value = "";
        Response.Redirect("MainForm.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strResult="";
        int intSchoolID = 0;          
        string[] strArray = this.hidFlag.Value.Split('^');
        try
        {
            List<string> lstArray = new List<string>();
            byte[] fileData = null;
            byte[] imageData = null;
          
            long lnLength =0;

            fUploadEmblem.Attributes["filename"] = hdnSImagePath.Value;
            if (fUploadEmblem.PostedFile.FileName != "")
            {
                if (fUploadEmblem.HasFile)
                {
                    try
                    {
                        Stream myStream = fUploadEmblem.PostedFile.InputStream;
                        lnLength = myStream.Length;
                        fileData = new byte[(int)myStream.Length];
                        myStream.Read(fileData, 0, (int)lnLength);
                        myStream.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }         
            string strEmblemStatus;
            if (rbtnYes.Checked == true)
                strEmblemStatus = "Y";
            else
                strEmblemStatus = "N";
            //if (strArray[0] == "N" || strArray[0]=="E" && strArray[3].Trim().ToUpper() != txtAddress.Text.Trim().ToUpper())
            //{               
            //    if (objCCWeb.ReturnNumericValue("SELECT COUNT(SchoolID) FROM MTInstitutionMaster WHERE Address='" + txtAddress.Text.Trim().Replace("'", "''") + "'") > 0)
            //    {
            //        strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblAddress.Text);
            //        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>" + strHideID + "alert('" + strResult + "')</script>");
            //        //ClientScript.RegisterStartupScript(this.GetType(), "", "<script>" + strHideID + "alert('Address Already Exist')</script>");
            //        hidFlag.Value = "S";
            //        return;
            //    }
            //}
            if(strArray[0]=="E")
            {
                lstArray.Add("UPDATE MTInstitutionMaster SET SchoolName1=" + objCCWeb.fReplaceChar(txtInstitution1) + ",SchoolName2='" + txtInstitution2.Text.Trim().Replace("'", "''") + "',Address=" + objCCWeb.fReplaceChar(txtAddress) + ",ReportHeader=" + objCCWeb.fReplaceChar(txtReportHeader)+
                    ",City=" + objCCWeb.fReplaceChar(txtCity) + ",State=" + objCCWeb.fReplaceChar(txtState) + ",Pincode=" + objCCWeb.fReplaceChar(txtPincode) + ",Telephone=" + objCCWeb.fReplaceChar(txtTelephone) + "," +
                    "Fax=" + objCCWeb.fReplaceChar(txtFax) + ",Email=" + objCCWeb.fReplaceChar(txtEmail) + ",DirectorName=" + objCCWeb.fReplaceChar(txtDirector) + ",DirectorTelephone=" + objCCWeb.fReplaceChar(txtDirPhone) +
                    ",PrincipalName=" + objCCWeb.fReplaceChar(txtPrincipal) + ",PrincipalPhone=" + objCCWeb.fReplaceChar(txtPriPhone) + ",VicePrincipalName=" + objCCWeb.fReplaceChar(txtVicePrincipal) + "," +
                    "VicePrincipalPhone=" + objCCWeb.fReplaceChar(txtVicePriPhone) + ",AdministratorName=" + objCCWeb.fReplaceChar(txtAdministrator) + ",AdministratorPhone=" + objCCWeb.fReplaceChar(txtAdmPhone) + ",Affiliation=" + objCCWeb.fReplaceChar(txtAffiliation) +
                    ",Medium=" + objCCWeb.fReplaceChar(txtMedium) + ",Motto=" + objCCWeb.fReplaceChar(txtMotto) + ",EstablishedOn=" + objCCWeb.fReplaceChar(txtEstablishedOn) + ",EstablishmentCode=" + objCCWeb.fReplaceChar(txtEstablishmentCode) + "," +
                    "BankAccountNo=" + objCCWeb.fReplaceChar(txtBankACNo) + ",EmblemStatus='" + strEmblemStatus + "',UpdateUserID=" + Session["UID"].ToString() + ",UpdateDate=GETDATE(),PLPackDate=" + objCCWeb.ReturnDateorNull(txtPLPackDate.Text.Trim()) +  ",PLPackdateStaff="+ objCCWeb.ReturnDateorNull(txtPLPackDateStaff.Text.Trim()) + " WHERE SchoolID=" + strArray[1] + "");

                lstArray.Add("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuInstitutionMaster','School " + (txtInstitution1.Text.Trim().Replace("'", "''") != "" ? txtInstitution1.Text.Trim().Replace("'", "''") : txtInstitution2.Text.Trim().Replace("'", "''")) + " Information ,Is Modified')");

            }
            //else
            //{               
            //     intSchoolID = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(SchoolID),0)+1 FROM MtInstitutionMaster");

            //    lstArray.Add("INSERT INTO MTInstitutionMaster(SchoolID,SchoolName1,SchoolName2,Address,ReportHeader,City,State,Pincode,Telephone,Fax,Email,DirectorName,DirectorTelephone,PrincipalName,PrincipalPhone,VicePrincipalName,VicePrincipalPhone,AdministratorName,AdministratorPhone," +
            //    "Affiliation,Medium,Motto,EstablishedOn,EstablishmentCode,BankAccountNo,EmblemStatus,EntryUserID,EntryDate) SELECT ISNULL(MAX(SchoolID),0)+1, '" + txtInstitution1.Text.Trim().Replace("'", "''") + "','" + txtInstitution2.Text.Trim().Replace("'", "''") + "','" + txtAddress.Text.Trim().Replace("'", "''") + "','" + txtReportHeader.Text.Trim().Replace("'", "''") +
            //        "','" + txtCity.Text.Trim().Replace("'", "''") + "','" + txtState.Text.Trim().Replace("'", "''") + "','" + txtPincode.Text.Trim().Replace("'", "''") + "','" + txtTelephone.Text.Trim().Replace("'", "''") + "'," +
            //        "'" + txtFax.Text.Trim().Replace("'", "''") + "','" + txtEmail.Text.Trim().Replace("'", "''") + "','" + txtDirector.Text.Trim().Replace("'", "''") + "','" + txtDirPhone.Text.Trim().Replace("'", "''") +
            //        "','" + txtPrincipal.Text.Trim().Replace("'", "''") + "','" + txtPriPhone.Text.Trim().Replace("'", "''") + "','" + txtVicePrincipal.Text.Trim().Replace("'", "''") + "'," +
            //        "'" + txtVicePriPhone.Text.Trim().Replace("'", "''") + "','" + txtAdministrator.Text.Trim().Replace("'", "''") + "','" + txtAdmPhone.Text.Trim().Replace("'", "''") + "','" + txtAffiliation.Text.Trim().Replace("'", "''") +
            //        "','" + txtMedium.Text.Trim().Replace("'", "''") + "','" + txtMotto.Text.Trim().Replace("'", "''") + "','" + txtEstablishedOn.Text.Trim().Replace("'", "''") + "','" + txtEstablishmentCode.Text.Trim().Replace("'", "''") + "'," +
            //        "'" + txtBankACNo.Text.Trim().Replace("'", "''") + "','" + strEmblemStatus + "'," + Session["UID"].ToString() + ",GETDATE() FROM MtInstitutionMaster");                
            //}
            strResult = objCCWeb.ExecuteQueryList(lstArray);
            if (strArray[0] == "E")
            {
                intSchoolID = Convert.ToInt32(strArray[1]);
            }
            //else
            //{
            //    intSchoolID = intSchoolID;
            //}
            //if (hdnSImagePath.Value != "noimage" && hdnSImagePath.Value != "")
            //{
            //    try
            //    {
            //        if (File.Exists(Server.MapPath("InstitutionImages") + "/I" + intSchoolID + ".jpg") == true)
            //        {
            //            File.Delete(Server.MapPath("InstitutionImages") + "/I" + intSchoolID + ".jpg");
            //        }
            //        File.Copy(hdnSImagePath.Value, Server.MapPath("InstitutionImages") + "/I" + intSchoolID + ".jpg", true);
            //        File.Delete(hdnSImagePath.Value);
            //    }
            //    catch
            //    { }
            //    //}
            //}
            //else if (hdnSImagePath.Value == "noimage")
            //{
            //    if (File.Exists(Server.MapPath("InstitutionImages") + "/I" + intSchoolID + ".jpg") == true)
            //    {
            //        File.Delete(Server.MapPath("InstitutionImages") + "/I" + intSchoolID + ".jpg");
            //    }
            //}
            if (hidFlag.Value == "N^")
            {
                hidFlag.Value = "N^";
            }
            else
            {
                hidFlag.Value = "E^";
            }
            if (strResult == "")
            {
                if (lnLength > 0)
                {
                    //SqlConnection conSImage = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionString"));
                    SqlConnection conSImage = new SqlConnection(objCCWeb.ReturnConnectionString());
                    conSImage.Open();
                    SqlCommand cmdSImage = new SqlCommand("UPDATE MTInstitutionMaster SET Emblem=@img,EmblemLength=" + lnLength.ToString() + " where SchoolID=" + intSchoolID + "", conSImage);
                    cmdSImage.CommandType = CommandType.Text;
                    cmdSImage.Parameters.Add(new SqlParameter("@img", SqlDbType.Image));
                    cmdSImage.Parameters["@img"].Value = fileData;
                    cmdSImage.ExecuteNonQuery();
                    conSImage.Close();
                    conSImage.Dispose();
                }
                if (lnLength == 0)
                {
                    if (strArray[0] == "E")
                    {
                        SqlDataReader rdrImage = objCCWeb.BindReader("SELECT ISNULL(Emblem,'') AS Emblem,CAST(ISNULL(EmblemLength,0) AS INT) AS EmblemLength FROM MTInstitutionMaster WHERE SchoolID=" + intSchoolID + "");
                        if (rdrImage.Read())
                        {
                            int intLength = (int)rdrImage["EmblemLength"];
                            imageData = new byte[intLength];
                            imageData = (byte[])rdrImage["Emblem"];
                            if (intLength != 0)
                                lnLength = intLength;
                        }
                        rdrImage.Close();
                        rdrImage.Dispose();
                    }
                }
                if (strArray[0] == "N")
                {
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "1", "");
                }
                else
                {
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "2", "");
                }
                ClientScript.RegisterStartupScript(this.GetType(), "displayScriptMsg", "<script>" + strHideID + "alert('" + strResult + "')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayE", "<script language=javascript>" + strHideID + "alert('" + strResult + "')</script>");
            }
            if (fUploadEmblem.PostedFile.FileName == "")
            {
                fileData = imageData;
            }
            btnCancel_Click(sender, e);
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>" + strHideID + "alert('" + ex.Message + "')</script>");
        }
        BindDDL();
        btnCancel_Click(sender, e);        
    }
    protected void PGetOption()
    {
        SqlDataReader rdrOption = objCCWeb.BindReader("SELECT ISNULL(MAX(NewOption),'N'),ISNULL(MAX(EditOption),'N'),ISNULL(MAX(DeleteOption),'N') FROM MTUserLimitMaster " +
                " WHERE ModuleID=1 AND MenuName='mnuInstitutionMaster' AND UID=" + Session["UID"] + "");
        if (rdrOption.Read())
        {
            hidCache.Value = rdrOption.GetValue(0).ToString() + ";" + rdrOption.GetValue(1).ToString() + ";" + rdrOption.GetValue(2).ToString();
//            strNewOption = rdrOption.GetValue(0).ToString();
  //          strEditOption = rdrOption.GetValue(1).ToString();
    //        strDeleteOption = rdrOption.GetValue(2).ToString();
        }
        rdrOption.Close();
        rdrOption.Dispose();
    }
    protected void BindDDL()
    {
        gvInstitute.DataSource = objCCWeb.BindDataSet("EXEC spInstitutionMaster");
        gvInstitute.DataBind();
        if (gvInstitute.Rows.Count > 0)
        {
            gvInstitute.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            for (int intLoop = 0; intLoop < gvInstitute.Rows.Count; intLoop++)
            {
                gvInstitute.Rows[intLoop].Cells[0].HorizontalAlign = HorizontalAlign.Right;
            }
        }        
    }

    protected void gvInstitute_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
            e.Row.Attributes.Add("ondblclick", "javascript:return fGridClick(" + e.Row.RowIndex + ")");
        }
        if (e.Row.Cells.Count - 1 > 0)
        {
            //e.Row.BackColor = System.Drawing.Color.FromName("#ffc0cb");
            e.Row.Cells[1].Style.Add("display", "none");
            e.Row.Cells[3].Style.Add("display", "none");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {        
        this.hidFlag.Value = "";
        ImgEmblem.ImageUrl = "~/StudentPhoto/NoImage.JPG";
        string strClear;
        strClear = "pClearFields('frmMTInstitutionMaster');";
        //if (Session["Type"] == "1")
        //{
            if (gvInstitute.Rows.Count > 0)
            {
                for (int intLoop = 0; intLoop < gvInstitute.Rows.Count; intLoop++)
                {
                    gvInstitute.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                    gvInstitute.HeaderRow.Cells[0].Width = 40;
                    gvInstitute.Rows[intLoop].Cells[0].HorizontalAlign = HorizontalAlign.Right;
                    gvInstitute.Rows[intLoop].Cells[0].Width = 40;
                    gvInstitute.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.HeaderRow.Cells[2].Width = 150;
                    gvInstitute.Rows[intLoop].Cells[2].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.Rows[intLoop].Cells[2].Width = 150;
                    gvInstitute.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.HeaderRow.Cells[3].Width = 150;
                    gvInstitute.Rows[intLoop].Cells[3].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.Rows[intLoop].Cells[3].Width = 150;
                    gvInstitute.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.HeaderRow.Cells[4].Width = 150;
                    gvInstitute.Rows[intLoop].Cells[4].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.Rows[intLoop].Cells[4].Width = 150;
                    gvInstitute.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.HeaderRow.Cells[5].Width = 100;
                    gvInstitute.Rows[intLoop].Cells[5].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.Rows[intLoop].Cells[5].Width = 100;
                    gvInstitute.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.HeaderRow.Cells[6].Width = 100;
                    gvInstitute.Rows[intLoop].Cells[6].HorizontalAlign = HorizontalAlign.Left;
                    gvInstitute.Rows[intLoop].Cells[6].Width = 100;
                }
            }
        //}
        //else
        //{
        //    if (gvInstitute.Rows.Count > 0)
        //    {
        //        for (int intLoop = 0; intLoop < gvInstitute.Rows.Count; intLoop++)
        //        {
        //            gvInstitute.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        //            gvInstitute.HeaderRow.Cells[0].Width = 40;
        //            gvInstitute.Rows[intLoop].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        //            gvInstitute.Rows[intLoop].Cells[0].Width = 40;
        //            gvInstitute.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.HeaderRow.Cells[2].Width = 100;
        //            gvInstitute.Rows[intLoop].Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.Rows[intLoop].Cells[2].Width = 100;
        //            gvInstitute.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.HeaderRow.Cells[3].Width = 100;
        //            gvInstitute.Rows[intLoop].Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.Rows[intLoop].Cells[3].Width = 100;
        //            gvInstitute.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.HeaderRow.Cells[4].Width = 150;
        //            gvInstitute.Rows[intLoop].Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.Rows[intLoop].Cells[4].Width = 150;
        //            gvInstitute.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.HeaderRow.Cells[5].Width = 100;
        //            gvInstitute.Rows[intLoop].Cells[5].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.Rows[intLoop].Cells[5].Width =100;
        //            gvInstitute.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.HeaderRow.Cells[6].Width = 100;
        //            gvInstitute.Rows[intLoop].Cells[6].HorizontalAlign = HorizontalAlign.Right;
        //            gvInstitute.Rows[intLoop].Cells[6].Width = 100;
        //        }
        //    }
        //}
        if (gvInstitute.Rows.Count > 0)
        {
            varData = objCCWeb.ReturnSingleValue("DECLARE @varSelected AS VARCHAR(2000); SET @varSelected=''; SELECT @varSelected=@varSelected+'^'+ Caption" + Session["Type"].ToString() + "  " +
                 " FROM MTFormControlMaster WHERE ControlName LIKE 'gvInstitute%'  AND FormID=116 ORDER BY PriorityNo  SELECT CASE WHEN LEN(@varSelected)>1  THEN SUBSTRING(@varSelected,1,LEN(@varSelected)) " +
                 " ELSE '0' END AS  GridDetails");
            string[] StrData = varData.ToString().Split('^');
            gvInstitute.HeaderRow.Cells[0].Text = StrData[1];
            gvInstitute.HeaderRow.Cells[2].Text = StrData[2];
            gvInstitute.HeaderRow.Cells[3].Text = StrData[3];
            gvInstitute.HeaderRow.Cells[4].Text = StrData[4];
            gvInstitute.HeaderRow.Cells[5].Text = StrData[5];
            gvInstitute.HeaderRow.Cells[6].Text = StrData[6];
        }

        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>" + strHideID + strClear + "</script>");
       
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;            
            string[] strArray = hidFlag.Value.ToString().Split('^');
            if (objCCWeb.ReturnNumericValue("EXEC spGetPrimaryValueExists 'SchoolID','MTInstitutionMaster','" + Convert.ToInt32(gvInstitute.Rows[Convert.ToInt32(strArray[2])].Cells[1].Text) + "'") > 0)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "alert('School Is In Use')</script>");
                strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                ClientScript.RegisterStartupScript(this.GetType(), "dispScript", "<script language='javascript'>" + strHideID + "alert('" + strResult + "')</script>");
                return;
            }
            else
            {
                strResult = objCCWeb.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuInstitutionMaster','School " + (txtInstitution1.Text.Trim().Replace("'", "''") != "" ? txtInstitution1.Text.Trim().Replace("'", "''") : txtInstitution2.Text.Trim().Replace("'", "''")) + " Information ,Is Deleted')");

                strResult = objCCWeb.ExecuteQuery("DELETE FROM MTInstitutionMaster WHERE SchoolID=" + Convert.ToInt32(gvInstitute.Rows[Convert.ToInt32(strArray[2])].Cells[1].Text) + "");
                if (strResult == "")
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>" + strHideID + "alert('Deleted Successfully')</script>");
                    strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "3", "");
                    ClientScript.RegisterStartupScript(this.GetType(), "displayDelete", "<script language=javascript>" + strHideID + "alert('" + strResult + "')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>" + strHideID + "alert('" + strResult + "')</script>");
                }
            }
            BindDDL();
            btnCancel_Click(sender, e);            
        }
        catch (Exception exMyError)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "alert('" + exMyError.Message.Replace("'", "") + "')</script>");
        }

    }
    protected void btnClick_Click(object sender, EventArgs e)
    {
        string[] strArray = hidFlag.Value.ToString().Split('^');
        SqlDataReader rdrInstitution = objCCWeb.BindReader("SELECT SchoolName1 AS SchoolName1,SchoolName2 AS SchoolName2,Address AS Address,ReportHeader AS ReportHeader,City AS City,State AS State," +
                "Pincode AS Pincode,Telephone AS Telephone,Fax AS Fax,Email AS Email,DirectorName AS DirectorName,DirectorTelephone AS DirectorTelephone," +
                "PrincipalName AS PrincipalName,PrincipalPhone AS PrincipalPhone,vicePrincipalName AS VicePrincipalName,VicePrincipalPhone AS VicePrincipalPhone," +
                "AdministratorName AS AdministratorName,AdministratorPhone AS AdministratorPhone,Affiliation AS Affiliation,Medium AS Medium," +
                "Motto AS Motto,EstablishedOn AS EstablishedOn,EstablishmentCode AS EstablishmentCode,BankAccountNo AS BankAccountno,Emblem AS Emblem,ISNULL(EmblemLength,0) AS EmblemLength," +
                "EmblemStatus AS EmblemStatus,ISNULL(Convert(varchar,PLPackDate,103),''),ISNULL(Convert(varchar,PLPackdateStaff,103),'') FROM MTInstitutionMaster where SchoolID=" + strArray[1] + "");
        if (rdrInstitution.Read())
        {
            txtInstitution1.Text = rdrInstitution.GetValue(0).ToString();
            txtInstitution2.Text = rdrInstitution.GetValue(1).ToString();
            txtAddress.Text = rdrInstitution.GetValue(2).ToString();
            txtReportHeader.Text = rdrInstitution.GetValue(3).ToString();
            txtCity.Text = rdrInstitution.GetValue(4).ToString();
            txtState.Text = rdrInstitution.GetValue(5).ToString();
            txtPincode.Text = rdrInstitution.GetValue(6).ToString();
            txtTelephone.Text = rdrInstitution.GetValue(7).ToString();
            txtFax.Text = rdrInstitution.GetValue(8).ToString();
            txtEmail.Text = rdrInstitution.GetValue(9).ToString();
            txtDirector.Text = rdrInstitution.GetValue(10).ToString();
            txtDirPhone.Text = rdrInstitution.GetValue(11).ToString();
            txtPrincipal.Text = rdrInstitution.GetValue(12).ToString();
            txtPriPhone.Text = rdrInstitution.GetValue(13).ToString();
            txtVicePrincipal.Text = rdrInstitution.GetValue(14).ToString();
            txtVicePriPhone.Text = rdrInstitution.GetValue(15).ToString();
            txtAdministrator.Text = rdrInstitution.GetValue(16).ToString();
            txtAdmPhone.Text = rdrInstitution.GetValue(17).ToString();
            txtAffiliation.Text = rdrInstitution.GetValue(18).ToString();
            txtMedium.Text = rdrInstitution.GetValue(19).ToString();
            txtMotto.Text = rdrInstitution.GetValue(20).ToString();
            txtEstablishedOn.Text = rdrInstitution.GetValue(21).ToString();
            txtEstablishmentCode.Text = rdrInstitution.GetValue(22).ToString();
            txtBankACNo.Text = rdrInstitution.GetValue(23).ToString();
            txtPLPackDate.Text = rdrInstitution.GetValue(27).ToString();
            txtPLPackDateStaff.Text = rdrInstitution.GetValue(28).ToString();
            rbtnYes.Checked = false;
            rbtnNo.Checked = false;
            if (rdrInstitution.GetValue(26).ToString() == "Y")
            {
                rbtnYes.Checked = true;
            }
            else
            {
                rbtnNo.Checked = true;
            }

            //string imageName = Server.MapPath("InstitutionImages") + "\\I" + strArray[1] + ".jpg";
            //if (File.Exists(imageName) == true)
            //{
            //    ImgEmblem.ImageUrl = "InstitutionImages\\I" + strArray[1] + ".jpg";;
            //    //hdnSImagePath = imageName;
            //    //File.Delete(Server.MapPath("InstitutionImages") + "/I" + intSchoolID + ".jpg");
            //}
            //else
            //    ImgEmblem.ImageUrl = "InstitutionImages/NoImage.JPG";
            //    //ImgEmblem.ImageUrl = Server.MapPath("InstitutionImages/NoImage.JPG");

            if (Convert.ToInt32(rdrInstitution.GetValue(25)) > 0)
            {
                ImgEmblem.ImageUrl = "LoadImage.aspx?TypeName=InstitutionEmblem&SchoolID=" + strArray[1] + "";
            }
            else
            {
                ImgEmblem.ImageUrl = "~/StudentPhoto/NoImage.JPG";
            }
        }
        rdrInstitution.Close();
        rdrInstitution.Dispose();

        // FILL GENDER DETAILS OF INSTITUTE
        ////SqlDataReader rdrStudCount = objCCWeb.BindReader("SELECT COUNT(*) AS TOTAL, (Select count(*) from SIStudentMaster SM INNER JOIN sistudentyearwisedetails SYD ON SM.StudentId = SYD.StudentId " +
        ////            " where SM.SEX='M' AND SYD.StudentStatus='S' AND SM.SchoolID=" + strArray[1] + " AND SYD.ACASTART="+Session["AcaStart"].ToString()+") AS BOYS,  (Select count(*) from SIStudentMaster SM INNER JOIN sistudentyearwisedetails SYD ON SM.StudentId = SYD.StudentId " +
        ////            " where SM.SEX='F' AND SYD.StudentStatus='S' AND SM.SchoolID=" + strArray[1] + " AND SYD.ACASTART=" + Session["AcaStart"].ToString() + ") AS GIRLS from SIStudentMaster SM INNER JOIN sistudentyearwisedetails SYD ON SM.StudentId = SYD.StudentId where SYD.StudentStatus='S' AND SM.SchoolID=" + strArray[1] + " AND SYD.ACASTART="+Session["AcaStart"].ToString()+"");
        
        ////if (rdrStudCount.Read())
        ////{
        ////    txtStudCount.Text = rdrStudCount.GetValue(0).ToString();
        ////    txtBoys.Text = rdrStudCount.GetValue(1).ToString();
        ////    txtGirls.Text = rdrStudCount.GetValue(2).ToString();
        ////}
        ////rdrStudCount.Close();
        ////rdrStudCount.Dispose();
        // SET BACKCOLOR OF GRID ROW TO SELECTED AlternatingRowStyle CssClass="MyGridViewAlternate" 
        int intRow = Convert.ToInt32(strArray[2]);
        intRow += 1;
        //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>document.getElementById('gvInstitute').rows[" + intRow + "].style.cssText=\"color: green; font-weight: bold; cursor: pointer;  background: #ffc0cb;\"" + strHideID + "</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>document.getElementById('gvInstitute').rows[" + intRow + "].style.cssText='color: green; font-weight: bold; cursor: pointer;  background: #ffc0cb;';" + strHideID + "</script>");
        //gvInstitute.Rows[Convert.ToInt32(strArray[2])].BackColor = System.Drawing.Color.FromName("#ffc0cb");
        //gvInstitute.Rows[Convert.ToInt32(strArray[2])].BackColor = System.Drawing.Color.Red;
       
       
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (gvInstitute.Rows.Count > 0)
        {
            gvInstitute.HeaderRow.Cells[1].Visible = false;
            gvInstitute.HeaderRow.Cells[3].Visible = false;
            for (int intLoop = 0; intLoop < gvInstitute.Rows.Count; intLoop++)
            {
                gvInstitute.Rows[intLoop].Cells[1].Visible = false;
                gvInstitute.Rows[intLoop].Cells[3].Visible = false;
            }
            objCCWeb.ExportToExcel(gvInstitute, frmMTInstitutionMaster,lblSchoolInformation1.Text, "Excel");
            //gvInstitute.HeaderRow.Cells[1].Visible = true;
            //gvInstitute.HeaderRow.Cells[3].Visible = true;
            for (int intLoop = 0; intLoop < gvInstitute.Rows.Count; intLoop++)
            {
                gvInstitute.Rows[intLoop].Cells[1].Visible = true;
                gvInstitute.Rows[intLoop].Cells[3].Visible = true;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>" + strHideID + "</script>");

        }
    }

}
