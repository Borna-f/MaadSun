using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaadSun_Object;
namespace MaadSun.Customer
{
    public partial class UserWebPagePreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XML X = new XML();
            if (Session["WebPage"] != null && Session["WebPage"].ToString() != "")
                UsersHTML.InnerHtml = X.ConvertXMLtoHTML(Session["WebPage"].ToString());
            else if (Session["UserID"] == null) Response.Redirect("Index.aspx");
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", "ShowMessage('صفحه مورد نظر هنوز ساخته نشده است. به صفحه تنظیمات صفحه وب مراجعه نمایید', 'خطا ');", true);
            }
        }
    }
}