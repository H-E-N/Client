using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    static public class Base
    {

        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        public static string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
        //特殊字符
        private static string[] SpecificSymbol = { "ξ∮┮¤≡" };
        private static string CrypticKey = @")sf,<xy'>9D+f-3v";//#'[H{EN$1a}(zA~?)sf,<xy'>9D+f-3v
        private static string CrypticIV = @"q-9f+48\";//v5~h'#[1ds&^}]{'!(~x1)pl
        /// <summary>
        /// 拆箱加密
        /// </summary>
        /// <returns></returns>
        public static string Encryption(ChatLog chatlog)
        {
            string message = chatlog.Sender + SpecificSymbol[0] + chatlog.Receiver + SpecificSymbol[0] + chatlog.Time + SpecificSymbol[0] + chatlog.Data;
            //return DESEncryption(message);
            return AESEncryption(message);
        }

        /// <summary>
        /// 封装解密
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ChatLog Decryption(string message)
        {
            //message = DESDecryption(message);
            message = AESDecryption(message);
            ChatLog chatlog = new ChatLog();
            if (message != null)
            {
                string[] arraystr = message.Split(SpecificSymbol, StringSplitOptions.RemoveEmptyEntries);
                chatlog.Sender = arraystr[0];
                chatlog.Receiver = arraystr[1];
                chatlog.Time = arraystr[2];
                chatlog.Data = arraystr[3];
            }
            else { }
            return chatlog;
        }

        #region AES加密解密
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string AESEncryption(string message)
        {
            Rijndael aes = Rijndael.Create();
            byte[] key = Encoding.Unicode.GetBytes(CrypticKey);
            byte[] IV = Encoding.Unicode.GetBytes(CrypticIV);
            byte[] data = Encoding.Unicode.GetBytes(message);
            message = null;
            try
            {

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(key, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                        message = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();
            return message;
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string AESDecryption(string message)
        {
            Rijndael aes = Rijndael.Create();
            byte[] key = Encoding.Unicode.GetBytes(CrypticKey);
            byte[] IV = Encoding.Unicode.GetBytes(CrypticIV);
            byte[] data = Convert.FromBase64String(message);
            message = null;
            try
            {
                using (MemoryStream ms = new MemoryStream())//存储解密后的数据
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(key, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);//进行解密
                        cs.FlushFinalBlock();
                        message = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();
            return message;
        }
        #endregion
        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="o">对象</param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T o)
        {
            byte[] bytes = null;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, o);
                    bytes = ms.ToArray();
                }
            }
            catch { }
            return bytes;
        }
        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="bytes">二进制数据</param>
        /// <returns></returns>
        public static T DeSerialize<T>(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (T)bf.Deserialize(ms);
                }
            }
            catch { }
            return default(T);
        }
    }
}
