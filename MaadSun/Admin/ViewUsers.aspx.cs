using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaadSun_Object;
using System.IO;
namespace MaadSun.Admin
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Convert.ToInt32(Session["Priv"]) != (int) MaadSun_Object.RoleUser.Admin)
            {
                Response.Redirect("/Customer/Index.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            UserFilter User = new UserFilter();
            User.User.Username = Username.Value;
            User.User.Password = password.Value;
            User.User.Firstname = Firstname.Value;
            User.User.Familyname = Familyname.Value;
            User.User.Phonenumber = Phonenumber.Value;
            User.User.Address = Address.Value;
            User.User.Email = Email.Value;
            User.User.Privilage = System.Convert.ToInt32(UserType.Value);

            User.User.UserID = (System.Convert.ToInt32(HUserID.Value));
            MaadSun_Interface.MaadSun_In.UpdateUser(User);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "ShowMessage('کاربر با موفقیت ویرایش شد','ویرایش کاربر')", true);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            MaadSun_Interface.MaadSun_In.DeleteUser(System.Convert.ToInt32(HUserID.Value));
            string filepath = "";
            ImageFilter ImFilt = new ImageFilter();
            ImageList ImList = new ImageList();
            ImFilt.Image.UserID = System.Convert.ToInt32(HUserID.Value);
            ImList = MaadSun_Interface.MaadSun_In.GetFilteredImage(ImFilt);
            for (int i = 0; i < ImList.Rows.Count; i++)
            {
                filepath = Server.MapPath("~/Uploads/" + ImList.Rows[i].Imagename);
                File.Delete(filepath);
            }
                MaadSun_Interface.MaadSun_In.DeleteImageByUserID(System.Convert.ToInt32(HUserID.Value));
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "ShowMessage('کاربر با موفقیت حذف شد','حذف کاربر')", true);
        }
    }
}