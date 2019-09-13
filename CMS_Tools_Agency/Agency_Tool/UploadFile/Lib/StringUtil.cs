using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UploadFile.Lib
{
    public class StringUtil
    {
        private static readonly string[] VietnameseSigns = new string[]
         {
          "aAeEoOuUiIdDyY",
          "áàạảãâấầậẩẫăắằặẳẵ",
          "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
          "éèẹẻẽêếềệểễ",
          "ÉÈẸẺẼÊẾỀỆỂỄ",
          "óòọỏõôốồộổỗơớờợởỡ",
          "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
          "úùụủũưứừựửữ",
          "ÚÙỤỦŨƯỨỪỰỬỮ",
          "íìịỉĩ",
          "ÍÌỊỈĨ",
          "đ",
          "Đ",
          "ýỳỵỷỹ",
          "ÝỲỴỶỸ"
         };

        public static string RemoveSign4VietnameseString(string str)
        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        public static string SEOUrl(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            string strTitle = StringUtil.RemoveSign4VietnameseString(str);

            #region Generate SEO Friendly URL based on Title
            //Trim Start and End Spaces.
            strTitle = strTitle.Trim();

            //Trim "-" Hyphen
            strTitle = strTitle.Trim('-');

            strTitle = strTitle.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            strTitle = strTitle.Replace("c#", "C-Sharp");
            strTitle = strTitle.Replace("vb.net", "VB-Net");
            strTitle = strTitle.Replace("asp.net", "Asp-Net");

            //Replace . with - hyphen
            strTitle = strTitle.Replace(".", "-");

            //Replace Special-Characters
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                {
                    strTitle = strTitle.Replace(strChar, string.Empty);
                }
            }

            //Replace all spaces with one "-" hyphen
            strTitle = strTitle.Replace(" ", "-");

            //Replace multiple "-" hyphen with single "-" hyphen.
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");

            //Run the code again...
            //Trim Start and End Spaces.
            strTitle = strTitle.Trim();

            //Trim "-" Hyphen
            strTitle = strTitle.Trim('-');
            #endregion
            return strTitle.ToLower();
        }
    }
}