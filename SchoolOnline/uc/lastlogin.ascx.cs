using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolOnline_uc_lastlogin : System.Web.UI.UserControl
{
    CCWeb objCCWeb = new CCWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ParentID"] != null)
            {
                string[] strLogDetail = objCCWeb.ReturnSingleValue("DECLARE @VAR nvarchar(2000) " +
               " SET @VAR=ISNULL((SELECT  TOP 1'Last Login :-'+ Convert(varchar,LoginTime,106)+' '+  ISNULL(CONVERT(VARCHAR, LoginTime,108),'')  " +
               " FROM MDUserLoginDetails where UID=" + Session["UID"].ToString() + " AND SessionDetails<>'" + Session.SessionID.ToString() + "'  AND LoginSuccessStatus='Y'  ORDER BY LoginID DESC),ISNULL(Convert(varchar,GETDATE(),106),'')+' '+ ISNULL(CONVERT(VARCHAR, GETDATE(),108),'')) " +
               " SET @VAR=@VAR+'^'+ISNULL((SELECT  'Total Login:- '+CAST(COUNT(*)AS Varchar) FROM MDUserLoginDetails where UID=" + Session["UID"].ToString() + "  AND LoginSuccessStatus='Y'),0) " +
               "  SET @VAR=@VAR+'^'+ISNULL((SELECT  TOP 1 'First Login :-'+ Convert(varchar,LoginTime,106)+' '+  ISNULL(CONVERT(VARCHAR, LoginTime,108),'')  " +
               " FROM MDUserLoginDetails where UID=" + Session["UID"].ToString() + "  AND LoginSuccessStatus='Y'  ORDER BY LoginID ASC),ISNULL(Convert(varchar,GETDATE(),106),'')+' '+ ISNULL(CONVERT(VARCHAR, GETDATE(),108),''))  " +
               " SELECT  @VAR").Split('^');
                ltrlLastlogin.Text = "";
                ltrlLastlogin.Text += "<li id='log1'>" + strLogDetail[2] + "</li>";
                ltrlLastlogin.Text += "<li id='log2'>" + strLogDetail[0] + "</li>";
                ltrlLastlogin.Text += "<li id='log3'>" + strLogDetail[1] + "</li>";


            }
            if (Session["UID"] != null)
            {
                string[] strLogDetail = objCCWeb.ReturnSingleValue("DECLARE @VAR nvarchar(2000) " +
                " SET @VAR=ISNULL((SELECT  TOP 1'Last Login :-'+ Convert(varchar,LoginTime,106)+' '+  ISNULL(CONVERT(VARCHAR, LoginTime,108),'')  " +
                " FROM MDUserLoginDetails where UID=" + Session["UID"].ToString() + " AND SessionDetails<>'" + Session.SessionID.ToString() + "'  AND LoginSuccessStatus='Y'  ORDER BY LoginID DESC),ISNULL(Convert(varchar,GETDATE(),106),'')+' '+ ISNULL(CONVERT(VARCHAR, GETDATE(),108),'')) " +
                " SET @VAR=@VAR+'^'+ISNULL((SELECT  'Total Login:- '+CAST(COUNT(*)AS Varchar) FROM MDUserLoginDetails where UID=" + Session["UID"].ToString() + "  AND LoginSuccessStatus='Y'),0) " +
                "  SET @VAR=@VAR+'^'+ISNULL((SELECT  TOP 1 'First Login :-'+ Convert(varchar,LoginTime,106)+' '+  ISNULL(CONVERT(VARCHAR, LoginTime,108),'')  " +
                " FROM MDUserLoginDetails where UID=" + Session["UID"].ToString() + "  AND LoginSuccessStatus='Y'  ORDER BY LoginID ASC),ISNULL(Convert(varchar,GETDATE(),106),'')+' '+ ISNULL(CONVERT(VARCHAR, GETDATE(),108),''))  " +
                " SELECT  @VAR").Split('^');
                ltrlLastlogin.Text = "";
                ltrlLastlogin.Text += "<li id='log1'>" + strLogDetail[2] + "</li>";
                ltrlLastlogin.Text += "<li id='log2'>" + strLogDetail[0] + "</li>";
                ltrlLastlogin.Text += "<li id='log3'>" + strLogDetail[1] + "</li>";

            }

        }
    }
}