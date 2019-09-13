using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools.Authen
{
    public partial class LoginGG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var JSON = Lib.GoogleLib.GetConfigGoogle(Lib.Constants.GG_JSON_FILE);
                string linkRequest = JSON.web.auth_uri + "?scope=profile" +
                    "&access_type=offline&include_granted_scopes=true&state=state_parameter_passthrough_value&redirect_uri=" +
                    (Lib.Constants.SERVER_TYPE == "REAL" ? JSON.web.redirect_uris[1] : JSON.web.redirect_uris[0]) + "&response_type=code&client_id=" + JSON.web.client_id;
                Response.Redirect(linkRequest);
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR REQUEST LOGIN GG: " + ex);
            }
        }       
    }
}