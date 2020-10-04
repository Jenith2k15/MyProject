using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker.FamilyExpense
{
    public partial class Savings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsolidatedReportRepository consolidatedReportRepository =
                new ConsolidatedReportRepository();
            try
            {
                AccountBreakUp accountBreakUp = consolidatedReportRepository.GetFamilyIncomeExpenditureAndSaving();
                lblIncome.Text = accountBreakUp.Income.ToString();
                lblExpenditure.Text = accountBreakUp.Expenditure.ToString();
                lblSavings.Text = accountBreakUp.Savings.ToString();
            }
            
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}