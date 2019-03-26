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
using System.IO;
public partial class MainForm : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    public string strLink = "";
    public string strCompany = "";
    string strEmployeeCode = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetNoStore();
        Response.AddHeader("Cache-control", "no-store,must-revalidate,private,no-cache,no-store,pre-check=0,post-check=0,max-stale=0");
        Response.AddHeader("Pragma", "no-cache");
        Response.AddHeader("Expires", "0");

        if (Session["UID"] == null)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
            return;
        }
        if (Request.QueryString["Status"] != null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script>ChangeSchool('" + Session["SchoolName"].ToString() + "');</script>");
        }
        if (Request.QueryString["LinkPage"] != null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script>ChangeSchool(\"" + Session["SchoolName"].ToString().Replace("'", "\'") + "\");</script>");
            strLink = Request.QueryString["LinkPage"].ToString();
            strCompany = Session["CompanyName"].ToString();

        }
        if (!IsPostBack)
        {
            if (Session["CompanyName"] != null)
            {
                strCompany = Session["CompanyName"].ToString();
            }
            imgPhoto.Attributes.Add("onError", "javascript:return AssignError();");
            imgPhoto.ImageUrl = "EmployeePhotos/NoImage.JPG";
            if (Session["SchoolID"] == null)
            {
                if (objCCWeb.ReturnNumericValue("SELECT Count(SchoolID) FROM MTUserInstitutionMaster WHERE UID=" + Session["UID"] + "") > 1)
                {
                    Session["SchoolID"] = "0";
                    Response.Redirect("MTChangeSchool.aspx");
                }
                else
                {
                    //Login1.DestinationPageUrl = "~/Default.aspx";
                    Session["SchoolID"] = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(SchoolID),1) FROM MTUserInstitutionMaster WHERE UID=" + Session["UID"] + "");
                }
               
            }
            
            string strDate = DateTime.Now.Date.ToString("yyyy/MM/dd");
            string strdateLastWeek = Convert.ToString(objCCWeb.ReturnSingleValue("Select convert(varchar,DateAdd(dd,-7,getdate()),111)"));

             // DLHeader.DataSource = objCCWeb.BindDataSet("SELECT Header,Detail,Remark FROM MTUserAppointmentMaster  WHERE ApDate='" + strDate + "' AND EntryUserID=" + Session["UID"] + "");
            DLHeader.DataSource = objCCWeb.BindDataSet("SELECT Header,Detail,Remark FROM MTUserAppointmentMaster  WHERE Display=1 AND EntryUserID=" + Session["UID"] + "");
            DLHeader.DataBind();
            //DLDetails.DataSource = objCCWeb.BindDataSet("SELECT Detail FROM MTUserAppointmentMaster  WHERE ApID>1");
            //DLDetails.DataBind();
             
            DLCaption.DataSource=objCCWeb.BindDataSet("SELECT MenuCaption1 FROM MTuserMEnuMaster UM INNER JOIN MTUserPriorityMaster UP ON UM.ModuleID=UP.ModuleID " +
                " AND UM.RollNumber=UP.RollNumber AND UID="+Session["UID"]+"");
            DLCaption.DataBind();

            ////////int NATodayFollowupCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SRStudentEnquiry WHERE FollowupUID=0  AND DateofEnquiry='" + strDate + "' AND ACASTART=" + Session["AcaStart"].ToString());
            ////////lblTodayEnquiry.Text = NATodayFollowupCount + " Today Enquiry";

            ////////int NALastWeekFollowupCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SRStudentEnquiry WHERE FollowupUID=0  AND DateofEnquiry>='" + strdateLastWeek + "' AND DateofEnquiry<='"+strDate+"' AND ACASTART=" + Session["AcaStart"].ToString());
            ////////lblLastWeekEnquiry.Text = NALastWeekFollowupCount + " Last Week Enquiry";


            ////////int NATodayRegFollowupCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SRStudentmaster WHERE FollowupUID=0  AND Convert(Varchar,DateOfSubmission,111)='" + strDate + "' AND ACASTART=" + Session["AcaStart"].ToString());
            ////////lblTodayRegistration.Text = NATodayRegFollowupCount + " Today Registration";

            ////////int NALastWeekRegFollowupCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SRStudentmaster WHERE FollowupUID=0  AND Convert(Varchar,DateOfSubmission,111)>='" + strdateLastWeek + "' AND Convert(Varchar,DateOfSubmission,111)<='" + strDate + "' AND ACASTART=" + Session["AcaStart"].ToString());
            ////////lblLastWeekRegistration.Text = NALastWeekRegFollowupCount + " Last Week Registration";


            int intEmpEnrolleeID = objCCWeb.ReturnNumericValue("SELECT EmployeeIDStudentID FROM MTuserMaster WHERE UID=" + Session["UID"] + "");
            int intUserType = objCCWeb.ReturnNumericValue("SELECT UserTypeID FROM MTUserMaster WHERE UID=" + Session["UID"] + "");
            int inEmployeeID = objCCWeb.ReturnNumericValue("SELECT EmployeeIDStudentID FROM MTuserMaster WHERE UID=" + Session["UID"] + " AND UserTypeID=1");
            int intStudentID = objCCWeb.ReturnNumericValue("SELECT EmployeeIDStudentID FROM MTuserMaster WHERE UID=" + Session["UID"] + " AND UserTypeID=2");

            if (intUserType==1)
            {
                strEmployeeCode = objCCWeb.ReturnSingleValue("SELECT Employeecode From PRLEmployeeMaster where PRLEmployeeID in(SELECT EmployeeIDStudentID FROM MTuserMaster WHERE UID=" + Session["UID"] + " AND UserTypeID=1)");
            }
            string strusertype = objCCWeb.ReturnSingleValue("Select  Usertype from MDMessageDetails Where Usertype='A'");
            if (intEmpEnrolleeID == 0)
            {
                //DLMessageList.DataSource = objCCWeb.BindDataSet("SELECT ISNULL(MessageTitle,'') AS MessageTitle,Message,ISNULL(NewsFileName,'') as NewsFileName,MessageDate AS Message from MTMessageMaster WHERE MessageStatus='Y'  AND  '" + strDate + "' between MessageDate And MessageTillDate  AND SchoolID=" + Session["SchoolID"].ToString() + " ORDER BY MessageDate desc");
                //DLMessageList.DataBind();

                //int unreadMessagesCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MESSAGESENDDETAILS WHERE TOUID=" + Session["UID"].ToString() + " AND READUNREAD='UR' AND ACASTART=" + Session["AcaStart"].ToString());
                //lblInboxStatus.Text = unreadMessagesCount + " Unread Messages";
            }
            else if (intEmpEnrolleeID > 0 && intUserType == 1 && strusertype == "A")
            {
                //DLMessageList.DataSource = objCCWeb.BindDataSet("SELECT distinct ISNULL(MessageTitle,'') AS MessageTitle," +
                //" Message AS Message,ISNULL(NewsFileName,'') as NewsFileName,MessageDate from MTMessageMaster MM INNER JOIN MDMessageDetails MD ON MD.MessageID=MM.MessageID " +
                //" WHERE (EmployeeID=" + intEmpEnrolleeID + " AND UserType='E') OR UserType='A' AND MessageStatus='Y' AND  '" + strDate + "' between MessageDate  And MessageTillDate  AND SchoolID=" + Session["SchoolID"].ToString() + " ORDER BY MessageDate desc");
                //DLMessageList.DataBind();

                imgPhoto.ImageUrl = "EmployeePhotos/E" + intEmpEnrolleeID + ".jpg?"+ DateTime.Now.ToFileTimeUtc();

                //int unreadMessagesCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MESSAGESENDDETAILS WHERE TOUID=" + Session["UID"].ToString() + " AND READUNREAD='UR' AND ACASTART=" + Session["AcaStart"].ToString());
                //lblInboxStatus.Text = unreadMessagesCount + " Unread Messages";
                //int unreadMessagesCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MESSAGESENDDETAILS WHERE TOUID="+ Session["UID"].ToString() +" AND READUNREAD='UR'");

            }
            else if (intEmpEnrolleeID > 0 && intUserType == 1 && strusertype == "")
            {
                //DLMessageList.DataSource = objCCWeb.BindDataSet("SELECT distinct ISNULL(MessageTitle,'') AS MessageTitle," +
                //" Message AS Message,ISNULL(NewsFileName,'') as NewsFileName,MessageDate from MTMessageMaster MM INNER JOIN MDMessageDetails MD ON MD.MessageID=MM.MessageID " +
                //" WHERE EmployeeID=" + intEmpEnrolleeID + " AND UserType='E' OR UserType='A' AND MessageStatus='Y' AND  '" + strDate + "' between MessageDate  And MessageTillDate AND SchoolID=" + Session["SchoolID"].ToString() + "   ORDER BY MessageDate desc");
                //DLMessageList.DataBind();
                imgPhoto.ImageUrl = "EmployeePhotos/E" + intEmpEnrolleeID + ".jpg?" + DateTime.Now.ToFileTimeUtc();

                //int unreadMessagesCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MESSAGESENDDETAILS WHERE TOUID=" + Session["UID"].ToString() + " AND READUNREAD='UR' AND ACASTART=" + Session["AcaStart"].ToString());
                //lblInboxStatus.Text = unreadMessagesCount + " Unread Messages";
                //int unreadMessagesCount = objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM MESSAGESENDDETAILS WHERE TOUID="+ Session["UID"].ToString() +" AND READUNREAD='UR'");

            }

            else if (intEmpEnrolleeID > 0 && intUserType == 2 && strusertype == "A")
            {
                //DLMessageList.DataSource = objCCWeb.BindDataSet("SELECT distinct ISNULL(MessageTitle,'') AS MessageTitle," +
                //" Message AS Message,ISNULL(NewsFileName,'') as NewsFileName,MessageDate from MTMessageMaster MM INNER JOIN MDMessageDetails MD ON MD.MessageID=MM.MessageID" +
                //" WHERE  StudentID=" + intEmpEnrolleeID + "  AND  UserType='S' OR UserType='A' AND MessageStatus='Y' AND  '" + strDate + "' between MessageDate And MessageTillDate   AND SchoolID=" + Session["SchoolID"].ToString() + " ORDER BY MessageDate desc");
                //DLMessageList.DataBind();
                imgPhoto.ImageUrl = "StudentPhoto/S" + intEmpEnrolleeID + ".jpg?" + DateTime.Now.ToFileTimeUtc();
            }
            else if (intEmpEnrolleeID > 0 && intUserType == 2 && strusertype == "")
            {
                //DLMessageList.DataSource = objCCWeb.BindDataSet("SELECT distinct ISNULL(MessageTitle,'') AS MessageTitle," +
                //" Message AS Message,ISNULL(NewsFileName,'') as NewsFileName,MessageDate from MTMessageMaster MM INNER JOIN MDMessageDetails MD ON MD.MessageID=MM.MessageID" +
                //" WHERE  StudentID=" + intEmpEnrolleeID + "  AND  UserType='S' OR UserType='A' AND MessageStatus='Y' AND  '" + strDate + "' between MessageDate And MessageTillDate  AND SchoolID=" + Session["SchoolID"].ToString() + "  ORDER BY MessageDate desc");
                //DLMessageList.DataBind();
                imgPhoto.ImageUrl = "StudentPhoto/S" + intEmpEnrolleeID + ".jpg?" + DateTime.Now.ToFileTimeUtc();
            }
            int unreadMessagesCount = 0;//objCCWeb.ReturnNumericValue("exec [spMsgGrid]  " + Session["UID"].ToString() + ", " + Session["AcaStart"] + ", " + Session["SchoolID"].ToString() + ", 'EMPLOYEECOUNT',0  ");
            lblInboxStatus.Text = unreadMessagesCount + " Unread Messages";
            //MainImage.Attributes.Add("GALLERYIMG", "no");
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["LinkPage"] != null)
        {
            Response.Redirect(Request.QueryString["LinkPage"] + "?MenuName=" + Request.QueryString["MenuName"] + "");
        }
    }
    protected void btnOpenEnqReg_Click(object sender, EventArgs e)
    {
        if (hidFlag.Value != "")
        {
            Response.Redirect("SREnqRegFollowupAssigner.aspx?EnqRegType=" + hidFlag.Value + "");
        }
    }
    protected void DLMessageList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        HiddenField hdd;
        HtmlTableCell td;
        Image imgnews;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            hdd = new HiddenField();
            td = new HtmlTableCell();
            imgnews = new Image();
            hdd = (HiddenField)e.Item.FindControl("hdnNewsAttachment");
            td = (HtmlTableCell)e.Item.FindControl("tdimg");
            imgnews = (Image)e.Item.FindControl("imgbtnNews");
            if (!File.Exists(Server.MapPath("News") + "/" + hdd.Value + ""))
            {
                td.Visible = false;
            }

            if (hdd.Value.Split('.')[hdd.Value.Split('.').Length - 1].ToUpper() == "PDF")
            {
                imgnews.ImageUrl = "News/pdf.JPG";
            }
            
        }
    }
}
