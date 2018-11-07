using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaadSun_Object;
using System.Data;
using System.Data.SqlClient;
namespace MaadSun_DataLayer
{
    public class MaadSunDB : BaseDB
    {
        #region UserParam
        private const string USER_USERID_PARAM = "@UserID";

        private const string USER_FIRSTNAME_PARAM = "@Firstname";
        private const string USER_FAMILYNAME_PARAM = "@Familyname";
        private const string USER_PHONENUMBER_PARAM = "@Phonenumber";
        private const string USER_EMAIL_PARAM = "@Email";
        private const string USER_ADDRESS_PARAM = "@Address";
        private const string USER_PRIVILAGE_PARAM = "@Privilage";
        private const string USER_WEBPAGE_PARAM = "@WebPage";
        private const string USER_USERNAME_PARAM = "@Username";
        private const string USER_PASSWORD_PARAM = "@Password";
        private const string GETFILTERED_USER_SP = "dbo.MaadSun_Users_GetFiltered";
        private const string CREATE_USER_SP = "dbo.MaadSun_Users_Create";
        private const string UPDATE_USER_SP = "dbo.MaadSun_Users_Update";
        private const string DELETE_USER_SP = "dbo.MaadSun_Users_Delete";
        private const string GET_USER_SP = "dbo.MaadSun_Users_Get";
        
        #endregion
        #region UserControler
        public UserList GetUsers(UserFilter UFilt)
        {
            SqlDataReader dataReader = null;
            UserList UserList = null;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = GETFILTERED_USER_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(USER_FIRSTNAME_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Firstname;
                sqlCommand.Parameters.Add(new SqlParameter(USER_FAMILYNAME_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Familyname;
                sqlCommand.Parameters.Add(new SqlParameter(USER_PHONENUMBER_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Phonenumber;
                sqlCommand.Parameters.Add(new SqlParameter(USER_EMAIL_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Email;
                sqlCommand.Parameters.Add(new SqlParameter(USER_ADDRESS_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Address;
                sqlCommand.Parameters.Add(new SqlParameter(USER_PRIVILAGE_PARAM, SqlDbType.Int)).Value = UFilt.User.Privilage;
                sqlCommand.Parameters.Add(new SqlParameter(USER_WEBPAGE_PARAM, SqlDbType.Xml)).Value = UFilt.User.WebPageXML;
                sqlCommand.Parameters.Add(new SqlParameter(USER_USERNAME_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Username;
                sqlCommand.Parameters.Add(new SqlParameter(USER_PASSWORD_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Password;
                ProjectConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                UserList = new UserList();
                while (dataReader.Read())
                {
                    User U = new User();
                    U.FillForObject(dataReader);
                    UserList.Rows.Add(U);
                }
                dataReader.Close();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("USER", ex);
            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return UserList ;
        }


        public UserList GetUserbyID(int ID)
        {
            SqlDataReader dataReader = null;
            UserList UserList = null;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = GET_USER_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(USER_USERID_PARAM, SqlDbType.Int)).Value = ID;
                ProjectConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                UserList = new UserList();
                while (dataReader.Read())
                {
                    User U = new User();
                    U.FillForObject(dataReader);
                    UserList.Rows.Add(U);
                }
                dataReader.Close();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("USER", ex);
            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return UserList;
        }



        public int CreateUser(UserFilter UFilt)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = CREATE_USER_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(USER_FIRSTNAME_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Firstname;
                sqlCommand.Parameters.Add(new SqlParameter(USER_FAMILYNAME_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Familyname;
                sqlCommand.Parameters.Add(new SqlParameter(USER_PHONENUMBER_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Phonenumber;
                sqlCommand.Parameters.Add(new SqlParameter(USER_EMAIL_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Email;
                sqlCommand.Parameters.Add(new SqlParameter(USER_ADDRESS_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Address;
                sqlCommand.Parameters.Add(new SqlParameter(USER_PRIVILAGE_PARAM, SqlDbType.Int)).Value = UFilt.User.Privilage;
                sqlCommand.Parameters.Add(new SqlParameter(USER_WEBPAGE_PARAM, SqlDbType.Xml)).Value = UFilt.User.WebPageXML;
                sqlCommand.Parameters.Add(new SqlParameter(USER_USERNAME_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Username;
                sqlCommand.Parameters.Add(new SqlParameter(USER_PASSWORD_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Password;
                ProjectConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("USER", ex);
            }
            finally
            {
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return result;
        }


        public int UpdateUser(UserFilter UFilt)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = UPDATE_USER_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(USER_USERID_PARAM, SqlDbType.Int)).Value = UFilt.User.UserID;
                sqlCommand.Parameters.Add(new SqlParameter(USER_FIRSTNAME_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Firstname;
                sqlCommand.Parameters.Add(new SqlParameter(USER_FAMILYNAME_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Familyname;
                sqlCommand.Parameters.Add(new SqlParameter(USER_PHONENUMBER_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Phonenumber;
                sqlCommand.Parameters.Add(new SqlParameter(USER_EMAIL_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Email;
                sqlCommand.Parameters.Add(new SqlParameter(USER_ADDRESS_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Address;
                sqlCommand.Parameters.Add(new SqlParameter(USER_PRIVILAGE_PARAM, SqlDbType.Int)).Value = UFilt.User.Privilage;
                sqlCommand.Parameters.Add(new SqlParameter(USER_WEBPAGE_PARAM, SqlDbType.Xml)).Value = UFilt.User.WebPageXML;
                sqlCommand.Parameters.Add(new SqlParameter(USER_USERNAME_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Username;
                sqlCommand.Parameters.Add(new SqlParameter(USER_PASSWORD_PARAM, SqlDbType.NVarChar)).Value = UFilt.User.Password;
                ProjectConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("USER", ex);
            }
            finally
            {
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return result;
        }


        public int DeleteUser(int UserID)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = DELETE_USER_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(USER_USERID_PARAM, SqlDbType.Int)).Value = UserID;
                ProjectConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("USER", ex);
            }
            finally
            {
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return result;
        }


        #endregion

        #region ImageParam
        private const string IMAGE_USERID_PARAM = "@UserID";
        private const string IMAGE_CATEGORYID_PARAM = "@CategoryID";
        private const string IMAGE_SUBCATEGORYID_PARAM = "@SubCategoryID";
        private const string IMAGE_IMAGEID_PARAM = "@ID";
        private const string IMAGE_IMAGENAME_PARAM = "@Imagename";
        private const string GETFILTERED_IMAGE_SP = "dbo.MaadSun_Images_GetFiltered";
        private const string CREATE_IMAGE_SP = "dbo.MaadSun_Images_Create";
        private const string UPDATE_IMAGE_SP = "dbo.MaadSun_Images_Update";
        private const string DELETE_IMAGE_BYUSERID_SP = "dbo.MaadSun_Images_Delete_ByUserID";
        private const string DELETE_IMAGE_BYIMAGENAME_SP = "dbo.MaadSun_Images_Delete_ByImagename";
        private const string GET_IMAGE_SP = "dbo.MaadSun_Images_Get";

        #endregion
        #region ImageControler
        public ImageList GetFilteredImage(ImageFilter IFilt)
        {
            SqlDataReader dataReader = null;
            ImageList ImageList = null;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = GETFILTERED_IMAGE_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_USERID_PARAM, SqlDbType.Int)).Value = IFilt.Image.UserID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_CATEGORYID_PARAM, SqlDbType.Int)).Value = IFilt.Image.CategoryID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_SUBCATEGORYID_PARAM, SqlDbType.Int)).Value = IFilt.Image.SubCategoryID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_IMAGENAME_PARAM, SqlDbType.NVarChar)).Value = IFilt.Image.Imagename;
                ProjectConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                ImageList = new ImageList();
                while (dataReader.Read())
                {
                    Image I = new Image();
                    I.FillForObject(dataReader);
                    ImageList.Rows.Add(I);
                }
                dataReader.Close();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("IMAGE", ex);
            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return ImageList;
        }




        public int CreateImage(ImageFilter IFilt)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = CREATE_IMAGE_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_USERID_PARAM, SqlDbType.Int)).Value = IFilt.Image.UserID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_CATEGORYID_PARAM, SqlDbType.Int)).Value = IFilt.Image.CategoryID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_SUBCATEGORYID_PARAM, SqlDbType.Int)).Value = IFilt.Image.SubCategoryID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_IMAGENAME_PARAM, SqlDbType.NVarChar)).Value = IFilt.Image.Imagename;
                ProjectConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("IMAGE", ex);
            }
            finally
            {
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return result;
        }


        public int UpdateImage(ImageFilter IFilt)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = UPDATE_IMAGE_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_IMAGEID_PARAM, SqlDbType.Int)).Value = IFilt.Image.ImageID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_USERID_PARAM, SqlDbType.Int)).Value = IFilt.Image.UserID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_CATEGORYID_PARAM, SqlDbType.Int)).Value = IFilt.Image.CategoryID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_SUBCATEGORYID_PARAM, SqlDbType.Int)).Value = IFilt.Image.SubCategoryID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_IMAGENAME_PARAM, SqlDbType.NVarChar)).Value = IFilt.Image.Imagename;
                ProjectConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("IMAGE", ex);
            }
            finally
            {
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return result;
        }


        public int DeleteImageByImagename(string Imagename)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = DELETE_IMAGE_BYIMAGENAME_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_IMAGENAME_PARAM, SqlDbType.NVarChar)).Value = Imagename;
                ProjectConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("IMAGE", ex);
            }
            finally
            {
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return result;
        }

        public int DeleteImageByUserID(int UserID)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = DELETE_IMAGE_BYUSERID_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_USERID_PARAM, SqlDbType.NVarChar)).Value = UserID;
                ProjectConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("IMAGE", ex);
            }
            finally
            {
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return result;
        }

        #endregion


        #region CategoryParam
        private const string CATEGORY_CATEGORYID_PARAM = "@ID";
        private const string CATEGORY_CATEGORYDESCRIPTION_PARAM = "@Desctiption";
        private const string GETCATEGORIES_SP = "dbo.MaadSun_Category_GetCategory";
        private const string CREATE_Category_SP = "dbo.MaadSun_Category_Create";
        private const string UPDATE_Category_SP = "dbo.MaadSun_Category_Update";
        private const string DELETE_Category_SP = "dbo.MaadSun_Category_Delete";

        #endregion
        #region CategoryControler
        public CategoryList GetCategories()
        {
            SqlDataReader dataReader = null;
            CategoryList CategoryList = null;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = GETCATEGORIES_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                ProjectConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                CategoryList = new CategoryList();
                while (dataReader.Read())
                {
                    Category I = new Category();
                    I.FillForObject(dataReader);
                    CategoryList.Rows.Add(I);
                }
                dataReader.Close();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CATEGORY", ex);
            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return CategoryList;
        }




        public int CreateCategory(CategoryFilter CFilt)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = CREATE_Category_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_USERID_PARAM, SqlDbType.Int)).Value = CFilt.Category.CategoryID;
                sqlCommand.Parameters.Add(new SqlParameter(IMAGE_CATEGORYID_PARAM, SqlDbType.Int)).Value = CFilt.Category.CategoryDescription;
                ProjectConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CATEGORY", ex);
            }
            finally
            {
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return result;
        }



        #endregion

        #region SubCategoryParam
        private const string SUBCATEGORY_SUBCATEGORYID_PARAM = "@ID";
        private const string SUBCATEGORY_PARENTID_PARAM = "@ParentID";
        private const string SUBCATEGORY_SUBCATEGORYDESCRIPTION_PARAM = "@Desctiption";
        private const string GETFILTERED_SUBCategory_SP = "dbo.MaadSun_SubCategory_GetFiltered";
        private const string CREATE_SUBCategory_SP = "dbo.MaadSun_SubCategory_Create";
        private const string UPDATE_SUBCategory_SP = "dbo.MaadSun_SubCategory_Update";
        private const string DELETE_SUBCategory_SP = "dbo.MaadSun_SubCategory_Delete";

        #endregion
        #region SubCategoryControler
        public SubCategoryList GetFilteredSubCategories(SubCategoryFilter SCFilter)
        {
            SqlDataReader dataReader = null;
            SubCategoryList SCList = null;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = GETFILTERED_SUBCategory_SP;
                sqlCommand.Parameters.Add(new SqlParameter(SUBCATEGORY_PARENTID_PARAM, SqlDbType.Int)).Value = SCFilter.SubCategory.ParentID;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                ProjectConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                SCList = new SubCategoryList();
                while (dataReader.Read())
                {
                    SubCategory I = new SubCategory();
                    I.FillForObject(dataReader);
                    SCList.Rows.Add(I);
                }
                dataReader.Close();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("SUBCATEGORY", ex);
            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return SCList;
        }




        public int CreateSubCategory(SubCategoryFilter SCFilt)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = ProjectConnection.CreateCommand();
                sqlCommand.CommandText = CREATE_SUBCategory_SP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter(SUBCATEGORY_PARENTID_PARAM, SqlDbType.Int)).Value = SCFilt.SubCategory.ParentID;
                sqlCommand.Parameters.Add(new SqlParameter(SUBCATEGORY_SUBCATEGORYDESCRIPTION_PARAM, SqlDbType.NVarChar)).Value = SCFilt.SubCategory.SubCategoryDescription;
                ProjectConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                ProjectConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("SUBCATEGORY", ex);
            }
            finally
            {
                if (ProjectConnection.State == ConnectionState.Open)
                {
                    ProjectConnection.Close();
                }
            }
            return result;
        }



        #endregion



    }
}
