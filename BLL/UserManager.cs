using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BLL
{
    public class UserManager
    {
        public UserManager()
        {
            CreateGroupUsers();
            CreateTableUsers();
        }
        /// <summary>
        /// 创建Users表
        /// </summary>
        private void CreateTableUsers()
        {
            UserService.CreateTableUsers();
            if (UserService.GetUserByIP(Base.GetAddressIP()) == null)
            {
                User user = new User();
                user.IP = Base.GetAddressIP();
                user.Name = "Administrator";
                Image img = Image.FromFile("head/4.png");
                user.Picture = Base.ChangeToBytes(img);
                user.Signature = " ";
                user.Group = 0;
                UserService.InsertUser(user);
            }
        }
        /// <summary>
        /// 创建联系人分组表
        /// </summary>
        private void CreateGroupUsers()
        {
            UsersGroupService.CreateUsersGroup();
            UsersGroup ug = new UsersGroup();
            ug.GroupName = "我的好友";
            if (!UsersGroupService.GetIDByUsersGroupName(ug.GroupName))
            {
                UsersGroupService.InsertUsersGroup(ug);
            }
        }
        /// <summary>
        /// 通过IP获取用户信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public User GetUserByIP(string ip)
        {
            CreateGroupUsers();
            CreateTableUsers();
            return UserService.GetUserByIP(ip);
        }
        /// <summary>
        /// 更新个人资料
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            UserService.UpdateUser(user);
        }
        public List<User> GetUsers()
        {
            return UserService.GetUsers();
        }
    }
}
