using CMS_Tools.Lib;
using CMS_Tools.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        List<Entity.MenuPage> listMenu = new List<Entity.MenuPage>();
        public UserInfo userData = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            this.copyright.InnerHtml = now.Year + " &copy; " + Lib.Constants.COPY_RIGHT + " | Ver " + Constants.SERVER_VER + 
            "<div class='scroll-to-top'><i class='icon-arrow-up'></i></div>";
            try
            {
                userData = Apis.Account.GetAccountInfo(HttpContext.Current);
                if (userData == null)
                {
                    Session.Clear();
                    Session.Abandon();
                    UtilClass.RemoveCookie(this.Context, "accountToken");
                    Response.Redirect("login.aspx");
                    return;
                }
                if (userData.AgencyInfo.agencyCode.Length > 13)
                {
                    string scriptHiddenAgencySub2 = "$(document).ready(function(){$('#m_34').remove();$('#m_38').remove();$('#m_48').remove();});";
                    UtilClass.IncludeScript(this.Page, scriptHiddenAgencySub2);

                }
                else
                {
                    string scriptHiddenAgencySub2 = "$(document).ready(function(){$('#m_61').remove();});";
                    UtilClass.IncludeScript(this.Page, scriptHiddenAgencySub2);
                }
                UserInfo uData = new UserInfo()
                {
                    AccountId = userData.AccountId,
                    Avatar = userData.Avatar,
                    Code = userData.Code,
                    UserName = userData.UserName,
                    Email = userData.Email,
                    PublisherID = userData.PublisherID
                };
                this._userdata.Value = JsonConvert.SerializeObject(uData); //Lib.Helper.DataTableToJSON(userData);
                string publisherId = userData.PublisherID.ToString();
                var token = new
                {
                    publisherName = UtilClass.General_publisher(publisherId),
                    userId = userData.AccountId.ToString(),
                    clientIp = UtilClass.GetIPAddress()
                };
                this.tokenUpload.Value = Encryptor.Base64Encode(Encryptor.EncryptString(JsonConvert.SerializeObject(token), Constants.KEY_SERVER));


                loadMenu();
                Lib.UtilClass.IncludeFileJS(this.Page, "assets/global/plugins/socket.io.js");
                if (Lib.Constants.SERVER_TYPE == "REAL")
                    Lib.UtilClass.IncludeFileJS(this.Page, "assets/global/scripts/websocket_real.js");
                else
                {
                    Lib.UtilClass.IncludeFileJS(this.Page, "assets/global/scripts/websocket.js");
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {

            }
        }

        private void loadMenu()
        {
            try
            {
                if (Session["menu"] == null)
                {
                    ManagerDAO a = new ManagerDAO();
                    int code = 0;
                    listMenu = a.MenuModel.GetMenuUser(userData.AccountId, ref code);
                    //string list_menuId = "";
                    //string list_menuRule = "";
                    //if (a.MenuModel.GetRuleUser(userData.AccountId, ref list_menuId, ref list_menuRule) == 0) {
                    //    Entity.MenuRule r = new Entity.MenuRule()
                    //    {
                    //        menuId = list_menuId != "" ? JsonConvert.DeserializeObject<List<int>>(list_menuId) : new List<int>(),
                    //        menuRule = list_menuRule != "" ? JsonConvert.DeserializeObject<List<List<int>>>(list_menuRule) : new List<List<int>>()
                    //    };
                    //    Session["rule"] = r;
                    //}
                    if (code == 0)
                    {
                        var menuIds = listMenu.Select(x => x.MenuId).ToList();
                        StringBuilder strMenu = new StringBuilder();
                        strMenu.Append("<ul class='page-sidebar-menu  page-header-fixed page-sidebar-menu-hover-submenu' data-keep-expanded='false' data-auto-scroll='true' data-slide-speed='200'>");
                        var menuParent = listMenu.Where(x => x.ParentID == 0).OrderByDescending(x => x.DisplayIndex);
                        foreach (var item in menuParent)
                        {
                            listMenu.Remove(item);
                            string subMenu = GetSubMenu(item.MenuId);
                            string link = item.Onclick == "" ? "Page.aspx?m=" + item.MenuId : item.Onclick;
                            strMenu.Append("<li class='nav-item' id='m_" + item.MenuId + "'>" +
                                "<a href='" + (subMenu != "" ? "javascript:;" : link) + "' class='nav-link nav-toggle'>" + (item.Icon != "" ? "<i class='" + item.Icon + "'></i>" : "") +
                                "<span class='title'>" + item.MenuName + "</span><span class='arrow'></span></a>" + subMenu +
                            "</li>");
                        }
                        strMenu.Append("</ul>");
                        this.menuPage.InnerHtml = strMenu.ToString();
                        Session["menu"] = strMenu;
                    }
                    else
                        Response.Redirect("login.aspx");
                }
                else {
                    this.menuPage.InnerHtml = Session["menu"].ToString();
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {
            }
        }

        private string GetSubMenu(int parentId) {
            string s = "";
            var menu = listMenu.Where(x => x.ParentID == parentId).OrderByDescending(x => x.DisplayIndex);
            foreach (var item in menu)
            {
                listMenu.Remove(item);
                string subMenu = GetSubMenu(item.MenuId);
                string link = item.Onclick == "" ? "Page.aspx?m=" + item.MenuId : item.Onclick;
                s += "<li class='nav-item' id='m_" + item.MenuId + "'>" +
                        "<a href='" + (subMenu != "" ? "javascript:;": link) +"' class='nav-link'>" + (item.Icon != "" ? "<i class='" + item.Icon + "'></i> " : "") +
                            "<span class='title'>" + item.MenuName + "</span>" +
                        "</a>" + subMenu + 
                    "</li>";
            }
            
            return s != "" ? "<ul class='sub-menu'>" + s + "</ul>" : "";
        }

        /// <summary>
        /// GetUserInfo
        /// Return AccountId, Email, UserName, Avatar, Token 
        /// </summary>
        /// <returns></returns>
        //public UserInfo GetUserInfo() {
        //    try
        //    {
        //        if (Session["account"] != null)
        //        {
        //            var userData = (UserInfo)Session["account"];
        //            return userData;
        //        }
        //        else
        //        {
        //            if (Request.Cookies["accountToken"] != null)
        //            {
        //                string token = Request.Cookies["accountToken"].Value;
        //                return Apis.Account.GetUserByToken(token);
        //            }
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.SaveError("Error GetUserInfo: " + ex);
        //        return null;
        //    }
        //}

        /// <summary>
        /// GetUserByToken
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        //private UserInfo GetUserByToken(string token)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(token))
        //        {
        //            Model.AccountModel acc = new Model.AccountModel();
        //            int? code = 0;
        //            var userData = acc.LoginWithToken(token, Lib.UtilClass.GetIPAddress(), ref code);
        //            if (code == 1)
        //            {
        //                Session["account"] = userData;
        //                return userData;
        //            }
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// CheckPagePermission
        /// </summary>
        /// <returns></returns>
        public bool CheckPagePermission(int menuId, Lib.Constants.USER_PERMISSTIONS rule)
        {
            try
            {
                userData = Apis.Account.GetAccountInfo(HttpContext.Current); //GetUserInfo();
                if (userData == null)
                    return false;
                else
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR CheckPagePermission: " + ex);
                return false;
            }
        }
    }
}