using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CMS_Tools.Lib
{
    public class FacebookLib
    {
        public static string FB_APP_ID = ConfigurationManager.AppSettings["FB_APP_ID"];
        public static string FB_URL_Oauth = ConfigurationManager.AppSettings["FB_URL_Oauth"];//"https://www.facebook.com/dialog/oauth";
        public static string FB_URL_CALLBACK = "/Authen/" + ConfigurationManager.AppSettings["FB_CALLBACK_URL"];
        public static string FB_SCOPE = ConfigurationManager.AppSettings["FB_SCOPE"];
        public static string FB_ACCESS_TOKEN = ConfigurationManager.AppSettings["FB_ACCESS_TOKEN"];//"https://graph.facebook.com/v2.4/oauth/access_token";
        public static string FB_GET_USER = ConfigurationManager.AppSettings["FB_GET_USER"];//"https://graph.facebook.com/v2.4/me?fields=ids_for_business,email,first_name,last_name,gender,locale,link&access_token=";
        public static string FB_SECRET = ConfigurationManager.AppSettings["FB_SECRET"];

        /// <summary>
        /// GetAccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetAccessToken(string code) {
            try
            {
                string accessTokenUrl = string.Format("{0}?client_id={1}&redirect_uri={2}&client_secret={3}&code={4}",
                        Lib.FacebookLib.FB_ACCESS_TOKEN, Lib.FacebookLib.FB_APP_ID, Lib.UtilClass.GetWebAppRoot() + Lib.FacebookLib.FB_URL_CALLBACK, Lib.FacebookLib.FB_SECRET, code);
                using (WebClient webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    string response = webClient.DownloadString(accessTokenUrl);
                    if (response.Length > 0)
                    {
                        var accessToken = JsonConvert.DeserializeObject<token_fb>(response);
                        Lib.Logs.SaveLog("AccessToken: " + response);
                        return accessToken.access_token;
                    }
                    else
                        throw new Exception("Token Null!");
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("GetAccessToken FB: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// FB_Login
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static FB_Class FB_Login(string code)
        {
            FB_Class _tmp = null;
            try
            {
                string accessToken = GetAccessToken(code);               
                Uri targetUserUri = new Uri(Lib.FacebookLib.FB_GET_USER + accessToken);
                HttpWebRequest user = (HttpWebRequest)HttpWebRequest.Create(targetUserUri);
                StreamReader userInfo = new StreamReader(user.GetResponse().GetResponseStream());
                string jsonResponse = string.Empty;
                jsonResponse = userInfo.ReadToEnd();
                Lib.Logs.SaveLog("FB_Login info: " + jsonResponse);
                _tmp = JsonConvert.DeserializeObject<FB_Class>(jsonResponse);
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error FB_Login: " + ex);
            }
            return _tmp;
        }

        public static FB_FriendClass FB_FriendList(string accessToken)
        {
            FB_FriendClass _tmp = null;
            //new FB_FriendClass();
            Uri targetUserUri = new Uri("https://graph.facebook.com/me/friends?access_token=" + accessToken);
            try
            {
                //https://graph.facebook.com/me/friends?access_token=EAANKMAR6H0UBAClBOWGRZAHtbxMThXYxbOei6eSImAqUNpXy2Yd0oWASxlQrHPlRblPomB98rkYvfkyQFZBZABMp2C6Y1TD53TknEtnZACZBISDqL2KZAJq3prpxVFwZCmx1ZBqmVCepOxU9ONhgZAxc2fN1cybLZBfI7q9emyP2XZCrgZDZD
                HttpWebRequest user = (HttpWebRequest)HttpWebRequest.Create(targetUserUri);

                // Read the returned JSON object response
                StreamReader userInfo = new StreamReader(user.GetResponse().GetResponseStream());
                string jsonResponse = string.Empty;
                jsonResponse = userInfo.ReadToEnd();
                Lib.Logs.SaveLog("FB Friends: " + jsonResponse);
                _tmp = JsonConvert.DeserializeObject<FB_FriendClass>(jsonResponse);
            }
            catch (Exception)
            {
            }
            return _tmp;
        }
    }

    public class token_fb
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }

    public class FB_Class
    {
        public FB_Class()
        {
            email = "";
            first_name = "";
            last_name = "";
            gender = "";
            locale = "";
            link = "";
            id = "";
            name = "";
            picture = new picture_fb();
            ids_for_business = new FB_business_Class();
        }
        public string name { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
        public string link { get; set; }
        public string id { get; set; }
        public picture_fb picture { get; set; }
        public FB_business_Class ids_for_business { get; set; }
    }

    public class picture_fb
    {
        public dataPicture_fb data { get; set; }
    }

    public class dataPicture_fb
    {
        public string url { get; set; }
    }

    public class FB_business_Class
    {
        public List<FB_business> data = new List<FB_business>();
    }

    public class FB_business
    {
        public FB_business()
        {
            app = new App();
            accountLink = "";
            id = "";
        }

        public string id;
        public App app;
        public string accountLink;
    }
    public class App
    {
        public string id;
    }
    public class FB_FriendInfo
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class FB_FriendClass
    {
        public List<FB_FriendInfo> data { get; set; }
    }
}