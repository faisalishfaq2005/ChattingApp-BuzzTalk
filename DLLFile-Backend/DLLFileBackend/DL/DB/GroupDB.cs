using SecSemesterProjOOP.BL;
using SecSemesterProjOOP.DLInterfaces;
using SecSemesterProjOOP.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.DL.DB
{
    public class GroupDB : IGroupDL
    {
        public bool UpdateGroupInUserGroups(Group group)
        {

            bool fcheck = false;
            string connectionString = Utilities.GetConnectionString();
            SqlConnection connection1 = Utilities.GetSqlConnection(connectionString);
            connection1.Open();
            string query1 = String.Format("insert into [Group] (Name,Description,GroupAdmin,AdminOnlyMessageSettings) VALUES('{0}','{1}','{2}',{3})", group.GetGroupName(), group.GetDescription(), group.GetGroupAdmin(), group.GetAdminOnlyMessageSettings() ? 1 : 0);
            SqlCommand command2 = new SqlCommand(query1, connection1);
            int rowsAffected1 = command2.ExecuteNonQuery();
            if (rowsAffected1 > 0)
            {
                fcheck = true;
            }
            connection1.Close();

            return fcheck;

        }

        public bool UpdateGroupMembers(User user, Group group)
        {
            bool check = false;
            string connectionString = Utilities.GetConnectionString();
            SqlConnection connection = Utilities.GetSqlConnection(connectionString);
            SqlConnection connection1 = Utilities.GetSqlConnection(connectionString);
            SqlConnection connection2 = Utilities.GetSqlConnection(connectionString);
            connection.Open();
            connection1.Open();
            connection2.Open();
            string searchQuery1 = String.Format("Select UserId from [User] where UserName = '{0}'", user.GetUserName());
            SqlCommand command1 = new SqlCommand(searchQuery1, connection);
            SqlDataReader data1 = command1.ExecuteReader();
            if (data1.Read())
            {
                string searchQuery2 = String.Format("Select GroupId from [Group] where Name = '{0}'", group.GetGroupName());
                SqlCommand command2 = new SqlCommand(searchQuery2, connection1);
                SqlDataReader data2 = command2.ExecuteReader();
                if (data2.Read())
                {
                    string query2 = String.Format("insert into [GroupMembers] (UserId,GroupId) VALUES({0},{1})", data1.GetInt32(0), data2.GetInt32(0));
                    SqlCommand command3 = new SqlCommand(query2, connection2);
                    int rowsAffected1 = command3.ExecuteNonQuery();
                    if (rowsAffected1 > 0)
                    {
                        check = true;
                    }
                }

            }
            connection.Close();
            connection1.Close();
            connection2.Close();
            return check;


        }

        public bool UpdateAdminOnlyManageSettings(Group group)
        {
            bool check = false;
            string connectionString = Utilities.GetConnectionString();
            SqlConnection connection1 = Utilities.GetSqlConnection(connectionString);
            SqlConnection connection2 = Utilities.GetSqlConnection(connectionString);
            connection1.Open();
            connection2.Open();
            string searchQuery1 = String.Format("Select GroupId from [Group] where Name = '{0}'", group.GetGroupName());
            SqlCommand command1 = new SqlCommand(searchQuery1, connection1);
            SqlDataReader data1 = command1.ExecuteReader();
            if (data1.Read())
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Group] SET AdminOnlyMessageSettings=@AdminOnlyMessageSettings where GroupId=@GroupId", connection2);
                cmd.Parameters.AddWithValue("@AdminOnlyMessageSettings", group.GetAdminOnlyMessageSettings() ? 1 : 0);
                cmd.Parameters.AddWithValue("@GroupId", data1.GetInt32(0));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    check = true;

                }
            }
            connection1.Close();
            connection2.Close();
            return check;

        }

        public List<User> RetreiveGroupMembers(int GroupId)
        {
            List<User> GroupMembers = new List<User>();
            string conStr = Utilities.GetConnectionString();
            SqlConnection connection1 = Utilities.GetSqlConnection(conStr);
            SqlConnection connection2 = Utilities.GetSqlConnection(conStr);
            connection1.Open();
            connection2.Open();
            string searchQueryForgroupMembers = String.Format("Select UserId from [GroupMembers] where GroupId = {0}", GroupId);
            SqlCommand command1 = new SqlCommand(searchQueryForgroupMembers, connection1);
            SqlDataReader data1 = command1.ExecuteReader();

            while (data1.Read())
            {
                string searchQuery = String.Format("Select * from [User] where UserId = {0} ", data1.GetInt32(0));
                SqlCommand command2 = new SqlCommand(searchQuery, connection2);
                SqlDataReader data2 = command2.ExecuteReader();
                if (data2.Read())
                {
                    User U = new User(data2.GetString(0), data2.GetString(1), data2.GetString(2), data2.GetString(3));
                    GroupMembers.Add(U);
                }

                data2.Close();

            }
            connection1.Close();
            connection2.Close();
            return GroupMembers;
        }


        public List<Group> RetrievingDataForUserGroupsList(User user)

        {
            List<Group> UserGroups = new List<Group>();

            string conStr = Utilities.GetConnectionString();
            SqlConnection connection1 = Utilities.GetSqlConnection(conStr);
            SqlConnection connection2 = Utilities.GetSqlConnection(conStr);
            SqlConnection connection3 = Utilities.GetSqlConnection(conStr);
            connection1.Open();
            connection2.Open();
            connection3.Open();
            string searchQuery1 = String.Format("Select UserId from [User] where UserEmail = '{0}' and UserPassword = '{1}'", user.GetUserEmail(), user.GetUserPassword());
            SqlCommand command1 = new SqlCommand(searchQuery1, connection1);
            SqlDataReader data1 = command1.ExecuteReader();
            if (data1.Read())
            {
                string searchQueryForContactsList = String.Format("Select GroupId from [GroupMembers] where UserId = {0}", data1.GetInt32(0));
                SqlCommand command2 = new SqlCommand(searchQueryForContactsList, connection2);
                SqlDataReader data2 = command2.ExecuteReader();
                while (data2.Read())
                {
                    List<User> GroupMembers = RetreiveGroupMembers(data2.GetInt32(0));
                    List<Message> GroupMessages = RetrieveGroupsMessages(data2.GetInt32(0));
                    string searchQuery3 = String.Format("Select * from [Group] where GroupId = {0} ", data2.GetInt32(0));
                    SqlCommand command3 = new SqlCommand(searchQuery3, connection3);
                    SqlDataReader data3 = command3.ExecuteReader();
                    if (data3.Read())
                    {
                        Group G = new Group(data3.GetString(0), data3.GetString(1), data3.GetString(2), data3.GetBoolean(3), GroupMembers, GroupMessages);

                        UserGroups.Add(G);
                    }

                    data3.Close();

                }

            }
            connection1.Close();
            connection2.Close();
            connection3.Close();
            return UserGroups;

        }


        public List<Message> RetrieveGroupsMessages(int GroupId)
        {
            List<Message> GroupMessages = new List<Message>();

            string conStr = Utilities.GetConnectionString();

            using (SqlConnection connection = Utilities.GetSqlConnection(conStr))
            {
                connection.Open();

                // Query to retrieve GroupMessageId and corresponding TextGroupMessages
                string searchQuery = @"
             SELECT  gm.Sender, gm.Receivers, gm.TimeStamp, gm.IsSeen, tgm.Text
             FROM [GroupMessages] gm
             INNER JOIN [TextGroupMessages] tgm ON gm.GroupMessageId = tgm.GroupMessageId
             WHERE gm.GroupId = @GroupId";



                using (SqlCommand command = new SqlCommand(searchQuery, connection))
                {
                    command.Parameters.AddWithValue("@GroupId", GroupId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string sender = reader.GetString(0);
                            string receiver = reader.GetString(1);
                            DateTime timeStamp = reader.GetDateTime(2);
                            bool isSeen = reader.GetBoolean(3);
                            string text = reader.GetString(4);

                            Message message = new TextMessage(sender, receiver, timeStamp, isSeen, text);
                            GroupMessages.Add(message);
                        }
                    }
                }
                connection.Close();
            }

            
            return GroupMessages;
        }


        public List<Community> RetreiveDataForUserCommunitiesList(User user)
        {
            List<Community> UserCommunitiesList = new List<Community>();
            

            string conStr = Utilities.GetConnectionString();
            SqlConnection connection1 = Utilities.GetSqlConnection(conStr);
            SqlConnection connection2 = Utilities.GetSqlConnection(conStr);
            SqlConnection connection3 = Utilities.GetSqlConnection(conStr);
            connection1.Open();
            connection2.Open();
            connection3.Open();
            string searchQuery1 = String.Format("Select UserId from [User] where UserEmail = '{0}' and UserPassword = '{1}'", user.GetUserEmail(), user.GetUserPassword());
            SqlCommand command1 = new SqlCommand(searchQuery1, connection1);
            SqlDataReader data1 = command1.ExecuteReader();
            if (data1.Read())
            {
                
                string searchQueryForContactsList = String.Format("Select Name,CommunityId from [Community] where UserId = {0}", data1.GetInt32(0));
                SqlCommand command2 = new SqlCommand(searchQueryForContactsList, connection2);
                SqlDataReader data2 = command2.ExecuteReader();
                while(data2.Read())
                {
                    string searchQuery3 = String.Format("Select GroupId from [CommunityGroups] where CommunityId = {0}", data2.GetInt32(1));
                    SqlCommand command3 = new SqlCommand(searchQuery3, connection3);
                    SqlDataReader data3 = command3.ExecuteReader();
                    List<Group> CommunityGroups=new List<Group>();
                    while (data3.Read())
                    {
                        CommunityGroups.Add(RetrievingDataForCommunitiesGroups(data3.GetInt32(0)));
                        

                    }
                    data3.Close();
                    Community community = new Community(data2.GetString(0), CommunityGroups);
                    UserCommunitiesList.Add(community);





                }
                data2.Close();
            }

            connection1.Close();
            connection2.Close();
            connection3.Close();
            return UserCommunitiesList;

        }


        public Group RetrievingDataForCommunitiesGroups(int groupId)

        {
            Group CommunityGroups = new Group();

            string conStr = Utilities.GetConnectionString();

            SqlConnection connection3 = Utilities.GetSqlConnection(conStr);

            connection3.Open();

            List<User> GroupMembers = RetreiveGroupMembers(groupId);
            List<Message> GroupMessages = RetrieveGroupsMessages(groupId);
            string searchQuery3 = String.Format("Select * from [Group] where GroupId = {0} ", groupId);
            SqlCommand command3 = new SqlCommand(searchQuery3, connection3);
            SqlDataReader data3 = command3.ExecuteReader();
            if (data3.Read())
            {
                Group G = new Group(data3.GetString(0), data3.GetString(1), data3.GetString(2), data3.GetBoolean(3), GroupMembers, GroupMessages);

                CommunityGroups = G;
            }

            data3.Close();

            connection3.Close();
            return CommunityGroups;

        }

    }

    
        
        


    
}
