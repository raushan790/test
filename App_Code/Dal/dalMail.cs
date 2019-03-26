using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for dalMail
/// </summary>

namespace SchoolOnline
{
    public class dalMail
    {
        CCWeb objCCWeb = new CCWeb();
        public dalMail()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetEmailData(dalCommon objCommon,string iMailType)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objCCWeb.BindDataTable(" Exec SpMessageBind  " + objCommon.UID + ",'" + iMailType + "'");
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                objCCWeb = null;
            }
        }
    }
}