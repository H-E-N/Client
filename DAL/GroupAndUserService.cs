using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DAL
{
     public class GroupAndUserService
    {
        public static int CreateGroupAndUser()
        {
            string creatTable = "CREATE TABLE IF NOT EXISTS GroupAndUser(id INTEGER PRIMARY KEY AUTOINCREMENT, GroupID int, UserIP varchar(20));";//建表语句
            return SqliteHelper.ExecuteNonQuery(CommandType.Text, creatTable, null);
        }
        public static void InsertGroupAndUser(GroupAndUser groupAndUser)
        {
            string sql = "Insert into GroupAndUser(GroupID,UserIP) values(@GroupID,@UserIP)";
            SQLiteParameter[] paras ={
                                        new SQLiteParameter("@GroupID",DbType.Int32),
                                        new SQLiteParameter("@UserIP",DbType.String,20),
                                    };
            paras[0].Value = groupAndUser.GroupID;
            paras[1].Value = groupAndUser.UserIP;
            SqliteHelper.ExecuteNonQuery(CommandType.Text, sql, paras);
        }
    }
}
