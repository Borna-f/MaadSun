using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace MaadSun_Object
{
    public class CategoryList //: Grid
    {
        private List<CategoryService> _Rows = new List<CategoryService>();
        public List<CategoryService> Rows
        {
            get { return _Rows; }
            set { _Rows = value; }
        }
    }


    public class CategoryFilter //: BaseFilter
    {
        private Category _Category = new Category();
        public Category Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
    }

    public class CategoryService
    {

   
        private int _CategoryID;
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        private string _CategoryDescription;
        public string CategoryDescription
        {
            get { return _CategoryDescription; }
            set { _CategoryDescription = value; }
        }



    }


    public class Category : CategoryService
    {
        public readonly string CategoryID_FIELD = "ID";
        public readonly string CategoryDescription_FIELD = "Description";
        public CategoryService GetService()
        {
            var cs = new CategoryService();
            cs.CategoryID = CategoryID;
            cs.CategoryDescription = CategoryDescription;
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

            if (Columns.Contains(CategoryID_FIELD) && dataReader[CategoryID_FIELD] != DBNull.Value) this.CategoryID = Convert.ToInt32(dataReader[CategoryID_FIELD]);
            if (Columns.Contains(CategoryDescription_FIELD) && dataReader[CategoryDescription_FIELD] != DBNull.Value) this.CategoryDescription = Convert.ToString(dataReader[CategoryDescription_FIELD]);
        }
    }
}
