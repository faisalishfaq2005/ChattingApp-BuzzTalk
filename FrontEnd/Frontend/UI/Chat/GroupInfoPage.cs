using FontAwesome.Sharp;
using OOPProject.Utilities;
using SecSemesterProjOOP.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPProject.UI.Chat
{
    public partial class GroupInfoPage : Form
    {
        Panel ParentPanel;
        User SignedInUser;
        Group Group;
        public GroupInfoPage(Panel parentPanel, User user, Group group)
        {
            InitializeComponent();
            ParentPanel = parentPanel;
            SignedInUser = user;
            Group = group;
            CommonFunctoions.CreateButtons2(panel3, Group, 205);
            if(SignedInUser.GetUserName()==Group.GetGroupAdmin())
            {
                CreateButton(panel7, "Allow Only Admin To Send Messages",Group,205);
                CreateButton(panel8, "Allow All Members To Send Messages",Group, 205);
            }
        }

        private void GroupInfoPage_Load(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            CommonFunctoions.OpenChildForm(new MessagesChatPage(ParentPanel, SignedInUser, Group,1), ParentPanel);
        }

        private static void CreateButton(System.Windows.Forms.Panel panel, string s,Group group, int buttonwidth)
        {
            

            panel.Controls.Clear();


            int buttonWidth = buttonwidth;
            int buttonHeight = 70;
           
            IconButton button =CommonFunctoions.GenrateButton(buttonWidth, buttonHeight, IconChar.User);
            button.Tag = s;
            button.Text= s;

            if (group.GetAdminOnlyMessageSettings() == true && s == "Allow Only Admin To Send Messages")
            {
                button.ForeColor = System.Drawing.Color.CadetBlue;
                button.BackColor = System.Drawing.Color.FromArgb(39, 45, 74);
                button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;

            }
            else if(group.GetAdminOnlyMessageSettings() == false && s == "Allow All Members To Send Messages")
            {
                button.ForeColor = System.Drawing.Color.CadetBlue;
                button.BackColor = System.Drawing.Color.FromArgb(39, 45, 74);
                button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;


            }

            button.Click += (sender, e) =>
            {
                if (s == "Allow Only Admin To Send Messages") 
                {
                    group.SetAdminOnlyMessageSettings(true);
                    ObjectHandler.GetGroupDL().UpdateAdminOnlyManageSettings(group);
                }
                else if(s == "Allow All Members To Send Messages")
                {
                    group.SetAdminOnlyMessageSettings(false);
                    ObjectHandler.GetGroupDL().UpdateAdminOnlyManageSettings(group);

                }
                

            };


                panel.Controls.Add(button);




           


        }
    }
}
