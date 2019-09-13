using CMS_Tools.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class VetifyResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string token = Request.QueryString["token"];
                if (!string.IsNullOrEmpty(token))
                {
                    string decrypt = Encryptor.DecryptString(Encryptor.Base64Decode(token), Constants.KEY_SERVER);
                    if(decrypt != "")
                    {
                        Logs.SaveLog("VetifyResetPassword info: " + decrypt);
                        var a = decrypt.Split('|');
                        string email = a[0];
                        string timeExpire = a[1];
                        string clientIp = a[2];
                        byte loginType = byte.Parse(a[3]);
                        long count = UtilClass.UnixTime(DateTime.Now) - int.Parse(timeExpire);
                        if (count <= 300)
                        {
                            Session["resetpassword"] = new ResetPasswordUser()
                            {
                                loginId = email,
                                loginType = loginType
                            };
                            Response.Redirect("ResetPassword.aspx");
                        }
                        else
                        {
                            Response.Write("<h1>Token hết hiệu lực!</h1>");
                        }
                    }
                    else
                        Response.Write("<h1>PAGE 404 NOT FOUND!</h1>");
                }
                else
                {
                    Response.Write("<h1>PAGE 404 NOT FOUND!</h1>");
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Response.Write("ERROR: " + ex.Message);
            }
        }
    }

    public class ResetPasswordUser
    {
        public string loginId { get; set; }
        public byte loginType { get; set; }
    }
}