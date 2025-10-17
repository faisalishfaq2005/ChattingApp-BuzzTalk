using Guna.UI2.WinForms;
using OOPProject.Utilities;
using SecSemesterProjOOP.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPProject.UI.Settings
{
    public partial class AddGroupsInCommunityPage : Form
    {
        User SignedInUser;
        List<Group> UserGroups;
        List<Group> GroupsInCommunity;

        public AddGroupsInCommunityPage(User user)
        {
            InitializeComponent();
            SignedInUser=user;
            UserGroups=SignedInUser.GetUserUserGroups();
            GroupsInCommunity= CommonFunctoions.CreateButtons3(panel3, UserGroups, 205);

        }

        private void AddGroupsInCommunityPage_Load(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Community community = new Community(guna2TextBox1.Text, GroupsInCommunity);
            SignedInUser.AddCommunityInUserCommunities(community);
            ObjectHandler.GetCommunityDL().AddUserCommunity(SignedInUser,community);
           
            
            this.Hide();
            UserPage2 userPage = new UserPage2(SignedInUser);
            userPage.ShowDialog();
            userPage = null;
            this.Show();
        }
    }
}
