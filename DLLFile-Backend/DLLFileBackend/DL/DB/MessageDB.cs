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
    public class MessageDB:IMessageDL
    {
        public bool UpdateGroupMessage(Group group, Message message)
        {
            bool check = false;
            string connectionString = Utilities.GetConnectionString();
            SqlConnection connection1 = Utilities.GetSqlConnection(connectionString);
            SqlConnection connection2 = Utilities.GetSqlConnection(connectionString);
            SqlConnection connection3 = Utilities.GetSqlConnection(connectionString);
            SqlConnection connection4 = Utilities.GetSqlConnection(connectionString);
            connection1.Open();
            connection2.Open();
            connection3.Open();
            connection4.Open();
            string searchQuery1 = String.Format("Select GroupId from [Group] where Name = '{0}'", group.GetGroupName());
            SqlCommand command1 = new SqlCommand(searchQuery1, connection1);
            SqlDataReader data1 = command1.ExecuteReader();
            if (data1.Read())
            {
                string timeStampString = message.GetTimeStamp().ToString("yyyy-MM-dd HH:mm:ss");
                string query2 = String.Format("insert into [GroupMessages] (Sender,Receivers,TimeStamp,IsSeen,GroupId) VALUES('{0}','{1}','{2}',{3},{4})", message.GetSender(), message.GetReceivers(), timeStampString, message.GetIsSeen() ? 1 : 0, data1.GetInt32(0));
                SqlCommand command2 = new SqlCommand(query2, connection2);
                int rowsAffected1 = command2.ExecuteNonQuery();
                if (rowsAffected1 > 0)
                {
                    string searchQuery2 = String.Format("Select GroupMessageId from [GroupMessages] where GroupId = {0}", data1.GetInt32(0));
                    SqlCommand command3 = new SqlCommand(searchQuery2, connection3);
                    SqlDataReader data2 = command3.ExecuteReader();
                    if (data2.Read())
                    {
                        TextMessage textMessage = (TextMessage)message;
                        string query3 = String.Format("insert into [TextGroupMessages] (GroupMessageId,Text) VALUES({0},'{1}')", data2.GetInt32(0), textMessage.GetText());
                        SqlCommand command4 = new SqlCommand(query3, connection2);
                        int rowsAffected2 = command4.ExecuteNonQuery();
                        if (rowsAffected2 > 0)
                        {
                            check = true;

                        }

                    }

                }

            }
            connection1.Close();
            connection2.Close();
            connection3.Close();
            connection4.Close();
            return check;

        }

    }
}
