using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace CMS_Tools.Apis
{
    /// <summary>
    /// Summary description for Captcha
    /// </summary>
    public class Captcha : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Session["captcha"] = Guid.NewGuid().ToString().Substring(0, 6);
            MemoryStream memStream = new MemoryStream();
            string phrase = context.Session["captcha"].ToString();

            //Generate an image from the text stored in session
            Bitmap imgCapthca = GenerateImage(80, 40, phrase);
            imgCapthca.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imgBytes = memStream.GetBuffer();

            imgCapthca.Dispose();
            memStream.Close();

            //Write the image as response, so it can be displayed
            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(imgBytes);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public Bitmap GenerateImage(int Width, int Height, string Phrase)
        {
            Bitmap CaptchaImg = new Bitmap(Width, Height);
            Random Randomizer = new Random();
            Graphics Graphic = Graphics.FromImage(CaptchaImg);
            Graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Graphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //Set height and width of captcha image
            Graphic.FillRectangle(new SolidBrush(Color.FromArgb(220, 213, 161)), 0, 0, Width, Height);
            //Rotate text a little bit
            Graphic.RotateTransform(-3);
            Graphic.DrawString(Phrase, new Font("Tahama", 14),
                new SolidBrush(Color.Black), 7, 10);
            Graphic.Flush();
            return CaptchaImg;
        }

        //public string randomString()
        //{
        //    Random random = new Random((int)DateTime.Now.Ticks);
        //    StringBuilder builder = new StringBuilder();
        //    for (int i = 0; i < 13; i++)
        //    {
        //        builder.Append(Convert.ToChar(
        //                Convert.ToInt32(Math.Floor(
        //                        26 * random.NextDouble() + 65))));
        //    }
        //    return builder.ToString();
        //}
    }
}