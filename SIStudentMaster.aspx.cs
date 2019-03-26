/*sb
   Project Name            :   CampusCare
   Client                  :   
   Database                :   SQL Server 2000
   Front-End               :   ASP.NET With C#, Java Script, Ajax
   Reporting Tool          :   Crystal Report 11.0
   Team                    :    
   Tables                  :   SIStudentMaster,SIStudentYearWiseDetails
   Procedures              :   
   Page Created            :   Ushas/Sandhya    
   Codes                   :   Ushas/Sandhya
   Testing & Modification  :   Jitender Kumar
   Remarks                 :      
*/
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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

public partial class SIStudentMaster : System.Web.UI.Page
{
	CCWeb objCCWeb = new CCWeb();
	//protected static string strNewOption;
	//protected static string strEditOption;
	//protected static string strDeleteOption;
	protected static string strSearchOption;
	protected static string strAddPhoto;
	protected static string strRemovePhoto;
	protected static string strChangePhoto;
	protected int intSlNo;
	/*=====Added by Manju on 23-04-2012==========*/
	protected static string strCon1 = "";
	protected static string strCon2 = "";
	protected static string strCon3 = "";
	protected static string strCon4 = "";
	protected static string strCon5 = "";
	protected static string strCon6 = "";
	protected static string strCon7 = "";
	protected static string strCon8 = "";
	protected static string strCon9 = "";
	protected static string strCon10 = "";
	protected static string strCon11 = "";
	protected static string strCon12 = "";
	protected static string strCon13 = "";
	protected static string strCon14 = "";
	/*=====End of Added by Manju on 23-04-2012==========*/
	String vardata;
	protected static string strType;
	string strResult;
	//string AuthorizedImage = "";
	protected string strHideID = "document.getElementById('trName').style.display='none';document.getElementById('divToolTip').style.display='none';document.getElementById('tbImageCaption').style.display='none';";
	protected string strfindShowID = //" window.parent.document.getElementById('leftTD').style.width = '1%'; " +
		//" window.parent.document.getElementById('rightTD').style.width = '99%'; " +     
									  " document.getElementById('divFind').style.left='5px'; " +
									  " document.getElementById('divFind').style.top='12px'; " +
									  " document.getElementById('divFind').style.display='block'; " +
									  " document.getElementById('divFind').style.position='absolute'; " +
									  " document.getElementById('divMain').align='center';";
	protected string strDisableOnAdvSrch = "pLockControls('frmStudentmaster');" +
											"document.getElementById('trSearch').style.display='none';" +
											"document.getElementById('tblButton').style.display='none';" +
											"document.getElementById('tdOption').style.display='none';" +
											"document.getElementById('AddPhoto').style.display='none';" +
											"document.getElementById('RemovePhoto').style.display='none';" +
											"document.getElementById('imgbtnAddress').disabled=true;" +
											"document.getElementById('txtAdmNo').disabled=true;" +
											"var offset=(navigator.userAgent.indexOf('Mac')!=-1 || navigator.userAgent.indexOf('Gecko')!=-1 || navigator.userAgent.indexOf('Netscape')!=-1)?0:4;" +
											"window.moveTo(200,70);" +
											"window.resizeTo(785,700);";
	//"return false;"; 
	protected string strPresCity = "if(document.getElementById('hdnFlagPresCity.Value') =='R'){" +
								   "document.getElementById('btnNew').disabled=true;" +
								   "document.getElementById('btnEdit').disabled=true;" +
								   "document.getElementById('btnSave').disabled=false;" +
								   "document.getElementById('btnDropOut').disabled=true;" +
								   "document.getElementById('btnDetails').disabled=true;" +
								   "document.getElementById('btnTC').disabled=true;" +
								   "document.getElementById('btnRemarks').disabled=true;" +
								   "document.getElementById('btnCancel').disabled=false;" +
								   "document.getElementById('btnClose').disabled=false;}";


	protected void Page_Load(object sender, EventArgs e)
	{
		ClientScript.RegisterStartupScript(this.GetType(), "dispScript", "<script>" + strHideID + "</script>");
		//Session["Type"] = "1";
		Response.Cache.SetCacheability(HttpCacheability.NoCache);
		Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
		Response.Cache.SetNoStore();
		Response.AddHeader("Cache-control", "no-store,must-revalidate,private,no-cache,no-store,pre-check=0,post-check=0,max-stale=0");
		Response.AddHeader("Pragma", "no-cache");
		Response.AddHeader("Expires", "0");

		if (Session["UID"] == null || Session["SchoolID"] == null)
		{
			Response.Write("<script>window.close();window.open('Logon.aspx','_Parent');</script>");
			return;
		}
		if ((objCCWeb.ReturnNumericValue("SELECT Count(*) FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=3 AND MenuName='mnuStudent'") == 0) || (objCCWeb.ReturnSingleValue("SELECT ISNULL(VisibleOption,'N') FROM MTUserLimitMaster WHERE UID=" + Session["UID"] + " AND ModuleID=3 AND MenuName='mnuStudent'") == "N"))
		{
			Session.Clear();
			Response.Redirect("Logon.aspx");
			return;
		}
		if (objCCWeb.pCheckText(frmStudentmaster) == true)
		{
			Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
			return;
		}
		if ((Session["Type"] == null) || (Session["Type"].ToString() == "1"))
		{
			strType = "ltr";
			Session["Type"] = "1";
		}
		else
		{
			strType = "rtl";
			pnlLanguageKnown.HorizontalAlign = HorizontalAlign.Right;
		}

		if (Request["TypeID"] != null)
		{
			if (Request["TypeID"] == "txtStuSelect")
			{
				strResult = pGetStudentDetails(Convert.ToInt32(Request["StudentID"]));
			}
			else if (Request["TypeID"] == "txtAdmNo")
			{
				strResult = pGetStudentDetails(objCCWeb.ReturnNumericValue("SELECT SM.StudentID FROM SIStudentMaster SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID  " +
			 " AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " WHERE AdmissionNo='" + Request["StudentID"].Replace("'", "''") + "'"));
			}
			else if (Request["TypeID"] == "txtFeeNo")
			{
				strResult = pGetStudentDetails(objCCWeb.ReturnNumericValue("SELECT SM.StudentID FROM SIStudentMaster SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID  " +
			 " AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " WHERE FeeNo='" + Request["StudentID"].Replace("'", "''") + "'"));
			}
			else if (Request["TypeID"] == "txtAdmNo")
			{
				strResult = pGetStudentDetails(objCCWeb.ReturnNumericValue("SELECT SM.StudentID FROM SIStudentMaster SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID  " +
			 " AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " WHERE AdmissionNo='" + Request["StudentID"].Replace("'", "''") + "'"));
			}
			else if (Request["TypeID"] == "txtResiCity")
			{
				strResult = pGetCityDetails(Convert.ToInt32(Request["CityID"]), "txtResiCity");
			}
			else if (Request["TypeID"] == "txtPerCity")
			{
				strResult = pGetCityDetails(Convert.ToInt32(Request["CityID"]), "txtPerCity");
			}
			else if (Request["TypeID"] == "txtDisplayStud")
			{
				strResult = pGetStudentDetails(objCCWeb.ReturnNumericValue("SELECT Top 1 SM.StudentID FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID  " +
					" WHERE ParentID='" + Request["ParentID"].Replace("'", "''") + "'  AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " Order by SM.StudentId ASC"));
			}
			else if (Request["TypeID"] == "txtParentID")
			{
				strResult = pGetSiblingDetails(Convert.ToInt32(Request["ParentID"]));
			}
			//    strResult= pGetStudentDetails(Convert.ToInt32(Request["StudentID"]));

			Response.Clear();
			Response.ContentType = "text/xml";
			Response.Write(strResult);
			Response.End();
		}
		/*====================================Added By Manju on 24-04-2012================================*/
		if (Request.QueryString["A"] != null)
		{
			string[] strID = Request.QueryString["A"].Split('^');
			string strResult = "";
			string Result = "";
			string strAdmResult = "";
			string strFeeResult = "";
			string strRollResult = "";
			string strChangeAdmID = "";
			string strResiCityCount = "";





			if (strID[0] == "ValEditConcession")
			{

				if (strID[1] == "FeeConcession")
				{
					strChangeAdmID = objCCWeb.ReturnSingleValue("select Count(*) from FeeAccountMaster FD " +
				   "  INNER JOIN SIStudentYearWIseDetails SYD ON FD.StudentID= SYD.StudentID" +
				   "  INNER JOIN FeeGroupMaster FGM ON FD.FeeGroupID=FGM.FeeGroupID And FGM.AcaStart=SYD.AcaStart" +
				   "  where FD.Studentid=" + strID[2] + "  and SYD.SchoolId=" + Session["SchoolID"] + " " +
				   "  and SYD.AcaStart=" + Session["AcaStart"] + "");
				}
				Result = "ChangePageNext" + "^" + strChangeAdmID;
				Response.Clear();
				Response.ContentType = "text/xml";
				Response.Write(Result);
				Response.End();
			}
			if (strID[0] == "ChangePageNext")
			{

				if (strID[1] == "AdmNo")
				{
					strChangeAdmID = objCCWeb.ReturnSingleValue("SELECT COUNT(*) FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + " AND  YD.AcaStart=" + Session["AcaStart"] + "" +
					" AND   ISNULL(AdmissionNo,'')= '" + strID[2] + "'");
				}
				Result = "ChangePageNext" + "^" + strChangeAdmID;
				Response.Clear();
				Response.ContentType = "text/xml";
				Response.Write(Result);
				Response.End();
			}
			if (strID[0] == "ValResiCity")
			{

				if (strID[1] == "ResiCity")
				{
					strResiCityCount = objCCWeb.ReturnSingleValue("SELECT COUNT(*) FROM MTCitymaster where CityName" + Session["Type"] + "  LIKE '" + strID[2] + "%'");
				}

				Result = "ValOnSave" + "^" + strResiCityCount;
				Response.Clear();
				Response.ContentType = "text/xml";
				Response.Write(Result);
				Response.End();
			}
			if (strID[0] == "ValPerCity")
			{

				if (strID[1] == "PerCity")
				{
					strResiCityCount = objCCWeb.ReturnSingleValue("SELECT COUNT(*) FROM MTCitymaster where CityName" + Session["Type"] + "  LIKE '" + strID[2] + "%'");
				}

				Result = "ValOnSave" + "^" + strResiCityCount;
				Response.Clear();
				Response.ContentType = "text/xml";
				Response.Write(Result);
				Response.End();
			}

		}


		//*=========Binding of Feegroup==================*/
		if (Request.QueryString["FeeGroupID"] != null)
		{
			string[] strID = Request.QueryString["FeeGroupID"].Split('~');
			string Result = "";
			string strClassStrength = "";
			string strSchoolStrength = "";
			string FinalResult = "";
			strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
		  " where StudentStatus='S' and SYD.ClassID='" + strID[0] + "' and SYD.SectionID='" + strID[2] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

			strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
			" where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

			SqlDataReader rdrVal;

			rdrVal = objCCWeb.BindReader("SELECT GM.FeeGroupID,FeeGroupName" + Session["Type"] + "+'~' FROM  " +
								" FEEGroupMaster GM INNER JOIN FEEGroupDetail GD ON GM.FeeGroupID=GD.FeeGroupID   " +
								" WHERE GD.ClassID IN (SELECT  ClassID FROM MTClassMaster WHERE ClassID=" + strID[0] + ") " +
								" AND GD.SectionId IN (Select SectionId FROM MTSectionMaster WHERe SECTIONID=" + strID[2] + " )  " +
								" AND SchoolID=" + Session["SchoolID"] + "ANd Acastart=" + Session["AcaStart"] + "   AND  GM.FeeGroupID<>0" +
								" ORDER BY FeeGroupName" + Session["Type"] + "");





			while (rdrVal.Read())
			{
				Result += rdrVal.GetValue(0).ToString() + "^" + rdrVal.GetValue(1).ToString();

			}
			//if (strClassStrength != "0")
			//{

			FinalResult = Result + "@" + strClassStrength + "@" + strSchoolStrength;
			//}

			rdrVal.Close();
			rdrVal.Dispose();
			Response.Clear();
			Response.ContentType = "text/xml";
			Response.Write(FinalResult);
			Response.End();
		}
		//*=========Binding of FeeApplicableFrom==================*/
		if (Request.QueryString["FeeGrpLenEq1"] != null)
		{
			string[] strID = Request.QueryString["FeeGrpLenEq1"].Split('~');
			string Result = "";
			SqlDataReader rdrVal;


			rdrVal = objCCWeb.BindReader("SELECT FeeInstallmentID,FeeInstallmentName" + Session["Type"] + "+'~' FROM  FEEInstallmentMaster WHERE FeeInstallmentID IN " +
								 " (SELECT FeeInstallmentID FROM  FEEStructureUserDetail SD  JOIN FEEStructureUserMaster SM ON SM.StrID=SD.StrID WHERE  FeeGroupId=" + strID[0] + ") " +
								 " AND SchoolID=" + Session["SchoolID"] + "ORDER BY PriorityNo ");
			while (rdrVal.Read())
			{
				Result += rdrVal.GetValue(0).ToString() + "^" + rdrVal.GetValue(1).ToString();
			}

			rdrVal.Close();
			rdrVal.Dispose();
			Response.Clear();
			Response.ContentType = "text/xml";
			Response.Write(Result);
			Response.End();
		}
		if (Request.QueryString["FeeGrpLenEq0"] != null)
		{
			string[] strID = Request.QueryString["FeeGrpLenEq0"].Split('~');
			string Result = "";
			SqlDataReader rdrVal;


            rdrVal = objCCWeb.BindReader("SELECT FeeInstallmentID,FeeInstallmentName" + Session["Type"] + "+'~' FROM  FEEInstallmentMaster where FeeInstallmentID>0 ");
			while (rdrVal.Read())
			{
				Result += rdrVal.GetValue(0).ToString() + "^" + rdrVal.GetValue(1).ToString();
			}
			rdrVal.Close();
			rdrVal.Dispose();
			Response.Clear();
			Response.ContentType = "text/xml";
			Response.Write(Result);
			Response.End();
		}
		if (Request.QueryString["FeeGrpLenGrt0"] != null)
		{
			string[] strID = Request.QueryString["FeeGrpLenGrt0"].Split('~');
			string Result = "";
			SqlDataReader rdrVal;


			rdrVal = objCCWeb.BindReader("SELECT FeeInstallmentID,FeeInstallmentName" + Session["Type"] + "+'~' FROM  FEEInstallmentMaster WHERE FeeInstallmentID IN " +
								 " (SELECT FeeInstallmentID FROM  FEEStructureUserDetail SD  JOIN FEEStructureUserMaster SM ON SM.StrID=SD.StrID WHERE  FeeGroupId=" + strID[0] + ") " +
								 " AND SchoolID=" + Session["SchoolID"] + "ORDER BY PriorityNo ");
			while (rdrVal.Read())
			{
				Result += rdrVal.GetValue(0).ToString() + "^" + rdrVal.GetValue(1).ToString();
			}
			rdrVal.Close();
			rdrVal.Dispose();
			Response.Clear();
			Response.ContentType = "text/xml";
			Response.Write(Result);
			Response.End();
		}
		if (Request.QueryString["FeeApplGrt0"] != null)
		{
			string[] strID = Request.QueryString["FeeApplGrt0"].Split('~');
			string Result = "";
			SqlDataReader rdrVal;


			rdrVal = objCCWeb.BindReader("SELECT FeeInstallmentID,FeeInstallmentName" + Session["Type"] + "+'~' FROM  FEEInstallmentMaster WHERE FeeInstallmentID IN " +
								 " (SELECT FeeInstallmentID FROM  FEEStructureUserDetail SD  JOIN FEEStructureUserMaster SM ON SM.StrID=SD.StrID WHERE  FeeGroupId=" + strID[0] + ") " +
								 " AND SchoolID=" + Session["SchoolID"] + "ORDER BY PriorityNo ");
			while (rdrVal.Read())
			{
				Result += rdrVal.GetValue(0).ToString() + "^" + rdrVal.GetValue(1).ToString();
			}
			rdrVal.Close();
			rdrVal.Dispose();
			Response.Clear();
			Response.ContentType = "text/xml";
			Response.Write(Result);
			Response.End();
		}
		/*====================For Binding DivSection===================*/
		if (Request.QueryString["FindSectionID"] != null)
		{
			string[] strID = Request.QueryString["FindSectionID"].Split('~');
			string Result = "";
			SqlDataReader rdrVal;



			rdrVal = objCCWeb.BindReader("SELECT SectionID,SectionName" + Session["Type"] + "+'~' FROM MTSectionMAster WHERE SectionID IN " +
					" (SELECT SectionID FROM SIStudentYEarWiseDetails SYD  WHERE SchoolID=" + Session["SchoolID"] + "  AND AcaStart= " + Session["AcaStart"] + " AND ClassID=" + strID[0] + ") ORDER BY SectionName1");

			while (rdrVal.Read())
			{
				Result += rdrVal.GetValue(0).ToString() + "^" + rdrVal.GetValue(1).ToString();
			}
			rdrVal.Close();
			rdrVal.Dispose();
			Response.Clear();
			Response.ContentType = "text/xml";
			Response.Write(Result);
			Response.End();
		}
		/*====================For Binding DivClass===================*/
		if (Request.QueryString["BindFindClass"] != null)
		{
			string[] strID = Request.QueryString["BindFindClass"].Split('~');
			string Result = "";
			SqlDataReader rdrVal;

			rdrVal = objCCWeb.BindReader("Select ClassID,ClassName" + Session["Type"] + "+'~' FROM MTClassMAster WHERE ClassID IN (SELECT ClassID FROM SIStudentYEarWiseDetails SYD  WHERE SchoolID=" + Session["SchoolID"] + "   AND AcaStart=" + Session["AcaStart"] + ")  ORDER BY PriorityNo ");

			while (rdrVal.Read())
			{
				Result += rdrVal.GetValue(0).ToString() + "^" + rdrVal.GetValue(1).ToString();
			}
			rdrVal.Close();
			rdrVal.Dispose();
			Response.Clear();
			Response.ContentType = "text/xml";
			Response.Write(Result);
			Response.End();
		}


		//---------------------------------Added By Archana 07-04-2014 Start --------------------------------//

		if (Request.QueryString["Classwise"] != null)
		{
			string[] strID = Request.QueryString["Classwise"].Split('~');
			string Result = "";
			string strCriteria = "";


			if ((strID[0] != "0") && (strID[0] != ""))
			{
				strCriteria = " AND YD.ClassID=" + strID[0] + " ";

				if (strID.Length > 2)
				{
					if ((strID[2] != "0") && (strID[2] != ""))
					{
						strCriteria += " AND YD.SectionID=" + strID[2] + " ";
					}
				}

				SqlDataReader rdrVal;
				//rdrVal = objCCWeb.BindReader("Select CM.ClassName1+' - '+SM.SectionName1 AS ClassName,COUNT(StudentID) as Total from SIStudentYearWiseDetails YD  INNER JOIN MTClassMaster CM ON CM.ClassID=YD.ClassID INNER JOIN MTSectionMaster SM ON SM.SectionID=YD.SectionID " +
				//        " WHERE YD.AcaStart=" + Session["AcaStart"] + " AND YD.SchoolID=" + Session["SchoolID"] + "  And YD.StudentStatus='S' " + strCriteria + " GROUP BY CM.ClassName1,SM.SectionName1");

				rdrVal = objCCWeb.BindReader("Select SM.SectionName1 AS ClassName,COUNT(StudentID) as Total from SIStudentYearWiseDetails YD  INNER JOIN MTClassMaster CM ON CM.ClassID=YD.ClassID INNER JOIN MTSectionMaster SM ON SM.SectionID=YD.SectionID " +
					 " WHERE YD.AcaStart=" + Session["AcaStart"] + " AND YD.SchoolID=" + Session["SchoolID"] + "  And YD.StudentStatus='S' " + strCriteria + " GROUP BY CM.ClassName1,SM.SectionName1");


				while (rdrVal.Read())
				{
					Result += rdrVal.GetValue(0).ToString() + ":" + rdrVal.GetValue(1).ToString() + '@';
				}

				if (Result != "")
				{
					Result = Result.Remove(Result.Length - 1, 1);
				}

				rdrVal.Close();
				rdrVal.Dispose();
				Response.Clear();
				Response.ContentType = "text/xml";
				Response.Write(Result);
				Response.End();
			}


		}

		//---------------------------------Added By Archana 07-04-2014 END --------------------------------//
		if (!IsPostBack)
		{
			hidCache.Value = "";
			imgPickup.Attributes.Add("onBlur", "javascript:return fpickupClose();");
			imgPickup.Attributes.Add("onError", "javascript:return AssignDocumentsError();");
			txtAdmNo.Attributes.Add("onkeypress", "javascript:return fFillListBox('txtAdmNo',event)");
			txtFeeNo.Attributes.Add("onkeypress", "javascript:return fFillListBox('txtFeeNo',event)");
			txtAdmNo.Attributes.Add("onpaste", "javascript:return false;");
			txtFeeNo.Attributes.Add("onpaste", "javascript:return false;");
			txtStuSelect.Attributes.Add("onkeypress", "javascript:return fBind_Student(event);");
			txtSiblingAdmNo.Attributes.Add("onkeypress", "javascript:return fBindSiblingOnAdm(event,this.value);");

			txtParentID.Attributes.Add("onkeypress", "javascript:return fBind_Parent(event);");
			//txtParentID.Attributes.Add("onfocus", "javascript:return hideLstBox()");

			imgStudent.Attributes.Add("onLoad", "javascript:return AssignPathStudent();");
			imgStudent.Attributes.Add("onError", "javascript:return AssignError();");
			txtRollNo.Attributes.Add("onkeypress", "javascript:return Allow_Integer(event)");
			txtNoOfChild.Attributes.Add("onkeypress", "javascript:return Allow_Integer(event)");
			txtPositionChild.Attributes.Add("onkeypress", "javascript:return Allow_Integer(event)");
			txtChildCode.Attributes.Add("onkeypress", "javascript:return Allow_Integer(event)");
			txtArabicName.Attributes.Add("onkeypress", "Javascript:return Restrict_NameArabic(event);");
			txtPresAddress.Attributes.Add("onkeypress", "Javascript:return Restrict_Multiline(event,150);");
			txtPresAddress.Attributes.Add("onkeyup", "Javascript:return CheckLenOnPaste(event,150);");
			txtPerAddress.Attributes.Add("onkeypress", "Javascript:return Restrict_Multiline(event,150);");
			txtPerAddress.Attributes.Add("onpaste", "Javascript:return CheckLenOnPaste(event,150);");
			txtBoardRegNo.Attributes.Add("onkeypress", "Javascript:return Restrict_Name(event);");
			// txtFeeNo.Attributes.Add("onkeypress", "Javascript:return fFillListBox('txtFee',event)");
			txtFirstName.Attributes.Add("onkeypress", "Javascript:return Restrict_Name(event);");
			txtLastName.Attributes.Add("onkeypress", "Javascript:return Restrict_Name(event);");
			txtMiddleName.Attributes.Add("onkeypress", "Javascript:return Restrict_Name(event);");
			txtPerPhone.Attributes.Add("onkeypress", "Javascript:return Restrict_Phone(event);");
			txtPerPincode.Attributes.Add("onkeypress", "Javascript:return Restrict_Pincode(event);");
			txtPresPhone.Attributes.Add("onkeypress", "Javascript:return Restrict_Phone(event);");
			txtPresPincode.Attributes.Add("onkeypress", "Javascript:return Restrict_Pincode(event);");
			txtSiqmano.Attributes.Add("onkeypress", "Javascript:return Restrict_Name(event);");
			txtStuEmail.Attributes.Add("onkeypress", "Javascript:return Restrict_Email(event);");
			txtStuEmergencyNo.Attributes.Add("onkeypress", "Javascript:return Restrict_Name(event);");
			txtRemarks.Attributes.Add("onkeypress", "Javascript:return Restrict_Multiline(event,250);");
			txtRemarks.Attributes.Add("onkeyup", "Javascript:return CheckLenOnPaste(event,250);");
			txtChildCode.Attributes.Add("onpaste", "javascript:return false;");
			txtRollNo.Attributes.Add("onpaste", "javascript:return false;");
			txtPresPincode.Attributes.Add("onpaste", "javascript:return false;");
			txtPerPincode.Attributes.Add("onpaste", "javascript:return false;");
			txtPresPhone.Attributes.Add("onpaste", "javascript:return false;");
			txtPerPhone.Attributes.Add("onpaste", "javascript:return false;");
			txtResiCity.Attributes.Add("onkeypress", "javascript:return fBind_ResiCity(event);");
			txtPerCity.Attributes.Add("onkeypress", "javascript:return fBind_PerCity(event);");
			txtCBSERollNo.Attributes.Add("onkeypress", "Javascript:return Restrict_Name(event);");
			txtCaste.Attributes.Add("onkeypress", "Javascript:return Restrict_Name(event);");

			txtPerCity.Attributes.Add("AutoComplete", "off");
			txtResiCity.Attributes.Add("AutoComplete", "off");
			gvAuthorisedPickUp.Attributes.Add("autocomplete", "off");
			gvEmergencyContact.Attributes.Add("autocomplete", "off");
			txtParentID.Attributes.Add("AutoComplete", "off");
			txtStuSelect.Attributes.Add("AutoComplete", "off");
			txtResiCity.Attributes.Add("AutoComplete", "off");
			txtPerCity.Attributes.Add("AutoComplete", "off");

			objCCWeb.pRemoveAutoComplete(this);

			AutoCompleteExtender1.CompletionSetCount = Convert.ToInt32(Session["SchoolID"].ToString() + "000" + Session["AcaStart"].ToString());
			AutoCompleteExtender2.CompletionSetCount = Convert.ToInt32(Session["SchoolID"].ToString() + "000" + Session["AcaStart"].ToString());
			AutoCompleteExtender3.CompletionSetCount = Convert.ToInt32(Session["SchoolID"].ToString() + "000" + Session["AcaStart"].ToString());
			AutoCompleteExtender4.CompletionSetCount = Convert.ToInt32(Session["SchoolID"].ToString() + "000" + Session["AcaStart"].ToString());
			AutoCompleteExtender5.CompletionSetCount = Convert.ToInt32(Session["SchoolID"].ToString() + "000" + Session["AcaStart"].ToString());

			gvFindStudent.DataSource = objCCWeb.BindDataSet("EXEC spStuBindBlank 'Blank'");
			gvFindStudent.DataBind();
			pGetOption();
			gvPreviousEducation.Attributes.Add("bordercolor", "#FFC1A4");
			gvSibling.Attributes.Add("bordercolor", "#FFC1A4");
			gvEmergencyContact.Attributes.Add("bordercolor", "#FFC1A4");
			gvAuthorisedPickUp.Attributes.Add("bordercolor", "#FFC1A4");
			gvDocuments.Attributes.Add("bordercolor", "#FFC1A4");
			linkBasic.Enabled = false;
			hdnFlag.Value = "^";
			// imgATD.ImageUrl = "~/Images/1Present.png";
			pBindDDL();
			btnCancel_Click(sender, e);
			if (hdnFlag.Value == "E^")
			{

			}
			if (hdnFlag.Value == "^")
			{
				if (Request.QueryString["StudentBaseID"] != null && Request.QueryString["StudentBaseID"] != "")
				{
					SqlDataReader sqlRdr = objCCWeb.BindReader("SELECT  SM.StudentID, YD.AdmissionNo, " +
					" ISNULL(FirstName,'') +' '+ ISNULL(MiddleName,'') +' '+  ISNULL(LastName,'')  +' # '+  ISNULL(AdmissionNo,'') +' # '+CM.ClassName1+'-'+SIM.Sectionname1 " +
					" FROM SIStudentMaster SM INNER JOIN SIStudentYearwisedetails YD ON SM.StudentID=YD.StudentId   " +
					" INNER JOIN MTClassMaster CM ON CM.ClassID=YD.ClassID " +
					" INNER JOIN MTSectionmaster SIM ON SIM.sectionID=YD.sectionID " +
					" WHERE SM.StudentID=" + Convert.ToInt32(Request["StudentBaseID"]) + "  AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " ");
					if (sqlRdr.Read())
					{
						hdntxtStuSelect.Value = sqlRdr.GetValue(0).ToString();
						txtAdmNo.Text = sqlRdr.GetValue(1).ToString();
						txtStuSelect.Text = sqlRdr.GetValue(2).ToString();
						btnDisplay_Click(sender, e);
						return;
					}
					sqlRdr.Close();
					sqlRdr.Dispose();
				}
				else
				{
					hdnFlag.Value = "^^";
				}
			}
			//btnCancel_Click(sender, e);
			ClientScript.RegisterStartupScript(this.GetType(), "dispScript", "<script>" + strHideID + "</script>");
		}

		if (Request["Check"] == "ADVSearch")//Advance Searching option
		{
			string StudentID = Request["StudentID"].ToString();
			hdnFlag.Value = "ADVSER";
			string strStudent = objCCWeb.ReturnSingleValue("SELECT SM.FirstName+' '+SM.MiddleName+' '+ SM.LastName+'^'+AdmissionNo From SIStudentYearWiseDetails  SYS INNER JOIN SIStudentMaster SM ON SM.StudentID=SYS.StudentID WHERE SYS.StudentID=" + StudentID + "");
			string[] strDetail = strStudent.Split('^');
			txtAdmNo.Text = strDetail[1].ToString();
			btnDisplay_Click(sender, e);
			ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\" type=\"text/javascript\">" + strDisableOnAdvSrch + "</script>");
		}
	}


	protected void pGetOption()
	{
		try
		{
			SqlDataReader rdrOption = objCCWeb.BindReader("SELECT ISNULL(MAX(NewOption),'N'),ISNULL(MAX(EditOption),'N'),ISNULL(MAX(DeleteOption),'N') FROM MTUserLimitMaster " +
				" WHERE ModuleID=3 AND MenuName='mnuStudent' AND UID=" + Session["UID"] + "");
			if (rdrOption.Read())
			{
				//strNewOption = rdrOption.GetValue(0).ToString();
				//strEditOption = rdrOption.GetValue(1).ToString();
				//strDeleteOption = rdrOption.GetValue(2).ToString();
				hidCache.Value = rdrOption.GetValue(0).ToString() + ";" + rdrOption.GetValue(1).ToString() + ";" + rdrOption.GetValue(2).ToString();
			}
			rdrOption.Close();
			rdrOption.Dispose();
		}
		catch (Exception ex)
		{
			ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>" + strHideID + "alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
		}
	}
	private string pGetStudentDetails(int intStudentID)
	{
		string strResult = "";
		/*==========================Modified By Manju on 02-05-2012============================================================*/
		SqlDataReader sqlRdr = objCCWeb.BindReader("SELECT  SM.StudentID,SM.FirstName,SM.MiddleName,SM.LastName,SM.ArabicName,SM.Sex,   " +
			" CONVERT(VARCHAR,SM.DateOfBirth,103) AS DateOfBirth,CONVERT(VARCHAR,SM.DateOfAdmission,103)AS  DateOfAdmission,ISNULL(SM.ClassAdmited,0) AS ClassAdmited,ISNULL(SM.CategoryID,0) As CategoryID,ISNULL(SM.ReligionID,0) AS ReligionID,ISNULL(SM.CasteID,0) AS CasteID,SM.EmergencyPhoneNo, " +
			" SM.EmailID,ISNULL(SM.BloodGroupID,0) AS BloodGroupID,ISNULL(SM.NationalityID,0) AS NationalityID,ISNULL(SM.MotherTongueID,0) As MotherTongueID,ISNULL(SM.ParentID,0),SM.SIqamaNo,SM.NoofChild,SM.Positionofchild, " +
			" YD.AdmissionNo,ISNULL(YD.FeeNo,0),ISNULL(YD.ClassID,0),ISNULL(YD.SectionID,0),YD.NewAdmission,YD.ClassRollNo,ISNULL(YD.HouseID,0),ISNULL(YD.BoardID,0),YD.BoardRegistrationNo, " +
			" ISNULL(YD.BoardingCategoryID,0),YD.ChildCode,YD.Remark,MA.FlatNo,ISNULL(MA.CityID,0),MA.PinCode,MA.TelephoneNo,RA.FlatNo,ISNULL(RA.CityID,0),RA.PinCode,RA.TelephoneNo ,  " +
			" ISNULL(MCM.CityName" + Session["Type"].ToString() + " ,'') As MCityName,ISNULL(MSM.StateName" + Session["Type"].ToString() + " ,'') AS MStateName,  " +
			" ISNULL(MCT.CountryName" + Session["Type"].ToString() + " ,'') As MCountryName,ISNULL(RCM.CityName" + Session["Type"].ToString() + " ,'') As RCityName, " +
			" ISNULL(RSM.StateName" + Session["Type"].ToString() + " ,'') AS RStateName,   " +
			" ISNULL(RCT.CountryName" + Session["Type"].ToString() + " ,'') As RCountryName,ISNULL(FD.TitleID,0),FD.FatherName,ISNULL(MD.TitleID,0),ISNULL(MD.MotherName,0),ISNULL(YD.FeeGroupID,0),YD.FeeApplicableFrom,YD.StudentStatus, " +
			" ISNULL(Convert(varchar,SIqamaExpiryDate,103),'') As SIqamaExpiryDate,ISNULL(SM.FeeConcessionTypeID,0) AS FeeConcessionTypeID,ISNULL(Meals,0),SchoolBus,ISNULL(SecondLanguage,0),ISNULL(ThirdLanguage,0),  " +
			" SM.StudentLivingWithParents,SM.ProvAdmission,CONVERT(VARCHAR,SM.DateOfJoin,103) As DateOFJoin,ISNULL(SM.EduLiveEmailID,'') AS EduLiveEmailID ,ISNULL(YD.SchoolTransfered,0) as SchoolTransfered,ISNULL(SM.CBSERollNo,'') AS CBSERollNo, ISNULL(YD.Stream,0),ISNULL(YD.TRBusStopID,0) AS BusStopID,ISNULL(SM.Caste,'') AS Caste,ISNULL(SM.FreeShip,'N'),GGNNo " +
			" FROM SIStudentMaster SM INNER JOIN SIStudentYearwisedetails YD ON SM.StudentID=YD.StudentId   " +//ISNULL(LEFT(CONVERT(NVARCHAR,CONVERT(DATETIME,SIqamaExpiryDate,103),131) ,10),'')
			" LEFT JOIN SIStudentMailingAddress MA   ON MA.studentID=SM.StudentID  " +
			" LEFT JOIN SIStudentResidenceAddress  RA ON RA.studentID=SM.StudentID   " +
			" LEFT JOIN MTcityMaster MCM ON MCM.CityID=MA.CityID AND  MCM.CityID<>0   " +
			" LEFT JOIN MTStateMaster MSM ON MSM.StateID=MCM.StateID   " +
			" LEFT JOIN MTCountryMaster MCT ON MCT.CountryID=MSM.CountryID   " +
			" LEFT JOIN MTcityMaster RCM ON RCM.CityID=RA.CityID AND  RCM.CityID<>0   " +
			" LEFT JOIN MTStateMaster RSM ON RSM.StateID=RCM.StateID   " +
			" LEFT JOIN MTCountryMaster RCT ON RCT.CountryID=RSM.CountryID   " +
			" LEFT JOIN SIStudentFatherDetails FD ON FD.studentID=SM.StudentID " +
			" LEFT JOIN SIStudentMotherDetails  MD ON  MD.studentID=SM.StudentID  " +
			" LEFT JOIN TRBusStopMaster BSM ON BSM.TRBusStopID=YD.TRBusStopID" +
			// " LEFT JOIN PRLEmployeeMaster PRM ON YD.HomeAdvisorID = PRM.PRLEmployeeID " +
			" WHERE SM.StudentID=" + intStudentID + " AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " ");
		/*==========================Modified By Manju on 02-05-2012============================================================*/
		if (sqlRdr.Read())
		{
			for (int intForloop = 0; intForloop < sqlRdr.FieldCount; intForloop++)
			{
				strResult = strResult + sqlRdr.GetValue(intForloop).ToString() + "^";
			}
			strResult = strResult.Remove(strResult.Length - 1, 1);
		}

		sqlRdr.Close();
		sqlRdr.Dispose();
		return strResult;

	}

	private string pGetCityDetails(int intCityID, string strCity)
	{
		string strResult = "";
		SqlDataReader sqlRdr = objCCWeb.BindReader("SELECT CM.CityID,CM.CityName" + Session["Type"].ToString() + ",SM.StateName" + Session["Type"].ToString() + ",CT.CountryName" + Session["Type"].ToString() + " FROM MTcityMaster CM INNER JOIN MTStateMaster SM ON SM.StateID=CM.StateID   " +
		   " INNER JOIN MTCountryMaster CT ON CT.CountryID=SM.CountryID  WHERE CityID=" + intCityID + "");

		if (sqlRdr.Read())
		{
			for (int intForloop = 0; intForloop < sqlRdr.FieldCount; intForloop++)
			{
				strResult = strResult + sqlRdr.GetValue(intForloop).ToString() + "^";
			}
			strResult = strResult.Remove(strResult.Length - 1, 1);
		}
		strResult = strResult + "^" + strCity;

		sqlRdr.Close();
		sqlRdr.Dispose();
		return strResult;
	}
	private string pGetSiblingDetails(int intParentID)
	{
		string strResult = "";
		//SqlDataReader sqlRdr = objCCWeb.BindReader(" SELECT TOP 1 SM.StudentID,SM.ReligionID,SM.CasteID,SM.NationalityID,SM.MotherTongueID,  " +
		//    " SM.NoofChild,YD.ChildCode,MA.FlatNo,ISNULL(MA.CityID,0) AS MCity,MA.PinCode,MA.TelephoneNo,RA.FlatNo, " +
		//    " ISNULL(RA.CityID,0) AS RCity,RA.PinCode,RA.TelephoneNo , ISNULL(MCM.CityName" + Session["Type"].ToString() + ",'') As MCityName,ISNULL(MSM.StateName" + Session["Type"].ToString() + " ,'') AS MStateName, " +
		//    " ISNULL(MCT.CountryName" + Session["Type"].ToString() + " ,'') As MCountryName,ISNULL(RCM.CityName" + Session["Type"].ToString() + ",'') As RCityName,ISNULL(RSM.StateName" + Session["Type"].ToString() + ",'') AS RStateName,  " +
		//    " ISNULL(RCT.CountryName" + Session["Type"].ToString() + " ,'') As RCountryName,ISNULL(SM.ParentID,0),YD.AdmissionNo,FD.TitleID,FD.FatherName, MD.TitleID,MD.MotherName,YD.FeeGroupID,YD.FeeApplicableFrom,YD.StudentStatus   FROM SIStudentMaster SM INNER JOIN SIStudentYearwisedetails YD ON  SM.StudentID=YD.StudentId   " +
		//    " LEFT JOIN SIStudentMailingAddress MA  ON MA.studentID=SM.StudentID   " +
		//    " LEFT JOIN SIStudentResidenceAddress  RA ON   RA.studentID=SM.StudentID   " +
		//    " LEFT JOIN MTcityMaster MCM ON MCM.CityID=MA.CityID AND  MCM.CityID<>0  " +
		//    " LEFT JOIN MTStateMaster MSM ON MSM.StateID=MCM.StateID  "+
		//    " LEFT JOIN MTCountryMaster MCT ON MCT.CountryID=MSM.CountryID  "+
		//    " LEFT JOIN MTcityMaster RCM ON RCM.CityID=RA.CityID AND   RCM.CityID<>0  "+
		//    " LEFT JOIN MTStateMaster RSM ON RSM.StateID=RCM.StateID  " +
		//    " LEFT JOIN MTCountryMaster RCT ON RCT.CountryID=RSM.CountryID    " +
		//    " LEFT JOIN SIStudentFatherDetails FD ON FD.studentID=SM.StudentID " +
		//    " LEFT JOIN SIStudentMotherDetails  MD ON  MD.studentID=SM.StudentID  " +
		//    "  WHERE SM.ParentID=" + intParentID + " AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + "  ORDER BY SM.StudentID ASC");


		SqlDataReader sqlRdr = objCCWeb.BindReader(" SELECT TOP 1 SM.StudentID,SM.ReligionID,SM.CasteID,SM.NationalityID,SM.MotherTongueID,  " +
		   " SM.NoofChild,YD.ChildCode,MA.FlatNo,ISNULL(MA.CityID,0) AS MCity,MA.PinCode,MA.TelephoneNo,RA.FlatNo, " +
		   " ISNULL(RA.CityID,0) AS RCity,RA.PinCode,RA.TelephoneNo , ISNULL(MCM.CityName" + Session["Type"].ToString() + ",'') As MCityName,ISNULL(MSM.StateName" + Session["Type"].ToString() + " ,'') AS MStateName, " +
		   " ISNULL(MCT.CountryName" + Session["Type"].ToString() + " ,'') As MCountryName,ISNULL(RCM.CityName" + Session["Type"].ToString() + ",'') As RCityName,ISNULL(RSM.StateName" + Session["Type"].ToString() + ",'') AS RStateName,  " +
		   " ISNULL(RCT.CountryName" + Session["Type"].ToString() + " ,'') As RCountryName,ISNULL(SM.ParentID,0),YD.AdmissionNo,FD.TitleID,FD.FatherName, MD.TitleID,MD.MotherName,YD.FeeGroupID,YD.FeeApplicableFrom,YD.StudentStatus   FROM SIStudentMaster SM INNER JOIN SIStudentYearwisedetails YD ON  SM.StudentID=YD.StudentId   " +
		   " LEFT JOIN SIStudentMailingAddress MA  ON MA.studentID=SM.StudentID   " +
		   " LEFT JOIN SIStudentResidenceAddress  RA ON   RA.studentID=SM.StudentID   " +
		   " LEFT JOIN MTcityMaster MCM ON MCM.CityID=MA.CityID AND  MCM.CityID<>0  " +
		   " LEFT JOIN MTStateMaster MSM ON MSM.StateID=MCM.StateID  " +
		   " LEFT JOIN MTCountryMaster MCT ON MCT.CountryID=MSM.CountryID  " +
		   " LEFT JOIN MTcityMaster RCM ON RCM.CityID=RA.CityID AND   RCM.CityID<>0  " +
		   " LEFT JOIN MTStateMaster RSM ON RSM.StateID=RCM.StateID  " +
		   " LEFT JOIN MTCountryMaster RCT ON RCT.CountryID=RSM.CountryID    " +
		   " LEFT JOIN SIStudentFatherDetails FD ON FD.studentID=SM.StudentID " +
		   " LEFT JOIN SIStudentMotherDetails  MD ON  MD.studentID=SM.StudentID  " +
		   "  WHERE SM.ParentID=" + intParentID + "  AND YD.SchoolId=" + Session["SchoolID"].ToString() + "  ORDER BY SM.StudentID ASC");

		if (sqlRdr.Read())
		{
			for (int intForloop = 0; intForloop < sqlRdr.FieldCount; intForloop++)
			{
				strResult = strResult + sqlRdr.GetValue(intForloop).ToString() + "^";
			}
			strResult = strResult.Remove(strResult.Length - 1, 1);
		}

		sqlRdr.Close();
		sqlRdr.Dispose();
		return strResult;
	}
	private void pFillBlankGrid(int intID)
	{
		gvAuthorisedPickUp.DataSource = objCCWeb.BindDataSet("EXEC spSIFillingGridForEntry 'SIStudentPickupDetails'," + intID + "");
		gvAuthorisedPickUp.DataBind();
		gvEmergencyContact.DataSource = objCCWeb.BindDataSet("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intID + " ");
		gvEmergencyContact.DataBind();
		gvSibling.DataSource = objCCWeb.BindDataSet("EXEC spSIFillingGridForEntry 'SISiblingDetails',0");
		gvSibling.DataBind();
		gvDocuments.DataSource = objCCWeb.BindDataSet("EXEC spStuBindBlank 'Documents'");
		gvDocuments.DataBind();

		//gvPreviousEducation.DataSource = objCCWeb.BindDataSet("EXEC  spSIFillingGridForEntry 'SRStudentPreviousEducationDetails',0");
		//gvPreviousEducation.DataBind();SIStudentPreviousEducationDetails
		/*===================Modified by Manju on 07-05-2012========================================================================*/
		gvPreviousEducation.DataSource = objCCWeb.BindDataSet("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intID + " ");
		gvPreviousEducation.DataBind();
		//gvPreviousEducation.DataSource = objCCWeb.BindDataSet("SELECT 1 AS SNo,'' AS NameOfSchool,'' AS Location,'' AS ClassCompleted,'' AS YearAttended,'' As LanguageOfInstruction,'' AS Result");
		//gvPreviousEducation.DataBind();
		//ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");

		/*===================End of Modified by Manju on 07-05-2012========================================================================*/
		if (Request["Check"] == "ADVSearch")
			gvAuthorisedPickUp.HeaderRow.Cells[gvAuthorisedPickUp.HeaderRow.Cells.Count - 1].Visible = false;
		if (Session["Type"].ToString() == "2")
		{
			if (gvAuthorisedPickUp.Rows.Count > 0)
			{
				for (int intLoop = 0; intLoop < gvAuthorisedPickUp.Rows.Count; intLoop++)
				{
					gvAuthorisedPickUp.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
					gvAuthorisedPickUp.Rows[intLoop].Cells[0].HorizontalAlign = HorizontalAlign.Left;
					gvAuthorisedPickUp.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
					gvAuthorisedPickUp.Rows[intLoop].Cells[1].HorizontalAlign = HorizontalAlign.Right;
					gvAuthorisedPickUp.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
					gvAuthorisedPickUp.Rows[intLoop].Cells[2].HorizontalAlign = HorizontalAlign.Right;
					gvAuthorisedPickUp.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
					gvAuthorisedPickUp.Rows[intLoop].Cells[3].HorizontalAlign = HorizontalAlign.Right;
					gvAuthorisedPickUp.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
					gvAuthorisedPickUp.Rows[intLoop].Cells[4].HorizontalAlign = HorizontalAlign.Right;
				}

			}
			if (gvEmergencyContact.Rows.Count > 0)
			{
				for (int intLoop = 0; intLoop < gvEmergencyContact.Rows.Count; intLoop++)
				{
					gvEmergencyContact.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
					gvEmergencyContact.Rows[intLoop].Cells[0].HorizontalAlign = HorizontalAlign.Left;
					gvEmergencyContact.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
					gvEmergencyContact.Rows[intLoop].Cells[1].HorizontalAlign = HorizontalAlign.Right;
					gvEmergencyContact.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
					gvEmergencyContact.Rows[intLoop].Cells[2].HorizontalAlign = HorizontalAlign.Right;
					gvEmergencyContact.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
					gvEmergencyContact.Rows[intLoop].Cells[3].HorizontalAlign = HorizontalAlign.Right;
					gvEmergencyContact.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
					gvEmergencyContact.Rows[intLoop].Cells[4].HorizontalAlign = HorizontalAlign.Right;
				}
			}
			if (gvSibling.Rows.Count > 0)
			{
				for (int intLoop = 0; intLoop < gvSibling.Rows.Count; intLoop++)
				{
					gvSibling.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
					gvSibling.Rows[intLoop].Cells[0].HorizontalAlign = HorizontalAlign.Left;
					gvSibling.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
					gvSibling.Rows[intLoop].Cells[1].HorizontalAlign = HorizontalAlign.Right;
					gvSibling.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
					gvSibling.Rows[intLoop].Cells[2].HorizontalAlign = HorizontalAlign.Right;
					gvSibling.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
					gvSibling.Rows[intLoop].Cells[3].HorizontalAlign = HorizontalAlign.Right;
				}
			}
		}
	}
	private void pBindDDL()
	{

		/*=======================Modified by Manju on 23-04-2012===================================*/
		DataSet DS = new DataSet();
		DS = objCCWeb.BindDataSet("EXEC spFillCombo " + Session["Type"].ToString() + "," + Session["SchoolID"] + "," + Session["AcaStart"].ToString() + "");
		if (DS.Tables.Count > 0)
		{
			for (int i = 0; i < DS.Tables.Count; i++)
			{
				foreach (Control ctlTemp in frmStudentmaster.Controls)
				{
					if (ctlTemp.GetType() == typeof(DropDownList))
					{
						if (((DropDownList)(ctlTemp)).ID == DS.Tables[i].Columns[0].Caption)
						{
							((DropDownList)(ctlTemp)).DataSource = DS.Tables[i];
							((DropDownList)(ctlTemp)).DataValueField = DS.Tables[i].Columns[0].Caption;
							((DropDownList)(ctlTemp)).DataTextField = DS.Tables[i].Columns[0].Caption + "Name";
							((DropDownList)(ctlTemp)).DataBind();
							break;
						}
					}
				}
			}
		}


	}

	protected void btnNew_Click(object sender, EventArgs e)
	{

		btnCancel_Click(sender, e);

		//lblStudentStatus.Text = "";
		lblLastMDate.Text = "";
		txtAdmNo.Text = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(CAST(AdmissionNo AS Bigint)),0)+1 FROM SIStudentYearWiseDetails WHERE ISNUMERIC(AdmissionNo)=1  AND  " +
						  " SchoolID=" + Session["SchoolID"] + " ");
		if (txtAdmNo.Text.Trim() != "")
		{
			if (objCCWeb.ReturnNumericValue("Select count(*) AS [scount] From SIStudentYearWiseDetails Where AdmissionNo='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' AND SchoolID=" + Session["SchoolID"].ToString() + " AND AcaStart=" + Session["AcaStart"].ToString()) > 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('AdmissionNo already exists for another student');</script>");
				return;
				//throw new Exception("ABCDFASDF");
			}
		}

		txtFeeNo.Text = objCCWeb.ReturnSingleValue("SELECT  MAX(CAST(FeeNo AS Bigint))+1  FROM SIStudentYearWiseDetails WHERE ISNUMERIC(FeeNo)=1  AND  " +   ///ISNULL(MAX(CAST(FeeNo AS Bigint))+1,0)//ISNULL(MAX(CAST(FeeNo AS Bigint)),0)+1
										 "  SchoolID=" + Session["SchoolID"] + " ");
		if (txtFeeNo.Text.Trim() != "")
		{
			if (objCCWeb.ReturnNumericValue("Select count(*) AS [scount] From SIStudentYearWiseDetails Where FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "' AND SchoolID=" + Session["SchoolID"].ToString() + " AND AcaStart=" + Session["AcaStart"].ToString()) > 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Fee No. already exists for another student');</script>");
				return;
				//throw new Exception("ABCDFASDF");
			}
		}

		//txtParentID.Text = objCCWeb.ReturnSingleValue("SELECT MAX(ISNULL(ParentID,0))+1 From SISTudentmaster  WHERE SChoolID=" + Session["SchoolID"] + "");
		//Modifiy by Archana ******************* 05-10-2012 Parent ID Not generated if Blank Table*****************//
		txtParentID.Text = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(ParentID),0)+1 From SISTudentmaster");
		//Modifiy by Archana *******************05-10-2012 Parent ID Not generated if Blank Table*****************//
		hdntxtParentID.Value = txtParentID.Text;
		btnNew.Enabled = false;
		// btnEdit.Enabled = false;
		txtAdmNo.Focus();
		pFillBlankGrid(0);
		hdnFlag.Value = "N^";

	}


	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			int intParentID = 0;
			List<string> lstArray = new List<string>();
			int intstudentID = 0;
			int intPreviousID = 0;
			string StrChkLanguageKnown = "";
			string StrTypeofImpairment = "";
			/*==========Added By Manju on 23-04-2012======*/
			strCon1 = "";
			strCon2 = "";
			strCon3 = "";
			strCon4 = "";
			strCon5 = "";
			strCon6 = "";
			strCon7 = "";
			strCon8 = "";
			strCon9 = "";
			strCon10 = "";
			strCon11 = "";
			strCon12 = "";
			strCon13 = "";
			strCon14 = "";
			/*============End of Added By Manju on 23-04-2012======*/
			string strimagepath = "";
			//int intlength = 0;
			string strIqamadate;
			string strMeal = "";
			strIqamadate = "CONVERT(DATETIME,";
			if (txtSiqmaExpiryDate.Text.Trim() == "")
			{
				strIqamadate += "null";
			}
			else
			{
				strIqamadate += "'" + txtSiqmaExpiryDate.Text.Trim() + "'";
			}
			strIqamadate += ",131)";
			string[] strchkValues;

			if (txtResiCity.Text.Trim() != "")
			{
				hdntxtResiCity.Value = objCCWeb.ReturnSingleValue("SELECT ISNULL(CityID,0) FROM MTCityMaster WHERE UPPER(CityName" + Session["Type"] + ")='" + txtResiCity.Text.Trim().ToUpper().Replace("'", "''") + "'");
			}
			else
			{
				hdntxtResiCity.Value = "0";
			}
			if (txtPerCity.Text.Trim() != "")
			{
				hdntxtPerCity.Value = objCCWeb.ReturnSingleValue("SELECT ISNULL(CityID,0) FROM MTCityMaster WHERE UPPER(CityName" + Session["Type"] + ")='" + txtPerCity.Text.Trim().ToUpper().Replace("'", "''") + "'");
			}
			else
			{
				hdntxtPerCity.Value = "0";
			}
			if (ddlMeal.SelectedValue == "")
			{
				strMeal = "0";
			}
			else
			{
				strMeal = ddlMeal.SelectedValue;
			}
			/*=============Added By Manju on 01-05-2012====================*/
			for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
			{
				if (chkLanguageKnown.Items[inti].Selected == true)
				{
					StrChkLanguageKnown = StrChkLanguageKnown + chkLanguageKnown.Items[inti].Value + ",";
				}
			}
			if (StrChkLanguageKnown.Length > 0)
			{
				StrChkLanguageKnown = StrChkLanguageKnown.Substring(0, StrChkLanguageKnown.Length - 1);
			}



			for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
			{
				if (chkImpairment.Items[inti].Selected == true)
				{
					StrTypeofImpairment = StrTypeofImpairment + chkImpairment.Items[inti].Value + ",";
				}
			}
			if (StrTypeofImpairment.Length > 0)
			{
				StrTypeofImpairment = StrTypeofImpairment.Substring(0, StrTypeofImpairment.Length - 1);
			}

			/*=============End of Added By Manju on 01-05-2012====================*/
			/*--------------------Added By Manju on 01-06-2012------------------------*/

			/*--------------------End of Added By Manju on 01-06-2012------------------------*/

			if (hdnFlag.Value == "N^")
			{
				//if (objCCWeb.ReturnNumericValue("Select Count(AdmissionNo) from SistudentYearwisedetails where AdmissionNo='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' and AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "") >= 1)
				//{
				//    ClientScript.RegisterStartupScript(this.GetType(), "displayScriptMsg", "<script>alert('AdmissionNo. Already Exists')</script>");
				//    return;
				//}
				//if (objCCWeb.ReturnNumericValue("Select Count(FeeNo) from SistudentYearwisedetails where FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "' and AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "") >= 1)
				//{
				//    ClientScript.RegisterStartupScript(this.GetType(), "displayScriptMsg", "<script>alert('FeeNo. Already Exists')</script>");
				//    return;
				//}
				if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + "" +
							 " AND   ISNULL(AdmissionNo,'') ='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' ") > 0)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Admission No. Already Exists')</script>");
					txtAdmNo.Focus();
					return;
				}
				if (txtRollNo.Text.Trim() != "")
				{

					if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + " AND  YD.AcaStart=" + Session["AcaStart"] + "  " +
							 "AND YD.StudentStatus='S' and ClassId=" + ddlClass.SelectedValue + " AND SectionId=" + ddlSection.SelectedValue + " And   ClassRollNo=" + txtRollNo.Text.Trim().Replace("'", "''") + " AND  ClassRollNo>0") > 0)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Roll No. Already Exists')</script>");
						txtRollNo.Focus();
						return;
					}
				}

				if (txtFeeNo.Text.Trim().Replace("'", "''") != "")
				{
					if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + " " +
							 " AND   YD.FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "'") > 0)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Fee No. Already Exists')</script>");
						txtFeeNo.Focus();
						return;
					}
				}

				if (txtResiCity.Text.Trim() != "")
				{
					if (objCCWeb.ReturnSingleValue("Select CityID from MtCityMaster Where CityName1='" + txtResiCity.Text.Trim().Replace("'", "''") + "'") == "")
					{
						ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Please Select Residence City From List')</script>");
						txtResiCity.Focus();
						return;
					}
				}
				if (txtPerCity.Text.Trim() != "")
				{
					if (objCCWeb.ReturnSingleValue("Select CityID from MtCityMaster Where CityName1='" + txtPerCity.Text.Trim().Replace("'", "''") + "'") == "")
					{
						ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Please Select Permanent City From List')</script>");
						txtPerCity.Focus();
						return;
					}
				}
				if (hdntxtParentID.Value == txtParentID.Text)
				{
					if (objCCWeb.ReturnNumericValue("Select Count(ParentID) from SIStudentmaster WHERE ParentID=" + Convert.ToInt32(hdntxtParentID.Value) + "") > 0)
					{
						txtParentID.Text = objCCWeb.ReturnSingleValue("SELECT ISNULL(MAX(ParentID),0)+1 From SISTudentmaster");
					}
					else
					{
						txtParentID.Text = hdntxtParentID.Value;
					}
				}

				intstudentID = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(StudentID),0)+1 FROM SIStudentMaster ");

				strCon1 = "INSERT INTO SIStudentMaster (StudentID,FirstName,MiddleName,LastName,ArabicName,Sex,DateOfBirth,DateOfAdmission,ClassAdmited,CategoryID,ReligionID,CasteID, " +
					" EmergencyPhoneNo,EmailID,BloodGroupID,NationalityID,MotherTongueID,ParentID,SIqamaNo,NoofChild, " +
					" Positionofchild,SchoolID,EntryUserID,EntryDate,SIqamaExpiryDate,FeeConcessionTypeID,Meals,SchoolBus,SecondLanguage,ThirdLanguage,StudentLivingWithParents,ProvAdmission,DateOfJoin,CBSERollNo,Caste,FreeShip) VALUES(" + intstudentID + "," + objCCWeb.fReplaceChar(txtFirstName) + "," + objCCWeb.fReplaceChar(txtMiddleName) + "," +
					" " + objCCWeb.fReplaceChar(txtLastName) + "," + objCCWeb.fReplaceChar(txtArabicName) + ",'" + (rbtnMale.Checked == true ? 'M' : 'F') + "'," + objCCWeb.ReturnDateorNull(txtStuDOB.Text.Trim()) + "," +
					" " + objCCWeb.ReturnDateorNull(txtDOA.Text.Trim()) + "," + ddlAdmittedClass.SelectedValue + "," + ddlSocCategory.SelectedValue + ", " + ddlReligion.SelectedValue + ",  " +
					" 0," + objCCWeb.fReplaceChar(txtStuEmergencyNo) + "," + objCCWeb.fReplaceChar(txtStuEmail) + ",  " +
					" " + ddlBloodGroup.SelectedValue + "," + ddlNationality.SelectedValue + "," + ddlMotherTongue.SelectedValue + "," + (txtParentID.Text.Trim() == "" ? "0" : txtParentID.Text.Trim().Replace("'", "''")) + ", " +
					" " + objCCWeb.fReplaceChar(txtSiqmano) + "," + (txtNoOfChild.Text.Trim() == "" ? "0" : txtNoOfChild.Text.Trim().Replace("'", "''")) + "," + (txtPositionChild.Text.Trim() == "" ? "0" : txtPositionChild.Text.Trim().Replace("'", "''")) + ", " +
					" " + Session["SchoolID"].ToString() + "," + Session["UID"] + ",GETDATE()," + objCCWeb.ReturnDateorNull(txtSiqmaExpiryDate.Text.Trim()) + "," + ddlConcessionType.SelectedValue + "," + strMeal + "  ," +
					" '" + ddlSchoolBus.SelectedValue + "'," + ddlSecondLanguage.SelectedValue + "," + ddlThirdLanguage.SelectedValue + ",'" + ddlStuLiving.SelectedValue + "','" + (rbtProvYes.Checked == true ? 'Y' : 'N') + "'," + objCCWeb.ReturnDateorNull(txtDateOFJoin.Text.Trim()) + "," +
					" " + objCCWeb.fReplaceChar(txtCBSERollNo) + "," + objCCWeb.fReplaceChar(txtCaste) + ",'" + (rbtnFreeShipYes.Checked == true ? 'Y' : 'N') + "')";


				strCon1 = strCon1 + "~INSERT INTO SIStudentYearWiseDetails (YearWiseID,StudentID,AcaStart,AdmissionNo,FeeNo,ClassID,SectionID,FeeGroupID,NewAdmission,FeeApplicableFrom,ClassRollNo, " +
                     " HouseID,BoardID,BoardRegistrationNo,BoardingCategoryID,ChildCode,StudentStatus,Promotion,Remark,SchoolID,EntryUserID,EntryDate,SchoolTransfered,WardenID,HostelID,RoomNo,BedNo,HomeAdvisorID,Stream,TRBusStopID,GGNNo)   " +
					 "  SELECT ISNULL(MAX(YearWiseID),0)+1," + intstudentID + "," + Session["AcaStart"] + "," +
					 " " + objCCWeb.fReplaceChar(txtAdmNo) + "," + objCCWeb.fReplaceChar(txtFeeNo) + "," + ddlClass.SelectedValue + "," +
					 " " + ddlSection.SelectedValue + "," + ddlFeeGroup.SelectedValue + ",'" + (rbtnAdmissionNew.Checked == true ? 'N' : 'O') + "'," + ddlFeeApplnFrom.SelectedValue + "," + (txtRollNo.Text.Trim() == "" ? "0" : txtRollNo.Text.Trim()) + "," + ddlHouse.SelectedValue + "," +
					 " " + ddlBoard.SelectedValue + "," + objCCWeb.fReplaceChar(txtBoardRegNo) + "," + ddlBoardingCategory.SelectedValue + "," +
                     " " + objCCWeb.fReplaceChar(txtChildCode) + ",'S','N'," + objCCWeb.fReplaceChar(txtRemarks) + "," + Session["SchoolID"] + "," + Session["UID"] + ",GETDATE(),'0',0,0,'','',0," + (ddlStream.SelectedValue == "" ? "0" : ddlStream.SelectedValue) + ",0," + objCCWeb.fReplaceChar(txtGGNNo) + " FROM SIStudentYearWiseDetails";

				strCon2 = strCon2 + "~INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuStudent','Student, Name: " + txtFirstName.Text.Trim().Replace("'", "''") + " " + txtMiddleName.Text.Trim().Replace("'", "''") + " " + txtLastName.Text.Trim().Replace("'", "''") + " With Admission No : " + txtAdmNo.Text.Trim().Replace("'", "''") + " & Fee No: " + txtFeeNo.Text.Trim().Replace("'", "''") + " In Class-Sec " + ddlClass.SelectedItem + "-" + ddlSection.SelectedItem + " Is Added In Student Information')";

			}
			else
			{
				string[] strArray = hdnFlag.Value.Split('^');
				/*=============Modified by MAnju on 30-04-2012=================*/
				//intstudentID = Convert.ToInt32(strArray[1]);
				// intstudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE AdmissionNo='" + txtAdmNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
				intstudentID = Convert.ToInt32(hdntxtStuSelect.Value);

				if (hdnSDID.Value != hdntxtStuSelect.Value)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Please select the record again')</script>");
					txtStuSelect.Focus();
					return;
				}
				if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + "" +
							" AND   YD.StudentID<>" + intstudentID + " AND ISNULL(AdmissionNo,'') ='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' ") > 0)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Admission No. Already Exists');pEnableDisable('EDIT');</script>");
					txtAdmNo.Focus();
					return;
				}
				if (txtRollNo.Text.Trim() != "")
				{
                    if (objCCWeb.ReturnSingleValue("Select StudentStatus from sistudentyearwisedetails where StudentID=" + intstudentID + " AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "") == "S")
                    {
                        if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + " AND  YD.AcaStart=" + Session["AcaStart"] + "  " +
                                 " AND YD.StudentStatus='S' and   YD.StudentID<>" + intstudentID + " AND ClassId=" + ddlClass.SelectedValue + " AND SectionId=" + ddlSection.SelectedValue + " And   ClassRollNo=" + txtRollNo.Text.Trim().Replace("'", "''") + " AND  ClassRollNo>0") > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Roll No. Already Exists');pEnableDisable('EDIT');</script>");
                            txtRollNo.Focus();
                            return;
                        }
                    }
				}

				if (txtFeeNo.Text.Trim().Replace("'", "''") != "")
				{
					if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + " " +
							 " AND   YD.StudentID<>" + intstudentID + " AND   YD.FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "'") > 0)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Fee No. Already Exists');pEnableDisable('EDIT');</script>");
						txtFeeNo.Focus();
						return;
					}
				}

				if (txtResiCity.Text.Trim() != "")
				{
					if (objCCWeb.ReturnSingleValue("Select CityID from MtCityMaster Where CityName1='" + txtResiCity.Text.Trim().Replace("'", "''") + "'") == "")
					{
						ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Please Select Residence City From List');pEnableDisable('EDIT');</script>");
						txtResiCity.Focus();
						return;
					}
				}

				if (txtPerCity.Text.Trim() != "")
				{
					if (objCCWeb.ReturnSingleValue("Select CityID from MtCityMaster Where CityName1='" + txtPerCity.Text.Trim().Replace("'", "''") + "'") == "")
					{
						ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Please Select Permanent City From List');pEnableDisable('EDIT');</script>");
						txtPerCity.Focus();
						return;
					}
				}


				//int intFeegrp = objCCWeb.ReturnNumericValue("Select FeegroupID from Sistudentyearwisedetails where StudentID=" + intstudentID + " and ACastart=" + Session["AcaStart"] + " and SchoolID=" + Session["SchoolID"] + "");

				if (objCCWeb.ReturnNumericValue("select Count(*) from FeeAccountMaster FD INNER JOIN Sistudentyearwisedetails SYD ON SYD.StudentID=FD.StudentID " +
						 " INNER JOIN FeeGroupMaster FGM ON FD.FeeGroupID=FGM.FeeGroupID And FGM.AcaStart=SYD.AcaStart" +
						 " where FD.StudentID=" + intstudentID + " and SYD.ACastart=" + Session["AcaStart"] + " and SYD.SchoolID=" + Session["SchoolID"] + "") > 0)
				{
					int intFeegrp = objCCWeb.ReturnNumericValue("select Distinct SYD.FeeGroupID from FeeAccountMaster FD INNER JOIN Sistudentyearwisedetails SYD ON SYD.StudentID=FD.StudentID " +
					 " INNER JOIN FeeGroupMaster FGM ON FD.FeeGroupID=FGM.FeeGroupID And FGM.AcaStart=SYD.AcaStart" +
					 " where FD.StudentID=" + intstudentID + " and SYD.ACastart=" + Session["AcaStart"] + " and SYD.SchoolID=" + Session["SchoolID"] + "");


					int intFeeApl = objCCWeb.ReturnNumericValue("select Distinct SYD.FeeApplicableFrom from FeeAccountMaster FD " +
												   " INNER JOIN Sistudentyearwisedetails SYD ON SYD.StudentID=FD.StudentID  " +
												   " INNER JOIN FeeGroupMaster FGM ON FD.FeeGroupID=FGM.FeeGroupID And FGM.AcaStart=SYD.AcaStart " +
												   " where FD.StudentID=" + intstudentID + " and SYD.ACastart=" + Session["AcaStart"] + " and SYD.SchoolID=" + Session["SchoolID"] + "");
					if (intFeegrp != Convert.ToInt32(hidFeeGrpID.Value))
					{
						ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Fee Entry Already Done.So,You Cannot Change Feegroup');pEnableDisable('EDIT');</script>");
						ddlFeeGroup.Focus();
						return;
					}
					if (intFeeApl != Convert.ToInt32(hidFeeAppID.Value))
					{
						ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Fee Entry Already Done.So,You Cannot Change FeeApplicableFrom');pEnableDisable('EDIT');</script>");
						ddlFeeApplnFrom.Focus();
						return;
					}
				}

				//------------------Concession Checking-----------------
				int intFeeGroupID = objCCWeb.ReturnNumericValue("select Distinct FD.FeeGroupID from FeeConcessionMaster FD INNER JOIN Sistudentyearwisedetails SYD ON SYD.StudentID=FD.StudentID " +
				" INNER JOIN FeeGroupMaster FGM ON FD.FeeGroupID=FGM.FeeGroupID And FGM.AcaStart=SYD.AcaStart" +
				" where FD.StudentID=" + intstudentID + " and SYD.ACastart=" + Session["AcaStart"] + " and SYD.SchoolID=" + Session["SchoolID"] + "");

				if (intFeeGroupID > 0)
				{
					if (intFeeGroupID != Convert.ToInt32(hidFeeGrpID.Value))
					{
						ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Concession Given For This Student. So,You Cannot Change Feegroup');pEnableDisable('EDIT');</script>");
						ddlFeeGroup.Focus();
						return;
					}
				}
				//------------------Concession Checking-----------------


				intParentID = objCCWeb.ReturnNumericValue("Select ParentID from SIStudentMaster where StudentID='" + intstudentID + "'");



				if (intParentID != Convert.ToInt32(txtParentID.Text.Trim()))
				{
					if (objCCWeb.ReturnNumericValue("Select Count(*) from MTUserMaster where UserTypeID=3 And EmployeeIDStudentID='" + intParentID + "'") > 0)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Parent Login Generated for this student. So,You Cannot Change ParentID');pEnableDisable('EDIT');</script>");
						return;
					}
				}



				if (intParentID != Convert.ToInt32(txtParentID.Text.Trim().Replace("'", "''")))
				{

					hdnFImagePath.Value = Server.MapPath("FatherPhoto") + "/F" + intParentID + ".jpg";
					if (hdnFImagePath.Value != "noimage" && hdnFImagePath.Value != "")
					{
						try
						{
							if (File.Exists(Server.MapPath("FatherPhoto") + "/F" + intParentID + ".jpg") == true)
							{
								File.Copy(hdnFImagePath.Value, Server.MapPath("FatherPhoto") + "/F" + txtParentID.Text.Replace('/', '-') + ".jpg", true);
								File.Delete(Server.MapPath("FatherPhoto") + "/F" + intParentID + ".jpg");
							}

						}
						catch
						{ }
					}
					else if (hdnFImagePath.Value == "noimage")
					{
						if (File.Exists(Server.MapPath("FatherPhoto") + "/F" + txtParentID.Text.Replace('/', '-') + ".jpg") == true)
						{
							File.Delete(Server.MapPath("FatherPhoto") + "/F" + txtParentID.Text.Replace('/', '-') + ".jpg");
						}
					}


					hdnMImagePath.Value = Server.MapPath("MotherPhoto") + "/M" + intParentID + ".jpg";
					if (hdnMImagePath.Value != "noimage" && hdnMImagePath.Value != "")
					{
						try
						{
							if (File.Exists(Server.MapPath("MotherPhoto") + "/M" + intParentID + ".jpg") == true)
							{
								File.Copy(hdnMImagePath.Value, Server.MapPath("MotherPhoto") + "/M" + txtParentID.Text.Replace('/', '-') + ".jpg", true);
								File.Delete(Server.MapPath("MotherPhoto") + "/M" + intParentID + ".jpg");
							}

						}
						catch
						{ }
					}
					else if (hdnMImagePath.Value == "noimage")
					{
						if (File.Exists(Server.MapPath("MotherPhoto") + "/M" + txtParentID.Text.Replace('/', '-') + ".jpg") == true)
						{
							File.Delete(Server.MapPath("MotherPhoto") + "/M" + txtParentID.Text.Replace('/', '-') + ".jpg");
						}
					}

				}

				strCon1 = strCon1 + "~UPDATE SIStudentMaster SET FirstName=" + objCCWeb.fReplaceChar(txtFirstName) + ",MiddleName=" + objCCWeb.fReplaceChar(txtMiddleName) + "," +
					  " LastName=" + objCCWeb.fReplaceChar(txtLastName) + ",Sex='" + (rbtnMale.Checked == true ? 'M' : 'F') + "',DateOfBirth=" + objCCWeb.ReturnDateorNull(txtStuDOB.Text.Trim()) + "," +
					  " DateOfAdmission=" + objCCWeb.ReturnDateorNull(txtDOA.Text.Trim()) + ",ClassAdmited=" + ddlAdmittedClass.SelectedValue + ",CategoryID=" + ddlSocCategory.SelectedValue + "," +
					  " ReligionID=" + ddlReligion.SelectedValue + ",CasteID=0,EmergencyPhoneNo=" + objCCWeb.fReplaceChar(txtStuEmergencyNo) + "," +
					  " EmailID=" + objCCWeb.fReplaceChar(txtStuEmail) + ",BloodGroupID=" + ddlBloodGroup.SelectedValue + ",NationalityID=" + ddlNationality.SelectedValue + "," +
					  " MotherTongueID=" + ddlMotherTongue.SelectedValue + ",ParentID=" + (txtParentID.Text.Trim() == "" ? "0" : txtParentID.Text.Trim().Replace("'", "''")) + ", " +
					  " SIqamaNo=" + objCCWeb.fReplaceChar(txtSiqmano) + ",NoofChild=" + (txtNoOfChild.Text.Trim() == "" ? "0" : txtNoOfChild.Text.Trim().Replace("'", "''")) + ",Positionofchild=" + (txtPositionChild.Text.Trim() == "" ? "0" : txtPositionChild.Text.Trim().Replace("'", "''")) + " , " +
					  " UpdateUserID=" + Session["UID"] + ",UpdateDate=GETDATE(),SIqamaExpiryDate=" + objCCWeb.ReturnDateorNull(txtSiqmaExpiryDate.Text.Trim()) + ",FeeConcessionTypeID=" + ddlConcessionType.SelectedValue + ",Meals=" + strMeal + ",SchoolBus='" + ddlSchoolBus.SelectedValue + "',SecondLanguage=" + ddlSecondLanguage.SelectedValue + ",ThirdLanguage=" + ddlThirdLanguage.SelectedValue + " ," +
                      " StudentLivingWithParents='" + ddlStuLiving.SelectedValue + "',ProvAdmission='" + (rbtProvYes.Checked == true ? 'Y' : 'N') + "',DateOfJoin=" + objCCWeb.ReturnDateorNull(txtDateOFJoin.Text.Trim()) + ",CBSERollNo=" + objCCWeb.fReplaceChar(txtCBSERollNo) + ", Caste=" + objCCWeb.fReplaceChar(txtCaste) + ",FreeShip='" + (rbtnFreeShipYes.Checked == true ? 'Y' : 'N') + "' WHERE StudentID=" + intstudentID + " AND SchoolID=" + Session["SchoolID"].ToString() + " ";

				strCon1 = strCon1 + "~UPDATE SIStudentYearWiseDetails SET ClassID=" + ddlClass.SelectedValue + "," +
					  " SectionID=" + ddlSection.SelectedValue + ",FeeGroupID=" + ddlFeeGroup.SelectedValue + " ,NewAdmission='" + (rbtnAdmissionNew.Checked == true ? 'N' : 'O') + "',FeeApplicableFrom=" + ddlFeeApplnFrom.SelectedValue + ",ClassRollNo=" + (txtRollNo.Text.Trim() == "" ? "0" : txtRollNo.Text.Trim()) + "," +
					  " HouseID=" + ddlHouse.SelectedValue + ",BoardID=" + ddlBoard.SelectedValue + ",BoardRegistrationNo='" + txtBoardRegNo.Text.Trim().Replace("'", "''") + "',BoardingCategoryID=" + ddlBoardingCategory.SelectedValue + "," +
                      " ChildCode=" + objCCWeb.fReplaceChar(txtChildCode) + ",Remark=" + objCCWeb.fReplaceChar(txtRemarks) + ",UpdateUserID=" + Session["UID"] + ",UpdateDate=GETDATE(),SchoolTransfered='0',Stream=" + (ddlStream.SelectedValue == "" ? "0" : ddlStream.SelectedValue) + ",TRBusStopID=0,GGNNo=" + objCCWeb.fReplaceChar(txtGGNNo) + " WHERE StudentID=" + intstudentID + " AND SchoolID=" + Session["SchoolID"] + " AND AcaStart=" + Session["AcaStart"] + "";



				if (objCCWeb.ReturnSingleValue("SELECT Max(Acastart) from SIStudentyearwisedetails WHERE StudentID=" + intstudentID + " AND SchoolID=" + Session["SchoolID"] + " ") == Session["AcaStart"].ToString())
				{
					string strAdmno = objCCWeb.ReturnSingleValue("SELECT AdmissionNo from SIStudentyearwisedetails WHERE StudentID=" + intstudentID + " AND SchoolID=" + Session["SchoolID"] + " AND AcaStart=" + Session["AcaStart"] + " ");

					string strfeeno = objCCWeb.ReturnSingleValue("SELECT FeeNo from SIStudentyearwisedetails WHERE StudentID=" + intstudentID + " AND SchoolID=" + Session["SchoolID"] + " AND AcaStart=" + Session["AcaStart"] + " ");

					strCon1 = strCon1 + "~UPDATE SIStudentYearWiseDetails SET AdmissionNo='" + txtAdmNo.Text.Trim().Replace("'", "''") + "'  WHERE StudentID=" + intstudentID + " AND SchoolID=" + Session["SchoolID"] + " AND AdmissionNo='" + strAdmno + "'";

					strCon1 = strCon1 + "~UPDATE SIStudentYearWiseDetails SET FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "'  WHERE StudentID=" + intstudentID + " AND SchoolID=" + Session["SchoolID"] + " AND FeeNo='" + strfeeno + "'";
				}


				// -------- Added For Mark Entry Updation on Section Change
				int intSectionID = objCCWeb.ReturnNumericValue("SELECT SYD.SectionID from SIStudentYearWiseDetails SYD INNER JOIN MTSectionMaster SM on SYD.SectionID = SM.SectionID where SYD.ClassID = " + Request.Form["ddlClass"] + " and SYD.StudentId = " + intstudentID + " and Acastart = " + Session["AcaStart"] + " and SchoolID = " + Session["SchoolID"] + "");
				if (Convert.ToInt32(intSectionID) != 0)
				{
					if (Request.Form["ddlSection"] != Convert.ToString(intSectionID))
					{
						objCCWeb.BindDataSet("EXEC spExamEntryonSectionChange " + Request.Form["ddlClass"] + "," + Request.Form["ddlSection"] + "," + intSectionID + "," + intstudentID + "," + Session["Acastart"] + "," + Session["SchoolID"] + "");
					}
				}

				strCon1 = strCon1 + "~DELETE FROM SIStudentMailingAddress WHERE StudentID=" + intstudentID + "";

				strCon1 = strCon1 + "~DELETE FROM SIStudentResidenceAddress WHERE StudentID=" + intstudentID + "";

				strCon1 = strCon1 + "~DELETE FROM SIStudentLanguages WHERE StudentID=" + intstudentID + "";

				strCon1 = strCon1 + "~DELETE FROM SIStudentTypeofImpairmentDetails WHERE StudentID=" + intstudentID + "";

				strCon1 = strCon1 + "~DELETE FROM SIStudentEmergencyContactDetails WHERE StudentID=" + intstudentID + "";

				strCon1 = strCon1 + "~DELETE FROM SIStudentPickUpDetails WHERE StudentID=" + intstudentID + "";

				strCon1 = strCon1 + "~DELETE FROM SIStudentDocumentDetails WHERE StudentID=" + intstudentID + "";

				strCon1 = strCon1 + "~DELETE FROM SIStudentPreviousEducationDetails WHERE StudentID=" + intstudentID + "";
				strCon2 = strCon2 + "~INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuStudent','Student, Name: " + txtFirstName.Text.Trim().Replace("'", "''") + " " + txtMiddleName.Text.Trim().Replace("'", "''") + " " + txtLastName.Text.Trim().Replace("'", "''") + " With Admission No : " + txtAdmNo.Text.Trim().Replace("'", "''") + " & Fee No: " + txtFeeNo.Text.Trim().Replace("'", "''") + " In Class-Sec " + ddlClass.SelectedItem + "-" + ddlSection.SelectedItem + " Is Modified In Student Information')";

			}
			string strQry1 = "";
			for (int intForLoop = 0; intForLoop < gvPreviousEducation.Rows.Count; intForLoop++)
			{
				if (Request.Form[gvPreviousEducation.Rows[intForLoop].UniqueID + "$txtSchoolName"].Trim() != "")
				{
					strQry1 = "~INSERT INTO SIStudentPreviousEducationDetails (PEID,StudentID,SNo,NameOfSchool,Location,ClassCompleted,YearAttended,LanguageOfInstruction,Result,EntryUserID,EntryDate) " +
						   "SELECT ISNULL(MAX(PEID),0)+1," + intstudentID + "," + (intForLoop + 1) + ",'" + Request.Form[gvPreviousEducation.Rows[intForLoop].UniqueID + "$txtSchoolName"].Trim().Replace("'", "''") + "'," +
						   "'" + Request.Form[gvPreviousEducation.Rows[intForLoop].UniqueID + "$txtLocation"].Trim().Replace("'", "''") + "','" + Request.Form[gvPreviousEducation.Rows[intForLoop].UniqueID + "$txtClassCompleted"].Trim().Replace("'", "''") + "',  " +
							" " + (Request.Form[gvPreviousEducation.Rows[intForLoop].UniqueID + "$txtYearAttended"].Trim() == "" ? "0" : (Request.Form[gvPreviousEducation.Rows[intForLoop].UniqueID + "$txtYearAttended"].Trim())).Replace("'", "''") + " ,'" + Request.Form[gvPreviousEducation.Rows[intForLoop].UniqueID + "$txtLanguage"].Trim().Replace("'", "''") + "','" + Request.Form[gvPreviousEducation.Rows[intForLoop].UniqueID + "$txtResult"].Trim().Replace("'", "''") + "'," + Session["UID"] + ",GETDATE() FROM  SIStudentPreviousEducationDetails";

					if ((strCon2.Length + strQry1.Length) <= 8000)
					{
						strCon2 += strQry1;
					}
					else if ((strCon3.Length + strQry1.Length) <= 8000)
					{
						strCon3 += strQry1;
					}
					else if ((strCon4.Length + strQry1.Length) <= 8000)
					{
						strCon4 += strQry1;
					}
					else if ((strCon5.Length + strQry1.Length) <= 8000)
					{
						strCon5 += strQry1;
					}
					else if ((strCon6.Length + strQry1.Length) <= 8000)
					{
						strCon6 += strQry1;
					}
					else if ((strCon7.Length + strQry1.Length) <= 8000)
					{
						strCon7 += strQry1;
					}
					else if ((strCon8.Length + strQry1.Length) <= 8000)
					{
						strCon8 += strQry1;
					}
					else if ((strCon9.Length + strQry1.Length) <= 8000)
					{
						strCon9 += strQry1;
					}
					else if ((strCon10.Length + strQry1.Length) <= 8000)
					{
						strCon10 += strQry1;
					}
					else if ((strCon11.Length + strQry1.Length) <= 8000)
					{
						strCon11 += strQry1;
					}
					else if ((strCon12.Length + strQry1.Length) <= 8000)
					{
						strCon12 += strQry1;
					}
					else if ((strCon13.Length + strQry1.Length) <= 8000)
					{
						strCon13 += strQry1;
					}
					else if ((strCon14.Length + strQry1.Length) <= 8000)
					{
						strCon14 += strQry1;
					}
				}
			}

			strCon1 = strCon1 + "~INSERT INTO SIStudentMailingAddress (StudentID,FlatNo,CityID,PinCode,TelephoneNo,EntryUserID,EntryDate)" +
				" VALUES(" + intstudentID + ",'" + txtPresAddress.Text.Trim().Replace("'", "''") + "', " +
				" " + hdntxtResiCity.Value + ",'" + txtPresPincode.Text.Trim() + "','" + txtPresPhone.Text.Trim() + "'," + Session["UID"] + ",GETDATE())";
			strCon1 = strCon1 + "~INSERT INTO SIStudentResidenceAddress (StudentID,FlatNo,CityID,PinCode,TelephoneNo,EntryUserID,EntryDate)" +
				" VALUES(" + intstudentID + ",'" + txtPerAddress.Text.Trim().Replace("'", "''") + "', " +
				" " + hdntxtPerCity.Value + ", '" + txtPerPincode.Text.Trim() + "','" + txtPerPhone.Text.Trim() + "'," + Session["UID"] + ",GETDATE())";



			for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
			{
				if (chkLanguageKnown.Items[inti].Selected == true)
				{
					strCon1 = strCon1 + "~INSERT INTO SIStudentLanguages (SLDID,StudentID,MotherTongueID,EntryUserID,EntryDate)" +
						  " SELECT ISNULL(MAX(SLDID),0)+1," + intstudentID + "," + chkLanguageKnown.Items[inti].Value + "," + Session["UID"] + ",GETDATE() FROM SIStudentLanguages";

				}

			}


			for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
			{
				if (chkImpairment.Items[inti].Selected == true)
				{
					strCon1 = strCon1 + "~INSERT INTO SIStudentTypeofImpairmentDetails (SImpDID,StudentID,ImpairmentID,EntryUserID,EntryDate)" +
						  " SELECT ISNULL(MAX(SImpDID),0)+1," + intstudentID + "," + chkImpairment.Items[inti].Value + "," + Session["UID"] + ",GETDATE() FROM SIStudentTypeofImpairmentDetails";

				}

			}


			string strQry3 = "";
			for (int intForLoop = 0; intForLoop < gvEmergencyContact.Rows.Count; intForLoop++)
			{
				if (Request.Form[gvEmergencyContact.Rows[intForLoop].UniqueID + "$txtName"].Trim() != "")
				{
					strQry3 = "~INSERT INTO SIStudentEmergencyContactDetails (ECDID,StudentID,SNo,PersonName,Relation,PhoneNo,Remarks,EntryUserID,EntryDate) " +
							   "SELECT ISNULL(MAX(ECDID),0)+1," + intstudentID + "," + (intForLoop + 1) + ",'" + Request.Form[gvEmergencyContact.Rows[intForLoop].UniqueID + "$txtName"].Trim().Replace("'", "''") + "'," +
							   "'" + Request.Form[gvEmergencyContact.Rows[intForLoop].UniqueID + "$txtRelationship"].Trim().Replace("'", "''") + "','" + Request.Form[gvEmergencyContact.Rows[intForLoop].UniqueID + "$txtPhoneNo"].Trim().Replace("'", "''") + "',  " +
							   " '" + Request.Form[gvEmergencyContact.Rows[intForLoop].UniqueID + "$txtRemarks"].Trim().Replace("'", "''") + "'," + Session["UID"] + ",GETDATE() FROM  SIStudentEmergencyContactDetails";

					if ((strCon2.Length + strQry3.Length) <= 8000)
					{
						strCon2 += strQry3;
					}
					else if ((strCon3.Length + strQry3.Length) <= 8000)
					{
						strCon3 += strQry3;
					}
					else if ((strCon4.Length + strQry3.Length) <= 8000)
					{
						strCon4 += strQry3;
					}
					else if ((strCon5.Length + strQry3.Length) <= 8000)
					{
						strCon5 += strQry3;
					}
					else if ((strCon6.Length + strQry3.Length) <= 8000)
					{
						strCon6 += strQry3;
					}
					else if ((strCon7.Length + strQry3.Length) <= 8000)
					{
						strCon7 += strQry3;
					}
					else if ((strCon8.Length + strQry3.Length) <= 8000)
					{
						strCon8 += strQry3;
					}
					else if ((strCon9.Length + strQry3.Length) <= 8000)
					{
						strCon9 += strQry3;
					}
					else if ((strCon10.Length + strQry3.Length) <= 8000)
					{
						strCon10 += strQry3;
					}
					else if ((strCon11.Length + strQry3.Length) <= 8000)
					{
						strCon11 += strQry3;
					}
					else if ((strCon12.Length + strQry3.Length) <= 8000)
					{
						strCon12 += strQry3;
					}
					else if ((strCon13.Length + strQry3.Length) <= 8000)
					{
						strCon13 += strQry3;
					}
					else if ((strCon14.Length + strQry3.Length) <= 8000)
					{
						strCon14 += strQry3;
					}

				}
			}


			string strQry = "";
			for (int intForLoop = 0; intForLoop < gvAuthorisedPickUp.Rows.Count; intForLoop++)
			{
				int intPickupID = objCCWeb.ReturnNumericValue("SELECT ISNULL(MAX(PickupID),0)+1 FROM SIStudentPickUpDetails ");
				if (Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtName"].Trim() != "")
				{
					if ((Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() == "") || (Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() == "AuthorisedPickup/NoImage.JPG"))
					{
						strimagepath = "";
					}
					else
					{
						strimagepath = "P" + Convert.ToString(intstudentID) + "_" + (intForLoop + 1) + ".jpg ";
					}

					strQry = "~INSERT INTO SIStudentPickUpDetails (PickupID,StudentID,SNo,PersonName,Relation,PhoneNo,Remarks,imgpath,EntryUserID,EntryDate)" +
					   "SELECT ISNULL(MAX(PickupID),0)+1," + intstudentID + "," + (intForLoop + 1) + ",'" + Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtName"].Trim().Replace("'", "''") + "'," +
					   "'" + Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtRelationship"].Trim().Replace("'", "''") + "','" + Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtPhoneNo"].Trim().Replace("'", "''") + "',  " +
					   " '" + Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtRemarks"].Trim().Replace("'", "''") + "','" + strimagepath + "'," + Session["UID"] + ",GETDATE() FROM  SIStudentPickUpDetails";


					if ((strCon2.Length + strQry.Length) <= 8000)
					{
						strCon2 += strQry;
					}
					else if ((strCon3.Length + strQry.Length) <= 8000)
					{
						strCon3 += strQry;
					}
					else if ((strCon4.Length + strQry.Length) <= 8000)
					{
						strCon4 += strQry;
					}
					else if ((strCon5.Length + strQry.Length) <= 8000)
					{
						strCon5 += strQry;
					}
					else if ((strCon6.Length + strQry.Length) <= 8000)
					{
						strCon6 += strQry;
					}
					else if ((strCon7.Length + strQry.Length) <= 8000)
					{
						strCon7 += strQry;
					}
					else if ((strCon8.Length + strQry.Length) <= 8000)
					{
						strCon8 += strQry;
					}
					else if ((strCon9.Length + strQry.Length) <= 8000)
					{
						strCon9 += strQry;
					}
					else if ((strCon10.Length + strQry.Length) <= 8000)
					{
						strCon10 += strQry;
					}
					else if ((strCon11.Length + strQry.Length) <= 8000)
					{
						strCon11 += strQry;
					}
					else if ((strCon12.Length + strQry.Length) <= 8000)
					{
						strCon12 += strQry;
					}
					else if ((strCon13.Length + strQry.Length) <= 8000)
					{
						strCon13 += strQry;
					}
					else if ((strCon14.Length + strQry.Length) <= 8000)
					{
						strCon14 += strQry;
					}

				}
			}
			for (int intForLoop = 0; intForLoop < gvAuthorisedPickUp.Rows.Count; intForLoop++)
			{
				if (Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtName"].Trim() != "")
				{
					if (Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() != "")
					{
						try
						{
							if ((Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim().Substring(0, 18) != "AuthorisedPickup/P") && (Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() != "AuthorisedPickup/NoImage.JPG"))
							{
								//FileInfo fa = new FileInfo();
								if (File.Exists(Server.MapPath("AuthorisedPickup") + "/P" + intstudentID + "_" + gvAuthorisedPickUp.Rows[intForLoop].Cells[0].Text.Trim() + ".jpg") == true)
								{
									File.Delete(Server.MapPath("AuthorisedPickup") + "/P" + intstudentID + "_" + gvAuthorisedPickUp.Rows[intForLoop].Cells[0].Text.Trim() + ".jpg");
								}
								File.Copy(Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim(), Server.MapPath("AuthorisedPickup") + "/P" + intstudentID + "_" + gvAuthorisedPickUp.Rows[intForLoop].Cells[0].Text.Trim() + ".jpg", true);
								// File.Delete(Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim());
							}
							else if (Request.Form[gvAuthorisedPickUp.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() == "AuthorisedPickup/NoImage.JPG")
							{
								if (File.Exists(Server.MapPath("AuthorisedPickup") + "/P" + intstudentID + "_" + gvAuthorisedPickUp.Rows[intForLoop].Cells[0].Text.Trim() + ".jpg") == true)
								{
									File.Delete(Server.MapPath("AuthorisedPickup") + "/P" + intstudentID + "_" + gvAuthorisedPickUp.Rows[intForLoop].Cells[0].Text.Trim() + ".jpg");
								}
							}
						}
						catch
						{
						}
					}
				}
				else if (File.Exists(Server.MapPath("AuthorisedPickup") + "/P" + intstudentID + "_" + gvAuthorisedPickUp.Rows[intForLoop].Cells[0].Text.Trim() + ".jpg") == true)
				{
					File.Delete(Server.MapPath("AuthorisedPickup") + "/P" + intstudentID + "_" + gvAuthorisedPickUp.Rows[intForLoop].Cells[0].Text.Trim() + ".jpg");
				}
			}


			string strQury2 = "";

			for (int intForLoop = 0; intForLoop < gvDocuments.Rows.Count; intForLoop++)
			{
				if (Request.Form[((CheckBox)(gvDocuments.Rows[intForLoop].Cells[3].FindControl("YES"))).UniqueID] == "on")
				{

					strQury2 = "~INSERT INTO SISTUDENTDOCUMENTDETAILS (StudentID,DocumentID,EntryUserID,EntryDate) VALUES" +
					  "(" + intstudentID + "," + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "," + Session["UID"].ToString() + ",GETDATE())";


					if ((strCon2.Length + strQury2.Length) <= 8000)
					{
						strCon2 += strQury2;
					}
					else if ((strCon3.Length + strQury2.Length) <= 8000)
					{
						strCon3 += strQury2;
					}
					else if ((strCon4.Length + strQury2.Length) <= 8000)
					{
						strCon4 += strQury2;
					}
					else if ((strCon5.Length + strQury2.Length) <= 8000)
					{
						strCon5 += strQury2;
					}
					else if ((strCon6.Length + strQury2.Length) <= 8000)
					{
						strCon6 += strQury2;
					}
					else if ((strCon7.Length + strQury2.Length) <= 8000)
					{
						strCon7 += strQury2;
					}
					else if ((strCon8.Length + strQury2.Length) <= 8000)
					{
						strCon8 += strQury2;
					}
					else if ((strCon9.Length + strQury2.Length) <= 8000)
					{
						strCon9 += strQury2;
					}
					else if ((strCon10.Length + strQury2.Length) <= 8000)
					{
						strCon10 += strQury2;
					}
					else if ((strCon11.Length + strQury2.Length) <= 8000)
					{
						strCon11 += strQury2;
					}
					else if ((strCon12.Length + strQury2.Length) <= 8000)
					{
						strCon12 += strQury2;
					}
					else if ((strCon13.Length + strQury2.Length) <= 8000)
					{
						strCon13 += strQury2;
					}
					else if ((strCon14.Length + strQury2.Length) <= 8000)
					{
						strCon14 += strQury2;
					}


					// }              
				}
			}




			//------------------Modified By Manju on 11-10-2012------------------------*/
			string strQury3 = "";

			for (int intForLoop = 0; intForLoop < gvDocuments.Rows.Count; intForLoop++)
			{
				if (Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() != "")
				{
					string[] strCheckFormat = Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim().Split('.');
					if (strCheckFormat[strCheckFormat.Length - 1] != "pdf" && strCheckFormat[strCheckFormat.Length - 1] != "doc")
					{

						if (Request.Form[((CheckBox)(gvDocuments.Rows[intForLoop].Cells[3].FindControl("YES"))).UniqueID] == "on")
						{
							try
							{
								if ((Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim().Substring(0, 11) != "Documents/D") && (Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() != "Documents/NoImage.JPG"))
								{
									if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg") == true)
									{
										File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg");
									}
									File.Copy(Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim(), Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg", true);
									strQury3 = "~UPDATE SISTUDENTDOCUMENTDETAILS SET [TYPE]='.JPG' WHERE StudentID=" + intstudentID + " AND DOCUMENTID=" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "";
									//  File.Delete(Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim());

								}
								else if (Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() == "Documents/NoImage.JPG")
								{
									if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg") == true)
									{
										File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg");
									}
								}
								strQury3 = "~UPDATE SISTUDENTDOCUMENTDETAILS SET [TYPE]='.JPG' WHERE StudentID=" + intstudentID + " AND DOCUMENTID=" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "";
							}
							catch
							{
							}
						}
						else
						{
							if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg") == true)
							{
								File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg");
							}
						}
					}
					else
					{
						if (Request.Form[((CheckBox)(gvDocuments.Rows[intForLoop].Cells[3].FindControl("YES"))).UniqueID] == "on")
						{
							try
							{
								if ((Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim().Substring(0, 11) != "Documents/D") && (Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() != "Documents/NoImage.JPG"))
								{
									if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "." + strCheckFormat[strCheckFormat.Length - 1]) == true)
									{
										File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "." + strCheckFormat[strCheckFormat.Length - 1]);
									}
									File.Copy(Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim(), Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "." + strCheckFormat[strCheckFormat.Length - 1], true);
									strQury3 = strQury3 + "~UPDATE SISTUDENTDOCUMENTDETAILS SET [TYPE]='." + strCheckFormat[strCheckFormat.Length - 1] + "' WHERE StudentID=" + intstudentID + " AND DOCUMENTID=" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "";
								}
								else if (Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() == "Documents/NoImage.JPG")
								{
									if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "." + strCheckFormat[strCheckFormat.Length - 1]) == true)
									{
										File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "." + strCheckFormat[strCheckFormat.Length - 1]);
									}
								}
							}
							catch
							{

							}
							//strQury3 = "~UPDATE SISTUDENTDOCUMENTDETAILS SET [TYPE]='." + strCheckFormat[strCheckFormat.Length - 1] + "' WHERE StudentID=" + intstudentID + " AND DOCUMENTID=" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + "";
						}
					}
				}
				else
				{
					if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg") == true)
					{
						File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg");
					}
				}
			}
			if ((strCon2.Length + strQury2.Length) <= 8000)
			{
				strCon2 += strQury3;
			}
			else if ((strCon3.Length + strQury2.Length) <= 8000)
			{
				strCon3 += strQury3;
			}
			else if ((strCon4.Length + strQury2.Length) <= 8000)
			{
				strCon4 += strQury3;
			}
			else if ((strCon5.Length + strQury2.Length) <= 8000)
			{
				strCon5 += strQury3;
			}
			else if ((strCon6.Length + strQury2.Length) <= 8000)
			{
				strCon6 += strQury3;
			}
			else if ((strCon7.Length + strQury2.Length) <= 8000)
			{
				strCon7 += strQury3;
			}
			else if ((strCon8.Length + strQury2.Length) <= 8000)
			{
				strCon8 += strQury3;
			}
			else if ((strCon9.Length + strQury2.Length) <= 8000)
			{
				strCon9 += strQury3;
			}
			else if ((strCon10.Length + strQury2.Length) <= 8000)
			{
				strCon10 += strQury3;
			}
			else if ((strCon11.Length + strQury2.Length) <= 8000)
			{
				strCon11 += strQury3;
			}
			else if ((strCon12.Length + strQury2.Length) <= 8000)
			{
				strCon12 += strQury3;
			}
			else if ((strCon13.Length + strQury2.Length) <= 8000)
			{
				strCon13 += strQury3;
			}
			else if ((strCon14.Length + strQury2.Length) <= 8000)
			{
				strCon14 += strQury3;
			}

			//------------------End of Modified By Manju on 11-10-2012------------------------*/


			//////for (int intForLoop = 0; intForLoop < gvDocuments.Rows.Count; intForLoop++)
			//////{
			//////    if (Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() != "")
			//////    {
			//////        if (Request.Form[((CheckBox)(gvDocuments.Rows[intForLoop].Cells[3].FindControl("YES"))).UniqueID] == "on")
			//////        {
			//////            try
			//////            {
			//////                if ((Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim().Substring(0, 11) != "Documents/D") && (Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() != "Documents/NoImage.JPG"))
			//////                {
			//////                    if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg") == true)
			//////                    {
			//////                        File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg");
			//////                    }
			//////                    File.Copy(Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim(), Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg", true);

			//////                    //  File.Delete(Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim());

			//////                }
			//////                else if (Request.Form[gvDocuments.Rows[intForLoop].UniqueID + "$txtimgPath"].Trim() == "Documents/NoImage.JPG")
			//////                {
			//////                    if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg") == true)
			//////                    {
			//////                        File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg");
			//////                    }
			//////                }

			//////            }
			//////            catch
			//////            {
			//////            }
			//////        }
			//////        else
			//////        {
			//////            if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg") == true)
			//////            {
			//////                File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg");
			//////            }
			//////        }
			//////    }
			//////    else
			//////    {
			//////        if (File.Exists(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg") == true)
			//////        {
			//////            File.Delete(Server.MapPath("Documents") + "/D" + intstudentID + "_" + gvDocuments.Rows[intForLoop].Cells[1].Text.Trim() + ".jpg");
			//////        }
			//////    }
			//////}


			if (objCCWeb.ReturnNumericValue("SELECT Count(*) FROM SIStudentMaster WHERE SchoolID=" + Session["SchoolID"].ToString() + "  AND ParentID=" + txtParentID.Text.Trim().Replace("'", "''") + " ") > 0)
			{
				intPreviousID = objCCWeb.ReturnNumericValue("SELECT TOP 1 StudentID FROM SIStudentMaster WHERE SchoolID=" + Session["SchoolID"].ToString() + "  AND ParentID=" + txtParentID.Text.Trim().Replace("'", "''") + "  ORDER BY StudentID");
			}

			if (objCCWeb.ReturnNumericValue("SELECT ISNULL(StudentID,0) FROM SIStudentFatherDetails Where StudentId=" + intstudentID + "") > 0)
			{
				//lstArray.Add("UPDATE SIStudentFatherDetails  SET  FatherName='" + txtFName.Text.Trim().Replace("'", "''") + "',TitleID=" + ddlFTitle.SelectedValue + "  WHERE StudentID=" + intstudentID + "");
				strCon1 = strCon1 + "~UPDATE SIStudentFatherDetails  SET  FatherName='" + txtFName.Text.Trim().Replace("'", "''") + "',TitleID=" + ddlFTitle.SelectedValue + "  WHERE StudentID=" + intstudentID + "";

			}
			else
			{
				if (intPreviousID == 0)
				{
					//lstArray.Add("INSERT INTO SIStudentFatherDetails(StudentID,TitleID,FatherName) VALUES (" + intstudentID + "," + ddlFTitle.SelectedValue + ",'" + txtFName.Text.Trim().Replace("'", "''") + "')");
					//////strCon1 = strCon1 + "~INSERT INTO SIStudentFatherDetails(StudentID,TitleID,FatherName) VALUES (" + intstudentID + "," + ddlFTitle.SelectedValue + ",'" + txtFName.Text.Trim().Replace("'", "''") + "')";
					strCon1 = strCon1 + "~INSERT INTO SIStudentFatherDetails(StudentID,TitleID,FatherName,ArabicFatherName,PQualificationID,POccupationID,PDesignationID,AnnualIncome,OrganizationName,OrganizationAddress,CityID, " +
							  "PinCode,MobileNo,Telephone,EmailID,FIqamaNo,EntryUserID,EntryDate,FIqamaNoExpiryDate,PNationlityID)  " +
							  " VALUES (" + intstudentID + "," + ddlFTitle.SelectedValue + ",'" + txtFName.Text.Trim().Replace("'", "''") + "','',0,0,0,0,'','',0, " +
							  " '','','','',''," + Session["UID"] + ",GETDATE(),NULL,0)";

				}
				else
				{

					strCon1 = strCon1 + "~INSERT INTO SIStudentFatherDetails(StudentID,TitleID,FatherName,ArabicFatherName,PQualificationID,POccupationID,PDesignationID,AnnualIncome,OrganizationName,OrganizationAddress,CityID, " +
			   "PinCode,MobileNo,Telephone,EmailID,FIqamaNo,EntryUserID,EntryDate,FIqamaNoExpiryDate)  " +
				   " (SELECT " + intstudentID + "," + ddlFTitle.SelectedValue + ",'" + txtFName.Text.Trim().Replace("'", "''") + "',ArabicFatherName,PQualificationID,POccupationID,PDesignationID,AnnualIncome,OrganizationName,OrganizationAddress,CityID, " +
			   " PinCode,MobileNo,Telephone,EmailID,FIqamaNo," + Session["UID"] + ",GETDATE(),FIqamaNoExpiryDate FROM SIStudentFatherDetails  WHERE StudentID=" + intPreviousID + ")";



				}
			}

			if (objCCWeb.ReturnNumericValue("SELECT ISNULL(StudentID,0) FROM SIStudentMotherDetails Where StudentId=" + intstudentID + "") > 0)
			{
				//lstArray.Add("UPDATE SIStudentMotherDetails  SET  MotherName='" + txtMName.Text.Trim().Replace("'", "''") + "',TitleID=" + ddlMTitle.SelectedValue + "   WHERE StudentID=" + intstudentID + "");
				strCon1 = strCon1 + "~UPDATE SIStudentMotherDetails  SET  MotherName='" + txtMName.Text.Trim().Replace("'", "''") + "',TitleID=" + ddlMTitle.SelectedValue + "   WHERE StudentID=" + intstudentID + "";
			}
			else
			{
				if (intPreviousID == 0)
				{
					//lstArray.Add("INSERT INTO SIStudentMotherDetails(StudentID,TitleID,MotherName) VALUES (" + intstudentID + "," + ddlMTitle.SelectedValue + ",'" + txtMName.Text.Trim().Replace("'", "''") + "')");
					//////strCon1 = strCon1 + "~INSERT INTO SIStudentMotherDetails(StudentID,TitleID,MotherName) VALUES (" + intstudentID + "," + ddlMTitle.SelectedValue + ",'" + txtMName.Text.Trim().Replace("'", "''") + "')";

					strCon1 = strCon1 + "~INSERT INTO SIStudentMotherDetails(StudentID,TitleID,MotherName,ArabicMotherName,PQualificationID,POccupationID,PDesignationID,AnnualIncome,OrganizationName,OrganizationAddress,CityID," +
						 " PinCode,MobileNo,Telephone,EmailID,MIqamaNo,EntryUserID,EntryDate,MIqamaNoExpiryDate,PNationlityID) " +
						 " VALUES(" + intstudentID + "," + ddlMTitle.SelectedValue + ",'" + txtMName.Text.Trim().Replace("'", "''") + "','',0,0,0,0,'','',0,'','','','','' " +
						 " ," + Session["UID"] + ",GETDATE(),NULL,0)";
				}
				else
				{
					strCon1 = strCon1 + "~INSERT INTO SIStudentMotherDetails(StudentID,TitleID,MotherName,ArabicMotherName,PQualificationID,POccupationID,PDesignationID,AnnualIncome,OrganizationName,OrganizationAddress,CityID," +
						 " PinCode,MobileNo,Telephone,EmailID,MIqamaNo,EntryUserID,EntryDate,MIqamaNoExpiryDate) " +
						 "(SELECT " + intstudentID + "," + ddlMTitle.SelectedValue + ",'" + txtMName.Text.Trim().Replace("'", "''") + "',ArabicMotherName,PQualificationID,POccupationID,PDesignationID,AnnualIncome,OrganizationName,OrganizationAddress,CityID,PinCode,MobileNo,Telephone,EmailID,MIqamaNo " +
					   " ," + Session["UID"] + ",GETDATE(),MIqamaNoExpiryDate FROM SIStudentMotherDetails  WHERE StudentID=" + intPreviousID + ")";

					strCon1 = strCon1 + "~INSERT INTO SiStudentLocalGuardianDetails(StudentID,GuardianName,Relation,Address,MobileNo,EmailID,LIqamaNo,LIqamaNoExpiryDate)  " +
					   "(SELECT  " + intstudentID + ",GuardianName,Relation,Address,MobileNo,EmailID,LIqamaNo,LIqamaNoExpiryDate FROM SiStudentLocalGuardianDetails WHERE StudentID=" + intPreviousID + ")";

				}
			}
			//lstArray.Add("EXEC  SPFeeConcessionSettings  " + ddlConcessionType.SelectedValue + "," + Session["SchoolID"] + "," + Session["AcaStart"] + "," + intstudentID + "," + ddlFeeGroup.SelectedValue + "," + Session["UID"] + ",'Conc'");
			strCon1 = strCon1 + "~EXEC  SPFeeConcessionSettings  " + ddlConcessionType.SelectedValue + "," + Session["SchoolID"] + "," + Session["AcaStart"] + "," + intstudentID + "," + ddlFeeGroup.SelectedValue + "," + Session["UID"] + ",'Conc'";
			/*==============================End of Modified By Manju on 23-04-2012=================================*/

			if (objCCWeb.ReturnNumericValue("Select count(*) AS [scount] From SIStudentYearWiseDetails Where AdmissionNo='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' AND StudentID<>" + intstudentID + " AND SchoolID=" + Session["SchoolID"].ToString() + " AND AcaStart=" + Session["AcaStart"].ToString()) > 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\" type=\"text/javascript\">" + strHideID + "pEnableDisable('EDIT');alert('AdmissionNo already exists for another student.');callreturn();</script>");
				return;
				//throw new Exception("ABCDFASDF");
			}

			if (objCCWeb.ReturnNumericValue("Select count(*) AS [scount] From SIStudentYearWiseDetails Where FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "' AND StudentID<>" + intstudentID + " AND SchoolID=" + Session["SchoolID"].ToString() + " AND AcaStart=" + Session["AcaStart"].ToString()) > 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\" type=\"text/javascript\">" + strHideID + "pEnableDisable('EDIT');alert('FeeNo already exists for another student.');callreturn();</script>");
				return;
				//throw new Exception("ABCDFASDF");
			}
			if (chkParentDetailUpdate.Checked == true)
			{
				string strStudent = objCCWeb.ReturnSingleValue(" Declare @Var as Varchar(5000)  SET @Var='' Select @Var=@Var + CAST(SM.StudentID AS VARCHAR) +'^'  FROM SIStudentMaster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID=SYD.StudentID WHERE ParentID=" + txtParentID.Text.Trim().Replace("'", "''") + " AND StudentStatus='S'  AND AdmissionNo <>'" + txtAdmNo.Text.Trim().Replace("'", "''") + "' AND AcaStart=" + Session["AcaStart"] + " AND SM.SchoolID=" + Session["SchoolID"] + "  SELECT Case When LEN(@Var)>1 THEN SubString(@Var,1,LEN(@Var)-1) ELSE '' END");
				if (strStudent != "")
				{
					string[] strStudentID = strStudent.Split('^');
					for (int intForLoop = 0; intForLoop < strStudentID.Length; intForLoop++)
					{


						strCon1 = strCon1 + "~UPDATE SIStudentMaster SET MotherTongueID=" + ddlMotherTongue.SelectedValue + ",ReligionID=" + ddlReligion.SelectedValue + ",Caste='" + txtCaste.Text.Trim().Replace("'", "''") + "',NationalityID=" + ddlNationality.SelectedValue + ",NoofChild=" + (txtNoOfChild.Text.Trim() == "" ? "0" : txtNoOfChild.Text.Trim().Replace("'", "''")) + ",UpdateUserID=" + Session["UID"] + ",UpdateDate=GETDATE(), EmergencyPhoneNo='" + txtStuEmergencyNo.Text.Trim().Replace("'", "''") + "' ,CategoryID=" + ddlSocCategory.SelectedValue + " WHERE StudentID=" + strStudentID[intForLoop] + "";
						//strCon1 = strCon1 + "~UPDATE SIStudentYearWiseDetails  SET  HouseID=" + ddlHouse.SelectedValue + ",UpdateUserID=" + Session["UID"] + ",UpdateDate=GETDATE()    WHERE StudentID=" + strStudentID[intForLoop] + "";
						strCon1 = strCon1 + "~UPDATE SIStudentMailingAddress SET FlatNo='" + txtPresAddress.Text.Trim().Replace("'", "''") + "',CityID= " + hdntxtResiCity.Value + ", PinCode='" + txtPresPincode.Text.Trim() + "',TelephoneNo='" + txtPresPhone.Text.Trim() + "',UpdateUserID=" + Session["UID"] + ",UpdateDate=GETDATE()  WHERE StudentID=" + strStudentID[intForLoop] + "";
						strCon1 = strCon1 + "~UPDATE SIStudentResidenceAddress SET FlatNo='" + txtPerAddress.Text.Trim().Replace("'", "''") + "',CityID=" + hdntxtPerCity.Value + ", PinCode='" + txtPerPincode.Text.Trim() + "',TelephoneNo='" + txtPerPhone.Text.Trim() + "',UpdateUserID=" + Session["UID"] + ",UpdateDate=GETDATE()  WHERE StudentID=" + strStudentID[intForLoop] + "";
						strCon1 = strCon1 + "~UPDATE SIStudentFatherDetails SET TitleID=" + ddlFTitle.SelectedValue + ",FatherName='" + txtFName.Text.Trim().Replace("'", "''") + "',UpdateUserID=" + Session["UID"] + ",UpdateDate=GETDATE()  WHERE StudentID=" + strStudentID[intForLoop] + "";
						strCon1 = strCon1 + "~UPDATE SIStudentMotherDetails  SET  MotherName='" + txtMName.Text.Trim().Replace("'", "''") + "',TitleID=" + ddlMTitle.SelectedValue + ",UpdateUserID=" + Session["UID"] + ",UpdateDate=GETDATE()    WHERE StudentID=" + strStudentID[intForLoop] + "";

					}
				}
			}

			strResult = objCCWeb.ExecuteQuery("EXEC spInsertUpdateQuery '" + strCon1.Replace("'", "''") + "','" + strCon2.Replace("'", "''") + "','" + strCon3.Replace("'", "''") +
					  "','" + strCon4.Replace("'", "''") + "','" + strCon5.Replace("'", "''") + "','" + strCon6.Replace("'", "''") + "','" + strCon7.Replace("'", "''") + "','" + strCon8.Replace("'", "''") + "','" + strCon9.Replace("'", "''") + "','" + strCon10.Replace("'", "''") + "','" + strCon11.Replace("'", "''") + "','" + strCon12.Replace("'", "''") + "','" + strCon13.Replace("'", "''") + "','" + strCon14.Replace("'", "''") + "'");
			/*============End of Modified By Manju on 23-04-2012===================*/
			if (Directory.Exists(Server.MapPath("StudentPhoto")) == true)
			{
				if (hdnSImagePath.Value != "noimage" && hdnSImagePath.Value.ToString() != "")
				{

					try
					{

						if (hdnSImagePath.Value != "noimage" && hdnSImagePath.Value.ToString() != "")
						{
							FileInfo fi = new FileInfo(hdnSImagePath.Value);
							if (fi.Length > (1024 * 100))
							//if (fi.Length > (1024*20))
							{
								ClientScript.RegisterStartupScript(this.GetType(), "disiptSize", "<script language=javascript>alert('Check The Image Size Should Be 100kb')</script>");
								//ClientScript.RegisterStartupScript(this.GetType(), "disiptSize", "<script language=javascript>alert('Image size should not be greater than 20kb')</script>");
								btnCancel_Click(sender, e);
								SqlDataReader sqlRdr1 = objCCWeb.BindReader("SELECT  SM.StudentID, YD.AdmissionNo, " +
										 " ISNULL(FirstName,'') +' '+ ISNULL(MiddleName,'') +' '+  ISNULL(LastName,'')  +' # '+  ISNULL(AdmissionNo,'') +' # '+CM.ClassName1+'-'+SIM.Sectionname1  " +
										 " FROM SIStudentMaster SM INNER JOIN SIStudentYearwisedetails YD ON SM.StudentID=YD.StudentId   " +
										  " INNER JOIN MTClassMaster CM ON CM.ClassID=YD.ClassID " +
										 " INNER JOIN MTSectionmaster SIM ON SIM.sectionID=YD.sectionID " +
									  " WHERE SM.StudentID=" + intstudentID + "  AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " ");
								if (sqlRdr1.Read())
								{
									hdntxtStuSelect.Value = sqlRdr1.GetValue(0).ToString();
									txtAdmNo.Text = sqlRdr1.GetValue(1).ToString();
									txtStuSelect.Text = sqlRdr1.GetValue(2).ToString();
									//txtAdmNo.Attributes.Add("onfocus", "javascript:return pFillFeilds('txtAdmNo')");
									btnShowSave_Click(sender, e);
									return;
								}
								sqlRdr1.Close();
								sqlRdr1.Dispose();
							}

						}
						if (File.Exists(Server.MapPath("StudentPhoto") + "/S" + intstudentID + ".jpg") == true)
						{
							File.Delete(Server.MapPath("StudentPhoto") + "/S" + intstudentID + ".jpg");
						}

						File.Copy(hdnSImagePath.Value, Server.MapPath("StudentPhoto") + "/S" + intstudentID + ".jpg", true);
						File.Delete(hdnSImagePath.Value);
					}
					catch
					{ }

				}
				else if (hdnSImagePath.Value == "noimage")
				{
					if (File.Exists(Server.MapPath("StudentPhoto") + "/S" + intstudentID + ".jpg") == true)
					{
						File.Delete(Server.MapPath("StudentPhoto") + "/S" + intstudentID + ".jpg");
					}
				}
				//  hidPickupID.Value = "AD";
				if (hdnFlag.Value == "N^")
				{
					hdnFlag.Value = "A";
				}
				else
				{
					hdnFlag.Value = "E^";
				}
			}

			if (chkAClear.Checked == true)
			{
				hidAutoClear.Value = "C";
			}
			else
			{
				hidAutoClear.Value = "U";
			}

			if (strResult == "")
			{
				if (hdnFlag.Value == "N^" || hdnFlag.Value == "A")
				{
					strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "1", "");
				}
				else
				{
					strResult = objCCWeb.pDisplayMessage("" + Session["Type"].ToString() + "", "2", "");
				}
				ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('" + strResult + "');pLockControls('frmStudentmaster');document.getElementById('btnSave').disabled=true;pAddGridAttributes('frmStudentmaster')</script>");
			}
			else
			{
				ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('" + strResult + "')</script>");
			}

			if (chkAClear.Checked == true)
			{
				btnShowSave_Click(sender, e);
				hdnFlag.Value = "^^";

			}
			else
			{
				//btnCancel_Click(sender, e);
				SqlDataReader sqlRdr = objCCWeb.BindReader("SELECT  SM.StudentID, YD.AdmissionNo, " +
						 " ISNULL(FirstName,'') +' '+ ISNULL(MiddleName,'') +' '+  ISNULL(LastName,'')  +' # '+  ISNULL(AdmissionNo,'') +' # '+CM.ClassName1+'-'+SIM.Sectionname1 " +
						 " FROM SIStudentMaster SM INNER JOIN SIStudentYearwisedetails YD ON SM.StudentID=YD.StudentId   " +
							 " INNER JOIN MTClassMaster CM ON CM.ClassID=YD.ClassID " +
								" INNER JOIN MTSectionmaster SIM ON SIM.sectionID=YD.sectionID " +
					  " WHERE SM.StudentID=" + intstudentID + "  AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " ");
				if (sqlRdr.Read())
				{
					hdntxtStuSelect.Value = sqlRdr.GetValue(0).ToString();
					txtAdmNo.Text = sqlRdr.GetValue(1).ToString();
					txtStuSelect.Text = sqlRdr.GetValue(2).ToString();
					btnShowSave_Click(sender, e);
					//txtAdmNo.Attributes.Add("onfocus", "javascript:return pFillFeilds('txtAdmNo')");
					return;
				}
				sqlRdr.Close();
				sqlRdr.Dispose();
			}

		}
		catch (Exception ex)
		{
			ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>" + strHideID + "alert(" + ex.Message.Replace("'", "") + ");</script>");
		}
	}
	protected void btnDropOut_Click(object sender, EventArgs e)
	{
		Response.Redirect("SIStudentDropoutDetail.aspx?StudentID=" + hdntxtStuSelect.Value);
		hdnFlag.Value = "^^";
	}
	protected void btnCancel_Click(object sender, EventArgs e)
	{
		foreach (Control txtControl in frmStudentmaster.Controls)
		{
			if (txtControl.GetType().FullName == "System.Web.UI.WebControls.TextBox")
			{
				((TextBox)txtControl).Text = "";
			}
		}

		foreach (Control ddlControl in frmStudentmaster.Controls)
		{
			if (ddlControl.GetType().FullName == "System.Web.UI.WebControls.DropDownList")
				if (((System.Web.UI.WebControls.ListControl)(((DropDownList)ddlControl))).Items.Count > 0)
				{
					{
						((DropDownList)ddlControl).SelectedIndex = 0;
					}
				}
		}
		pFillBlankGrid(0);
		//pDisplayType(); 

		strAddPhoto = "Add Photo";//objCCWeb.ReturnSingleValue("SELECT  Caption" + Session["Type"].ToString() + " FROM [MTFormControlMaster] WHERE   FormID=307 AND ControlName='lblAddSphoto' ");
		strRemovePhoto = "Remove";// objCCWeb.ReturnSingleValue("SELECT  Caption" + Session["Type"].ToString() + " FROM [MTFormControlMaster] WHERE   FormID=307 AND ControlName='lblRemoveSPhoto' ");
		strChangePhoto = "Change"; //objCCWeb.ReturnSingleValue("SELECT  Caption" + Session["Type"].ToString() + " FROM [MTFormControlMaster] WHERE   FormID=307 AND ControlName='lblChangSphoto' ");
		AddPhoto.InnerHtml = strAddPhoto;
		ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");
		txtStuSelect.Text = "";
		hdntxtStuSelect.Value = "";
		hdnSDID.Value = "";
		hidFeeGrpID.Value = "";
		hidFeeAppID.Value = "";
		hdntxtParentID.Value = "";
		lblLastMDate.Text = "";
		//  hdnFlag.Value = "^^";
		btnNew.Enabled = true;
		//if (hdnFlag.Value != "^")
		//{ hdnFlag.Value = "^^";
		//}   

		objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName" + Session["Type"].ToString() + " AS MotherTongueName FROM MTMotherTongueMaster WHERE MotherTongueID<>0 ORDER BY MotherTongueName" + Session["Type"].ToString() + " ", "MotherTongueID", "MotherTongueName", "");
		objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName FROM MTImpairmentMaster WHERE ImpairmentID<>0 ORDER BY Impairment ", "ImpairmentID", "ImpairmentName", "");

		//chkLanguageKnown.ClearSelection();
		rbtnAdmissionNew.Checked = true;
		rbtnMale.Checked = true;
		txtAdmNo.Focus();

		if (Session["Type"].ToString() == "2")
		{
			imgbtnAddress.ImageUrl = "~/Images/LeftArrow.gif";
		}
		// ddlNationality.SelectedValue = objCCWeb.ReturnSingleValue("select NationalityID from MTNationalityMaster where NationalityName1 like 'INDIAN%'");
		hdnFindSearch.Value = "";

		imgStudent.ImageUrl = "~/StudentPhoto/NoImage.JPG";
		imgQRCode.Visible = false;
		hdnFImagePath.Value = "";
		hdnMImagePath.Value = "";
		lblClassStrength.Text = "";
		lblTotalStrength.Text = "";
		hidSiblingAdm.Value = "";
		hdnImage.Value = "";

	}
	protected void btnClose_Click(object sender, EventArgs e)
	{
		hidCache.Value = "";
		Response.Redirect("MainForm.aspx");
	}

	protected void linkAddition_Click(object sender, EventArgs e)
	{
		/*========================================Modified By Manju on 28-04-2012==================================================================*/
		int intStudentID = 0;
		intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE AdmissionNo='" + txtAdmNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
		if (objCCWeb.ReturnNumericValue("SELECT COUNT(*) FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + " AND  YD.AcaStart=" + Session["AcaStart"] + "" +
					   " AND   ISNULL(AdmissionNo,'')= '" + txtAdmNo.Text.Trim().Replace("'", "''") + "'") <= 0)
		{
			ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('Admission No Does Not Exits..');callreturn();</script>");
			txtAdmNo.Focus();
			return;
		}
		else
		{
			if (Request["Check"] != "ADVSearch")
			{

				Response.Redirect("SIStudentAdditionalInformation.aspx?StudentAddID=" + intStudentID + "");
			}
			else
			{
				Response.Redirect("SIStudentAdditionalInformation.aspx?StudentAddID=" + intStudentID + "&Check=ADVSearch");
			}
		}
		/*========================================End of Modified By Manju on 28-04-2012==================================================================*/
	}
	protected void gvSibling_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex > -1)
		{

			e.Row.Cells[0].Text = intSlNo.ToString();
			intSlNo += 1;
			e.Row.Attributes.Add("ondblclick", "fSiblingGridDoubleClick(" + e.Row.RowIndex + ")");
			e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
		}
		else
		{
			intSlNo = 1;

		}


	}


	protected void gvFindStudent_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex > -1)
		{
			e.Row.Cells[0].Text = intSlNo.ToString();
			intSlNo += 1;
			e.Row.Attributes.Add("ondblclick", "fGridDoubleClick(" + e.Row.RowIndex + ")");
			e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
		}
		else
		{
			intSlNo = 1;

		}
		if (e.Row.RowType != DataControlRowType.EmptyDataRow)
		{
			e.Row.Cells[0].Style.Add("display", "none");
			e.Row.Cells[1].Style.Add("display", "none");
		}
	}
	protected void gvAuthorisedPickUp_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex > -1)
		{
			e.Row.Cells[6].Attributes.Add("onclick", "pPickupPhoto('ADD'," + e.Row.RowIndex + ",'gvAuthorisedPickUp')");
			e.Row.Cells[7].Attributes.Add("onclick", "fGridClick(" + e.Row.RowIndex + ",'gvAuthorisedPickUp')");
			e.Row.Cells[7].Attributes.Add("onError", "javascript:return fimgAssignError();");
			e.Row.Cells[8].Attributes.Add("onclick", "PRemovePickUPDocuments(" + e.Row.RowIndex + ",'gvAuthorisedPickUp')");
			//e.Row.Cells[5].Style.Add("display", "none");

			if (Request["Check"] == "ADVSearch")
			{
				e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
			}


			e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
		}
		/*===========Added By manju on 08-05-2012=============*/
		if (e.Row.RowType != DataControlRowType.EmptyDataRow)
		{
			e.Row.Cells[5].Style.Add("display", "none");
		}
		/*===========End of Added By manju on 08-05-2012=============*/
	}
	protected void btnDetails_Click(object sender, EventArgs e)
	{
		//Response.Redirect("SIStudentSummaryDetails.aspx?StudentID=" + hdnSDID.Value + "&AcaStart=" + Session["AcaStart"] + "");

		//Response.Redirect("SIFeeReceiptDetails.aspx?StudentID=" + hdnSDID.Value + "&AcaStart=" + Session["AcaStart"] + "");

		Response.Redirect("SIExamDetails.aspx?StudentID=" + hdnSDID.Value + "&AcaStart=" + Session["AcaStart"] + "");
		//Response.Redirect("SIExamDetails.aspx?StudentID=" + hdnSDID.Value + "&AcaStart=" + Session["AcaStart"] + "");

	}
	protected void gvDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex > -1)
		{

			e.Row.Cells[5].Attributes.Add("onclick", "pPickupPhoto('ADD'," + e.Row.RowIndex + ",'gvDocuments')");
			e.Row.Cells[6].Attributes.Add("onclick", "fGridClick(" + e.Row.RowIndex + ",'gvDocuments')");
			e.Row.Cells[6].Attributes.Add("onError", "javascript:return fimgAssignError();");
			e.Row.Attributes.Add("onmouseover", "javascript:this.style.cursor='pointer';");
			//  e.Row.Cells[7].Attributes.Add("onclick", "PRemovePickUPDocuments(" + e.Row.RowIndex + ",'gvDocuments')");
		}
		/*===========Added By manju on 08-05-2012=============*/
		if (e.Row.RowType != DataControlRowType.EmptyDataRow)
		{
			e.Row.Cells[4].Style.Add("display", "none");
			e.Row.Cells[1].Style.Add("display", "none");
		}
		/*===========End of Added By manju on 08-05-2012=============*/

	}
	protected void txtPresAddress_TextChanged(object sender, EventArgs e)
	{

	}
	/*==================Added By Manju on 30-04-2012===================================*/
	protected void btnDisplay_Click(object sender, EventArgs e)
	{
		hidStatusdisplay.Value = "";
		string strResult = "";
		int intStudentID = 0;
		string lblcaption = "";
		string intPID = "";
		string strClassStrength = "";
		string strSchoolStrength = "";
		int minAcaStart = Convert.ToInt32(Session["Acastart"]) - 1;

		intPID = objCCWeb.ReturnSingleValue("Select Max(ParentID)+1 from SIStudentmaster SM INNER JOIN SIStudentYearWisedetails YD ON YD.StudentID=SM.StudentID where YD.AcaStart=" + Session["AcaStart"] + " and YD.SchoolID=" + Session["SchoolID"] + "");
		if (btnNew.Enabled == false && (txtParentID.Text.Trim() != "") && (intPID != hidParentID.Value))
		{

			if (objCCWeb.ReturnNumericValue("SELECT ISNUMERIC ('" + txtParentID.Text.Trim().Replace("'", "''") + "')").ToString() == "0")
			{
				ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert(' Please Enter ParentID or Select Parent Name From List..');callreturn();</script>");
				txtParentID.Focus();
				return;

			}

			//if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentMaster SM INNER JOIN SIStudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' and AcaStart='" + Session["AcaStart"] + "'") <= 0)
			if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentMaster SM INNER JOIN SIStudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' ") <= 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('ParentID Does Not Exits..');callreturn();</script>");
				txtParentID.Focus();
				return;
			}
			if (btnNew.Enabled == false)
			{
				//if (objCCWeb.ReturnNumericValue("Select Count(*) From SIStudentMaster SM INNER JOIN SIStudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' and AcaStart='" + Session["AcaStart"] + "'") > 0)
				if (objCCWeb.ReturnNumericValue("Select Count(*) From SIStudentMaster SM INNER JOIN SIStudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' ") > 0)
				{
					int intParentID = Convert.ToInt32(txtParentID.Text.Trim().Replace("'", "''"));
					strResult = pGetSiblingDetails(intParentID);
					if ((strResult == "") || (strResult == "null"))
					{
						return;
					}
					string[] varStudent = strResult.Split('^');
					hdntxtStuSelect.Value = varStudent[0];
					hdnSDID.Value = varStudent[0];
					ddlReligion.SelectedValue = varStudent[1];
					//ddlCaste.SelectedValue = varStudent[2];
					ddlNationality.SelectedValue = varStudent[3];
					ddlMotherTongue.SelectedValue = varStudent[4];
					txtNoOfChild.Text = varStudent[5];
					txtChildCode.Text = varStudent[6];
					txtPresAddress.Text = varStudent[7];
					hdntxtResiCity.Value = varStudent[8];
					txtPresPincode.Text = varStudent[9];
					txtPresPhone.Text = varStudent[10];
					txtPerAddress.Text = varStudent[11];
					hdntxtPerCity.Value = varStudent[12];
					txtPerPincode.Text = varStudent[13];
					txtPerPhone.Text = varStudent[14];
					txtResiCity.Text = varStudent[15];
					txtPresState.Text = varStudent[16];
					txtPresCountry.Text = varStudent[17];
					txtPerCity.Text = varStudent[18];
					txtPerState.Text = varStudent[19];
					txtPerCountry.Text = varStudent[20];
					txtParentID.Text = varStudent[21];
					ddlFTitle.SelectedValue = varStudent[23];
					txtFName.Text = varStudent[24];
					ddlMTitle.SelectedValue = varStudent[25];
					// hidStatusdisplay.Value="";
					txtMName.Text = varStudent[26];
					if (varStudent[29] == "T")
					{
						hidStatusdisplay.Value = "T";
						imgATD.ImageUrl = "~/Images/Present.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
					}
					else if (varStudent[29] == "D")
					{
						hidStatusdisplay.Value = "D";
						imgATD.ImageUrl = "~/Images/Absent.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "  FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
					}
					else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
						  "  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
						  " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
						  " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + varStudent[0] + " ") > 0)
					{
						hidStatusdisplay.Value = "R";
						imgATD.ImageUrl = "~/Images/HalfDay.png";
						//lblStudentStatus.Text = "Repeater";
					}
					else
					{
						// imgATD.ImageUrl = "~/Images/1Present.png";
						// lblStudentStatus.Text = "";
					}
					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
						   " INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + intParentID + "    AND  " +
						"  SYWD.SchoolID=" + Session["SchoolID"] + "AND SYWD.AcaStart=" + Session["AcaStart"] + "  ORDER BY SM.StudentID");
					gvSibling.DataBind();


				}
				hdnFlag.Value = "N^";
			}
			else
			{
				if ((objCCWeb.ReturnNumericValue("Select Count(*) From SIStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'")) > 0)
				{
					int intPStudentID = objCCWeb.ReturnNumericValue("SELECT Top 1 SM.StudentID FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID  " +
						" WHERE ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'  AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " Order by SM.StudentId ASC");

					strResult = pGetStudentDetails(intPStudentID);
					if ((strResult == "") || (strResult == "null"))
					{
						return;
					}
					string[] VarArray = strResult.Split('^');
					hdnSImagePath.Value = "";
					imgStudent.ImageUrl = "StudentPhoto/S" + VarArray[0] + ".jpg";
					if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + VarArray[0] + ".GIF") == true)
					{
						imgQRCode.ImageUrl = "~/QRCodeImage/Q" + VarArray[0] + ".GIF";

					}
					else
					{
						imgQRCode.Visible = false;
					}

					hdntxtStuSelect.Value = VarArray[0];
					hdnSDID.Value = VarArray[0];
					txtFirstName.Text = VarArray[1];
					txtMiddleName.Text = VarArray[2];
					txtLastName.Text = VarArray[3];
					txtArabicName.Text = VarArray[4];
					if (VarArray[5].ToString() == "M")
					{
						rbtnMale.Checked = true;
					}
					else
					{
						rbtnFemale.Checked = true;
					}
					txtStuDOB.Text = VarArray[6];
					txtDOA.Text = VarArray[7];
					ddlAdmittedClass.SelectedValue = VarArray[8];
					ddlSocCategory.SelectedValue = VarArray[9];

					ddlReligion.SelectedValue = VarArray[10];
					//ddlCaste.SelectedValue = VarArray[11];
					txtStuEmergencyNo.Text = VarArray[12];
					txtStuEmail.Text = VarArray[13];
					ddlBloodGroup.SelectedValue = VarArray[14];
					ddlNationality.SelectedValue = VarArray[15];
					ddlMotherTongue.SelectedValue = VarArray[16];
					txtParentID.Text = VarArray[17];
					txtSiqmano.Text = VarArray[18];
					txtNoOfChild.Text = VarArray[19];
					txtPositionChild.Text = VarArray[20];
					txtAdmNo.Text = VarArray[21];
					txtFeeNo.Text = VarArray[22];
					ddlClass.SelectedValue = VarArray[23];
					ddlSection.SelectedValue = VarArray[24];

					lblCaption1.Text = "Strength";
					strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
					 " where StudentStatus='S' and SYD.ClassID='" + VarArray[23] + "' and SYD.SectionID='" + VarArray[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

					strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
					 " where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

					lblTotalStrength.Text = "School : " + "" + strSchoolStrength;

					lblClassStrength.Text = "Class  : " + "" + strClassStrength;

					if (VarArray[25].ToString() == "N")
					{
						rbtnAdmissionNew.Checked = true;
					}
					else
					{
						rbtnAdmissionOld.Checked = true;
					}
					txtRollNo.Text = VarArray[26];
					ddlHouse.SelectedValue = VarArray[27];
					ddlBoard.SelectedValue = VarArray[28];
					txtBoardRegNo.Text = VarArray[29];
					ddlBoardingCategory.SelectedValue = VarArray[30];
					//ddlStop.SelectedValue = VarArray[67];
					txtChildCode.Text = VarArray[31];
					txtRemarks.Text = VarArray[32];
					txtPresAddress.Text = VarArray[33];
					hdntxtResiCity.Value = VarArray[34];
					txtPresPincode.Text = VarArray[35];
					txtPresPhone.Text = VarArray[36];
					txtPerAddress.Text = VarArray[37];
					hdntxtPerCity.Value = VarArray[38];
					txtPerPincode.Text = VarArray[39];
					txtPerPhone.Text = VarArray[40];
					txtResiCity.Text = VarArray[41];
					txtPresState.Text = VarArray[42];
					txtPresCountry.Text = VarArray[43];
					txtPerCity.Text = VarArray[44];
					txtPerState.Text = VarArray[45];
					txtPerCountry.Text = VarArray[46];
					ddlFTitle.SelectedValue = VarArray[47];
					txtFName.Text = VarArray[48];
					ddlMTitle.SelectedValue = VarArray[49];
					txtMName.Text = VarArray[50];
					ddlFeeGroup.SelectedValue = VarArray[51];
					ddlFeeApplnFrom.SelectedValue = VarArray[52];

					if (VarArray[53].ToString() == "T")
					{
						hidStatusdisplay.Value = "T";
						imgATD.ImageUrl = "~/Images/Present.png";
						// lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
					}
					else if (VarArray[53].ToString() == "D")
					{
						hidStatusdisplay.Value = "D";
						imgATD.ImageUrl = "~/Images/Absent.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
					}
					else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
					"  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
					" WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
					" WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + VarArray[0] + " ") > 0)
					{
						hidStatusdisplay.Value = "R";
						imgATD.ImageUrl = "~/Images/HalfDay.png";
						// lblStudentStatus.Text = "Repeater";
					}
					else
					{
						//imgATD.ImageUrl = "~/Images/1Present.png";
						//lblStudentStatus.Text = "";
					}
					txtSiqmaExpiryDate.Text = VarArray[54];
					ddlConcessionType.SelectedValue = VarArray[55];
					if (VarArray[56] != "0")
					{
						ddlMeal.SelectedValue = VarArray[56];
					}

					if (VarArray[57] == "")
					{
						ddlSchoolBus.SelectedValue = "";
					}
					else
					{
						ddlSchoolBus.SelectedValue = VarArray[57];
					}
					ddlSecondLanguage.SelectedValue = VarArray[58];
					ddlThirdLanguage.SelectedValue = VarArray[59];
					ddlStuLiving.SelectedValue = VarArray[60];

					//if (VarArray[60] == "")
					//{
					//    ddlStuLiving.SelectedValue = "";
					//}
					//else
					//{
					//    ddlStuLiving.SelectedValue = VarArray[60];
					//}
					if (VarArray[61].ToString() == "Y")
					{
						rbtProvYes.Checked = true;
					}
					else
					{
						rbtProvNo.Checked = true;
					}
					txtDateOFJoin.Text = VarArray[62];
					txtLiveEduID.Text = VarArray[63];
					//ddlHomeAdvisor.SelectedValue = VarArray[66];


					txtCBSERollNo.Text = VarArray[65];
					txtCaste.Text = VarArray[68];

					if (VarArray[69].ToString() == "Y")
					{
						rbtnFreeShipYes.Checked = true;
					}
					else
					{
						rbtnFreeShipNo.Checked = true;
					}
                    txtGGNNo.Text = VarArray[70];
					gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intPStudentID + "");
					gvEmergencyContact.DataBind();


					gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intPStudentID + "");
					gvAuthorisedPickUp.DataBind();


					gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
									  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgpath  " +
									  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intPStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
					gvDocuments.DataBind();


					ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
						" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + VarArray[17] + "    AND  " +
					 "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();
					gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intPStudentID + "");
					gvPreviousEducation.DataBind();

					//objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 ORDER BY  MotherTongueName1", "MotherTongueID", "MotherTongueName", "");
					string vardata = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
											  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

					objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

					if (vardata != "0")
					{
						string[] varStr = vardata.Split(',');
						for (int i = 0; i < varStr.Length; i++)
						{
							if (chkLanguageKnown.Items.Count > 0)
							{
								for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
								{
									if (chkLanguageKnown.Items[inti].Value == varStr[i])
									{
										chkLanguageKnown.Items[inti].Selected = true;
									}

								}
							}
						}
					}

					//****Added By Archana******************//

					string vardata1 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(ImpairmentID AS Varchar)  FROM SIStudentTypeofImpairmentDetails Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
											  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

					objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName,1 as id FROM MTImpairmentMaster  WHERE ImpairmentID<>0 AND ImpairmentID IN (select * from [fnSplit] ('" + vardata1 + "',',')) union Select ImpairmentID,Impairment As ImpairmentName,2 as id From MTImpairmentMaster WHERE ImpairmentID<>0  AND ImpairmentID NOT IN (select * from [fnSplit] ('" + vardata1 + "',',')) ORDER BY id ", "ImpairmentID", "ImpairmentName", "");

					if (vardata1 != "0")
					{
						string[] varStr1 = vardata1.Split(',');
						for (int i = 0; i < varStr1.Length; i++)
						{
							if (chkImpairment.Items.Count > 0)
							{
								for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
								{
									if (chkImpairment.Items[inti].Value == varStr1[i])
									{
										chkImpairment.Items[inti].Selected = true;
									}

								}
							}
						}
					}
					//****Added By Archana END ******************//
				}
				intStudentID = objCCWeb.ReturnNumericValue("SELECT  SM.StudentID FROM SIStudentMaster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID = SYD.StudentID WHERE SM.ParentID='" + txtParentID.Text.Trim() + "' AND SYD.AcaStart=" + Session["AcaStart"] + " AND SYD.SchoolID=" + Session["SchoolID"] + "");
				hdnFlag.Value = "A";
			}
		}




		if (btnNew.Enabled == true && (txtAdmNo.Text.Trim() != ""))
		{
			if ((txtAdmNo.Text.Trim() != "") && (hdnAdmNo.Value == ""))
			{

				intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE AdmissionNo='" + txtAdmNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
				int pParentID = objCCWeb.ReturnNumericValue("SELECT ParentID FROM SIStudentMaster WHERE StudentID=" + intStudentID + "");
				// string FeeNo = objCCWeb.ReturnSingleValue("Select FeeNo from SIStudentYearWisedetails where AdmissionNo='"+txtAdmNo.Text.Trim()+"' AND AcaStart="+Session["AcaStart"]+" AND SchoolID="+Session["SchoolID"]+" ");

				if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentYearWiseDetails where AdmissionNo='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' AND AcaStart=" + Session["AcaStart"] + "  AND SchoolID=" + Session["SchoolID"] + "") <= 0)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('Admission No Does Not Exits..');callreturn();</script>");
					txtAdmNo.Focus();
					return;
				}
				if (txtParentID.Text.Trim().Replace("'", "''") != "")
				{
					if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentMaster SM INNER JOIN SIStudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' ") <= 0)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('ParentID Does Not Exits..');callreturn();</script>");
						txtParentID.Focus();
						return;
					}
					pParentID = Convert.ToInt32(txtParentID.Text.Trim());
				}

				//if (objCCWeb.ReturnNumericValue("Select Count(*) From Sistudentyearwisedetails where FeeNo='" + FeeNo + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "") > 1)
				//{
				//    ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>callreturn();</script>");
				//    txtAdmNo.Focus();

				//    return;
				//}


				strResult = pGetStudentDetails(intStudentID);
				if ((strResult == "") || (strResult == "null"))
				{
					return;
				}
				string[] strArray1 = strResult.Split('^');
				hdnSImagePath.Value = "";
				imgStudent.ImageUrl = "StudentPhoto/S" + strArray1[0] + ".jpg";
				if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + strArray1[0] + ".GIF") == true)
				{
					imgQRCode.ImageUrl = "~/QRCodeImage/Q" + strArray1[0] + ".GIF";
					imgQRCode.Visible = true;
				}
				else
				{
					imgQRCode.Visible = false;
				}
				hdntxtStuSelect.Value = strArray1[0];
				hdnSDID.Value = strArray1[0];
				txtFirstName.Text = strArray1[1];
				txtMiddleName.Text = strArray1[2];
				txtLastName.Text = strArray1[3];
				txtArabicName.Text = strArray1[4];
				if (strArray1[5].ToString() == "M")
				{
					rbtnMale.Checked = true;
				}
				else
				{
					rbtnFemale.Checked = true;
				}
				txtStuDOB.Text = strArray1[6];
				txtDOA.Text = strArray1[7];
				ddlAdmittedClass.SelectedValue = strArray1[8];
				ddlSocCategory.SelectedValue = strArray1[9];

				ddlReligion.SelectedValue = strArray1[10];
				// ddlCaste.SelectedValue = strArray1[11];
				txtStuEmergencyNo.Text = strArray1[12];
				txtStuEmail.Text = strArray1[13];
				ddlBloodGroup.SelectedValue = strArray1[14];
				ddlNationality.SelectedValue = strArray1[15];
				ddlMotherTongue.SelectedValue = strArray1[16];
				if (pParentID != Convert.ToInt32(strArray1[17]))
				{
					txtParentID.Text = pParentID.ToString();
				}
				else
				{
					txtParentID.Text = strArray1[17];
				}
				txtSiqmano.Text = strArray1[18];
				txtNoOfChild.Text = strArray1[19];
				txtPositionChild.Text = strArray1[20];
				txtAdmNo.Text = strArray1[21];
				txtFeeNo.Text = strArray1[22];
				ddlClass.SelectedValue = strArray1[23];
				ddlSection.SelectedValue = strArray1[24];
				lblCaption1.Text = "Strength";
				strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S' and SYD.ClassID='" + strArray1[23] + "' and SYD.SectionID='" + strArray1[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

				lblClassStrength.Text = "Class : " + "" + strClassStrength;


				strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

				lblTotalStrength.Text = "School : " + "" + strSchoolStrength;

				if (strArray1[25].ToString() == "N")
				{
					rbtnAdmissionNew.Checked = true;
				}
				else
				{
					rbtnAdmissionOld.Checked = true;
				}
				txtRollNo.Text = strArray1[26];
				ddlHouse.SelectedValue = strArray1[27];
				ddlBoard.SelectedValue = strArray1[28];
				txtBoardRegNo.Text = strArray1[29];
				ddlBoardingCategory.SelectedValue = strArray1[30];
				// ddlStop.SelectedValue = strArray1[67];
				txtChildCode.Text = strArray1[31];
				txtRemarks.Text = strArray1[32];
				txtPresAddress.Text = strArray1[33];
				hdntxtResiCity.Value = strArray1[34];
				txtPresPincode.Text = strArray1[35];
				txtPresPhone.Text = strArray1[36];
				txtPerAddress.Text = strArray1[37];
				hdntxtPerCity.Value = strArray1[38];
				txtPerPincode.Text = strArray1[39];
				txtPerPhone.Text = strArray1[40];
				txtResiCity.Text = strArray1[41];
				txtPresState.Text = strArray1[42];
				txtPresCountry.Text = strArray1[43];
				txtPerCity.Text = strArray1[44];
				txtPerState.Text = strArray1[45];
				txtPerCountry.Text = strArray1[46];
				ddlFTitle.SelectedValue = strArray1[47];
				txtFName.Text = strArray1[48];
				ddlMTitle.SelectedValue = strArray1[49];
				txtMName.Text = strArray1[50];
				ddlFeeGroup.SelectedValue = strArray1[51];


				ddlFeeApplnFrom.SelectedValue = strArray1[52];

				if (strArray1[53].ToString() == "T")
				{
					hidStatusdisplay.Value = "T";
					imgATD.ImageUrl = "~/Images/Present.png";
					//  lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
				}
				else if (strArray1[53].ToString() == "D")
				{
					hidStatusdisplay.Value = "D";
					imgATD.ImageUrl = "~/Images/Absent.png";
					//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
				}
				else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
				   "  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
				   " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
				   " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + strArray1[0] + " ") > 0)
				{
					hidStatusdisplay.Value = "R";
					imgATD.ImageUrl = "~/Images/HalfDay.png";
					// lblStudentStatus.Text = "Repeater";
				}
				else
				{
					//  imgATD.ImageUrl = "~/Images/1Present.png";
					// lblStudentStatus.Text = "";
				}
				txtSiqmaExpiryDate.Text = strArray1[54];
				ddlConcessionType.SelectedValue = strArray1[55];
				if (strArray1[56] != "0")
				{
					ddlMeal.SelectedValue = strArray1[56];
				}

				if (strArray1[57] == "")
				{
					ddlSchoolBus.SelectedValue = "";
				}
				else
				{
					ddlSchoolBus.SelectedValue = strArray1[57];
				}
				ddlSecondLanguage.SelectedValue = strArray1[58];
				ddlThirdLanguage.SelectedValue = strArray1[59];
				ddlStuLiving.SelectedValue = strArray1[60];

				//if (strArray1[60] == "")
				//{
				//    ddlStuLiving.SelectedValue = "";
				//}
				//else
				//{
				//    ddlStuLiving.SelectedValue = strArray1[60];
				//}
				if (strArray1[61].ToString() == "Y")
				{
					rbtProvYes.Checked = true;
				}
				else
				{
					rbtProvNo.Checked = true;
				}
				txtDateOFJoin.Text = strArray1[62];
				txtLiveEduID.Text = strArray1[63];


				txtCBSERollNo.Text = strArray1[65];
				ddlStream.SelectedValue = (strArray1[66] == "" ? "0" : strArray1[66]);
				txtCaste.Text = strArray1[68];

				if (strArray1[69].ToString() == "Y")
				{
					rbtnFreeShipYes.Checked = true;
				}
				else
				{
					rbtnFreeShipNo.Checked = true;
				}
                txtGGNNo.Text = strArray1[70];
				gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intStudentID + "");
				gvEmergencyContact.DataBind();




				gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intStudentID + "");
				gvAuthorisedPickUp.DataBind();



				//fillGrid('gvDocuments',"SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName<%=Session["Type"] %>  AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
				//          " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as MPath  " +
				//          " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID="+varStudent[0]+"    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");

				gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
								  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgPath  " +
								  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
				gvDocuments.DataBind();


				//ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


				if (pParentID != Convert.ToInt32(strArray1[17]))
				{
					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
					" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + pParentID + "    AND  " +
					"  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();
					hdnFlag.Value = "PID";

				}
				else
				{
					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
					" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + strArray1[17] + "    AND  " +
					"  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();

				}


				gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intStudentID + "");
				gvPreviousEducation.DataBind();




				/*-----------------------Modified By Manju on 29-05-2012-----------------------------------------------------*/
				string vardata2 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
										  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

				objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata2 + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata2 + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

				if (vardata2 != "0")
				{
					string[] varStr = vardata2.Split(',');

					for (int i = 0; i < varStr.Length; i++)
					{
						if (chkLanguageKnown.Items.Count > 0)
						{
							for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
							{
								if (chkLanguageKnown.Items[inti].Value == varStr[i])
								{
									chkLanguageKnown.Items[inti].Selected = true;
								}

							}
						}
					}
				}

				string vardata8 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(ImpairmentID AS Varchar)  FROM SIStudentTypeofImpairmentDetails Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
										 "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

				objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName,1 as id FROM MTImpairmentMaster  WHERE ImpairmentID<>0 AND ImpairmentID IN (select * from [fnSplit] ('" + vardata8 + "',',')) union Select ImpairmentID,Impairment As ImpairmentName,2 as id From MTImpairmentMaster WHERE ImpairmentID<>0  AND ImpairmentID NOT IN (select * from [fnSplit] ('" + vardata8 + "',',')) ORDER BY id ", "ImpairmentID", "ImpairmentName", "");

				if (vardata8 != "0")
				{
					string[] varStr1 = vardata8.Split(',');
					for (int i = 0; i < varStr1.Length; i++)
					{
						if (chkImpairment.Items.Count > 0)
						{
							for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
							{
								if (chkImpairment.Items[inti].Value == varStr1[i])
								{
									chkImpairment.Items[inti].Selected = true;
								}

							}
						}
					}
				}
				fBusRouteDetails(intStudentID);
				//ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>fBusRouteDetails(" + intStudentID + ");</script>");


				/*-----------------------End of Modified By Manju on 29-05-2012-----------------------------------------------------*/


				/*----------Added By Manju on 29-05-2012------------------*/

				if (hdnFindSearch.Value == "F")
				{
					ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\" type=\"text/javascript\">" + strfindShowID + "</script>");
				}
			}
			if (hdnFlag.Value != "PID")
			{
				hdnFlag.Value = "A";
			}
			//else
			//{
			//    ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pHandleOnEdit();</script>");
			//}
		}
		//Added By Archana For fee no wise Searching****//

		if (btnNew.Enabled == true && (txtFeeNo.Text.Trim() != ""))
		{
			if ((txtFeeNo.Text.Trim() != "") && (hdnAdmNo.Value == ""))
			{

				intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE FeeNo='" + txtFeeNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
				int pParentID = objCCWeb.ReturnNumericValue("SELECT ParentID FROM SIStudentMaster WHERE StudentID=" + intStudentID + "");

				if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentYearWiseDetails where FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "' AND AcaStart=" + Session["AcaStart"] + "  AND SchoolID=" + Session["SchoolID"] + "") <= 0)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('Fee No Does Not Exits..');callreturn();</script>");
					txtAdmNo.Focus();
					return;
				}
				if (txtParentID.Text.Trim().Replace("'", "''") != "")
				{
					if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentMaster SM INNER JOIN SIStudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' ") <= 0)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('ParentID Does Not Exits..');callreturn();</script>");
						txtParentID.Focus();
						return;
					}
					pParentID = Convert.ToInt32(txtParentID.Text.Trim());
				}

				if (objCCWeb.ReturnNumericValue("Select Count(*) From Sistudentyearwisedetails where FeeNo='" + txtFeeNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "") > 1)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>callreturn();</script>");
					txtAdmNo.Focus();

					return;
				}

				strResult = pGetStudentDetails(intStudentID);
				if ((strResult == "") || (strResult == "null"))
				{
					return;
				}
				string[] strArray1 = strResult.Split('^');
				hdnSImagePath.Value = "";
				imgStudent.ImageUrl = "StudentPhoto/S" + strArray1[0] + ".jpg";
				if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + strArray1[0] + ".GIF") == true)
				{
					imgQRCode.ImageUrl = "~/QRCodeImage/Q" + strArray1[0] + ".GIF";
					imgQRCode.Visible = true;
				}
				else
				{
					imgQRCode.Visible = false;
				}
				hdntxtStuSelect.Value = strArray1[0];
				hdnSDID.Value = strArray1[0];
				txtFirstName.Text = strArray1[1];
				txtMiddleName.Text = strArray1[2];
				txtLastName.Text = strArray1[3];
				txtArabicName.Text = strArray1[4];
				if (strArray1[5].ToString() == "M")
				{
					rbtnMale.Checked = true;
				}
				else
				{
					rbtnFemale.Checked = true;
				}
				txtStuDOB.Text = strArray1[6];
				txtDOA.Text = strArray1[7];
				ddlAdmittedClass.SelectedValue = strArray1[8];
				ddlSocCategory.SelectedValue = strArray1[9];

				ddlReligion.SelectedValue = strArray1[10];
				// ddlCaste.SelectedValue = strArray1[11];
				txtStuEmergencyNo.Text = strArray1[12];
				txtStuEmail.Text = strArray1[13];
				ddlBloodGroup.SelectedValue = strArray1[14];
				ddlNationality.SelectedValue = strArray1[15];
				ddlMotherTongue.SelectedValue = strArray1[16];
				if (pParentID != Convert.ToInt32(strArray1[17]))
				{
					txtParentID.Text = pParentID.ToString();
				}
				else
				{
					txtParentID.Text = strArray1[17];
				}
				txtSiqmano.Text = strArray1[18];
				txtNoOfChild.Text = strArray1[19];
				txtPositionChild.Text = strArray1[20];
				txtAdmNo.Text = strArray1[21];
				txtFeeNo.Text = strArray1[22];
				ddlClass.SelectedValue = strArray1[23];
				ddlSection.SelectedValue = strArray1[24];
				lblCaption1.Text = "Strength";
				strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S' and SYD.ClassID='" + strArray1[23] + "' and SYD.SectionID='" + strArray1[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");
				lblClassStrength.Text = "Class : " + "" + strClassStrength;

				strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

				lblTotalStrength.Text = "School : " + "" + strSchoolStrength;

				if (strArray1[25].ToString() == "N")
				{
					rbtnAdmissionNew.Checked = true;
				}
				else
				{
					rbtnAdmissionOld.Checked = true;
				}
				txtRollNo.Text = strArray1[26];
				ddlHouse.SelectedValue = strArray1[27];
				ddlBoard.SelectedValue = strArray1[28];
				txtBoardRegNo.Text = strArray1[29];
				ddlBoardingCategory.SelectedValue = strArray1[30];
				// ddlStop.SelectedValue = strArray1[67];
				txtChildCode.Text = strArray1[31];
				txtRemarks.Text = strArray1[32];
				txtPresAddress.Text = strArray1[33];
				hdntxtResiCity.Value = strArray1[34];
				txtPresPincode.Text = strArray1[35];
				txtPresPhone.Text = strArray1[36];
				txtPerAddress.Text = strArray1[37];
				hdntxtPerCity.Value = strArray1[38];
				txtPerPincode.Text = strArray1[39];
				txtPerPhone.Text = strArray1[40];
				txtResiCity.Text = strArray1[41];
				txtPresState.Text = strArray1[42];
				txtPresCountry.Text = strArray1[43];
				txtPerCity.Text = strArray1[44];
				txtPerState.Text = strArray1[45];
				txtPerCountry.Text = strArray1[46];
				ddlFTitle.SelectedValue = strArray1[47];
				txtFName.Text = strArray1[48];
				ddlMTitle.SelectedValue = strArray1[49];
				txtMName.Text = strArray1[50];
				ddlFeeGroup.SelectedValue = strArray1[51];


				ddlFeeApplnFrom.SelectedValue = strArray1[52];

				if (strArray1[53].ToString() == "T")
				{
					hidStatusdisplay.Value = "T";
					imgATD.ImageUrl = "~/Images/Present.png";
					// lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
				}
				else if (strArray1[53].ToString() == "D")
				{
					hidStatusdisplay.Value = "D";
					imgATD.ImageUrl = "~/Images/Absent.png";
					//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
				}
				else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
				  "  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
				  " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
				  " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + strArray1[0] + " ") > 0)
				{
					hidStatusdisplay.Value = "R";
					imgATD.ImageUrl = "~/Images/HalfDay.png";
					// lblStudentStatus.Text = "Repeater";
				}
				else
				{
					// imgATD.ImageUrl = "~/Images/1Present.png";
					//lblStudentStatus.Text = "";
				}
				txtSiqmaExpiryDate.Text = strArray1[54];
				ddlConcessionType.SelectedValue = strArray1[55];
				if (strArray1[56] != "0")
				{
					ddlMeal.SelectedValue = strArray1[56];
				}

				if (strArray1[57] == "")
				{
					ddlSchoolBus.SelectedValue = "";
				}
				else
				{
					ddlSchoolBus.SelectedValue = strArray1[57];
				}
				ddlSecondLanguage.SelectedValue = strArray1[58];
				ddlThirdLanguage.SelectedValue = strArray1[59];
				ddlStuLiving.SelectedValue = strArray1[60];

				//if (strArray1[60] == "")
				//{
				//    ddlStuLiving.SelectedValue = "";
				//}
				//else
				//{
				//    ddlStuLiving.SelectedValue = strArray1[60];
				//}
				if (strArray1[61].ToString() == "Y")
				{
					rbtProvYes.Checked = true;
				}
				else
				{
					rbtProvNo.Checked = true;
				}
				txtDateOFJoin.Text = strArray1[62];
				txtLiveEduID.Text = strArray1[63];


				txtCBSERollNo.Text = strArray1[65];
				ddlStream.SelectedValue = (strArray1[66] == "" ? "0" : strArray1[66]);
				txtCaste.Text = strArray1[68];

				if (strArray1[69].ToString() == "Y")
				{
					rbtnFreeShipYes.Checked = true;
				}
				else
				{
					rbtnFreeShipNo.Checked = true;
				}
                txtGGNNo.Text = strArray1[70];
				gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intStudentID + "");
				gvEmergencyContact.DataBind();




				gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intStudentID + "");
				gvAuthorisedPickUp.DataBind();



				//fillGrid('gvDocuments',"SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName<%=Session["Type"] %>  AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
				//          " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as MPath  " +
				//          " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID="+varStudent[0]+"    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");

				gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
								  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgPath  " +
								  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
				gvDocuments.DataBind();


				//ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


				if (pParentID != Convert.ToInt32(strArray1[17]))
				{
					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
					" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + pParentID + "    AND  " +
					"  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();
					hdnFlag.Value = "PID";

				}
				else
				{
					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
					" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + strArray1[17] + "    AND  " +
					"  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();

				}


				gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intStudentID + "");
				gvPreviousEducation.DataBind();




				/*-----------------------Modified By Manju on 29-05-2012-----------------------------------------------------*/
				string vardata2 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
										  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

				objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata2 + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata2 + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

				if (vardata2 != "0")
				{
					string[] varStr = vardata2.Split(',');

					for (int i = 0; i < varStr.Length; i++)
					{
						if (chkLanguageKnown.Items.Count > 0)
						{
							for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
							{
								if (chkLanguageKnown.Items[inti].Value == varStr[i])
								{
									chkLanguageKnown.Items[inti].Selected = true;
								}

							}
						}
					}
				}

				string vardata8 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(ImpairmentID AS Varchar)  FROM SIStudentTypeofImpairmentDetails Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
										 "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

				objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName,1 as id FROM MTImpairmentMaster  WHERE ImpairmentID<>0 AND ImpairmentID IN (select * from [fnSplit] ('" + vardata8 + "',',')) union Select ImpairmentID,Impairment As ImpairmentName,2 as id From MTImpairmentMaster WHERE ImpairmentID<>0  AND ImpairmentID NOT IN (select * from [fnSplit] ('" + vardata8 + "',',')) ORDER BY id ", "ImpairmentID", "ImpairmentName", "");

				if (vardata8 != "0")
				{
					string[] varStr1 = vardata8.Split(',');
					for (int i = 0; i < varStr1.Length; i++)
					{
						if (chkImpairment.Items.Count > 0)
						{
							for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
							{
								if (chkImpairment.Items[inti].Value == varStr1[i])
								{
									chkImpairment.Items[inti].Selected = true;
								}

							}
						}
					}
				}
				fBusRouteDetails(intStudentID);
				//ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>fBusRouteDetails(" + intStudentID + ");</script>");


				/*-----------------------End of Modified By Manju on 29-05-2012-----------------------------------------------------*/


				/*----------Added By Manju on 29-05-2012------------------*/

				if (hdnFindSearch.Value == "F")
				{
					ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\" type=\"text/javascript\">" + strfindShowID + "</script>");
				}
			}
			if (hdnFlag.Value != "PID")
			{
				hdnFlag.Value = "A";
			}
			//else
			//{
			//    ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pHandleOnEdit();</script>");
			//}
		}

		//End by archana

		if ((btnNew.Enabled == true) && (txtAdmNo.Text.Trim() != "") && (txtStuSelect.Text != ""))
		{


			if ((txtAdmNo.Text.Trim() != "") && (hdnAdmNo.Value == ""))
			{
				intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE AdmissionNo='" + txtAdmNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
				int pParentID = objCCWeb.ReturnNumericValue("SELECT ParentID FROM SIStudentMaster WHERE StudentID=" + intStudentID + "");
				if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentYearWiseDetails where AdmissionNo='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' AND AcaStart=" + Session["AcaStart"] + "  AND SchoolID=" + Session["SchoolID"] + "") <= 0)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('Admission No Does Not Exits..');callreturn();</script>");
					txtAdmNo.Focus();
					return;
				}
				if (txtParentID.Text.Trim().Replace("'", "''") != "")
				{
					if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentMaster SM INNER JOIN SIStudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' ") <= 0)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('ParentID Does Not Exits..');callreturn();</script>");
						txtParentID.Focus();
						return;
					}
					pParentID = Convert.ToInt32(txtParentID.Text.Trim());

				}


				strResult = pGetStudentDetails(intStudentID);
				if ((strResult == "") || (strResult == "null"))
				{
					return;
				}
				string[] strArray1 = strResult.Split('^');
				hdnSImagePath.Value = "";
				imgStudent.ImageUrl = "StudentPhoto/S" + strArray1[0] + ".jpg";
				if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + strArray1[0] + ".GIF") == true)
				{
					imgQRCode.ImageUrl = "~/QRCodeImage/Q" + strArray1[0] + ".GIF";
					imgQRCode.Visible = true;
				}
				else
				{
					imgQRCode.Visible = false;
				}
				hdntxtStuSelect.Value = strArray1[0];
				hdnSDID.Value = strArray1[0];
				txtFirstName.Text = strArray1[1];
				txtMiddleName.Text = strArray1[2];
				txtLastName.Text = strArray1[3];
				txtArabicName.Text = strArray1[4];
				if (strArray1[5].ToString() == "M")
				{
					rbtnMale.Checked = true;
				}
				else
				{
					rbtnFemale.Checked = true;
				}
				txtStuDOB.Text = strArray1[6];
				txtDOA.Text = strArray1[7];
				ddlAdmittedClass.SelectedValue = strArray1[8];
				ddlSocCategory.SelectedValue = strArray1[9];

				ddlReligion.SelectedValue = strArray1[10];
				// ddlCaste.SelectedValue = strArray1[11];
				txtStuEmergencyNo.Text = strArray1[12];
				txtStuEmail.Text = strArray1[13];
				ddlBloodGroup.SelectedValue = strArray1[14];
				ddlNationality.SelectedValue = strArray1[15];
				ddlMotherTongue.SelectedValue = strArray1[16];
				if (pParentID != Convert.ToInt32(strArray1[17]))
				{
					txtParentID.Text = pParentID.ToString();
				}
				else
				{
					txtParentID.Text = strArray1[17];
				}
				//txtParentID.Text = strArray1[17];
				txtSiqmano.Text = strArray1[18];
				txtNoOfChild.Text = strArray1[19];
				txtPositionChild.Text = strArray1[20];
				txtAdmNo.Text = strArray1[21];
				txtFeeNo.Text = strArray1[22];
				ddlClass.SelectedValue = strArray1[23];
				ddlSection.SelectedValue = strArray1[24];

				lblCaption1.Text = "Strength";
				strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S' and SYD.ClassID='" + strArray1[23] + "' and SYD.SectionID='" + strArray1[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");
				lblClassStrength.Text = "Class : " + "" + strClassStrength;


				strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

				lblTotalStrength.Text = "School : " + "" + strSchoolStrength;
				if (strArray1[25].ToString() == "N")
				{
					rbtnAdmissionNew.Checked = true;
				}
				else
				{
					rbtnAdmissionOld.Checked = true;
				}
				txtRollNo.Text = strArray1[26];
				ddlHouse.SelectedValue = strArray1[27];
				ddlBoard.SelectedValue = strArray1[28];
				txtBoardRegNo.Text = strArray1[29];
				ddlBoardingCategory.SelectedValue = strArray1[30];
				// ddlStop.SelectedValue = strArray1[67];
				txtChildCode.Text = strArray1[31];
				txtRemarks.Text = strArray1[32];
				txtPresAddress.Text = strArray1[33];
				hdntxtResiCity.Value = strArray1[34];
				txtPresPincode.Text = strArray1[35];
				txtPresPhone.Text = strArray1[36];
				txtPerAddress.Text = strArray1[37];
				hdntxtPerCity.Value = strArray1[38];
				txtPerPincode.Text = strArray1[39];
				txtPerPhone.Text = strArray1[40];
				txtResiCity.Text = strArray1[41];
				txtPresState.Text = strArray1[42];
				txtPresCountry.Text = strArray1[43];
				txtPerCity.Text = strArray1[44];
				txtPerState.Text = strArray1[45];
				txtPerCountry.Text = strArray1[46];
				ddlFTitle.SelectedValue = strArray1[47];
				txtFName.Text = strArray1[48];
				ddlMTitle.SelectedValue = strArray1[49];
				txtMName.Text = strArray1[50];
				ddlFeeGroup.SelectedValue = strArray1[51];


				ddlFeeApplnFrom.SelectedValue = strArray1[52];

				if (strArray1[53].ToString() == "T")
				{
					hidStatusdisplay.Value = "T";
					imgATD.ImageUrl = "~/Images/Present.png";
					// lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
				}
				else if (strArray1[53].ToString() == "D")
				{
					hidStatusdisplay.Value = "D";
					imgATD.ImageUrl = "~/Images/Absent.png";
					// lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
				}
				//Archana
				else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
						"  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
						" WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
						" WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + strArray1[0] + " ") > 0)
				{
					hidStatusdisplay.Value = "R";
					imgATD.ImageUrl = "~/Images/HalfDay.png";
					// lblStudentStatus.Text = "Repeater";
				}
				else
				{
					//imgATD.ImageUrl = "~/Images/1Present.png";
					// lblStudentStatus.Text = "";
				}
				txtSiqmaExpiryDate.Text = strArray1[54];
				ddlConcessionType.SelectedValue = strArray1[55];
				if (strArray1[56] != "0")
				{
					ddlMeal.SelectedValue = strArray1[56];
				}

				if (strArray1[57] == "")
				{
					ddlSchoolBus.SelectedValue = "";
				}
				else
				{
					ddlSchoolBus.SelectedValue = strArray1[57];
				}
				ddlSecondLanguage.SelectedValue = strArray1[58];
				ddlThirdLanguage.SelectedValue = strArray1[59];
				ddlStuLiving.SelectedValue = strArray1[60];

				//if (strArray1[60] == "")
				//{
				//    ddlStuLiving.SelectedValue = "";
				//}
				//else
				//{
				//    ddlStuLiving.SelectedValue = strArray1[60];
				//}
				if (strArray1[61].ToString() == "Y")
				{
					rbtProvYes.Checked = true;
				}
				else
				{
					rbtProvNo.Checked = true;
				}
				txtDateOFJoin.Text = strArray1[62];
				txtLiveEduID.Text = strArray1[63];


				txtCBSERollNo.Text = strArray1[65];
				ddlStream.SelectedValue = (strArray1[66] == "" ? "0" : strArray1[66]);
				txtCaste.Text = strArray1[68];
				if (strArray1[69].ToString() == "Y")
				{
					rbtnFreeShipYes.Checked = true;
				}
				else
				{
					rbtnFreeShipNo.Checked = true;
				}
                txtGGNNo.Text = strArray1[70];
				gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intStudentID + "");
				gvEmergencyContact.DataBind();




				gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intStudentID + "");
				gvAuthorisedPickUp.DataBind();



				//fillGrid('gvDocuments',"SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName<%=Session["Type"] %>  AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
				//          " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as MPath  " +
				//          " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID="+varStudent[0]+"    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");

				gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
								  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgPath  " +
								  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
				gvDocuments.DataBind();


				ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");

				if (pParentID != Convert.ToInt32(strArray1[17]))
				{

					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
					" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + pParentID + "    AND  " +
				 "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();
					hdnFlag.Value = "PID";
				}
				else
				{
					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
					 " INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + strArray1[17] + "    AND  " +
				  "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();

				}


				gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intStudentID + "");
				gvPreviousEducation.DataBind();




				/*-----------------------Modified By Manju on 29-05-2012-----------------------------------------------------*/
				string vardata2 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
										  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

				objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata2 + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata2 + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

				if (vardata2 != "0")
				{
					string[] varStr = vardata2.Split(',');

					for (int i = 0; i < varStr.Length; i++)
					{
						if (chkLanguageKnown.Items.Count > 0)
						{
							for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
							{
								if (chkLanguageKnown.Items[inti].Value == varStr[i])
								{
									chkLanguageKnown.Items[inti].Selected = true;
								}

							}
						}
					}
				}
				string vardata8 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(ImpairmentID AS Varchar)  FROM SIStudentTypeofImpairmentDetails Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
										 "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

				objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName,1 as id FROM MTImpairmentMaster  WHERE ImpairmentID<>0 AND ImpairmentID IN (select * from [fnSplit] ('" + vardata8 + "',',')) union Select ImpairmentID,Impairment As ImpairmentName,2 as id From MTImpairmentMaster WHERE ImpairmentID<>0  AND ImpairmentID NOT IN (select * from [fnSplit] ('" + vardata8 + "',',')) ORDER BY id ", "ImpairmentID", "ImpairmentName", "");

				if (vardata8 != "0")
				{
					string[] varStr1 = vardata8.Split(',');
					for (int i = 0; i < varStr1.Length; i++)
					{
						if (chkImpairment.Items.Count > 0)
						{
							for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
							{
								if (chkImpairment.Items[inti].Value == varStr1[i])
								{
									chkImpairment.Items[inti].Selected = true;
								}

							}
						}
					}
				}
				fBusRouteDetails(intStudentID);
				//ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>fBusRouteDetails(" + intStudentID + ");</script>");


				/*-----------------------End of Modified By Manju on 29-05-2012-----------------------------------------------------*/


				/*----------Added By Manju on 29-05-2012------------------*/

				if (hdnFindSearch.Value == "F")
				{
					ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\" type=\"text/javascript\">" + strfindShowID + "</script>");
				}

			}
			if (hdnFlag.Value != "PID")
			{
				hdnFlag.Value = "A";
			}
			//else
			//{
			//    ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pHandleOnEdit();</script>");
			//}
		}
		////Added by Archana**********8

		if ((btnNew.Enabled == true) && (txtFeeNo.Text.Trim() != "") && (txtStuSelect.Text != ""))
		{


			if ((txtFeeNo.Text.Trim() != "") && (hdnAdmNo.Value == ""))
			{
				intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE FeeNo='" + txtFeeNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
				int pParentID = objCCWeb.ReturnNumericValue("SELECT ParentID FROM SIStudentMaster WHERE StudentID=" + intStudentID + "");
				if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentYearWiseDetails where FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "' AND AcaStart=" + Session["AcaStart"] + "  AND SchoolID=" + Session["SchoolID"] + "") <= 0)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('Fee No Does Not Exits..');callreturn();</script>");
					txtAdmNo.Focus();
					return;
				}
				if (txtParentID.Text.Trim().Replace("'", "''") != "")
				{
					if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentMaster SM INNER JOIN SIStudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' ") <= 0)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('ParentID Does Not Exits..');callreturn();</script>");
						txtParentID.Focus();
						return;
					}
					pParentID = Convert.ToInt32(txtParentID.Text.Trim());

				}


				strResult = pGetStudentDetails(intStudentID);
				if ((strResult == "") || (strResult == "null"))
				{
					return;
				}
				string[] strArray1 = strResult.Split('^');
				hdnSImagePath.Value = "";
				imgStudent.ImageUrl = "StudentPhoto/S" + strArray1[0] + ".jpg";
				if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + strArray1[0] + ".GIF") == true)
				{
					imgQRCode.ImageUrl = "~/QRCodeImage/Q" + strArray1[0] + ".GIF";
					imgQRCode.Visible = true;
				}
				else
				{
					imgQRCode.Visible = false;
				}
				hdntxtStuSelect.Value = strArray1[0];
				hdnSDID.Value = strArray1[0];
				txtFirstName.Text = strArray1[1];
				txtMiddleName.Text = strArray1[2];
				txtLastName.Text = strArray1[3];
				txtArabicName.Text = strArray1[4];
				if (strArray1[5].ToString() == "M")
				{
					rbtnMale.Checked = true;
				}
				else
				{
					rbtnFemale.Checked = true;
				}
				txtStuDOB.Text = strArray1[6];
				txtDOA.Text = strArray1[7];
				ddlAdmittedClass.SelectedValue = strArray1[8];
				ddlSocCategory.SelectedValue = strArray1[9];

				ddlReligion.SelectedValue = strArray1[10];
				// ddlCaste.SelectedValue = strArray1[11];
				txtStuEmergencyNo.Text = strArray1[12];
				txtStuEmail.Text = strArray1[13];
				ddlBloodGroup.SelectedValue = strArray1[14];
				ddlNationality.SelectedValue = strArray1[15];
				ddlMotherTongue.SelectedValue = strArray1[16];
				if (pParentID != Convert.ToInt32(strArray1[17]))
				{
					txtParentID.Text = pParentID.ToString();
				}
				else
				{
					txtParentID.Text = strArray1[17];
				}
				//txtParentID.Text = strArray1[17];
				txtSiqmano.Text = strArray1[18];
				txtNoOfChild.Text = strArray1[19];
				txtPositionChild.Text = strArray1[20];
				txtAdmNo.Text = strArray1[21];
				txtFeeNo.Text = strArray1[22];
				ddlClass.SelectedValue = strArray1[23];
				ddlSection.SelectedValue = strArray1[24];
				lblCaption1.Text = "Strength";
				strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S' and SYD.ClassID='" + strArray1[23] + "' and SYD.SectionID='" + strArray1[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");
				lblClassStrength.Text = "Class : " + "" + strClassStrength;

				strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

				lblTotalStrength.Text = "School : " + "" + strSchoolStrength;

				if (strArray1[25].ToString() == "N")
				{
					rbtnAdmissionNew.Checked = true;
				}
				else
				{
					rbtnAdmissionOld.Checked = true;
				}
				txtRollNo.Text = strArray1[26];
				ddlHouse.SelectedValue = strArray1[27];
				ddlBoard.SelectedValue = strArray1[28];
				txtBoardRegNo.Text = strArray1[29];
				ddlBoardingCategory.SelectedValue = strArray1[30];
				// ddlStop.SelectedValue = strArray1[67];
				txtChildCode.Text = strArray1[31];
				txtRemarks.Text = strArray1[32];
				txtPresAddress.Text = strArray1[33];
				hdntxtResiCity.Value = strArray1[34];
				txtPresPincode.Text = strArray1[35];
				txtPresPhone.Text = strArray1[36];
				txtPerAddress.Text = strArray1[37];
				hdntxtPerCity.Value = strArray1[38];
				txtPerPincode.Text = strArray1[39];
				txtPerPhone.Text = strArray1[40];
				txtResiCity.Text = strArray1[41];
				txtPresState.Text = strArray1[42];
				txtPresCountry.Text = strArray1[43];
				txtPerCity.Text = strArray1[44];
				txtPerState.Text = strArray1[45];
				txtPerCountry.Text = strArray1[46];
				ddlFTitle.SelectedValue = strArray1[47];
				txtFName.Text = strArray1[48];
				ddlMTitle.SelectedValue = strArray1[49];
				txtMName.Text = strArray1[50];
				ddlFeeGroup.SelectedValue = strArray1[51];


				ddlFeeApplnFrom.SelectedValue = strArray1[52];

				if (strArray1[53].ToString() == "T")
				{
					hidStatusdisplay.Value = "T";
					imgATD.ImageUrl = "~/Images/Present.png";
					//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
				}
				else if (strArray1[53].ToString() == "D")
				{
					hidStatusdisplay.Value = "D";
					imgATD.ImageUrl = "~/Images/Absent.png";
					// lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
				}
				else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
					 "  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
					 " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
					 " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + strArray1[0] + " ") > 0)
				{
					hidStatusdisplay.Value = "R";
					// lblStudentStatus.Text = "Repeater";
					imgATD.ImageUrl = "~/Images/HalfDay.png";
				}
				else
				{
					// imgATD.ImageUrl = "~/Images/1Present.png";
					// lblStudentStatus.Text = "";
				}
				txtSiqmaExpiryDate.Text = strArray1[54];
				ddlConcessionType.SelectedValue = strArray1[55];
				if (strArray1[56] != "0")
				{
					ddlMeal.SelectedValue = strArray1[56];
				}

				if (strArray1[57] == "")
				{
					ddlSchoolBus.SelectedValue = "";
				}
				else
				{
					ddlSchoolBus.SelectedValue = strArray1[57];
				}
				ddlSecondLanguage.SelectedValue = strArray1[58];
				ddlThirdLanguage.SelectedValue = strArray1[59];
				ddlStuLiving.SelectedValue = strArray1[60];

				//if (strArray1[60] == "")
				//{
				//    ddlStuLiving.SelectedValue = "";
				//}
				//else
				//{
				//    ddlStuLiving.SelectedValue = strArray1[60];
				//}
				if (strArray1[61].ToString() == "Y")
				{
					rbtProvYes.Checked = true;
				}
				else
				{
					rbtProvNo.Checked = true;
				}
				txtDateOFJoin.Text = strArray1[62];
				txtLiveEduID.Text = strArray1[63];


				txtCBSERollNo.Text = strArray1[65];
				ddlStream.SelectedValue = (strArray1[66] == "" ? "0" : strArray1[66]);
				txtCaste.Text = strArray1[68];
				if (strArray1[69].ToString() == "Y")
				{
					rbtnFreeShipYes.Checked = true;
				}
				else
				{
					rbtnFreeShipNo.Checked = true;
				}
                txtGGNNo.Text = strArray1[70];
				gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intStudentID + "");
				gvEmergencyContact.DataBind();




				gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intStudentID + "");
				gvAuthorisedPickUp.DataBind();



				//fillGrid('gvDocuments',"SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName<%=Session["Type"] %>  AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
				//          " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as MPath  " +
				//          " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID="+varStudent[0]+"    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");

				gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
								  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgPath  " +
								  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
				gvDocuments.DataBind();


				ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");

				if (pParentID != Convert.ToInt32(strArray1[17]))
				{

					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
					" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + pParentID + "    AND  " +
				 "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();
					hdnFlag.Value = "PID";
				}
				else
				{
					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
					 " INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + strArray1[17] + "    AND  " +
				  "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();

				}


				gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intStudentID + "");
				gvPreviousEducation.DataBind();




				/*-----------------------Modified By Manju on 29-05-2012-----------------------------------------------------*/
				string vardata2 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
										  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

				objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata2 + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata2 + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

				if (vardata2 != "0")
				{
					string[] varStr = vardata2.Split(',');

					for (int i = 0; i < varStr.Length; i++)
					{
						if (chkLanguageKnown.Items.Count > 0)
						{
							for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
							{
								if (chkLanguageKnown.Items[inti].Value == varStr[i])
								{
									chkLanguageKnown.Items[inti].Selected = true;
								}

							}
						}
					}
				}
				string vardata8 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(ImpairmentID AS Varchar)  FROM SIStudentTypeofImpairmentDetails Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
										 "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

				objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName,1 as id FROM MTImpairmentMaster  WHERE ImpairmentID<>0 AND ImpairmentID IN (select * from [fnSplit] ('" + vardata8 + "',',')) union Select ImpairmentID,Impairment As ImpairmentName,2 as id From MTImpairmentMaster WHERE ImpairmentID<>0  AND ImpairmentID NOT IN (select * from [fnSplit] ('" + vardata8 + "',',')) ORDER BY id ", "ImpairmentID", "ImpairmentName", "");

				if (vardata8 != "0")
				{
					string[] varStr1 = vardata8.Split(',');
					for (int i = 0; i < varStr1.Length; i++)
					{
						if (chkImpairment.Items.Count > 0)
						{
							for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
							{
								if (chkImpairment.Items[inti].Value == varStr1[i])
								{
									chkImpairment.Items[inti].Selected = true;
								}

							}
						}
					}
				}
				fBusRouteDetails(intStudentID);
				//ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>fBusRouteDetails(" + intStudentID + ");</script>");


				/*-----------------------End of Modified By Manju on 29-05-2012-----------------------------------------------------*/


				/*----------Added By Manju on 29-05-2012------------------*/

				if (hdnFindSearch.Value == "F")
				{
					ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\" type=\"text/javascript\">" + strfindShowID + "</script>");
				}

			}
			if (hdnFlag.Value != "PID")
			{
				hdnFlag.Value = "A";
			}
			//else
			//{
			//    ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pHandleOnEdit();</script>");
			//}
		}


		//END by Archana

		//Added By archana****8
		if ((txtParentID.Text.Trim() != "") && (hdnAdmNo.Value == "") && txtFeeNo.Text.Trim() == "")
		{

			//string Fee = objCCWeb.ReturnSingleValue("Select Feeno from sistudentmaster sm inner join sistudentyearwisedetails yd on yd.studentid=sm.studentid where Parentd");

			if (objCCWeb.ReturnNumericValue("SELECT ISNUMERIC ('" + txtParentID.Text.Trim().Replace("'", "''") + "')").ToString() == "0")
			{
				ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert(' Please Enter ParentID or Select Parent Name From List..');callreturn();</script>");
				txtParentID.Focus();
				return;

			}

			if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'") <= 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('ParentID Does Not Exits..');callreturn();</script>");
				txtParentID.Focus();
				return;
			}
			if (btnNew.Enabled == false)
			{
				if (objCCWeb.ReturnNumericValue("Select Count(*) From SIStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'") > 0)
				{
					int intParentID = Convert.ToInt32(txtParentID.Text.Trim().Replace("'", "''"));
					strResult = pGetSiblingDetails(intParentID);
					if ((strResult == "") || (strResult == "null"))
					{
						return;
					}
					string[] varStudent = strResult.Split('^');
					hdntxtStuSelect.Value = varStudent[0];
					hdnSDID.Value = varStudent[0];
					ddlReligion.SelectedValue = varStudent[1];
					//ddlCaste.SelectedValue = varStudent[2];
					ddlNationality.SelectedValue = varStudent[3];
					ddlMotherTongue.SelectedValue = varStudent[4];
					txtNoOfChild.Text = varStudent[5];
					txtChildCode.Text = varStudent[6];
					txtPresAddress.Text = varStudent[7];
					hdntxtResiCity.Value = varStudent[8];
					txtPresPincode.Text = varStudent[9];
					txtPresPhone.Text = varStudent[10];
					txtPerAddress.Text = varStudent[11];
					hdntxtPerCity.Value = varStudent[12];
					txtPerPincode.Text = varStudent[13];
					txtPerPhone.Text = varStudent[14];
					txtResiCity.Text = varStudent[15];
					txtPresState.Text = varStudent[16];
					txtPresCountry.Text = varStudent[17];
					txtPerCity.Text = varStudent[18];
					txtPerState.Text = varStudent[19];
					txtPerCountry.Text = varStudent[20];
					txtParentID.Text = varStudent[21];
					ddlFTitle.SelectedValue = varStudent[23];
					txtFName.Text = varStudent[24];
					ddlMTitle.SelectedValue = varStudent[25];
					txtMName.Text = varStudent[26];
					if (varStudent[29] == "T")
					{
						hidStatusdisplay.Value = "T";
						imgATD.ImageUrl = "~/Images/Present.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
					}
					else if (varStudent[29] == "D")
					{
						hidStatusdisplay.Value = "D";
						imgATD.ImageUrl = "~/Images/Absent.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "  FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
					}
					else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
					 "  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
					 " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
					 " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + varStudent[0] + " ") > 0)
					{
						hidStatusdisplay.Value = "R";
						imgATD.ImageUrl = "~/Images/HalfDay.png";
						//lblStudentStatus.Text = "Repeater";
					}
					else
					{
						//imgATD.ImageUrl = "~/Images/1Present.png";
						// lblStudentStatus.Text = "";
					}
					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
						   " INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + intParentID + "    AND  " +
						"  SYWD.SchoolID=" + Session["SchoolID"] + "AND SYWD.AcaStart=" + Session["AcaStart"] + "  ORDER BY SM.StudentID");
					gvSibling.DataBind();


				}
				hdnFlag.Value = "N^";
			}
			else
			{
				if ((objCCWeb.ReturnNumericValue("Select Count(*) From SIStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'")) > 0)
				{
					int intPStudentID = objCCWeb.ReturnNumericValue("SELECT Top 1 SM.StudentID FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID  " +
						" WHERE ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'  AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " Order by SM.StudentId ASC");

					strResult = pGetStudentDetails(intPStudentID);
					if ((strResult == "") || (strResult == "null"))
					{
						return;
					}
					string[] VarArray = strResult.Split('^');
					hdnSImagePath.Value = "";
					imgStudent.ImageUrl = "StudentPhoto/S" + VarArray[0] + ".jpg";
					if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + VarArray[0] + ".GIF") == true)
					{
						imgQRCode.ImageUrl = "~/QRCodeImage/Q" + VarArray[0] + ".GIF";

					}
					else
					{
						imgQRCode.Visible = false;
					}

					hdntxtStuSelect.Value = VarArray[0];
					hdnSDID.Value = VarArray[0];
					txtFirstName.Text = VarArray[1];
					txtMiddleName.Text = VarArray[2];
					txtLastName.Text = VarArray[3];
					txtArabicName.Text = VarArray[4];
					if (VarArray[5].ToString() == "M")
					{
						rbtnMale.Checked = true;
					}
					else
					{
						rbtnFemale.Checked = true;
					}
					txtStuDOB.Text = VarArray[6];
					txtDOA.Text = VarArray[7];
					ddlAdmittedClass.SelectedValue = VarArray[8];
					ddlSocCategory.SelectedValue = VarArray[9];

					ddlReligion.SelectedValue = VarArray[10];
					//ddlCaste.SelectedValue = VarArray[11];
					txtStuEmergencyNo.Text = VarArray[12];
					txtStuEmail.Text = VarArray[13];
					ddlBloodGroup.SelectedValue = VarArray[14];
					ddlNationality.SelectedValue = VarArray[15];
					ddlMotherTongue.SelectedValue = VarArray[16];
					txtParentID.Text = VarArray[17];
					txtSiqmano.Text = VarArray[18];
					txtNoOfChild.Text = VarArray[19];
					txtPositionChild.Text = VarArray[20];
					txtAdmNo.Text = VarArray[21];
					txtFeeNo.Text = VarArray[22];
					ddlClass.SelectedValue = VarArray[23];
					ddlSection.SelectedValue = VarArray[24];
					lblCaption1.Text = "Strength";
					strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S' and SYD.ClassID='" + VarArray[23] + "' and SYD.SectionID='" + VarArray[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");
					lblClassStrength.Text = "Class : " + "" + strClassStrength;


					strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				" where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

					lblTotalStrength.Text = "School : " + "" + strSchoolStrength;

					if (VarArray[25].ToString() == "N")
					{
						rbtnAdmissionNew.Checked = true;
					}
					else
					{
						rbtnAdmissionOld.Checked = true;
					}
					txtRollNo.Text = VarArray[26];
					ddlHouse.SelectedValue = VarArray[27];
					ddlBoard.SelectedValue = VarArray[28];
					txtBoardRegNo.Text = VarArray[29];
					ddlBoardingCategory.SelectedValue = VarArray[30];
					//ddlStop.SelectedValue = VarArray[67];
					txtChildCode.Text = VarArray[31];
					txtRemarks.Text = VarArray[32];
					txtPresAddress.Text = VarArray[33];
					hdntxtResiCity.Value = VarArray[34];
					txtPresPincode.Text = VarArray[35];
					txtPresPhone.Text = VarArray[36];
					txtPerAddress.Text = VarArray[37];
					hdntxtPerCity.Value = VarArray[38];
					txtPerPincode.Text = VarArray[39];
					txtPerPhone.Text = VarArray[40];
					txtResiCity.Text = VarArray[41];
					txtPresState.Text = VarArray[42];
					txtPresCountry.Text = VarArray[43];
					txtPerCity.Text = VarArray[44];
					txtPerState.Text = VarArray[45];
					txtPerCountry.Text = VarArray[46];
					ddlFTitle.SelectedValue = VarArray[47];
					txtFName.Text = VarArray[48];
					ddlMTitle.SelectedValue = VarArray[49];
					txtMName.Text = VarArray[50];
					ddlFeeGroup.SelectedValue = VarArray[51];
					ddlFeeApplnFrom.SelectedValue = VarArray[52];

					if (VarArray[53].ToString() == "T")
					{
						hidStatusdisplay.Value = "T";
						imgATD.ImageUrl = "~/Images/Present.png";
						// lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
					}
					else if (VarArray[53].ToString() == "D")
					{
						hidStatusdisplay.Value = "D";
						imgATD.ImageUrl = "~/Images/Absent.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
					}
					else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
				   "  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
				   " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
				   " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + VarArray[0] + " ") > 0)
					{
						hidStatusdisplay.Value = "R";
						imgATD.ImageUrl = "~/Images/HalfDay.png";
						//lblStudentStatus.Text = "Repeater";
					}
					else
					{
						//imgATD.ImageUrl = "~/Images/1Present.png";
						//lblStudentStatus.Text = "";
					}
					txtSiqmaExpiryDate.Text = VarArray[54];
					ddlConcessionType.SelectedValue = VarArray[55];
					if (VarArray[56] != "0")
					{
						ddlMeal.SelectedValue = VarArray[56];
					}

					if (VarArray[57] == "")
					{
						ddlSchoolBus.SelectedValue = "";
					}
					else
					{
						ddlSchoolBus.SelectedValue = VarArray[57];
					}
					ddlSecondLanguage.SelectedValue = VarArray[58];
					ddlThirdLanguage.SelectedValue = VarArray[59];
					ddlStuLiving.SelectedValue = VarArray[60];

					//if (VarArray[60] == "")
					//{
					//    ddlStuLiving.SelectedValue = "";
					//}
					//else
					//{
					//    ddlStuLiving.SelectedValue = VarArray[60];
					//}
					if (VarArray[61].ToString() == "Y")
					{
						rbtProvYes.Checked = true;
					}
					else
					{
						rbtProvNo.Checked = true;
					}
					txtDateOFJoin.Text = VarArray[62];
					txtLiveEduID.Text = VarArray[63];
					//ddlHomeAdvisor.SelectedValue = VarArray[66];


					txtCBSERollNo.Text = VarArray[65];
					txtCaste.Text = VarArray[68];

					if (VarArray[69].ToString() == "Y")
					{
						rbtnFreeShipYes.Checked = true;
					}
					else
					{
						rbtnFreeShipNo.Checked = true;
					}
                    txtGGNNo.Text = VarArray[70];
					gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intPStudentID + "");
					gvEmergencyContact.DataBind();


					gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intPStudentID + "");
					gvAuthorisedPickUp.DataBind();


					gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
									  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgpath  " +
									  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intPStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
					gvDocuments.DataBind();


					ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
						" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + VarArray[17] + "    AND  " +
					 "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();
					gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intPStudentID + "");
					gvPreviousEducation.DataBind();

					//objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 ORDER BY  MotherTongueName1", "MotherTongueID", "MotherTongueName", "");
					string vardata = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intPStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
											  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

					objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

					if (vardata != "0")
					{
						string[] varStr = vardata.Split(',');
						for (int i = 0; i < varStr.Length; i++)
						{
							if (chkLanguageKnown.Items.Count > 0)
							{
								for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
								{
									if (chkLanguageKnown.Items[inti].Value == varStr[i])
									{
										chkLanguageKnown.Items[inti].Selected = true;
									}

								}
							}
						}
					}


					string vardata8 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(ImpairmentID AS Varchar)  FROM SIStudentTypeofImpairmentDetails Where StudentID=" + intPStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
											 "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

					objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName,1 as id FROM MTImpairmentMaster  WHERE ImpairmentID<>0 AND ImpairmentID IN (select * from [fnSplit] ('" + vardata8 + "',',')) union Select ImpairmentID,Impairment As ImpairmentName,2 as id From MTImpairmentMaster WHERE ImpairmentID<>0  AND ImpairmentID NOT IN (select * from [fnSplit] ('" + vardata8 + "',',')) ORDER BY id ", "ImpairmentID", "ImpairmentName", "");

					if (vardata8 != "0")
					{
						string[] varStr1 = vardata8.Split(',');
						for (int i = 0; i < varStr1.Length; i++)
						{
							if (chkImpairment.Items.Count > 0)
							{
								for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
								{
									if (chkImpairment.Items[inti].Value == varStr1[i])
									{
										chkImpairment.Items[inti].Selected = true;
									}

								}
							}
						}
					}
				}
				intStudentID = objCCWeb.ReturnNumericValue("SELECT  SM.StudentID FROM SIStudentMaster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID = SYD.StudentID WHERE SM.ParentID='" + txtParentID.Text.Trim() + "' AND SYD.AcaStart=" + Session["AcaStart"] + " AND SYD.SchoolID=" + Session["SchoolID"] + "");
				hdnFlag.Value = "A";
			}
		}
		//END by archana
		if ((txtParentID.Text.Trim() != "") && (hdnAdmNo.Value == "") && txtAdmNo.Text.Trim() == "")
		{

			if (objCCWeb.ReturnNumericValue("SELECT ISNUMERIC ('" + txtParentID.Text.Trim().Replace("'", "''") + "')").ToString() == "0")
			{
				ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert(' Please Enter ParentID or Select Parent Name From List..');callreturn();</script>");
				txtParentID.Focus();
				return;

			}

			if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'") <= 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('ParentID Does Not Exits..');callreturn();</script>");
				txtParentID.Focus();
				return;
			}
			if (btnNew.Enabled == false)
			{
				if (objCCWeb.ReturnNumericValue("Select Count(*) From SIStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'") > 0)
				{
					int intParentID = Convert.ToInt32(txtParentID.Text.Trim().Replace("'", "''"));
					strResult = pGetSiblingDetails(intParentID);
					if ((strResult == "") || (strResult == "null"))
					{
						return;
					}
					string[] varStudent = strResult.Split('^');
					hdntxtStuSelect.Value = varStudent[0];
					hdnSDID.Value = varStudent[0];
					ddlReligion.SelectedValue = varStudent[1];
					//ddlCaste.SelectedValue = varStudent[2];
					ddlNationality.SelectedValue = varStudent[3];
					ddlMotherTongue.SelectedValue = varStudent[4];
					txtNoOfChild.Text = varStudent[5];
					txtChildCode.Text = varStudent[6];
					txtPresAddress.Text = varStudent[7];
					hdntxtResiCity.Value = varStudent[8];
					txtPresPincode.Text = varStudent[9];
					txtPresPhone.Text = varStudent[10];
					txtPerAddress.Text = varStudent[11];
					hdntxtPerCity.Value = varStudent[12];
					txtPerPincode.Text = varStudent[13];
					txtPerPhone.Text = varStudent[14];
					txtResiCity.Text = varStudent[15];
					txtPresState.Text = varStudent[16];
					txtPresCountry.Text = varStudent[17];
					txtPerCity.Text = varStudent[18];
					txtPerState.Text = varStudent[19];
					txtPerCountry.Text = varStudent[20];
					txtParentID.Text = varStudent[21];
					ddlFTitle.SelectedValue = varStudent[23];
					txtFName.Text = varStudent[24];
					ddlMTitle.SelectedValue = varStudent[25];
					txtMName.Text = varStudent[26];
					if (varStudent[29] == "T")
					{
						hidStatusdisplay.Value = "T";
						imgATD.ImageUrl = "~/Images/Present.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
					}
					else if (varStudent[29] == "D")
					{
						hidStatusdisplay.Value = "D";
						imgATD.ImageUrl = "~/Images/Absent.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "  FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
					}
					else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
							"  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
							" WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
							" WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + varStudent[0] + " ") > 0)
					{
						hidStatusdisplay.Value = "R";
						imgATD.ImageUrl = "~/Images/HalfDay.png";
						//  lblStudentStatus.Text = "Repeater";
					}
					else
					{
						//imgATD.ImageUrl = "~/Images/1Present.png";
						//lblStudentStatus.Text = "";
					}
					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
						   " INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + intParentID + "    AND  " +
						"  SYWD.SchoolID=" + Session["SchoolID"] + "AND SYWD.AcaStart=" + Session["AcaStart"] + "  ORDER BY SM.StudentID");
					gvSibling.DataBind();


				}
				hdnFlag.Value = "N^";
			}
			else
			{
				if ((objCCWeb.ReturnNumericValue("Select Count(*) From SIStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'")) > 0)
				{
					int intPStudentID = objCCWeb.ReturnNumericValue("SELECT Top 1 SM.StudentID FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID  " +
						" WHERE ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'  AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " Order by SM.StudentId ASC");

					strResult = pGetStudentDetails(intPStudentID);
					if ((strResult == "") || (strResult == "null"))
					{
						return;
					}
					string[] VarArray = strResult.Split('^');
					hdnSImagePath.Value = "";
					imgStudent.ImageUrl = "StudentPhoto/S" + VarArray[0] + ".jpg";
					if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + VarArray[0] + ".GIF") == true)
					{
						imgQRCode.ImageUrl = "~/QRCodeImage/Q" + VarArray[0] + ".GIF";

					}
					else
					{
						imgQRCode.Visible = false;
					}

					hdntxtStuSelect.Value = VarArray[0];
					hdnSDID.Value = VarArray[0];
					txtFirstName.Text = VarArray[1];
					txtMiddleName.Text = VarArray[2];
					txtLastName.Text = VarArray[3];
					txtArabicName.Text = VarArray[4];
					if (VarArray[5].ToString() == "M")
					{
						rbtnMale.Checked = true;
					}
					else
					{
						rbtnFemale.Checked = true;
					}
					txtStuDOB.Text = VarArray[6];
					txtDOA.Text = VarArray[7];
					ddlAdmittedClass.SelectedValue = VarArray[8];
					ddlSocCategory.SelectedValue = VarArray[9];

					ddlReligion.SelectedValue = VarArray[10];
					//ddlCaste.SelectedValue = VarArray[11];
					txtStuEmergencyNo.Text = VarArray[12];
					txtStuEmail.Text = VarArray[13];
					ddlBloodGroup.SelectedValue = VarArray[14];
					ddlNationality.SelectedValue = VarArray[15];
					ddlMotherTongue.SelectedValue = VarArray[16];
					txtParentID.Text = VarArray[17];
					txtSiqmano.Text = VarArray[18];
					txtNoOfChild.Text = VarArray[19];
					txtPositionChild.Text = VarArray[20];
					txtAdmNo.Text = VarArray[21];
					txtFeeNo.Text = VarArray[22];
					ddlClass.SelectedValue = VarArray[23];
					ddlSection.SelectedValue = VarArray[24];
					lblCaption1.Text = "Strength";
					strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				  " where StudentStatus='S' and SYD.ClassID='" + VarArray[23] + "' and SYD.SectionID='" + VarArray[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");
					lblClassStrength.Text = "Class : " + "" + strClassStrength;



					strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				" where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

					lblTotalStrength.Text = "School : " + "" + strSchoolStrength;


					if (VarArray[25].ToString() == "N")
					{
						rbtnAdmissionNew.Checked = true;
					}
					else
					{
						rbtnAdmissionOld.Checked = true;
					}
					txtRollNo.Text = VarArray[26];
					ddlHouse.SelectedValue = VarArray[27];
					ddlBoard.SelectedValue = VarArray[28];
					txtBoardRegNo.Text = VarArray[29];
					ddlBoardingCategory.SelectedValue = VarArray[30];
					//ddlStop.SelectedValue = VarArray[67];
					txtChildCode.Text = VarArray[31];
					txtRemarks.Text = VarArray[32];
					txtPresAddress.Text = VarArray[33];
					hdntxtResiCity.Value = VarArray[34];
					txtPresPincode.Text = VarArray[35];
					txtPresPhone.Text = VarArray[36];
					txtPerAddress.Text = VarArray[37];
					hdntxtPerCity.Value = VarArray[38];
					txtPerPincode.Text = VarArray[39];
					txtPerPhone.Text = VarArray[40];
					txtResiCity.Text = VarArray[41];
					txtPresState.Text = VarArray[42];
					txtPresCountry.Text = VarArray[43];
					txtPerCity.Text = VarArray[44];
					txtPerState.Text = VarArray[45];
					txtPerCountry.Text = VarArray[46];
					ddlFTitle.SelectedValue = VarArray[47];
					txtFName.Text = VarArray[48];
					ddlMTitle.SelectedValue = VarArray[49];
					txtMName.Text = VarArray[50];
					ddlFeeGroup.SelectedValue = VarArray[51];
					ddlFeeApplnFrom.SelectedValue = VarArray[52];

					if (VarArray[53].ToString() == "T")
					{
						hidStatusdisplay.Value = "T";
						imgATD.ImageUrl = "~/Images/Present.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
					}
					else if (VarArray[53].ToString() == "D")
					{
						hidStatusdisplay.Value = "D";
						imgATD.ImageUrl = "~/Images/Absent.png";
						//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
					}
					else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
					  "  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
					  " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
					  " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + VarArray[0] + " ") > 0)
					{
						hidStatusdisplay.Value = "R";
						imgATD.ImageUrl = "~/Images/HalfDay.png";
						// lblStudentStatus.Text = "Repeater";
					}
					else
					{
						// imgATD.ImageUrl = "~/Images/1Present.png";
						// lblStudentStatus.Text = "";
					}
					txtSiqmaExpiryDate.Text = VarArray[54];
					ddlConcessionType.SelectedValue = VarArray[55];
					if (VarArray[56] != "0")
					{
						ddlMeal.SelectedValue = VarArray[56];
					}

					if (VarArray[57] == "")
					{
						ddlSchoolBus.SelectedValue = "";
					}
					else
					{
						ddlSchoolBus.SelectedValue = VarArray[57];
					}
					ddlSecondLanguage.SelectedValue = VarArray[58];
					ddlThirdLanguage.SelectedValue = VarArray[59];
					ddlStuLiving.SelectedValue = VarArray[60];

					//if (VarArray[60] == "")
					//{
					//    ddlStuLiving.SelectedValue = "";
					//}
					//else
					//{
					//    ddlStuLiving.SelectedValue = VarArray[60];
					//}
					if (VarArray[61].ToString() == "Y")
					{
						rbtProvYes.Checked = true;
					}
					else
					{
						rbtProvNo.Checked = true;
					}
					txtDateOFJoin.Text = VarArray[62];
					txtLiveEduID.Text = VarArray[63];
					//ddlHomeAdvisor.SelectedValue = VarArray[66];


					txtCBSERollNo.Text = VarArray[65];
					txtCaste.Text = VarArray[68];

					if (VarArray[69].ToString() == "Y")
					{
						rbtnFreeShipYes.Checked = true;
					}
					else
					{
						rbtnFreeShipNo.Checked = true;
					}
                    txtGGNNo.Text = VarArray[70];
					gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intPStudentID + "");
					gvEmergencyContact.DataBind();


					gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intPStudentID + "");
					gvAuthorisedPickUp.DataBind();


					gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
									  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgpath  " +
									  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intPStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
					gvDocuments.DataBind();


					ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


					gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
						" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + VarArray[17] + "    AND  " +
					 "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
					gvSibling.DataBind();
					gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intPStudentID + "");
					gvPreviousEducation.DataBind();

					//objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 ORDER BY  MotherTongueName1", "MotherTongueID", "MotherTongueName", "");
					string vardata = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intPStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
											  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

					objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

					if (vardata != "0")
					{
						string[] varStr = vardata.Split(',');
						for (int i = 0; i < varStr.Length; i++)
						{
							if (chkLanguageKnown.Items.Count > 0)
							{
								for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
								{
									if (chkLanguageKnown.Items[inti].Value == varStr[i])
									{
										chkLanguageKnown.Items[inti].Selected = true;
									}

								}
							}
						}
					}


					string vardata8 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(ImpairmentID AS Varchar)  FROM SIStudentTypeofImpairmentDetails Where StudentID=" + intPStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
											 "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

					objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName,1 as id FROM MTImpairmentMaster  WHERE ImpairmentID<>0 AND ImpairmentID IN (select * from [fnSplit] ('" + vardata8 + "',',')) union Select ImpairmentID,Impairment As ImpairmentName,2 as id From MTImpairmentMaster WHERE ImpairmentID<>0  AND ImpairmentID NOT IN (select * from [fnSplit] ('" + vardata8 + "',',')) ORDER BY id ", "ImpairmentID", "ImpairmentName", "");

					if (vardata8 != "0")
					{
						string[] varStr1 = vardata8.Split(',');
						for (int i = 0; i < varStr1.Length; i++)
						{
							if (chkImpairment.Items.Count > 0)
							{
								for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
								{
									if (chkImpairment.Items[inti].Value == varStr1[i])
									{
										chkImpairment.Items[inti].Selected = true;
									}

								}
							}
						}
					}
				}
				intStudentID = objCCWeb.ReturnNumericValue("SELECT  SM.StudentID FROM SIStudentMaster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID = SYD.StudentID WHERE SM.ParentID='" + txtParentID.Text.Trim() + "' AND SYD.AcaStart=" + Session["AcaStart"] + " AND SYD.SchoolID=" + Session["SchoolID"] + "");
				hdnFlag.Value = "A";
			}
		}
		if (hdnAdmNo.Value != "")
		{
			intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE AdmissionNo='" + hdnAdmNo.Value + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
			strResult = pGetStudentDetails(intStudentID);
			if ((strResult == "") || (strResult == "null"))
			{
				return;
			}
			string[] strArray2 = strResult.Split('^');
			hdnSImagePath.Value = "";
			imgStudent.ImageUrl = "StudentPhoto/S" + strArray2[0] + ".jpg";
			if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + strArray2[0] + ".GIF") == true)
			{
				imgQRCode.ImageUrl = "~/QRCodeImage/Q" + strArray2[0] + ".GIF";

			}
			else
			{
				imgQRCode.Visible = false;
			}

			txtStuSelect.Text = "";
			hdntxtStuSelect.Value = strArray2[0];
			hdnSDID.Value = strArray2[0];
			txtStuSelect.Text = "";
			txtFirstName.Text = strArray2[1];
			txtMiddleName.Text = strArray2[2];
			txtLastName.Text = strArray2[3];
			txtArabicName.Text = strArray2[4];
			if (strArray2[5].ToString() == "M")
			{
				rbtnMale.Checked = true;
			}
			else
			{
				rbtnFemale.Checked = true;
			}
			txtStuDOB.Text = strArray2[6];
			txtDOA.Text = strArray2[7];
			ddlAdmittedClass.SelectedValue = strArray2[8];
			ddlSocCategory.SelectedValue = strArray2[9];

			ddlReligion.SelectedValue = strArray2[10];
			//ddlCaste.SelectedValue = strArray2[11];
			txtStuEmergencyNo.Text = strArray2[12];
			txtStuEmail.Text = strArray2[13];
			ddlBloodGroup.SelectedValue = strArray2[14];
			ddlNationality.SelectedValue = strArray2[15];
			ddlMotherTongue.SelectedValue = strArray2[16];
			txtParentID.Text = strArray2[17];
			txtSiqmano.Text = strArray2[18];
			txtNoOfChild.Text = strArray2[19];
			txtPositionChild.Text = strArray2[20];
			txtAdmNo.Text = strArray2[21];
			txtFeeNo.Text = strArray2[22];
			ddlClass.SelectedValue = strArray2[23];
			ddlSection.SelectedValue = strArray2[24];
			lblCaption1.Text = "Strength";
			strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
			   " where StudentStatus='S' and SYD.ClassID='" + strArray2[23] + "' and SYD.SectionID='" + strArray2[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");
			lblClassStrength.Text = "Class : " + "" + strClassStrength;

			strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
				" where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

			lblTotalStrength.Text = "School : " + "" + strSchoolStrength;

			if (strArray2[25].ToString() == "N")
			{
				rbtnAdmissionNew.Checked = true;
			}
			else
			{
				rbtnAdmissionOld.Checked = true;
			}
			txtRollNo.Text = strArray2[26];
			ddlHouse.SelectedValue = strArray2[27];
			ddlBoard.SelectedValue = strArray2[28];
			txtBoardRegNo.Text = strArray2[29];
			ddlBoardingCategory.SelectedValue = strArray2[30];
			// ddlStop.SelectedValue = strArray2[67];
			txtChildCode.Text = strArray2[31];
			txtRemarks.Text = strArray2[32];
			txtPresAddress.Text = strArray2[33];
			hdntxtResiCity.Value = strArray2[34];
			txtPresPincode.Text = strArray2[35];
			txtPresPhone.Text = strArray2[36];
			txtPerAddress.Text = strArray2[37];
			hdntxtPerCity.Value = strArray2[38];
			txtPerPincode.Text = strArray2[39];
			txtPerPhone.Text = strArray2[40];
			txtResiCity.Text = strArray2[41];
			txtPresState.Text = strArray2[42];
			txtPresCountry.Text = strArray2[43];
			txtPerCity.Text = strArray2[44];
			txtPerState.Text = strArray2[45];
			txtPerCountry.Text = strArray2[46];
			ddlFTitle.SelectedValue = strArray2[47];
			txtFName.Text = strArray2[48];
			ddlMTitle.SelectedValue = strArray2[49];
			txtMName.Text = strArray2[50];
			ddlFeeGroup.SelectedValue = strArray2[51];
			ddlFeeApplnFrom.SelectedValue = strArray2[52];

			if (strArray2[53].ToString() == "T")
			{
				hidStatusdisplay.Value = "T";
				imgATD.ImageUrl = "~/Images/Present.png";
				//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
			}
			else if (strArray2[53].ToString() == "D")
			{
				hidStatusdisplay.Value = "D";
				imgATD.ImageUrl = "~/Images/Absent.png";
				//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
			}
			else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
				 "  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
				 " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
				 " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + strArray2[0] + " ") > 0)
			{
				hidStatusdisplay.Value = "R";
				imgATD.ImageUrl = "~/Images/HalfDay.png";
				// lblStudentStatus.Text = "Repeater";
			}
			else
			{
				//imgATD.ImageUrl = "~/Images/1Present.png";
				// lblStudentStatus.Text = "";
			}
			txtSiqmaExpiryDate.Text = strArray2[54];
			ddlConcessionType.SelectedValue = strArray2[55];
			if (strArray2[56] != "0")
			{
				ddlMeal.SelectedValue = strArray2[56];
			}

			if (strArray2[57] == "")
			{
				ddlSchoolBus.SelectedValue = "";
			}
			else
			{
				ddlSchoolBus.SelectedValue = strArray2[57];
			}
			ddlSecondLanguage.SelectedValue = strArray2[58];
			ddlThirdLanguage.SelectedValue = strArray2[59];
			ddlStuLiving.SelectedValue = strArray2[60];

			//if (strArray2[60] == "")
			//{
			//    ddlStuLiving.SelectedValue = "";
			//}
			//else
			//{
			//    ddlStuLiving.SelectedValue = strArray2[60];
			//}
			if (strArray2[61].ToString() == "Y")
			{
				rbtProvYes.Checked = true;
			}
			else
			{
				rbtProvNo.Checked = true;
			}
			txtDateOFJoin.Text = strArray2[62];
			txtLiveEduID.Text = strArray2[63];


			txtCBSERollNo.Text = strArray2[65];
			txtCaste.Text = strArray2[68];

			if (strArray2[69].ToString() == "Y")
			{
				rbtnFreeShipYes.Checked = true;
			}
			else
			{
				rbtnFreeShipNo.Checked = true;
			}
            txtGGNNo.Text = strArray2[70];
			gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intStudentID + "");
			gvEmergencyContact.DataBind();



			gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intStudentID + "");
			gvAuthorisedPickUp.DataBind();



			gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
							  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgpath  " +
							  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
			gvDocuments.DataBind();


			ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


			gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
				" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + strArray2[17] + "    AND  " +
			 "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + hdnAdmNo.Value + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
			gvSibling.DataBind();

			gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intStudentID + "");
			gvPreviousEducation.DataBind();


			//objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 ORDER BY  MotherTongueName1", "MotherTongueID", "MotherTongueName", "");
			string vardata3 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
									  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");
			objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata3 + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata3 + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

			if (vardata3 != "0")
			{
				string[] varStr = vardata3.Split(',');
				for (int i = 0; i < varStr.Length; i++)
				{
					if (chkLanguageKnown.Items.Count > 0)
					{
						for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
						{
							if (chkLanguageKnown.Items[inti].Value == varStr[i])
							{
								chkLanguageKnown.Items[inti].Selected = true;
							}

						}
					}
				}
			}
			string vardata8 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(ImpairmentID AS Varchar)  FROM SIStudentTypeofImpairmentDetails Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
											 "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

			objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName,1 as id FROM MTImpairmentMaster  WHERE ImpairmentID<>0 AND ImpairmentID IN (select * from [fnSplit] ('" + vardata8 + "',',')) union Select ImpairmentID,Impairment As ImpairmentName,2 as id From MTImpairmentMaster WHERE ImpairmentID<>0  AND ImpairmentID NOT IN (select * from [fnSplit] ('" + vardata8 + "',',')) ORDER BY id ", "ImpairmentID", "ImpairmentName", "");

			if (vardata8 != "0")
			{
				string[] varStr1 = vardata8.Split(',');
				for (int i = 0; i < varStr1.Length; i++)
				{
					if (chkImpairment.Items.Count > 0)
					{
						for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
						{
							if (chkImpairment.Items[inti].Value == varStr1[i])
							{
								chkImpairment.Items[inti].Selected = true;
							}

						}
					}
				}
			}
			hdnFlag.Value = "A";
			hdnAdmNo.Value = "";
			fBusRouteDetails(intStudentID);
		}

		//if (objCCWeb.ReturnSingleValue("Select  CONVERT(VARCHAR,UpdateDate,103) from SIStudentmaster Where StudentID='" + hdntxtStuSelect.Value + "'") == "null")
		if ((objCCWeb.ReturnSingleValue("Select  CONVERT(VARCHAR,UpdateDate,103) from SIStudentmaster Where StudentID='" + hdntxtStuSelect.Value + "'") == "") || (objCCWeb.ReturnSingleValue("Select  CONVERT(VARCHAR,UpdateDate,103) from SIStudentmaster Where StudentID='" + hdntxtStuSelect.Value + "'") == "NULL"))
		{
			lblcaption = "Entry Date";
		}

		else
		{
			lblcaption = "Last Modified Date ";
		}
		lblLastMDate.Text = "(" + lblcaption + " : " + objCCWeb.ReturnSingleValue("Select CONVERT(VARCHAR,ISNULL(UpdateDate,EntryDate),103) FROM SIStudentmaster where  StudentID=" + hdntxtStuSelect.Value + " ") + ")";
		return;

	}



	////////  protected void btnDisplay_Click(object sender, EventArgs e)

	////////  {
	////////      string strResult = "";
	////////      int intStudentID = 0;

	////////      if (btnNew.Enabled == true  || (txtStuSelect.Text != ""))
	////////      {
	////////          if ((txtAdmNo.Text.Trim() != "") && (hdnAdmNo.Value == ""))
	////////          {
	////////              if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentYearWiseDetails where AdmissionNo='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' AND AcaStart=" + Session["AcaStart"] + "  AND SchoolID=" + Session["SchoolID"] + "") <= 0)
	////////              {
	////////                  ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('Admission No Does Not Exits..');callreturn();</script>");
	////////                  txtAdmNo.Focus();
	////////                  return;
	////////              }
	////////              else
	////////              {

	////////                  intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE AdmissionNo='" + txtAdmNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
	////////                  strResult = pGetStudentDetails(intStudentID);

	////////                  string[] strArray1 = strResult.Split('^');
	////////                  hdnSImagePath.Value = "";
	////////                  imgStudent.ImageUrl = "StudentPhoto/S" + strArray1[0] + ".jpg";
	////////                  if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + strArray1[0] + ".GIF") == true)
	////////                  {
	////////                      imgQRCode.ImageUrl = "~/QRCodeImage/Q" + strArray1[0] + ".GIF";
	////////                      imgQRCode.Visible = true;
	////////                  }
	////////                  else
	////////                  {
	////////                      imgQRCode.Visible = false;
	////////                  }
	////////                  hdntxtStuSelect.Value = strArray1[0];
	////////                  hdnSDID.Value = strArray1[0];
	////////                  txtFirstName.Text = strArray1[1];
	////////                  txtMiddleName.Text = strArray1[2];
	////////                  txtLastName.Text = strArray1[3];
	////////                  txtArabicName.Text = strArray1[4];
	////////                  if (strArray1[5].ToString() == "M")
	////////                  {
	////////                      rbtnMale.Checked = true;
	////////                  }
	////////                  else
	////////                  {
	////////                      rbtnFemale.Checked = true;
	////////                  }
	////////                  txtStuDOB.Text = strArray1[6];
	////////                  txtDOA.Text = strArray1[7];
	////////                  ddlAdmittedClass.SelectedValue = strArray1[8];
	////////                  ddlSocCategory.SelectedValue = strArray1[9];

	////////                  ddlReligion.SelectedValue = strArray1[10];
	////////                 // ddlCaste.SelectedValue = strArray1[11];
	////////                  txtStuEmergencyNo.Text = strArray1[12];
	////////                  txtStuEmail.Text = strArray1[13];
	////////                  ddlBloodGroup.SelectedValue = strArray1[14];
	////////                  ddlNationality.SelectedValue = strArray1[15];
	////////                  ddlMotherTongue.SelectedValue = strArray1[16];
	////////                  txtParentID.Text = strArray1[17];
	////////                  txtSiqmano.Text = strArray1[18];
	////////                  txtNoOfChild.Text = strArray1[19];
	////////                  txtPositionChild.Text = strArray1[20];
	////////                  txtAdmNo.Text = strArray1[21];
	////////                  txtFeeNo.Text = strArray1[22];
	////////                  ddlClass.SelectedValue = strArray1[23];
	////////                  ddlSection.SelectedValue = strArray1[24];
	////////                  if (strArray1[25].ToString() == "N")
	////////                  {
	////////                      rbtnAdmissionNew.Checked = true;
	////////                  }
	////////                  else
	////////                  {
	////////                      rbtnAdmissionOld.Checked = true;
	////////                  }
	////////                  txtRollNo.Text = strArray1[26];
	////////                  ddlHouse.SelectedValue = strArray1[27];
	////////                  ddlBoard.SelectedValue = strArray1[28];
	////////                  txtBoardRegNo.Text = strArray1[29];
	////////                  ddlBoardingCategory.SelectedValue = strArray1[30];
	////////                 // ddlStop.SelectedValue = strArray1[67];
	////////                  txtChildCode.Text = strArray1[31];
	////////                  txtRemarks.Text = strArray1[32];
	////////                  txtPresAddress.Text = strArray1[33];
	////////                  hdntxtResiCity.Value = strArray1[34];
	////////                  txtPresPincode.Text = strArray1[35];
	////////                  txtPresPhone.Text = strArray1[36];
	////////                  txtPerAddress.Text = strArray1[37];
	////////                  hdntxtPerCity.Value = strArray1[38];
	////////                  txtPerPincode.Text = strArray1[39];
	////////                  txtPerPhone.Text = strArray1[40];
	////////                  txtResiCity.Text = strArray1[41];
	////////                  txtPresState.Text = strArray1[42];
	////////                  txtPresCountry.Text = strArray1[43];
	////////                  txtPerCity.Text = strArray1[44];
	////////                  txtPerState.Text = strArray1[45];
	////////                  txtPerCountry.Text = strArray1[46];
	////////                  ddlFTitle.SelectedValue = strArray1[47];
	////////                  txtFName.Text = strArray1[48];
	////////                  ddlMTitle.SelectedValue = strArray1[49];
	////////                  txtMName.Text = strArray1[50];
	////////                  ddlFeeGroup.SelectedValue = strArray1[51];


	////////                  ddlFeeApplnFrom.SelectedValue = strArray1[52];

	////////                  if (strArray1[53].ToString() == "T")
	////////                  {
	////////                      lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
	////////                  }
	////////                  else if (strArray1[53].ToString() == "D")
	////////                  {
	////////                      lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
	////////                  }
	////////                  else
	////////                  {
	////////                      lblStudentStatus.Text = "";
	////////                  }
	////////                  txtSiqmaExpiryDate.Text = strArray1[54];
	////////                  ddlConcessionType.SelectedValue = strArray1[55];
	////////                  if (strArray1[56] != "0")
	////////                  {
	////////                      ddlMeal.SelectedValue = strArray1[56];
	////////                  }

	////////                  if (strArray1[57] == "")
	////////                  {
	////////                      ddlSchoolBus.SelectedValue = "";
	////////                  }
	////////                  else
	////////                  {
	////////                      ddlSchoolBus.SelectedValue = strArray1[57];
	////////                  }
	////////                  ddlSecondLanguage.SelectedValue = strArray1[58];
	////////                  ddlThirdLanguage.SelectedValue = strArray1[59];
	////////                  ddlStuLiving.SelectedValue = strArray1[60];

	////////                  //if (strArray1[60] == "")
	////////                  //{
	////////                  //    ddlStuLiving.SelectedValue = "";
	////////                  //}
	////////                  //else
	////////                  //{
	////////                  //    ddlStuLiving.SelectedValue = strArray1[60];
	////////                  //}
	////////                  if (strArray1[61].ToString() == "Y")
	////////                  {
	////////                      rbtProvYes.Checked = true;
	////////                  }
	////////                  else
	////////                  {
	////////                      rbtProvNo.Checked = true;
	////////                  }
	////////                  txtDateOFJoin.Text = strArray1[62];
	////////                  txtLiveEduID.Text = strArray1[63];


	////////                  txtCBSERollNo.Text = strArray1[65];
	////////                  ddlStream.SelectedValue = (strArray1[66]==""?"0":strArray1[66]);
	////////                  txtCaste.Text = strArray1[68];
	////////                 // ddlHomeAdvisor.SelectedValue=strArray1[66];
	////////                  //hdnTutor.Value = strArray1[66];

	////////                  gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intStudentID + "");
	////////                  gvEmergencyContact.DataBind();




	////////                  gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intStudentID + "");
	////////                  gvAuthorisedPickUp.DataBind();



	////////              //fillGrid('gvDocuments',"SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName<%=Session["Type"] %>  AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
	////////              //          " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as MPath  " +
	////////              //          " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID="+varStudent[0]+"    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");

	////////                  gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
	////////                                    " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgPath  " +
	////////                                    " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
	////////                  gvDocuments.DataBind();


	////////                  ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


	////////                  gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
	////////                      " INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + strArray1[17] + "    AND  " +
	////////                   "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
	////////                  gvSibling.DataBind();

	////////                  gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intStudentID + "");
	////////                  gvPreviousEducation.DataBind();




	////////                  /*-----------------------Modified By Manju on 29-05-2012-----------------------------------------------------*/
	////////                  string vardata2 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
	////////                                            "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

	////////                  objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata2 + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata2 + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

	////////                  if (vardata2 != "0")
	////////                  {
	////////                      string[] varStr = vardata2.Split(',');

	////////                      for (int i = 0; i < varStr.Length; i++)
	////////                      {
	////////                          if (chkLanguageKnown.Items.Count > 0)
	////////                          {
	////////                              for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
	////////                              {
	////////                                  if (chkLanguageKnown.Items[inti].Value == varStr[i])
	////////                                  {
	////////                                      chkLanguageKnown.Items[inti].Selected = true;
	////////                                  }

	////////                              }
	////////                          }
	////////                      }
	////////                  }
	////////                  fBusRouteDetails(intStudentID);
	////////                  //ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>fBusRouteDetails(" + intStudentID + ");</script>");


	////////                  /*-----------------------End of Modified By Manju on 29-05-2012-----------------------------------------------------*/
	////////              }

	////////              /*----------Added By Manju on 29-05-2012------------------*/

	////////              if (hdnFindSearch.Value == "F")
	////////              {
	////////                  ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\" type=\"text/javascript\">" + strfindShowID + "</script>");
	////////              }

	////////          }
	////////          hdnFlag.Value = "A";
	////////      }
	////////      if ((txtParentID.Text.Trim() != "") && (hdnAdmNo.Value == "") )
	////////      {
	////////          if (objCCWeb.ReturnNumericValue("SELECT Count(*) from SiStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'") <= 0)
	////////          {
	////////              ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('ParentID Does Not Exits..');callreturn();</script>");
	////////              txtParentID.Focus();
	////////              return;
	////////          }
	////////          if (btnNew.Enabled == false)
	////////          {
	////////              if (objCCWeb.ReturnNumericValue("Select Count(*) From SIStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'") > 0)
	////////              {
	////////                  int intParentID =Convert.ToInt32(txtParentID.Text.Trim().Replace("'", "''"));
	////////                  strResult = pGetSiblingDetails(intParentID);
	////////                  string[] varStudent = strResult.Split('^');
	////////                  hdntxtStuSelect.Value = varStudent[0];
	////////                  hdnSDID.Value = varStudent[0];
	////////                  ddlReligion.SelectedValue = varStudent[1];
	////////                  //ddlCaste.SelectedValue = varStudent[2];
	////////                  ddlNationality.SelectedValue = varStudent[3];
	////////                  ddlMotherTongue.SelectedValue = varStudent[4];
	////////                  txtNoOfChild.Text = varStudent[5];
	////////                  txtChildCode.Text = varStudent[6];
	////////                  txtPresAddress.Text = varStudent[7];
	////////                  hdntxtResiCity.Value = varStudent[8];
	////////                  txtPresPincode.Text = varStudent[9];
	////////                  txtPresPhone.Text = varStudent[10];
	////////                  txtPerAddress.Text = varStudent[11];
	////////                  hdntxtPerCity.Value = varStudent[12];
	////////                  txtPerPincode.Text = varStudent[13];
	////////                  txtPerPhone.Text = varStudent[14];
	////////                  txtResiCity.Text = varStudent[15];
	////////                  txtPresState.Text = varStudent[16];
	////////                  txtPresCountry.Text = varStudent[17];
	////////                  txtPerCity.Text = varStudent[18];
	////////                  txtPerState.Text = varStudent[19];
	////////                  txtPerCountry.Text = varStudent[20];
	////////                  txtParentID.Text = varStudent[21];
	////////                  ddlFTitle.SelectedValue = varStudent[23];
	////////                  txtFName.Text = varStudent[24];
	////////                  ddlMTitle.SelectedValue = varStudent[25];
	////////                  txtMName.Text = varStudent[26];
	////////                  if (varStudent[29] == "T")
	////////                  {
	////////                      lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
	////////                  }
	////////                  else if (varStudent[29] == "")
	////////                  {
	////////                      lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "  FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
	////////                  }
	////////                  else
	////////                  {
	////////                      lblStudentStatus.Text = "";
	////////                  }
	////////                  gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
	////////                         " INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + intParentID + "    AND  " +
	////////                      "  SYWD.SchoolID=" + Session["SchoolID"] + "AND SYWD.AcaStart=" + Session["AcaStart"] + "  ORDER BY SM.StudentID");
	////////                  gvSibling.DataBind();


	////////              }
	////////              hdnFlag.Value = "N^";
	////////          }
	////////          else
	////////          {
	////////              if ((objCCWeb.ReturnNumericValue("Select Count(*) From SIStudentMaster where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'")) > 0)
	////////              {
	////////                  int intPStudentID = objCCWeb.ReturnNumericValue("SELECT Top 1 SM.StudentID FROM SIStudentMaster  SM INNER JOIN  SISTudentYearWIseDetails YD ON SM.StudentID=YD.StudentID  " +
	////////                      " WHERE ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'  AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " Order by SM.StudentId ASC");

	////////                  strResult = pGetStudentDetails(intPStudentID);
	////////                  string[] VarArray = strResult.Split('^');
	////////                  hdnSImagePath.Value = "";
	////////                  imgStudent.ImageUrl = "StudentPhoto/S" + VarArray[0] + ".jpg";
	////////                  if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + VarArray[0] + ".GIF") == true)
	////////                  {
	////////                      imgQRCode.ImageUrl = "~/QRCodeImage/Q" + VarArray[0] + ".GIF";

	////////                  }
	////////                  else
	////////                  {
	////////                      imgQRCode.Visible = false;
	////////                  }

	////////                  hdntxtStuSelect.Value = VarArray[0];
	////////                  hdnSDID.Value = VarArray[0];
	////////                  txtFirstName.Text = VarArray[1];
	////////                  txtMiddleName.Text = VarArray[2];
	////////                  txtLastName.Text = VarArray[3];
	////////                  txtArabicName.Text = VarArray[4];
	////////                  if (VarArray[5].ToString() == "M")
	////////                  {
	////////                      rbtnMale.Checked = true;
	////////                  }
	////////                  else
	////////                  {
	////////                      rbtnFemale.Checked = true;
	////////                  }
	////////                  txtStuDOB.Text = VarArray[6];
	////////                  txtDOA.Text = VarArray[7];
	////////                  ddlAdmittedClass.SelectedValue = VarArray[8];
	////////                  ddlSocCategory.SelectedValue = VarArray[9];

	////////                  ddlReligion.SelectedValue = VarArray[10];
	////////                  //ddlCaste.SelectedValue = VarArray[11];
	////////                  txtStuEmergencyNo.Text = VarArray[12];
	////////                  txtStuEmail.Text = VarArray[13];
	////////                  ddlBloodGroup.SelectedValue = VarArray[14];
	////////                  ddlNationality.SelectedValue = VarArray[15];
	////////                  ddlMotherTongue.SelectedValue = VarArray[16];
	////////                  txtParentID.Text = VarArray[17];
	////////                  txtSiqmano.Text = VarArray[18];
	////////                  txtNoOfChild.Text = VarArray[19];
	////////                  txtPositionChild.Text = VarArray[20];
	////////                  txtAdmNo.Text = VarArray[21];
	////////                  txtFeeNo.Text = VarArray[22];
	////////                  ddlClass.SelectedValue = VarArray[23];
	////////                  ddlSection.SelectedValue = VarArray[24];
	////////                  if (VarArray[25].ToString() == "N")
	////////                  {
	////////                      rbtnAdmissionNew.Checked = true;
	////////                  }
	////////                  else
	////////                  {
	////////                      rbtnAdmissionOld.Checked = true;
	////////                  }
	////////                  txtRollNo.Text = VarArray[26];
	////////                  ddlHouse.SelectedValue = VarArray[27];
	////////                  ddlBoard.SelectedValue = VarArray[28];
	////////                  txtBoardRegNo.Text = VarArray[29];
	////////                  ddlBoardingCategory.SelectedValue = VarArray[30];
	////////                  //ddlStop.SelectedValue = VarArray[67];
	////////                  txtChildCode.Text = VarArray[31];
	////////                  txtRemarks.Text = VarArray[32];
	////////                  txtPresAddress.Text = VarArray[33];
	////////                  hdntxtResiCity.Value = VarArray[34];
	////////                  txtPresPincode.Text = VarArray[35];
	////////                  txtPresPhone.Text = VarArray[36];
	////////                  txtPerAddress.Text = VarArray[37];
	////////                  hdntxtPerCity.Value = VarArray[38];
	////////                  txtPerPincode.Text = VarArray[39];
	////////                  txtPerPhone.Text = VarArray[40];
	////////                  txtResiCity.Text = VarArray[41];
	////////                  txtPresState.Text = VarArray[42];
	////////                  txtPresCountry.Text = VarArray[43];
	////////                  txtPerCity.Text = VarArray[44];
	////////                  txtPerState.Text = VarArray[45];
	////////                  txtPerCountry.Text = VarArray[46];
	////////                  ddlFTitle.SelectedValue = VarArray[47];
	////////                  txtFName.Text = VarArray[48];
	////////                  ddlMTitle.SelectedValue = VarArray[49];
	////////                  txtMName.Text = VarArray[50];
	////////                  ddlFeeGroup.SelectedValue = VarArray[51];
	////////                  ddlFeeApplnFrom.SelectedValue = VarArray[52];

	////////                  if (VarArray[53].ToString() == "T")
	////////                  {
	////////                      lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
	////////                  }
	////////                  else if (VarArray[53].ToString() == "D")
	////////                  {
	////////                      lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
	////////                  }
	////////                  else
	////////                  {
	////////                      lblStudentStatus.Text = "";
	////////                  }
	////////                  txtSiqmaExpiryDate.Text = VarArray[54];
	////////                  ddlConcessionType.SelectedValue = VarArray[55];
	////////                  if (VarArray[56] != "0")
	////////                  {
	////////                      ddlMeal.SelectedValue = VarArray[56];
	////////                  }

	////////                  if (VarArray[57] == "")
	////////                  {
	////////                      ddlSchoolBus.SelectedValue = "";
	////////                  }
	////////                  else
	////////                  {
	////////                      ddlSchoolBus.SelectedValue = VarArray[57];
	////////                  }
	////////                  ddlSecondLanguage.SelectedValue = VarArray[58];
	////////                  ddlThirdLanguage.SelectedValue = VarArray[59];
	////////                  ddlStuLiving.SelectedValue = VarArray[60];

	////////                  //if (VarArray[60] == "")
	////////                  //{
	////////                  //    ddlStuLiving.SelectedValue = "";
	////////                  //}
	////////                  //else
	////////                  //{
	////////                  //    ddlStuLiving.SelectedValue = VarArray[60];
	////////                  //}
	////////                  if (VarArray[61].ToString() == "Y")
	////////                  {
	////////                      rbtProvYes.Checked = true;
	////////                  }
	////////                  else
	////////                  {
	////////                      rbtProvNo.Checked = true;
	////////                  }
	////////                  txtDateOFJoin.Text = VarArray[62];
	////////                  txtLiveEduID.Text = VarArray[63];
	////////                  //ddlHomeAdvisor.SelectedValue = VarArray[66];


	////////                  txtCBSERollNo.Text = VarArray[65];
	////////                  txtCaste.Text = VarArray[68];

	////////                  gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intPStudentID + "");
	////////                  gvEmergencyContact.DataBind();


	////////                  gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intPStudentID + "");
	////////                  gvAuthorisedPickUp.DataBind();


	////////                  gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
	////////                                    " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+'.JPG' END as imgpath  " +
	////////                                    " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intPStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
	////////                  gvDocuments.DataBind();


	////////                  ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


	////////                  gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
	////////                      " INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + VarArray[17] + "    AND  " +
	////////                   "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
	////////                  gvSibling.DataBind();
	////////                  gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intPStudentID + "");
	////////                  gvPreviousEducation.DataBind();

	////////                  //objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 ORDER BY  MotherTongueName1", "MotherTongueID", "MotherTongueName", "");
	////////                  string vardata = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
	////////                                            "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

	////////                  objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

	////////                  if (vardata != "0")
	////////                  {
	////////                      string[] varStr = vardata.Split(',');
	////////                      for (int i = 0; i < varStr.Length; i++)
	////////                      {
	////////                          if (chkLanguageKnown.Items.Count > 0)
	////////                          {
	////////                              for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
	////////                              {
	////////                                  if (chkLanguageKnown.Items[inti].Value == varStr[i])
	////////                                  {
	////////                                      chkLanguageKnown.Items[inti].Selected = true;
	////////                                  }

	////////                              }
	////////                          }
	////////                      }
	////////                  }
	////////              }
	////////              intStudentID = objCCWeb.ReturnNumericValue("SELECT  SM.StudentID FROM SIStudentMaster SM INNER JOIN SIStudentYearWiseDetails SYD ON SM.StudentID = SYD.StudentID WHERE SM.ParentID='" + txtParentID.Text.Trim() + "' AND SYD.AcaStart=" + Session["AcaStart"] + " AND SYD.SchoolID=" + Session["SchoolID"] + "");
	////////              hdnFlag.Value = "A";
	////////          }
	////////      }
	////////      if (hdnAdmNo.Value != "")
	////////      {
	////////          intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE AdmissionNo='" + hdnAdmNo.Value + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
	////////             strResult = pGetStudentDetails(intStudentID);

	////////              string[] strArray2 = strResult.Split('^');
	////////              hdnSImagePath.Value = "";
	////////              imgStudent.ImageUrl = "StudentPhoto/S" + strArray2[0] + ".jpg";
	////////              if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + strArray2[0] + ".GIF") == true)
	////////              {
	////////                  imgQRCode.ImageUrl = "~/QRCodeImage/Q" + strArray2[0] + ".GIF";

	////////              }
	////////              else
	////////              {
	////////                  imgQRCode.Visible = false;
	////////              }

	////////              txtStuSelect.Text = "";
	////////              hdntxtStuSelect.Value = strArray2[0];
	////////              hdnSDID.Value = strArray2[0];
	////////              txtStuSelect.Text = "";
	////////              txtFirstName.Text = strArray2[1];
	////////              txtMiddleName.Text = strArray2[2];
	////////              txtLastName.Text = strArray2[3];
	////////              txtArabicName.Text = strArray2[4];
	////////              if (strArray2[5].ToString() == "M")
	////////              {
	////////                  rbtnMale.Checked = true;
	////////              }
	////////              else
	////////              {
	////////                  rbtnFemale.Checked = true;
	////////              }
	////////              txtStuDOB.Text = strArray2[6];
	////////              txtDOA.Text = strArray2[7];
	////////              ddlAdmittedClass.SelectedValue = strArray2[8];
	////////              ddlSocCategory.SelectedValue = strArray2[9];

	////////              ddlReligion.SelectedValue = strArray2[10];
	////////              //ddlCaste.SelectedValue = strArray2[11];
	////////              txtStuEmergencyNo.Text = strArray2[12];
	////////              txtStuEmail.Text = strArray2[13];
	////////              ddlBloodGroup.SelectedValue = strArray2[14];
	////////              ddlNationality.SelectedValue = strArray2[15];
	////////              ddlMotherTongue.SelectedValue = strArray2[16];
	////////              txtParentID.Text = strArray2[17];
	////////              txtSiqmano.Text = strArray2[18];
	////////              txtNoOfChild.Text = strArray2[19];
	////////              txtPositionChild.Text = strArray2[20];
	////////              txtAdmNo.Text = strArray2[21];
	////////              txtFeeNo.Text = strArray2[22];
	////////              ddlClass.SelectedValue = strArray2[23];
	////////              ddlSection.SelectedValue = strArray2[24];
	////////              if (strArray2[25].ToString() == "N")
	////////              {
	////////                  rbtnAdmissionNew.Checked = true;
	////////              }
	////////              else
	////////              {
	////////                  rbtnAdmissionOld.Checked = true;
	////////              }
	////////              txtRollNo.Text = strArray2[26];
	////////              ddlHouse.SelectedValue = strArray2[27];
	////////              ddlBoard.SelectedValue = strArray2[28];
	////////              txtBoardRegNo.Text = strArray2[29];
	////////              ddlBoardingCategory.SelectedValue = strArray2[30];
	////////             // ddlStop.SelectedValue = strArray2[67];
	////////              txtChildCode.Text = strArray2[31];
	////////              txtRemarks.Text = strArray2[32];
	////////              txtPresAddress.Text = strArray2[33];
	////////              hdntxtResiCity.Value = strArray2[34];
	////////              txtPresPincode.Text = strArray2[35];
	////////              txtPresPhone.Text = strArray2[36];
	////////              txtPerAddress.Text = strArray2[37];
	////////              hdntxtPerCity.Value = strArray2[38];
	////////              txtPerPincode.Text = strArray2[39];
	////////              txtPerPhone.Text = strArray2[40];
	////////              txtResiCity.Text = strArray2[41];
	////////              txtPresState.Text = strArray2[42];
	////////              txtPresCountry.Text = strArray2[43];
	////////              txtPerCity.Text = strArray2[44];
	////////              txtPerState.Text = strArray2[45];
	////////              txtPerCountry.Text = strArray2[46];
	////////              ddlFTitle.SelectedValue = strArray2[47];
	////////              txtFName.Text = strArray2[48];
	////////              ddlMTitle.SelectedValue = strArray2[49];
	////////              txtMName.Text = strArray2[50];
	////////              ddlFeeGroup.SelectedValue = strArray2[51];
	////////              ddlFeeApplnFrom.SelectedValue = strArray2[52];

	////////              if (strArray2[53].ToString() == "T")
	////////              {
	////////                  lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
	////////              }
	////////              else if (strArray2[53].ToString() == "D")
	////////              {
	////////                  lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
	////////              }
	////////              else
	////////              {
	////////                  lblStudentStatus.Text = "";
	////////              }
	////////              txtSiqmaExpiryDate.Text = strArray2[54];
	////////              ddlConcessionType.SelectedValue = strArray2[55];
	////////              if (strArray2[56] != "0")
	////////              {
	////////                  ddlMeal.SelectedValue = strArray2[56];
	////////              }

	////////              if (strArray2[57] == "")
	////////              {
	////////                  ddlSchoolBus.SelectedValue = "";
	////////              }
	////////              else
	////////              {
	////////                  ddlSchoolBus.SelectedValue = strArray2[57];
	////////              }
	////////              ddlSecondLanguage.SelectedValue = strArray2[58];
	////////              ddlThirdLanguage.SelectedValue = strArray2[59];
	////////              ddlStuLiving.SelectedValue = strArray2[60];

	////////              //if (strArray2[60] == "")
	////////              //{
	////////              //    ddlStuLiving.SelectedValue = "";
	////////              //}
	////////              //else
	////////              //{
	////////              //    ddlStuLiving.SelectedValue = strArray2[60];
	////////              //}
	////////              if (strArray2[61].ToString() == "Y")
	////////              {
	////////                  rbtProvYes.Checked = true;
	////////              }
	////////              else
	////////              {
	////////                  rbtProvNo.Checked = true;
	////////              }
	////////              txtDateOFJoin.Text = strArray2[62];
	////////              txtLiveEduID.Text = strArray2[63];


	////////              txtCBSERollNo.Text = strArray2[65];
	////////              txtCaste.Text = strArray2[68];

	////////              gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intStudentID + "");
	////////              gvEmergencyContact.DataBind();



	////////              gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intStudentID + "");
	////////              gvAuthorisedPickUp.DataBind();



	////////              gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
	////////                                " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+'.JPG' END as imgpath  " +
	////////                                " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
	////////              gvDocuments.DataBind();


	////////              ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


	////////              gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
	////////                  " INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + strArray2[17] + "    AND  " +
	////////               "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + hdnAdmNo.Value + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
	////////              gvSibling.DataBind();

	////////              gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intStudentID + "");
	////////              gvPreviousEducation.DataBind();


	////////              //objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 ORDER BY  MotherTongueName1", "MotherTongueID", "MotherTongueName", "");
	////////              string vardata3 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
	////////                                        "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");
	////////              objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata3 + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata3 + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

	////////              if (vardata3 != "0")
	////////              {
	////////                  string[] varStr = vardata3.Split(',');
	////////                  for (int i = 0; i < varStr.Length; i++)
	////////                  {
	////////                      if (chkLanguageKnown.Items.Count > 0)
	////////                      {
	////////                          for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
	////////                          {
	////////                              if (chkLanguageKnown.Items[inti].Value == varStr[i])
	////////                              {
	////////                                  chkLanguageKnown.Items[inti].Selected = true;
	////////                              }

	////////                          }
	////////                      }
	////////                  }
	////////              }
	////////              hdnFlag.Value = "A";
	////////              hdnAdmNo.Value = "";
	////////              fBusRouteDetails(intStudentID);
	////////          }
	////////     return;
	////////}



	protected void btnFindDisplay_Click(object sender, EventArgs e)
	{
		hdnFindSearch.Value = "F";
		if (hdnFlag.Value == "S^")
		{
			String varCriteria = "";
			//if(ddlFindClass.SelectedValue!="0")
			if (Request.Form["ddlFindClass"] != "0" && Request.Form["ddlFindClass"] != null)
			{
				//varCriteria="AND SYD.ClassID="+ ddlFindClass.SelectedValue;
				varCriteria = "AND SYD.ClassID=" + Request.Form["ddlFindClass"];
			}
			//if (ddlFindSection.SelectedValue != "0" && ddlFindSection.SelectedValue != "")
			if (Request.Form["ddlFindSection"] != "0" && Request.Form["ddlFindSection"] != "" && Request.Form["ddlFindSection"] != null)
			{
				//varCriteria = varCriteria + "AND SYD.SectionID=" + ddlFindSection.SelectedValue;
				varCriteria = varCriteria + "AND SYD.SectionID=" + Request.Form["ddlFindSection"];
			}
			if (txtFindStudent.Text.Trim() != "")
			{
				varCriteria = varCriteria + "AND SIM.FirstName Like '" + txtFindStudent.Text.Trim().Replace("'", "''") + "%'";
			}
			if (txtFindFatherName.Text.Trim() != "")
			{
				varCriteria = varCriteria + "AND SFD.FatherName LIKE '" + txtFindFatherName.Text.Trim().Replace("'", "''") + "%'";
			}
			if (txtFindMotherName.Text.Trim() != "")
			{
				varCriteria = varCriteria + "AND SMD.MotherName LIKE '" + txtFindMotherName.Text.Trim().Replace("'", "''") + "%'";
			}
			if (varCriteria != "")
			{
				gvFindStudent.DataSource = objCCWeb.BindReader("SELECT 0 AS SlNo,SYD.StudentID,ClassRollNo AS RollNo,AdmissionNo AS AdmNo,FirstName+' '+MiddleName+' '+LastName AS SName FROM SIStudentMaster SIM " +
				" INNER JOIN SIStudentYearWiseDetails SYD ON SIM.StudentID= SYD.StudentID INNER JOIN MTClassMAster CM ON SYD.ClassID= CM.ClassID " +
				" INNER JOIN MTSectionMaster SM ON SYD.SectionID= SM.SectionID INNER JOIN SIStudentFatherDetails SFD ON SYD.StudentID= SFD.StudentID " +
				" INNER JOIN SIStudentMotherDetails SMD ON SYD.StudentID= SMD.StudentID WHERE SYD.SchoolID=" + Session["SchoolID"] + " AND AcaStart=" + Session["AcaStart"] + " " + varCriteria + "  AND StudentStatus='S' ORDER BY SName");
				gvFindStudent.DataBind();
			}
			else
			{
				gvFindStudent.DataSource = objCCWeb.BindReader("SELECT 0 AS SlNo,SYD.StudentID,ClassRollNo AS RollNo,AdmissionNo AS AdmNo,FirstName+' '+MiddleName+' '+LastName AS SName FROM SIStudentMaster SIM " +
				" INNER JOIN SIStudentYearWiseDetails SYD ON SIM.StudentID= SYD.StudentID INNER JOIN MTClassMAster CM ON SYD.ClassID= CM.ClassID " +
				" INNER JOIN MTSectionMaster SM ON SYD.SectionID= SM.SectionID INNER JOIN SIStudentFatherDetails SFD ON SYD.StudentID= SFD.StudentID " +
				" INNER JOIN SIStudentMotherDetails SMD ON SYD.StudentID= SMD.StudentID WHERE SYD.SchoolID=" + Session["SchoolID"] + " AND AcaStart=" + Session["AcaStart"] + "  AND StudentStatus='S' ORDER BY SName");
				gvFindStudent.DataBind();
			}
			objCCWeb.FillDDLs(ddlFindClass, "SELECT 0 AS ClassID,'' AS ClassName1,0 AS PriorityNo UNION Select ClassID, ClassName1,PriorityNo FROM MTClassMAster WHERE ClassID IN (SELECT ClassID FROM SIStudentYEarWiseDetails SYD  WHERE SchoolID=" + Session["SchoolID"] + "  AND AcaStart=" + Session["AcaStart"] + " ) ORDER BY PriorityNo", "ClassID", "ClassName1", "");
			if (Request.Form["ddlFindClass"] != "0" && Request.Form["ddlFindClass"] != null)
			{

				ddlFindClass.Items.FindByValue(Request.Form["ddlFindClass"]).Selected = true;


				objCCWeb.FillDDLs(ddlFindSection, "SELECT 0 AS SectionID,'***Select Section***' AS SectionName1 UNION SELECT SectionID,SectionName1 FROM MTSectionMAster WHERE SectionID IN " +
					   " (SELECT SectionID FROM SIStudentYEarWiseDetails SYD  WHERE SchoolID=" + Session["SchoolID"] + "  AND AcaStart= " + Session["AcaStart"] + " AND ClassID=" + Request.Form["ddlFindClass"] + ") ORDER BY SectionName1", "SectionID", "SectionName1", "");
			}

			if (Request.Form["ddlFindSection"] != "0" && Request.Form["ddlFindSection"] != "" && Request.Form["ddlFindSection"] != null)
			{

				ddlFindSection.Items.FindByValue(Request.Form["ddlFindSection"]).Selected = true;
			}
			//btnCancel_Click(sender, e);
			//pFillBlankGrid(0);
			// ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");
			hdnFlag.Value = "S";

		}
	}

	private void pBindGrid()
	{
		int intStudentID = 0;
		intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE AdmissionNo='" + txtAdmNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
		strResult = pGetStudentDetails(intStudentID);
		string[] strArray = strResult.Split('^');
		if (intStudentID == 0)
		{
			gvSibling.DataSource = objCCWeb.BindReader("SELECT 1 AS SNO, '' AS AdmissionNo,'' AS StudentName,'' As ClassSection");
			gvSibling.DataBind();

			gvEmergencyContact.DataSource = objCCWeb.BindReader("SELECT  1 As SNo,'' AS PersonName,'' AS RelationShip,'' AS PhoneNo,'' AS Remarks");
			gvEmergencyContact.DataBind();

			gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("SELECT 1 AS SNo,'' AS PersonName,'' AS RelationShip,'' AS PhoneNo,'' AS Remarks,'' As imgPath");
			gvAuthorisedPickUp.DataBind();

			gvPreviousEducation.DataSource = objCCWeb.BindReader("SELECT 1 AS SNo,'' AS NameOfSchool,'' AS Location,'' AS ClassCompleted,'' AS YearAttended,'' As LanguageOfInstruction,'' AS Result");
			gvPreviousEducation.DataBind();
			ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


		}
		else
		{
			gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intStudentID + "");
			gvEmergencyContact.DataBind();

			for (int intForLoop = 0; intForLoop < gvEmergencyContact.Rows.Count; intForLoop++)
			{
				if (((TextBox)(gvEmergencyContact.Rows[intForLoop].FindControl("txtName"))).Text == "")
				{
					gvEmergencyContact.Rows[intForLoop].Style.Add("display", "none");
				}
			}
			gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intStudentID + "");
			gvAuthorisedPickUp.DataBind();
			ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");

			for (int intForLoop = 0; intForLoop < gvAuthorisedPickUp.Rows.Count; intForLoop++)
			{
				if (((TextBox)(gvAuthorisedPickUp.Rows[intForLoop].FindControl("txtName"))).Text.Trim() == "")
				{
					gvAuthorisedPickUp.Rows[intForLoop].Style.Add("display", "none");
				}
			}

			gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
							  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgpath  " +
							  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
			gvDocuments.DataBind();
			ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


			gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
				" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + strArray[17] + "    AND  " +
			 "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
			gvSibling.DataBind();
			for (int i = 0; i < gvSibling.Rows.Count; i++)
			{
				if (gvSibling.Rows[i].Cells[1].Text.Replace("&nbsp;", "") == "")
				{
					gvSibling.Rows[i].Style.Add("display", "none");
				}
			}
			gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intStudentID + "");
			gvPreviousEducation.DataBind();
			if (gvPreviousEducation.Rows.Count > 0)
			{
				for (int intForLoop = 0; intForLoop < gvPreviousEducation.Rows.Count; intForLoop++)
				{
					if (((TextBox)(gvPreviousEducation.Rows[intForLoop].FindControl("txtSchoolName"))).Text == "")
					{
						gvPreviousEducation.Rows[intForLoop].Style.Add("display", "none");
					}
				}
			}
		}

	}
	protected void gvEmergencyContact_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
	protected void btnResiCity_Click(object sender, EventArgs e)
	{
		string strResult = "";
		int intCityID = objCCWeb.ReturnNumericValue("Select CityID from MTCityMaster where CityName1='" + txtResiCity.Text.Trim().Replace("'", "''") + "'");
		string strCity = objCCWeb.ReturnSingleValue("Select CityName1 from MTCityMaster where CityName1='" + txtResiCity.Text.Trim().Replace("'", "''") + "'");
		strResult = pGetCityDetails(intCityID, strCity);
		string[] varStudent = strResult.Split('^');

		txtResiCity.Text = varStudent[1];
		txtPresState.Text = varStudent[2];
		txtPresCountry.Text = varStudent[3];
		// pBindGrid();
		hdnFlagPresCity.Value = "R";
		ClientScript.RegisterStartupScript(this.GetType(), "displayScriptMsg", "<script>pEnableDisable('EDIT');</script>");


	}
	protected void btnPerCity_Click(object sender, EventArgs e)
	{
		string strResult = "";
		int intCityID = objCCWeb.ReturnNumericValue("Select CityID from MTCityMaster where CityName1='" + txtPerCity.Text.Trim().Replace("'", "''") + "'");
		string strCity = objCCWeb.ReturnSingleValue("Select CityName1 from MTCityMaster where CityName1='" + txtPerCity.Text.Trim().Replace("'", "''") + "'");
		strResult = pGetCityDetails(intCityID, strCity);
		string[] varStudent = strResult.Split('^');

		txtPerCity.Text = varStudent[1];
		txtPerState.Text = varStudent[2];
		txtPerCountry.Text = varStudent[3];
		hdnFlagPerCity.Value = "P";
		ClientScript.RegisterStartupScript(this.GetType(), "displayScriptMsg", "<script>pEnableDisable('EDIT');</script>");
	}
	/*==================End of Added By Manju on 30-04-2012===================================*/
	protected void btnShowSave_Click(object sender, EventArgs e)
	{
		int intStudentID = 0;
		string lblcaption = "";
		string strClassStrength = "";
		string strSchoolStrength = "";
		hidStatusdisplay.Value = "";
		int minAcaStart = Convert.ToInt32(Session["Acastart"]) - 1;
		intStudentID = objCCWeb.ReturnNumericValue("SELECT StudentID FROM SIStudentYearWisedetails WHERE AdmissionNo='" + txtAdmNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
		strResult = pGetStudentDetails(intStudentID);
		if ((strResult == "") || (strResult == "null"))
		{
			return;
		}
		string[] strArray1 = strResult.Split('^');
		hdnSImagePath.Value = "";
		imgStudent.ImageUrl = "StudentPhoto/S" + strArray1[0] + ".jpg";
		if (File.Exists(Server.MapPath("QRCodeImage") + "/Q" + strArray1[0] + ".GIF") == true)
		{
			imgQRCode.ImageUrl = "~/QRCodeImage/Q" + strArray1[0] + ".GIF";

		}
		else
		{
			imgQRCode.Visible = false;
		}
		hdntxtStuSelect.Value = strArray1[0];
		hdnSDID.Value = strArray1[0];
		txtFirstName.Text = strArray1[1];
		txtMiddleName.Text = strArray1[2];
		txtLastName.Text = strArray1[3];
		txtArabicName.Text = strArray1[4];
		if (strArray1[5].ToString() == "M")
		{
			rbtnMale.Checked = true;
		}
		else
		{
			rbtnFemale.Checked = true;
		}
		txtStuDOB.Text = strArray1[6];
		txtDOA.Text = strArray1[7];
		ddlAdmittedClass.SelectedValue = strArray1[8];
		ddlSocCategory.SelectedValue = strArray1[9];

		ddlReligion.SelectedValue = strArray1[10];
		//ddlCaste.SelectedValue = strArray1[11];
		txtStuEmergencyNo.Text = strArray1[12];
		txtStuEmail.Text = strArray1[13];
		ddlBloodGroup.SelectedValue = strArray1[14];
		ddlNationality.SelectedValue = strArray1[15];
		ddlMotherTongue.SelectedValue = strArray1[16];
		txtParentID.Text = strArray1[17];
		txtSiqmano.Text = strArray1[18];
		txtNoOfChild.Text = strArray1[19];
		txtPositionChild.Text = strArray1[20];
		txtAdmNo.Text = strArray1[21];
		txtFeeNo.Text = strArray1[22];
		ddlClass.SelectedValue = strArray1[23];
		ddlSection.SelectedValue = strArray1[24];
		lblCaption1.Text = "Strength";
		strClassStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
			" where StudentStatus='S' and SYD.ClassID='" + strArray1[23] + "' and SYD.SectionID='" + strArray1[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");
		lblClassStrength.Text = "Class : " + "" + strClassStrength;

		strSchoolStrength = objCCWeb.ReturnSingleValue("Select Count(*) from SIStudentMaster SIM inner join SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
	  " where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

		lblTotalStrength.Text = "School: " + "" + strSchoolStrength;



		if (strArray1[25].ToString() == "N")
		{
			rbtnAdmissionNew.Checked = true;
		}
		else
		{
			rbtnAdmissionOld.Checked = true;
		}
		txtRollNo.Text = strArray1[26];
		ddlHouse.SelectedValue = strArray1[27];
		ddlBoard.SelectedValue = strArray1[28];
		txtBoardRegNo.Text = strArray1[29];
		ddlBoardingCategory.SelectedValue = strArray1[30];
		//ddlStop.SelectedValue = strArray1[67];
		txtChildCode.Text = strArray1[31];
		txtRemarks.Text = strArray1[32];
		txtPresAddress.Text = strArray1[33];
		hdntxtResiCity.Value = strArray1[34];
		txtPresPincode.Text = strArray1[35];
		txtPresPhone.Text = strArray1[36];
		txtPerAddress.Text = strArray1[37];
		hdntxtPerCity.Value = strArray1[38];
		txtPerPincode.Text = strArray1[39];
		txtPerPhone.Text = strArray1[40];
		txtResiCity.Text = strArray1[41];
		txtPresState.Text = strArray1[42];
		txtPresCountry.Text = strArray1[43];
		txtPerCity.Text = strArray1[44];
		txtPerState.Text = strArray1[45];
		txtPerCountry.Text = strArray1[46];
		ddlFTitle.SelectedValue = strArray1[47];
		txtFName.Text = strArray1[48];
		ddlMTitle.SelectedValue = strArray1[49];
		txtMName.Text = strArray1[50];
		ddlFeeGroup.SelectedValue = strArray1[51];
		ddlFeeApplnFrom.SelectedValue = strArray1[52];
		// 
		if (strArray1[53].ToString() == "T")
		{
			hidStatusdisplay.Value = "T";
			imgATD.ImageUrl = "~/Images/Present.png";
			// lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + " FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_T'");
		}
		else if (strArray1[53].ToString() == "D")
		{
			hidStatusdisplay.Value = "D";
			imgATD.ImageUrl = "~/Images/Absent.png";
			//lblStudentStatus.Text = objCCWeb.ReturnSingleValue("Select Caption" + Session["Type"] + "FROM mtformcontrolmaster Where Formid=307 ANd  ControlName='lblStudentStatus_D'");
		}
		else if (objCCWeb.ReturnNumericValue("SELECT count(*) from SIStudentYearWiseDetails SYD " +
			"  INNER JOIN (SELECT  SYD.StudentID FROM SIStudentYearWiseDetails SYD   " +
			" WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
			" WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + strArray1[0] + " ") > 0)
		{
			hidStatusdisplay.Value = "R";
			imgATD.ImageUrl = "~/Images/HalfDay.png";
			// lblStudentStatus.Text = "Repeater";
		}
		else
		{
			//imgATD.ImageUrl = "~/Images/1Present.png";
			//lblStudentStatus.Text = "";
		}
		txtSiqmaExpiryDate.Text = strArray1[54];
		ddlConcessionType.SelectedValue = strArray1[55];
		if (strArray1[56] != "0")
		{
			ddlMeal.SelectedValue = strArray1[56];
		}

		if (strArray1[57] == "")
		{
			ddlSchoolBus.SelectedValue = "";
		}
		else
		{
			ddlSchoolBus.SelectedValue = strArray1[57];
		}
		ddlSecondLanguage.SelectedValue = strArray1[58];
		ddlThirdLanguage.SelectedValue = strArray1[59];
		ddlStuLiving.SelectedValue = strArray1[60];

		//if (strArray1[60] == "")
		//{
		//    ddlStuLiving.SelectedValue = "";
		//}
		//else
		//{
		//    ddlStuLiving.SelectedValue = strArray1[60];
		//}
		if (strArray1[61].ToString() == "Y")
		{
			rbtProvYes.Checked = true;
		}
		else
		{
			rbtProvNo.Checked = true;
		}
		txtDateOFJoin.Text = strArray1[62];
		txtLiveEduID.Text = strArray1[63];


		txtCBSERollNo.Text = strArray1[65];
		txtCaste.Text = strArray1[68];


		if (strArray1[69].ToString() == "Y")
		{
			rbtnFreeShipYes.Checked = true;
		}
		else
		{
			rbtnFreeShipNo.Checked = true;
		}
        txtGGNNo.Text = strArray1[70];
		gvEmergencyContact.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentEmergencyContactDetails'," + intStudentID + "");
		gvEmergencyContact.DataBind();



		gvAuthorisedPickUp.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPickupDetails'," + intStudentID + "");
		gvAuthorisedPickUp.DataBind();



		gvDocuments.DataSource = objCCWeb.BindReader("SELECT  1 As SNO,RM.DocumentID As DocumentID,DocumentName1 AS Documen,CAST(CASE WHEN RS.StudentID IS NULL THEN 0 ELSE 1 END AS Bit)AS YES,  " +
						  " CASE WHEN RS.StudentID IS NULL THEN 'Documents/NoImage.JPG'   ELSE 'Documents/D'+CAST(StudentID As Varchar)+'_'+Cast(RM.DocumentID As Varchar)+ISNULL([Type],'') END as imgpath  " +
						  " from MTDOCUMENTMASTER RM  LEFT JOIN SISTUDENTDOCUMENTDETAILS RS on RM.DocumentID = RS.DocumentID ANd StudentID=" + intStudentID + "    WHERE RM.DocumentID<>0 ORDER BY RM.DOCUMENTID");
		gvDocuments.DataBind();


		ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");


		gvSibling.DataSource = objCCWeb.BindReader("SELECT '' AS SNO, SYWD.AdmissionNo,REPLACE(ISNULL(SM.FirstName,'')+' '+ISNULL(SM.MiddleName,'')+' '+ISNULL(SM.LastName,''),'  ',' ') AS StudentName,(ISNULL(ClassName1,'')+' '+ISNULL(SectionName1,'')) As ClassSection FROM SIStudentMaster SM  INNER JOIN SIStudentYearWiseDetails SYWD ON SM.StudentID=SYWD.StudentID   " +
			" INNER JOIN MTClassMaster CM ON SYWD.ClassID=CM.ClassID INNER JOIN MTSectionMaster SecM ON SYWD.SectionID=SecM.SectionID  WHERE PARENTID=" + strArray1[17] + "    AND  " +
		 "  SYWD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo<>'" + txtAdmNo.Text.Trim() + "'  AND SYWD.AcaStart=" + Session["AcaStart"] + "   ORDER BY SM.StudentID");
		gvSibling.DataBind();

		gvPreviousEducation.DataSource = objCCWeb.BindReader("EXEC  spSIFillingGridForEntry 'SIStudentPreviousEducationDetails'," + intStudentID + "");
		gvPreviousEducation.DataBind();


		objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 ORDER BY  MotherTongueName1", "MotherTongueID", "MotherTongueName", "");
		string vardata2 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM SIstudentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
								  "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");
		objCCWeb.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName1 AS MotherTongueName,1 as id FROM MTMotherTongueMaster  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata2 + "',',')) union Select MotherTongueID,MotherTongueName1 As MotherTongueName,2 as id From MTMotherTongueMaster WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata2 + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName", "");

		if (vardata2 != "0")
		{
			string[] varStr = vardata2.Split(',');
			for (int i = 0; i < varStr.Length; i++)
			{
				if (chkLanguageKnown.Items.Count > 0)
				{
					for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
					{
						if (chkLanguageKnown.Items[inti].Value == varStr[i])
						{
							chkLanguageKnown.Items[inti].Selected = true;
						}

					}
				}
			}
		}


		string vardata8 = objCCWeb.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(ImpairmentID AS Varchar)  FROM SIStudentTypeofImpairmentDetails Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
									   "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

		objCCWeb.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName,1 as id FROM MTImpairmentMaster  WHERE ImpairmentID<>0 AND ImpairmentID IN (select * from [fnSplit] ('" + vardata8 + "',',')) union Select ImpairmentID,Impairment As ImpairmentName,2 as id From MTImpairmentMaster WHERE ImpairmentID<>0  AND ImpairmentID NOT IN (select * from [fnSplit] ('" + vardata8 + "',',')) ORDER BY id ", "ImpairmentID", "ImpairmentName", "");

		if (vardata8 != "0")
		{
			string[] varStr1 = vardata8.Split(',');
			for (int i = 0; i < varStr1.Length; i++)
			{
				if (chkImpairment.Items.Count > 0)
				{
					for (int inti = 0; inti < chkImpairment.Items.Count; inti++)
					{
						if (chkImpairment.Items[inti].Value == varStr1[i])
						{
							chkImpairment.Items[inti].Selected = true;
						}

					}
				}
			}
		}
		if ((objCCWeb.ReturnSingleValue("Select  CONVERT(VARCHAR,UpdateDate,103) from SIStudentmaster Where StudentID='" + intStudentID + "'") == "") || (objCCWeb.ReturnSingleValue("Select  CONVERT(VARCHAR,UpdateDate,103) from SIStudentmaster Where StudentID='" + intStudentID + "'") == "NULL"))
		{
			lblcaption = "Entry Date";
		}
		else
		{
			lblcaption = "Last Modified Date ";
		}
		lblLastMDate.Text = "(" + lblcaption + " : " + objCCWeb.ReturnSingleValue("Select CONVERT(VARCHAR,ISNULL(UpdateDate,EntryDate),103) FROM SIStudentmaster where  StudentID=" + intStudentID + " ") + ")";

	}
	protected void fBusRouteDetails(int intStudent)
	{
		//debugger;

		lblBusMorning.Text = objCCWeb.ReturnSingleValue("SELECT ISNULL(BRM.BusRouteNo,'')+'-'+ ISNULL(BusStopName1,'') FROM TRBusroutemaster BRM JOIN TRBusroutedetails BRD  " +
			" ON BRM.BusRouteID=BRD.BusRouteID JOIN  SISTUDENTBUSROUTEDETAILS  BSD ON BSD.BusStopID=BRD.BusStopID WHERE BSD.TravelType='M' AND BSD.Active='Y' AND BSD.StudentID=" + intStudent + "  AND   BRM.SchoolId=" + Session["SchoolID"] + " AND  BSD.AcaStart=" + Session["AcaStart"] + " ");

		if (lblBusMorning.Text != "")
		{
			lblBusMorninghr.Text = objCCWeb.ReturnSingleValue("SELECT caption1 FROM mtformcontrolmaster where ControlName='tdBusMorninghr' AND Formid=307");
			//lblBusMorninghr.style.display="";
			//lblBusMorninghr.Attributes("display", "none");
			ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> ShowBusRoute();</script>");

		}
		else
		{
			lblBusMorninghr.Text = "";
		}

		lblBusAfterNoon.Text = objCCWeb.ReturnSingleValue("SELECT ISNULL(BRM.BusRouteNo,'')+'-'+ ISNULL(BusStopName1,'') FROM TRBusroutemaster BRM JOIN TRBusroutedetails BRD  " +
		" ON BRM.BusRouteID=BRD.BusRouteID JOIN  SISTUDENTBUSROUTEDETAILS  BSD ON BSD.BusStopID=BRD.BusStopID WHERE BSD.TravelType='A' AND BSD.Active='Y' AND BSD.StudentID=" + intStudent + " AND   BRM.SchoolId=" + Session["SchoolID"] + " AND  BSD.AcaStart=" + Session["AcaStart"] + " ");
		if (lblBusAfterNoon.Text != "")
		{
			lblBusAfterNoonhr.Text = objCCWeb.ReturnSingleValue("SELECT caption1 FROM mtformcontrolmaster where ControlName='tdBusAfterNoonhr' AND Formid=307");
			// lblBusAfterNoonhr.Style("display", "none");
			//document.getElementById('tdBusAfterNoon').style.display="";
			ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> ShowBusRoute();</script>");

		}
	}
	protected void gvPreviousEducation_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex > -1)
		{
			((TextBox)e.Row.FindControl("txtYearAttended")).Attributes.Add("onkeypress", "Javascript:return Restrict_Pincode(event);");
		}

	}
	protected void btnSiblingSearch_Click(object sender, EventArgs e)
	{
		string SQLQuery = "";
		if (hidSiblingAdm.Value != "")
		{
			SQLQuery = "Select ParentID FROM SIStudentMaster SIM JOIN SIStudentYearwisedetails SYD ON SYD.StudentID=SIM.StudentID WHERE SYD.AcaStart=" + Session["AcaStart"] + "" +
				" AND SYD.SchoolID=" + Session["SchoolID"] + " AND AdmissionNo='" + hidSiblingAdm.Value + "'";
			hidParentID.Value = objCCWeb.ReturnSingleValue(SQLQuery);
			txtParentID.Text = hidParentID.Value;
			if (hidParentID.Value == "")
			{
				ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('Student Does Not Exist!');callreturn();</script>");
				txtSiblingAdmNo.Focus();
				return;
			}
			btnDisplay_Click(sender, e);
		}
		else
		{
			ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert(' Please Enter Admission No or Select Student Name From List..');callreturn();</script>");
			txtSiblingAdmNo.Focus();
			return;
		}

	}
}
