using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaadSun_Object
{
    public class CreateHTML
    {
        //public string CreateHTML()
        //{
        //    //string s =
        //    //<!DOCTYPE html>
        //    //<head runat="server">
        //    //<title></title>
        //    //</head>
        //    //<body>
        //    //<form id="form1" runat="server">
        //    //<div>
    
        //    //</div>
        //    //</form>
        //    //</body>
        //    //</html>
        //    //return s;
        //}
        public static string MakeParagraph(string s)
        {
            return "<p>" + s + "</p>";
        }
        public static string AddImage(string src,string id)
        {
            return "<img id='"+ id + "' class='SampleImages' src=" + src + " alt=" + id + "/>";
        }
        public static string AddImageWithDataID(string src, string id,string dataid)
        {
            return "<img id='" + id + "' class='SampleImages' src='" + src + "' alt='" + id + "'" + "data-id = '" + dataid + "'" + "/>";
        }
        public static string AddDivElement(string Class, string DivBody)
        {
            return "<div class='" + Class + "'>" + DivBody + "</div>";
        }
        public static string AddSpan(string Class,string SpanBody)
        {
            return "<span class='" + Class + "'>" + SpanBody + "</span>";
        }
        public static string SetTitle(string t)
        {
            return "<h4>" + t + "</h4>";
        }

        public static string Setheader (string h)
        {
            return "<h5>" + h + "</h5>";
        }
        public static string AddHeadTag(string H)
        {
            return "<head>" +
                "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />"
                + H + "</head>";
        }
        public static string AddBodyTag(string B)
        {
            return "<body>" + "<div class='bodyframe'>" + "<div class='bodytext'>" + B + "</div>" + "</div>" + "</body>";
        }
        public static string Initilize ()
        {
            return "<!DOCTYPE html> <html xmlns=\"http://www.w3.org/1999/xhtml\">";
        }
        public static string END()
        {
            return "</html>";
        }
    }
}
