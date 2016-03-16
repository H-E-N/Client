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
    static public class ChatLogService
    {
        /// <summary>
        /// 创建ChatLog表
        /// </summary>
        public static void CreatTableChatLog()
        {
            string creatTable = "CREATE TABLE IF NOT EXISTS ChatLog(id INTEGER PRIMARY KEY AUTOINCREMENT, Sender varchar(20), Receiver varchar(20),Time varchar(20),Data varchar(100));";//建表语句
            SqliteHelper.ExecuteNonQuery(CommandType.Text, creatTable, null);
        }
        /// <summary>
        /// 保存数据到数据库
        /// </summary>
        /// <param name="chatlog"></param>
        public static void InsertChatLog(ChatLog chatlog)
        {
            CreatTableChatLog();
            string sql = "INSERT INTO ChatLog(sender,receiver,time,data) values(@sender,@receiver,@time,@data)";
            SQLiteParameter[] paras ={
                                        new SQLiteParameter("@sender",DbType.String,20),
                                        new SQLiteParameter("@receiver",DbType.String,20),
                                        new SQLiteParameter("@time",DbType.String,20),
                                        new SQLiteParameter("@data",DbType.String,100)
                                    };
            paras[0].Value = chatlog.Sender;
            paras[1].Value = chatlog.Receiver;
            paras[2].Value = chatlog.Time;
            paras[3].Value = chatlog.Data;
            SqliteHelper.ExecuteNonQuery(CommandType.Text, sql, paras);
        }
        /// <summary>
        /// 获取对话信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<ChatLog> GetChatlog(string sender, string receiver, ref int id)
        {
            CreatTableChatLog();
            string sql = String.Format("SELECT * FROM ChatLog where ((sender = '{0}' and receiver ='{1}') or (sender = '{1}' and receiver ='{0}')) and id > {2}", sender, receiver, id);
            DataTable dt = null;
            dt = SqliteHelper.ExcuteDataTable(CommandType.Text, sql, null);
            List<ChatLog> chatloglist = new List<ChatLog>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chatloglist.Add(EntryToChatLog(dt.Rows[i]));
                }
                id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["id"]);
            }
            return chatloglist;
        }
        public static List<ChatLog> GetChatlogs(string sender, string receiver, ref int id)
        {
            CreatTableChatLog();
            string sql = String.Format("SELECT * FROM ChatLog where ((sender = '{0}' and receiver ='{1}') or (sender = '{1}' and receiver ='{0}')) and id > {2}", sender, receiver, id);
            SQLiteDataReader dr = null;
            dr = SqliteHelper.ExcuteDataReader(CommandType.Text, sql, null);
            List<ChatLog> chatloglist = new List<ChatLog>();
            while (dr.Read())
            {
                chatloglist.Add(EntryToChatLog(dr));
            }
            return chatloglist;
        }
        private static ChatLog EntryToChatLog(IDataRecord dr)
        {
            ChatLog chat = new ChatLog();
            chat.Sender = dr["sender"] != DBNull.Value ? dr["sender"].ToString() : "";
            chat.Receiver = dr["receiver"] != DBNull.Value ? dr["receiver"].ToString() : "";
            chat.Time = dr["time"] != DBNull.Value ? dr["time"].ToString() : "";
            chat.Data = dr["data"] != DBNull.Value ? dr["data"].ToString() : "";
            return chat;
        }
        private static ChatLog EntryToChatLog(DataRow dr)
        {
            ChatLog chat = new ChatLog();
            chat.Sender = dr["sender"] != DBNull.Value ? dr["sender"].ToString() : "";
            chat.Receiver = dr["receiver"] != DBNull.Value ? dr["receiver"].ToString() : "";
            chat.Time = dr["time"] != DBNull.Value ? dr["time"].ToString() : "";
            chat.Data = dr["data"] != DBNull.Value ? dr["data"].ToString() : "";
            return chat;
        }
    }
}
