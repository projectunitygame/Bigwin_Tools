using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UploadFile.Lib
{
    public class ConnectionDB
    {
        public const string KEY_CONNECT_STRING = "9465162a63e95a093f2e556b95f0895b";
        public SqlConnection conn;
        public ConnectionDB(string connectString)
        {
            conn = new SqlConnection();
            string str = WebConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            int i = str.IndexOf("Password=") + 9;
            string c = str.Substring(i, str.Length - i);
            this.conn.ConnectionString = str.Replace(c, Encryptor.DecryptString(c, KEY_CONNECT_STRING));
        }
    }
}