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
            string creatTable = "CREATE TABLE IF NOT EXISTS Users(id INTEGER PRIMARY KEY AUTOINCREMENT, IP varchar(20), Name varchar(20),Picture varchar(100));";//建表语句
            return SqliteHelper.ExecuteNonQuery(CommandType.Text, creatTable, null);
        }
        /// <summary>
        /// 插入用户数据
        /// </summary>
        /// <param name="user"></param>
        public static void InsertUser(User user)
        {
            string sql = "insert into Users(ip,name,picture) values(@ip,@name,@picture)";
            SQLiteParameter[] paras ={
                                        new SQLiteParameter("@ip",DbType.String,20),
                                        new SQLiteParameter("@name",DbType.String,20),
                                        new SQLiteParameter("@picture",DbType.String,100)
                                    };
            paras[0].Value = user.IP;
            paras[1].Value = user.Name;
            paras[2].Value = user.Picture;
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
        private static User EntryToUser(DataRow dr)
        {
            User user = new User();
            user.IP = dr["IP"] != DBNull.Value ? dr["IP"].ToString() : "";
            user.Name = dr["Name"] != DBNull.Value ? dr["Name"].ToString() : "Aministrator";
            user.Picture = dr["picture"] != DBNull.Value ? dr["picture"].ToString() : "#";
            return user;
        }
    }
}
