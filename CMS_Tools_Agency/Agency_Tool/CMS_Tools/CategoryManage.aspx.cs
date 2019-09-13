using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class CategoryManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var u = Apis.Account.GetAccountInfo(HttpContext.Current);
            if (u == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}