using CMS_Tools.Lib;
using CMS_Tools.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace CMS_Tools.Apis
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {
        UserInfo accountInfo;
        int sizeWeb = 1200;
        int sizeTable = 768;
        int sizePhone = 470;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                accountInfo = Account.GetAccountInfo(context);

                if (accountInfo == null)
                {
                    var r = new
                    {
                        status = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN,
                        msg = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN.ToString()
                    };
                    context.Response.Write(JsonConvert.SerializeObject(r));
                    return;
                }
                if (context.Request.Files.Count > 0)
                {
                    if (context.Request.Files.Count < 10)
                    {
                        var file = context.Request.Files[0];
                        EditImages objUpload = new EditImages();
                        string publisherName = accountInfo.PublisherID.ToString();
                        string path = context.Server.MapPath("../upload/" + publisherName + "/" + DateTime.Now.ToShortDateString().Replace('/', '-') + "/");
                        string pathTemp = "../upload/" + publisherName + "/" + DateTime.Now.ToShortDateString().Replace('/', '-') + "/";
                        string typeIMG = System.IO.Path.GetExtension(file.FileName);
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        string _sizeWeb = context.Request.Form["sizeWeb"];
                        if (string.IsNullOrEmpty(_sizeWeb))
                            _sizeWeb = context.Request.QueryString["sizeWeb"];
                        string _sizeTable = context.Request.Form["sizeTable"];
                        if (string.IsNullOrEmpty(_sizeTable))
                            _sizeTable = context.Request.QueryString["sizeTable"];
                        string _sizePhone = context.Request.Form["sizePhone"];
                        if (string.IsNullOrEmpty(_sizePhone))
                            _sizePhone = context.Request.QueryString["sizePhone"];

                        if (!string.IsNullOrEmpty(_sizeWeb))
                            sizeWeb = Convert.ToInt32(_sizeWeb);
                        if (!string.IsNullOrEmpty(_sizeTable))
                            sizeTable = Convert.ToInt32(_sizeTable);
                        if (!string.IsNullOrEmpty(_sizePhone))
                            sizePhone = Convert.ToInt32(_sizePhone);

                        objUpload.iMaxWebWidth = sizeWeb;
                        objUpload.iMaxTabletWidth = sizeTable;
                        objUpload.iMaxPhoneWidth = sizePhone;
                        objUpload.sPath = path;
                        objUpload.fileUpped = file;
                        objUpload.sFileName = GetUniqueFileName(file.FileName, path, typeIMG);

                        objUpload.Process_Upload();
                        //var result = new { message = "success", urlImage = pathTemp + objUpload.sFileName + typeIMG, urlImageTemp = pathTemp + "temp_" + objUpload.sFileName + typeIMG, id = objUpload.sFileName, fileName = objUpload.sFileName + typeIMG, fileSize = calculatorSizeFile(file.ContentLength) };
                        ResultImages result = new ResultImages();
                        result.status = (int)Constants.NUMBER_CODE.SUCCESS;
                        result.msg = "success";
                        result.urlWeb = pathTemp + objUpload.sFileName + typeIMG;
                        result.urlTablet = pathTemp + "ThumbTable_" + objUpload.sFileName + typeIMG;
                        result.urlPhone = pathTemp + "ThumbPhone_" + objUpload.sFileName + typeIMG;
                        result.id = objUpload.sFileName;
                        result.fileName = objUpload.sFileName + typeIMG;
                        result.size = calculatorSizeFile(file.ContentLength);
                        context.Response.Write(serializer.Serialize(result));
                    }
                    else
                    {
                        var result = new { message = "error", name = "Limit upload images to not more than 5!" };
                        context.Response.Write(serializer.Serialize(result));
                    }
                }
                else
                {
                    var result = new { message = "error", name = "No image upload!" };
                    context.Response.Write(serializer.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                var result = new { message = "error", name = ex.Message };
                context.Response.Write(serializer.Serialize(result));
            }
        }

        public string calculatorSizeFile(float fSize)
        {
            string[] fSExt = new string[] { "Bytes", "KB", "MB", "GB" };
            int i = 0;
            while (fSize > 900)
            {
                fSize /= 1024; i++;
            }
            return Math.Round(fSize * 100) / 100 + fSExt[i];
        }

        public static string GetUniqueFileName(string name, string savePath, string ext)
        {

            name = name.Replace(ext, "").Replace(" ", "_");
            name = System.Text.RegularExpressions.Regex.Replace(name, @"[^\w\s]", "");

            var newName = name;
            var i = 0;
            if (System.IO.File.Exists(savePath + newName + ext))
            {

                do
                {
                    i++;
                    newName = name + "_" + i;

                }
                while (System.IO.File.Exists(savePath + newName + ext));

            }

            return newName;


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class ResultImages
    {
        public int status { get; set; }
        public string msg { get; set; }
        public string urlWeb { get; set; }
        public string urlTablet { get; set; }
        public string urlPhone { get; set; }
        public string id { get; set; }
        public string fileName { get; set; }
        public string size { get; set; }
    }
}