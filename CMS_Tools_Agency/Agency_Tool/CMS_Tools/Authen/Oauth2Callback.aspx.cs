using CMS_Tools.Lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools.Authen
{
    public partial class Oauth2Callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string code = Request.QueryString["code"];
                string ip = Lib.UtilClass.GetIPAddress();
                Lib.Logs.logTracking.Info(Request.Url.AbsoluteUri +
                "\r\nUrlReferrer: " + (Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : "") + 
                "\r\nIP: " + ip + 
                "\r\nCode: " + code);
                
                if (!string.IsNullOrEmpty(code))
                {         
                    var userData = GoogleLib.GetGoogleUserInfo(code);

                    if (userData != null)
                    {
                        Model.ManagerDAO manager = new Model.ManagerDAO();
                        int? codeNumber = 0;
                        var data = manager.AccountModel.LoginID(new Model.LoginInfo()
                        {
                            deviceId = "",
                            deviceName = "",
                            ip = UtilClass.GetIPAddress(),
                            loginId = userData.id,
                            loginType = (byte)Lib.Constants.LOGIN_TYPE.GOOGLE
                        }, ref codeNumber);
                        if (codeNumber == (int)Lib.Constants.NUMBER_CODE.LOGIN_SUCCESS)
                        {
                            UtilClass.AddCookie(this, "accountToken", data.Token);

                            Session["account"] = data;
                            Response.Redirect("../Dashboard.aspx");
                            //Response.Write(Lib.Helper.DataTableToJSON(data));
                        }
                        else
                        {
                            var userTemp = new
                            {
                                data = userData,
                                loginType = (byte)Lib.Constants.LOGIN_TYPE.GOOGLE
                            };
                            Session["loginFailed"] = JsonConvert.SerializeObject(userTemp);
                            Response.Redirect("../login.aspx");
                        }
                        //var data = manager.AccountModel.Register(new Model.RegisterInfo()
                        //{
                        //    deviceId = "",
                        //    deviceName = "",
                        //    email = userData.email != null ? userData.email : "",
                        //    ip = ip,
                        //    loginId = userData.id,
                        //    loginType = (byte)Lib.Constants.LOGIN_TYPE.GOOGLE,
                        //    picture = userData.picture,
                        //    userName = userData.name
                        //}, ref codeNumber);
                        //var userinfo = Lib.Helper.DataTableToJSON(data);
                        //Response.Write(codeNumber + ", " + userinfo);
                    }
                    else
                    {
                        Response.Write("Account Null");
                    }
                }
                else
                {
                    string error = Request.QueryString["error"];
                    if (!string.IsNullOrEmpty(error))
                        Response.Write(error);
                    else
                        Response.Write("Code not found!");
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR Oauth2Callback: " + ex);
                Response.Write("ERROR " + ex);
            }
            
        }
    }   
}