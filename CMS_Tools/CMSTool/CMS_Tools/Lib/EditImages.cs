using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace CMS_Tools.Lib
{
    public class EditImages
    {
        //public string sOverlayText { get; set; }
        public string sFileName { get; set; }
        public int iMaxWebWidth { get; set; }
        public int iMaxTabletWidth { get; set; }
        public int iMaxPhoneWidth { get; set; }
        public string sPath { get; set; }
        public HttpPostedFile fileUpped { get; set; }

        public void Process_Upload()
        {
            try
            {
                //Check for common errors.
                if (!Check_Upload(fileUpped)) return;

                //Initializing local variables
                HttpPostedFile myUpload = fileUpped;
                int myLength = myUpload.ContentLength;
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

        void Process_Image(Stream myStream, String myName,string type)
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
            Bitmap myBitmap = new Bitmap(myImage, newWidth, newHeight);

            //Creating the text overlay for re-sized image
            //if (sOverlayText != "")
            //{
            //    Graphics myCanvas = Graphics.FromImage(myBitmap);
            //    Font myFont = new Font("Verdana", 14, FontStyle.Bold);
            //    StringFormat myFormat = new StringFormat(StringFormatFlags.LineLimit);

            //    myCanvas.DrawString(sOverlayText, myFont, Brushes.Black, new PointF(4, 4), myFormat);
            //    myCanvas.DrawString(sOverlayText, myFont, Brushes.Black, new PointF(6, 6), myFormat);
            //    myCanvas.DrawString(sOverlayText, myFont, Brushes.Black, new PointF(4, 6), myFormat);
            //    myCanvas.DrawString(sOverlayText, myFont, Brushes.Black, new PointF(6, 4), myFormat);
            //    myCanvas.DrawString(sOverlayText, myFont, Brushes.Gray, new PointF(5, 5), myFormat);
            //    myCanvas.Dispose();
            //}

            //Writing text overlayed image to disk and cleaning up
            myBitmap.Save(myPath, getType(type));
            myBitmap.Dispose();
            //Creating thumbnail and writing to disk


            if (iMaxTabletWidth > 0 && (oldWidth > iMaxTabletWidth))
            {
                newWidth = iMaxTabletWidth;
                newHeight = (int)(oldHeight / ((Double)oldWidth / newWidth));                
            }
            else {
                newWidth = oldWidth;
                newHeight = oldHeight;
            }

            Bitmap myThumb_table = new Bitmap(myImage, newWidth, newHeight);
            myThumb_table.Save(myThumbPathTable, getType(type));
            myThumb_table.Dispose();



            if (iMaxPhoneWidth > 0 && (oldWidth > iMaxPhoneWidth))
            {
                newWidth = iMaxPhoneWidth;
                newHeight = (int)(oldHeight / ((Double)oldWidth / newWidth));                
            }
            else {
                newWidth = oldWidth;
                newHeight = oldHeight;
            }

            Bitmap myThumb_phone = new Bitmap(myImage, newWidth, newHeight);
            myThumb_phone.Save(myThumbPathPhone, getType(type));
            myThumb_phone.Dispose();

            //Cleaning up parent image object
            myImage.Dispose();
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

        private ImageFormat getType(string type) {            
            switch (type) {
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