﻿using System.Security.Cryptography;
using System.Text;

namespace Education.Areas.Admin.Utilz
{
    public class Encryption
    {
        public static string GetMD5Hash(string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MD5 md5Hasher = MD5.Create();
                    byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    return sBuilder.ToString();
                }
                return "";
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }
    }
}