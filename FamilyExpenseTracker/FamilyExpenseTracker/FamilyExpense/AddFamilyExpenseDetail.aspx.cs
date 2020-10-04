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
    public partial class AddFamilyExpenseDetail : System.Web.UI.Page
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
                
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            { 
                BO.FamilyExpense familyExpense = new BO.FamilyExpense()
                {
                    Name = name.Text,
                    Purpose = purpose.Text,
                    Amount = Convert.ToInt32(amount.Text),
                    Date = Convert.ToDateTime(date.Text)
                };
            
                try
                {
                    int insertStatus = familyExpenseRepository.AddFamilyExpense(familyExpense);
                    if (insertStatus == (int)Utilities.OperationState.Inserted)
                    {
                        Response.Redirect("FamilyExpenseDetails.aspx");
                    }
                    else
                    {
                        Response.Redirect("AddFamilyExpenseDetail.aspx");
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