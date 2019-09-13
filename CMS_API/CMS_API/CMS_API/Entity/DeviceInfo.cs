using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace api_cms.Entity
{
    public class DeviceInfo
    {
        public string deviceID;
        public string deviceName;
        public string platform;
        public string deviceModel;
        public string version;
        public string tokenPushNotification;
        public string accountID;
        private string signature;

        public string Signature { get => GetMd5Hash(string.Format("<#####>{0}:{1}:{2}:{3}:{4}</#####>", deviceID, deviceName, platform, deviceModel, version)); set => signature = value; }

        public static string GetMd5Hash(string input, bool utf8 = false)
        {
            if (!utf8)
            {
                MD5 md5Hash = MD5.Create();
                byte[] data = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    string hexValue = data[i].ToString("X").ToLower();
                    sBuilder.Append((hexValue.Length == 1 ? "0" : "") + hexValue);

                }
                return sBuilder.ToString();
            }
            else
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.UTF8.GetBytes(input));
                byte[] result = md5.Hash;
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    strBuilder.Append(result[i].ToString("x2"));
                }
                return strBuilder.ToString();
            }
        }
    }
}