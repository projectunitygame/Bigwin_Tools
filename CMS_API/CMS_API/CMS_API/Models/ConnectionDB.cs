using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace api_cms.Models
{
    public class ConnectionDB
    {
        public static string GetConnectionDB(string connectString)
        {
            string str = WebConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            int i = str.IndexOf("Password=") + 9;
            string c = str.Substring(i, str.Length - i);
            return str.Replace(c, common.Encryptor.DecryptString(c, common.Constants.KEY_CONNECT_STRING));
        }
    }
}