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
    public partial class HomePage : Form
    {
        User SignedInUser;
        public HomePage(User user)
        {
            InitializeComponent();
            SignedInUser=user;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
