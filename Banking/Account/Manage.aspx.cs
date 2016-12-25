using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Banking.Bussiness;

namespace Banking.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var accountInfo = new AccountService().GetAccountInfo(Context.User.Identity.Name);
                gvTransaction.DataSource = accountInfo.UserTransactions.OrderByDescending(_ => _.Id);
                gvTransaction.DataBind();
            }

        }
    }
}