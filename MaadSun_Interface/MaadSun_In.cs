using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaadSun_Object;
using MaadSun_DataLayer;
namespace MaadSun_Interface
{
    public class MaadSun_In
    {
        public static UserList GETFILTEREDUSER (UserFilter UFilt)
        {
            MaadSunDB MDB = new MaadSunDB();
            UserList Ulist = new UserList();
            Ulist = MDB.GetUsers(UFilt);
            return Ulist;
        }

        public static UserList GETUSER(int ID)
        {
            MaadSunDB MDB = new MaadSunDB();
            UserList UList = new UserList();
            UList = MDB.GetUserbyID(ID);
            return UList;
        }

        public static int CreateUser(UserFilter UFilt)
        {
            MaadSunDB MDB = new MaadSunDB();
            int U = MDB.CreateUser(UFilt);
            return U;
        }

        public static int UpdateUser(UserFilter UFilt)
        {
            MaadSunDB MDB = new MaadSunDB();
            int U = MDB.UpdateUser(UFilt);
            return U;
        }
        public static int DeleteUser(int UserID)
        {
            MaadSunDB MDB = new MaadSunDB();
            int U = MDB.DeleteUser(UserID);
            return U;
        }
        public static int CreateImage(ImageFilter IFilt)
        {
            MaadSunDB MDB = new MaadSunDB();
            int U = MDB.CreateImage(IFilt);
            return U;
        }

        public static int DeleteImageByImagename(string Imagename)
        {
            MaadSunDB MDB = new MaadSunDB();
            int U = MDB.DeleteImageByImagename(Imagename);
            return U;
        }
        public static int DeleteImageByUserID(int UserID)
        {
            MaadSunDB MDB = new MaadSunDB();
            int U = MDB.DeleteImageByUserID(UserID);
            return U;
        }

        public static int UpdateImage(ImageFilter IFilt)
        {
            MaadSunDB MDB = new MaadSunDB();
            int U = MDB.UpdateImage(IFilt);
            return U;
        }

        public static ImageList GetFilteredImage(ImageFilter IFilt)
        {
            MaadSunDB MDB = new MaadSunDB();
            return MDB.GetFilteredImage(IFilt);
        }

        public static CategoryList GetCategoryList()
        {
            MaadSunDB MDB = new MaadSunDB();
            return MDB.GetCategories();
        }
        public static SubCategoryList GetFilteredSubCategory(SubCategoryFilter SCFilter)
        {
            MaadSunDB MDB = new MaadSunDB();
            return MDB.GetFilteredSubCategories(SCFilter);
        }
    }
}
