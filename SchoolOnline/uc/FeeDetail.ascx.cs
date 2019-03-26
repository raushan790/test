using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SchoolOnline;

public partial class SchoolOnline_uc_FeeDetail : System.Web.UI.UserControl
{

    dalCommon objCommon;
    dalDashboard objDashboard;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetFeeDetails();
    }
    protected void GetFeeDetails()
    {
        DataTable dt = new DataTable();
       objCommon = new dalCommon();
       objDashboard = new dalDashboard();
       objCommon.AcaStart = Session["AcaStart"].ToString();
       objCommon.SchoolId = Session["SchoolID"].ToString();
       objCommon.StudEmp = Session["StudentID"].ToString();
       try
       {
          dt.Load(objDashboard.GetFeeDetails(objCommon));

          if (dt.Rows.Count > 0)
          {
              ltrlFeedetail.Text = "";
              ltrlFeedetail.Text += "<div class='heading'>" +
              "<div class='col'>Installment</div>" +
              "<div class='col'>Amount</div>" +
               "<div class='col'>Paid</div>" +
                "<div class='col'>Fine/Excess</div>" +
                 "<div class='col'>Balance</div>" +
         "</div>";
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  if (i + 1 != dt.Rows.Count)
                  {
                      ltrlFeedetail.Text += "<div class='table-row'>";
                      ltrlFeedetail.Text += "<div class='col'>";
                      ltrlFeedetail.Text += "" + dt.Rows[i]["Installment"] + "</div>";
                      ltrlFeedetail.Text += "<div class='col'>";
                      ltrlFeedetail.Text += "" + dt.Rows[i]["Amount"] + "</div>";
                      ltrlFeedetail.Text += "<div class='col'>";
                      ltrlFeedetail.Text += "" + dt.Rows[i]["Paid"] + "</div>";
                      ltrlFeedetail.Text += "<div class='col'>";
                      ltrlFeedetail.Text += "" + dt.Rows[i]["Fine/Excess"] + "</div>";
                      ltrlFeedetail.Text += "<div class='col'>";
                      ltrlFeedetail.Text += "" + dt.Rows[i]["Balance"] + "</div>";
                                    ltrlFeedetail.Text += "</div>";
                        }
                  else
                  {
                      ltrlFeedetail.Text += " <div class='total'>";
                      ltrlFeedetail.Text += "<div class='col'>";
                      ltrlFeedetail.Text += "" + dt.Rows[i]["Installment"] + "</div>";
                      ltrlFeedetail.Text += "<div class=\"col\">" + dt.Rows[i]["Amount"] + "</div>";
                      ltrlFeedetail.Text += "<div class=\"col\">" + dt.Rows[i]["Paid"] + "</div>";
                      ltrlFeedetail.Text += "<div class=\"col\">" + dt.Rows[i]["Fine/Excess"] + "</div>";
                      ltrlFeedetail.Text += "<div class=\"col\">" + dt.Rows[i]["Balance"] + "</div>";
                      ltrlFeedetail.Text += "</div>";
                  }
              }
          }
          // rptrFeeDetails.DataSource = objDashboard.GetFeeDetails(objCommon);
          // rptrFeeDetails.DataBind();
       }
       catch (Exception)
       {
           throw;
       }
       finally
       {
           objCommon = null;
           objDashboard = null;
       }
    }
}