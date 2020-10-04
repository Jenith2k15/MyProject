using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker
{
    public partial class FamilyExpenseDetails : System.Web.UI.Page
    {
        FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    List<BO.FamilyExpense> familyExpenses = familyExpenseRepository.GetAllFamilyExpenses();
                    Session["familyExpenses"] = familyExpenses;
                    ExpenseGridView.DataSource = familyExpenses;
                    ExpenseGridView.DataBind();
                }

                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void SearchExpenseDetailsByName(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(search.Text))
            {
                try
                {
                    ExpenseGridView.DataSource = familyExpenseRepository.GetAllFamilyExpensesByName(search.Text);
                    ExpenseGridView.DataBind();
                    if (ExpenseGridView.Rows.Count == Convert.ToInt32(Utilities.OperationState.ZeroCount))
                    {
                        errorMessage.InnerText = "No Record Found!";
                        message.Attributes.Add("Class", "alert alert-danger show");
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Response.Redirect("FamilyExpenseDetails.aspx");
            }
        }

        protected void SearchExpenseDetailsByDate(object sender, EventArgs e)
        {
            if (startDate.Text != string.Empty && endDate.Text != string.Empty)
            {
                try
                {
                    ExpenseGridView.DataSource = familyExpenseRepository.GetFamilyExpenseDetailsByDate(startDate.Text, endDate.Text);
                    ExpenseGridView.DataBind();
                    if (ExpenseGridView.Rows.Count == Convert.ToInt32(Utilities.OperationState.ZeroCount))
                    {
                        errorMessage.InnerText = "No Record Found!";
                        message.Attributes.Add("Class", "alert alert-danger show");
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Response.Redirect("FamilyExpenseDetails.aspx");
            }
        }

        int totalExpense = 0;
        protected void ExpenseGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalExpense += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Grand Total";
                e.Row.Cells[4].Font.Bold = true;

                e.Row.Cells[5].Text = totalExpense.ToString();
                e.Row.Cells[5].Font.Bold = true;
            }
        }

        protected void ExpenseGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object expenseId = e.Values[0];
            try
            {
                int deleteStatus = familyExpenseRepository.DeleteFamilyExpense(Convert.ToInt32(expenseId));
                if (deleteStatus == (int)Utilities.OperationState.Deleted)
                {
                    Response.Redirect("FamilyExpenseDetails.aspx");
                }
            }
            
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}