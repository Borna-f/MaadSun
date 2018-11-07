using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace MaadSun_Object
{

    public class SubCategoryList //: Grid
    {
        private List<SubCategoryService> _Rows = new List<SubCategoryService>();
        public List<SubCategoryService> Rows
        {
            get { return _Rows; }
            set { _Rows = value; }
        }
    }


    public class SubCategoryFilter //: BaseFilter
    {
        private SubCategory _SubCategory = new SubCategory();
        public SubCategory SubCategory
        {
            get { return _SubCategory; }
            set { _SubCategory = value; }
        }
    }

    public class SubCategoryService
    {

        private int? _ParentID;
        public int? ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        private int _SubCategoryID;
        public int SubCategoryID
        {
            get { return _SubCategoryID; }
            set { _SubCategoryID= value; }
        }

        private string _SubCategoryDescription;
        public string SubCategoryDescription
        {
            get { return _SubCategoryDescription; }
            set { _SubCategoryDescription = value; }
        }

      

    }


    public class SubCategory : SubCategoryService
    {
        public readonly string SubCategoryID_FIELD = "ID";
        public readonly string SubCategoryParent_FIELD = "ParentID";
        public readonly string SubCategoryDescription_FIELD = "Description";
        public SubCategoryService GetService()
        {
            var cs = new SubCategoryService();
            cs.SubCategoryID = SubCategoryID;
            cs.SubCategoryDescription = SubCategoryDescription;
            cs.ParentID= ParentID;
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

            if (Columns.Contains(SubCategoryID_FIELD) && dataReader[SubCategoryID_FIELD] != DBNull.Value) this.SubCategoryID = Convert.ToInt32(dataReader[SubCategoryID_FIELD]);
            if (Columns.Contains(SubCategoryParent_FIELD) && dataReader[SubCategoryParent_FIELD] != DBNull.Value) this.ParentID = Convert.ToInt32(dataReader[SubCategoryParent_FIELD]);
            if (Columns.Contains(SubCategoryDescription_FIELD) && dataReader[SubCategoryDescription_FIELD] != DBNull.Value) this.SubCategoryDescription = Convert.ToString(dataReader[SubCategoryDescription_FIELD]);
        }
    }

}
