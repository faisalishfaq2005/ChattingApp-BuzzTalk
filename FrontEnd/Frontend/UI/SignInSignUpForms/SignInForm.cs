using Guna.UI2.WinForms;
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


namespace OOPProject.UI.SignInSignUpForms
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //hide this form
            this.Hide();
            //create an instance of SignUpForm
            SignUpForm signUpForm = new SignUpForm();
            //show signup form
            signUpForm.ShowDialog();
            signUpForm = null;
            this.Show();
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            User user = new User(guna2TextBox1.Text, guna2TextBox2.Text);
            List<IndividualContact> contacts = ObjectHandler.GetIndividualContactDL().RetrievingDataForContactsList(user);
            List<Group> UserGroups = ObjectHandler.GetGroupDL().RetrievingDataForUserGroupsList(user);
            List<Community> UserCommunities= ObjectHandler.GetGroupDL().RetreiveDataForUserCommunitiesList(user);
            List<Channels> channels = ObjectHandler.GetUserDL().RetreiveChannels();
            if (ObjectHandler.GetUserDL().SignIn(user,contacts,UserGroups,UserCommunities,channels)!=null)
            {
                
                User SignedInUser = ObjectHandler.GetUserDL().SignIn(user,contacts, UserGroups,UserCommunities, channels);
               
                this.Hide();
                UserPage2 userPage = new UserPage2(SignedInUser);
                userPage.ShowDialog();
                userPage = null;
                this.Show();
            }
            else
            {
                CommonMessageBox m = new CommonMessageBox();
                m.SetLabelText("Account Does Not Exists !");
                m.ShowDialog();
            }

        }
    }
}
