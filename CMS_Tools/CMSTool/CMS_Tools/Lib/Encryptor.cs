using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace CMS_Tools.Lib
{
    public static class Encryptor
    {
        public static string GeneralSignature(List<string> param)
        {
            return GetMd5Hash(Constants.KEY_SERVER + "#" + string.Join(":", param) + "#" + Constants.KEY_SERVER, true);
        }

        public static string GeneralSignature(string key, List<string> param)
        {
            return GetMd5Hash(key + "#" + string.Join(":", param) + "#" + key, true);
        }

        public static string GetMd5Hash(string input, bool utf8 = false)
        {
            if (!utf8)
            {
                MD5 md5Hash = MD5.Create();
                byte[] data = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(input)); //md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    string hexValue = data[i].ToString("X").ToLower();
                    sBuilder.Append((hexValue.Length == 1 ? "0" : "") + hexValue);

                }
                return sBuilder.ToString();
            }
            else
            {
                MD5 md5 = new MD5CryptoServiceProvider();

                //compute hash from the bytes of text
                md5.ComputeHash(ASCIIEncoding.UTF8.GetBytes(input));

                //get hash result after compute it
                byte[] result = md5.Hash;

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    //change it into 2 hexadecimal digits
                    //for each byte
                    strBuilder.Append(result[i].ToString("x2"));
                }
                return strBuilder.ToString();
            }
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        public static string MD5HashUTF8(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.UTF8.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }      

        public static string EncryptString(string InputText, string key)
        {
            try
            {
                //RijndaelManaged RijndaelCipher = new RijndaelManaged();
                //byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
                //byte[] Salt = Encoding.ASCII.GetBytes(key.Length.ToString());
                //PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(key, Salt);
                //ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
                //MemoryStream memoryStream = new MemoryStream();
                //CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
                //cryptoStream.Write(PlainText, 0, PlainText.Length);
                //cryptoStream.FlushFinalBlock();
                //byte[] CipherBytes = memoryStream.ToArray();
                //memoryStream.Close();
                //cryptoStream.Close();
                //string EncryptedData = Convert.ToBase64String(CipherBytes);
                //return EncryptedData;
                var plainBytes = Encoding.UTF8.GetBytes(InputText);
                return Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(key)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string DecryptString(string InputText, string key)
        {
            try
            {
                if (string.IsNullOrEmpty(InputText))
                    return "";
                //RijndaelManaged RijndaelCipher = new RijndaelManaged();
                //byte[] EncryptedData = Convert.FromBase64String(InputText);
                //byte[] Salt = Encoding.ASCII.GetBytes(key.Length.ToString());
                //PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(key, Salt);
                //ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
                //MemoryStream memoryStream = new MemoryStream(EncryptedData);
                //CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                //byte[] PlainText = new byte[EncryptedData.Length];
                //int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                //memoryStream.Close();
                //cryptoStream.Close();
                //string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
                //return DecryptedData;
                var encryptedBytes = Convert.FromBase64String(InputText.Replace(" ", "+").Replace("-", "+").Replace("_", "/"));
                return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(key)));
            }
            catch (Exception)
            {
                return "";
                //throw new Exception(ex.Message);
            }
        }

        public static RijndaelManaged GetRijndaelManaged(String secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };
        }

        public static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        public static byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}