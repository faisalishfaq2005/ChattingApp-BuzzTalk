using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.BL
{
    public class Community
    {
        
        private string Name;
        private List<Group> GroupsInCommunity=new List<Group>();

        public Community(string name,List<Group> groups) 
        {
            Name = name;
            GroupsInCommunity=groups;

        }

        public string GetCommunityName()
        {
            return Name;

        }
        public List<Group> GetGroupsInCommunity()
        {
            return GroupsInCommunity;
        }
    }
    
}
