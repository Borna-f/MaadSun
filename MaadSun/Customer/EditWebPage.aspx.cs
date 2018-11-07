using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaadSun_Object;
using System.IO;
using System.Xml;
using Microsoft.Win32;
namespace MaadSun.Customer
{
    public partial class EditWebPage : System.Web.UI.Page
    {
        protected int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToInt32(Session["Priv"]) == (int)RoleUser.Admin && Request.QueryString["UserID"] != null && Request.QueryString["UserID"] != "")
                UserID = Convert.ToInt32(Request.QueryString["UserID"]);
            else
                UserID = Convert.ToInt32(Session["UserID"]);

            if (!Page.IsPostBack)
            {
                Page.Form.Attributes.Add("enctype", "multipart/form-data");

                if (Convert.ToInt32(Session["Priv"]) == (int)RoleUser.Admin && Request.QueryString["UserID"] != null && Request.QueryString["UserID"] != "")
                {
                    UserList Ulist = new UserList();
                    Ulist = MaadSun_Interface.MaadSun_In.GETUSER(UserID);
                    string WebPage = Ulist.Rows[0].WebPageXML;
                    if (WebPage != null && WebPage != "")
                    {
                        XmlDocument XMLDOC = new XmlDocument();
                        XMLDOC.LoadXml(WebPage);
                        XmlNodeList NodeList = XMLDOC.GetElementsByTagName("html");
                        if (NodeList[0].SelectSingleNode("//title") != null) pageTitle.Text = NodeList[0]["title"].InnerText;
                        if (NodeList[0].SelectSingleNode("//body") != null) aboutCo.InnerText = NodeList[0]["body"].InnerText;
                        if (NodeList[0].SelectSingleNode("//Samplework") != null)
                        {
                            XmlNodeList Images = NodeList[0]["Samplework"].ChildNodes;
                            int ImagesCount = (int)NodeList[0]["Samplework"].ChildNodes.Count;
                            string Body = "";
                            for (int i = 0; i < ImagesCount; i++)
                            {
                                Body += CreateHTML.AddDivElement("img-wrap",
                                    CreateHTML.AddSpan("close", "&times;") + CreateHTML.AddSpan("update", "^")
                                    + CreateHTML.AddImageWithDataID(ResourceManager.ImagePath + Images[i].InnerText
                                                                               , Images[i].InnerText, Images[i].InnerText)

                               );

                            };
                            SampleWorks.InnerHtml = Body;
                        }
                    }
                }
                else
                {
                    if (Session["WebPage"] != null && (string)Session["WebPage"] != "")
                    {
                        string WebPage = Session["WebPage"].ToString();
                        XmlDocument XMLDOC = new XmlDocument();
                        XMLDOC.LoadXml(WebPage);
                        XmlNodeList NodeList = XMLDOC.GetElementsByTagName("html");

                        if (NodeList[0].SelectSingleNode("//title") != null) pageTitle.Text = NodeList[0]["title"].InnerText;
                        if (NodeList[0].SelectSingleNode("//body") != null)  aboutCo.InnerText = NodeList[0]["body"].InnerText;
                        if (NodeList[0].SelectSingleNode("//Samplework") != null)
                        {
                            XmlNodeList Images = NodeList[0]["Samplework"].ChildNodes;
                            int ImagesCount = (int)NodeList[0]["Samplework"].ChildNodes.Count;

                            string Body = "";
                            for (int i = 0; i < ImagesCount; i++)
                            {
                                Body += CreateHTML.AddDivElement("img-wrap",
                                    CreateHTML.AddSpan("close", "&times;") + CreateHTML.AddSpan("update", "^")
                                    + CreateHTML.AddImageWithDataID(ResourceManager.ImagePath + Images[i].InnerText
                                                                               , Images[i].InnerText, Images[i].InnerText)

                               );

                            };
                            SampleWorks.InnerHtml = Body;
                        }

                        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "AddFileBrowser", "createFileUpload();", true); 
                        //pageTitle.Text = XMLDOC.//(GetElementsByTagName("title").ToString();
                    }
                    else if (Session["UserID"] == null || Session["UserID"].ToString() == "")
                    {
                        Response.Redirect("Index.aspx");
                    }


                }
            }
        }
        protected void DeleteImage_Click(object sender, EventArgs e)
        {
            var Imagename = hID.Value;
            MaadSun_Interface.MaadSun_In.DeleteImageByImagename(Imagename);
            string WebPage = MaadSun_Interface.MaadSun_In.GETUSER(UserID).Rows[0].WebPageXML;
            XmlDocument XMLDOC = new XmlDocument();
            XMLDOC.LoadXml(WebPage);
            XmlNodeList NodeList = XMLDOC.GetElementsByTagName("Samplework");
            XmlNode node = NodeList[0].SelectNodes("Img[text()=\"" + Imagename + "\"]")[0];
            node.ParentNode.RemoveChild(node);
            UserFilter UFilt = new UserFilter();
            UFilt.User.WebPageXML = XMLDOC.InnerXml;
            UFilt.User.UserID = UserID;
            XML newXML = new XML();
            MaadSun_Interface.MaadSun_In.UpdateUser(UFilt);
            //NodeList[0]["Samplework"].RemoveChild(
            //NodeList[0]["Samplework"].SelectNodes    
                //NodeList[0]["Samplework"][Imagename]);
            if (Convert.ToInt32(Session["Priv"]) != (int)RoleUser.Admin) Session["WebPage"] = XMLDOC.InnerXml;
            string filePath = Server.MapPath("~/Uploads/" + Path.GetFileName(Imagename));
            File.Delete(filePath);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", "ShowMessage('تصویر با موفقیت حذف شد', 'حذف تصویر');", true);
        }
        protected string GetDefaultExtension(string mimeType)
        {
            string result;
            RegistryKey key;
            object value;

            key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);
            value = key != null ? key.GetValue("Extension", null) : null;
            result = value != null ? value.ToString() : string.Empty;

            return result;
        }
        

        protected void btnSavePage_Click(object sender, EventArgs e)
        {
            string[] Filenames;
            int OldImagesCount = 0;
            string WebPage = MaadSun_Interface.MaadSun_In.GETUSER(UserID).Rows[0].WebPageXML;
            if (WebPage != null && WebPage != "")
            {
                XmlDocument XMLDOC = new XmlDocument();
                XMLDOC.LoadXml(WebPage);
                XmlNodeList NodeList = XMLDOC.GetElementsByTagName("Samplework");
                OldImagesCount = NodeList[0].ChildNodes.Count;
                Filenames = new string[Request.Files.Count + OldImagesCount];
                for (int i = 0; i < OldImagesCount; i++)
                    Filenames[i] = NodeList[0].ChildNodes[i].InnerText;
            }
            else
                Filenames = new string[Request.Files.Count + OldImagesCount];
            
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFile file = Request.Files[i];
                if (file.FileName != null && file.FileName != "" && file.ContentLength > 0)
                {

                    string GeneratedFilename = Guid.NewGuid().ToString() + GetDefaultExtension(file.ContentType);
                    string filePath = Server.MapPath("~/Uploads/" + GeneratedFilename);
                    Filenames[i + OldImagesCount] = GeneratedFilename;
                    using (FileStream streamToDisk = File.Create(filePath))
                    {
                        file.InputStream.CopyTo(streamToDisk);
                        streamToDisk.Close();
                    }
                    ImageFilter IFilt = new ImageFilter();
                    IFilt.Image.Imagename = Filenames[i + OldImagesCount];
                    IFilt.Image.CategoryID = Convert.ToInt32(Request.Form.Get("CategoryFile" + i));
                    IFilt.Image.SubCategoryID = Convert.ToInt32(Request.Form.Get("SubCategoryFile" + i));
                    IFilt.Image.UserID = UserID;
                    MaadSun_Interface.MaadSun_In.CreateImage(IFilt);
                }
            }
            XML newXML = new XML();
            UserFilter UFilt = new UserFilter();
            UFilt = newXML.GetUpdateWebPageFilter(UserID, pageTitle.Text, aboutCo.InnerText, Filenames);
            MaadSun_Interface.MaadSun_In.UpdateUser(UFilt);
            if (Convert.ToInt32(Session["Priv"]) != (int)RoleUser.Admin) Session["WebPage"] = UFilt.User.WebPageXML;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", "ShowMessage('تغییرات صفحه وب با موفقیت انجام شد', 'صفحه وب');", true);

        }
    }
}