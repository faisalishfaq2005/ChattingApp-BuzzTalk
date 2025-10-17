using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOPProject.Utilities;
using SecSemesterProjOOP.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OOPProject.UI.Settings
{
    public partial class SettingsPage : Form
    {

        Panel ParentPanel;
        User SignedInUser;

       



        public SettingsPage(Panel parentPanel, User user)
        {
            InitializeComponent();
            SignedInUser = user;
            
            ParentPanel = parentPanel;
            CommonFunctoions.SetNameInPage(panel2,SignedInUser.GetUserName());
            
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            
            CommonFunctoions.OpenChildForm(new AddGroupPage(SignedInUser),ParentPanel);
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            CommonFunctoions.OpenChildForm(new AddContactPage(SignedInUser), ParentPanel);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            CommonFunctoions.OpenChildForm(new AddGroupsInCommunityPage(SignedInUser), ParentPanel);

        }
    }
}
