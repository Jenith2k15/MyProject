using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker.FamilyMember
{
    public partial class AddFamilyMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            { 
                BO.FamilyMember familyMember = new BO.FamilyMember()
                {
                    Name = name.Text,
                    Cell = Convert.ToInt64(cell.Text),
                    Work = work.Text,
                    Income = Convert.ToInt32(income.Text)
                };

                FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
                try
                {
                    int insertStatus = familyMemberRepository.AddFamilyMember(familyMember);
                    if (insertStatus == (int)Utilities.OperationState.Inserted)
                    {
                        Response.Redirect("FamilyMemberDetails.aspx");
                    }
                    else
                    {
                        errorMessage.Text = "Name or Cell is already available";
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