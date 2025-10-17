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




namespace OOPProject.UI.Chat
{
    public partial class MessagesChatPage : Form
    {
        Panel ParentPanel;
        User SignedInUser;
        IndividualContact Contact;
        bool IsIndividualChat;
        int PreviousPage;
        Group Group;
        List<Group> CommunityGroups;
        
        //multiple constructors are made to accomodate both the group and contact
        public MessagesChatPage(Panel parentPanel, User user,IndividualContact contact, int previousPage)
        {
            InitializeComponent();
            ParentPanel = parentPanel;
            SignedInUser = user;
            Contact = contact;
            IsIndividualChat = true;
            PreviousPage = previousPage;
            CommonFunctoions.SetNameInPage(panel1,contact.GetUserContact().GetUserName());
            iconButton4.Text = "";
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.None;
            CommonFunctoions.DisplayMessages(Contact.GetIndividualMessages(), panel11);


        }

        public MessagesChatPage(Panel parentPanel, User user, Group group,int previousPage)
        {
            InitializeComponent();
            ParentPanel = parentPanel;
            SignedInUser = user;
            Group=group;
            IsIndividualChat = false;
            PreviousPage = previousPage;
            CommonFunctoions.SetNameInPage(panel1, group.GetGroupName());
            CommonFunctoions.DisplayMessages(Group.GetGroupMessages(),panel11);
            checkforAdminSettings();


        }

        public MessagesChatPage(Panel parentPanel, User user, Group group, int previousPage,List<Group> communityGroups)
        {
            InitializeComponent();
            ParentPanel = parentPanel;
            SignedInUser = user;
            Group = group;
            IsIndividualChat = false;
            PreviousPage = previousPage;
            CommunityGroups=communityGroups;
            CommonFunctoions.SetNameInPage(panel1, group.GetGroupName());
            CommonFunctoions.DisplayMessages(Group.GetGroupMessages(), panel11);
            checkforAdminSettings();


        }

        private void MessagesChatPage_Load(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (PreviousPage == 1)
            {
                CommonFunctoions.OpenChildForm(new ChatPage(ParentPanel, SignedInUser), ParentPanel);
            }
            else if(PreviousPage==2)
            {
                CommonFunctoions.OpenChildForm(new GroupsInCommunityPage(ParentPanel, SignedInUser,CommunityGroups), ParentPanel);
            }
        }



        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
            
            
            if(IsIndividualChat==true)
            {
                
                
                SecSemesterProjOOP.BL.Message message = new TextMessage(SignedInUser.GetUserName(), Contact.GetUserContact().GetUserName(), DateTime.Now, false,guna2TextBox1.Text);
                Contact.AddMessageInMessageList(message);
                CommonFunctoions.DisplayMessages(Contact.GetIndividualMessages(), panel11);
            }
            
            else if(IsIndividualChat==false)
            {
                
                guna2TextBox1.PlaceholderText = "Message";
                string Receivers = "";

                List<User> UserReceivers = Group.GetGroupMembers();
                foreach (User u in UserReceivers)
                {
                    Receivers = Receivers + u.GetUserName();

                }

                SecSemesterProjOOP.BL.Message message = new TextMessage(SignedInUser.GetUserName(), Receivers, DateTime.Now, false, guna2TextBox1.Text);
                Group.AddMessage(message);
                ObjectHandler.GetMessageDL().UpdateGroupMessage(Group, message);

                CommonFunctoions.DisplayMessages(Group.GetGroupMessages(), panel11);

            }
           
        }
        private void checkforAdminSettings()
        {
            if (IsIndividualChat == false && Group.GetAdminOnlyMessageSettings() == true && SignedInUser.GetUserName() != Group.GetGroupAdmin())
            {
                iconButton1.Enabled = false;
                guna2TextBox1.PlaceholderText = "Only Admin Can Send Messages";
            }

        }
        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            CommonFunctoions.OpenChildForm(new GroupInfoPage(ParentPanel, SignedInUser, Group), ParentPanel);

        }
    }   

}
