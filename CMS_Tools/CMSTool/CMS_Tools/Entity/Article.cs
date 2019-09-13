using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Tools.Entity
{
    public class Article
    {
        public long id { get; set; }
        public byte status { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string product_Specifications { get; set; }
        public string metaKeyword { get; set; }
        public string metaDescription { get; set; }
        public string images { get; set; }
        public string videos { get; set; }
        public string author { get; set; }
        public string quote { get; set; }
        public string tags { get; set; }
        public string productCode { get; set; }
        public string datePublish { get; set; }
        public string categoriesTags { get; set; }
        public string body { get; set; }
        public int accountId { get; set; }
        public int publisherId { get; set; }
        public string link { get; set; }
    }
}