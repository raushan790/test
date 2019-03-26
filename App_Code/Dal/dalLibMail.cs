using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SchoolOnline;

/// <summary>
/// Get All Mail Details Inbox,Outbox,UnradMail, Read Mail
/// </summary>
namespace SchoolOnline
{
    public class dalLibMail
    {
        #region Top5InboxMessages

        public DataSet GetTop5UnreadMail(dalCommon objCommonPara,string eMailType)
        {
            CCWeb ObjccWeb = new CCWeb();
            DataSet ds = new DataSet();
            try
            {
                string Query = " Exec SpMessageBind  " + objCommonPara.UID + ",'UR'";
                ds = ObjccWeb.BindDataSet(Query);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ds = null;
                objCommonPara = null;
                ObjccWeb = null;
            }
        }
        #endregion
    }
}