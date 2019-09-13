using api_cms.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_cms.Entity
{
    public struct ResultTracking
    {
        public int status;
        public string msg;
    }

    public struct ResultApi
    {
        public int status;
        public string msg;
        public object data;
        public string secreckey;
    }

    public class PayloadApi: BaseApiInfo
    {
        public string data { get; set; }
        public string clientIP { get; set; }
        public string sign { get; set; }
        public string signServer { get { return Encryptor.GeneralSignature(new List<string> { Encryptor.GetMd5Hash(data), clientIP, publickey, serviceID.ToString() });} }
    }
}