using CMS_Tools.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Site1 masterPage = (Site1)Page.Master;
                var u = Apis.Account.GetAccountInfo(HttpContext.Current);
                if(u == null)
                {
                    Response.Redirect("Login.aspx");
                }
                string publisherId = u.PublisherID.ToString();
                var token = new
                        {
                    publisherName = UtilClass.General_publisher(publisherId),
                    userId = u.AccountId.ToString(),
                    clientIp = UtilClass.GetIPAddress()
                };
                string url_path = "/upload/" + UtilClass.General_publisher(publisherId) + "/article";
                string path = Server.MapPath(url_path);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                this.RadEditor1.ImageManager.ViewPaths = new string[] { url_path, url_path };
                this.RadEditor1.ImageManager.UploadPaths = new string[] { url_path, url_path };
                this.RadEditor1.ImageManager.DeletePaths = new string[] { url_path, url_path };
                this.RadEditor1.ImageManager.MaxUploadFileSize = 2204800;

                this.RadEditor1.MediaManager.ViewPaths = new string[] { url_path, url_path };
                this.RadEditor1.MediaManager.UploadPaths = new string[] { url_path, url_path };
                this.RadEditor1.MediaManager.DeletePaths = new string[] { url_path, url_path };
                this.RadEditor1.MediaManager.MaxUploadFileSize = 10204800;

                this.RadEditor1.DocumentManager.ViewPaths = new string[] { url_path, url_path };
                this.RadEditor1.DocumentManager.UploadPaths = new string[] { url_path, url_path };
                this.RadEditor1.DocumentManager.DeletePaths = new string[] { url_path, url_path };
                this.RadEditor1.DocumentManager.MaxUploadFileSize = 5204800;

                this.RadEditor1.TemplateManager.ViewPaths = new string[] { url_path, url_path };
                this.RadEditor1.TemplateManager.UploadPaths = new string[] { url_path, url_path };
                this.RadEditor1.TemplateManager.DeletePaths = new string[] { url_path, url_path };
                this.RadEditor1.TemplateManager.MaxUploadFileSize = 1204800;

                this.RadEditor1.FlashManager.ViewPaths = new string[] { url_path, url_path };
                this.RadEditor1.FlashManager.UploadPaths = new string[] { url_path, url_path };
                this.RadEditor1.FlashManager.DeletePaths = new string[] { url_path, url_path };
                this.RadEditor1.FlashManager.MaxUploadFileSize = 1204800;
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {
            }
        }
    }
}