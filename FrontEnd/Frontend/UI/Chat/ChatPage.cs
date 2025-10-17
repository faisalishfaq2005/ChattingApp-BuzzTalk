using FontAwesome.Sharp;
using OOPProject.UI.Settings;
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
    public partial class ChatPage : Form
    {
        static Panel ParentPanel;
        static User SignedInUser;
        bool check;
        List<IndividualContact> contacts;
        List<Group> userGroups;
        
        public ChatPage(Panel parentPanel, User user)
        {
            InitializeComponent();
            ParentPanel = parentPanel;
            SignedInUser = user;
            contacts=SignedInUser.GetUserContacts();
            userGroups=SignedInUser.GetUserUserGroups();
            panel6.Controls.Clear();
            if ((contacts == null || contacts.Count == 0) && (userGroups == null || userGroups.Count == 0))
            {
                
                AddNoContactsLabel(panel6);
            }
            else
            {
                CreateButtons(panel6, contacts, userGroups, 205, 90);
            }

        }

        private void ChatPage_Load(object sender, EventArgs e)
        {
            
        }
        

        private static void CreateButtons(System.Windows.Forms.Panel panel, List<IndividualContact> contacts,List<Group> userGroups, int buttonWidth,int buttonHeight)
        {
            
            panel.Controls.Clear();
            int spacing = 1;
            int x = 0;
            int y = 10;
            foreach (IndividualContact contact in contacts)
            {
                IconButton button = CommonFunctoions.GenrateButton(buttonWidth,buttonHeight, IconChar.User);
                
                button.Tag = contact.GetUserContact().GetUserName();
                button.Text = contact.GetUserContact().GetUserName(); // Optional: Display text alongside the icon
                button.Click += (sender, e) => OpenFormForContact(contact);

                
                panel.Controls.Add(button);

                
                y += buttonHeight + spacing;
            }
           
            foreach (Group group in userGroups)
            {
                IconButton button = CommonFunctoions.GenrateButton(buttonWidth, buttonHeight, IconChar.Users);
                List<SecSemesterProjOOP.BL.Message> message = group.GetGroupMessages();
;               if (message.Count != 0)
                {
                    TextMessage textMessage = (TextMessage)message[message.Count-1];
                    //button.Tag = group.GetGroupName() + "  " + textMessage.GetText();
                    // button.Text = group.GetGroupName() + "  " + textMessage.GetText();
                    string groupName = group.GetGroupName();
                    string messageText = textMessage.GetText()+"  ( "+textMessage.GetSender()+" )";

                    // Apply styling to the button text
                    button.Tag = groupName + "  " + messageText;
                    button.Text = groupName + "\n" + messageText;

                    
                }
                else
                {
                    button.Tag = group.GetGroupName();
                    button.Text = group.GetGroupName();

                }

                
                button.Click += (sender, e) => OpenFormForUserGroups(group);

            
                panel.Controls.Add(button);

                
                y += buttonHeight + spacing;
            }

            
            panel.AutoScroll = true;
        }

        private static void OpenFormForContact(IndividualContact contact)
        {
            CommonFunctoions.OpenChildForm(new MessagesChatPage(ParentPanel,SignedInUser,contact,1), ParentPanel);
        }

        private static void OpenFormForUserGroups(Group group)
        {
            CommonFunctoions.OpenChildForm(new MessagesChatPage(ParentPanel, SignedInUser, group,1), ParentPanel);
        }

        


        public static void AddNoContactsLabel(Panel panel)
        {
            // Create label
            Label label = new Label();
            label.Text = "No Contacts or Groups Added";
            label.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.Gainsboro;
            label.AutoSize = true;

            // Calculate the location to center the label at the top of the panel
            int x = (panel.Width - label.Width) / 2;
            int y = 30;

            // Set the location
            label.Left = 105;
            label.Top = y;
            

            // Add the label to the panel
            panel.Controls.Add(label);
        }
    }
}
