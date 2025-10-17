using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using SecSemesterProjOOP.BL;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using OOPProject.Utilities;
using System.Data.SqlClient;

namespace OOPProject.UI.Chat
{
    public partial class ChannelPage : Form
    {
        static Panel ParentPanel;
        static User SignedInUser;
        public ChannelPage(Panel homePagePanel,User signedInUser)
        {
            InitializeComponent();
            ParentPanel = homePagePanel;
            SignedInUser = signedInUser;
            CreateButtons(panel6, signedInUser.GetChannels(), 205, 90);
            
        }

        private void ChannelPage_Load(object sender, EventArgs e)
        {

        }

        private static void CreateButtons(System.Windows.Forms.Panel panel, List<Channels> Channels, int buttonWidth, int buttonHeight)
        {

            panel.Controls.Clear();
            int spacing = 1;
            int x = 0;
            int y = 10;


            foreach (Channels channel in Channels)
            {
                IconButton button = CommonFunctoions.GenrateButton(buttonWidth, buttonHeight, IconChar.Crosshairs);

                button.Tag = channel.GetChannelName();
                button.Text = channel.GetChannelName();


                List<string> imagePaths = ImagePaths(channel);
                button.Click += (sender, e) => OpenFormForUserGroups(channel,imagePaths);


                panel.Controls.Add(button);


                y += buttonHeight + spacing;
            }


            panel.AutoScroll = true;
        }

        private static void OpenFormForUserGroups(Channels channel,List<string> imagePaths)
        {
            CommonFunctoions.OpenChildForm(new ChannelPostsPage(channel,imagePaths, SignedInUser,ParentPanel), ParentPanel);
        }

        private static List<string> ImagePaths(Channels channel)
        {
            List<string> imagePaths = new List<string>();
            string conStr = Util.GetConnectionString();
            SqlConnection connection1 = Util.GetSqlConnection(conStr);
            SqlConnection connection2 = Util.GetSqlConnection(conStr);
            connection1.Open();
            connection2.Open();
            string searchQueryForgroupMembers = String.Format("Select ChannelId from [Channels] where Name = '{0}'", channel.GetChannelName());
            SqlCommand command1 = new SqlCommand(searchQueryForgroupMembers, connection1);
            SqlDataReader data1 = command1.ExecuteReader();

            while (data1.Read())
            {
                string searchQuery = String.Format("Select ImagePath from [ChannelPosts] where ChannelId = {0} ", data1.GetInt32(0));
                SqlCommand command2 = new SqlCommand(searchQuery, connection2);
                SqlDataReader data2 = command2.ExecuteReader();
                if (data2.Read())
                {
                    string data = data2.GetString(0);
                    imagePaths.Add(@data);
                }

                data2.Close();

            }
            connection1.Close();
            connection2.Close();
            
            return imagePaths;

        }
    }
}
