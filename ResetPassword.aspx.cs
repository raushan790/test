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
using System.Net.NetworkInformation;
using System.Net;
using System.Data.SqlClient;
using System.Collections.Generic;


public partial class ResetPassword : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        PDisplayType();
    }
    protected void PDisplayType()
    {
        try
        {
            foreach (Control frmControl in frmResetPassword.Controls)
            {
                if (frmControl.GetType().FullName == "System.Web.UI.WebControls.TextBox")
                {
                    TextBox tempBox = (TextBox)frmControl;
                    //tempBox.Attributes.Add("onFocus", "pFocus(this);");
                    //tempBox.Attributes.Add("onBlur", "pBlur(this);");
                    //tempBox.Attributes.Add("onBlur", "pBlur(this);");
                    tempBox.Attributes.Add("AutoComplete", "off");
                }


            }

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string strResult = "";
        string[] strUID;
        string StrStudentID = "";
        ((MSCaptcha.CaptchaControl)btnReset.FindControl("ccJoin")).ValidateCaptcha(((TextBox)btnReset.FindControl("txtCapText")).Text);
        if (!((MSCaptcha.CaptchaControl)btnReset.FindControl("ccJoin")).UserValidated)
        {
            lblCode.Text = "Code Mismatch. Please enter the Code again.";
            txtCapText.Text = "";
            txtCapText.Focus();
            return;
        }
        else
        {
            lblCode.Text = "";
        }

        if (rbtnReg.Checked == true)
        {
            StrStudentID = objCCWeb.ReturnSingleValue("Select SM.Applicationid from AdmStudentMaster SM Inner Join ADMFatherDetails FD on SM.ApplicationID=FD.ApplicationID where SM.FirstName='" + txtFirstName.Text.Trim().Replace("'", "''") + "' and SM.DOB='" + objCCWeb.ChangeYYYYMMDD(txtDOB.Text.Trim()) + "' and SM.MobileNo='" + txtMobileNo.Text.Trim().Replace("'", "''") + "' ");

            if (StrStudentID != "")
            {
                strUID = objCCWeb.ReturnSingleValue("SELECT CAST(UID AS VARCHAR)+'^'+CAST(UserID aS VARCHAR) From MTUserMaster where EmployeeIDStudentID=" + StrStudentID + " AND UsertypeID=6 and UserStatus='Y'").ToString().Split('^');
                if (strUID[0] != "")
                {
                    string strPassword = getCode(); 
                    if (strResult == "")
                    {
                        strResult = objCCWeb.ExecuteQuery("UPDATE MTUserMaster SET UserPassword='" + FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword, "SHA1") + "' WHERE UID=" + strUID[0] + " and UserTypeID=6  and UserStatus='Y' and  UserID  like 'SR%'");
                        strResult = strResult + objCCWeb.ExecuteQuery("Update AdmStudentMaster Set StrNum='" + strPassword + "' where ApplicationId=" + StrStudentID + "");
                        if (strResult == "")
                        {
                            sendSMS("91" + txtMobileNo.Text.Trim().Replace("'", "''") + "", "Your UserID is " + strUID[1] + " and your password is " + strPassword + ". Please retain this information for future reference.", strUID[0]);
                            txtMobileNo.Text = "";
                            txtDOB.Text = "";
                            txtFirstName.Text = "";
                            txtCapText.Text = "";
                            strResult = "The New Password Has Been Sent To The Registered Mobile No.";
                        }
                    }
                }
                else
                {
                    strResult = "User ID Does not Exist For This Child.";
                }
            }
            else
            {
                strResult = "UserID Does not Exist For This Child.";
            }
        }
       if (rbtnParentlogin.Checked == true)
        {
            StrStudentID = objCCWeb.ReturnSingleValue("Select ParentID from SIStudentMaster SM Inner join SIStudentFatherDetails  FD on FD.StudentID=SM.StudentID where SM.FirstName='" + txtFirstName.Text.Trim().Replace("'", "''") + "' and SM.DateofBirth='" + objCCWeb.ChangeYYYYMMDD(txtDOB.Text.Trim()) + "' and FD.MobileNo like '%" + txtMobileNo.Text.Trim().Replace("'", "''") + "%' ");
            if (StrStudentID != "")
            {
                strUID = objCCWeb.ReturnSingleValue("SELECT CAST(UID AS VARCHAR)+'^'+CAST(UserID aS VARCHAR) From MTUserMaster where EmployeeIDStudentID=" + StrStudentID + " AND UsertypeID=3 and UserID like 'P%'").ToString().Split('^');
                if (strUID[0] != "")
                {
                    string strPassword = getCode();
                    if (strResult == "")
                    {
                        strResult = objCCWeb.ExecuteQuery("UPDATE MTUserMaster SET UserPassword='" + FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword, "SHA1") + "' WHERE UID=" + strUID[0] + " and UserTypeID=3 and UserID like 'P%'");
                        if (strResult == "")
                        { 
                            sendSMS("91" + txtMobileNo.Text.Trim().Replace("'", "''") + "", "Your UserID is " + strUID[1] + " and your password is " + strPassword + ". Please retain this details for future reference.",strUID[0]);
                            txtMobileNo.Text = "";
                            txtDOB.Text = "";
                            txtFirstName.Text = "";
                            strResult = "The New Password Has Been Sent To The Registered Mobile No.";
                        }
                    }
                }
                else
                {
                    strResult = "Parent User ID Does not Exist For This Child.";
                }
            }
            else
            {
                strResult = "Entered data is not matching with our data";
            }
        }

        if (rbtnStudentlogin.Checked == true)
        {
            StrStudentID = objCCWeb.ReturnSingleValue("Select SM.StudentID from SIStudentMaster SM Inner join SIStudentFatherDetails FD on FD.StudentID=SM.StudentID where SM.FirstName='" + txtFirstName.Text.Trim().Replace("'", "''") + "' and SM.DateofBirth='" + objCCWeb.ChangeYYYYMMDD(txtDOB.Text.Trim()) + "' and FD.MobileNo like '%" + txtMobileNo.Text.Trim().Replace("'", "''") + "%' ");
            if (StrStudentID != "")
            {
                strUID = objCCWeb.ReturnSingleValue("SELECT CAST(UID AS VARCHAR)+'^'+CAST(UserID aS VARCHAR) From MTUserMaster where EmployeeIDStudentID=" + StrStudentID + " AND UsertypeID=2 and UserID like 'S%'").ToString().Split('^');
                if (strUID[0] != "")
                {
                    string strPassword = getCode();
                    if (strResult == "")
                    {
                        strResult = objCCWeb.ExecuteQuery("UPDATE MTUserMaster SET UserPassword='" + FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword, "SHA1") + "' WHERE UID=" + strUID[0] + " and UserTypeID=2 and UserID like 'S%'");
                        if (strResult == "")
                        {
                            sendSMS("91" + txtMobileNo.Text.Trim().Replace("'", "''") + "", "Your UserID is " + strUID[1] + " and your password is " + strPassword + ". Please retain this details for future reference.", strUID[0]);
                            txtMobileNo.Text = "";
                            txtDOB.Text = "";
                            txtFirstName.Text = "";
                            txtCapText.Text = "";
                            strResult = "The New Password Has Been Sent To The Registered Mobile No.";
                        }
                    }
                }
                else
                {
                    strResult = "Student User ID Does not Exist For This Child.";
                }
            }
            else
            {
                strResult = "Entered data is not matching with our data";
            }
        }

        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('" + strResult + "');</script>");
    }

    protected string getCode()
    {
        Random r = new Random();
        int intRnd = 0;
        int intFor = 0;
        string strValue = "23456789ABCDEFGHJKMNPQRSTUVWXYZ23456789";
        string strCode = "";

        for (intFor = 0; intFor < 6; intFor++)
        {
            intRnd = r.Next(1, 39);
            strCode += strValue.Substring(intRnd, 1);
        }
        return strCode;
    }
   
    protected int sendSMS(string phoneno, string smsmessage, string strUID)
    { 
        int messageSendSuccessfully = 0;

        try
        {

            if (phoneno.Trim() == "" || smsmessage.Trim() == "")
                return messageSendSuccessfully;

            List<string> lstArray = new List<string>();
            int intCreditAvailable = 0;
            string[] strCheckNumber;
            string strPhoneNumber = phoneno.Trim();
            CreditAvailable();

            SqlDataReader sqlRdr = objCCWeb.BindReader("SELECT SMSURL,UserName,Password,NumberPerSMS,CreditAvailable,TotalSMSSend,SenderNo FROM EMSMSSettingsMaster Where TransactionType='T'");

            if (sqlRdr.Read())
            {
                smsmessage = "Dear Parents, " + smsmessage.Trim() + " Regards " + sqlRdr.GetValue(6).ToString();
                intCreditAvailable = 0;
                strCheckNumber = strPhoneNumber.Split(',');
                for (int i = 0; i < strCheckNumber.Length; i++)
                {
                    if (strCheckNumber[i].Trim() != "" && strCheckNumber[i].Trim().Length == 12)
                    {
                        strPhoneNumber = strCheckNumber[i];
                        if (intCreditAvailable >= objCCWeb.ReturnNumericValue("SELECT CreditAvailable FROM EMSMSSettingsMaster  Where TransactionType='T'"))
                        {
                            return messageSendSuccessfully;
                        }
                        else
                        {
                            string DecodedMessage = smsmessage.Trim();
                            string req = "URL API";


                            req = sqlRdr.GetValue(0).ToString() + "?UserName=" + sqlRdr.GetValue(1).ToString() + "&Password=" + sqlRdr.GetValue(2).ToString() + "&Type=Individual&To=" + strPhoneNumber.Trim() + "&Mask=" + sqlRdr.GetValue(6).ToString() + "&Message=" + DecodedMessage + "";

                            try
                            {
                                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(req);
                                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                                string responseString = respStreamReader.ReadToEnd();
                                myResp.Close();
                            }
                            catch
                            {
                            }

                            objCCWeb.ExecuteQuery("INSERT INTO EMSMSSendDetails (SMSSendID,SMSTo,PRLEmployeeID,StudentID,Content,SMSTemplateID,SMSDate,EntryUserID,EntryDate)" +
                                " SELECT ISNULL(MAX(SMSSendID),0)+1,'" + strPhoneNumber + "',0,0," +
                                " '" + DecodedMessage.Replace("'", "''") + "',0,GETDATE()," +
                                " " + strUID + ",GETDATE() FROM EMSMSSendDetails");

                            int msgCount = ((DecodedMessage.Length - 1) / 160) + 1;
                            objCCWeb.ExecuteQuery("UPDATE EMSMSSettingsMaster SET TotalSMSSend=TotalSMSSend+" + msgCount + ",CreditAvailable=CreditAvailable-" + msgCount + "  Where TransactionType='T'");
                            strPhoneNumber = "";
                            messageSendSuccessfully++;
                        }
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "AlertMsg", "<script>alert('Please Enter Values In SMS Settings.'</script>");
                return messageSendSuccessfully;
            }

        }
        catch (Exception ex)
        {
        }

        return messageSendSuccessfully;
    }

    protected void CreditAvailable()
    {
        try
        {
            string[] strUserNamePWD = objCCWeb.ReturnSingleValue("SELECT UserName+'^'+Password from EMSMSSettingsMaster Where TransactionType='T'").Split('^');
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://www.smsgatewaycenter.com/library/checkbalance.php?Username=" + strUserNamePWD[0].ToString() + "&Password=" + strUserNamePWD[1].ToString() + "");
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            myResp.Close();
            objCCWeb.ExecuteQuery("Update EMSMSSettingsMaster Set CreditAvailable=" + responseString.Split('|')[0].Split(':')[1].Trim() + " Where TransactionType='T'");

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disError", "<script language='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        } 
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logon.aspx");
    }
}
