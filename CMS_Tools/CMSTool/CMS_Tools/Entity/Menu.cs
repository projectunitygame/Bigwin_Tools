using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Tools.Entity
{
    public class Menu
    {
        public int menuId;
        public int parentId;
        public string menuName;
        public string description;
        public string icon;
        public string onclick;
        public int dislayIndex;
        public int status;
        public long creator;
        public string css;
        public string html;
        public string js;
        public string databaseId;
        public string sql_query;
        public string sql_dataType;
        public byte type_query;
        public string dateCreate;
        public int publisherId;
    }
	
    public class MenuPage
    {
        public int MenuId;
        public int ParentID;
        public string MenuName;
        public string Icon;
        public string Onclick;
        public int DisplayIndex;
    }

    public class MenuRule
    {
        public List<int> menuId { get; set; }
        public List<List<int>> menuRule { get; set; }
    }
}