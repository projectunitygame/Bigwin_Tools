using CMS_Tools.Apis;
using CMS_Tools.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class Page : System.Web.UI.Page
    {
        UserInfo userData = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                userData = Account.GetAccountInfo(HttpContext.Current);
                if (userData == null)
                {
                    Response.Redirect("login.aspx");
                    return;
                }
                
                string m = Request.QueryString["m"];
                if (string.IsNullOrEmpty(m))
                    Response.Redirect("Page404.aspx");
                else {
                    var menuID = (List<int>)Session["menuId"];
                    if (!menuID.Contains(int.Parse(m)))
                    {
                        Response.Redirect("login.aspx");
                        return;
                    }
                    else
                    {
                        Model.ManagerDAO manageDao = new Model.ManagerDAO();
                        int code = 0;
                        var menuData = manageDao.MenuModel.GetMenuByID(int.Parse(m), ref code);
                        if (code > 0)
                        {
                            string css = menuData.Rows[0][10].ToString();
                            string js = menuData.Rows[0][12].ToString();
                            string html = menuData.Rows[0][11].ToString();
                            string title = menuData.Rows[0][2].ToString();
                            string description = menuData.Rows[0][3].ToString();
                            this.lblMenuName.InnerText = title;
                            if (!string.IsNullOrEmpty(css))
                                Lib.UtilClass.IncludeCSS(this, css);
                            if (!string.IsNullOrEmpty(js))
                                Lib.UtilClass.IncludeSourceJS(this, js);
                            if (!string.IsNullOrEmpty(html))
                                PageID.InnerHtml = html;
                            PageTitle.InnerHtml = "<h1 class='page-title'>" + title +
                                    " <small>" + description + "</small>" +
                                "</h1> ";
                        }
                        else
                        {
                            Response.Redirect("Page404.aspx");
                        }
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR PAGE: " + ex);
            }
        }
    }
}