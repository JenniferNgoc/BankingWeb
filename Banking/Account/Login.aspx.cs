using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Banking.Bussiness;

namespace Banking.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                var account = new AccountService().Login(AccountNumber.Text, Password.Text);
                
                var userIdentity = new UserIdentity
                {
                    Name = account.AccountNumber, IsAuthenticated = true
                };
                var userPrincipal = new UserPrincipal
                {
                    Identity = userIdentity
                };

                HttpContext.Current.User = userPrincipal;
                FormsAuthentication.SetAuthCookie(account.AccountNumber,true);
                Response.Redirect("~/Account/Manage");

            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
            }
        }
    }

   
}