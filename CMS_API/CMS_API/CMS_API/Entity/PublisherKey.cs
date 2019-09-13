using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_cms.Entity
{
    public struct PublisherKey
    {
        public int publisherID;
        public string publickey;
        public string secretkey;
        public short serviceID;
        public string serverIP;
        public string version;
    }
}