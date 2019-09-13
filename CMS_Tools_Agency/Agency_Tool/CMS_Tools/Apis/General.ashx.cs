using CMS_Tools.Lib;
using CMS_Tools.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CMS_Tools.Apis
{
    /// <summary>
    /// Summary description for General
    /// </summary>
    public class General : IHttpHandler, IRequiresSessionState
    {
        UserInfo accountInfo;
        private Results results = new Results();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            #region CHECK ACCOUNT LOGIN
            accountInfo = Account.GetAccountInfo(context);

            if (accountInfo == null)
            {
                results.status = -199;
                results.message = "error";
                context.Response.Write(JsonConvert.SerializeObject(results));
                return;
            }
            #endregion
            string type = context.Request.Form["type"];
            if (string.IsNullOrEmpty(type))
                type = context.Request.QueryString["type"];
            switch (type)
            {
                case "GetMD5":
                    GetMD5(context);
                    break;
                case "GetMD5_UTF8":
                    GetMD5_UTF8(context);
                    break;
                case "Encryption":
                    Encryption(context);
                    break;
                case "EncryptionBySecretkey":
                    EncryptionBySecretkey(context);
                    break;
                case "Decryption":
                    Decryption(context);
                    break;
                case "DecryptionBySecretkey":
                    DecryptionBySecretkey(context);
                    break;
                case "Base64Encode":
                    Base64Encode(context);
                    break;
                case "Base64Decode":
                    Base64Decode(context);
                    break;
                default:
                    results.message = "You do not have permission to access!";
                    context.Response.Write(JsonConvert.SerializeObject(results));
                    break;
            }
        }

        private void Base64Decode(HttpContext context)
        {
            try
            {
                string s = context.Request.Form["code"];
                string encryptor = Encryptor.Base64Decode(s);
                results.message = "success";
                results.data = encryptor;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
            catch (Exception ex)
            {
                results.message = "error";
                results.data = ex.Message;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
        }

        private void Base64Encode(HttpContext context)
        {
            try
            {
                string s = context.Request.Form["code"];
                string encryptor = Encryptor.Base64Encode(s);
                results.message = "success";
                results.data = encryptor;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
            catch (Exception ex)
            {

                results.message = "error";
                results.data = ex.Message;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
        }

        private void GetMD5_UTF8(HttpContext context)
        {
            try
            {
                string s = context.Request.Form["code"];
                string encryptor = Encryptor.MD5HashUTF8(s);
                results.message = "success";
                results.data = encryptor;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("GetMD5_UTF8: " + ex);
                results.message = "error";
                results.data = ex.ToString();
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
        }

        private void Decryption(HttpContext context)
        {
            try
            {
                string key = context.Request.Form["key"];
                if (string.IsNullOrEmpty(key))
                    key = Constants.secretKey;
                string s = context.Request.Form["code"];
                string encryptor = Encryptor.DecryptString(s, key);
                results.message = "success";
                results.data = encryptor;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Decryption: " + ex);
                results.message = "error";
                results.data = ex.ToString();
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
        }

        private void DecryptionBySecretkey(HttpContext context)
        {
            try
            {
                string s = context.Request.Form["code"];
                string key = context.Request.Form["key"];
                string encryptor = Encryptor.DecryptString(s, key);
                results.message = "success";
                results.data = encryptor;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("DecryptionBySecretkey: " + ex);
                results.message = "error";
                results.data = ex.ToString();
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
        }

        private void Encryption(HttpContext context)
        {
            try
            {
                string key = context.Request.Form["key"];
                if (string.IsNullOrEmpty(key))
                    key = Constants.secretKey;
                string s = context.Request.Form["code"];
                string encryptor = Encryptor.EncryptString(s, key);
                results.message = "success";
                results.data = encryptor;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Encryption: " + ex);
                results.message = "error";
                results.data = ex.ToString();
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
        }

        private void EncryptionBySecretkey(HttpContext context)
        {
            try
            {
                string s = context.Request.Form["code"];
                string key = context.Request.Form["key"];
                string encryptor = Encryptor.EncryptString(s, key);
                results.message = "success";
                results.data = encryptor;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("EncryptionBySecretkey: " + ex);
                results.message = "error";
                results.data = ex.ToString();
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
        }

        private void GetMD5(HttpContext context)
        {
            try
            {
                string s = context.Request.Form["code"];
                string encryptor = Encryptor.GetMd5Hash(s);
                results.message = "success";
                results.data = encryptor;
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("EncryptionBySecretkey: " + ex);
                results.message = "error";
                results.data = ex.ToString();
                context.Response.Write(JsonConvert.SerializeObject(results));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Results
    {
        public Results()
        {
            message = "";
            data = "";
            errorMsg = "";
        }
        public string message { get; set; }
        public string data { get; set; }
        public int record { get; set; }
        public int status { get; set; }
        public string errorMsg { get; set; }
    }
}