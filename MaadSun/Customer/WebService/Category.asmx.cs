using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MaadSun_Object;
namespace MaadSun.Customer.WebService
{
    /// <summary>
    /// Summary description for Category
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Category : System.Web.Services.WebService
    {

        [WebMethod]
        public CategoryList GetCategory()
        {
            CategoryList CList = new CategoryList();
            CList = MaadSun_Interface.MaadSun_In.GetCategoryList();
            return CList;
        }

        [WebMethod]
        public ImageList GetImageInfo(string Imagename)
        {
            ImageFilter ImFilt = new ImageFilter();
            ImFilt.Image.Imagename = Imagename;
            return MaadSun_Interface.MaadSun_In.GetFilteredImage(ImFilt);
        }



        [WebMethod]
        public SubCategoryList GetFilteredSubcategory(int ParentID)
        {
            SubCategoryList SCList = new SubCategoryList();
            SubCategoryFilter SCFilter = new SubCategoryFilter();
            SCFilter.SubCategory.ParentID = ParentID;
            SCList = MaadSun_Interface.MaadSun_In.GetFilteredSubCategory(SCFilter);
            return SCList;
        }
    }
}
