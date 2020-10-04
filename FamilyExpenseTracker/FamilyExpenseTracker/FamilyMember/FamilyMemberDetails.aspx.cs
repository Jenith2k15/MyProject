using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker.FamilyMember
{
    public partial class FamilyMembers : System.Web.UI.Page
    {
        FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    List<BO.FamilyMember> familyMembers = familyMemberRepository.GetAllFamilyMembers();
                    if(familyMembers.Count != (int)Utilities.OperationState.ZeroCount)
                    { 
                        Session["FamilyMembers"] = familyMembers;
                        GV.DataSource = familyMemberRepository.GetAllFamilyMembers();
                        GV.DataBind();
                    }
                    else
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
        }

        int totalIncome = 0;
        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalIncome += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Income"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Grand Total";
                e.Row.Cells[4].Font.Bold = true;

                e.Row.Cells[5].Text = totalIncome.ToString();
                e.Row.Cells[5].Font.Bold = true;
            }
        }

        protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object familyMemberId = e.Values[0];
            try
            {
                int deleteStatus = familyMemberRepository.DeleteFamilyMember(Convert.ToInt32(familyMemberId));
                if (deleteStatus >= (int)Utilities.OperationState.Deleted)
                {
                    Response.Redirect("FamilyMemberDetails.aspx");
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}