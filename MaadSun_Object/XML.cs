using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MaadSun_Object
{
    public class XML
    {
        public UserFilter GetUpdateWebPageFilter (int UserID,string title,string body,string[] images)
        {
            //XmlWriter writer = null;

            //try
            //{

            //    // Create an XmlWriterSettings object with the correct options. 
            //    XmlWriterSettings settings = new XmlWriterSettings();
            //    settings.Indent = true;
            //    settings.IndentChars = ("\t");
            //    settings.OmitXmlDeclaration = true;

            //    // Create the XmlWriter object and write some content.
            //    writer = XmlWriter.Create(FilePath + "data.xml", settings);
            //    writer.WriteStartElement("book");
            //    writer.WriteElementString("item", "tesing");
            //    writer.WriteEndElement();

            //    writer.Flush();

            //}
            //finally
            //{
            //    if (writer != null)
            //        writer.Close();
            //}



            var sb = new StringBuilder();
            UserFilter UFilt = new UserFilter();
            UFilt.User.UserID = UserID;

            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                writer.WriteStartDocument();
                bool SampleWorkFlag = false;

                writer.WriteStartElement("html");
                if(title!=null && title!="")
                writer.WriteElementString("title", title);
                if(body!=null && body!="")
                writer.WriteElementString("body", body);

                
                foreach (string image in images)
                {
                    if (image != null && image != "")
                    {
                        if (SampleWorkFlag == false)
                        {
                            writer.WriteStartElement("Samplework");
                            SampleWorkFlag = true;
                        }
                        writer.WriteElementString("Img", image);
                    }
                    //writer.WriteEndElement();
                    //writer.WriteEndElement();
                }
                if (SampleWorkFlag == true) writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
                UFilt.User.WebPageXML = sb.ToString();
            }
            return UFilt;
        }
        public string ConvertXMLtoHTML(string XML)
        {
            XmlDocument XDOC = new XmlDocument();
            XDOC.LoadXml(XML);
            XmlNodeList NodeList = XDOC.GetElementsByTagName("html");
            string title = "";
            string body = "";
            int ImagesCount = 0;
            XmlNodeList Images = null;
            if (NodeList[0].SelectSingleNode("//title") != null)
            title = NodeList[0]["title"].InnerText;
            if (NodeList[0].SelectSingleNode("//body") != null)
            body =  NodeList[0]["body"].InnerText;
            if (NodeList[0].SelectSingleNode("//Samplework") != null)
            {
                ImagesCount = NodeList[0]["Samplework"].ChildNodes.Count;
                Images = NodeList[0]["Samplework"].ChildNodes;
            }
            string HTML = "";
            string HTMLBody = "";
            HTML += CreateHTML.Initilize();
            HTML += CreateHTML.AddHeadTag("");
            if (title != "") HTMLBody += CreateHTML.SetTitle(title);
            if (body !="")  HTMLBody += CreateHTML.MakeParagraph(body);

            if (ImagesCount > 0 && Images != null)
            {
                HTMLBody += CreateHTML.Setheader("نمونه کارها");
                for (int i = 0; i < ImagesCount; i++)
                {
                    HTMLBody += CreateHTML.AddImage(ResourceManager.ImagePath + Images[i].InnerText
                                                                           , Images[i].InnerText);
                };
            }
            HTML += CreateHTML.AddBodyTag(HTMLBody);                   
            HTML += CreateHTML.END();
            return HTML;
        }
    }
}
