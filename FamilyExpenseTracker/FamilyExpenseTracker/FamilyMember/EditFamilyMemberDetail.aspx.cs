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
    public partial class EditFamilyMember : System.Web.UI.Page
    {
        FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["FamilyMembers"] != null)
                {
                    List<BO.FamilyMember> familyMembers = (List<BO.FamilyMember>)Session["FamilyMembers"];

                    BO.FamilyMember editFamilyMember
                    = familyMembers.Find(familyMember => familyMember.FamilyMemberId == Convert.ToInt32(Request.QueryString["FamilyMemberId"]));
                    fmid.Value = editFamilyMember.FamilyMemberId.ToString();
                    name.Text = editFamilyMember.Name;
                    cell.Text = editFamilyMember.Cell.ToString();
                    work.Text = editFamilyMember.Work;
                    income.Text = editFamilyMember.Income.ToString();
                }

                else
                {
                    Server.Transfer("FamilyMemberDetails.aspx");
                }
                
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            { 
                BO.FamilyMember familyMember = new BO.FamilyMember()
                {
                    FamilyMemberId = Convert.ToInt32(fmid.Value),
                    Name = name.Text,
                    Cell = Convert.ToInt64(cell.Text),
                    Work = work.Text,
                    Income = Convert.ToInt32(income.Text)
                };

                try
                {
                    int editStatus = familyMemberRepository.EditFamilyMember(familyMember);
                    if (editStatus == (int)Utilities.OperationState.Edited)
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