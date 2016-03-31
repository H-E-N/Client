using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GroupManager
    {
        /// <summary>
        /// 创建群表
        /// </summary>
        public GroupManager()
        {
            GroupService.CreateGroup();
            GroupAndUserService.CreateGroupAndUser();
            GroupDataService.CreateGroupData();
        }
        public void InsertGroup(Group group,List<string>IPlist)
        {
            int id = GroupService.InsertGroup(group);
            if(IPlist.Count>0)
            {
                IPlist.Add(Base.GetAddressIP());
                GroupAndUser groupAndUser=new GroupAndUser();
                groupAndUser.GroupID=id;
                foreach(string ip in IPlist)
                {
                    groupAndUser.UserIP=ip;
                    GroupAndUserService.InsertGroupAndUser(groupAndUser);
                }
            }
        }
        public List<Group> GetGroups()
        {
            return GroupService.GetGroups();
        }

    }
}
