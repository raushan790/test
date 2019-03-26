using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class SchoolOnline_uc_attendance : System.Web.UI.UserControl
{
    CCWeb objCCWeb = new CCWeb();
    protected static ArrayList alSelectDate = new ArrayList();
    protected DateTime dtDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fAttCount(DateTime.Now.Month);
        }

    }
    protected void calDetails_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
        }
    }
    protected void calendarAttentance_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        try
        {
            fAttCount(e.NewDate.Month);
        }
        catch (Exception ex)
        {
        }
    }
    protected void calendarAttentance_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Cell.ID = "Cell/" + e.Day.Date.ToString("dd/MM/yyyy");
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }
        else
        {
            string strdate1 = e.Day.Date.ToString("dd/MM/yyyy");

            string strDate2 = objCCWeb.ReturnSingleValue("SELECT CASE WHEN SAED.SIAttRemarkID=1 THEN 'Present' WHEN SAED.SIAttRemarkID=3 THEN 'HalfDay' WHEN SAED.SIAttRemarkID=4 THEN    " +
                              " 'SportDay' ELSE 'Absent' END AS Attendance FROM SIStudentMaster SIM  INNER JOIN SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID  AND SYD.AcaStart=" + Session["AcaStart"] + " INNER JOIN SIStudentAttEntry SAE ON SAE.StudentID=SIM.StudentID  " +
                              "  INNER JOIN SIStudentAttEntryDetails SAED ON SAED.AttEntryID=SAE.AttEntryID   WHERE SIM.StudentID=" + Session["StudentID"] + " AND SYD.AcaStart=" + Session["AcaStart"] + " AND PeriodWiseEntry='0'  AND SAED.PeriodID='0' AND  Convert(varchar,SAE.AttDate,103)='" + strdate1 + "'  ");
            e.Cell.ToolTip = strdate1;
            if (strDate2 == "Present")
            {
                //e.Cell.BackColor = System.Drawing.Color.Green;
                e.Cell.Style.Add("background-image", "url(Images/Present.png)");//background-repeat :no-repeat ;background-position: center center;
                e.Cell.Style.Add("background-color", "#093");
                e.Cell.Style.Add("background-repeat", "no-repeat");
                e.Cell.Style.Add("background-position", "center");
                e.Cell.ToolTip = "Present";
            }
            else if (strDate2 == "HalfDay")
            {
                //e.Cell.BackColor = System.Drawing.Color.Maroon;
                e.Cell.Style.Add("background-image", "url(Images/HalfDay.png)");//background-repeat :no-repeat ;background-position: center center;
                e.Cell.Style.Add("background-color", "rgba(0, 0, 102, 0.4)");

                e.Cell.Style.Add("background-repeat", "no-repeat");
                e.Cell.Style.Add("background-position", "center");
                e.Cell.ToolTip = "HalfDay";
            }
            else if (strDate2 == "Absent")
            {
                e.Cell.Style.Add("background-image", "url(Images/Absent.png)");//background-repeat :no-repeat ;background-position: center center;
                e.Cell.Style.Add("background-color", "red");
                e.Cell.Style.Add("background-repeat", "no-repeat");
                e.Cell.Style.Add("background-position", "center");
                e.Cell.ToolTip = "Absent";
            }
            if ((alSelectDate.Contains(e.Day.Date.ToString("dd.MM.yyyy")) && (dtDate.Month == e.Day.Date.Month)) || (e.Day.Date.DayOfWeek.ToString() == "Sunday"))
            {
                //e.Cell.BackColor = System.Drawing.Color.FromName("#889999");
                hidSunday.Value = hidSunday.Value + '~' + e.Day.Date.ToString("dd.MM.yyyy");
            }
        }
    }
    protected void fAttCount(int intMonth)
    {
        //string strTotalDay = objCCWeb.ReturnSingleValue("select  COUNT(DISTINCT SAE.AttDate) from SIStudentAttEntry SAE  INNER JOIN SIStudentAttEntryDetails SAED ON SAED.AttEntryID=SAE.AttEntryID  WHERE Month(SAE.AttDate)=" + intMonth + "");
        string strTotalDay =   objCCWeb.ReturnSingleValue("select Count(*) from MTCalendarMaster where MONTH(CalendarDate)=" + intMonth + "" +
                    " AND CalendarDate>=(select AcaStartDate from MTAcademicSessionMaster where AcaStart=" + Session["AcaStart"] + " ) AND CalendarDate<=(select AcaEndDate from MTAcademicSessionMaster where AcaStart=" + Session["AcaStart"] + " )");
        string strStudentAtt = objCCWeb.ReturnSingleValue("SELECT   Count(DISTINCT SAE.AttDate) FROM SIStudentMaster SIM  INNER JOIN SIStudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID  AND SYD.AcaStart=" + Session["AcaStart"] + " INNER JOIN SIStudentAttEntry SAE ON SAE.StudentID=SIM.StudentID  " +
                               " INNER JOIN SIStudentAttEntryDetails SAED ON SAED.AttEntryID=SAE.AttEntryID  WHERE  SYD.AcaStart= " + Session["AcaStart"] + "  AND PeriodWiseEntry='0'  AND SAED.PeriodID='0'   AND SAE.AttDate NOT IN(SELECT CalendarDate From MTCalendarMaster where CalendarType='H') " +
                               " AND Month(SAE.AttDate)=" + intMonth + "  AND SIM.StudentID=" + Session["StudentID"] + "");
        if (strTotalDay != "0")
        {
            lblTotalAttendance.Text = " Total Attendance :-" + strStudentAtt + "/" + strTotalDay + "";
        }
        else
        {
            lblTotalAttendance.Text = "";
        }
    }
}