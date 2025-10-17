using SecSemesterProjOOP.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecSemesterProjOOP.BL;
using SecSemesterProjOOP.Utils;
using System.Data.SqlClient;

namespace SecSemesterProjOOP.DL.DB
{
    public class UserDB:IUserDL
    {
        public User SignIn(User user, List<IndividualContact> contacts,List<Group> UserGroups,List<Community> UserCommunities,List<Channels> channels)
        {
            
            

            string conStr= Utilities.GetConnectionString();
            SqlConnection connection = Utilities.GetSqlConnection(conStr);
            connection.Open();
            string searchQuery = String.Format("Select * from [User] where UserEmail = '{0}' and UserPassword = '{1}'", user.GetUserEmail() ,user.GetUserPassword());
            
            SqlCommand command = new SqlCommand(searchQuery, connection);
            SqlDataReader data = command.ExecuteReader();
           
            if (data.Read())
            {
               
                User storedUser = new User(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3),UserGroups ,contacts,UserCommunities,channels);
               //this is not complete user you have to bring all other data for that user olso.
                connection.Close();
                return storedUser;
            }
            connection.Close();
            return null;

        }


        public List<Channels> RetreiveChannels()
        {
            List<Channels> channels = new List<Channels>();


            string conStr = Utilities.GetConnectionString();
            SqlConnection connection = Utilities.GetSqlConnection(conStr);
            connection.Open();
            string searchQuery = String.Format("Select Name from [Channels] ");

            SqlCommand command = new SqlCommand(searchQuery, connection);
            SqlDataReader data = command.ExecuteReader();

            while (data.Read())
            {
                Channels c = new Channels(data.GetString(0));
                channels.Add(c);
                
            }
           
            connection.Close();
            return channels ;

        }




        public  bool SignUp(User user)
        {
            string connectionString = Utilities.GetConnectionString();
            if (!validateUser(user))
            {
                SqlConnection connection = Utilities.GetSqlConnection(connectionString);
                connection.Open();
                string query = String.Format("insert into [User] (UserName,UserEmail, UserPassword,PhoneNumber) VALUES('{0}', '{1}', '{2}',{3})", user.GetUserName(),user.GetUserEmail() ,user.GetUserPassword(), user.GetUserPhone());
                SqlCommand command = new SqlCommand(query, connection);
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool validateUser(User user)
        {
            string connectionString = Utilities.GetConnectionString();
            SqlConnection connection =Utilities.GetSqlConnection(connectionString);
            connection.Open();

            string searchQuery = String.Format("Select * from [User] where UserName = '{0}' ", user.GetUserName());
            SqlCommand command = new SqlCommand(searchQuery, connection);
            SqlDataReader data = command.ExecuteReader();
            bool check = data.Read();
            connection.Close();
            return check;
        }

        public bool ValidateUserForAddingContact(User user)
        {
            string connectionString = Utilities.GetConnectionString();
            SqlConnection connection = Utilities.GetSqlConnection(connectionString);
            connection.Open();

            string searchQuery = String.Format("Select * from [User] where UserName = '{0}' and UserEmail = '{1}' and PhoneNumber={2}", user.GetUserName(), user.GetUserEmail(), user.GetUserPhone());
            SqlCommand command = new SqlCommand(searchQuery, connection);
            SqlDataReader data = command.ExecuteReader();
            bool check = data.Read();
            connection.Close();
            return check;
        }

        
    }
}
    