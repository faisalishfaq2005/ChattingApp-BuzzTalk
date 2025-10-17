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
    public partial class CommunityPage : Form
    {
        static Panel ParentPanel;
        static User SignedInUser;
        public CommunityPage(Panel parentPanel, User user)
        {
            InitializeComponent();
            ParentPanel = parentPanel;
            SignedInUser = user;
            if(SignedInUser.GetUserCommunities()!=null)
            {
                CreateButtons(panel6, SignedInUser.GetUserCommunities(), 205, 90);
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private static void CreateButtons(System.Windows.Forms.Panel panel,List<Community> UserCommunities, int buttonWidth, int buttonHeight)
        {
            // Clear existing buttons from the panel
            panel.Controls.Clear();

            // Define button properties

            int spacing = 1;
            int x = 0;
            int y = 10;

            foreach (Community c in UserCommunities)
            {
                List<Group> CommunityGroups = c.GetGroupsInCommunity();
                IconButton button = CommonFunctoions.GenrateButton(buttonWidth, buttonHeight, IconChar.Users);

                button.Tag = c.GetCommunityName();
                button.Text =c.GetCommunityName(); // Optional: Display text alongside the icon


                // Assign the event handler to the button to open a form
                button.Click += (sender, e) => OpenFormForCommunityGroups(CommunityGroups);

                // Add the button to the panel
                panel.Controls.Add(button);

                // Adjust position for the next button
                y += buttonHeight + spacing;
            }

            // Enable vertical scrolling for the panel
            panel.AutoScroll = true;
        }


        private static void OpenFormForCommunityGroups(List<Group> Communitygroup)
        {
            CommonFunctoions.OpenChildForm(new GroupsInCommunityPage(ParentPanel, SignedInUser,Communitygroup ), ParentPanel);
        }
    }
}
