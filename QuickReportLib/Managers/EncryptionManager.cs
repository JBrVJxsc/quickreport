using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// 提供加密与解密服务。
    /// </summary>
    internal class EncryptionManager
    {
        public static readonly string IV = "SuFjcEmp/TE=";
        public static readonly string Key = "KIPSToILGp6fl+3gXJvMsN4IajizYBBT";

        /// <summary>
        /// 对字符串加密。
        /// </summary>
        /// <param name="text">需要加密的字符串。</param>
        /// <returns>加密后的字符串。</returns>
        public static string Encrypt(string text)
        {
            TripleDESCryptoServiceProvider provider = GetCryptoProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream,provider.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] toEncrypt = new UTF8Encoding().GetBytes(text);
            cStream.Write(toEncrypt, 0, toEncrypt.Length);
            cStream.FlushFinalBlock();
            byte[] ret = mStream.ToArray();
            cStream.Close();
            mStream.Close();
            return Convert.ToBase64String(ret);
        }

        /// <summary>
        /// 获取加密服务类。
        /// </summary>
        /// <returns>加密服务类。</returns>
        public static TripleDESCryptoServiceProvider GetCryptoProvider()
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.IV = Convert.FromBase64String(IV);
            provider.Key = Convert.FromBase64String(Key);
            return provider;
        }

        /// <summary>
        /// 对字符串解密。
        /// </summary>
        /// <param name="text">经过加密字符串。</param>
        /// <returns>解密后的字符串。</returns>
        public static string Decrypt(string text)
        {
            TripleDESCryptoServiceProvider provider = GetCryptoProvider();
            byte[] inputEquivalent = Convert.FromBase64String(text);
            MemoryStream msDecrypt = new MemoryStream();
            CryptoStream csDecrypt = new CryptoStream(msDecrypt,
            provider.CreateDecryptor(),
            CryptoStreamMode.Write);
            csDecrypt.Write(inputEquivalent, 0, inputEquivalent.Length);
            csDecrypt.FlushFinalBlock();
            csDecrypt.Close();
            return new UTF8Encoding().GetString(msDecrypt.ToArray());
        }
    }
}
