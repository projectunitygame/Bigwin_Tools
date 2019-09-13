using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace api_cms.common
{
    public class Constants
    {
        public const string KEY_CONNECT_STRING = "9465162a63e95a093f2e556b95f0895b";
        public const string KEY_SQL = "48dc695d5f6203fd54b85c93b022ffe5";
        public const string KEY_SERVER = "63dc8f4d5805b4b972e769b9d50ff004";
        public const int TIMOUT_CONNECT_SQL = 60000;
        public static string SERVER_TYPE = WebConfigurationManager.AppSettings["SERVER_TYPE"];
    }

    public enum ERROR_CODDE: int
    {
        ERROR_EX = -9999,
        DATA_NULL,
        SIGN_WRONG,
        PUBLICKEY_NOT_FOUND,
        SERVICEID_NOT_FOUND,
        IP_NOT_ALLOW_ACCEPT,
        DATA_INVALID,
        DATA_ENCRYPT_INVALID,
        ERROR_PARSE_OBJECT,
        VERSION_INVALID,
        NGAY_GIAO_GIAY_INVALID,
        SUCCESS = 0
    }
}