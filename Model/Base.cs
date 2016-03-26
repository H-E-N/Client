using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
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
                    break;
                }
                else
                {
                    AddressIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
                }
            }
            return AddressIP;


            //获得局域网的IP地址
            //IPHostEntry ihe = Dns.GetHostByName(Dns.GetHostName());
            //IPAddress myIp = ihe.AddressList[0];
            //string loginIP = myIp.ToString();
            //return loginIP;

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
            //return message;
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


        #region 二进制序列化
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
        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <typeparam name="T">序列化的类型</typeparam>
        /// <param name="obj">序列化的对象</param>
        /// <param name="filename">序列化的XML文件名</param>
        public static void BinarySerializer<T>(T obj, string filename)
        {


            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, obj);
                }
                catch (SerializationException e)
                {
                    Trace.WriteLine(e);

                }
            }
        }

        /// <summary>
        /// 二进制反列化
        /// </summary>
        /// <typeparam name="T">反序列化的类型</typeparam>
        /// <param name="filename">反序列化的XML文件名</param>
        /// <returns>T类型对象</returns>
        public static T BinaryDeserialize<T>(string filename)
        {

            // 检查文件是否存在
            if (!File.Exists(filename))
            {
                return default(T);
            }
            T obj = default(T);
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    obj = (T)formatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    Trace.WriteLine(e);

                }
            }
            return obj;
        }
        #endregion
    }
    /// <summary>
    /// 工具类定义
    /// </summary>
    public class Tools
    {



        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path">目录名</param>
        public static void CreateDir(string path)
        {
            string[] dirs = path.Split(char.Parse("\\"));
            string tmp = "";
            if (!Directory.Exists(path))
            {
                foreach (string item in dirs)
                {
                    tmp += item + "\\";
                    if (!Directory.Exists(tmp))
                    {
                        Directory.CreateDirectory(tmp);
                    }
                }
            }
        }


    }
    /// <summary>
    /// 安全助手类定义
    /// </summary>
    public class SecurityHelper
    {
        /// <summary>
        /// 获取字符串的 MD5 值
        /// </summary>
        /// <param name="text">字符串</param>
        /// <returns>MD5 值</returns>
        public static string GetStringMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] encryptedBytes = md5.ComputeHash(Encoding.Default.GetBytes(text));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 实现对一个文件md5的读取，path为文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetMD5(string path)
        {
            try
            {
                using (Stream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return GetMD5(file);
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        /// <summary>
        /// 获取流的 MD5 值
        /// </summary>
        /// <param name="s">流</param>
        /// <returns>MD5 值</returns>
        public static string GetMD5(Stream s)
        {
            byte[] hash_byte;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                hash_byte = md5.ComputeHash(s);
            }
            return GetMD5String(hash_byte);
        }

        /// <summary>
        /// 获取数组的 MD5 值
        /// </summary>
        /// <param name="buffer">数组</param>
        /// <returns>MD5 值</returns>
        public static string GetMD5(byte[] buffer)
        {
            byte[] hash_byte;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                hash_byte = md5.ComputeHash(buffer);
            }
            return GetMD5String(hash_byte);
        }

        /// <summary>
        /// 获取数组的 MD5 值
        /// </summary>
        /// <param name="buffer">数组</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">长度</param>
        /// <returns>MD5 值</returns>
        public static string GetMD5(byte[] buffer, int offset, int count)
        {
            byte[] hash_byte;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                hash_byte = md5.ComputeHash(buffer, offset, count);
            }
            return GetMD5String(hash_byte);
        }

        /// <summary>
        /// 获取数组的 MD5 值
        /// </summary>
        /// <param name="hash_byte">数组</param>
        /// <returns>MD5 值</returns>
        private static string GetMD5String(byte[] hash_byte)
        {
            string resule = BitConverter.ToString(hash_byte);
            resule = resule.Replace("-", "");
            return resule;
        }
    }
}