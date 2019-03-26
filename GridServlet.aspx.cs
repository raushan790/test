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
using System.Data.Sql;
using System.Data.SqlClient;

public partial class GridServlet : System.Web.UI.Page
{
    
    CCWeb objCCWeb = new CCWeb();
    SqlDataReader sqlRdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string strResult ="";

        if (Request["TypeID"] != null && Request["TypeID"] != "")
        {
            //SqlDataReader sqlRdr;
            if (Request["TypeID"] == "FillListBox")
            {

                sqlRdr = objCCWeb.BindReader(Request["StrQuery"]);
                //if (Request["pAction"]=="FillListBox")
                // {
                //     sqlRdr = objCCWeb.BindReader(Request["strQuery"]);
                // }
                while (sqlRdr.Read())
                {
                    strResult = strResult + sqlRdr.GetValue(0).ToString() + "^" + sqlRdr.GetValue(1).ToString() + "~";
                }
                if (strResult != "") strResult = strResult.Remove(strResult.Length - 1);
            }
            else if (Request["TypeID"] == "ReturnSingleValue")
            {

                sqlRdr = objCCWeb.BindReader(Request["StrQuery"]);
                //if (Request["pAction"]=="FillListBox")
                // {
                //     sqlRdr = objCCWeb.BindReader(Request["strQuery"]);
                // }
                if (sqlRdr.Read())
                {
                    strResult = sqlRdr.GetValue(0).ToString();
                }
            }
            //else if (Request["TypeID"] == "ExecuteQuery")
            //{
            //    strResult = objCCWeb.ExecuteQuery(Request["StrQuery"]);
            //}
            else if (Request["TypeID"] == "FillClientGrid")
            {
                Int32 intcount = 0;
                sqlRdr = objCCWeb.BindReader(Request["StrQuery"]);
                while (sqlRdr.Read())
                {
                    if (intcount == 0)
                    {
                        intcount = 1;
                        for (int intForLoop = 0; intForLoop < sqlRdr.FieldCount; intForLoop++)
                        {
                            strResult = strResult + sqlRdr.GetName(intForLoop).ToString() + "^";
                        }
                        if (strResult != "") strResult = strResult.Remove(strResult.Length - 1);
                        strResult = strResult + "~";
                    }
                    for (int intForLoop = 0; intForLoop < sqlRdr.FieldCount; intForLoop++)
                    {
                        strResult = strResult + sqlRdr.GetValue(intForLoop).ToString() + "^";
                    }
                    if (strResult != "") strResult = strResult.Remove(strResult.Length - 1);
                    strResult = strResult + "~";
                }

                if (strResult != "") strResult = strResult.Remove(strResult.Length - 1);
            }
            else //if (Request["TypeID"] == "FillGrid")
            {
                sqlRdr = objCCWeb.BindReader(Request["StrQuery"]);
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
            }
            sqlRdr.Close();
            sqlRdr.Dispose();

            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(strResult);
            Response.End();
        }
        else if (Request["TypeID"] == "ExecuteQuery")
            {
            
            strResult = objCCWeb.ExecuteQuery(Request["StrQuery"]);
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(strResult);
            Response.End();
            }
        //}
    }
}
