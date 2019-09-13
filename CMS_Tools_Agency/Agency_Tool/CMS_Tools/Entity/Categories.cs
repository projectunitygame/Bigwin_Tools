using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Tools.Entity
{
    public class Categories
    {
        public Categories(){
            images = new List<Picture>();
            languageCode = "VI";
        }
        public int categoryId;
        public string categoryName;
        public string description;
        public List<Picture> images;
        public string link;
        public int parentId;
        public int publisherId;
        public int status;
        public int accountId;
        public byte isMenu;
        public short displayIndex;
        public byte categoryType;
        public string languageCode;
        public string icon;
        public string css;
        public string html;
        public string metaDescription;
        public string metaKeyword;
        public string dateCreate;
        public string categoryTags;
        public string actionTags;
        public string msg;
    }

    public class CategoryTags
    {
        public string Tags;
        public int PublisherId;
        public int AccountId;
        public int CategoryID;
        public string TagType;
        public string Msg;
    }

    public class Picture
    {
        public string urlWeb { get; set; }
        public string urlTablet { get; set; }
        public string urlPhone { get; set; }
        public string fileName { get; set; }
        public string size { get; set; }
    }
}