/*
    Project Name            :   CampusCare
    Client                  :   
    Database                :   SQL Server 2005
    Front-End               :   ASP.NET With C#, Java Script, Ajax
    Reporting Tool          :   Crystal Report 11.0
    Team                    :   Sijo,Swapnil,Sandhya,Tinu,Ushas,Jitender Kumar
    Tables                  :   
    Procedures              :   
    Page Created            :   Tinu  
    Codes                   :   Tinu
    Testing & Modification  :   Jitender Kumar
    Remarks                 :   For Display and Print the Student Related Reports  
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
public partial class SIReports : System.Web.UI.Page
{
    protected string strFormula = "";
    protected string strCheck = "";
   
    ReportDocument cr = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
         CCWeb objCCWeb = new CCWeb();
        try
            {
            string strServer = System.Configuration.ConfigurationManager.AppSettings.Get("ServerName");
            string strDatabase = System.Configuration.ConfigurationManager.AppSettings.Get("DatabaseName");
            string strUID = objCCWeb.ReturnDataBaseUID();
            string strPWD = objCCWeb.ReturnDataBasePWD();
            strFormula = Session["Formula"].ToString();
            strCheck = Session["Check"].ToString();

            if (!IsPostBack)
            {
                string[] strStudentList = strFormula.Split('^');
                switch (strCheck)
                {
                    case "StudentList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;

                    case "ListOfAClass":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIListOfaClass.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIListOfaClass.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";

                        }
                        break;
                    case "Student Summary":
                        if (Session["Option"].ToString() == "1")
                        {
                            string str = Server.MapPath("StudentPhoto") + "/";
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentWiseSummary.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(2, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["strPicturePath"].Text = "'" + str + "'";
                        }
                        else
                        {
                            string str = Server.MapPath("StudentPhoto") + "/";
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentWiseSummary.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(2, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";
                            cr.DataDefinition.FormulaFields["strPicturePath"].Text = "'" + str + "'";
                        }
                        break;

                    case "ListOfAClassAndSection":
                        if (Session["Option"].ToString() == "1")
                        {

                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIListOfClass&Section.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIListOfClass&Section.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "AdmissionRegister":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIAdmissionRegister.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIAdmissionRegister.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "NewAdmissionList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSINewAdmission.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSINewAdmission.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "MarkEntryList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIMarkList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[6] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIMarkList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[6] + "'";
                        }
                        break;


                    case "BoardingCategoryList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIBoardingCategoryList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIBoardingCategoryList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;
                    case "FeeGroupList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIFeeGroupList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIFeeGroupList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;
                    case "ClassEmailList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIClassEmailList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIClassEmailList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "MailingAddressList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIMailingAddressList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIMailingAddressList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "ResidenceAddressList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIResidenceAddressList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIResidenceAddressList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "FatherMobileEmailList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentFatherDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentFatherDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "MotherMobileEmailList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentMotherDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentMotherDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "HobbiesCareerGoals":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIHobbiesCareerList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIHobbiesCareerList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "GenderWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIGenderWiseList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIGenderWiseList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }

                        break;

                    case "NationalityWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSINationalityList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSINationalityList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;
                    case "CategoryWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentCategoryList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentCategoryList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;
                    case "ReligionWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentReligionDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentReligionDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;
                    case "CasteWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentCasteDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentCasteDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }

                        break;
                    case "ActivityWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentActivityList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentActivityList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";

                        } break;
                    case "BoardWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIBoardList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.FileName = Server.MapPath("StudentReports") + "/crptSIBoardList.rpt";
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;

                    case "BirthDayWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIDOBList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, Convert.ToInt32(strStudentList[3]));
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[7]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[11] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIDOBList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, Convert.ToInt32(strStudentList[3]));
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[7]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[11] + "'";
                        }
                        break;

                    case "EmergencyContact":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIEmergencyContactDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIEmergencyContactDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";

                        }
                        break;
                    /*------------------------ Modified By Poonam on 31.08.2012------START-----------*/
                    case "PromotionList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIPromotionList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[6] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIPromotionList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[6] + "'";


                        }
                        break;
                    /*------------------------ Modified By Poonam on 31.08.2012------END-----------*/

                    case "PromotionSummary":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentPromotionListSummary.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[3]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[6] + "'";
                        break;
                    case "DateOfBirth":
                        //crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIConfirmationofDOB.rpt";
                        //crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        ////crptReportSource.ReportDocument.VerifyDatabase();
                        //crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[1]);
                        //crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        //crptReportSource.ReportDocument.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                        cr.Load(Server.MapPath("StudentReports") + "/crptSIConfirmationofDOB.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.SetParameterValue(0, strStudentList[1]);
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                        cr.DataDefinition.FormulaFields["Reason"].Text = "'" + strStudentList[3] + "'";

                        Session["Option"] = "";
                        break;
                    case "StudentDropoutList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentDropoutList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[5]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[9] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentDropoutList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[5]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[9] + "'";
                        }
                        break;
                    case "StudentTCDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentTCdetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[5]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[9] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentTCdetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[5]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[9] + "'";
                        }
                        break;
                    //case "CharacterCertificate":
                    //    cr.Load(Server.MapPath("StudentReports") + "/crptSICharacterCertificate.rpt");
                    //    cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                    //    //cr.VerifyDatabase();
                    //    cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                    //    cr.SetParameterValue(0, strStudentList[3]);
                    //    cr.DataDefinition.FormulaFields["Character"].Text = "'" + strStudentList[1] + "'";
                    //    cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                    //    Session["Option"] = "";
                    //    break;

                    case "CharacterCertificate":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSICharacterCertificate.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.DataDefinition.FormulaFields["Character"].Text = "'" + strStudentList[1] + "'";
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                        Session["Option"] = "";
                        break;
                    case "CharacterCertificateXII":
                        string str1 = Server.MapPath("StudentPhoto") + "/";
                        cr.Load(Server.MapPath("StudentReports") + "/crptSICharacterCertificateXII.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.SetParameterValue(0, strStudentList[3]);
                        cr.DataDefinition.FormulaFields["Character"].Text = "'" + strStudentList[1] + "'";
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                        cr.DataDefinition.FormulaFields["Remark"].Text = "'" + strStudentList[4] + "'";
                        cr.DataDefinition.FormulaFields["Subject"].Text = "'" + strStudentList[5] + "'";
                        cr.DataDefinition.FormulaFields["SubjName"].Text = "'" + strStudentList[6] + "'";
                        cr.DataDefinition.FormulaFields["SubjClass"].Text = "'" + strStudentList[7] + "'";
                        cr.DataDefinition.FormulaFields["strPicturePath"].Text = "'" + str1 + "'";

                        Session["Option"] = "";
                        break;

                     //case "BonafideCertificate":
                     //   cr.Load(Server.MapPath("StudentReports") + "/crptSIBonafideCertificate.rpt");
                     //   cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                     //   //cr.VerifyDatabase();
                     //   cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                     //   cr.SetParameterValue(0, strStudentList[2]);
                     //   cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[1] + "'";
                     //   cr.DataDefinition.FormulaFields["Remarks"].Text = "'" + strStudentList[3] + "'";
                     //   Session["Option"] = "";
                     //   break;

                    case "BonafideCertificate":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSIBonafideCertificate.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[1] + "'";
                        Session["Option"] = "";
                        break;

                    case "BonafideCertificateForeign":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIBonafideCertificateForeign.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[1] + "'";
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["MinAcaStart"].Text = "'" + strStudentList[3] + "'";
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["MaxAcaStart"].Text = "'" + strStudentList[4] + "'";
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["Grade"].Text = "'" + strStudentList[5] + "'";
                        break;
                    case "TransferCertificate":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSITransferCertificateNew.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        Session["Option"] = "";
                        break;

                    //added For Dues Certificate Archana
                    case "NoDuesCertificate":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptNoDuesCertificate.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        break;
                    // END  Dues Certificate 

                    case "CalendarDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptCalendarDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        }
                        else
                        {

                        }

                        //crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[4] + "'";
                        break;

                    /*------------------------------------ Modifide by Poonam on 31.08.2012 -------------- START -----------------------*/

                    case "SchoolOverview":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSISchoolOverview.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[5] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSISchoolOverview.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[5] + "'";

                        }
                        break;

                    /*------------------------------------ Modifide by Poonam on 31.08.2012 -------------- END -----------------------*/

                    case "AllSchoolOverview":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptAllSchoolOVERVIEW.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                        break;
                    case "StudentIqamaDetails":
                        if (Session["Option"].ToString() == "1")
                        {

                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIIqama&PassportDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, Session["SchoolID"]);
                            //crptReportSource.ReportDocument.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIIqama&PassportDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, Session["SchoolID"]);
                            //cr.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "StudentPassportDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIIqama&PassportDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, Session["SchoolID"]);
                            //crptReportSource.ReportDocument.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIIqama&PassportDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, Session["SchoolID"]);
                            //cr.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;

                    case "StudentIqamaExpiryDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIIqamaPassportExpiryDate.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, Session["SchoolID"]);
                            //crptReportSource.ReportDocument.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIIqamaPassportExpiryDate.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, Session["SchoolID"]);
                            //cr.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;

                    case "StudentPassportExpiryDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIIqamaPassportExpiryDate.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, Session["SchoolID"]);
                            //crptReportSource.ReportDocument.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIIqamaPassportExpiryDate.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, Session["SchoolID"]);
                            //cr.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;
                    case "StudentIqaDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentIqamaDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, Session["SchoolID"]);
                            //crptReportSource.ReportDocument.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentIqamaDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, Session["SchoolID"]);
                            //cr.DataDefinition.FormulaFields["varHeader"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                        }
                        break;
                    case "StudentGroupWiseDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentGroupWiseDetails.rpt";//crptSIStudentGroupWiseDetails
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[5] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptStudentGroupWiseDetails.rpt");//crptSIStudentGroupWiseDetails
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[5] + "'";
                        }
                        break;
                    case "GroupSectionWiseDeatils":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptTotalNoOfStudentInBoysSection.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[3] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptTotalNoOfStudentInBoysSection.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[3] + "'";
                        }
                        break;
                    case "StudentEnrollmentDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentEnrollmentDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[3] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptStudentEnrollmentDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[3] + "'";
                        }
                        break;
                    case "StudentDocumentSubmissionDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentDocumentSudmissionDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, Session["SchoolID"]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[6] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptStudentDocumentSudmissionDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, Session["SchoolID"]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[6] + "'";
                        }
                        break;

                    //***Attendance Reports**///
                    case "DailyAttendance":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIAttDailyAttendance.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[11]);
                            crptReportSource.ReportDocument.SetParameterValue(11, Convert.ToInt32(strStudentList[12]));
                            crptReportSource.ReportDocument.SetParameterValue(12, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";

                        }
                        else
                        {

                            cr.Load(Server.MapPath("StudentReports") + "/crptSIAttDailyAttendance.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                           //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[11]);
                            cr.SetParameterValue(11, Convert.ToInt32(strStudentList[12]));
                            cr.SetParameterValue(12, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";

                        }
                        break;


                    case "DailyAttendance1":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/1crptSIDailyAttendance.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                        crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                        break;
                    case "DailyAttendanceWithRemark":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIAttDailyAttendanceWithRemarks.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIAttDailyAttendanceWithRemarks.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";

                        }
                        break;

                    case "DailyAttendanceWithRemark1":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/1crptSIAttDailyAttendanceWithRemarks.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                        crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                        break;
                    case "StudentWiseAttendance":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIAttStudentWiseAttendance.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                            crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIAttStudentWiseAttendance.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[10]);
                            cr.SetParameterValue(11, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";

                        }
                        break;

                    case "StudentWiseAttendance1":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/1crptSIAttStudentWiseAttendance.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                        crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                        crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        break;
                    case "ClassWiseAttendance":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIAttClassWiseAttendance.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIAttClassWiseAttendance.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";

                        }
                        break;
                    case "ClassWiseAttendance1":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/1crptSIAttClassWiseAttendance.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                        crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                        break;

                    case "AttendanceRegister":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptAttAttendanceRegister.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                        crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                        crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        break;
                    case "AttendanceRegister1":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/1crptAttAttendanceRegister.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                        crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                        crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        break;
                    case "AttendanceSummary":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptAttendanceSummary.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                            crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptAttendanceSummary.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[10]);
                            cr.SetParameterValue(11, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";

                        }
                        break;

                    case "AttendanceSummary1":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/1crptAttendanceSummary.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                        crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                        crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        break;
                    case "AttendanceTeacher1":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/1crptAttTeacherWise.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                        crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                        crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[12]);
                        crptReportSource.ReportDocument.SetParameterValue(12, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        break;
                    case "AttendanceTeacher":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptAttTeacherWise.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                            crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[12]);
                            crptReportSource.ReportDocument.SetParameterValue(12, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptAttTeacherWise.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[10]);
                            cr.SetParameterValue(11, strStudentList[12]);
                            cr.SetParameterValue(12, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        }
                        break;
                    //-----------Added by Shashank on 28-Feb-2013-------------------
                    case "OnlineStudentOffice365":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptOnlineStudentOffice365.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];


                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptOnlineStudentOffice365.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];

                        }

                        break;

                    case "StudentParentlogininfo":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentParentlogoninfo.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            // crptReportSource.ReportDocument.SetParameterValue(7, Convert.ToInt32(Session["SchoolID"]));

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentParentlogoninfo.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[3]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            // cr.SetParameterValue(7, Convert.ToInt32(Session["SchoolID"]));

                        }

                        break;
                    //***TransportReports***//
                    case "RouteWiseSummary":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIRouteWiseSummary.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[5]);
                        crptReportSource.ReportDocument.SetParameterValue(5, "RouteWiseSummary");
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(9, Convert.ToInt32(Session["SchoolID"]));
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[4] + "'";
                        break;
                    case "RouteWiseDetails":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptRouteWiseStudentDetails.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[0]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[8]);
                        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[9]);
                        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                        //crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[2]);
                        //crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                        //crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[3]);
                        //crptReportSource.ReportDocument.SetParameterValue(9, Convert.ToInt32(Session["SchoolID"]));
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["FromMonth"].Text = "'" + strStudentList[6] + "'";
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["ToMonth"].Text = "'" + strStudentList[7] + "'";
                        break;
                    case "RouteWiseList":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptRouteWiseList.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[6]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[7];
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                        break;
                    case "RouteCapacity":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIRouteCapacity.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.RecordSelectionFormula = strStudentList[0];
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(Session["SchoolID"]));
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";
                        break;
                    case "ParentIDWiseStudentList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIParentIDWiseStudentList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIParentIDWiseStudentList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    case "SerialLetter":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSISerialLetter.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(6, Session["SchoolID"]);
                        crptReportSource.ReportDocument.SetParameterValue(7, Session["SchoolID"]);
                        break;
                    //For Admission & Registration Reports
                    case "AllRegisteredStudent":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRAllRegisteredStudent.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                            crptReportSource.ReportDocument.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            // crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[1]);
                            //crptReportSource.ReportDocument.SetParameterValue(12, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        }
                        else
                        {

                            cr.Load(Server.MapPath("StudentReports") + "/crptSRAllRegisteredStudent.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[10]);
                            cr.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            // crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[1]);
                            //cr.SetParameterValue(12, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";

                        }
                        break;
                    case "SelectionWiseDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRSelectionWiseDetails.rpt";//
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                            crptReportSource.ReportDocument.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            //crptReportSource.ReportDocument.SetParameterValue(12, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRSelectionWiseDetails.rpt");//
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[10]);
                            cr.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            //cr.SetParameterValue(12, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";

                        }

                        break;
                    case "ClassWiseSummary":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRClassWiseSummary.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                            crptReportSource.ReportDocument.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            //crptReportSource.ReportDocument.SetParameterValue(12, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRClassWiseSummary.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[10]);
                            cr.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            //cr.SetParameterValue(12, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";


                        }


                        break;
                    case "StatusWiseDetails":

                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRStatusWiseDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRStatusWiseDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";

                        }
                        break;
                    // Enquiry Reports
                    case "EnquiryStatusWiseList":
                        if (Session["Option"].ToString() == "1")
                        {

                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSREnquiryStatusWiseList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(9, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSREnquiryStatusWiseList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[8]);
                            cr.SetParameterValue(8, strStudentList[9]);
                            cr.SetParameterValue(9, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";

                        }

                        break;
                    case "FollowupDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            //crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports_old") + "/crptSRFollowupDetails.rpt";
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRFollowupDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                        }

                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRFollowupDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[8]);
                            cr.SetParameterValue(8, strStudentList[9]);
                            cr.SetParameterValue(9, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";

                        }
                        break;
                    case "ClassWiseEnquirySummary":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRClassWiseEnquirySummary.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRClassWiseEnquirySummary.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[8]);
                            cr.SetParameterValue(8, strStudentList[9]);
                            cr.SetParameterValue(9, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";

                        }
                        break;

                    case "ClassWiseEnquiryDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            //crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports_old") + "/crptSRClassWiseEnquiryDetails.rpt";
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRClassWiseEnquiryDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {

                            cr.Load(Server.MapPath("StudentReports") + "/crptSRClassWiseEnquiryDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[8]);
                            cr.SetParameterValue(8, strStudentList[9]);
                            cr.SetParameterValue(9, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";

                        }

                        break;
                    case "ToadysFolloupReport":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRToadysFollowupReports.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[3] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRToadysFollowupReports.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[3] + "'";
                        }
                        break;

                    case "MonthWiseAnalysis":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRMonthWiseAnalysisReport.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[2] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRMonthWiseAnalysisReport.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[2] + "'";
                        }

                        break;
                    case "YearWiseAnalysis":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRYearWiseAnalysis.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[2] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRYearWiseAnalysis.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[2] + "'";


                        }

                        break;

                    case "SourceWiseEnquiryList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRSourceWiseEnquriyReport.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            crptReportSource.ReportDocument.SetParameterValue(0, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[1] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRSourceWiseEnquriyReport.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            cr.SetParameterValue(0, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[1] + "'";


                        }
                        break;

                    case "StudentEnquirySummary":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentEnqirySummary.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptStudentEnqirySummary.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";

                        }
                        break;

                    case "AdmissionMarkEntryDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            strStudentList = strFormula.Split('^');
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptMarkEntryDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";
                            crptReportSource.ReportDocument.SetParameterValue(0, Session["SchoolID"]);
                        }
                        else
                        {
                            strStudentList = strFormula.Split('^');
                            cr.Load(Server.MapPath("StudentReports") + "/crptMarkEntryDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";
                            cr.SetParameterValue(0, Session["SchoolID"]);
                        }
                        break;
                    case "SMSDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSMSEMPSummary.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(3, Convert.ToInt32(Session["SchoolID"].ToString()));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[2] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSMSEMPSummary.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[1]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[0]);
                            cr.SetParameterValue(3, Convert.ToInt32(Session["SchoolID"].ToString()));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[2] + "'";
                        } break;

                    case "RemarkDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentRemarkDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Session["AcaStart"]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[9] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentRemarkDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Session["AcaStart"]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[9] + "'";
                        }
                        break;
                    //added for the Admission and Enquiry  
                    case "StudentIntraction":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentIntractDescription.rpt";//crptStudentIntractDescription.rpt
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            crptReportSource.ReportDocument.SetParameterValue(0, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[1] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptStudentIntractDescription.rpt");//crptStudentIntractDescription.rpt
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            cr.SetParameterValue(0, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[1] + "'";


                        }


                        break;

                    //for the Admission Process Conversion Rations details
                    case "ApplicationProcessConversionRations":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptEnquiryConversionRation.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[3] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptEnquiryConversionRation.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["ReportCaption"].Text = "'" + strStudentList[3] + "'";

                        }
                        break;

                    case "AdmissionStatusList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIAdmissionStatusWiseList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[8] + strStudentList[9];
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIAdmissionStatusWiseList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, Session["SchoolID"]);
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[8] + strStudentList[9];
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";

                        }
                        break;

                    case "StudentSibilingDetails":

                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentSibilingDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, Session["SchoolID"]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptStudentSibilingDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, Session["SchoolID"]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";

                        }
                        break;


                    case "CONTACTAddressList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentContactAddressList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentContactAddressList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";


                        }
                        break;
                    case "RouteWiseCollection":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptRouteWiseCollection.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                        break;
                    case "StudentBusRouteDetails":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentBusRouteChangeDetailsrpt.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, Session["SchoolID"]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[4] + "'";
                        break;
                    case "StudentRouteDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentRouteDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            // Session["Option"] = "1";
                        }
                        break;

                    case "StudentBusAvailingDetails":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentBusAvailingDetails.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, Session["SchoolID"]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                        break;


                    // For Counselling Reports Added By Priyanka on 9-12-2011 START

                    case "StudentPsychologicalDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("CounselingReports") + "/StudentWisePsychologicalDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, Session["SchoolID"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("CounselingReports") + "/StudentWisePsychologicalDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, Session["SchoolID"]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";

                        }

                        break;


                    case "StudentCounsellingDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("CounselingReports") + "/crptStudentCounsellingDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, Session["SchoolId"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("CounselingReports") + "/crptStudentCounsellingDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, Session["SchoolId"]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";

                        }
                        break;
                    case "StudentFollowUpDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("CounselingReports") + "/crptCMPsycologicalFollwup.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, Session["SchoolId"]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("CounselingReports") + "/crptCMPsycologicalFollwup.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, Session["SchoolId"]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";

                        }
                        break;

                    case "Visitor Details":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptvisitorDetails.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        crptReportSource.ReportDocument.SetParameterValue(0, Session["SchoolID"]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";
                        break;

                    case "StudentInformation":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSistudentinformation.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSistudentinformation.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";


                        }

                        break;


                    case "MarkEntryList2":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIMarkListII.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[6] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIMarkListII.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[6] + "'";
                        }
                        break;
                    // For Counselling Reports Added By Priyanka on 9-12-2011 END


                    case "StudentICardInformation":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentICardInformation.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, Session["SchoolID"]);
                            //crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentICardInformation.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, Session["SchoolID"]);
                            //cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                        }

                        break;
                    ///-------------Add By Archana For House List Reporton 31-03--2012 --------------//////////
                    ///
                    case "HouseWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentHouseDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentHouseDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;

                    case "ClasswiseHouseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentHouseClassWiseList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentHouseClassWiseList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;


                    case "ParentOrgDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIparentOrgDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIparentOrgDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }

                        break;
                    //------------------Add by Archana for report Student phone list-----27.04.2012

                    case "StudentphoneList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentphonlist.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentphonlist.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;

                    //////---------END---------------///
                    case "PrintRankWise"://Added By Bhawna On 21-03-2012
                        if (Session["Option"] == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptPrintRankWiseDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptPrintRankWiseDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                        }
                        break;

                    case "PrintAdmDetails"://Added By Bhawna On 21-03-2012
                        if (Session["Option"] == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptprintAdmDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptprintAdmDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);

                        }
                        break;
                    case "PrintAllRegisterd"://Added By Archana   On 14-01-2013
                        if (Session["Option"] == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptAdmPrintAllRegistered.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptAdmPrintAllRegistered.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                        }
                        break;

                    case "PrintTotalPointDetails": //Added By Bhawna On 22-03-2012
                        if (Session["Option"] == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptPrintTotalPointDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[3] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptPrintTotalPointDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[3] + "'";


                        }
                        break;
                    case "PrintPointDetails"://Added By Bhawna On 22-03-2012
                        if (Session["Option"] == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptPrintPointDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[3] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptPrintPointDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[3] + "'";

                        }
                        break;


                    case "AdmSummary":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptPointWiseList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportHeader"].Text = "'" + strStudentList[2] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptPointWiseList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            cr.SetParameterValue(0, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["ReportHeader"].Text = "'" + strStudentList[2] + "'";

                        }
                        break;

                    case "AdmDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/rptAdmnDetail.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportHeader"].Text = "'" + strStudentList[2] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/rptAdmnDetail.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            cr.SetParameterValue(0, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["ReportHeader"].Text = "'" + strStudentList[2] + "'";

                        }
                        break;

                    case "AdmComplete":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/rptAllDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, Convert.ToInt32(strStudentList[1]));
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[0]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportHeader"].Text = "'" + strStudentList[4] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/rptAllDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[0]);
                            cr.DataDefinition.FormulaFields["ReportHeader"].Text = "'" + strStudentList[4] + "'";

                        }
                        break;



                    case "Acknowldegement"://Modified By Bhawna On 22-03-2012
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/rptAcknoledgeSlip.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[1]);

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/rptAcknoledgeSlip.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            cr.SetParameterValue(0, strStudentList[1]);

                        }
                        break;


                    ///-------------Add By Archana ForStudent SMS Details Reporton 08-05--2012 --------------//////////
                    ///

                    /*---------------Added By Manju on 21-09-2012(For Tutor Wise list)----------------------------*/
                    case "TutorWiseList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSITutorWiseStudentDetail.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSITutorWiseStudentDetail.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;
                    /*---------------End of Added By Manju on 21-09-2012(For Tutor Wise list)----------------------------*/
                    case "UserUpdationDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptUserDetailForParticularModule.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["ReportHeader"].Text = "'" + strStudentList[5] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptUserDetailForParticularModule.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.DataDefinition.FormulaFields["ReportHeader"].Text = "'" + strStudentList[5] + "'";

                        }
                        break;

                    case "StudentSMSDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSMSStudentSummarydts.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSMSStudentSummarydts.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";

                        }
                        break;


                    ////////case "StudentBlankAttendanceRegister":
                    ////////    if (Session["Option"].ToString() == "1")
                    ////////    {
                    ////////        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentBlankAttendanceRegister.rpt";
                    ////////        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                    ////////        //crptReportSource.ReportDocument.VerifyDatabase();
                    ////////        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                    ////////        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[2]);

                    ////////        ////crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[11]);
                    ////////        ////crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                    ////////        ////crptReportSource.ReportDocument.SetParameterValue(11, strStudentList[2]);
                    ////////        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                    ////////    }
                    ////////    else
                    ////////    {
                    ////////        cr.Load(Server.MapPath("StudentReports") + "/crptStudentBlankAttendanceRegister.rpt");
                    ////////        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                    ////////        //cr.VerifyDatabase();
                    ////////        cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                    ////////        cr.SetParameterValue(1, strStudentList[1]);
                    ////////        cr.SetParameterValue(2, strStudentList[2]);
                    ////////        cr.SetParameterValue(3, strStudentList[3]);
                    ////////        cr.SetParameterValue(4, strStudentList[4]);
                    ////////        cr.SetParameterValue(5, strStudentList[5]);
                    ////////        cr.SetParameterValue(6, strStudentList[6]);
                    ////////        cr.SetParameterValue(7, strStudentList[7]);
                    ////////        cr.SetParameterValue(8, strStudentList[8]);
                    ////////        cr.SetParameterValue(9, strStudentList[9]);
                    ////////        cr.SetParameterValue(10, strStudentList[10]);
                    ////////        cr.SetParameterValue(11, strStudentList[2]);
                    ////////        ////cr.SetParameterValue(9, strStudentList[11]);
                    ////////        ////cr.SetParameterValue(10, strStudentList[10]);
                    ////////        ////cr.SetParameterValue(11, strStudentList[2]);
                    ////////        cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";


                    ////////    }

                    ////////    break;

                    ////////case "StudentAttendanceRegister":
                    ////////    if (Session["Option"].ToString() == "1")
                    ////////    {
                    ////////        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentAttendanceRegister.rpt";
                    ////////        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                    ////////        //crptReportSource.ReportDocument.VerifyDatabase();
                    ////////        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                    ////////        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                    ////////        crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[2]);
                    ////////        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";
                    ////////    }
                    ////////    else
                    ////////    {
                    ////////        cr.Load(Server.MapPath("StudentReports") + "/crptStudentAttendanceRegister.rpt");
                    ////////        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                    ////////        //cr.VerifyDatabase();
                    ////////        cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                    ////////        cr.SetParameterValue(1, strStudentList[1]);
                    ////////        cr.SetParameterValue(2, strStudentList[2]);
                    ////////        cr.SetParameterValue(3, strStudentList[3]);
                    ////////        cr.SetParameterValue(4, strStudentList[4]);
                    ////////        cr.SetParameterValue(5, strStudentList[5]);
                    ////////        cr.SetParameterValue(6, strStudentList[6]);
                    ////////        cr.SetParameterValue(7, strStudentList[7]);
                    ////////        cr.SetParameterValue(8, strStudentList[8]);
                    ////////        cr.SetParameterValue(9, strStudentList[2]);
                    ////////        cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";


                    ////////    }

                    ////////    break;

                    case "StudentAttendanceRegister":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentAttendanceRegister.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[2]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptStudentAttendanceRegister.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[2]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[9] + "'";

                        }
                        break;
                    //-------------------------------------HIMANSHU ON 22.10.2012
                    case "MailingLabels":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIMailingLabels.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            //crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIMailingLabels.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            //cr.SetParameterValue(6, strStudentList[3]);

                        }
                        break;
                    /*------------------------------- Added by poonam on 18.10.2012 --------------*/

                    case "ConductandCharacterCertificate":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSIConductCharacterCertificate.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.SetParameterValue(0, strStudentList[3]);
                        cr.DataDefinition.FormulaFields["Character"].Text = "'" + strStudentList[1] + "'";
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                        cr.DataDefinition.FormulaFields["SLNo"].Text = "'" + strStudentList[4] + "'";
                        Session["Option"] = "";
                        break;
                    /*-------------------------------End of Added by poonam on 18.10.2012 --------------*/
                    case "StudentICardDetails":
                        if (Session["Option"].ToString() == "1")
                        {

                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentIDCard.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        }

                        else
                        {

                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentIDCard.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];

                        }
                        break;

                    case "StudentInformationFormIDCard":
                        if (Session["Option"].ToString() == "1")
                        {

                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentIDCardNew.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            //crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[1]));
                        }

                        else
                        {

                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentIDCardNew.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[1]));

                        }
                        break;

                    case "crptAddressProof":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSIAddressProofCertificate.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.SetParameterValue(0, strStudentList[1]);
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                        Session["Option"] = "";
                        break;

                    case "crptNOC":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSINOCCertificate.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.SetParameterValue(0, strStudentList[1]);
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                        cr.DataDefinition.FormulaFields["Sports"].Text = "'" + strStudentList[3] + "'";
                        cr.DataDefinition.FormulaFields["Sportsplace"].Text = "'" + strStudentList[4] + "'";
                        cr.DataDefinition.FormulaFields["FromDate"].Text = "'" + strStudentList[5] + "'";
                        cr.DataDefinition.FormulaFields["Todate"].Text = "'" + strStudentList[6] + "'";
                        Session["Option"] = "";
                        break;


                    case "StopWiseStudentStrength":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptstopwisestudentstrength.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                        crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                        crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[2]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                        break;

                    case "ClassWise/RouteWise Summary":
                        crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/CrptClasswiseRoutewiseSummary.rpt";
                        crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //crptReportSource.ReportDocument.VerifyDatabase();
                        crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                        crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                        crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                        crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[0]);
                        crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[3] + "'";
                        break;

                    case "crptVisaProof":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSIVisaProofCertificate.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.SetParameterValue(0, strStudentList[1]);
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                        cr.DataDefinition.FormulaFields["FromDate"].Text = "'" + strStudentList[3] + "'";
                        cr.DataDefinition.FormulaFields["Todate"].Text = "'" + strStudentList[4] + "'";
                        Session["Option"] = "";
                        break;
                    //**************Added By Archana Start 29-10-2012 *************************************//
                    /*----------------------- Added By Poonam on 29.10.2012 ----------------------------*/
                    case "AdharIcard":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSIAdharCertificate.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.SetParameterValue(0, strStudentList[2]);
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[1] + "'";
                        Session["Option"] = "";
                        break;
                    /*-----------------------End of Added By Poonam on 29.10.2012 ----------------------------*/
                    /*----------------------- Added By Poonam on 17.11.2012  ----------------------------*/

                    case "BonafideCertificateOnly":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSIBonafideCertificateOnly.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.SetParameterValue(0, strStudentList[2]);
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[1] + "'";
                        cr.DataDefinition.FormulaFields["Character"].Text = "'" + strStudentList[3] + "'";
                        Session["Option"] = "";
                        break;
                    /*-----------------------End of Added By Poonam on 17.11.2012  ----------------------------*/
                    case "CasteCertificate":
                        cr.Load(Server.MapPath("StudentReports") + "/crptSICasteCertificate.rpt");
                        cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                        //cr.VerifyDatabase();
                        cr.DataDefinition.RecordSelectionFormula = strStudentList[0];
                        cr.SetParameterValue(0, strStudentList[1]);
                        cr.DataDefinition.FormulaFields["Date"].Text = "'" + strStudentList[2] + "'";
                        Session["Option"] = "";
                        break;

                    case "StudentOnlineLoginDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRStudentOnlineLoginDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                            crptReportSource.ReportDocument.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        }
                        else
                        {

                            cr.Load(Server.MapPath("StudentReports") + "/crptSRStudentOnlineLoginDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[10]);
                            cr.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";

                        }
                        break;

                    case "AllRegisteredStudent1":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRAllRegisteredStudent1.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            // crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(10, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                        }
                        else
                        {

                            cr.Load(Server.MapPath("StudentReports") + "/crptSRAllRegisteredStudent1.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            // crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[1]);
                            cr.SetParameterValue(10, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";

                        }
                        break;

                    case "SelectionWiseDetails1":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRSelectionWiseDetails1.rpt";//
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRSelectionWiseDetails1.rpt");//
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";

                        }
                        break;
                    case "ClassWiseSummary1":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRClassWiseSummary1.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[1]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSRClassWiseSummary1.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[1]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[10] + "'";


                        }
                        break;

                    case "StudentInformationUpdation":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIUpdationDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, Convert.ToInt32(strStudentList[5]));
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[5]);

                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIUpdationDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, Convert.ToInt32(strStudentList[5]));
                            cr.SetParameterValue(4, strStudentList[6]);
                            cr.SetParameterValue(5, strStudentList[7]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.SetParameterValue(7, strStudentList[4]);
                            cr.SetParameterValue(8, strStudentList[9]);
                            cr.SetParameterValue(9, strStudentList[5]);

                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;


                    case "Alumini List":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptStudentInfAlumini.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.DataDefinition.RecordSelectionFormula = strStudentList[0];
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";


                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptStudentInfAlumini.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[1] + "'";

                        }
                        break;

                    //****************************Added By Archana For Proposed Details of Visit 20-03-2013 Start *******************//
                    case "ProposedDateDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRProposedDateDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, strStudentList[8]);
                            crptReportSource.ReportDocument.SetParameterValue(9, strStudentList[9]);
                            crptReportSource.ReportDocument.SetParameterValue(10, strStudentList[10]);
                            crptReportSource.ReportDocument.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";
                        }
                        else
                        {

                            cr.Load(Server.MapPath("StudentReports") + "/crptSRProposedDateDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, strStudentList[8]);
                            cr.SetParameterValue(9, strStudentList[9]);
                            cr.SetParameterValue(10, strStudentList[10]);
                            cr.SetParameterValue(11, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[11] + "'";

                        }
                        break;



                    case "OnlineRegUpdationDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSRUpdationDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[7]);
                            crptReportSource.ReportDocument.SetParameterValue(8, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {

                            cr.Load(Server.MapPath("StudentReports") + "/crptSRUpdationDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[7]);
                            cr.SetParameterValue(8, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[8] + "'";

                        }
                        break;
                    //****************************Added By Archana For Proposed Details of Visit END 20-03-2013*******************//


                    //***************Added By Archana Start(26-03-2013)****************************//

                    case "DisabilitiesSpecialNeed":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentWithDSNeedsDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, strStudentList[0]);
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, Convert.ToInt32(Session["SchoolID"]));
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["Usercaption"].Text = "'" + strStudentList[6] + "'";

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentWithDSNeedsDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, strStudentList[0]);
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, Convert.ToInt32(Session["SchoolID"]));
                            cr.DataDefinition.FormulaFields["Usercaption"].Text = "'" + strStudentList[6] + "'";

                        }
                        break;
                    //***************Added By Archana END(26-03-2013)****************************//

                    case "FreeShipList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudenFreeShiptList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudenFreeShiptList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;



                    case "StudentsPersonalDiary":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentsPersonalDiary.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentsPersonalDiary.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[7] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[8] + "'";
                        }
                        break;

                    case "StudentAdmissionRegister":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIAdmissionRegister.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIAdmissionRegister.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;

                    case "MarkEntryListWIthHouse":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIMarkEntrywithHouseList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[6] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIMarkEntrywithHouseList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                            cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[6] + "'";
                        }
                        break;

                    case "crptSIStudentGGNNoList":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIStudentGGNNoList.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[3]);
                            crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                           
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIStudentGGNNoList.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[3]);
                            cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[5] + "'";
                            
                        }
                        break;

                    case "TCClearanceForm":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIClearanceTC.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[3]);

                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIClearanceTC.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[3]);

                        }
                        break;

                    case "StudentParentOrganizationDetails":
                        if (Session["Option"].ToString() == "1")
                        {
                            crptReportSource.ReportDocument.FileName = Server.MapPath("StudentReports") + "/crptSIParentOrganizationDetails.rpt";
                            crptReportSource.ReportDocument.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //crptReportSource.ReportDocument.VerifyDatabase();
                            crptReportSource.ReportDocument.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            crptReportSource.ReportDocument.SetParameterValue(1, strStudentList[1]);
                            crptReportSource.ReportDocument.SetParameterValue(2, strStudentList[2]);
                            crptReportSource.ReportDocument.SetParameterValue(3, strStudentList[3]);
                            crptReportSource.ReportDocument.SetParameterValue(4, strStudentList[4]);
                            crptReportSource.ReportDocument.SetParameterValue(5, strStudentList[5]);
                            crptReportSource.ReportDocument.SetParameterValue(6, strStudentList[6]);
                            crptReportSource.ReportDocument.SetParameterValue(7, strStudentList[3]);
                            // crptReportSource.ReportDocument.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            // crptReportSource.ReportDocument.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        else
                        {
                            cr.Load(Server.MapPath("StudentReports") + "/crptSIParentOrganizationDetails.rpt");
                            cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUID, strPWD);
                            //cr.VerifyDatabase();
                            cr.SetParameterValue(0, Convert.ToInt32(strStudentList[0]));
                            cr.SetParameterValue(1, strStudentList[1]);
                            cr.SetParameterValue(2, strStudentList[2]);
                            cr.SetParameterValue(3, strStudentList[3]);
                            cr.SetParameterValue(4, strStudentList[4]);
                            cr.SetParameterValue(5, strStudentList[5]);
                            cr.SetParameterValue(6, strStudentList[6]);
                            cr.SetParameterValue(7, strStudentList[3]);
                            // cr.DataDefinition.FormulaFields["UserCaption"].Text = "'" + strStudentList[6] + "'";
                            // cr.DataDefinition.FormulaFields["AdmNo"].Text = "'" + strStudentList[7] + "'";
                        }
                        break;


                    default:

                        break;

                }
                if (Session["Option"] == "1")
                {
                    crptReportView.ReportSourceID = crptReportSource.ID;
                    crptReportView.EnableToolTips = true;
                    crptReportView.HasCrystalLogo = false;
                    crptReportView.HasExportButton = true;
                    crptReportView.DisplayGroupTree = false;
                    crptReportView.EnableDrillDown = false;
                    crptReportView.HasToggleGroupTreeButton = false;
                }
                else if (Session["Option"] == "2")
                {

                    if (Session["Orienation"] == "1")
                    {
                        cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    }
                    else
                    {
                        cr.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    }
                    //cr.PrintOptions.PaperSize = PaperSize.PaperLegal;
                    if (Session["PaperSize"] == "1")
                    {
                        cr.PrintOptions.PaperSize = PaperSize.PaperA4;
                    }
                    if (Session["PaperSize"] == "2")
                    {
                        cr.PrintOptions.PaperSize = PaperSize.PaperA3;
                    }
                    if (Session["PaperSize"] == "3")
                    {
                        cr.PrintOptions.PaperSize = PaperSize.PaperLegal;
                    }
                    cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "RefExport");
                    cr.Close();
                    cr.Dispose();
                }
                else
                {
                    //crptReportView.ReportSourceID = crptReportSource.ID;
                    //crptReportView.EnableToolTips = true;
                    //crptReportView.HasCrystalLogo = false;
                    //crptReportView.HasExportButton = true;
                    //crptReportView.DisplayGroupTree = false;
                    //crptReportView.EnableDrillDown = false;
                    //crptReportView.HasToggleGroupTreeButton = false;
                    crptReportView.ReportSourceID = crptReportSource.ID;
                    crptReportView.EnableToolTips = true;
                    crptReportView.HasCrystalLogo = false;
                    crptReportView.HasExportButton = true;
                    crptReportView.DisplayGroupTree = false;
                    crptReportView.EnableDrillDown = false;
                    crptReportView.HasToggleGroupTreeButton = false;
                    cr.PrintOptions.PaperSize = PaperSize.PaperA4;
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "RefExport");
                    cr.Close();
                    cr.Dispose();
                }

            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }

           finally
           {
               cr.Close();
               cr.Dispose();
           }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {

          try
        {
        strCheck = Session["Check"].ToString();
        switch (strCheck)
        {
            case "StudentList":
            case "ListOfAClass":
            case "ListOfAClassAndSection":
            case "AdmissionRegister":
            case "NewAdmissionList":
            case "MarkEntryList":
            case "BoardingCategoryList":
            case "ClassEmailList":
            case "MailingAddressList":
            case "ResidenceAddressList":
            case "FatherMobileEmailList":
            case "MotherMobileEmailList":
            case "HobbiesCareerGoals":
            case "GenderWiseList":
            case "NationalityWiseList":
            case "CategoryWiseList":
            case "ReligionWiseList":
            case "CasteWiseList":
            case "ActivityWiseList":
            case "BoardWiseList":
            case "BirthDayWiseList":
            case "EmergencyContact":
            case "FeeGroupList":
            case "Student Summary":
            case "ParentIDWiseStudentList":
            case "StudentTCDetails":
            case "StudentDropoutList":
            case "SerialLetter":
            case "StudentIqamaDetails":
            case "StudentPassportDetails":
            case "StudentIqamaExpiryDetails":
            case "StudentPassportExpiryDetails":
            case "StudentIqaDetails":
            case "GroupSectionWiseDeatils":
            case "StudentEnrollmentDetails":
            case "StudentGroupWiseDetails":
            case "StudentDocumentSubmissionDetails":
            case "SMSDetails":
            case "AdmissionStatusList":
            case "StudentSibilingDetails":
            case "CONTACTAddressList":
            case "StudentInformation":
            case "MarkEntryList2":

            case "UserUpdationDetails":
            case "OnlineStudentOffice365":
            case "StudentParentlogininfo":
            case "StudentParentOrganizationDetails":
            
            case "StudentICardInformation":
            case "HouseWiseList":
            case "ClasswiseHouseList":
            case "ParentOrgDetails":
            case "StudentphoneList":
            case "StudentSMSDetails":
            case "MailingLabels":
            case "StudentICardDetails":
            case "DisabilitiesSpecialNeed":
            case "FreeShipList":
            case "StudentsPersonalDiary":
            case "StudentAdmissionRegister":
            case "MarkEntryListWIthHouse":
            case "TCClearanceForm":
            case "crptSIStudentGGNNoList":
                Response.Redirect("SIStudentListWizard.aspx");
                break;
            case "TutorWiseList":
                Response.Redirect("SIStudentListWizard.aspx");
                break;
            case "Alumini List":
                Response.Redirect("SIStudentListWizard.aspx");
                break;
            case "PromotionList":
            case "PromotionSummary":
                Response.Redirect("SIStudentPromotionList.aspx");
                break;
            case "DateOfBirth":
            case "CharacterCertificate":
            case "BonafideCertificate":
          //  case "BonafideCertificateForeign":
           // case "CharacterCertificateXII":
            case "crptAddressProof":
            case "crptNOC":
            case "crptVisaProof":
            case "AdharIcard":
            case "BonafideCertificateOnly":
            case "CasteCertificate":
                Response.Redirect("SICertificateWizard.aspx");
                break;
            case "TransferCertificate":
            case "NoDuesCertificate":
                Response.Redirect("SIStudentTransferCertificate.aspx");
                break;
            case "CalendarDetails":
                Response.Redirect("MTCalendar.aspx");
                break;
            case "SchoolOverview":
            case "AllSchoolOverview":
                Response.Redirect("SISchoolOverview.aspx");
                break;
            case "DailyAttendance":
            case "DailyAttendanceWithRemark":
            case "StudentWiseAttendance":
            case "ClassWiseAttendance":
            case "AttendanceRegister":
            case "AttendanceSummary":
            case "DailyAttendance1":
            case "DailyAttendanceWithRemark1":
            case "StudentWiseAttendance1":
            case "ClassWiseAttendance1":
            case "AttendanceRegister1":
            case "AttendanceSummary1":
            case "AttendanceTeacher1":
            case "AttendanceTeacher":
            case "StudentBlankAttendanceRegister":
            case "StudentAttendanceRegister":
                Response.Redirect("SIAttendanceReports.aspx");
                break;
            case "RouteWiseSummary":
            case "RouteWiseDetails":
            case "RouteCapacity":
            case "StudentRouteDetails":
            case "StudentBusAvailingDetails":
            case "RouteWiseCollection":
            case "StudentBusRouteDetails":
            case "RouteWiseList":
                Response.Redirect("TRTransportReports.aspx");
                break;
            case "StudentCounsellingDetails":
            case "StudentFollowUpDetails":
            case "StudentPsychologicalDetails":
            
                Response.Redirect("CMStudentReports.aspx");
                break;
            case "AllRegisteredStudent":
            case "SelectionWiseDetails":
            case "ClassWiseSummary":
            case "StatusWiseDetails":
            case "EnquiryStatusWiseList":
            case "FollowupDetails":
            case "ClassWiseEnquirySummary":
            case "ClassWiseEnquiryDetails":
            case "ToadysFolloupReport":
            //case "MonthWiseAnalysis":
           // case "YearWiseAnalysis":
            case "SourceWiseEnquiryList":
            case "StudentEnquirySummary":
            case "ProposedDateDetails":
            case "OnlineRegUpdationDetails":
            case "StudentIntraction":
            case "ApplicationProcessConversionRations":
                Response.Redirect("SRReports.aspx");
                break;

            case "Visitor Details":
                Response.Redirect("FOMVisitorReport.aspx");
                break;
            //case "AdmissionMarkEntryDetails":
            case "StudentOnlineLoginDetails":
                Response.Redirect("SRReports.aspx");
                break;
            case "Acknowldegement":
            case "AdmSummary":
            case "AdmDetails":
            case "AdmComplete":
                Response.Redirect("SRReports.aspx");
                break;
            case "AllRegisteredStudent1":
            case "SelectionWiseDetails1":
            case "ClassWiseSummary1":
            case "MonthWiseAnalysis":
            case "YearWiseAnalysis":
              case "AdmissionMarkEntryDetails":
                Response.Redirect("SROtherReports.aspx");
                break;
            case "PrintTotalPointDetails":
                Response.Redirect("SRReports.aspx");
                break;
            case "PrintPointDetails":
                Response.Redirect("SRReports.aspx");
                break;
            case "StopWiseStudentStrength":
                Response.Redirect("TRTransportReports.aspx");
                break;
            case "ClassWise/RouteWise Summary":
                Response.Redirect("TRTransportReports.aspx");
                break;
            case "StudentInformationUpdation":
                Response.Redirect("SIStudentListWizard.aspx");
                break;
            case "StudentInformationFormIDCard":
                Response.Redirect("SIStudentListWizard.aspx");
                break;
            default:
                Response.Redirect("MainForm.aspx");
                break;
        }
        if (Session["Check"] != null)
        {
            Session.Remove("Check");
        }
        if (Session["Formula"] != null)
        {
            Session.Remove("Formula");
        }
        }
          finally
          {
              crptReportSource.ReportDocument.Close();
          }
    }
}
