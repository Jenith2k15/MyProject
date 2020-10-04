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
    public partial class EditFamilyExpenseDetail : System.Web.UI.Page
    {
        FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    name.DataSource = familyExpenseRepository.GetAllFamilyMemberNames();
                    name.DataBind();
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                if (Session["FamilyExpenses"] != null)
                {
                    List<BO.FamilyExpense> familyExpenses = (List<BO.FamilyExpense>)Session["FamilyExpenses"];

                    BO.FamilyExpense editFamilyExpense
                    = familyExpenses.Find(familyExpense => familyExpense.ExpenseId == Convert.ToInt32(Request.QueryString["ExpenseId"]));

                    expenseId.Value = editFamilyExpense.ExpenseId.ToString();
                    familyMemberId.Value = editFamilyExpense.FamilyMemberId.ToString();
                    name.SelectedValue = editFamilyExpense.Name;
                    purpose.Text = editFamilyExpense.Purpose;
                    amount.Text = editFamilyExpense.Amount.ToString();
                    expenseDate.Text = editFamilyExpense.Date.ToString();
                }

                else
                {
                    Server.Transfer("FamilyExpenseDetails.aspx");
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            { 
                BO.FamilyExpense familyExpense = new BO.FamilyExpense
                {
                    ExpenseId = Convert.ToInt32(expenseId.Value),
                    FamilyMemberId = Convert.ToInt32(familyMemberId.Value),
                    Name = name.Text,
                    Purpose = purpose.Text,
                    Amount = Convert.ToInt32(amount.Text),
                    Date = Convert.ToDateTime(date.Text)
                };

                try
                {
                    int editStatus = familyExpenseRepository.EditFamilyExpense(familyExpense);
                    if (editStatus == (int)Utilities.OperationState.Edited)
                    {
                        Response.Redirect("FamilyExpenseDetails.aspx");
                    }
                    else
                    {
                        Response.Redirect("EditFamilyExpenseDetail.aspx");
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
