using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaadSun.Customer
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCustomerLogin_click(object sender, EventArgs e)
        {

        }

        protected void btnCustomerRegister_click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerReguster.aspx");
        }
    }
}