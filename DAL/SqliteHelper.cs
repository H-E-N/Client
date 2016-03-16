using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SqliteHelper
    {
        static string path = "Data Source=" + Environment.CurrentDirectory + "/test.db";

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="cmdType">语句类型</param>
        /// <param name="cmdText">数据库语句</param>
        /// <param name="cmdParams">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SQLiteParameter[] cmdParams)
        {
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    PrepareCommand(cmd, null, cmdType, cmdText, cmdParams);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 查询(一次)
        /// </summary>
        /// <param name="cmdType">语句类型</param>
        /// <param name="cmdText">数据库语句</param>
        /// <param name="cmdParams">参数</param>
        /// <returns></returns>
        public static DataTable ExcuteDataTable(CommandType cmdType, string cmdText, params SQLiteParameter[] cmdParams)
        {
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    PrepareCommand(cmd, null, cmdType, cmdText, cmdParams);
                    SQLiteDataAdapter adaper = new SQLiteDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    adaper.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
        /// <summary>
        /// 查询（连续）
        /// </summary>
        /// <param name="cmdType">语句类型</param>
        /// <param name="cmdText">数据库语句</param>
        /// <param name="cmdParams">参数</param>
        /// <returns></returns>
        public static SQLiteDataReader ExcuteDataReader(CommandType cmdType, string cmdText, params SQLiteParameter[] cmdParams)
        {
            SQLiteConnection conn = new SQLiteConnection(path);
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                PrepareCommand(cmd, null, cmdType, cmdText, cmdParams);
                SQLiteDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }
        /// <summary>
        /// cmd封装
        /// </summary>
        /// <param name="cmd">cmd</param>
        /// <param name="trans">事务</param>
        /// <param name="cmdType">类型</param>
        /// <param name="cmdText">语句</param>
        /// <param name="cmdParams">参数</param>
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteTransaction trans, CommandType cmdType, string cmdText, params SQLiteParameter[] cmdParams)
        {
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            if (cmdParams != null)
                cmd.Parameters.AddRange(cmdParams);
        }
    }
}
