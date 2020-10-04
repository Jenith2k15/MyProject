using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker.FamilyExpense
{
    public partial class ConsolidatedExpenseReport : System.Web.UI.Page
    {
        ConsolidatedReportRepository consolidatedReportRepository =
                new ConsolidatedReportRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<List<ConsolidatedReport>> lstConsolidatedReports
            = consolidatedReportRepository.GetTodayYesterdayAndMonthlyExpense();

            try
            {
                int todayFamilyExpenseTotal = 0;
                int yesterdayFamilyExpenseTotal = 0;
                int monthlyFamilyExpenseTotal = 0;
                foreach (var consolidatedReports in lstConsolidatedReports)
                {
                    foreach (var consolidatedReport in consolidatedReports)
                    {
                        if (consolidatedReport.Remark == Utilities.TodayYesterdayAndMonthly.Today.ToString())
                        {
                            todayFamilyExpenseTotal = todayFamilyExpenseTotal + consolidatedReport.Spent;
                            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("p");
                            //htmlGenericControl.InnerText = consolidatedReport.Name + " spent " + consolidatedReport.Spent;
                            htmlGenericControl.InnerText = $"{consolidatedReport.Name} spent {consolidatedReport.Spent}";
                            divToday.Controls.Add(htmlGenericControl);
                        }

                        else if (consolidatedReport.Remark == Utilities.TodayYesterdayAndMonthly.Yesterday.ToString())
                        {
                            yesterdayFamilyExpenseTotal = yesterdayFamilyExpenseTotal + consolidatedReport.Spent;
                            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("p");
                            //htmlGenericControl.InnerText = consolidatedReport.Name + " spent " + consolidatedReport.Spent;
                            htmlGenericControl.InnerText = $"{consolidatedReport.Name} spent {consolidatedReport.Spent}";
                            divYesterday.Controls.Add(htmlGenericControl);
                        }

                        else if (consolidatedReport.Remark == Utilities.TodayYesterdayAndMonthly.Monthly.ToString())
                        {
                            monthlyFamilyExpenseTotal = monthlyFamilyExpenseTotal + consolidatedReport.Spent;
                            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("p");
                            //htmlGenericControl.InnerText = consolidatedReport.Name + " spent " + consolidatedReport.Spent;
                            htmlGenericControl.InnerText = $"{consolidatedReport.Name} spent {consolidatedReport.Spent}";
                            divCurrentMonth.Controls.Add(htmlGenericControl);
                        }
                    }
                    divTodayTotal.InnerText = $"Total : {todayFamilyExpenseTotal.ToString()}";
                    divYesterdayTotal.InnerText = $"Total : {yesterdayFamilyExpenseTotal.ToString()}";
                    divCurrentMonthTotal.InnerText = $"Total : {monthlyFamilyExpenseTotal.ToString()}";
                }
            }

            catch(Exception ex)
            {
                throw ex;
            }

            message.Attributes.Add("Class", "alert alert-danger collapse");
        }        

        protected void FilterExpenseSpentByIndidual(object sender, EventArgs e)
        {
            divDateRangeTxt.InnerText = $"{startDate.Text}/{endDate.Text}";
            try
            { 
                List<ConsolidatedReport> consolidatedReportBetweenTwoDates =
                    consolidatedReportRepository.GetCumulativeFamilyExpenseByDate(startDate.Text,endDate.Text);

                if(consolidatedReportBetweenTwoDates.Count != (int)Utilities.OperationState.ZeroCount)
                { 
                    int cumulativeTotal = 0;
                    foreach (var item in consolidatedReportBetweenTwoDates)
                    {
                        cumulativeTotal = cumulativeTotal + item.Spent;
                        HtmlGenericControl htmlGenericControl = new HtmlGenericControl("p");
                        //htmlGenericControl.InnerText = item.Name + " spent " + item.Spent;
                        htmlGenericControl.InnerText = $"{item.Name} spent {item.Spent}";
                        divDateRange.Controls.Add(htmlGenericControl);
                    }
                    divDateRangeTotal.InnerText = $"Total : {cumulativeTotal.ToString()}";
                }

                else
                {
                    errorMessage.InnerText = "No Record Found!";
                    message.Attributes.Add("Class", "alert alert-danger show");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}