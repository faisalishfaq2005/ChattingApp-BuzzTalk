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

namespace OOPProject.UI.Settings
{
    public partial class AddGroupPage : Form
    {
        public User SignedInUser;
        List<IndividualContact> contacts;
        List<User> GroupMembers;
        
        public AddGroupPage(User user)
        {
            InitializeComponent();
            SignedInUser = user;
            if (SignedInUser != null)
            {
                contacts = SignedInUser.GetUserContacts();
                GroupMembers = CommonFunctoions.CreateButtons(panel3, contacts, 205);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddGroupPage_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Group group=new Group(guna2TextBox1.Text,guna2TextBox2.Text,SignedInUser.GetUserName(),GroupMembers);
            SignedInUser.AddGroupInUserGroups(group);
            ObjectHandler.GetGroupDL().UpdateGroupInUserGroups(group);
            ObjectHandler.GetGroupDL().UpdateGroupMembers(SignedInUser, group);
            foreach (User u in GroupMembers)
            {
                
                ObjectHandler.GetGroupDL().UpdateGroupMembers(u, group);

            }
            this.Hide();
            UserPage2 userPage = new UserPage2(SignedInUser);
            userPage.ShowDialog();
            userPage = null;
            this.Show();


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
