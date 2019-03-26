using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using SchoolOnline;

/// <summary>
/// Summary description for dalDiary
/// </summary>
public class dalDiary
{
    CCWeb objCCWeb = new CCWeb();
	public dalDiary()
	{
		//
		// TODO: Add constructor logic here
        //
	}



    public  DataTable GetDiaryDetails(dalCommon objCommon,int flagid,string sFromDate , string sToDate)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objCCWeb.BindDataTable("Exec Sp_PLPersonalDairy " + objCommon.SchoolId + "," + flagid + ",'" + sFromDate + "','" + sToDate + "'");
            return dt;
        }
        catch (Exception)
        {   
            throw;
        }
    }
}