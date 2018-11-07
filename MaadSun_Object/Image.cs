using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace MaadSun_Object
{

    public class ImageList //: Grid
    {
        private List<ImageService> _Rows = new List<ImageService>();
        public List<ImageService> Rows
        {
            get { return _Rows; }
            set { _Rows = value; }
        }
    }


    public class ImageFilter //: BaseFilter
    {
        private Image _Image = new Image();
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
    }

    public class ImageService
    {

        private int? _UserID;
        public int? UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private int? _CategoryID;
        public int? CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        private int? _SubCategoryID;
        public int? SubCategoryID
        {
            get { return _SubCategoryID; }
            set { _SubCategoryID = value; }
        }

        private string _Imagename;
        public string Imagename
        {
            get { return _Imagename; }
            set { _Imagename = value; }
        }


        private int _ImageID;
        public int ImageID
        {
            get { return _ImageID; }
            set { _ImageID = value; }
        }


    }


    public class Image : ImageService
    {
        public readonly string UserID_FIELD = "UserID";
        public readonly string ImageID_FIELD = "ID";
        public readonly string Imagename_FIELD = "Imagename";
        public readonly string CategoryID_FIELD = "CategoryID";
        public readonly string SubCategoryID_FIELD = "SubCategoryID";

        public ImageService GetService()
        {
            var cs = new ImageService();
            cs.UserID = UserID;
            cs.ImageID= ImageID;
            cs.CategoryID = CategoryID ;
            cs.SubCategoryID = SubCategoryID;
            cs.Imagename = Imagename;
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
            if (Columns.Contains(SubCategoryID_FIELD) && dataReader[SubCategoryID_FIELD] != DBNull.Value) this.SubCategoryID = Convert.ToInt32(dataReader[SubCategoryID_FIELD]);
            if (Columns.Contains(CategoryID_FIELD) && dataReader[CategoryID_FIELD] != DBNull.Value) this.CategoryID = Convert.ToInt32(dataReader[CategoryID_FIELD]);
            if (Columns.Contains(Imagename_FIELD) && dataReader[Imagename_FIELD] != DBNull.Value) this.Imagename = Convert.ToString(dataReader[Imagename_FIELD]);
            if (Columns.Contains(ImageID_FIELD) && dataReader[ImageID_FIELD] != DBNull.Value) this.ImageID = Convert.ToInt32(dataReader[ImageID_FIELD]);
        }
    }





}
