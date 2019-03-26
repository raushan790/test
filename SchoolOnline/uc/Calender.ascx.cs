using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;

public partial class SchoolOnline_uc_Calender : System.Web.UI.UserControl
{
    CCWeb objCCWeb = new CCWeb();
    protected static ArrayList alSelectDate = new ArrayList();
    protected DateTime dtDate;
    protected void Page_Load(object sender, EventArgs e)
    {

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
    protected void calDetails_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Cell.ID = "Cell/" + e.Day.Date.ToString("dd/MM/yyyy");
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }
        else
        {
            e.Cell.Attributes.Add("onmouseover", " javascript:return f_pfillDescription(event,'" + e.Day.Date.ToString("dd/MM/yyyy") + "',this)");
            e.Cell.Attributes.Add("onmouseOut", " javascript:return fCalendarMouseOut(event,'" + e.Day.Date.ToString("dd/MM/yyyy") + "',this)");

            string strdate1 = e.Day.Date.ToString("dd/MM/yyyy");


            //SqlDataReader sqlRdr4 = objCCWeb.BindReader("SELECT Convert(varchar,CalendarDate,103) ,CalendarType, CalendarRemarks+' '+Venue+' '+Discription  FROM MTCalendarMaster WHERE Convert(varchar,CalendarDate,103)='" + strdate1 + "'  AND DATENAME(DW,CalendarDate)<>'Sunday'  ");

            SqlDataReader sqlRdr4 = objCCWeb.BindReader("select TOP 1 EM.EventID, EventTIme+' '+ED.EventSubject+' '+ED.Venue+' '+ED.Discription from EventMaster EM " +
                                  " INNER JOIN EventDetail ED ON EM.EventID=ED.EventID INNER JOIN (Select DISTINCT EventID,EventSubject,Venue,Discription from eventdetail Where EventSubject<>'')SUB " +
                                  " ON SUB.EventID=ED.EventID AND SUB.EventSubject=ed.EventSubject AND Ed.Venue=sub.Venue  " +
                                  " Where EM.EventID IN(Select EventID from EventClassDetail ED INNER JOIN SIStudentYearWiseDetailS SYD ON SYD.ClassID=ED.ClassID AND SYD.SectionID=ED.SectionID Where StudentID=" + Session["StudentID"] + ") " +
                                  " AND EventDate>=(select AcaStartDate from MTAcademicSessionMaster Where Acastart=" + Session["AcaStart"] + ") AND EventDate<=(select AcaEndDate from MTAcademicSessionMaster Where Acastart=" + Session["AcaStart"] + ") " +
                                  " AND Convert(varchar,EM.EventDate,103)='" + strdate1 + "' " +
                                  " ORDER BY  EventDate DESC");




            while (sqlRdr4.Read())
            {

                if (e.Day.Date.DayOfWeek.ToString() != "Sunday")
                    if (sqlRdr4.GetValue(1).ToString().Trim() != "")
                    {
                        e.Cell.ToolTip = sqlRdr4.GetValue(1).ToString();
//                      e.Cell.Style.Add("background-image", "url(Images/Event.png)");
                        e.Cell.Style.Add("background-color", "green");
                        e.Cell.Style.Add("background-repeat", "no-repeat");
                        e.Cell.Style.Add("background-position", "center");
                    }

            }
            sqlRdr4.Close();
            sqlRdr4.Dispose();
            if ((alSelectDate.Contains(e.Day.Date.ToString("dd.MM.yyyy")) && (dtDate.Month == e.Day.Date.Month)) || (e.Day.Date.DayOfWeek.ToString() == "Sunday"))
            {
                //e.Cell.BackColor = System.Drawing.Color.FromName("#889999");
                hidSunday.Value = hidSunday.Value + '~' + e.Day.Date.ToString("dd.MM.yyyy");
            }
        }
    }
}