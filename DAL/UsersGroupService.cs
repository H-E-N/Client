using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class UsersGroupService
    {
        /// <summary>
        /// 创建分组表
        /// </summary>
        /// <returns></returns>
        public static int CreateUsersGroup()
        {
            string creatTable = "CREATE TABLE IF NOT EXISTS UsersGroup(id INTEGER PRIMARY KEY AUTOINCREMENT, GroupName varchar(20));";//建表语句
            return SqliteHelper.ExecuteNonQuery(CommandType.Text, creatTable, null);
        }
        /// <summary>
        /// 判断分组是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetIDByUsersGroupName(string name)
        {
            string sql = "select Count(*) from UsersGroup where GroupName=@GroupName";
            SQLiteParameter[] param = { new SQLiteParameter("@GroupName", DbType.String, 20) };
            param[0].Value = name;
            if (Convert.ToInt32(SqliteHelper.ExcuteScalar(CommandType.Text, sql, param)) > 0)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 添加分组
        /// </summary>
        /// <param name="ug"></param>
        public static void InsertUsersGroup(UsersGroup ug)
        {
            string sql = "insert into UsersGroup(GroupName) values(@GroupName)";
            SQLiteParameter[] param = { new SQLiteParameter("@GroupName", DbType.String, 20) };
            param[0].Value = ug.GroupName;
            SqliteHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
        /// <summary>
        /// 获取分组
        /// </summary>
        /// <returns></returns>
        public static List<UsersGroup> GetUsersGroup()
        {
            string sql = "select * from UsersGroup";
            List<UsersGroup> usersGrouplist = null;
            DataTable dt = SqliteHelper.ExcuteDataTable(CommandType.Text, sql, null);
            if(dt!=null&&dt.Rows.Count>0)
            {
                usersGrouplist = new List<UsersGroup>();
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    usersGrouplist.Add(EntryToUsersGroup(dt.Rows[i]));
                }
            }
            return usersGrouplist;
        }
        private static UsersGroup EntryToUsersGroup(DataRow dr)
        {
            UsersGroup ug = new UsersGroup();
            ug.Id = Convert.ToInt32(dr["id"]);
            ug.GroupName = dr["GroupName"].ToString();
            return ug;
        }
    }
}
