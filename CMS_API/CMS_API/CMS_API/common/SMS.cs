using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace api_cms.common
{
    public class SMS
    {
        static string ApiKey = "3F11E064600D5C3E073FA1B033831B";
        static string SecretKey = "C8F2CCDA4C9B32CAC4E3EFDD1C08B8";
        static string brandName = "Svoucher"; //Verify;
        static string SmsType = "2";
        public static void SendMessage(string phone, string message)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                string msgSent = UtilClass.RemoveSign4VietnameseString(message);//HttpUtility.UrlEncode(message);
                
                string url = "http://rest.esms.vn/MainService.svc/json/SendMultipleMessage_V4_get?Phone=" + phone + "&Content=" + msgSent + "&ApiKey=" + ApiKey + "&SecretKey=" + SecretKey + "&SmsType=" + SmsType + "&brandname=" + brandName;
                //string SmsType = "4";
                //string url = string.Format("http://rest.esms.vn/MainService.svc/json/SendMultipleMessage_V4_get?Phone={0}&Content={1}&ApiKey={2}&SecretKey={3}&SmsType={4}",phone, msgSent, ApiKey, SecretKey, SmsType);
                try
                {
                    LogClass.SaveLog("Send SMS Message: " + url);
                    string result = Web.WebRequest(Web.Method.GET, url, "");
                    LogClass.SaveLog("Message result: " + result);
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR Send SMS Message: " + ex);
                }
            }
        }

        private static string WebRequest(object gET, string url)
        {
            throw new NotImplementedException();
        }
    }
}