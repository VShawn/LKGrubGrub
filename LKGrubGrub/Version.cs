using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using LKGrubGrub;

namespace LKGrubGrub
{
    static class Version
    {
        public const string version = "0.0.3";            //当前版本号
        public const string edition = "LeFe 0.0.3";
        public const int date = 20160418;            //当前版本时间
        public const string sofeId = "LeFe PROJECT LKGrub";      //标识符
        public const string versionXml = "http://singlex.sinaapp.com/LeFe/LKGrubGrubVersion.php";
        private static Dictionary<string, string> xmlData =new Dictionary<string, string>();


        /// <summary>
        /// 检查更新
        /// </summary>
        public static bool Check()
        {
            ReadVersionXML();
            try
            {
                int newDate = int.Parse(GetDate());
                if (newDate > date)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                
            }
            return false;
        }
        public static string GetVersion()
        {
            return GetXML("version");
        }
        public static string GetDate()
        {
            return GetXML("date");
        }
        public static string GetDocuments()
        {
            return GetXML("documents");
        }
        public static string GetDownload()
        {
            return GetXML("download");
        }
        public static string GetInfo()
        {
            return GetXML("info");
        }
        private static string GetXML(string key)
        {
            if (xmlData.Count == 0)
            {
                ReadVersionXML();
            }
            if (xmlData.ContainsKey(key))
            {
                return xmlData[key];
            }
            return "";
        }
        private static void ReadVersionXML()
        {
            Dictionary<string, string> tmp = new Dictionary<string, string>();

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(versionXml);
                XmlNode Lefe = xmldoc.SelectSingleNode("Lefe");
                foreach (XmlNode node in Lefe)
                {
                    tmp.Add(node.Name, node.InnerText);
                }
            }
            catch
            {

            }
            finally
            {
                xmlData = tmp;
            }

            
        }
    }
}