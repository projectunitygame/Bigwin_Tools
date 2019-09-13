using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools.Authen
{
    public partial class FB_OauthCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ip = Lib.UtilClass.GetIPAddress();
            try
            {
                Lib.Logs.logTracking.Info(Request.Url.AbsoluteUri +
                "\r\nUrlReferrer: " + (Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : "") +
                "\r\nIP: " + ip);
                string authToken = Request.QueryString["code"];
                if (!String.IsNullOrEmpty(authToken))
                {
                    var fbData = Lib.FacebookLib.FB_Login(authToken);
                    if (fbData != null)
                    {
                        Lib.Logs.SaveLog("RESULT LOGIN FB INFO: " + JsonConvert.SerializeObject(fbData));
                        Model.ManagerDAO manager = new Model.ManagerDAO();
                        int? codeNumber = 0;
                        var data = manager.AccountModel.LoginID(new Model.LoginInfo()
                        {
                            deviceId = "",
                            deviceName = "",
                            ip = Lib.UtilClass.GetIPAddress(),
                            loginId = fbData.id,
                            loginType = (byte)Lib.Constants.LOGIN_TYPE.FB
                        }, ref codeNumber);
                        if (codeNumber == (int)Lib.Constants.NUMBER_CODE.LOGIN_SUCCESS)
                        {
                            Lib.UtilClass.AddCookie(this, "accountToken", data.Token);
                            Session["account"] = data;
                            Response.Redirect("../Dashboard.aspx");
                            //Response.Write(Lib.Helper.DataTableToJSON(data));
                        }
                        else
                        {
                            var userTemp = new
                            {
                                data = fbData,
                                loginType = (byte)Lib.Constants.LOGIN_TYPE.FB
                            };
                            Session["loginFailed"] = JsonConvert.SerializeObject(userTemp);
                            Response.Redirect("../login.aspx");
                        }
                        //var data = manager.AccountModel.Register(new Model.RegisterInfo()
                        //{
                        //    deviceId = "",
                        //    deviceName = "",
                        //    email = fbData.email != null ? fbData.email : "",
                        //    ip = ip,
                        //    loginId = fbData.id,
                        //    loginType = (byte)Lib.Constants.LOGIN_TYPE.FB,
                        //    picture = fbData.picture.data.url,
                        //    userName = fbData.name
                        //}, ref codeNumber);
                        //var userinfo = Lib.Helper.DataTableToJSON(data);
                        //Response.Write(codeNumber + ", " + userinfo);



                        //Response.Write(JsonConvert.SerializeObject(fbData));
                    }
                    else
                    {

                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("[FB CALLBACK] " + ex);
                Response.Write(ex);
            }
        }        
    }  
}