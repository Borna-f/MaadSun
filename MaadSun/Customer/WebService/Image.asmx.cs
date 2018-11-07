using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MaadSun_Object;
namespace MaadSun.Customer.WebService
{
    /// <summary>
    /// Summary description for Image
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Image : System.Web.Services.WebService
    {

        [WebMethod]
        public ImageList GetFilteredImage(ImageFilter ImFilt)
        {
            return MaadSun_Interface.MaadSun_In.GetFilteredImage(ImFilt);
        }
        [WebMethod]
        public int UpdateImage(ImageFilter ImFilt)
        {
            return MaadSun_Interface.MaadSun_In.UpdateImage(ImFilt);
        }
    }
}
