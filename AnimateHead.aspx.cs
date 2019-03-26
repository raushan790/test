using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.IO;
using System.Data.SqlClient;
public partial class AnimateHead : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    protected StringBuilder strImates = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] strImageFile = Directory.GetFiles(Server.MapPath("animate\\SlidePhoto"), "*.*");
        string[] strFile;
        string strFileName;
        for (int fileCount = 0; fileCount < strImageFile.Length; fileCount++)
        {
            strFile = strImageFile[fileCount].ToString().Split('\\');
            strFileName = strFile[strFile.Length - 1];
            if ((strFileName.Split('.')[1].ToUpper() == "JPG") || (strFileName.Split('.')[1].ToUpper() == "GIF") || (strFileName.Split('.')[1].ToUpper() == "JPEG") || (strFileName.Split('.')[1].ToUpper() == "PNG"))
            {
                strImates.Append(" <div data-iview:image=\"animate/SlidePhoto/" + strFileName + "\"> </div>");
            }
        }
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
                lblShowLoginDetail.Text = strLogDetail[2] + " " + strLogDetail[0] + " " + strLogDetail[1]; ;
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
                lblShowLoginDetail.Text = strLogDetail[2] + " " + strLogDetail[0] + " " + strLogDetail[1]; ;
            }
            //lblSchoolName.Text = objCCWeb.ReturnSingleValue("SELECt SchoolName1 from MTClientCompany  where SchoolID=" + Session["SchoolID"] + " ");
        }
        /*------------------------- From DATABASE------------------------------
         * 
         * 
        string[] strFile;
        string strFileName;
        SqlDataReader rdr = objCCWeb.BindReader("SELECT SchoolHeaderID,SchoolHeaderText,SchoolImageFile From SchoolHeader");
        while(rdr.Read())
        { 
            if (File.Exists(Server.MapPath("animate\\SlidePhoto\\"+ rdr.GetValue(2).ToString()+"")) == true)
            {
                strFile = Server.MapPath("animate\\SlidePhoto\\" + rdr.GetValue(2).ToString() + "").ToString().Split('\\');
                strFileName = rdr.GetValue(2).ToString();

                if ((strFileName.Split('.')[1].ToUpper() == "JPG") || (strFileName.Split('.')[1].ToUpper() == "GIF") || (strFileName.Split('.')[1].ToUpper() == "JPEG") || (strFileName.Split('.')[1].ToUpper() == "PNG"))
                {
                    if (rdr.GetValue(1).ToString() != "")
                    {
                        strImates.Append(" <div data-iview:image=\"animate/SlidePhoto/" + strFileName + "\"><div class=\"iview-caption caption3\" data-x=\"10\" data-y=\"60\" data-transition=\"expandLeft\">" + rdr.GetValue(1).ToString() + "</div> </div>");
                    }
                    else
                    {
                        strImates.Append(" <div data-iview:image=\"animate/SlidePhoto/" + strFileName + "\"></div>");
                    }
                     
                }
            }
        }
         
         */
    }
}