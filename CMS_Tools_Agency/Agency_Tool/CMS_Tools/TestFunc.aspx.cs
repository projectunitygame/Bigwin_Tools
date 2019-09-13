using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class TestFunc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ngaydatgiay = "25/05/2019 10:00";
            var d = ngaydatgiay.Split(' ')[0].Split('/');
            string _ngaydat = d[2] + "/" + d[1] + '/' + d[0] + " " + ngaydatgiay.Split(' ')[1] + ":00"; //yyyy/mm/dd hh:mm:ss
            DateTime date = Convert.ToDateTime(_ngaydat);
        }
    }
}