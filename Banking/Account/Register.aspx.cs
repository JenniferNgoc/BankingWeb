using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Banking.Bussiness;

namespace Banking.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                new AccountService().RegisterAccount(AccountNumber.Text, AccountName.Text, Password.Text, Convert.ToDecimal(Balance.Text));

                ErrorMessage.Text = "Your account has been created successfully and is ready to use";
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }
    }
}