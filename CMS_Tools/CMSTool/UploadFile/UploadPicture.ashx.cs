using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using UploadFile.Lib;

namespace UploadFile
{
    /// <summary>
    /// Summary description for UploadPicture
    /// </summary>
    public class UploadPicture : IHttpHandler
    {
        public const string KEY = "63dc8f4d5805b4b972e769b9d50ff004";
        static int sizeWeb = 2048;
        static int sizeTable = 768;
        static int sizePhone = 470;
        static int maxsize = 3*1024*1000;//3mb
        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.ContentType = "application/json";
            ResultImages result = new ResultImages();
            try
            {               
                string json = context.Request.QueryString["token"];
                json = Encryptor.DecryptString(Encryptor.Base64Decode(json), KEY);
                if (!string.IsNullOrEmpty(json))
                {
                    var data = JsonConvert.DeserializeObject<TokenUpload>(json);
                    if (context.Request.Files.Count > 0)
                    {
                        HttpPostedFile file = null;

                        for (int i = 0; i < context.Request.Files.Count; i++)
                        {
                            file = context.Request.Files[i];
                            Logs.SaveLog("File info: " + file.FileName + ", " + file.ContentLength);
                            if (file.ContentLength > 0 && file.ContentLength < maxsize)
                            {
                                #region process upload images
                                EditImages objUpload = new EditImages();

                                string url = "upload/" + data.publisherName + "/" + DateTime.Now.ToString("yyyy/MM/dd").Replace('/', '_') + "/";
                                string path = context.Server.MapPath(url);
                                if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);
                                string typeIMG = System.IO.Path.GetExtension(file.FileName);
                                string fileName = GetUniqueFileName(file.FileName, path, typeIMG);
                                objUpload.sFileName = fileName;
                                objUpload.iMaxWebWidth = sizeWeb;
                                objUpload.iMaxTabletWidth = sizeTable;
                                objUpload.iMaxPhoneWidth = sizePhone;
                                objUpload.sPath = path;
                                objUpload.fileUpped = file;
                                objUpload.Process_Upload_v2();

                                picture pic = new picture();
                                pic.fileName = objUpload.sFileName + typeIMG;
                                pic.urlWeb = context.Request.Url.GetLeftPart(UriPartial.Authority) + "/" + url + pic.fileName;
                                pic.urlTablet = context.Request.Url.GetLeftPart(UriPartial.Authority) + "/" + url + "ThumbTable_" + pic.fileName;
                                pic.urlPhone = context.Request.Url.GetLeftPart(UriPartial.Authority) + "/" + url + "ThumbPhone_" + pic.fileName;
                                pic.sizeWeb = calculatorSizeFile(objUpload.sizeWeb);
                                pic.sizeTablet = calculatorSizeFile(objUpload.sizeTablet);
                                pic.sizePhone = calculatorSizeFile(objUpload.sizePhone);
                                pic.sizeOld = calculatorSizeFile(file.ContentLength);
                                pic.ip = data.clientIp;
                                pic.userId = int.Parse(data.userId);
                                pic.serverTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                                UploadHistoryModel u = new UploadHistoryModel();
                                u.AddUploadHistory(pic);
                                if(pic.id > 0)
                                {
                                    result.status = NUMBER_CODE.SUCCESS;
                                    result.message = result.status.ToString();
                                    result.data = pic;
                                }
                                else
                                {
                                    result.status = NUMBER_CODE.ERROR_ADDHISTORY;
                                    result.message = "Upload file không thành công!";
                                }
                                #endregion
                            }
                            else
                            {
                                result.status = NUMBER_CODE.MAXMaximum_request_length_exceeded;
                                result.message = "File upload không được vượt quá 3MB!";
                            }
                        }
                    }
                    else
                    {
                        result.status = NUMBER_CODE.NO_FILE;
                        result.message = NUMBER_CODE.NO_FILE.ToString();
                    }
                }
                else {
                    result.status = NUMBER_CODE.TOKEN_WRONG;
                    result.message = result.status.ToString();
                }       
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR UploadPicture", ex, true);
                result.status = NUMBER_CODE.EX;
                result.message = ex.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
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
            return StringUtil.SEOUrl(newName);
        }

        public static string calculatorSizeFile(float fSize)
        {
            string[] fSExt = new string[] { "Bytes", "KB", "MB", "GB" };
            int i = 0;
            while (fSize > 900)
            {
                fSize /= 1024; i++;
            }
            return Math.Round(fSize * 100) / 100 + fSExt[i];
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }        
    }

    public enum FILE_TYPE : byte
    {
        IMAGE = 0
    }

    public enum NUMBER_CODE : int
    {
        EX = -9999,
        ERROR_ADDHISTORY = -1,
        SUCCESS = 0,
        TOKEN_WRONG,
        ERROR_UPLOAD,
        NO_FILE,
        MAXMaximum_request_length_exceeded
    }

    public class TokenUpload
    {
        public string publisherName { get; set; }
        public string userId { get; set; }
        public string clientIp { get; set; }
    }

    public class ResultImages
    {

        public string message { get; set; }
        public NUMBER_CODE status { get; set; }
        public object data { get;set; }        
    }

    public class picture
    {
        public string urlWeb { get; set; }
        public string urlTablet { get; set; }
        public string urlPhone { get; set; }
        public long id { get; set; }
        public string fileName { get; set; }
        public string sizeWeb { get; set; }
        public string sizeTablet { get; set; }
        public string sizePhone { get; set; }
        public string sizeOld { get; set; }
        public string ip { get; set; }
        public string serverTime { get; set; }
        public byte uploadType { get; set; }
        public int userId { get; set; }
    }

    public class EditImages
    {
        public string sOverlayText { get; set; }
        public string sFileName { get; set; }
        public int iMaxWebWidth { get; set; }
        public int iMaxTabletWidth { get; set; }
        public int iMaxPhoneWidth { get; set; }
        public string sPath { get; set; }
        public HttpPostedFile fileUpped { get; set; }
        public int sizeWeb { get; set; }
        public int sizeTablet { get; set; }
        public int sizePhone { get; set; }
        public bool sign { get; set; }
        int opacity = 100;

        public EditImages()
        {
            sign = false;
            sOverlayText = "";
        }

        public void Process_Upload_v2()
        {
            try
            {
                //Check for common errors.
                if (!Check_Upload(fileUpped)) return;

                //Initializing local variables
                HttpPostedFile myUpload = fileUpped;
                //int myLength = myUpload.ContentLength;
                string myType = myUpload.ContentType;
                string typeImg = System.IO.Path.GetExtension(myUpload.FileName);
                String myName = sFileName;
                //Running main image processing routine
                //Process_Image(myUpload.InputStream, Path.ChangeExtension(myName, ".jpg"));
                Process_Image_v2(myUpload.InputStream, Path.ChangeExtension(myName, typeImg), myType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Process_Upload()
        {
            try
            {
                //Check for common errors.
                if (!Check_Upload(fileUpped)) return;

                //Initializing local variables
                HttpPostedFile myUpload = fileUpped;
                //int myLength = myUpload.ContentLength;
                string myType = myUpload.ContentType;
                string typeImg = System.IO.Path.GetExtension(myUpload.FileName);
                String myName = sFileName;
                //Running main image processing routine
                //Process_Image(myUpload.InputStream, Path.ChangeExtension(myName, ".jpg"));
                Process_Image(myUpload.InputStream, Path.ChangeExtension(myName, typeImg), myType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void Process_Image_v2(Stream myStream, String myName, string type)
        {
            //Initializing local variables
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
            String myPath = Path.Combine(sPath, myName);
            String myThumbPathTable = Path.Combine(sPath, "ThumbTable_" + myName);
            String myThumbPathPhone = Path.Combine(sPath, "ThumbPhone_" + myName);
            int oldWidth = myImage.Width;
            int oldHeight = myImage.Height;
            int newWidth;
            int newHeight;

            //Determining new image size
            if ((iMaxWebWidth > 0) && (oldWidth > iMaxWebWidth))
            {
                newWidth = iMaxWebWidth;
                newHeight = (int)(oldHeight / ((Double)oldWidth / newWidth));
                Bitmap myBitmap = new Bitmap(myImage, newWidth, newHeight);
                myBitmap.Save(myPath, getType(type));
                myBitmap.Dispose();
            }
            else
            {
                myImage.Save(myPath);
            }
            FileStream fileStream = new FileStream(myPath, FileMode.Open, FileAccess.Read);
            sizeWeb = (int)fileStream.Length;


            if (iMaxTabletWidth > 0 && (oldWidth > iMaxTabletWidth))
            {
                newWidth = iMaxTabletWidth;
                newHeight = (int)(oldHeight / ((Double)oldWidth / newWidth));
                Bitmap myBitmap = new Bitmap(myImage, newWidth, newHeight);
                myBitmap.Save(myThumbPathTable, getType(type));
                myBitmap.Dispose();
            }
            else
            {
                myImage.Save(myThumbPathTable);
            }
            fileStream = new FileStream(myThumbPathTable, FileMode.Open, FileAccess.Read);
            sizeTablet = (int)fileStream.Length;

            if (iMaxPhoneWidth > 0 && (oldWidth > iMaxPhoneWidth))
            {
                newWidth = iMaxPhoneWidth;
                newHeight = (int)(oldHeight / ((Double)oldWidth / newWidth));
                Bitmap myBitmap = new Bitmap(myImage, newWidth, newHeight);
                myBitmap.Save(myThumbPathPhone, getType(type));
                myBitmap.Dispose();
            }
            else
            {
                myImage.Save(myThumbPathPhone);
            }
            fileStream = new FileStream(myThumbPathPhone, FileMode.Open, FileAccess.Read);
            sizePhone = (int)fileStream.Length;
        }

        void Process_Image(Stream myStream, String myName, string type)
        {
            //Initializing local variables
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
            String myPath = Path.Combine(sPath, myName);
            String myThumbPathTable = Path.Combine(sPath, "ThumbTable_" + myName);
            String myThumbPathPhone = Path.Combine(sPath, "ThumbPhone_" + myName);
            int oldWidth = myImage.Width;
            int oldHeight = myImage.Height;
            int newWidth;
            int newHeight;
            //Determining new image size
            if ((iMaxWebWidth > 0) && (oldWidth > iMaxWebWidth))
            {
                newWidth = iMaxWebWidth;
                newHeight = (int)(oldHeight / ((Double)oldWidth / newWidth));
            }
            else
            {
                newWidth = oldWidth;
                newHeight = oldHeight;
            }

            //Creating new, re-sized image
            //process image web
            Bitmap myBitmap = new Bitmap(myImage, newWidth, newHeight);

            //Creating the text overlay for re-sized image
            if (sOverlayText != "" && sign == true)
            {
                Graphics myCanvas = Graphics.FromImage(myBitmap);
                Font myFont = new Font("Tahoma", 14, FontStyle.Bold);
                StringFormat myFormat = new StringFormat(StringFormatFlags.LineLimit);


                myCanvas.DrawString(
                    sOverlayText, myFont,
                    new SolidBrush(Color.FromArgb(opacity, Color.Black)),
                    //new PointF((newWidth/2) - 220, (newHeight/2)-25), 
                    new PointF(10, 10),
                    myFormat);
                //myCanvas.DrawString(sOverlayText, myFont, Brushes.Black, new PointF(6, 6), myFormat);
                //myCanvas.DrawString(sOverlayText, myFont, Brushes.Black, new PointF(4, 6), myFormat);
                //myCanvas.DrawString(sOverlayText, myFont, Brushes.Black, new PointF(6, 4), myFormat);
                //myCanvas.DrawString(sOverlayText, myFont, Brushes.Gray, new PointF(5, 5), myFormat);
                myCanvas.Dispose();
            }

            //Writing text overlayed image to disk and cleaning up
            myBitmap.Save(myPath, getType(type));
            myBitmap.Dispose();
            FileStream fileStream = new FileStream(myPath, FileMode.Open, FileAccess.Read);
            sizeWeb = (int)fileStream.Length;
            //Creating thumbnail and writing to disk


            if (iMaxTabletWidth > 0 && (oldWidth > iMaxTabletWidth))
            {
                newWidth = iMaxTabletWidth;
                newHeight = (int)(oldHeight / ((Double)oldWidth / newWidth));
            }
            else
            {
                newWidth = oldWidth;
                newHeight = oldHeight;
            }

            // process image tablet
            Bitmap myThumb_table = new Bitmap(myImage, newWidth, newHeight);
            if (sOverlayText != "" && sign == true)
            {
                Graphics myCanvas = Graphics.FromImage(myThumb_table);
                //int opacity = 70;
                Font myFont = new Font("Tahoma", 11, FontStyle.Bold);
                StringFormat myFormat = new StringFormat(StringFormatFlags.LineLimit);


                myCanvas.DrawString(
                    sOverlayText, myFont,
                    new SolidBrush(Color.FromArgb(opacity, Color.Black)),
                    //new PointF((newWidth / 2) - 140, (newHeight / 2) - 25),
                    new PointF(5, 5),
                    myFormat);
                myCanvas.Dispose();
            }
            myThumb_table.Save(myThumbPathTable, getType(type));
            myThumb_table.Dispose();
            fileStream = new FileStream(myThumbPathTable, FileMode.Open, FileAccess.Read);
            sizeTablet = (int)fileStream.Length;


            if (iMaxPhoneWidth > 0 && (oldWidth > iMaxPhoneWidth))
            {
                newWidth = iMaxPhoneWidth;
                newHeight = (int)(oldHeight / ((Double)oldWidth / newWidth));
            }
            else
            {
                newWidth = oldWidth;
                newHeight = oldHeight;
            }
            // process image phone
            Bitmap myThumb_phone = new Bitmap(myImage, newWidth, newHeight);
            if (sOverlayText != "" && sign == true)
            {
                Graphics myCanvas = Graphics.FromImage(myThumb_phone);
                //int opacity = 70;
                Font myFont = new Font("Tahoma", 9, FontStyle.Bold);
                StringFormat myFormat = new StringFormat(StringFormatFlags.LineLimit);


                myCanvas.DrawString(
                    sOverlayText, myFont,
                    new SolidBrush(Color.FromArgb(opacity, Color.Black)),
                    //new PointF((newWidth / 2) - 130, (newHeight / 2) - 30),
                    new PointF(5, 5),
                    myFormat);
                myCanvas.Dispose();
            }
            myThumb_phone.Save(myThumbPathPhone, getType(type));
            myThumb_phone.Dispose();
            //Cleaning up parent image object
            myImage.Dispose();
            fileStream = new FileStream(myThumbPathPhone, FileMode.Open, FileAccess.Read);
            sizePhone = (int)fileStream.Length;
        }

        bool Check_Upload(HttpPostedFile fileUpped)
        {
            //Checking to see if field was left empty
            if (fileUpped.FileName == "")
            {
                throw new Exception("Error:No file sbumitted");
            }
            //Checking for Jpeg / Gif mime types
            if (!Regex.IsMatch(fileUpped.ContentType, "image/(?:\\w?jpeg|gif|png)", RegexOptions.IgnoreCase))
            {
                throw new Exception("Only JPG's, PNG and GIF's allowed");
            }
            //Checking for zero length.  You could also use to check for large files.
            if (fileUpped.ContentLength == 0)
            {
                throw new Exception("File cannot be zero bytes.");
            }
            return true;
        }

        private ImageFormat getType(string type)
        {
            switch (type)
            {
                case "image/jpg":
                    return ImageFormat.Jpeg;
                case "image/png":
                    return ImageFormat.Png;
                case "image/gif":
                    return ImageFormat.Gif;
                case "image/jpeg":
                    return ImageFormat.Jpeg;
                case "image/bmp":
                    return ImageFormat.Bmp;
                default:
                    return ImageFormat.Jpeg;
            }
        }
    }
}