using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace WongTung.Common
{
    /// <summary>
    /// MD5密码构造器
    /// </summary>
    public static class PasswordBuilder
    {
        private const int START = 8;
        private const int LENGTH = 16;

        /// <summary>
        /// 构造MD5密码
        /// </summary>
        /// <param name="password">明文</param>
        /// <returns>经过MD5加密后的密码</returns>
        public static string BuildPassword(string password)
        {
            //空密码返回空
            if (string.IsNullOrEmpty(password))
                return password;

            //构造MD5
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5Provider.ComputeHash(Encoding.Default.GetBytes(password))).Replace("-", "").ToLower().Substring(START, LENGTH);
        }
    }
}
