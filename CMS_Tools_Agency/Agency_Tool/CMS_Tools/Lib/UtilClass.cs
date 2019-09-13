using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.HtmlControls;

namespace CMS_Tools.Lib
{
    public class UtilClass
    {
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return getrandom.Next(min, max);
            }
        }

        public static bool ValidateDatetime(string dateString)
        {
            try
            {
                string formatString = "dd/MM/yyyy HH:mm";
                DateTime dateValue;
                CultureInfo enUS = new CultureInfo("en-US"); // is up to you
                if (DateTime.TryParseExact(dateString, formatString, enUS,
                                               DateTimeStyles.None, out dateValue))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetWebAppRoot()
        {
            string host = (HttpContext.Current.Request.Url.IsDefaultPort) ?
                HttpContext.Current.Request.Url.Host :
                HttpContext.Current.Request.Url.Authority;
            host = String.Format("{0}://{1}", HttpContext.Current.Request.Url.Scheme, host);
            if (HttpContext.Current.Request.ApplicationPath == "/")
                return host;
            else
                return host + HttpContext.Current.Request.ApplicationPath;
        }

        public static string SendPost(string postData, string url, string contentType = "application/json; charset=UTF-8")
        {
            StringBuilder s = new StringBuilder();
            s.Append("SendPost: " + url + "\r\nJSON DATA: " + postData);
            bool success = false;
            string resp;
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(postData);
            CookieContainer cookie = new CookieContainer();
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "POST";
            myRequest.ContentLength = data.Length;
            myRequest.ContentType = contentType;
            myRequest.KeepAlive = false;
            myRequest.CookieContainer = cookie;
            myRequest.AllowAutoRedirect = false;
            using (Stream requestStream = myRequest.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }
            string responseXml = string.Empty;
            try
            {
                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    if (myResponse.StatusCode != HttpStatusCode.OK)
                        success = false;
                    else
                        success = true;
                    using (Stream respStream = myResponse.GetResponseStream())
                    {
                        using (StreamReader respReader = new StreamReader(respStream))
                        {
                            responseXml = respReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                    using (HttpWebResponse exResponse = (HttpWebResponse)webEx.Response)
                    {
                        using (StreamReader sr = new StreamReader(exResponse.GetResponseStream()))
                        {
                            responseXml = sr.ReadToEnd();
                        }
                    }
                }
            }
            if (success)
            {
                resp = responseXml;
            }
            else
            {
                resp = responseXml;

            }
            s.Append("\r\nResponse Data: " + resp);
            Logs.SaveLog(s.ToString());
            return resp;
        }

        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static void AddCookie(HttpContext context,string name, string value, int expire_date = 180)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = value;
                cookie.Expires = DateTime.Now.AddDays(expire_date);
                context.Response.SetCookie(cookie);
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR Add cookie", ex);
                throw new Exception(ex.Message);
            }           
        }

        public static void RemoveCookie(HttpContext context, string name)
        {
            try
            {
                var myCookie = new HttpCookie(name);
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                context.Response.Cookies.Add(myCookie);
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR Remove cookie", ex);
                throw new Exception(ex.Message);
            }
        }

        public static void AddCookie(System.Web.UI.Page page, string name, string value, int expire_date = 90)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = value;
                cookie.Expires = DateTime.Now.AddDays(expire_date);
                page.Response.SetCookie(cookie);
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR Add cookie", ex);
            }
        }

        public static void IncludeCSSFile(System.Web.UI.Page page, string cssfile)
        {
            HtmlGenericControl child = new HtmlGenericControl("link");
            child.Attributes.Add("rel", "stylesheet");
            child.Attributes.Add("href", cssfile);
            child.Attributes.Add("type", "text/css");
            page.Header.Controls.AddAt(0, child);
        }

        public static void IncludeCSS(System.Web.UI.Page page, string css)
        {
            HtmlGenericControl child = new HtmlGenericControl("style");
            child.Attributes.Add("type", "text/css");
            child.InnerHtml = css;
            page.Header.Controls.AddAt(0, child);
        }

        public static void IncludeScript(System.Web.UI.Page page, string script)
        {
            HtmlGenericControl child = new HtmlGenericControl("script");
            child.Attributes.Add("type", "text/javascript");
            child.InnerHtml = script;
            page.Header.Controls.Add(child);
        }
        public static void IncludeFileJS(System.Web.UI.Page page, string script)
        {
            HtmlGenericControl child = new HtmlGenericControl("script");
            child.Attributes.Add("type", "text/javascript");
            child.Attributes.Add("src", script);
            page.Header.Controls.Add(child);
        }
        public static void IncludeSourceJS(System.Web.UI.Page page, string script)
        {
            HtmlGenericControl child = new HtmlGenericControl();
            child.InnerHtml = script;
            page.Header.Controls.Add(child);
        }

        public static long UnixTime(DateTime d)
        {
            var timeSpan = (d - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified));
            return (long)timeSpan.TotalSeconds;
        }

        private static readonly string[] VietnameseSigns = new string[]
        {
          "aAeEoOuUiIdDyY",
          "áàạảãâấầậẩẫăắằặẳẵ",
          "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
          "éèẹẻẽêếềệểễ",
          "ÉÈẸẺẼÊẾỀỆỂỄ",
          "óòọỏõôốồộổỗơớờợởỡ",
          "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
          "úùụủũưứừựửữ",
          "ÚÙỤỦŨƯỨỪỰỬỮ",
          "íìịỉĩ",
          "ÍÌỊỈĨ",
          "đ",
          "Đ",
          "ýỳỵỷỹ",
          "ÝỲỴỶỸ"
         };

        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string RemoveSign4VietnameseString(string s)
        {
            string str = convertToUnSign3(s);
            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        public static string General_publisher(string publisherId) {
            string s = "P_";
            for (int i = 0; i < 5 - publisherId.Length; i++)
            {
                s += "0";
            }
            s += publisherId;
            return s;
        }

        public static bool IsUnicode(string input)
        {
            var asciiBytesCount = Encoding.ASCII.GetByteCount(input);
            var unicodBytesCount = Encoding.UTF8.GetByteCount(input);
            return asciiBytesCount != unicodBytesCount;
        }

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^[0-9]{10,11}$").Success;
        }
    }

    public class Web
    {
        public enum Method { GET, POST };

        public static string WebRequest(Method method, string contentType, string url, string postData)
        {

            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";
            try
            {
                webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = method.ToString();
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.UserAgent = "";
                webRequest.Timeout = 60000;//1min

                if (method == Method.POST)
                {
                    webRequest.ContentType = contentType;

                    //POST the data.
                    requestWriter = new StreamWriter(webRequest.GetRequestStream());

                    try
                    {
                        requestWriter.Write(postData);
                    }
                    catch
                    {
                        throw;
                    }

                    finally
                    {
                        requestWriter.Close();
                        requestWriter = null;
                    }
                }

                responseData = WebResponseGet(webRequest);
                webRequest = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return responseData;
        }

        private static string WebResponseGet(HttpWebRequest webRequest)
        {
            throw new NotImplementedException();
        }

        public static string WebRequest(Method method, string url, string postData)
        {

            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.UserAgent = "";
            webRequest.Timeout = 60000;

            if (method == Method.POST)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";

                //POST the data.
                requestWriter = new StreamWriter(webRequest.GetRequestStream());

                try
                {
                    requestWriter.Write(postData);
                }
                catch
                {
                    throw;
                }

                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }

            responseData = WebResponseGet(webRequest);
            webRequest = null;
            return responseData;
        }
    }
}