using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SchoolOnline
/// </summary>
namespace SchoolOnline
{
    public class SchoolOnline : dalCommon
    {
        protected CCWeb objWeb = new CCWeb();
        public string SubjectValue { get; set; }


        public SchoolOnline()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    public class soAssignment : SchoolOnline
    {
        public DataTable GetAssignmentDetails(string hidValue)
        {
            try
            {
                DataTable dtAssig = new DataTable();
                dtAssig = objWeb.BindDataTable("Exec SP_Assignment " + StudEmp + "," + AcaStart + "," + SchoolId + ",'" + hidValue + "','" + FromDate + "','" + Todate + "','" + SubjectValue + "'");
                return dtAssig;
            }
            catch (Exception)
            {
                throw;
            }
            finally { objWeb = null; }
        }
    }
}



