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
    public partial class MenuManage : System.Web.UI.Page
    {
        string menuId = "-9999";//admin
        
        Constants.USER_PERMISSTIONS page_rule = Constants.USER_PERMISSTIONS.VIEW;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string strParentID = Request.QueryString["parentId"];
                int parentID = 0;
                if (!string.IsNullOrEmpty(strParentID))
                    int.TryParse(strParentID, out parentID);
                Site1 masterPage = (Site1)Page.Master;
                if (!masterPage.CheckPagePermission(int.Parse(menuId), page_rule))
                {
                    Response.Redirect("page404.aspx?errorCode=" + Constants.NUMBER_CODE.YOU_DO_NOT_PERMISSION_TO_ACCESS);
                }
                //TO DO
                string token = masterPage.userData.Token;
                this.input_parentID.Value = Encryptor.EncryptString(parentID + "#" + (int)page_rule + "#" + token, token);
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {
                Response.Redirect("page404.aspx?errorCode=" + Constants.NUMBER_CODE.ERROR_EX);
            }
        }
    }
}