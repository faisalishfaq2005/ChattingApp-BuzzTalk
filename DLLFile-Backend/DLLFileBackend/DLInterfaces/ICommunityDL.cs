using SecSemesterProjOOP.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.DLInterfaces
{
    public interface ICommunityDL
    {
        bool AddUserCommunity(User user,Community community);

        bool AddGroupsInCommunity(Group group, int communityId);
    }
}
