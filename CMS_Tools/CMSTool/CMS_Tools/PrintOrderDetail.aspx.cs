using CMS_Tools.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class PrintOrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.NgayIn.Value = DateTime.Now.ToString("dd/MM/yyyy");
            this.orderID.Value = Request.QueryString["OrderID"];
            this.pagePrint.Value = Request.QueryString["p"];
            if (string.IsNullOrEmpty(Request.QueryString["p"]))
                this.pagePrint.Value = "all";
            UserInfo userData = GetUserInfo();
            if (userData == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            this.userName.Value = userData.UserName;
        }

        public UserInfo GetUserInfo()
        {
            try
            {
                if (Session["account"] != null)
                {
                    var userData = (UserInfo)Session["account"];
                    return userData;
                }
                else
                {
                    string token = Request.Cookies["accountToken"].Value;
                    return GetUserByToken(token);
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error GetUserInfo: " + ex);
                return null;
            }
        }

        private UserInfo GetUserByToken(string token)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    Model.AccountModel acc = new Model.AccountModel();
                    int? code = 0;
                    var userData = acc.LoginWithToken(token, Lib.UtilClass.GetIPAddress(), ref code);
                    if (code == 1)
                    {
                        Session["account"] = userData;
                        return userData;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}