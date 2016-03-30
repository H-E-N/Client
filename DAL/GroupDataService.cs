using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GroupDataService
    {
        public static int CreateGroupData()
        {
            string creatTable = "CREATE TABLE IF NOT EXISTS GroupData(id INTEGER PRIMARY KEY AUTOINCREMENT, GroupID varchar(20), SenderIP varchar(20), Data varchar(1000));";//建表语句
            return SqliteHelper.ExecuteNonQuery(CommandType.Text, creatTable, null);
        }
        public static void InsertGroup(GroupData groupData)
        {
            string sql = "Insert into GroupData(GroupID,SenderIP,Data) values(@GroupID,@SenderIP,@Data)";
            SQLiteParameter[] paras ={
                                        new SQLiteParameter("@GroupID",DbType.Int32),
                                        new SQLiteParameter("@SenderIP",DbType.String,20),
                                        new SQLiteParameter("@Data",DbType.String,1000),
                                    };
            paras[0].Value = groupData.GroupID;
            paras[1].Value = groupData.SenderIP;
            paras[2].Value = groupData.Data;
            SqliteHelper.ExecuteNonQuery(CommandType.Text, sql, paras);
        }
    }
}
