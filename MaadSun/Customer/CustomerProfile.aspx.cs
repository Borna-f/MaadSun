using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaadSun_Object;
namespace MaadSun.Customer
{
    public partial class CustomerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("CustomerLogin.aspx");
                }
                else
                {
                    Username.Value = Session["Username"].ToString();
                    Firstname.Value = Session["Firstname"].ToString();
                    Familyname.Value = Session["Firstname"].ToString();
                    PhoneNumber.Value = Session["PhoneNumber"].ToString();
                    Email.Value = Session["Email"].ToString();
                    Address.Value = Session["Address"].ToString();
                }
            }
        }

        public bool CheckifUsernameExists(string Username)
        {
            UserFilter UFilt = new UserFilter();
            UFilt.User.Username = Username;
            if (MaadSun_Interface.MaadSun_In.GETFILTEREDUSER(UFilt).Rows.Count > 0)
                return true;
            return false;
        }

        
        public bool CheckifEmailExists (string Email)
        {
            UserFilter UFilt = new UserFilter();
            UFilt.User.Email = Email;
            if (MaadSun_Interface.MaadSun_In.GETFILTEREDUSER(UFilt).Rows.Count > 0)
                return true;
            return false;
        }

        protected void ChangeCustomerProfileBotton_Click(object sender, EventArgs e)
        {
            bool newUserExists = false ,newEmailExists = false;
            
            if (Username.Value != Session["Username"].ToString())
             newUserExists = CheckifUsernameExists (Username.Value);
            if(Email.Value != Session["Email"].ToString())
               newEmailExists = CheckifEmailExists (Email.Value);
                
            if(newEmailExists == false && newUserExists == false) 
            {
            UserFilter UFilt = new UserFilter();
            UFilt.User.Username = Username.Value;
            UFilt.User.Password = Pass.Value;
            UFilt.User.Privilage = Convert.ToInt32(Session["Priv"]);
            UFilt.User.Firstname = Firstname.Value;
            UFilt.User.Familyname = Familyname.Value;
            UFilt.User.Address = Address.Value;
            UFilt.User.Email = Email.Value;
            UFilt.User.Phonenumber = PhoneNumber.Value;
            UFilt.User.UserID = Convert.ToInt32(Session["UserID"].ToString());
            MaadSun_Interface.MaadSun_In.UpdateUser(UFilt);
            UserList UList = new UserList();
            UList = MaadSun_Interface.MaadSun_In.GETUSER(UFilt.User.UserID);

                Session["Username"] = UList.Rows[0].Username;
                Session["Address"] = UList.Rows[0].Address;
                Session["Phonenumber"] = UList.Rows[0].Phonenumber;
                Session["Firstname"] = UList.Rows[0].Firstname;
                Session["Familyname"] = UList.Rows[0].Familyname;
                Session["Email"] = UList.Rows[0].Email;
                //Session["Name"] = UList.Rows[0].Firstname + ' '  + UList.Rows[0].Familyname;
                Session["Priv"] = UList.Rows[0].Privilage;
                //HttpCookie ck = new HttpCookie();
                //ck.Value = "Test";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", "ShowMessage('مشخصات کاربری با موفقیت تغییر کرد', 'تغییر مشخصات');", true); 
            }
            else
            {
                if (newEmailExists == true)
              Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", "ShowMessage('این ایمیل قبلا به ثبت رسیده است', 'خطا');", true); 
                else
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", "ShowMessage('این نام کاربری قبلا به ثبت رسیده است', 'خطا');", true); 
           }
        }
    }
}