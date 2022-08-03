using System;
using System.Security.Cryptography;
using System.Text;

namespace Tools
{
    public class MD5Encrypt
    {
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string StartEncrypy(string str)
        {
            StringBuilder sb = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
                byte[] md5Bytes = md5.ComputeHash(bytes);
                for (int i = 0; i < md5Bytes.Length; i++)
                {
                    sb.Append(md5Bytes[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }
    }
}
