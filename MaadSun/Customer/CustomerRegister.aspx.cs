using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaadSun_Object;
namespace MaadSun.Customer
{
    public partial class CustomerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
                Response.Redirect("Index.aspx");
        }

        protected void Register_Button_Click(object sender, EventArgs e)
        {
            if (this.CaptchaTxT.Text.ToLower() == this.Session["CaptchaImageText"].ToString().ToLower())
            {

                UserFilter UFilt = new UserFilter();
                UFilt.User.Username = Username.Value;
                UFilt.User.Password = Pass.Value;
                UFilt.User.Privilage = 80;
                UFilt.User.Firstname = Firstname.Value;
                UFilt.User.Familyname = Familyname.Value;
                UFilt.User.Address = Address.Value;
                UFilt.User.Email = Email.Value;
                UFilt.User.Phonenumber = PhoneNumber.Value;
                MaadSun_Interface.MaadSun_In.CreateUser(UFilt);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", "ShowMessage('کاربر با موفقیت به ثبت رسید', 'ثبت کاربر');", true); 
                
                lblmsg.Text = "";
            }
            else
            {
                lblmsg.Text = "متن وارد شده با تصویر مطابقت ندارد";
                //return false;
            }
            this.CaptchaTxT.Text = "";
            this.Firstname.Value = "";
            this.Familyname.Value = "";
            this.Address.Value = "";
            this.Username.Value = "";
            this.Email.Value = "";
            this.PhoneNumber.Value = "";
        }
    }
}