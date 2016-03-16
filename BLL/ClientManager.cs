using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    static public class ClientManager
    {
        /// <summary>
        /// 创建ChatLog表
        /// </summary>
        public static void CreateTableUsers()
        {
            ClientService.CreateTableUsers();
            if (ClientService.GetUsers() == null)
            {
                User user = new User();
                user.IP = Base.GetAddressIP();
                user.Name = "Administrator";
                user.Picture = "#";
                ClientService.InsertUser(user);
            }
        }
        /// <summary>
        /// 插入用户数据
        /// </summary>
        /// <param name="user"></param>
        public static void InsertUser(User user)
        {
            CreateTableUsers();
            ClientService.InsertUser(user);
        }
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUsers()
        {
            CreateTableUsers();
            return ClientService.GetUsers();
        }
    }
}
