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
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string menuId = Request.QueryString["m"];
                string action = Request.QueryString["action"];
                string parent = Request.QueryString["parent"];
                if(!string.IsNullOrEmpty(action))
                {
                    Constants.USER_PERMISSTIONS page_rule;
                    if(!Constants.TryParseEnum<Constants.USER_PERMISSTIONS>(int.Parse(action), out page_rule))
                    {
                        Response.Redirect("page404.aspx");
                    }
                    if (string.IsNullOrEmpty(menuId))
                        menuId = "0";
                    Site1 masterPage = (Site1)Page.Master;
                    if (!masterPage.CheckPagePermission(int.Parse(menuId), page_rule))
                    {
                        Response.Redirect("page404.aspx?errorCode=" + Constants.NUMBER_CODE.YOU_DO_NOT_PERMISSION_TO_ACCESS);
                    }
                    //TO DO
                    string token = masterPage.userData.Token;
                    this.input_action.Value = Encryptor.EncryptString(menuId + "#" + (int)page_rule + "#" + token, token);
                    if (!string.IsNullOrEmpty(parent) && page_rule == Constants.USER_PERMISSTIONS.ADD)
                    {
                        string d = Encryptor.DecryptString(parent, token);
                        if (d != "" && d.Split('#')[2] == token)
                        {
                            this.input_parent.Value = d.Split('#')[0];
                        }
                        else
                            Response.Redirect("page404.aspx?errorCode=" + Constants.NUMBER_CODE.TOKEN_EXPIRE);
                    }
                }
                else
                {
                    Response.Redirect("page404.aspx");
                }
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