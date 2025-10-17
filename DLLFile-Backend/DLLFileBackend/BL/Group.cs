using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.BL
{
    public class Group
    {
        private string Name;
        private string Description;
        private string GroupAdmin;
        private bool AdminOnlyMessageSettings=false;
        private List<User> GroupMembers = new List<User>();
        // figure out and conform that these contacts are from that user only.
        private List<Message> GroupMessages = new List<Message>(); //in this we are ceating list of parent class message and will be storing the objects of child classs

        public Group() { }

        public Group(string name, string description, string groupAdmin)
        {
            Name = name;
            Description = description;
            GroupAdmin = groupAdmin;
        }
        public Group(string name, string description, string groupAdmin,List<User> groupMembers)
        {
            Name = name;
            Description = description;
            GroupAdmin = groupAdmin;
            GroupMembers = groupMembers;
        }
        public Group(string name, string description, string groupAdmin,bool adminOnlyMessageSettings, List<User> groupMembers,List<Message> groupMessages)
        {
            Name = name;
            Description = description;
            GroupAdmin = groupAdmin;
            AdminOnlyMessageSettings = adminOnlyMessageSettings;
            GroupMembers = groupMembers;
            GroupMessages = groupMessages;
        }

        public string GetGroupName()
        {
            return Name;
        }
        public string GetDescription()
        {
            return Description;
        }
        public string GetGroupAdmin()
        {
            return GroupAdmin;
        }
        public  List<Message> GetGroupMessages()
        {
            return GroupMessages;
        }

        public bool GetAdminOnlyMessageSettings()
        {
            return AdminOnlyMessageSettings;
        }
        public List<User> GetGroupMembers() 
        {
            return GroupMembers;
        }


        public void SetAdminOnlyMessageSettings(bool decesion)
        {
            AdminOnlyMessageSettings = decesion;
        }

        public void AddMessage(Message message)
        {
            GroupMessages.Add(message);
        }

        public void ClearChat()
        {


        }
        public void AddMember(User Member)
        {
            GroupMembers.Add(Member);
        }
        public void AllowOnlyAdminsToSendMessages()
        {

        }
        public void AllowAllGroupMemebersToSendMessages()
        {

        }


    }

    
}
