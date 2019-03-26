/*
    Project Name            :   CampusCare
    Client                  :   
    Database                :   SQL Server 2000
    Front-End               :   ASP.NET With C#, Java Script, Ajax
    Reporting Tool          :   Crystal Report 11.0
    Team                    :   Sandhya,Tinu,Ushas,Jitender Kumar
    Tables                  :   MTSectionMaster
    Procedures              :   spBindGrid
    Page Created            :   Tinu  
    Codes                   :   Tinu
    Testing & Modification  :   Jitender Kumar
    Remarks                 :      
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class frmUserManagement : System.Web.UI.Page
{
    CCWeb objWeb = new CCWeb();
    protected static string NewOption, EditOption, DeleteOption;
    protected static string strType;
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
    protected static int intSetRollNumber;
    //protected static string strSQL = "";
    
    String varData;
    protected string strHideID = "";
//    protected string strHideID = "if (document.getElementById('trUser').style.display=='block')if (document.getElementById('gvUserDetails').rows.length>1) {for(var intForLoop=0;intForLoop<document.getElementById('gvUserDetails').rows.length;intForLoop++)" +
//" { document.getElementById('gvUserDetails').rows[intForLoop].cells[0].style.display='none'; }} ";

    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "DisplayScript", "<script language='javascript'>" + strHideID + " </script>");
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
        if ((objWeb.ReturnNumericValue("SELECT Count(*) FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuUserManagement'") == 0) || (objWeb.ReturnSingleValue("SELECT ISNULL(VisibleOption,'N') FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=1 AND MenuName='mnuUserManagement'") == "N"))
        {
            Session.Clear();
            Response.Redirect("Logon.aspx");
            return;
        }
        if (objWeb.pCheckText(frmMTUserManagement) == true)
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
            pnlchkBox.HorizontalAlign = HorizontalAlign.Right;
        } 
        if (!Page.IsPostBack)
        {
            hidCache.Value = "";
            if (Session["ConfirmPassword"] == null)
            {
                Response.Redirect("MTConfirmPassword.aspx?MenuName=MTUserManagement.aspx");
            }
            else
            {
                Session.Remove("ConfirmPassword");
            }
            BindGrid();
            
            objWeb.FillCheckedBoxList(chkSchool, "SELECT SchoolID,SchoolName"+Session["Type"]+" FROM MTClientCompany WHERE SchoolID<>0 ORDER BY SchoolName"+Session["Type"]+"", "SchoolID", "SchoolName"+Session["Type"]+"", "");
            if (objWeb.ReturnNumericValue("select * from MTUserModuleMaster where ModuleID=12") == 0)
            {
                pnlLIB.Visible = false;
            }
            else
            {
                objWeb.FillCheckedBoxList(chkLibrary, "SELECT LIBLibraryID,LibraryName" + Session["Type"] + " FROM LIBLibraryMaster Where LIBLibraryID<>0 ORDER BY LibraryName" + Session["Type"] + "", "LIBLibraryID", "LibraryName" + Session["Type"] + "", "");
            }

            // txtUserId.Attributes.Add("onkeypress", "javascript:return RestrictEntry(event)");
           // ddlUserType.Attributes.Add("onchange", "javascript:return fUIDChange()");
           ddlUserType.Attributes.Add("onchange", "if (document.getElementById('btnSave').disabled==true) return false;");            
            btnSave.Attributes.Add("onclick", "javascript:return checkEmpty()");
            btnEdit.Attributes.Add("onclick", "javascript:return UserE_Control()");
            btnDelete.Attributes.Add("onclick", "javascript:return UserD_Control()");
            btnNew.Attributes.Add("onclick", "javascript:return User_Control()");
            txtUserId.Attributes.Add("AutoComplete", "off");
            if (Session["Type"] == "1")
            {
               // txtUserName.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event)");
                txtPassword.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event)");
                txtConfirmPassword.Attributes.Add("onkeypress", "javascript:return Restrict_Address(event)");
            }
            else
            {
                //txtUserName.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event)");
                txtPassword.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event)");
                txtConfirmPassword.Attributes.Add("onkeypress", "javascript:return Restrict_NameArabic(event)");
            }
            chkSchool.Attributes.Add("onclick", "if (document.getElementById('btnSave').disabled==true) return false;");
            chkLibrary.Attributes.Add("onclick", "if (document.getElementById('btnSave').disabled==true) return false;");            

            PGetOption();
            if (Request.QueryString["ManageUserID"] != null && Request.QueryString["ManageUserID"] != "")
            {
                txtUserId.Text = Request.QueryString["ManageUserID"];
                btnSearch_Click(sender, e);
            }

            if (Convert.ToInt32(ddlUserType.SelectedValue) == 0 || Convert.ToInt32(ddlUserType.SelectedValue) == 6)
            {

                objWeb.FillDDLs(ddlUserGroup, "SELECT 0 AS UserGroupID,'' AS UserGroupName UNION SELECT UserGroupID,UserGroupName AS UserGroupName FROM MTUserGroupMaster " +
                  " WHERE  UserGroupID>0 ORDER BY UserGroupName", "UserGroupID", "UserGroupName", "");

                ddlEmployee.Items.Clear();
                gvMenuMaster.Visible = true;
                Panel2.Visible = true;
                ddlEmployee.Enabled = false;
            }
            
          
            gvMenuMaster.Attributes.Add("bordercolor", "#8CDAFF");
            ClientScript.RegisterStartupScript(this.GetType(), "Enablea", "<script>pEnableDisable('LOAD');</script>");
            intSetRollNumber = objWeb.ReturnNumericValue("Select RollNumber From MTUserMenuMaster Where ModuleID=1 AND MenuName='mnuSet'");
        }

    }
   
    protected void BindGrid()
    {
        Panel2.Visible = false;
        btnSave.Enabled = false;
        btnDelete.Enabled = false;
        btnEdit.Enabled = false;
        btnNew.Enabled = true;
        btnSearch.Enabled = true;
        txtPassword.ReadOnly = true;
        txtUserName.ReadOnly = true;
        txtConfirmPassword.ReadOnly = true;
        txtUserId.Text = "";
        txtPassword.Text = "";
        txtUserName.Text = "";
        txtConfirmPassword.Text = "";
        hidFlag.Value = "^";
        ddlUserType.SelectedIndex = -1;
        ddlUserGroup.SelectedIndex = -1;
        ddlEmployee.SelectedIndex = -1;
        ddlUserType.Items.FindByValue("0").Selected = true;
        txtUserId.Focus();
        ddlEmployee.Enabled = false;
        ddlUserType.Enabled = false;
        txtPassword.BackColor = System.Drawing.Color.White;
        txtConfirmPassword.BackColor = System.Drawing.Color.White;
    }

    protected void PGetOption()
    {
        SqlDataReader rdroption = objWeb.BindReader("SELECT NewOption,EditOption,DeleteOption FROM MTUserLimitMaster ULM INNER JOIN MTUserModuleMaster UMM ON ULM.ModuleID=UMM.ModuleID " +
                " WHERE UMM.ModuleID=1 AND MenuName='mnuUserManagement' AND UID=" + Session["UID"] + "");
        if (rdroption.Read())
        {
            hidCache.Value = rdroption.GetValue(0).ToString() + ";" + rdroption.GetValue(1).ToString() + ";" + rdroption.GetValue(2).ToString(); 
            //NewOption = rdroption.GetValue(0).ToString();
            //EditOption = rdroption.GetValue(1).ToString();
            //DeleteOption = rdroption.GetValue(2).ToString();
        }
        rdroption.Close();
        rdroption.Dispose();
    }    

    protected void btnEdit_Click(object sender, EventArgs e)
    {
       

    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        BindGrid();
        objWeb.FillCheckedBoxList(chkSchool, "SELECT SchoolID,SchoolName"+Session["Type"]+" FROM MTClientCompany WHERE schoolID<>0 ORDER BY SchoolName"+Session["Type"]+"", "SchoolID", "SchoolName"+Session["Type"]+"", "");
        objWeb.FillCheckedBoxList(chkLibrary, "SELECT LIBLibraryID,LibraryName" + Session["Type"] + " FROM LIBLibraryMaster Where LIBLibraryID<>0 ORDER BY LibraryName" + Session["Type"] + "", "LIBLibraryID", "LibraryName" + Session["Type"] + "", "");

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult = "";
            string[] strArray = hidFlag.Value.Split('^');
            List<string> lstArray = new List<string>();
            int intUID = 0;
            strCon1 = "";
            strCon2 = "";
            strCon3 = "";
            strCon4 = "";
            strCon5 = "";
            strCon6 = "";
            strCon7 = "";
            strCon8 = "";
            strCon9 = "";
            strCon10 = "";
            strCon11 = "";
            strCon12 = "";
            strCon13 = "";
            strCon14 = "";

            if (strArray[0] == "N")
            {
                if (ddlUserType.SelectedValue == "1")
                {
                    if (objWeb.ReturnNumericValue("SELECT COUNT(*) FROM MtuserMaster WHERE  UserStatus='Y' AND UserTypeID="+ ddlUserType.SelectedValue+"  AND   EmployeeIDStudentID="+ ddlEmployee.SelectedValue +"") > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Duplicate", "<script>pEnableDisable('NEW'); alert('Member Already Exists');</script>");
                        return;
                    }
                }
                else if (ddlUserType.SelectedValue == "0")
                {
                    if (objWeb.ReturnNumericValue("SELECT Count(*) FROM MTUserMaster WHERE UserID=" + objWeb.fReplaceChar(txtUserId) + " AND  UserStatus='Y'") > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Duplicate", "<script>pEnableDisable('NEW'); alert('UserID Already Exists');</script>");
                        return;
                    }
                    if (objWeb.ReturnNumericValue("SELECT Count(*) FROM MTUserMaster WHERE UserName=" + objWeb.fReplaceChar(txtUserName) + " AND  UserStatus='Y' ") > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Duplicate", "<script>pEnableDisable('NEW'); alert('Username Already Exists');</script>");
                        return;
                    }
                }
                if (objWeb.ReturnNumericValue("SELECT Count(UserID) FROM MTUserMaster WHERE (UserID=" + objWeb.fReplaceChar(txtUserId) + " OR UserName=" + objWeb.fReplaceChar(txtUserName) + ")  AND UserTypeID IN (0,1) AND  UserStatus='Y' ") > 0)
                {
                    strResult = objWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblUserName.Text);
                    ClientScript.RegisterStartupScript(this.GetType(), "Duplicate", "<script>pEnableDisable('NEW'); alert('"+strResult+"');</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "Duplicate", "<script>pEnableDisable('NEW'); alert('User Name Already Exist');</script>");
                    return;
                }
                intUID = objWeb.ReturnNumericValue("SELECT ISNULL(MAX(UID),0)+1 FROM MTUserMaster");
                //lstArray.Add("INSERT INTO MTUserMaster (UID,UserID,UserName,UserPassword,UserTypeID,UserStatus,UserLoged,EmployeeIDStudentID,EntryUserID,EntryDate) VALUES " +
                //    "(" + intUID + ",'" + txtUserId.Text.Trim().Replace("'", "''") + "','" + txtUserName.Text.Trim().Replace("'", "''") + "','" + FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "SHA1") + "'," +
                //    "" + ddlUserType.SelectedValue + ",'Y',Null," + (Convert.ToInt32(ddlUserType.SelectedValue) > 0 ? Convert.ToInt32(ddlEmployee.SelectedValue) : 0) + "," + Convert.ToInt32(Session["UID"]) + ",'" + DateTime.Now.ToString("yyyy/MM/dd") + "')");
                strCon1 = "INSERT INTO MTUserMaster (UID,UserID,UserName,UserPassword,UserTypeID,UserStatus,UserLoged,EmployeeIDStudentID,EntryUserID,EntryDate,UserGroupID) VALUES " +
                   "(" + intUID + "," + objWeb.fReplaceChar(txtUserId) + "," + objWeb.fReplaceChar(txtUserName) + ",'" + FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "SHA1") + "'," +
                   "" + ddlUserType.SelectedValue + ",'Y',Null," + (Convert.ToInt32(ddlUserType.SelectedValue) > 0 ? Convert.ToInt32(ddlEmployee.SelectedValue) : 0) + "," + Convert.ToInt32(Session["UID"]) + ","+
                   " '" + DateTime.Now.ToString("yyyy/MM/dd") + "'," + ddlUserGroup.SelectedValue  + ")";

                strCon1 = strCon1 + "~INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuUserManagement', " +
                             " 'User : " + txtUserName.Text.Trim().Replace("'", "''") + ", User Type " + ddlUserType.SelectedItem + " , Is Added')";

            }
            else
            {
              
                intUID = Convert.ToInt32(strArray[1]);

                TextBox TXTUserName = new TextBox();
                TXTUserName.MaxLength = 100;
                TXTUserName.Text = Request.Form["txtUserName"].Trim().Replace("'", "''");


                if (ddlUserType.SelectedValue == "1")
                {
                    if (objWeb.ReturnNumericValue("SELECT COUNT(*) FROM MtuserMaster WHERE  UserStatus='Y'  ANd UID="+ intUID +" AND    " +
                      " UserTypeID="+ ddlUserType.SelectedValue +"  AND   EmployeeIDStudentID="+ ddlEmployee.SelectedValue +" ") < 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Duplicate", "<script>pEnableDisable('EDIT'); alert('You Cannot Modify Member');</script>");
                        return;
                    }
                }


                if (objWeb.ReturnNumericValue("SELECT Count(UserID) FROM MTUserMaster WHERE (UserID=" + objWeb.fReplaceChar(txtUserId) + " OR UserName=" + objWeb.fReplaceChar(TXTUserName) + ") AND UID<>" + intUID + " AND UserTypeID IN (0,1) AND  UserStatus='Y'") > 0)
                {
                    strResult = objWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblUserName.Text);
                    ClientScript.RegisterStartupScript(this.GetType(), "Duplicate", "<script>pEnableDisable('EDIT'); alert('"+strResult+"');</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "Duplicate", "<script>pEnableDisable('EDIT'); alert('User Name Already Exist');</script>");
                    return;
                }

                if (Request.Form["txtPassword"].Trim() != "")
                {


                    strCon1 = strCon1 + "~UPDATE MTUserMaster SET UserID=" + objWeb.fReplaceChar(txtUserId) + ",UserName=" + objWeb.fReplaceChar(TXTUserName) + ", " +
                       "UserTypeID=" + ddlUserType.SelectedValue + ",UserStatus='Y',EmployeeIDStudentID=" + (Convert.ToInt32(ddlUserType.SelectedValue) > 0 ? Convert.ToInt32(ddlEmployee.SelectedValue) : 0) + ",UserPassword='" + FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["txtPassword"].Trim(), "SHA1") + "',  " +
                       " EntryUserID=" + Convert.ToInt32(Session["UID"]) + ",EntryDate='" + DateTime.Now.ToString("yyyy/MM/dd") + "',UserGroupID="+ ddlUserGroup.SelectedValue +" " +
                       "WHERE UID=" + intUID + "";
                    strCon1 = strCon1 + "~INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuUserManagement', " +
                           " 'User : " + txtUserName.Text.Trim().Replace("'", "''") + ", User Type " + ddlUserType.SelectedItem + " ,Password Is Modified To " + FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["txtPassword"].Trim(), "SHA1") + "')";

                }
                else
                {

                    strCon1 = strCon1 + "~UPDATE MTUserMaster SET UserID=" + objWeb.fReplaceChar(txtUserId) + ",UserName=" + objWeb.fReplaceChar(TXTUserName) + ", " +
                            "UserTypeID=" + ddlUserType.SelectedValue + ",UserStatus='Y',EmployeeIDStudentID=" + (Convert.ToInt32(ddlUserType.SelectedValue) > 0 ? Convert.ToInt32(ddlEmployee.SelectedValue) : 0) + ", " +
                            " EntryUserID=" + Convert.ToInt32(Session["UID"]) + ",EntryDate='" + DateTime.Now.ToString("yyyy/MM/dd") + "',UserGroupID=" + ddlUserGroup.SelectedValue + "  " +
                            "WHERE UID=" + intUID + "";
                    
                    strCon1 = strCon1 + "~INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuUserManagement', " +
                         " 'User : " + txtUserName.Text.Trim().Replace("'", "''") + ", User Type " + ddlUserType.SelectedItem + " , Is Modified')";

                    //objWeb.ExecuteQuery("INSERT INTO JKtemp VALUES ('Second Updation II MTuserMaster')");
                    ////****///
                }
                //lstArray.Add("UPDATE MTUserMaster SET UserID='" + txtUserId.Text.Trim().Replace("'", "''") + "',UserName='" + txtUserName.Text.Trim().Replace("'", "''") + "', " +
                //    "UserTypeID=" + ddlUserType.SelectedValue + ",UserStatus='Y',EmployeeIDStudentID=" + (Convert.ToInt32(ddlUserType.SelectedValue) > 0 ? Convert.ToInt32(ddlEmployee.SelectedValue) : 0) + ",EntryUserID=" + Convert.ToInt32(Session["UID"]) + ",EntryDate='" + DateTime.Now.ToString("yyyy/MM/dd") + "' " +
                //    "WHERE UID=" + intUID + "");
                ///**** modified by Sandhya on 25.01.2012//////
                //lstArray.Add("DELETE FROM MTUserLimitMaster WHERE UID=" + intUID + "");
                //lstArray.Add("DELETE FROM MTUserInstitutionMaster WHERE UID=" + intUID + "");
                strCon1 = strCon1 + "~DELETE FROM MTUserLimitMaster WHERE UID=" + intUID + "";
                strCon1 = strCon1 + "~DELETE FROM MTUserInstitutionMaster WHERE UID=" + intUID + "";
                strCon1 = strCon1 + "~DELETE FROM MTUserLibraryMaster where UID=" + intUID + "";
                /////*****/////
            }
            string strQry = "";
            if (Convert.ToInt32(ddlUserType.SelectedValue) <= 1)
            {
                gvMenuMaster.Columns[0].Visible = true;
                gvMenuMaster.Columns[1].Visible = true;
                gvMenuMaster.Columns[2].Visible = true;
                for (int intForLoop = 0; intForLoop < gvMenuMaster.Rows.Count; intForLoop++)
                {
                    //lstArray.Add("INSERT INTO MTUserLimitMaster (UserLimitID,UID,ModuleID,MenuName,VisibleOption,NewOption,EditOption,DeleteOption) " +
                    //    " SELECT ISNULL(MAX(UserLimitID),0)+1," + intUID + "," + Convert.ToInt32((gvMenuMaster.Rows[intForLoop].Cells[0].Text.Trim() == "" ? "0" : gvMenuMaster.Rows[intForLoop].Cells[0].Text)) + ",'" + gvMenuMaster.Rows[intForLoop].Cells[2].Text + "', " +
                    //    " '" + (((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkVisible"))).Checked == true ? "Y" : "N") + "','" + (((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkNew"))).Checked == true ? "Y" : "N") + "', " +
                    //    " '" + (((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkEdit"))).Checked == true ? "Y" : "N") + "','" + (((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkDelete"))).Checked == true ? "Y" : "N") + "' FROM MTUserLimitMaster");
                    strQry = "~INSERT INTO MTUserLimitMaster (UserLimitID,UID,ModuleID,MenuName,VisibleOption,NewOption,EditOption,DeleteOption) " +
                       " SELECT ISNULL(MAX(UserLimitID),0)+1," + intUID + "," + Convert.ToInt32((gvMenuMaster.Rows[intForLoop].Cells[0].Text.Trim() == "" ? "0" : gvMenuMaster.Rows[intForLoop].Cells[0].Text)) + ",'" + gvMenuMaster.Rows[intForLoop].Cells[2].Text + "', " +
                       " '" + (((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkVisible"))).Checked == true && ((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkVisible"))).Enabled == true ? "Y" : "N") + "','" + (((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkNew"))).Checked == true  && ((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkNew"))).Enabled == true ? "Y" : "N") + "', " +
                       " '" + (((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkEdit"))).Checked == true && ((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkEdit"))).Enabled == true ? "Y" : "N") + "','" + (((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkDelete"))).Checked == true && ((CheckBox)(gvMenuMaster.Rows[intForLoop].FindControl("chkDelete"))).Enabled == true ? "Y" : "N") + "' FROM MTUserLimitMaster";


                    if ((strCon2.Length + strQry.Length) <= 8000)
                    {
                        strCon2 += strQry;
                    }
                    else if ((strCon3.Length + strQry.Length) <= 8000)
                    {
                        strCon3 += strQry;
                    }
                    else if ((strCon4.Length + strQry.Length) <= 8000)
                    {
                        strCon4 += strQry;
                    }
                    else if ((strCon5.Length + strQry.Length) <= 8000)
                    {
                        strCon5 += strQry;
                    }
                    else if ((strCon6.Length + strQry.Length) <= 8000)
                    {
                        strCon6 += strQry;
                    }
                    else if ((strCon7.Length + strQry.Length) <= 8000)
                    {
                        strCon7 += strQry;
                    }
                    else if ((strCon8.Length + strQry.Length) <= 8000)
                    {
                        strCon8 += strQry;
                    }
                    else if ((strCon9.Length + strQry.Length) <= 8000)
                    {
                        strCon9+= strQry;
                    }
                    else if ((strCon10.Length + strQry.Length) <= 8000)
                    {
                        strCon10 += strQry;
                    }
                    else if ((strCon11.Length + strQry.Length) <= 8000)
                    {
                        strCon11 += strQry;
                    }
                    else if ((strCon12.Length + strQry.Length) <= 8000)
                    {
                        strCon12 += strQry;
                    }
                    else if ((strCon13.Length + strQry.Length) <= 8000)
                    {
                        strCon13 += strQry;
                    }
                    else if ((strCon14.Length + strQry.Length) <= 8000)
                    {
                        strCon14 += strQry;
                    }

                    //if (strCon2.Length > 8000 && strCon3.Length < 1)
                    //{
                    //    strCon3 = strCon2;
                    //    strCon2 = "";
                    //    if (strCon3.Length > 7929 && strCon4.Length < 1)
                    //    {
                    //        strCon4 = strCon3;
                    //        strCon3 = "";
                    //    }
                    //    if (strCon4.Length > 7929 && strCon5.Length < 1)
                    //    {
                    //        strCon5 = strCon4;
                    //        strCon4 = "";
                    //    }
                    //    if (strCon5.Length > 7929 && strCon6.Length < 1)
                    //    {
                    //        strCon6 = strCon5;
                    //        strCon5 = "";
                    //    }
                    //}   
                }
                gvMenuMaster.Columns[0].Visible = false;
                gvMenuMaster.Columns[1].Visible = false;
                gvMenuMaster.Columns[2].Visible = false;
            }
            for (int intForLoop = 0; intForLoop < chkSchool.Items.Count; intForLoop++)
            {
                if (chkSchool.Items[intForLoop].Selected == true)
                {
                    //lstArray.Add("INSERT INTO MTUserInstitutionMaster (UserInstitutionID,UID,SchoolID) SELECT ISNULL(MAX(UserInstitutionID),0)+1," + intUID + "," + chkSchool.Items[intForLoop].Value + " FROM MTUserInstitutionMaster");
                    strCon14 = strCon14 + "~INSERT INTO MTUserInstitutionMaster (UserInstitutionID,UID,SchoolID) SELECT ISNULL(MAX(UserInstitutionID),0)+1," + intUID + "," + chkSchool.Items[intForLoop].Value + " FROM MTUserInstitutionMaster";
                }
            }
            //************************************ Added by Sneha on 02-03-2012 *****************************//

            for (int intForLoop = 0; intForLoop < chkLibrary.Items.Count; intForLoop++)
            {
                if (chkLibrary.Items[intForLoop].Selected == true)
                    strCon14= strCon14 + "~INSERT INTO MTUserLibraryMaster (LIBUID,UID,LIBLibraryID) SELECT ISNULL(MAX(LIBUID),0)+1," + intUID + "," + chkLibrary.Items[intForLoop].Value + " FROM MTUserLibraryMaster";
            } 
            //*******************************************************************//

           // strResult = objWeb.ExecuteQueryList(lstArray);
            strResult = objWeb.ExecuteQuery("EXEC spInsertUpdateQuery '" + strCon1.Replace("'", "''") + "','" + strCon2.Replace("'", "''") + "','" + strCon3.Replace("'", "''") +
                              "','" + strCon4.Replace("'", "''") + "','" + strCon5.Replace("'", "''") + "','" + strCon6.Replace("'", "''") + "','" + strCon7.Replace("'", "''") + "','" + strCon8.Replace("'", "''") + "','" + strCon9.Replace("'", "''") + "','" + strCon10.Replace("'", "''") + "','" + strCon11.Replace("'", "''") + "'"+
                              " ,'" + strCon12.Replace("'", "''") + "','" + strCon13.Replace("'", "''") + "','" + strCon14.Replace("'", "''") + "'");
            if (strResult != "")
            { ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script>alert(" + strResult.Replace("'", "''") + ");</script>");
                btnSearch_Click(sender, e);
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script>pEnableDisable('SAVE'); alert('Saved Successfully');</script>");
                strResult = objWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "1", "");
                ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script>pEnableDisable('SAVE'); alert('"+strResult+"');</script>");
                BindGrid();
                objWeb.FillCheckedBoxList(chkSchool, "SELECT SchoolID,SchoolName"+Session["Type"]+" FROM MTClientCompany WHERE SchoolID<>0 ORDER BY SchoolName"+Session["Type"]+"", "SchoolID", "SchoolName"+Session["Type"]+"", "");
                objWeb.FillCheckedBoxList(chkLibrary, "SELECT LIBLibraryID,LibraryName" + Session["Type"] + " FROM LIBLibraryMaster Where LIBLibraryID<>0 ORDER BY LibraryName" + Session["Type"] + "", "LIBLibraryID", "LibraryName" + Session["Type"] + "", "");

            }

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script>alert(" + ex.Message.Replace("'","''") + ");</script>");
            btnSearch_Click(sender, e);
        }
        
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        objWeb.FillCheckedBoxList(chkSchool, "SELECT SchoolID,SchoolName"+Session["Type"]+" FROM MTClientCompany WHERE SchoolID<>0 ORDER BY SchoolName"+Session["Type"]+"", "SchoolID", "SchoolName"+Session["Type"]+"", "");
        objWeb.FillCheckedBoxList(chkLibrary, "SELECT LIBLibraryID,LibraryName" + Session["Type"] + " FROM LIBLibraryMaster Where LIBLibraryID<>0 ORDER BY LibraryName" + Session["Type"] + "", "LIBLibraryID", "LibraryName" + Session["Type"] + "", "");

        txtUserId.Text = "";
        txtPassword.Text = "";
        txtUserName.Text = "";
        txtConfirmPassword.Text = "";
        txtUserName.ReadOnly = false;
        txtUserId.ReadOnly = false;
        txtPassword.ReadOnly = false;
        txtConfirmPassword.ReadOnly = false;
        txtPassword.BackColor = System.Drawing.Color.White;
        txtConfirmPassword.BackColor = System.Drawing.Color.White;
        ddlEmployee.SelectedIndex = -1;
        ddlUserType.SelectedIndex = -1;
        ddlUserType.Items.FindByValue("0").Selected = true;
        ddlEmployee.Items.Clear();
        txtUserId.Focus();
        Panel2.Visible = true;
        gvMenuMaster.Visible = true;
        gvMenuMaster.Columns[0].Visible = true;
        gvMenuMaster.Columns[1].Visible = true;
        gvMenuMaster.Columns[2].Visible = true;
        SqlDataReader rdr2 = objWeb.BindReader("EXEC spUserBindUserManagement 0,'" + Session["Type"] + "'," + ddlUserGroup.SelectedValue + "");
        gvMenuMaster.DataSource = rdr2;
        gvMenuMaster.DataBind();
        rdr2.Close();
        rdr2.Dispose();
        gvMenuMaster.Columns[0].Visible = false;
        gvMenuMaster.Columns[1].Visible = false;
        gvMenuMaster.Columns[2].Visible = false;
        gvMenuMaster.Columns[3].ItemStyle.Font.Bold = true;
        txtPassword.BackColor = System.Drawing.Color.Red;
        txtConfirmPassword.BackColor = System.Drawing.Color.Red;
        ClientScript.RegisterStartupScript(this.GetType(), "EnableR", "<script> pEnableDisable('NEW'); </script>");
        hidFlag.Value = "N^";
        if (gvMenuMaster.Rows.Count > 0)
        {
            varData = objWeb.ReturnSingleValue("DECLARE @varSelected AS VARCHAR(2000); SET @varSelected=''; SELECT @varSelected=@varSelected+'^'+ Caption" + Session["Type"].ToString() + "  " +
                 " FROM MTFormControlMaster WHERE ControlName LIKE 'gvMenuMaster%'  AND FormID=129 ORDER BY PriorityNo  SELECT CASE WHEN LEN(@varSelected)>1  THEN SUBSTRING(@varSelected,1,LEN(@varSelected)) " +
                 " ELSE '0' END AS  GridDetails");
            string[] StrData = varData.ToString().Split('^');
            gvMenuMaster.HeaderRow.Cells[3].Text = StrData[1];
            gvMenuMaster.HeaderRow.Cells[4].Text = StrData[2];
            gvMenuMaster.HeaderRow.Cells[6].Text = StrData[3];
            gvMenuMaster.HeaderRow.Cells[7].Text = StrData[4];
            gvMenuMaster.HeaderRow.Cells[8].Text = StrData[5];
            gvMenuMaster.HeaderRow.Cells[9].Text = StrData[6];
        }
        if (Session["Type"].ToString () == "2")
        {
            if (gvMenuMaster.Rows.Count > 0)
            {
                for (int intLoop = 0; intLoop < gvMenuMaster.Rows.Count; intLoop++)
                {
                    gvMenuMaster.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.Rows[intLoop].Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.Rows[intLoop].Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.Rows[intLoop].Cells[5].HorizontalAlign = HorizontalAlign.Right;
                }
            }
        } 
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    
    {

        objWeb.FillCheckedBoxList(chkSchool, "SELECT SchoolID,SchoolName" + Session["Type"] + " FROM MTClientCompany WHERE SchoolID<>0 ORDER BY SchoolName" + Session["Type"] + "", "SchoolID", "SchoolName" + Session["Type"] + "", "");
        objWeb.FillCheckedBoxList(chkLibrary, "SELECT LIBLibraryID,LibraryName" + Session["Type"] + " FROM LIBLibraryMaster Where LIBLibraryID<>0 ORDER BY LibraryName" + Session["Type"] + "", "LIBLibraryID", "LibraryName" + Session["Type"] + "", "");

        if (txtUserId.Text != "")
        {
            SqlDataReader rdr = objWeb.BindReader("SELECT UID AS UID,UserID AS UserID,UserName AS UserName,ISNULL(UserTypeID,0) AS UserTypeID,'' AS AcessType,ISNULL(EmployeeIDStudentID,0) AS EmployeeIDStudentID,UserPassword AS UserPassword," +
                                " ISNULL(UserGroupID,0) FROM MTUserMaster WHERE UserStatus='Y' AND UserID='" + txtUserId.Text.Trim().Replace("'", "''") + "' AND UserTypeID IN (0,1)");

            if (rdr.Read())
            {
                txtUserId.Text = rdr.GetValue(1).ToString();
                btnSearch.Enabled = true;
                txtUserName.Text = rdr.GetValue(2).ToString();
                txtUserName.ReadOnly = true;
              
                txtPassword.Text = rdr.GetValue(6).ToString();
                txtPassword.ReadOnly = true;
                txtConfirmPassword.Text = rdr.GetValue(6).ToString();
                txtConfirmPassword.ReadOnly = true;
                
                

                if (rdr.GetValue(7).ToString() != "" && rdr.GetValue(7).ToString() != null)
                {
                    ddlUserGroup.SelectedValue = rdr.GetValue(7).ToString();
                }

                hidFlag.Value = "E^" + rdr.GetValue(0).ToString();
                ddlUserType.SelectedIndex = -1;
                ddlEmployee.SelectedIndex = -1;
                if (ddlUserType.Items.Contains(ddlUserType.Items.FindByValue(rdr.GetValue(3).ToString()))) ddlUserType.Items.FindByValue(rdr.GetValue(3).ToString()).Selected = true;

                if (Convert.ToInt32(ddlUserType.SelectedValue) == 0)
                {

                    objWeb.FillDDLs(ddlUserGroup, "SELECT 0 AS UserGroupID,'' AS UserGroupName UNION SELECT UserGroupID,UserGroupName AS UserGroupName FROM MTUserGroupMaster " +
                      " WHERE  UserGroupID>0 ORDER BY UserGroupName", "UserGroupID", "UserGroupName", "");

                    ddlEmployee.Items.Clear();
                    gvMenuMaster.Visible = true;
                    Panel2.Visible = true;
                    ddlEmployee.Enabled = false;
                }
                
                if (Convert.ToInt32(ddlUserType.SelectedValue) == 1)
                {
                    objWeb.FillDDLs(ddlEmployee, "SELECT PRLEmployeeID,FirstName+' '+MiddleName+' '+LastName+' # '+EmployeeCode AS StaffName FROM PRLEmployeeMaster " +
                     " WHERE SchoolID=" + Convert.ToInt32(Session["SchoolID"]) + " AND PRLEmployeeID>0 ORDER BY FirstName+' '+MiddleName+' '+LastName+' # '+EmployeeCode", "PRLEmployeeID", "StaffName", "");

                }
                else if (Convert.ToInt32(ddlUserType.SelectedValue) > 1)
                {
                    //objWeb.FillDDLs(ddlEmployee, "SELECT StudentID,FirstName+' '+MiddleName+' '+LastName+' # '+CASE WHEN RTRIM(ISNULL(AdmissionNo,''))='' THEN RollNumber ELSE AdmissionNo END AS StudentName FROM SIStudentMaster " +
                    //    " WHERE CollegeCourseID IN (SELECT CollegeCourseID FROM MTCollegeWiseCourseMaster WHERE CollegeID=" + Convert.ToInt32(Session["CollegeID"]) + ") ORDER BY FirstName", "StudentID", "StudentName", "");

                    objWeb.FillDDLs(ddlEmployee, "SELECT SM.StudentID,SM.FirstName+' '+SM.MiddleName+' '+SM.LastName+' # '+ISNULL(SYD.AdmissionNo,'')AS StudentName FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYD ON SYD.StudentID=SM.StudentID" +
                        " WHERE SYD.StudentStatus='S' AND SYD.AcaStart=" + Session["AcaStart"] + " AND SYD.SchoolID=" + Convert.ToInt32(Session["SchoolID"]) + " ORDER BY FirstName,MiddleName,LastName", "StudentID", "StudentName", "");
                }
                else
                {
                    ddlEmployee.Items.Clear();
                }
                if (ddlEmployee.Items.Contains(ddlEmployee.Items.FindByValue(rdr.GetValue(5).ToString()))) ddlEmployee.Items.FindByValue(rdr.GetValue(5).ToString()).Selected = true;
                //hidFlag.Value   = rdr.GetValue(6).ToString();
                if (Convert.ToInt32(rdr.GetValue(3).ToString()) <= 1)
                {
                    Panel2.Visible = true;
                    gvMenuMaster.Visible = true;
                    gvMenuMaster.Columns[0].Visible = true;
                    gvMenuMaster.Columns[1].Visible = true;
                    gvMenuMaster.Columns[2].Visible = true;
                    //SqlDataReader rdr4 = objWeb.BindReader("EXEC spUserBindUserManagement  " + rdr.GetValue(0).ToString() + ",'" + Session["Type"] + "'," + ddlUserGroup.SelectedValue +"");
                    SqlDataReader rdr4 = objWeb.BindReader("EXEC spUserBindUserManagement  " + rdr.GetValue(0).ToString() + ",'" + Session["Type"] + "',0");
                    gvMenuMaster.DataSource = rdr4;
                    gvMenuMaster.DataBind();
                    //checkDisable();
                    rdr4.Close();
                    rdr4.Dispose();
                    gvMenuMaster.Columns[0].Visible = false;
                    gvMenuMaster.Columns[1].Visible = false;
                    gvMenuMaster.Columns[2].Visible = false;
                    gvMenuMaster.Columns[3].ItemStyle.Font.Bold = true;
                }
                else
                {
                    Panel2.Visible = false;
                    gvMenuMaster.Visible = false;
                }
                SqlDataReader rdrUserSchool = objWeb.BindReader("SELECT SchoolID FROM MTUserInstitutionMaster WHERE UID= " + rdr.GetValue(0) + "");
                while (rdrUserSchool.Read())
                {
                    if (chkSchool.Items.Contains(chkSchool.Items.FindByValue(rdrUserSchool.GetValue(0).ToString())))
                        chkSchool.Items.FindByValue(rdrUserSchool.GetValue(0).ToString()).Selected = true;
                }
                rdrUserSchool.Close();
                rdrUserSchool.Dispose();

                SqlDataReader rdrUserLibrary = objWeb.BindReader("SELECT LIBLibraryID FROM MTUserLibraryMaster WHERE UID= " + rdr.GetValue(0) + "");
                while (rdrUserLibrary.Read())
                {
                    if (chkLibrary.Items.Contains(chkLibrary.Items.FindByValue(rdrUserLibrary.GetValue(0).ToString())))
                        chkLibrary.Items.FindByValue(rdrUserLibrary.GetValue(0).ToString()).Selected = true;
                }
                rdrUserLibrary.Close();
                rdrUserLibrary.Dispose();

                txtPassword.BackColor = System.Drawing.Color.Red;
                txtConfirmPassword.BackColor = System.Drawing.Color.Red;
                ClientScript.RegisterStartupScript(this.GetType(), "EnableJKKK", "<script> pEnableDisable('DISPLAY'); </script>");

            }
            else
            {
                BindGrid();
                //ClientScript.RegisterStartupScript(this.GetType(),"disScript","<script language='javascript' type='text/javascript'>alert('User Not Found')</script>");
                string strResult = objWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "129_1", "");
                ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script language='javascript' type='text/javascript'>alert('" + strResult + "')</script>");
            }
            rdr.Close();
            rdr.Dispose();

        }
        else
        {
            BindGrid();
        }
        if (gvMenuMaster.Rows.Count > 0)
        {
            varData = objWeb.ReturnSingleValue("DECLARE @varSelected AS VARCHAR(2000); SET @varSelected=''; SELECT @varSelected=@varSelected+'^'+ Caption" + Session["Type"].ToString() + "  " +
                 " FROM MTFormControlMaster WHERE ControlName LIKE 'gvMenuMaster%'  AND FormID=129 ORDER BY PriorityNo  SELECT CASE WHEN LEN(@varSelected)>1  THEN SUBSTRING(@varSelected,1,LEN(@varSelected)) " +
                 " ELSE '0' END AS  GridDetails");
            string[] StrData = varData.ToString().Split('^');
            gvMenuMaster.HeaderRow.Cells[3].Text = StrData[1];
            gvMenuMaster.HeaderRow.Cells[4].Text = StrData[2];
            gvMenuMaster.HeaderRow.Cells[6].Text = StrData[3];
            gvMenuMaster.HeaderRow.Cells[7].Text = StrData[4];
            gvMenuMaster.HeaderRow.Cells[8].Text = StrData[5];
            gvMenuMaster.HeaderRow.Cells[9].Text = StrData[6];
        }
        if (Session["Type"] == "2")
        {
            if (gvMenuMaster.Rows.Count > 0)
            {
                for (int intLoop = 0; intLoop < gvMenuMaster.Rows.Count; intLoop++)
                {
                    gvMenuMaster.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.Rows[intLoop].Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.Rows[intLoop].Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                    gvMenuMaster.Rows[intLoop].Cells[5].HorizontalAlign = HorizontalAlign.Right;
                }
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string strResult = "";
        string[] strArray = hidFlag.Value.Split('^');
        int intUID = Convert.ToInt32(strArray[1]);

        List<string> lstArray = new List<string>();

        if (intUID == ((int)Session["UID"]))
        {
            try
            {
                // ClientScript.RegisterStartupScript(this.GetType(), "Enable", "<script> alert('Logger User Can't Delete'); </script>");
                //  strResult = objWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "129_2", "");
                // ClientScript.RegisterStartupScript(this.GetType(), "Enable", "<script> alert('"+strResult+"'); </script>");
                BindGrid();
                ClientScript.RegisterStartupScript(this.GetType(), "Enable", "<script> alert('Logger User Can not  Delete'); </script>");

                // return;
            }
            catch (SqlException sq)
            {


            }
        }

        else
        {


            try
            {
                if (objWeb.ReturnNumericValue("EXEC spGetPrimaryValueExists 'UID','MTUserMaster,MTUserLimitMaster,MTUserInstitutionMaster,MDUserLoginDetails,MTUserLibraryMaster'," + intUID + "") > 0)
                {
                    strResult = objWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "')</script>");
                }
                else
                {
                    lstArray.Add("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuUserManagement', " +
                   " 'User : " + txtUserName.Text.Trim().Replace("'", "''") + ", User Type " + ddlUserType.SelectedItem + " , Is Deleted')");

                    //lstArray.Add("UPDATE MTUserMaster SET UserStatus = 'N' WHERE UID = " + intUID + "");
                    lstArray.Add("DELETE FROM MTUserMaster WHERE UID = " + intUID + "");
                    lstArray.Add("DELETE FROM MTUserLimitMaster WHERE UID=" + intUID + "");
                    lstArray.Add("DELETE FROM MTUserInstitutionMaster WHERE UID=" + intUID + "");
                    lstArray.Add("DELETE FROM MDUserLoginDetails WHERE UID=" + intUID + "");
                    strResult = objWeb.ExecuteQueryList(lstArray);
                    // objWeb.ExecuteQuery(qry);
                    //ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script language='javascript' type='text/javascript'>alert('User Profile Deleted...')</script>");
                    strResult = objWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "3", "");
                    ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script language='javascript' type='text/javascript'>alert('" + strResult + "')</script>");
                }
                BindGrid();
            }

            catch (SqlException sq)
            {

            }
           // lstArray.Add("UPDATE MTUserMaster SET UserStatus = 'N' WHERE UID = " + intUID + "");
           // lstArray.Add("DELETE FROM MTUserLimitMaster WHERE UID=" + intUID + "");
           ////lstArray.Add("DELETE FROM MTUserInstitutionMaster WHERE UID=" + intUID + "");
           // try
           // {
           //    strResult= objWeb.ExecuteQueryList(lstArray);
           //   // objWeb.ExecuteQuery(qry);
           //     //ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script language='javascript' type='text/javascript'>alert('User Profile Deleted...')</script>");
           //     strResult = objWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "3", "");
           //     ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script language='javascript' type='text/javascript'>alert('" + strResult + "')</script>");
           //     BindGrid();
           // }

           // catch (SqlException sq)
           // {

           // }

        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        hidCache.Value = "";
        Response.Redirect("mainform.aspx");
    }
    /*======================================Modified By Himanshu on 31.07.2012=====================================*/
    protected void gvMenuMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          CheckBox ckbDisplay = new CheckBox();
          CheckBox chkEdit = new CheckBox();
          CheckBox chkNew = new CheckBox();
          CheckBox chkDelete = new CheckBox();
          //for (int forloop = 0; forloop < gvMenuMaster.Rows.Count; forloop++)
          //{
          //    if (gvMenuMaster.Rows[forloop].Cells[0].Text == "3" || gvMenuMaster.Rows[forloop].Cells[0].Text == "10")
          //    {
          //        chkNew.Enabled = false;
          //        chkEdit.Enabled = false;
          //        chkDelete.Enabled = false;
          //    }
          //    else
          //    {
          //        chkNew.Enabled = true;
          //        chkEdit.Enabled = true;
          //        chkDelete.Enabled = true;
          //    }
          //}
          ckbDisplay = e.Row.FindControl("chkVisible") as CheckBox;
          chkEdit = e.Row.FindControl("chkEdit") as CheckBox;
          chkNew = e.Row.FindControl("chkNew") as CheckBox;
          chkDelete = e.Row.FindControl("chkDelete") as CheckBox;
          //for (int forloop = 0; forloop <gvMenuMaster.Rows.Count; forloop++)
          //{
          //if (gvMenuMaster.Rows.Count > 0)
          //{
          //    int CheckRollNumber = objWeb.ReturnNumericValue("Select RollNumber From MTUserMenuMaster Where MenuName='"+e.Row.Cells[2].Text+"'");
          //    if (objWeb.ReturnSingleValue("SELECT Flag FROM MTClientCompany") == "A")
          //    {
          //        if (e.Row.Cells[0].Text == "3" || e.Row.Cells[0].Text == "10")
          //        {
          //            chkNew.Enabled = false;
          //            chkNew.Checked = false;
          //            chkEdit.Enabled = false;
          //            chkEdit.Checked = false;
          //            chkDelete.Enabled = false;
          //            chkDelete.Checked = false;
          //        }
                  
          //        else if (e.Row.Cells[0].Text == "1" && intSetRollNumber>CheckRollNumber)
          //        {
          //                chkNew.Enabled = false;
          //                chkNew.Checked = false;
          //                chkEdit.Enabled = false;
          //                chkEdit.Checked = false;
          //                chkDelete.Enabled = false;
          //                chkDelete.Checked = false;
          //        }
          //    }
          //}
          //}
          if (ckbDisplay != null) ckbDisplay.Attributes.Add("onclick", "javascript:return ChangeOption(" + e.Row.RowIndex + ',' + 3 + ")");
         if (chkEdit != null) chkEdit.Attributes.Add("onclick", "javascript:return ChangeOption(" + e.Row.RowIndex + ',' + 5 + ")");
         if (chkNew != null) chkNew.Attributes.Add("onclick", "javascript:return ChangeOption(" + e.Row.RowIndex + ',' + 4 + ")");
         if (chkDelete != null) chkDelete.Attributes.Add("onclick", "javascript:return ChangeOption(" + e.Row.RowIndex + ',' + 6 + ")");

      }

    }
    /*===========================================END====================================================================*/
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
     


        if (Convert.ToInt32(ddlUserType.SelectedValue) == 1)
        {
            //gvMenuMaster.Visible = true;
            //Panel2.Visible = true;
            //ddlEmployee.Enabled = true;
            //tdEmployee.InnerText = "Employee Name";
            lblEmployeeName.Text = "Employee Name";
            objWeb.FillDDLs(ddlEmployee, "SELECT PRLEmployeeID,FirstName+' '+MiddleName+' '+LastName+' # '+EmployeeCode AS StaffName FROM PRLEmployeeMaster " +
              " WHERE SchoolID=" + Convert.ToInt32(Session["SchoolID"]) + " AND PRLEmployeeID>0  and EmployeeStatus='N' ORDER BY FirstName+' '+MiddleName+' '+LastName+' # '+EmployeeCode", "PRLEmployeeID", "StaffName", "");

        }
        //else if (Convert.ToInt32(ddlUserType.SelectedValue) > 1)
        //{
        //    //objWeb.FillDDLs(ddlEmployee, "SELECT StudentID,FirstName+' '+MiddleName+' '+LastName+' # '+CASE WHEN RTRIM(ISNULL(AdmissionNo,''))='' THEN RollNumber ELSE AdmissionNo END AS StudentName FROM SIStudentMaster " +
        //    //    " WHERE CollegeCourseID IN (SELECT CollegeCourseID FROM MTCollegeWiseCourseMaster WHERE CollegeID=" + Convert.ToInt32(Session["CollegeID"]) + ") ORDER BY FirstName+' '+MiddleName+' '+LastName+' # '+CASE WHEN RTRIM(ISNULL(AdmissionNo,''))='' THEN RollNumber ELSE AdmissionNo END", "StudentID", "StudentName", "");

        //    objWeb.FillDDLs(ddlEmployee, "SELECT SM.StudentID,SM.FirstName+' '+SM.MiddleName+' '+SM.LastName+' # '+ISNULL(SYD.AdmissionNo,'')AS StudentName FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYD ON SYD.StudentID=SM.StudentID" +
        //               " WHERE SYD.StudentStatus='S' AND SYD.AcaStart=" + Session["AcaStart"] + " AND SYD.SchoolID=" + Convert.ToInt32(Session["SchoolID"]) + " ORDER BY FirstName,MiddleName,LastName", "StudentID", "StudentName", "");
        //    if (chkSchool.Items.FindByValue(Session["SchoolID"].ToString()) != null)
        //        chkSchool.Items.FindByValue(Session["SchoolID"].ToString()).Selected = true;

        //    gvMenuMaster.Visible = true;
        //    Panel2.Visible = true;
        //    ddlEmployee.Enabled = true;

        //    //gvMenuMaster.Visible = false;
        //    //Panel2.Visible = false;
        //    //ddlEmployee.Enabled = true;
        //    //tdEmployee.InnerText = "Student Name";
        //    lblEmployeeName.Text = "Student Name";
        //}
        else
        {
            ddlEmployee.Items.Clear();
            gvMenuMaster.Visible = true;
            Panel2.Visible = true;
            ddlEmployee.Enabled = false;
        }
        ClientScript.RegisterStartupScript(this.GetType(), "disScript1", "<script> pEnableDisable('EDIT'); </script>");
    }
    protected void gvUserDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int intRowIndex = e.Row.RowIndex - 1;
        if (e.Row.RowIndex > -1)
        {
            e.Row.Attributes.Add("ondblclick", "fGridDoubleClick(" + e.Row.RowIndex + ")");
            e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
        }
    }

    protected void ddlUserGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (objWeb.ReturnNumericValue("SELECT UID AS UID,UserID AS UserID,UserName AS UserName,ISNULL(UserTypeID,0) AS UserTypeID,'' AS AcessType,ISNULL(EmployeeIDStudentID,0) AS EmployeeIDStudentID,UserPassword AS UserPassword" +
                                " FROM MTUserMaster WHERE UserStatus='Y' AND UserID='" + txtUserId.Text.Trim().Replace("'", "''") + "'") > 0)

        {
            SqlDataReader rdr = objWeb.BindReader("SELECT UID AS UID,UserID AS UserID,UserName AS UserName,ISNULL(UserTypeID,0) AS UserTypeID,'' AS AcessType,ISNULL(EmployeeIDStudentID,0) AS EmployeeIDStudentID,UserPassword AS UserPassword" +
                                " FROM MTUserMaster WHERE UserStatus='Y' AND UserID='" + txtUserId.Text.Trim().Replace("'", "''") + "'");


            if (rdr.Read())
            {
                txtUserId.Text = rdr.GetValue(1).ToString();
                btnSearch.Enabled = true;
                txtUserName.Text = rdr.GetValue(2).ToString();
                txtUserName.ReadOnly = true;
                // txtUserName.ReadOnly = false;
                txtPassword.Text = rdr.GetValue(6).ToString();
                txtPassword.ReadOnly = true;
                txtConfirmPassword.Text = rdr.GetValue(6).ToString();
                txtConfirmPassword.ReadOnly = true;
                hidFlag.Value = "E^" + rdr.GetValue(0).ToString();
                //ddlUserType.SelectedIndex = -1;
                //ddlEmployee.SelectedIndex = -1;
                Panel2.Visible = true;
                gvMenuMaster.Visible = true;
                gvMenuMaster.Columns[0].Visible = true;
                gvMenuMaster.Columns[1].Visible = true;
                gvMenuMaster.Columns[2].Visible = true;
                SqlDataReader rdr4 = objWeb.BindReader("EXEC spUserBindUserManagement  " + rdr.GetValue(0).ToString() + ",'" + Session["Type"] + "'," + ddlUserGroup.SelectedValue + "");
                gvMenuMaster.DataSource = rdr4;
                gvMenuMaster.DataBind();
                rdr4.Close();
                rdr4.Dispose();
                gvMenuMaster.Columns[0].Visible = false;
                gvMenuMaster.Columns[1].Visible = false;
                gvMenuMaster.Columns[2].Visible = false;
                gvMenuMaster.Columns[3].ItemStyle.Font.Bold = true;
            }

           
        }
        else 
        {


            hidFlag.Value = "N";
            ////ddlUserType.SelectedIndex = -1;
            ////ddlEmployee.SelectedIndex = -1;
            Panel2.Visible = true;
            gvMenuMaster.Visible = true;
            gvMenuMaster.Columns[0].Visible = true;
            gvMenuMaster.Columns[1].Visible = true;
            gvMenuMaster.Columns[2].Visible = true;
            SqlDataReader rdr4 = objWeb.BindReader("EXEC spUserBindUserManagement  0,'" + Session["Type"] + "'," + ddlUserGroup.SelectedValue + "");
            gvMenuMaster.DataSource = rdr4;
            gvMenuMaster.DataBind();
            rdr4.Close();
            rdr4.Dispose();
            gvMenuMaster.Columns[0].Visible = false;
            gvMenuMaster.Columns[1].Visible = false;
            gvMenuMaster.Columns[2].Visible = false;
            gvMenuMaster.Columns[3].ItemStyle.Font.Bold = true;
            ddlEmployee.Enabled = true;
            ddlUserGroup.Enabled=true;
            ddlUserType.Enabled=true;

        }

        ClientScript.RegisterStartupScript(this.GetType(), "disScript19", "<script> pEnableDisable('EDIT'); </script>");
    }
    protected void checkDisable()
    {
        if (gvMenuMaster.Rows.Count > 0)
        {
            if (gvMenuMaster.Rows[gvMenuMaster.Rows.Count].Cells[0].Text == "3" || gvMenuMaster.Rows[gvMenuMaster.Rows.Count].Cells[0].Text == "10")
            {
               // chkNew.Enabled = false;
               // chkEdit.Enabled = false;
               // chkDelete.Enabled = false;
            }
            else
            {
                //chkNew.Enabled = true;
                //chkEdit.Enabled = true;
                //chkDelete.Enabled = true;
            }
        }
    }
}
