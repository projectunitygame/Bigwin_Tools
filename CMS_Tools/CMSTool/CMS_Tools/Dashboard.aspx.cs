using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class Dashboard : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Page.aspx?m=10");
                //Site1 m = (Site1)Page.Master;
                //var userData = m.GetUserInfo();
                //if(userData == null)
                //{
                //    Response.Redirect("login.aspx");
                //    return;
                //}
                //Response.Write(Lib.Helper.DataTableToJSON(userData));
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR PAGE Dashboard: " + ex);
            }
        }
    }
}