using CMS_Tools.Apis;
using CMS_Tools.Lib;
using CMS_Tools.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int debug = 0;
            this.copyRight.InnerHtml = "<p>Copyright &copy; "+ Lib.Constants.COPY_RIGHT + " " + DateTime.Now.Year + "</p>";
            //Lib.Mail.SendEmail("test mail", "cmstools", "devproduction.vn@gmail.com");
            //Lib.Logs.logSendMail.Error("test send mail log4 .NET", new Exception("test"));
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ref"]) && Request.QueryString["ref"] == "-1")
                {
                    Session["account"] = null;
                }
                else
                {
                    debug = 1;
                    if (Session["loginFailed"] != null)
                    {
                        debug = 2;
                        dynamic data = JObject.Parse(Session["loginFailed"].ToString());
                        string pic = "";
                        string userName = "";
                        string email = "";
                        string id = "";
                        if (data.loginType == Lib.Constants.LOGIN_TYPE.GOOGLE)
                        {
                            pic = data.data.picture;
                            userName = data.data.name;
                            id = data.data.id;
                            email = data.data.email;
                        }
                        else if (data.loginType == Lib.Constants.LOGIN_TYPE.FB)
                        {
                            pic = data.data.picture.data.url;
                            userName = data.data.name;
                            id = data.data.id;
                            email = data.data.email;
                        }
                        StringBuilder str = new StringBuilder();
                        str.Append("<div class='popup'><div class='bgTopup'><div class=''>");
                        str.Append("<div class='col1'><img src='" + pic + ";/></div>");
                        str.Append("<div class='col2'><div class='userName'>" + userName + "</div>" +
                            "<div>(" + id + ")</div><div>" + data.data.email + "</div><div class='msgError'>Tài khoản không tồn tại!</div></div></div></div></div>");
                        this.showPopup.InnerHtml = str.ToString();
                        Session["loginFailed"] = null;
                        return;
                    }

                    string token = "";
                    if (Session["account"] != null)
                    {
                        try
                        {
                            debug = 3;
                            var userData = (UserInfo)Session["account"];
                            token = userData.Token;
                        }
                        catch (Exception ex)
                        {
                            debug = 6;
                            Session["account"] = null;
                            Logs.SaveError("ERROR LOGIN [" + debug + "]\r\n" + ex);
                            return;
                        }
                    }
                    else
                    {
                        if(Request.Cookies["accountToken"] != null)
                            token = Request.Cookies["accountToken"].Value;
                    }


                    if (!string.IsNullOrEmpty(token))
                    {
                        debug = 4;
                        var userData = Account.GetUserByToken(token);
                        debug = 5;
                        if (userData != null)
                        {
                            Response.Redirect("Page.aspx?m=10");
                            //if (userData.GroupID == 6)
                            //    Response.Redirect("Page.aspx?m=10");
                            //else
                            //    Response.Redirect("Dashboard.aspx");
                        }
                        //Model.AccountModel acc = new Model.AccountModel();
                        //int? code = 0;
                        //string ip = UtilClass.GetIPAddress();
                        //Logs.SaveLog("LoginWithToken: " + token + "," + ip);
                        //var userInfo = acc.LoginWithToken(token, ip, ref code);
                        //Logs.SaveLog("Result LoginWithToken: " + code);
                        //if (code == 1)
                        //{
                        //    Response.Redirect("Dashboard.aspx");
                        //    return;
                        //}
                        //Session["account"] = null;
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR LOGIN ["+ debug + "] " + ex, ex);
            }           
        }
    }
}