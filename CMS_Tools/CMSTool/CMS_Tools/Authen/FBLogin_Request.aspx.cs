using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools.Authen
{
    public partial class FBLogin_Request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string url = string.Format(@"{0}?client_id={1}&redirect_uri={2}&scope={3}", Lib.FacebookLib.FB_URL_Oauth, Lib.FacebookLib.FB_APP_ID, Lib.UtilClass.GetWebAppRoot() + Lib.FacebookLib.FB_URL_CALLBACK, Lib.FacebookLib.FB_SCOPE);
                Lib.Logs.SaveLog("Url: " + Request.Url.AbsoluteUri + "\r\nRedirect LoginFB: " + url);
                Response.Redirect(url);
                return;
            }
            catch (ThreadAbortException) { }
            catch (Exception)
            { }
        }
    }
}