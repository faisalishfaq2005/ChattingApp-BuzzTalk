using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SecSemesterProjOOP.BL
{
    public class User
    {
        private string UserName;
        private string UserEmail;
        private string UserPassword;
        private string PhoneNumber;
        private List<Group> UserGroups;
        private List<IndividualContact> UserContacts;
        private List<Community> UserCommunities=new List<Community>();
        private List<Channels> ChannelsList=new List<Channels>();
        


        public User(string UserName,string UserEmail,string UserPassword,string PhoneNumber, List<Group> userGroups, List<IndividualContact> contacts,List<Community> userCommunities,List<Channels> channels)
        {
            this.UserName = UserName;
            this.UserEmail = UserEmail;
            this.UserPassword = UserPassword;
            this.PhoneNumber = PhoneNumber;
            UserGroups = userGroups;
            UserContacts =contacts;
            UserCommunities = userCommunities;
            ChannelsList=channels;


        }
        public User(string UserName, string UserEmail, string UserPassword, string PhoneNumber)
        {
            this.UserName = UserName;
            this.UserEmail = UserEmail;
            this.UserPassword = UserPassword;
            this.PhoneNumber = PhoneNumber;
            UserGroups = new List<Group>();
            UserContacts = new List<IndividualContact>();


        }
        public User(string UserEmail, string UserPassword)
        {
            this.UserEmail = UserEmail;
            this.UserPassword = UserPassword;
            UserGroups = new List<Group>();
            UserContacts = new List<IndividualContact>();
        }
        public User(string UserName,string UserEmail, string PhoneNumber)
        {
            this.UserName = UserName;
            this.UserEmail = UserEmail;
            this.PhoneNumber = PhoneNumber;
            UserGroups = new List<Group>();
            UserContacts = new List<IndividualContact>();

        }

        


        public string GetUserEmail()
        {
            return UserEmail;

        }

        public string GetUserPhone()
        {
            return PhoneNumber;

        }
        public string GetUserPassword()
        {
            return UserPassword;

        }
        public string GetUserName()
        {
            return UserName;

        }
        public List<IndividualContact> GetUserContacts()
        {
            return UserContacts;

        }
        public List<Group> GetUserUserGroups()
        {
            return UserGroups;
        }
        public List<Channels> GetChannels()
        {
            return ChannelsList;
        }
        public List<Community> GetUserCommunities()
        {
            return UserCommunities;
        }
        public void SetUserName(string username)
        {
            UserName=username;

        }

        public void AddGroupInUserGroups(Group group)
        {
            UserGroups.Add(group);
        }
        public void AddCommunityInUserCommunities(Community community)
        {
            UserCommunities.Add(community);
        }

        public void CreateGroup()
        {

        }


        public void AddUsersInGroup()
        {
            

        }

        public bool SearchUserInUserContacts(User u)
        {
            bool check=false;
            foreach (IndividualContact c in UserContacts)
            {
                User user = c.GetUserContact();
                if (user.GetUserName() == u.GetUserName())
                {
                    check=true ;
                }

            }
            return check;
        }

       
        public void ExitGroup()
        {

        }

        public void AddContactInUserContacts(User user)
        {
            
            IndividualContact IDCont = new IndividualContact(user);
            UserContacts.Add(IDCont);
        }
        
        
    }
}
