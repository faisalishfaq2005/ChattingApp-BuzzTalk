using SecSemesterProjOOP.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.DLInterfaces
{
    public interface IGroupDL
    {
        bool UpdateGroupInUserGroups(Group group);
        bool UpdateGroupMembers(User user, Group group);

        bool UpdateAdminOnlyManageSettings(Group group);

        List<Group> RetrievingDataForUserGroupsList(User user);

        List<Message> RetrieveGroupsMessages(int GroupId);

        List<User> RetreiveGroupMembers(int GroupId);

        List<Community> RetreiveDataForUserCommunitiesList(User user);

        Group RetrievingDataForCommunitiesGroups(int groupId);
    }
}
