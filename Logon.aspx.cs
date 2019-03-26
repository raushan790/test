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
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;


public partial class logon : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        string ip = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()).GetValue(0).ToString();
        System.Web.HttpBrowserCapabilities browser = Request.Browser;
        ((Button)Login1.FindControl("loginButton")).Enabled = true;
        hidBrsr.Value = "";
        hidBrsr.Value = "Type = " + browser.Type + "\n"
            + "Name = " + browser.Browser + "\n"
            + "Version = " + browser.Version + "\n"
            + "Major Version = " + browser.MajorVersion + "\n"
            + "Minor Version = " + browser.MinorVersion + "\n"
            + "Platform = " + browser.Platform + "\n"
            + "Is Beta = " + browser.Beta + "\n"
            + "Is Crawler = " + browser.Crawler + "\n"
            + "Is AOL = " + browser.AOL + "\n"
            + "Is Win16 = " + browser.Win16 + "\n"
            + "Is Wind32 = " + browser.Win32 + "\n"
            + "Support JavaScript = " + browser.EcmaScriptVersion.ToString() + "\n"
            + "Support JavaScript Verion = " + browser["JavaScriptVersion"] + "";

        brsrCheck();
        if (!IsPostBack)
        {
            if (Session["UID"] != null)
                Session.Clear();
            ((TextBox)Login1.FindControl("UserName")).Focus();
            ((TextBox)Login1.FindControl("UserName")).Attributes.Add("onpaste", "javascript:return false;");
            ((TextBox)Login1.FindControl("Password")).Attributes.Add("onpaste", "javascript:return false;");
           // ((TextBox)Login1.FindControl("txtCapText")).Attributes.Add("onpaste", "javascript:return false;");
            ((TextBox)Login1.FindControl("UserName")).Attributes.Add("AutoComplete", "off");
            ((TextBox)Login1.FindControl("Password")).Attributes.Add("AutoComplete", "off");
           // ((TextBox)Login1.FindControl("txtCapText")).Attributes.Add("AutoComplete", "off");

            objCCWeb.FillDDLs(((DropDownList)Login1.FindControl("ddlAcademicYear")), "SELECT AcaStart AS AcaStart,CAST(AcaStart AS VARCHAR)+' - '+CAST(AcaStart+1 AS VARCHAR) AS AcademicSession" +
                    " FROM MTAcademicSessionMaster WHERE AcaStart<>0 ORDER BY AcaStart DESC", "AcaStart", "AcademicSession", "");
            string strAcaStart = objCCWeb.ReturnSingleValue("SELECT AcaStart FROM MTAcademicSessionMaster WHERE AcaEndDate>=CONVERT(VARCHAR,GETDATE(),111) AND AcaStartDate<=CONVERT(VARCHAR,GETDATE(),111)");
            try
            {
                ((DropDownList)Login1.FindControl("ddlAcademicYear")).Items.FindByValue(strAcaStart).Selected = true;
            }
            catch
            {

            }
            //btnAbout.Attributes.Add("onmouseover", "javascript:return fMouseOver(this)");
            //btnAbout.Attributes.Add("onmouseout", "javascript:return fMouseOut(this)");
            hid.Value = CreateSalt(6); //Creating a Salt and Sending to Client.
            hdnFlag.Value = "";
        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            Authenticate(e);
        }
        catch
        {
        }
    }
    //For Creating a Salt of 8bit
    private static string CreateSalt(int size)
    {
        //Generate a cryptographic random number.
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);

        // Return a Base64 string representation of the random number.
        return Convert.ToBase64String(buff);
    }
    //Concatenating the Hash Password with Hash Pwd
    private static string CreatePasswordHash(string pwd, string salt)
    {
        string saltAndPwd = String.Concat(pwd, salt);
        string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd.ToLower(), "sha1");
        return hashedPwd;
    }
    protected void lnkOnline_Click(object sender, EventArgs e)
    {
        int intAcastart = objCCWeb.ReturnNumericValue("Select MAX(AcaStart) From MTAcademicsessionmaster");
        Session["UserLogin"] = Session.SessionID;
        objCCWeb.ExecuteQuery("INSERT INTO MDUserLoginDetails(IPAddress,LoginTime,SessionDetails,UserAgent,Referrer,URL,LoggedOutTime,LoginSuccessStatus) VALUES ('" + Request.ServerVariables.Get("remote_addr").ToString() + "',GETDATE(),'" + Session.SessionID.ToString() + "','" + hidBrsr.Value.Trim().ToString() + "','" + Request.UrlReferrer.ToString() + "','" + Request.Url.ToString() + "',null,'Y')");
        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\">alert('Online Registration Not Started !');</script>");
        Response.Redirect("NewGuideline.aspx");
    }
    protected void brsrCheck()
    {
        try
        {
            System.Web.HttpBrowserCapabilities browser1 = Request.Browser;
            if (browser1.Beta == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "dis", "<script>alert('You are using Beta version of browser, it is not allowed');</script>");
                ((Button)Login1.FindControl("loginButton")).Enabled = false;
                return;
            }
            else if (Convert.ToString(browser1.Browser) == "Firefox" && Convert.ToInt32(browser1.MajorVersion) < 22)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "dis", "<script>alert('You are using lower version of Firefox \\n Please use Firefox 22.0 or above');</script>");
                ((Button)Login1.FindControl("loginButton")).Enabled = false;
                return;
            }
            else if (Convert.ToString(browser1.Browser) == "IE" && Convert.ToInt32(browser1.MajorVersion) < 8)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "dis", "<script>alert('You are using lower version of IE \\n Please use IE 8.0 or above');</script>");
                ((Button)Login1.FindControl("loginButton")).Enabled = false;
                return;
            }
        }
        catch (Exception exx)
        {
            Response.Write("<script language='javascript'> alert('" + exx.Message.ToString() + "')</script>");
            return;
        }
    }
    /*------------Added BY Manju on 30-11-2012----------------*/
    protected void lnkEnqOnline_Click(object sender, EventArgs e)
    {
        Session["Online"] = "1";
        Response.Redirect("StudentOnlineEnquiry.aspx");
    }
    protected void Authenticate(AuthenticateEventArgs e)
    {
        SqlConnection conExecute = new SqlConnection(objCCWeb.ReturnConnectionString().ToString());
        try
        {
            string strUserName, strPwd;
            strUserName = Login1.UserName;
            strPwd = ((TextBox)Login1.FindControl("Password")).Text;

            /* Authenticating the User Through Procedure */
            SqlCommand cmdExecute = new SqlCommand("sp_AuthenticateUser", conExecute);
            cmdExecute.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@varUserID";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Size = 30;
            param1.Direction = ParameterDirection.Input;
            param1.Value = Login1.UserName.Replace("'", "''");

            cmdExecute.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@varUserPwd";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Size = 60;
            param2.Direction = ParameterDirection.Input;
            param2.Value = strPwd;

            cmdExecute.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@varUserSalt";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Size = 10;
            param3.Direction = ParameterDirection.Input;
            param3.Value = hid.Value;

            cmdExecute.Parameters.Add(param3);
            conExecute.Open();

            SqlDataReader sdrLogin = cmdExecute.ExecuteReader();

            /* THIS READERS RETURNS THESE VALUES
                ValidUser, 
                UID,
                UserID,
                UserName,
                UserTypeID,
                EmployeeIDStudentID
            */
            //((MSCaptcha.CaptchaControl)Login1.FindControl("ccJoin")).ValidateCaptcha(((TextBox)Login1.FindControl("txtCapText")).Text);
            //Login1.FailureText = "Incorrect Code";
             
            //  if (!((MSCaptcha.CaptchaControl)Login1.FindControl("ccJoin")).UserValidated)
            //  {
                Login1.FailureText = "Invalid User Name or Password";
                
                if (sdrLogin.HasRows)
                {
                    sdrLogin.Read();

                    
                    if (sdrLogin.GetValue(sdrLogin.GetOrdinal("ValidUser")).ToString() == "1")
                    {
                        Session["UserID"] = sdrLogin.GetValue(sdrLogin.GetOrdinal("UserID"));
                        Session["UID"] = sdrLogin.GetValue(sdrLogin.GetOrdinal("UID"));
                        Session["UserName"] = sdrLogin.GetValue(sdrLogin.GetOrdinal("UserName"));
                        Session["AcaStart"] = ((DropDownList)Login1.FindControl("ddlAcademicYear")).SelectedValue;
                        Session["AcademicSession"] = ((DropDownList)Login1.FindControl("ddlAcademicYear")).SelectedValue + "-" + Convert.ToInt32(Convert.ToInt32(((DropDownList)Login1.FindControl("ddlAcademicYear")).SelectedValue) + 1);
                        Session["Type"] = "1";

                        if (Session["SchoolID"] == null)
                        {
                            //if (objCCWeb.ReturnNumericValue("SELECT Count(SchoolID) FROM MTUserInstitutionMaster WHERE UID=" + Session["UID"] + "") > 1)
                            //{
                            //    Login1.DestinationPageUrl = "~/MTChangeSchool.aspx";
                            //}
                            //else
                            //{
                                if (sdrLogin.GetValue(sdrLogin.GetOrdinal("UserTypeID")).ToString() == "3" && hdnFlag.Value == "3")
                                {
                                    Session["ParentID"] = sdrLogin.GetValue(sdrLogin.GetOrdinal("EmployeeIDStudentID")).ToString();
                                    if (objCCWeb.ReturnNumericValue("Select count(SYD.StudentID)  from Sistudentmaster SM inner join sistudentyearwisedetails SYD on SM.StudentID=SYD.StudentID where ParentID='" + Session["ParentID"] + "' AND StudentStatus='S' AND AcaStart=" + Session["AcaStart"] + " ") > 0)
                                    {
                                        Login1.DestinationPageUrl = "~/PlParentLoginForm.aspx";
                                        //  Login1.DestinationPageUrl = "~/SchoolOnline/Default.aspx";
                                    }
                                    else
                                    {
                                        //  Login1.DestinationPageUrl = "~/SchoolOnline/Default.aspx";
                                        Login1.DestinationPageUrl = "~/PlParentLoginForm.aspx";
                                        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Student  does not exist in this Session');</script>");
                                        return;
                                    }
                                    Session["SchoolID"] = objCCWeb.ReturnNumericValue("Select SchoolID from SIStudentMaster Where ParentID IN (Select employeeIDStudentID from MTUserMaster Where UID=" + Session["UID"] + ")");
                                    Session["SchoolName"] = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(SchoolName1),'CampusCare') FROM MTClientCompany WHERE SchoolID=" + Session["SchoolID"] + "") + " :: " + Session["AcademicSession"];
                                }
                                else if (sdrLogin.GetValue(sdrLogin.GetOrdinal("UserTypeID")).ToString() == "2" && hdnFlag.Value == "2")
                                {
                                    Session["StudentID"] = sdrLogin.GetValue(sdrLogin.GetOrdinal("EmployeeIDStudentID")).ToString();
                                    if (objCCWeb.ReturnNumericValue("Select count(SYD.StudentID)  from Sistudentmaster SM inner join sistudentyearwisedetails SYD on SM.StudentID=SYD.StudentID where SM.StudentID='" + Session["StudentID"] + "' AND StudentStatus='S' AND AcaStart=" + Session["AcaStart"] + " ") > 0)
                                    {
                                        Login1.DestinationPageUrl = "~/PlParentLoginForm.aspx";
                                    }
                                    else
                                    {
                                        Login1.DestinationPageUrl = "~/PlParentLoginForm.aspx";
                                        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Student  does not exist in this Session');</script>");
                                        return;
                                    }
                                    Session["SchoolID"] = objCCWeb.ReturnNumericValue("Select SchoolID from SIStudentMaster Where StudentID IN (Select employeeIDStudentID from MTUserMaster Where UID=" + Session["UID"] + ")");
                                    Session["SchoolName"] = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(SchoolName1),'Campus Care') FROM MTClientCompany WHERE SchoolID=" + Session["SchoolID"] + "") + " :: " + Session["AcademicSession"];
                                }
                                else if (sdrLogin.GetValue(sdrLogin.GetOrdinal("UserTypeID")).ToString() == "1" && hdnFlag.Value == "1")
                                {
                                    Session["EmployeeID"] = sdrLogin.GetValue(sdrLogin.GetOrdinal("EmployeeIDStudentID")).ToString();
                                    Login1.DestinationPageUrl = "~/EmployeeLogin.aspx";
                                    Session["UserType"] = "1";
                                    Session["SchoolID"] = objCCWeb.ReturnNumericValue("Select SchoolID from PRLEmployeeMaster Where PRLEmployeeID IN (Select employeeIDStudentID from MTUserMaster Where UID=" + Session["UID"] + ")");
                                    Session["SchoolName"] = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(SchoolName1),'Campus Care') FROM MTClientCompany WHERE SchoolID=" + Session["SchoolID"] + "") + " :: " + Session["AcademicSession"];
                                }
                                else if (sdrLogin.GetValue(sdrLogin.GetOrdinal("UserTypeID")).ToString() == "4" && hdnFlag.Value == "1")
                                {
                                    Login1.DestinationPageUrl = "~/PlManagementLogin.aspx";
                                    Session["SchoolID"] = "1";
                                    Session["SchoolName"] = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(SchoolName1),'Campus Care') FROM MTClientCompany WHERE SchoolID=" + Session["SchoolID"] + "") + " :: " + Session["AcademicSession"];
                                }
                                else if (sdrLogin.GetValue(sdrLogin.GetOrdinal("UserTypeID")).ToString() == "6" && hdnFlag.Value == "6")
                                {
                                    Session["PID"] = objCCWeb.ReturnNumericValue("Select EmployeeIDStudentID from MTUserMaster Where UserID='" + Login1.UserName.Replace("'", "''") + "'  AND UserTypeID=6");
                                    string UserID = objCCWeb.ReturnSingleValue("Select Case when UserId like 'SE%' then 'SE' else 'SR' end as UserID  from MTUserMaster Where UserID='" + Login1.UserName.Replace("'", "''") + "'  AND UserTypeID=6");

                                    if (UserID == "SE")
                                    {
                                        Login1.DestinationPageUrl = "~/SRStudentonlineRegistration11.aspx";
                                    }
                                    else
                                    {
                                        Login1.DestinationPageUrl = "~/SRStudentonlineRegistration.aspx";
                                    }
                                    Session["SchoolID"] = objCCWeb.ReturnNumericValue("Select SchoolID from MTClientCompany");
                                    Session["AcaStart"] = objCCWeb.ReturnNumericValue("Select MAX(AcaStart)from MTAcademicsessionmaster");
                                Session["SchoolName"] = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(SchoolName1),'CampusCare') FROM MTClientCompany WHERE SchoolID=" + Session["SchoolID"] + "") + "";// :: " + Session["AcademicSession"];
                                }
                                else if (sdrLogin.GetValue(sdrLogin.GetOrdinal("UserTypeID")).ToString() == "0" && hdnFlag.Value == "0")
                                {
                                    Login1.DestinationPageUrl = "~/Default.aspx";
                                    Session["SchoolID"] = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(SchoolID),1) FROM MTUserInstitutionMaster WHERE UId=" + Session["UID"] + "");
                                    Session["SchoolName"] = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(SchoolName1),'CampusCare') FROM MTClientCompany WHERE SchoolID=" + Session["SchoolID"] + "") + "" ; //:: " + Session["AcademicSession"];
                                }
                                else
                                {
                                    Session["UserLogin"] = Session.SessionID;
                                    string strUserID = objCCWeb.ReturnSingleValue("SELECT UID FROM MTUsermaster where UserID='" + strUserName + "'");
                                    if (strUserID != "")
                                    {
                                        objCCWeb.ExecuteQuery("INSERT INTO MDUserLoginDetails(UID,IPAddress,LoginTime,SessionDetails,UserAgent,Referrer,URL,LoggedOutTime,LoginSuccessStatus) VALUES ('" + strUserID + "','" +
                                         Request.ServerVariables.Get("remote_addr").ToString() + "',GETDATE(),'" + Session.SessionID.ToString() + "','" + hidBrsr.Value.Trim().ToString() + "','" + Request.UrlReferrer.ToString() + "','" + Request.Url.ToString() + "',null,'N')");//"+Process.GetCurrentProcess().Id.ToString()+"
                                    }
                                    else
                                    {
                                        objCCWeb.ExecuteQuery("INSERT INTO MDUserLoginDetails(UID,IPAddress,LoginTime,SessionDetails,UserAgent,Referrer,URL,LoggedOutTime,LoginSuccessStatus) VALUES (0,'" +
                                                   Request.ServerVariables.Get("remote_addr").ToString() + "',GETDATE(),'" + Session.SessionID.ToString() + "','" + hidBrsr.Value.Trim().ToString() + "','" + Request.UrlReferrer.ToString() + "','" + Request.Url.ToString() + "',null,'N')");//"+Process.GetCurrentProcess().Id.ToString()+"
                                    }
                                    e.Authenticated = false;
                                    Session.Clear();
                                    hdnFlag.Value = hdnFlag.Value + "^N";
                                    return;
                                }
                            //}
                        }
                        Session["UserLogin"] = Session.SessionID;
                        objCCWeb.ExecuteQuery("INSERT INTO MDUserLoginDetails(UID,IPAddress,LoginTime,SessionDetails,UserAgent,Referrer,URL,LoggedOutTime,LoginSuccessStatus) VALUES (" + sdrLogin.GetValue(sdrLogin.GetOrdinal("UID")) +
                                         ",'" + Request.ServerVariables.Get("remote_addr").ToString() + "',GETDATE(),'" + Session.SessionID.ToString() + "','" + hidBrsr.Value.Trim().ToString() + "','" + Request.UrlReferrer.ToString() + "','" + Request.Url.ToString() + "',null,'Y')");//"+Process.GetCurrentProcess().Id.ToString()+"
                        Session["LoginID"] = objCCWeb.ReturnSingleValue("SELECT MAX(LoginID) FROM MDUSerLoginDetails WHERE UID=" + Session["UID"] + " AND LoginSuccessStatus='Y' ");

                        Session.Timeout = 30;
                        e.Authenticated = true;
                    }
                    else
                    {
                        Session["UserLogin"] = Session.SessionID;
                        objCCWeb.ExecuteQuery("INSERT INTO MDUserLoginDetails(UID,IPAddress,LoginTime,SessionDetails,UserAgent,Referrer,URL,LoggedOutTime,LoginSuccessStatus) VALUES (" + sdrLogin.GetValue(sdrLogin.GetOrdinal("UID")) +
                                        ",'" + Request.ServerVariables.Get("remote_addr").ToString() + "',GETDATE(),'" + Session.SessionID.ToString() + "','" + hidBrsr.Value.Trim().ToString() + "','" + Request.UrlReferrer.ToString() + "','" + Request.Url.ToString() + "',null,'N')");//"+Process.GetCurrentProcess().Id.ToString()+"
                        e.Authenticated = false;  
                    }
                }
                else
                {
                    Session["UserLogin"] = Session.SessionID;
                    objCCWeb.ExecuteQuery("INSERT INTO MDUserLoginDetails(UID,IPAddress,LoginTime,SessionDetails,UserAgent,Referrer,URL,LoggedOutTime,LoginSuccessStatus) VALUES (0,'" +
                               Request.ServerVariables.Get("remote_addr").ToString() + "',GETDATE(),'" + Session.SessionID.ToString() + "','" + hidBrsr.Value.Trim().ToString() + "','" + Request.UrlReferrer.ToString() + "','" + Request.Url.ToString() + "',null,'N')");//"+Process.GetCurrentProcess().Id.ToString()+"
                    e.Authenticated = false;
                }
            //}
            //else
            //{
            //    Session["UserLogin"] = Session.SessionID;
            //    string strUserID = objCCWeb.ReturnSingleValue("SELECT UID FROM MTUsermaster where UserID='" + strUserName + "'");
            //    if (strUserID != "")
            //    {
            //        objCCWeb.ExecuteQuery("INSERT INTO MDUserLoginDetails(UID,IPAddress,LoginTime,SessionDetails,UserAgent,Referrer,URL,LoggedOutTime,LoginSuccessStatus) VALUES ('" + strUserID + "','" +
            //         Request.ServerVariables.Get("remote_addr").ToString() + "',GETDATE(),'" + Session.SessionID.ToString() + "','" + hidBrsr.Value.Trim().ToString() + "','" + Request.UrlReferrer.ToString() + "','" + Request.Url.ToString() + "',null,'N')");//"+Process.GetCurrentProcess().Id.ToString()+"
            //    }
            //    else
            //    {
            //        objCCWeb.ExecuteQuery("INSERT INTO MDUserLoginDetails(UID,IPAddress,LoginTime,SessionDetails,UserAgent,Referrer,URL,LoggedOutTime,LoginSuccessStatus) VALUES (0,'" +
            //                   Request.ServerVariables.Get("remote_addr").ToString() + "',GETDATE(),'" + Session.SessionID.ToString() + "','" + hidBrsr.Value.Trim().ToString() + "','" + Request.UrlReferrer.ToString() + "','" + Request.Url.ToString() + "',null,'N')");//"+Process.GetCurrentProcess().Id.ToString()+"
            //    }
            //    e.Authenticated = false;
            //}
            sdrLogin.Close();
            sdrLogin.Dispose();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            conExecute.Close();
            conExecute.Dispose();
        }
        //  Login1.FailureText = "Invalid User Name or Password Or Check Correct Login Type";
        hdnFlag.Value = hdnFlag.Value + "^N";
        ClientScript.RegisterStartupScript(this.GetType(), "displ", "<script language='javascript'> document.getElementById('" + txtPosition.Text.Trim() + "').click();</script>");
    }
    protected void imgRefresh_Click1(object sender, EventArgs e)
    {
        //((TextBox)Login1.FindControl("txtCapText")).Focus();
    }
    /*------------End of Added BY Manju on 30-11-2012----------------*/
}