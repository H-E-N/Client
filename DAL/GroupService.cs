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
        public static int InsertGroup(Group group)
        {
            string sql = "Insert into Groups(GroupName,GroupPicture,GroupSignature,groups) values(@GroupName,@GroupPicture,@GroupSignature,@groups);select last_insert_rowid() ";
            SQLiteParameter[] paras ={
                                        new SQLiteParameter("@GroupName",DbType.String,20),
                                        new SQLiteParameter("@GroupPicture",DbType.Binary),
                                        new SQLiteParameter("@GroupSignature",DbType.String,100),
                                        new SQLiteParameter("@groups",DbType.Int32),
                                    };
            paras[0].Value = group.GroupName;
            paras[1].Value = group.GroupPicture;
            paras[2].Value = group.GroupSignature;
            paras[3].Value = group.Groups;
            DataTable dt= SqliteHelper.ExcuteDataTable(CommandType.Text, sql, paras);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            else return 0;
        }
        public static List<Group> GetGroups()
        {
            string sql = "select * from Groups";
            DataTable dt=SqliteHelper.ExcuteDataTable(CommandType.Text,sql,null);
            List<Group> grouplist=null;
            if(dt!=null&&dt.Rows.Count>0)
            {
                grouplist=new List<Group>();
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    grouplist.Add(EntryToGroup(dt.Rows[0]));
                }
            }
            return grouplist;
        }
        private static Group EntryToGroup(DataRow dr)
        {
            Group group = new Group();
            group.Id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
            group.GroupName = dr["GroupName"] != DBNull.Value ? dr["GroupName"].ToString() : "";
            group.GroupSignature = dr["GroupSignature"] != DBNull.Value ? dr["GroupSignature"].ToString() : "";
            group.GroupPicture = dr["GroupPicture"] as byte[];
            group.Groups = dr["Groups"] != DBNull.Value ? Convert.ToInt32(dr["Groups"]) : 0;
            return group;
        }
    }
}
