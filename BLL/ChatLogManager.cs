using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    static public class ChatLogManager
    {
        /// <summary>
        /// 创建用户表
        /// </summary>
        public static void CreatTableChatLog()
        {
            ChatLogService.CreatTableChatLog();
        }
        /// <summary>
        /// 保存数据到数据库
        /// </summary>
        /// <param name="chatlog"></param>
        public static void InsertChatLog(ChatLog chatlog)
        {
            ChatLogService.InsertChatLog(chatlog);
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
            return ChatLogService.GetChatlog(sender, receiver, ref id);
        }
    }
}
