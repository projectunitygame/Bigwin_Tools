using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Xml;

namespace CMS_Tools.Model
{
    public class ConnectionDB
    {
        public SqlConnection conn;
        //public ConnectionDB()
        //{
        //    conn = new SqlConnection();
        //    this.conn.ConnectionString = WebConfigurationManager.ConnectionStrings["CCTool_DBConnectionString"].ConnectionString;
        //}
        public ConnectionDB(string connectString)
        {
            conn = new SqlConnection();
            string str = WebConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            int i = str.IndexOf("Password=") + 9;
            string c = str.Substring(i, str.Length - i);
            this.conn.ConnectionString = str.Replace(c, Lib.Encryptor.DecryptString(c, Lib.Constants.KEY_CONNECT_STRING));
        }

        public static string GetConnectionDB(string connectString)
        {
            string str = WebConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            int i = str.IndexOf("Password=") + 9;
            string c = str.Substring(i, str.Length - i);
            return str.Replace(c, Lib.Encryptor.DecryptString(c, Lib.Constants.KEY_CONNECT_STRING));
        }

        //public static string getConnectString(string param)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(HttpContext.Current.Server.MapPath("~/xml/Databases.xml"));
        //        XmlElement root = doc.DocumentElement;
        //        XmlNodeList elemList = root.GetElementsByTagName("item");
        //        for (int i = 0; i < elemList.Count; i++)
        //        {
        //            if (elemList[i].Attributes["value"].InnerText == param)
        //                return elemList[i].Attributes["name"].InnerText;
        //        }
        //        return string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        Lib.Logs.SaveError("Error getConnectString: " + ex);
        //        return ex.Message;
        //    }
        //}
    }
}