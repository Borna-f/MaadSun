using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaadSun_Object;
namespace MaadSun.Customer
{
    public partial class CustomerMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                //LoginPanel.Visible = false;
                LoginPanel.CssClass = "Hidden";
                //User.Visible= true;
                if (Convert.ToInt32(Session["Priv"]) == (int)RoleUser.Admin )
                {
                    AdminPanel.CssClass = "Inline";
                    CustomerPanel.CssClass = "Hidden";
                }
                else
                {
                    CustomerPanel.CssClass = "Inline";
                    AdminPanel.CssClass = "Hidden";
                }
            }

        }

        protected void CloseSession_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}