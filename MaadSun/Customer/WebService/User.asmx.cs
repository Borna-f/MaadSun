using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MaadSun_Object;
using MaadSun_Interface;
using System.Net.Mail;
namespace MaadSun.Customer
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class User : System.Web.Services.WebService
    {

        [WebMethod(EnableSession=true)]
        public string GetFilteredUser(UserFilter UFilt)
        {
            UserList UList = new UserList();
            UList = MaadSun_Interface.MaadSun_In.GETFILTEREDUSER(UFilt);
            

            if (UList.Rows.Count == 1)
            { 
                Session["UserID"] = UList.Rows[0].UserID;

                Session["Username"] = UList.Rows[0].Username;
                Session["Address"] = UList.Rows[0].Address;
                Session["Phonenumber"] = UList.Rows[0].Phonenumber;
                Session["Firstname"] = UList.Rows[0].Firstname;
                Session["Familyname"] = UList.Rows[0].Familyname;
                Session["Email"] = UList.Rows[0].Email;
                //Session["Name"] = UList.Rows[0].Firstname + ' '  + UList.Rows[0].Familyname;
                Session["Priv"] = UList.Rows[0].Privilage;
                Session["WebPage"] = UList.Rows[0].WebPageXML;
                //HttpCookie ck = new HttpCookie();
                //ck.Value = "Test";
                return "Success";
            }

            else
                return "";
        }

        [WebMethod]
        public string SendForgottenEmail(string Username,string Email)
        {
            UserFilter UFilt = new UserFilter();
            if (Username != null && Username != "")
                UFilt.User.Username = Username;
            else
                UFilt.User.Email = Email;

            UserList UList = new UserList();
            UList = MaadSun_Interface.MaadSun_In.GETFILTEREDUSER(UFilt);
            if (UList.Rows.Count == 1)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.mail.yahoo.com");

                mail.From = new MailAddress("pink_floyd_the_best_rock@yahoo.com");
                mail.To.Add(UList.Rows[0].Email);
                mail.Subject = "بازیابی کلمه عبور گروه طراحان آفتاب ماد";
                mail.Body = UList.Rows[0].Firstname + ' ' + UList.Rows[0].Familyname + ' ' + "گرامی" + '\n' +
                     "اطلاعات کاربری شما به شرح زیر می باشد : " + '\n' +
                     "نام کاربری : " + UList.Rows[0].Username + '\n'
                     + "کلمه عبور : " + UList.Rows[0].Password;


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("pink_floyd_the_best_rock", "SecretPrayer1");
                SmtpServer.EnableSsl = true;
                
                SmtpServer.Send(mail);
                
                return "Success";
            }
            return "";
        }
        [WebMethod]
        public bool CheckifUsernameExists(string Username)
        {
            UserFilter UFilt = new UserFilter();
            UFilt.User.Username = Username;
            if (MaadSun_Interface.MaadSun_In.GETFILTEREDUSER(UFilt).Rows.Count > 0)
                return true;
            return false;
        }

        [WebMethod]
        public bool CheckifEmailExists (string Email)
        {
            UserFilter UFilt = new UserFilter();
            UFilt.User.Email = Email;
            if (MaadSun_Interface.MaadSun_In.GETFILTEREDUSER(UFilt).Rows.Count > 0)
                return true;
            return false;
        }



        [WebMethod]
        public int CreateUser(UserFilter UFilt)
        {
            return MaadSun_Interface.MaadSun_In.CreateUser(UFilt);
        }

        [WebMethod(EnableSession=true)]
        public void UpdateUser(UserFilter UFilt)
        {
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
                Session["WebPage"] = UList.Rows[0].WebPageXML;
                //HttpCookie ck = new HttpCookie();
                //ck.Value = "Test";
        }
        [WebMethod]
        public UserList GetAllUsers()
        {
            UserFilter UFilt = new UserFilter();
            //UFilt.Order = "ASC";
            UserList Ulist = new UserList();
            Ulist = MaadSun_Interface.MaadSun_In.GETFILTEREDUSER(UFilt);
            return Ulist;
        }

    }
}
