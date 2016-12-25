using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Banking.Bussiness;

namespace Banking.Account
{
    public partial class Withdraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var accountInfo = new AccountService().GetAccountInfo(Context.User.Identity.Name);
                AccountNumber.Text = accountInfo.AccountNumber;
                CurrentBalance.Text = accountInfo.Balance.Value.ToString("C");
            }
        }

        protected void Withdraw_Click(object sender, EventArgs e)
        {
            try
            {
                new TransactionService().Withdraw(Context.User.Identity.Name, Convert.ToDecimal(Amount.Text));
                CurrentBalance.Text = new AccountService().GetAccountInfo(Context.User.Identity.Name).Balance.Value.ToString("C");
                ErrorMessage.Text = "Your withdrawal request is successfully submitted";
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }
    }
}