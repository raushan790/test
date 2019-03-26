using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Wait : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CCWeb objCCWeb = new CCWeb();
        if (Request.QueryString["StrQuery"] != null)
        {
            string strResult = "";
            string strQuery = "";
            if (Request.QueryString["StrQuery"] == "User")
            {
                //strQuery = "SELECT '' AS SNo,AM.LIBAuthorID,AuthorName" + Session["Type"].ToString() + " FROM LIBAuthorMaster AM INNER JOIN LIBCollectionAuthorDetails CD ON AM.LIBAUTHORID=CD.LIBAUTHORID WHERE  LIBCollectionDetailID=" + Request.QueryString["Value"] + " and LIBLIBRARYID=" + Session["LibraryID"] + "";
                strQuery = "EXEC spUserOnline " + Session["UID"] + ",'" + Session.SessionID.Replace("'","''") + "',''";
            }

            SqlDataReader sqlRdr = objCCWeb.BindReader(strQuery);
            while (sqlRdr.Read())
            {
                for (int intForLoop = 0; intForLoop < sqlRdr.FieldCount; intForLoop++)
                {
                    strResult = strResult + sqlRdr.GetValue(intForLoop).ToString() + "^";
                }
                if (strResult != "") strResult = strResult.Remove(strResult.Length - 1);
                strResult = strResult + "~";
            }

            if (strResult != "") strResult = strResult.Remove(strResult.Length - 1);
            sqlRdr.Close();
            sqlRdr.Dispose();
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(strResult);
            Response.End();
        }

    }
}