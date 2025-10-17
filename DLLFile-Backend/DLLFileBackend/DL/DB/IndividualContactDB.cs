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
    public class IndividualContactDB:IIndividualContactDL
    {
        public List<IndividualContact> RetrievingDataForContactsList(User user)
        // add in this function to olso receive the messages of that individual contact
        {
            List<IndividualContact> Contacts = new List<IndividualContact>();
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
                string searchQueryForContactsList = String.Format("Select UserContactId from [IndividualContact] where UserId = {0}", data1.GetInt32(0));
                SqlCommand command2 = new SqlCommand(searchQueryForContactsList, connection2);
                SqlDataReader data2 = command2.ExecuteReader();
                while (data2.Read())
                {
                    string searchQuery3 = String.Format("Select * from [User] where UserId = {0} ", data2.GetInt32(0));
                    SqlCommand command3 = new SqlCommand(searchQuery3, connection3);
                    SqlDataReader data3 = command3.ExecuteReader();
                    if (data3.Read())
                    {
                        User U = new User(data3.GetString(0), data3.GetString(1), data3.GetString(2), data3.GetString(3));
                        IndividualContact c = new IndividualContact(U);
                        Contacts.Add(c);
                    }

                    data3.Close();

                }

            }
            connection1.Close();
            connection2.Close();
            connection3.Close();
            return Contacts;

        }

        public bool UpdateContactInUserContacts(User user, User SignedInUser)
        {
            bool check = false;
            string connectionString = Utilities.GetConnectionString();
            SqlConnection connection = Utilities.GetSqlConnection(connectionString);
            SqlConnection connection2 = Utilities.GetSqlConnection(connectionString);
            SqlConnection connection3 = Utilities.GetSqlConnection(connectionString);

            connection.Open();
            connection2.Open();
            connection3.Open();

            string searchQuery1 = String.Format("Select UserId from [User] where UserName = '{0}'", user.GetUserName());
            string searchQuery2 = String.Format("Select UserId from [User] where UserName = '{0}'", SignedInUser.GetUserName());
            SqlCommand command1 = new SqlCommand(searchQuery1, connection);
            SqlCommand command2 = new SqlCommand(searchQuery2, connection2);
            SqlDataReader data1 = command1.ExecuteReader();
            SqlDataReader data2 = command2.ExecuteReader();
            if (data1.Read() && data2.Read())
            {
                string query1 = String.Format("insert into [IndividualContact] (UserId,UserContactId) VALUES({0},{1})", data2.GetInt32(0), data1.GetInt32(0));
                SqlCommand command3 = new SqlCommand(query1, connection3);
                int rowsAffected1 = command3.ExecuteNonQuery();


                if (rowsAffected1 > 0)
                {
                    check = true;
                }


            }
            connection.Close();
            connection2.Close();
            connection3.Close();

            return check;

        }

    }
}
