using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    static public class ClientService
    {
        /// <summary>
        /// 创建用户表
        /// </summary>
        public static int CreateTableUsers()
        {
            string creatTable = "CREATE TABLE IF NOT EXISTS Users(id INTEGER PRIMARY KEY AUTOINCREMENT, IP varchar(20), Name varchar(20), Picture Blob, Signature varchar(100));";//建表语句
            return SqliteHelper.ExecuteNonQuery(CommandType.Text, creatTable, null);
        }
        /// <summary>
        /// 插入用户数据
        /// </summary>
        /// <param name="user"></param>
        public static void InsertUser(User user)
        {
            string sql = "insert into Users(ip,name,picture,signature) values(@ip,@name,@picture,@signature)";
            SQLiteParameter[] paras ={
                                        new SQLiteParameter("@ip",DbType.String,20),
                                        new SQLiteParameter("@name",DbType.String,20),
                                        new SQLiteParameter("@picture",DbType.Binary),
                                        new SQLiteParameter("@signature",DbType.String,100)
                                    };
            paras[0].Value = user.IP;
            paras[1].Value = user.Name;
            paras[2].Value = user.Picture;
            paras[3].Value = user.Signature;
            SqliteHelper.ExecuteNonQuery(CommandType.Text, sql, paras);
        }
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUsers()
        {
            string sql = "select * from Users";
            DataTable dt = null;
            dt = SqliteHelper.ExcuteDataTable(CommandType.Text, sql, null);
            List<User> userslist = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                userslist = new List<User>();
                for (int i = 0; i < dt.Rows.Count; i++)
                    userslist.Add(EntryToUser(dt.Rows[i]));
            }
            return userslist;
        }
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static User GetUserByIP(string ip)
        {
            string sql = "select * from Users where IP=@ip";
            SQLiteParameter[] param = { new SQLiteParameter("@ip", DbType.String, 20) };
            param[0].Value = ip;
            DataTable dt = null;
            User user = null;
            dt = SqliteHelper.ExcuteDataTable(CommandType.Text, sql, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                user = EntryToUser(dt.Rows[0]);
            }
            return user;
        }
        /// <summary>
        /// 由ip得出名字
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetUserName(string ip)
        {
            string sql = "select Name from Users where IP=@ip";
            SQLiteParameter[] param = { new SQLiteParameter("@ip", DbType.String, 20) };
            param[0].Value = ip;
            string name = SqliteHelper.ExcuteScalar(CommandType.Text, sql, param).ToString();
            return name;
        }
        public static void UpdateUser(User user)
        {
            string sql = "update Users set Name=@Name,Signature=@Signature,Picture=@Picture where IP=@IP";
            SQLiteParameter[] param ={
                                        new SQLiteParameter("@IP",DbType.String,20),
                                        new SQLiteParameter("@Name",DbType.String,20),
                                        new SQLiteParameter("@Signature",DbType.String,100),
                                        new SQLiteParameter("@Picture",DbType.Binary)
                                     };
            param[0].Value = user.IP;
            param[1].Value = user.Name;
            param[2].Value = user.Signature;
            param[3].Value = user.Picture;
            SqliteHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
        private static User EntryToUser(DataRow dr)
        {
            User user = new User();
            user.IP = dr["IP"] != DBNull.Value ? dr["IP"].ToString() : "";
            user.Name = dr["Name"] != DBNull.Value ? dr["Name"].ToString() : "Aministrator";
            user.Picture = dr["picture"] as byte[];
            user.Signature = dr["signature"] != DBNull.Value ? dr["signature"].ToString() : "";
            return user;
        }
    }
}
