using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CMS_Tools.Lib
{
    /// <summary>
    /// Google lib login
    /// </summary>
    public class GoogleLib
    {
        /// <summary>
        /// Get Config google key authen
        /// </summary>
        /// <returns></returns>
        public static dynamic GetConfigGoogle(string fileName)
        {
            try
            {
                string text = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/" + fileName));
                dynamic JSON = JObject.Parse(text);
                return JSON;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error GetConfigGoogle: " + ex);
                return null;
            }
        }

        /// <summary>
        /// GetAccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetAccessToken(string code) {
            try
            {
                var JSON = Lib.GoogleLib.GetConfigGoogle(Constants.GG_JSON_FILE);
                string d = "code=" + code +
                    "&client_id=" + JSON.web.client_id +
                    "&client_secret=" + JSON.web.client_secret +
                    "&redirect_uri=" + (Constants.SERVER_TYPE == "REAL" ? JSON.web.redirect_uris[1] : JSON.web.redirect_uris[0]) +
                    "&grant_type=authorization_code";
                string url = JSON.web.token_uri + "";
                Logs.SaveLog("GetAccessToken: " + url +
                    "\r\nPost Data: " + d);
                string data = UtilClass.SendPost(d, url);
                Logs.SaveLog("TokenGG: " + data);
                //{ "access_token": "ya29.Glv2BYPsIns3p7MiUsvhz109tCR9zv3yOoZG_KZO3eynI_-ltDbnl43zqt6IAk17_KSkoVknBQwAakNe33m0CNvXznpW3pcC325vXKSc_i3Y93EoyEqDuPoYg1bj", "token_type": "Bearer", "expires_in": 3600, "refresh_token": "1/UxchQTnopGju7bDezDV-Djeye_bixXZETaHTpvhjAcc", "scope": "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.me", "id_token": "eyJhbGciOiJSUzI1NiIsImtpZCI6IjlhMzNiNWVkYjQ5ZDA4NjdhODY3MmQ5NTczYjFlMGQyMzc1ODg2ZTEifQ.eyJhenAiOiI5ODMzNzM3OTg3NzctNGc1MWk2ODBvcThncTBwajFvdG5mZXNqcXNlMXZzcDAuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiI5ODMzNzM3OTg3NzctNGc1MWk2ODBvcThncTBwajFvdG5mZXNqcXNlMXZzcDAuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMDY1MzM3ODA3OTU5OTI1MTgwODgiLCJlbWFpbCI6ImRldnByb2R1Y3Rpb24udm5AZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOnRydWUsImF0X2hhc2giOiJfbHNENkRnYXVmZTlIdkxwYWotLW93IiwiZXhwIjoxNTM0MDAxOTY0LCJpc3MiOiJhY2NvdW50cy5nb29nbGUuY29tIiwiaWF0IjoxNTMzOTk4MzY0fQ.udQXANtLAIzdY85Gn-KoSKUNBGVBnbwVKuEFeZTILJclzFPxoWcpiOvbvpD6KyCz0b8moQnZTSNZCeQ7uU-YZMWPy9Jr225Pqo5DbOIAfeVfpm8AhJxuKCw8euhxe3LRDxq37ABsx782ayXpV_07wgnoE5jBcNS_BjYGHA9e9yAMyJ5uWNmN5Y9WSbfl6fw03wDVenX--Qi4IDtj-3ClJ2s6nqZ9i1kcPKGJPXMLQvXKQRkkh3k335Z-k2Y-CG5kjtBHA7Mfdkf2H5cgvY-I6Ck_qPUR_O2AnZ3uTWzND7-E6cjoRAcY9OB1ye0vnAe1kovU3H2ojd2RcNViZfZm_w" }
                dynamic Token = JObject.Parse(data);
                string accessToken = Token.access_token + "";
                return accessToken;
            }
            catch (Exception ex)
            {
                Logs.SaveError("Error AccessToken: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetGoogleUserInfo
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static GoogleUserOutputData GetGoogleUserInfo(string code)
        {
            try
            {
                string accessToken = GetAccessToken(code);
                using (WebClient client = new WebClient())
                {
                    //client.Headers.Add("Authorization", "Bearer " + accessToken);
                    client.Encoding = System.Text.Encoding.UTF8;
                    string jsonData = client.DownloadString("https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + accessToken);
                    //string jsonData = client.DownloadString("https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=" + accessToken);
                    //{
                    //"id": "106533780795992518088",
                    // "email": "devproduction.vn@gmail.com",
                    // "verified_email": true,
                    // "name": "",
                    // "given_name": "",
                    // "family_name": "",
                    // "picture": "https://lh4.googleusercontent.com/-IRPnaUrro-g/AAAAAAAAAAI/AAAAAAAAAAc/wji_sJlfe8A/photo.jpg"
                    //}

                    Logs.SaveLog("Result Login GG: " + jsonData);
                    var d = JsonConvert.DeserializeObject<GoogleUserOutputData>(jsonData);
                    return d;
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("Error GetGoogleUserInfo: " + ex);
                throw new Exception(ex.Message);
            }
        }
    }

    public class GoogleUserOutputData
    {
        public GoogleUserOutputData() {
            id = "";
            name = "";
            given_name = "";
            email = "";
            picture = "";
        }
        public string id { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string email { get; set; }
        public string picture { get; set; }
    }
}