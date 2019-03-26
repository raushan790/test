using System;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;



/// <summary>
/// Summary description for WSStudentSearch
/// </summary>
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
[System.Web.Services.WebService]
public class WSStudentSearch : System.Web.Services.WebService {

    public WSStudentSearch () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        //Senthil
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT (SM.FirstName+' '+SM.MiddleName+' '+SM.LastName) +' # '+SYD.AdmissionNo +' # '+ClassName1+'-'+SectionName1 from SIStudentMaster SM " +
                                " INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID=SYD.StudentID INNER JOIN mtClassMaster MCM ON MCM.ClassID=SYD.ClassID INNER JOIN mtSectionMaster MSM ON MSM.SectionID=SYD.SectionID" +
                                " WHERE SYD.AcaStart=" + intvalue[1] + "  AND SYD.SchoolID=" + intvalue[0] + " AND (SM.FirstName+' '+SM.MiddleName+' '+SM.LastName) like '" + prefixText + "%'");




        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    
    [WebMethod]
    public int NextValue(int current, string tag)
    {
        current= current + 1;
        if (current > 2099)
            current = 2099;
        return current;
    }
    [WebMethod]
    public int PrevValue(int current, string tag)
    {
       current= current - 1;
        if (current < 1900)
            current = 1900;
        return current;
    }
    [WebMethod]
    public string[] GetFCityList(string prefixText, int count)
    {
        //Manju
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT CityName1,CityID  FROM MTCityMaster  WHERE  CityName1  LIKE '" + prefixText + "%'");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }

    [WebMethod]
    public string[] GetHLStudentList(string prefixText, int count)
    {
        //Senthil
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT (SM.FirstName+' '+SM.MiddleName+' '+SM.LastName) +' # '+SYD.AdmissionNo FROM SIStudentMaster SM " +
                                " INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID=SYD.StudentID " +
                                " WHERE SYD.StudentStatus='S' AND SYD.AcaStart=" + intvalue[1] + "  AND SYD.SchoolID=" + intvalue[0] + " AND (SM.FirstName+' '+SM.MiddleName+' '+SM.LastName) like '" + prefixText + "%'");




        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }

    [WebMethod]
    public string[] GetMCityList(string prefixText, int count)
    {
        //Manju
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT CityName1,CityID  FROM MTCityMaster  WHERE  CityName1  LIKE '" + prefixText + "%'");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetFDesignation(string prefixText, int count)
    {
        //Manju
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT PDesignationName1,PDesignationID FROM MTPDesignationMaster  WHERE  PDesignationName1  LIKE '" + prefixText + "%'  ORDER BY PDesignationName1");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetFOccupation(string prefixText, int count)
    {
        //Manju
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT POccupationName1,POccupationID FROM MTPOccupationMaster  WHERE  POccupationName1 LIKE '" + prefixText + "%'  ORDER BY POccupationName1");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetMDesignation(string prefixText, int count)
    {
        //Manju
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT PDesignationName1 ,PDesignationID FROM MTPDesignationMaster  WHERE  PDesignationName1  LIKE '" + prefixText + "%'  ORDER BY PDesignationName1");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetMOccupation(string prefixText, int count)
    {
        //Manju
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT POccupationName1,POccupationID FROM MTPOccupationMaster  WHERE  POccupationName1  LIKE '" + prefixText + "%'  ORDER BY POccupationName1");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetResiCityList(string prefixText, int count)
    {
        //Manju
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT CityName1,CityID  FROM MTCityMaster  WHERE  CityName1  LIKE '" + prefixText + "%'");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetPerCityList(string prefixText, int count)
    {
        //Manju
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT CityName1,CityID  FROM MTCityMaster  WHERE  CityName1  LIKE '" + prefixText + "%'");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    /*================End of Added By Manju on 01-05-2012======================*/
    /*================Added By Bhawna On 01-05-012==============================*/

    [WebMethod]
    public string[] GetStudentCharacter(string prefixText, int count)
    {
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT  StudentCharacter,0 FROM SIStudentTCDetails STCD" +
        " INNER JOIN SIStudentYearWiseDetails SYWD ON SYWD.StudentID=STCD.StudentID AND SYWD.AcaStart=STCD.AcaStart " +
        " WHERE SYWD.SchoolID=" + count + " AND StudentCharacter like '" + prefixText + "%' " +
        " GROUP BY StudentCharacter ORDER BY StudentCharacter ");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetPromotion(string prefixText, int count)
    {
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT  STCD.Promotion,0 FROM SIStudentTCDetails STCD " +
        " INNER JOIN SIStudentYearWiseDetails SYWD ON SYWD.StudentID=STCD.StudentID AND SYWD.AcaStart=STCD.AcaStart" +
        " WHERE SYWD.SchoolID=" + count + " AND STCD.Promotion like '" + prefixText + "%'" +
        " GROUP BY STCD.Promotion ORDER BY STCD.Promotion ");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetStream(string prefixText, int count)
    {
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        List<string> items = new List<string>(count);
        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT  STCD.Stream,0 FROM SIStudentTCDetails STCD " +
        " INNER JOIN SIStudentYearWiseDetails SYWD ON SYWD.StudentID=STCD.StudentID AND SYWD.AcaStart=STCD.AcaStart " +
        " WHERE SYWD.SchoolID=" + count + " AND STCD.Stream like '" + prefixText + "%'" +
        " GROUP BY STCD.Stream ORDER BY STCD.Stream ");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetStudentName(string prefixText, int count)
    {
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        List<string> items = new List<string>(count);
        string SchoolID = "";
        string AcaStart = "";
        AcaStart = count.ToString().Substring(0, 4);
        SchoolID = count.ToString().Substring(7, 1);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT FirstName+' '+MiddleName+' '+LastName+' # '+     " +
        " ISNULL(AdmissionNo,0)AS StudentName,SM.StudentID FROM SIStudentMaster SM " +
        " INNER JOIN SIStudentYearWiseDetails  SYD ON SM.StudentID=SYD.StudentID " +
        " WHERE FirstName+' '+MiddleName+' '+LastName+' # '+  ISNULL(AdmissionNo,0) " +
        " LIKE '" + prefixText + "%' AND " +
        " SM.StudentID IN (SELECT StudentID FROM SIStudentYearWIseDetails WHERE AcaStart=" + AcaStart + " AND SchoolID=" + SchoolID + " AND StudentID NOT " +
        " IN (SELECT StudentID FROM SIStudentYearWiseDetails WHERE AcaStart IN " +
        " (SELECT AcaStart FROM MTAcademicSessionMaster WHERE AcaStart> " +
        " (SELECT AcaStart FROM MTAcademicSessionMaster WHERE AcaStart=" + AcaStart + ")))) " +
        " GROUP BY SM.StudentID,SM.FirstName,SM.MiddleName,SM.LastName,SYD.AdmissionNo " +
        " ORDER BY FirstName+' '+MiddleName+' '+LastName+' '+  ISNULL(AdmissionNo,0)  ");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    // Added By Vijay Kumar For Employee AutoComplete Method 
    [WebMethod]
    public string[] GetEmployeeDetails(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("Select (PRL.FirstName+' '+PRL.MiddleName+' '+PRL.LastName)+' # '+PRL.EmployeeCode From PRLEmployeeMaster PRL" +
                           " Where SchoolID=" + intvalue[0] + " AND PRL.EmployeeStatus='N' AND (PRL.FirstName+' '+PRL.MiddleName+' '+PRL.LastName) like '" + prefixText + "%' ");




        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }




    [WebMethod]
    public string[] GetEmployeeCompletionList(string prefixText, int count)
    {
        //HIMANSNHU On 25.06.2012
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT (PEM.FirstName+' '+PEM.MiddleName+' '+PEM.LastName) +' # '+PEM.EmployeeCode FROM PRLEmployeeMaster PEM " +
                                " WHERE PEM.SchoolID= " + intvalue[0] + " AND (PEM.FirstName+' '+PEM.MiddleName+' '+PEM.LastName) like '" + prefixText + "%' Order By PEM.FirstName+' '+PEM.MiddleName+' '+PEM.LastName");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
       [WebMethod]
    public string[] GetFqualfication(string prefixText, int count)
    {
        //Archana
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT PQualificationName1,PQualificationID FROM MTPqualificationmaster  WHERE  PQualificationName1  LIKE '" + prefixText + "%'  ORDER BY PQualificationName1");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }

    [WebMethod]
    public string[] GetMqualfication(string prefixText, int count)
    {
        //Archana
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT PQualificationName1,PQualificationID FROM MTPqualificationmaster  WHERE  PQualificationName1  LIKE '" + prefixText + "%'  ORDER BY PQualificationName1");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    //*******************For Parent list 30.07.2012 Start ***************************//
    [WebMethod]
    public string[] GetParentList(string prefixText, int count)
    {
        //Archana
        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT DISTINCT  FatherName+'#'+MotherName+'#'+CASt(SM.ParentID AS VARCHAR),SM.ParentID FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID INNER JOIN SIStudentFatherDetails SFD ON YD.StudentID=SFD.StudentID INNER JOIN SIStudentMotherDetails SMD ON YD.StudentID=SMD.StudentID WHERE SM.SchoolId=" + intvalue[0] + " AND  YD.AcaStart=" + intvalue[1] + "   AND FatherName LIKE '" + prefixText + "%' ");
        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            //return items.ToArray();

            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    //*******************For Parent list 30.07.2012 END ***************************//
    /************(For Showing Emloyee list whose status is N)***************/
    [WebMethod]
    public string[] GetEmployeeHealthList(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT (PEM.FirstName+' '+PEM.MiddleName+' '+PEM.LastName) +' # '+PEM.EmployeeCode FROM PRLEmployeeMaster PEM " +
                                " WHERE EmployeeStatus='N' AND PEM.SchoolID= " + intvalue[0] + " AND (PEM.FirstName+' '+PEM.MiddleName+' '+PEM.LastName) like '" + prefixText + "%' Order By PEM.FirstName+' '+PEM.MiddleName+' '+PEM.LastName");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }

    //========================================== Added By Bhawna ================================================
    [WebMethod]
    public string[] GetdAffNo(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT Affiliation FROM MTClientCompany WHERE Affiliation LIKE '" + prefixText + "%' AND Affiliation<>'' ");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }

    [WebMethod]
    public string[] GetPDName(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT FirstName+' '+MiddleName+' '+LastName+' # '+"+                               
                            " ISNULL(AdmissionNo,0)AS StudentName,SM.StudentID FROM SIStudentMaster SM "+
                            " INNER JOIN SIStudentYearWiseDetails  SYD ON SM.StudentID=SYD.StudentID "+
                            " WHERE FirstName+' '+MiddleName+' '+LastName+' # '+  ISNULL(AdmissionNo,0) "+                                
                            " LIKE '" + prefixText + "%' AND "+
                            " SM.StudentID IN (SELECT StudentID FROM SIStudentYearWIseDetails WHERE AcaStart="+intvalue[1]+" AND SchoolID="+intvalue[0]+" AND StudentID NOT "+
                            " IN (SELECT StudentID FROM SIStudentYearWiseDetails WHERE AcaStart IN "+
                            " (SELECT AcaStart FROM MTAcademicSessionMaster WHERE AcaStart> "+
                            " (SELECT AcaStart FROM MTAcademicSessionMaster WHERE AcaStart=" + intvalue[1] + ")))) GROUP BY SM.StudentID,SM.FirstName,SM.MiddleName,SM.LastName,SYD.AdmissionNo ORDER BY FirstName+' '+MiddleName+' '+LastName+' '+  ISNULL(AdmissionNo,0)  ");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }

    [WebMethod]
    public string[] GetGroupName(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT UserGroupName FROM MTusergroupmaster WHERE UserGroupName Like '" + prefixText + "%' ORDER BY UserGroupName  ");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }


    [WebMethod]
    public string[] GetUserName(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT REPLACE(UserID,' ','')+' # '+ CAST(UID as VARCHAR) AS UserID FROM MTUserMaster WHERE UID IN(SELECT DISTINCT UID FROM MTUserLimitMaster WHERE ModuleID IN(18,19)) " +
                   " AND UserStatus='Y' AND UserTypeID IN (0,1) AND UserID LIKE '" + prefixText + "%' ORDER BY UserID ");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }

    [WebMethod]
    public string[] GetUserAdminEmployee(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT UserID FROM MTUserMaster WHERE  UserStatus = 'Y'  AND UserTypeID IN (0,1) AND UserID Like '" + prefixText + "%' ORDER BY UserID ");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }

    [WebMethod]
    public string[] GetUserParent(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT UserID FROM MTUserMaster WHERE  UserStatus = 'Y'  AND UserID Like '" + prefixText + "%' ORDER BY UserID ");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }

    [WebMethod]
    public string[] GetEnquiryStudent(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT ISNULL(FirstName,'') +' '+ ISNULL(MidName,'') +' '+  ISNULL(LastName,'')  +' # '+   ISNULL(CAST(ApplicationNO As Varchar),'') AS StudentName,ApplicationNO " +
                    " FROM srstudentenquiry WHERE SchoolID=" + intvalue[0] + " AND Acastart=" + intvalue[1] + " AND ISNULL(FirstName,'') +' '+ ISNULL(MidName,'') +' '+  ISNULL(LastName,'') +' # '+  ISNULL(CAST(ApplicationNO As Varchar),'')  " +
                    "  Like '" + prefixText + "%'  ORDER BY FirstName ");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetModeOfFollowUp(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT  ModeofFollowup,ModeofFollowup AS ModeofFollowup1 FROM SRStudEnquiryFollowups "+
                                            " WHERE  AcaStart=" + intvalue[1] + "  AND SchoolId=" + intvalue[0] + "   AND  ModeofFollowup " +
                                            " LIKE '" + prefixText + "%' GROUP BY ModeofFollowup ORDER BY ModeofFollowup ");

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
     [WebMethod]
    public string[] GetRegistrationStudent(string prefixText, int count)
    {

        CCWeb ObjCCWeb = new CCWeb();
        int intCheckCount = 1;
        string strvalue = count.ToString().Replace("000", "~");
        string[] intvalue = strvalue.Trim().Split('~');
        List<string> items = new List<string>(count);

        SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT ISNULL(FirstName,'') +' '+ ISNULL(MiddleName,'') +' '+  ISNULL(LastName,'')  +' # '+  ISNULL(CAST(ReferenceNo AS NVARCHAR),'') AS StudentName,SM.ARStudentID FROM SRStudentMaster  SM " +
                        " WHERE SM.SchoolId=" + intvalue[0] + " AND  SM.AcaStart=" + intvalue[1] + "  " +
                        " AND ISNULL(FirstName,'') +' '+ ISNULL(MiddleName,'') +' '+  ISNULL(LastName,'') +' # '+  ISNULL(CAST(ReferenceNo AS NVARCHAR),'') Like '" + prefixText + "%'  ORDER BY FirstName");   

        while (rdrValue.Read())
        {
            if (intCheckCount <= 20)
            {
                items.Add(Convert.ToString(rdrValue.GetValue(0)));
            }
            else
                break;
            intCheckCount++;
        }
        rdrValue.Close();
        return items.ToArray();
    }
     [WebMethod]
     public string[] GetInformMediaList(string prefixText, int count)
     {
         //Archana
         CCWeb ObjCCWeb = new CCWeb();
         int intCheckCount = 1;
         string strvalue = count.ToString().Replace("000", "~");
         string[] intvalue = strvalue.Trim().Split('~');
         List<string> items = new List<string>(count);

         SqlDataReader rdrValue = ObjCCWeb.BindReader("select distinct informmedia  from HLNursingDetails where informmedia  like '" + prefixText + "%'");


         while (rdrValue.Read())
         {
             if (intCheckCount <= 20)
             {
                 items.Add(Convert.ToString(rdrValue.GetValue(0)));
             }
             else
                 break;
             //return items.ToArray();

             intCheckCount++;
         }
         rdrValue.Close();
         return items.ToArray();
     }

     [WebMethod]
     public string[] GetFSubLedger(string prefixText, int count)
     {
         //Atul
         CCWeb ObjCCWeb = new CCWeb();
         int intCheckCount = 1;
         string strvalue = count.ToString().Replace("000", "~");
         string[] intvalue = strvalue.Trim().Split('~');
         List<string> items = new List<string>(count);

         SqlDataReader rdrValue = ObjCCWeb.BindReader("SELECT SubLedgerName,FASLCode from FASubLedgerMaster  WHERE  SubLedgerName  LIKE '" + prefixText + "%'");
         while (rdrValue.Read())
         {
             if (intCheckCount <= 20)
             {
                 items.Add(Convert.ToString(rdrValue.GetValue(0)));
             }
             else
                 break;
             //return items.ToArray();

             intCheckCount++;
         }
         rdrValue.Close();
         return items.ToArray();
     }


     [WebMethod]
     public string[] GetStudentListWIthAdmissionNo(string prefixText, int count)
     {
         CCWeb ObjCCWeb = new CCWeb();
         int intCheckCount = 1;
         string SQLQuery;
         string strvalue = count.ToString().Replace("000", "~");
         string[] intvalue = strvalue.Trim().Split('~');
         List<string> items = new List<string>(count);

         SQLQuery = "SELECT DISTINCT  Replace((FirstName+' '+MiddleName+' '+LastName),'  ',' ')+'#'+CASt(SYD.AdmissionNo AS VARCHAR),SIM.ParentID FROM SIStudentMaster SIM " +
         " INNER JOIN  SISTudentYearWIseDetails SYD ON SIM.StudentID=SYD.StudentID " +
         " WHERE SIM.SchoolId=" + intvalue[0] + " AND  SYD.AcaStart=" + intvalue[1] + "   AND SIM.FirstName LIKE '" + prefixText + "%' ";

         SqlDataReader rdrValue = ObjCCWeb.BindReader(SQLQuery);
         while (rdrValue.Read())
         {
             if (intCheckCount <= 20)
             {
                 items.Add(Convert.ToString(rdrValue.GetValue(0)));
             }
             else
                 break;
             intCheckCount++;
         }
         rdrValue.Close();
         return items.ToArray();
     }

     /************(Added By Ravindra(2014-12-16) For Showing Student Transfer Certificate )***************/

     [WebMethod]
     public string[] GetStudentListForTC(string prefixText, int count)
     {
         CCWeb ObjCCWeb = new CCWeb();
         int intCheckCount = 1;
         string SQLQuery;
         string strvalue = count.ToString().Replace("000", "~");
         string[] intvalue = strvalue.Trim().Split('~');
         List<string> items = new List<string>(count);

         SQLQuery = "SELECT DISTINCT Replace((FirstName+' '+MiddleName+' '+LastName),'  ',' ')+'#'+CASt(SYD.AdmissionNo AS VARCHAR),SIM.ParentID FROM SIStudentMaster SIM " +
         " INNER JOIN  SISTudentYearWIseDetails SYD ON SIM.StudentID=SYD.StudentID " +
         " WHERE SYD.StudentStatus='S' AND SYD.SchoolID=" + intvalue[0] + " AND  SYD.AcaStart=" + intvalue[1] + " AND SIM.FirstName LIKE '" + prefixText + "%' ";

         SqlDataReader rdrValue = ObjCCWeb.BindReader(SQLQuery);
         while (rdrValue.Read())
         {
             if (intCheckCount <= 20)
             {
                 items.Add(Convert.ToString(rdrValue.GetValue(0)));
             }
             else
                 break;
             intCheckCount++;
         }
         rdrValue.Close();
         return items.ToArray();
     }

     [WebMethod]
     public string[] GetStudentListTC(string prefixText, int count)
     {
         CCWeb ObjCCWeb = new CCWeb();
         int intCheckCount = 1;
         string SQLQuery;
         string strvalue = count.ToString().Replace("000", "~");
         string[] intvalue = strvalue.Trim().Split('~');
         List<string> items = new List<string>(count);

         SQLQuery = "SELECT DISTINCT Replace((SIM.FirstName+' '+SIM.MiddleName+' '+SIM.LastName),'  ',' ')+'#'+CAST(SYD.AdmissionNo AS VARCHAR),SIM.ParentID FROM SIStudentTCDetails TC " +
         " INNER JOIN SIStudentYearWiseDetails SYD ON SYD.StudentID=TC.StudentID AND TC.AcaStart=SYD.AcaStart INNER JOIN SIStudentMaster SIM ON SIM.StudentID=SYD.StudentID " +
         " WHERE SYD.StudentStatus='T' AND SYD.SchoolID=" + intvalue[0] + " AND SYD.AcaStart=" + intvalue[1] + " AND SIM.FirstName LIKE '" + prefixText + "%' ";

         SqlDataReader rdrValue = ObjCCWeb.BindReader(SQLQuery);
         while (rdrValue.Read())
         {
             if (intCheckCount <= 20)
             {
                 items.Add(Convert.ToString(rdrValue.GetValue(0)));
             }
             else
                 break;
             intCheckCount++;
         }
         rdrValue.Close();
         return items.ToArray();
     }
    /************(Ended For Showing Student Transfer Certificate )***************/

    
}

