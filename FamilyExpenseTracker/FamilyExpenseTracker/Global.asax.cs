using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace FamilyExpenseTracker
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var serverError = Server.GetLastError() as HttpException;

            if (serverError != null)
            {
                if (serverError.GetHttpCode() == 404)
                {
                    Server.ClearError();
                    Server.Transfer("/Errors/404Error.aspx");
                }
            }

            if (Server.GetLastError() != null)
            {
                Logger.Log(Server.GetLastError());
                Server.ClearError();
                Server.Transfer("../Errors/Error.aspx");
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}