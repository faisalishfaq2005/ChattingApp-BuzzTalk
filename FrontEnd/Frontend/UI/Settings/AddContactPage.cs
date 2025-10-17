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

namespace OOPProject.UI.Settings
{
    public partial class AddContactPage : Form
    {

        public User SignedInUser;
        public AddContactPage(User user)
        {
            InitializeComponent();
            this.SignedInUser = user;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            User user = new User(guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox3.Text);
            if (ObjectHandler.GetUserDL().ValidateUserForAddingContact(user) ==true && SignedInUser.SearchUserInUserContacts(user)==false)
            {
                SignedInUser.AddContactInUserContacts(user);
                ObjectHandler.GetIndividualContactDL().UpdateContactInUserContacts(user, SignedInUser);
                CommonMessageBox m = new CommonMessageBox();
                m.SetLabelText("Person Added To Your Contacts");
                m.ShowDialog();
                this.Hide();
                UserPage2 userPage = new UserPage2(SignedInUser);
                userPage.ShowDialog();
                userPage = null;
                this.Show();
            }
            else if(ObjectHandler.GetUserDL().ValidateUserForAddingContact(user) == true && SignedInUser.SearchUserInUserContacts(user) == true)
            {
                CommonMessageBox m = new CommonMessageBox();
                m.SetLabelText("Person Already Added");
                m.ShowDialog();

            }
            
            else 
            {
                CommonMessageBox m = new CommonMessageBox();
                m.SetLabelText("This person does not exist on BuzzTalk");
                m.ShowDialog();
            }
        }
    }
}
