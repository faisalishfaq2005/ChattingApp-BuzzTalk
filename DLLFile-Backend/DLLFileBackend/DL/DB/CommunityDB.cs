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
    public class CommunityDB : ICommunityDL
    {
        public bool AddUserCommunity(User user, Community community)
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
                string SearchQuery2 = String.Format("insert into [Community] (Name,UserId) VALUES('{0}',{1})", community.GetCommunityName(), data1.GetInt32(0));
                SqlCommand command2 = new SqlCommand(SearchQuery2, connection1);
                int rowsAffected1 = command2.ExecuteNonQuery();
                if (rowsAffected1 > 0)
                {
                    string searchQuery3 = String.Format("Select CommunityId from [Community] where Name = '{0}'", community.GetCommunityName());
                    SqlCommand command3 = new SqlCommand(searchQuery3, connection2);
                    SqlDataReader data2 = command3.ExecuteReader();
                    if (data2.Read())
                    {
                        foreach(Group g in community.GetGroupsInCommunity())
                        {
                            AddGroupsInCommunity(g, data2.GetInt32(0));
                        }



                    }


                }
            }
            connection.Close();
            connection1.Close();
            connection2.Close();
            return check;


        }

        public bool AddGroupsInCommunity(Group communityGroup,int communityId)
        {

            bool check = false;
            string connectionString = Utilities.GetConnectionString();
            SqlConnection connection = Utilities.GetSqlConnection(connectionString);
            SqlConnection connection1 = Utilities.GetSqlConnection(connectionString);
            connection.Open();
            connection1.Open();
            string searchQuery2 = String.Format("Select GroupId from [Group] where Name = '{0}'", communityGroup.GetGroupName());
            SqlCommand command = new SqlCommand(searchQuery2, connection);
            SqlDataReader data = command.ExecuteReader();
            if (data.Read())
            {
                string query2 = String.Format("insert into [CommunityGroups] (CommunityId,GroupId) VALUES({0},{1})", communityId, data.GetInt32(0));
                SqlCommand command2 = new SqlCommand(query2, connection1);
                int rowsAffected1 = command2.ExecuteNonQuery();
                if (rowsAffected1 > 0)
                {
                    check = true;
                }
            }
            connection.Close();
            connection1.Close();

            return check;

        }





        
    }
}
