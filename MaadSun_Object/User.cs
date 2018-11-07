using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;
namespace MaadSun_Object
{
    public class UserList //: Grid
    {
        private List<UserService> _Rows = new List<UserService>();
        public List<UserService> Rows
        {
            get { return _Rows; }
            set { _Rows = value; }
        }
    }


    public class UserFilter //: BaseFilter
    {
        private User _User = new User();
        public User User
        {
            get { return _User; }
            set { _User = value; }
        }
    }

    public class UserService
    {

        private int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Firstname;
        public string Firstname
        {
            get { return _Firstname; }
            set { _Firstname = value; }
        }


        private string _Familyname;
        public string Familyname
        {
            get { return _Familyname; }
            set { _Familyname = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _Phonenumber;
        public string Phonenumber
        {
            get { return _Phonenumber; }
            set { _Phonenumber = value; }
        }


        private int? _Privilage;
        public int? Privilage
        {
            get { return _Privilage; }
            set { _Privilage = value; }
        }

        private string _WebPageXML;
        public string WebPageXML
        {
            get { return _WebPageXML; }
            set { _WebPageXML = value; }
        }

        

        //private int? _TryCount;
        //public int? TryCount
        //{
        //    get { return _TryCount; }
        //    set { _TryCount = value; }
        //}


        //private DateTime? _BanDate;
        //public DateTime? BanDate
        //{
        //    get { return _BanDate; }
        //    set { _BanDate = value; }
        //}

        //private int? _TotalBanCount;
        //public int? TotalBanCount
        //{
        //    get { return _TotalBanCount; }
        //    set { _TotalBanCount = value; }
        //}

    }


    public class User : UserService
    {
        public readonly string UserID_FIELD = "UserID";
        public readonly string Username_FIELD = "Username";
        public readonly string Firstname_FIELD = "Firstname";
        public readonly string Familyname_FIELD = "Familyname";
        public readonly string Phonenumber_FIELD = "Phonenumber";
        public readonly string Email_FIELD = "Email";
        public readonly string Address_FIELD = "Address";
        public readonly string Password_FIELD = "Password";
        public readonly string Privilage_FIELD = "Privilage";
        public readonly string WebPageXML_FIELD = "WebPage";
        //public readonly string TryCount_FIELD = "TryCount";
        //public readonly string BanDate_FIELD = "BanDate";
        //public readonly string BanCount_FIELD = "TotalBanCount";



        public UserService GetService()
        {
            var cs = new UserService();
            cs.UserID = UserID;
            cs.Firstname = Firstname;
            cs.Familyname = Familyname;
            cs.Phonenumber = Phonenumber ;
            cs.Email = Email;
            cs.Address = Address;
            cs.Username = Username;
            cs.Password = Password;
            cs.Privilage = Privilage;
            cs.WebPageXML = WebPageXML;
            //cs.TryCount = TryCount;
            //cs.BanDate = BanDate;
            //cs.TotalBanCount = TotalBanCount;
            return cs;
        }

        public void FillForObject(IDataReader dataReader)
        {
            int fieldCount = dataReader.FieldCount;
            var Columns = new List<string>();
            for (int i = 0; i < fieldCount; i++)
            {
                Columns.Add(dataReader.GetName(i));
            }

            if (Columns.Contains(UserID_FIELD) && dataReader[UserID_FIELD] != DBNull.Value) this.UserID = Convert.ToInt32(dataReader[UserID_FIELD]);
            if (Columns.Contains(Firstname_FIELD) && dataReader[Firstname_FIELD] != DBNull.Value) this.Firstname = Convert.ToString(dataReader[Firstname_FIELD]);
            if (Columns.Contains(Familyname_FIELD) && dataReader[Familyname_FIELD] != DBNull.Value) this.Familyname = Convert.ToString(dataReader[Familyname_FIELD]);
            if (Columns.Contains(Phonenumber_FIELD) && dataReader[Phonenumber_FIELD] != DBNull.Value) this.Phonenumber = Convert.ToString(dataReader[Phonenumber_FIELD]);
            if (Columns.Contains(Email_FIELD) && dataReader[Email_FIELD] != DBNull.Value) this.Email = Convert.ToString(dataReader[Email_FIELD]);
            if (Columns.Contains(Address_FIELD) && dataReader[Address_FIELD] != DBNull.Value) this.Address = Convert.ToString(dataReader[Address_FIELD]);
            if (Columns.Contains(Username_FIELD) && dataReader[Username_FIELD] != DBNull.Value) this.Username = Convert.ToString(dataReader[Username_FIELD]);
            if (Columns.Contains(Password_FIELD) && dataReader[Password_FIELD] != DBNull.Value) this.Password = Convert.ToString(dataReader[Password_FIELD]);
            if (Columns.Contains(Privilage_FIELD) && dataReader[Privilage_FIELD] != DBNull.Value) this.Privilage = Convert.ToInt32(dataReader[Privilage_FIELD]);
            if (Columns.Contains(WebPageXML_FIELD) && dataReader[WebPageXML_FIELD] != DBNull.Value) this.WebPageXML = Convert.ToString(dataReader[WebPageXML_FIELD]);
            //if (Columns.Contains(TryCount_FIELD) && dataReader[TryCount_FIELD] != DBNull.Value) this.TryCount = Convert.ToInt32(dataReader[TryCount_FIELD]);
            //if (Columns.Contains(BanDate_FIELD) && dataReader[BanDate_FIELD] != DBNull.Value) this.BanDate = Convert.ToDateTime(dataReader[BanDate_FIELD]);
            //if (Columns.Contains(BanCount_FIELD) && dataReader[BanCount_FIELD] != DBNull.Value) this.TotalBanCount = Convert.ToInt32(dataReader[BanCount_FIELD]);

        }
    }



}
