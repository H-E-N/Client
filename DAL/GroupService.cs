using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class GroupService
    {
        public static int CreateGroup()
        {
            string creatTable = "CREATE TABLE IF NOT EXISTS Groups(id INTEGER PRIMARY KEY AUTOINCREMENT, GroupName varchar(20), GroupPicture Blob, GroupSignature varchar(100),Groups int);";//建表语句
            return SqliteHelper.ExecuteNonQuery(CommandType.Text, creatTable, null);
        }
        public static void InsertGroup(Group group)
        {
            string sql = "Insert into Groups(GroupName,GroupPicture,GroupSignature,groups) values(@GroupName,@GroupPicture,@GroupSignature,@groups)";
            SQLiteParameter[] paras ={
                                        new SQLiteParameter("@GroupName",DbType.String,20),
                                        new SQLiteParameter("@GroupPicture",DbType.Binary),
                                        new SQLiteParameter("@GroupSignature",DbType.String,100),
                                        new SQLiteParameter("@groups",DbType.Int32),
                                    };
            paras[0].Value = group.GroupName;
            paras[1].Value = group.RoupPicture;
            paras[2].Value = group.GroupSignaure;
            paras[3].Value = group.Groups;
            SqliteHelper.ExecuteNonQuery(CommandType.Text, sql, paras);
        }
    }
}
