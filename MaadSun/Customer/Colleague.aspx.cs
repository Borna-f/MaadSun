using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaadSun_Object;
namespace MaadSun.Customer
{
    public partial class Colleague : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserID"] == null || Request.QueryString["UserID"].ToString() == "") Response.Redirect("Index.aspx");
            int UserID = Convert.ToInt32(Request.QueryString["UserID"]);
            UserList Ulist = new UserList();
            Ulist = MaadSun_Interface.MaadSun_In.GETUSER(UserID);
            if (Ulist.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", "ShowMessage('صفحه مورد نظر موجود نیست', 'خطا ');", true);
                Response.Redirect("Index.aspx");
            }
            else if (Ulist.Rows[0].WebPageXML != null && Ulist.Rows[0].WebPageXML.ToString() != "")
            {
                XML XML = new XML();
                UsersHTML.InnerHtml = XML.ConvertXMLtoHTML(Ulist.Rows[0].WebPageXML);
            }
            


        }
    }
}