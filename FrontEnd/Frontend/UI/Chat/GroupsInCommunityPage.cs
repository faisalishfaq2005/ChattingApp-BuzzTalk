using FontAwesome.Sharp;
using OOPProject.Utilities;
using SecSemesterProjOOP.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPProject.UI.Chat
{
    public partial class GroupsInCommunityPage : Form
    {
        static Panel ParentPanel;
        static User SignedInUser;
        static List<Group> GroupsInCommunity;
        Community Community;
        public GroupsInCommunityPage(Panel parentPanel, User user, List<Group> groupsInCommunity)
        {
            InitializeComponent();
            ParentPanel = parentPanel;
            SignedInUser = user;
            GroupsInCommunity = groupsInCommunity;
            CreateButtons(panel6, GroupsInCommunity, 205, 90);
            
        }

        private void GroupsInCommunityPage_Load(object sender, EventArgs e)
        {

        }


        private static void CreateButtons(System.Windows.Forms.Panel panel,List<Group> GroupsInCommunity, int buttonWidth, int buttonHeight)
        {

            panel.Controls.Clear();
            int spacing = 1;
            int x = 0;
            int y = 10;
            

            foreach (Group group in GroupsInCommunity)
            {
                IconButton button = CommonFunctoions.GenrateButton(buttonWidth, buttonHeight, IconChar.Users);

                button.Tag = group.GetGroupName();
                button.Text = group.GetGroupName();



                button.Click += (sender, e) => OpenFormForUserGroups(group);


                panel.Controls.Add(button);


                y += buttonHeight + spacing;
            }


            panel.AutoScroll = true;
        }


        private static void OpenFormForUserGroups(Group group)
        {
            CommonFunctoions.OpenChildForm(new MessagesChatPage(ParentPanel, SignedInUser, group, 2, GroupsInCommunity), ParentPanel);
        }
    }
}
