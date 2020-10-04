using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(email.Text, pwd.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(email.Text, remember.Checked);
            }
            else
            {
                errorMessage.Text = "Credentials Invalid";
            }
        }
    }
}