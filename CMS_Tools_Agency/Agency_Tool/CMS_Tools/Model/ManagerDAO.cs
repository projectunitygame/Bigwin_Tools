using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Tools.Model
{
    public class ManagerDAO
    {
        private AccountModel accountModel;
        private MenuModel menuModel;
        private CategoryModel categoryModel;

        public AccountModel AccountModel { get => AccountModel.Instance; set => accountModel = value; }
        public MenuModel MenuModel { get => MenuModel.Instance; set => menuModel = value; }
        public CategoryModel CategoryModel { get => CategoryModel.Instance; set => categoryModel = value; }
    }
}