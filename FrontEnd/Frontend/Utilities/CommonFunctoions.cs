using FontAwesome.Sharp;
using SecSemesterProjOOP.BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace OOPProject.Utilities
{
    internal class CommonFunctoions
    {
        public static void OpenChildForm(Form ChildForm, System.Windows.Forms.Panel HomePagePanel)
        {

            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            HomePagePanel.Controls.Add(ChildForm);
            HomePagePanel.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();

        }


        public static void ShowPagePanel(System.Windows.Forms.Panel HomePagePanel)
        {
            HomePagePanel.BringToFront();
            HomePagePanel.Show();
        }
        //you can do polymorphism as createbutton can have different forms.
        public static List<User> CreateButtons(System.Windows.Forms.Panel panel, List<IndividualContact> contacts, int buttonwidth)
        {
            List<User> SelectedContacts = new List<User>();
            
            panel.Controls.Clear();

            
            int buttonWidth = buttonwidth;
            int buttonHeight = 70;
            int spacing = 1;
            int x = 0;
            int y = 10;

          
            foreach (IndividualContact contact in contacts)
            {
                IconButton button = GenrateButton(buttonWidth, buttonHeight, IconChar.User);

                button.Tag = contact.GetUserContact().GetUserName();
                button.Text = contact.GetUserContact().GetUserName(); 
                
                button.Click += (sender, e) =>
                {

                    if (button.ForeColor == System.Drawing.Color.Gainsboro)
                    {

                        button.ForeColor = System.Drawing.Color.CadetBlue;
                        button.BackColor = System.Drawing.Color.FromArgb(39, 45, 74);
                        button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;


                       
                        SelectedContacts.Add(contact.GetUserContact());

                    }
                    else if (button.ForeColor == System.Drawing.Color.CadetBlue)
                    {

                        button.ForeColor = System.Drawing.Color.Gainsboro;
                        button.BackColor = System.Drawing.Color.FromArgb(34, 33, 74);
                        button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;

                       
                        SelectedContacts.Remove(contact.GetUserContact());
                    }
                 };
                
                panel.Controls.Add(button);

               
                y += buttonHeight + spacing;
            }

            
            panel.AutoScroll = true;

            return SelectedContacts;
        }

        public static void CreateButtons2(System.Windows.Forms.Panel panel, Group group, int buttonwidth)
        {
           List<User> GroupMembers=group.GetGroupMembers();

            panel.Controls.Clear();


            int buttonWidth = buttonwidth;
            int buttonHeight = 70;
            int spacing = 1;
            int x = 0;
            int y = 10;


            foreach (User u in GroupMembers)
            {
                IconButton button = GenrateButton(buttonWidth, buttonHeight, IconChar.User);
                if(u.GetUserName()==group.GetGroupAdmin())
                {
                    button.Tag = u.GetUserName()+"  (Group Admin)";
                    button.Text = u.GetUserName() + "   (Group Admin)";

                }
                else
                {
                    button.Tag = u.GetUserName();
                    button.Text = u.GetUserName();

                }
               

                

                panel.Controls.Add(button);


                y += buttonHeight + spacing;
            }


            panel.AutoScroll = true;

            
        }

        public static List<Group> CreateButtons3(System.Windows.Forms.Panel panel, List<Group> groups, int buttonwidth)
        {
            List<Group> SelectedGroups = new List<Group>();

            panel.Controls.Clear();


            int buttonWidth = buttonwidth;
            int buttonHeight = 70;
            int spacing = 1;
            int x = 0;
            int y = 10;


            foreach (Group g in groups)
            {
                IconButton button = GenrateButton(buttonWidth, buttonHeight, IconChar.User);

                button.Tag = g.GetGroupName();
                button.Text = g.GetGroupName();

                button.Click += (sender, e) =>
                {

                    if (button.ForeColor == System.Drawing.Color.Gainsboro)
                    {

                        button.ForeColor = System.Drawing.Color.CadetBlue;
                        button.BackColor = System.Drawing.Color.FromArgb(39, 45, 74);
                        button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;



                        SelectedGroups.Add(g);

                    }
                    else if (button.ForeColor == System.Drawing.Color.CadetBlue)
                    {

                        button.ForeColor = System.Drawing.Color.Gainsboro;
                        button.BackColor = System.Drawing.Color.FromArgb(34, 33, 74);
                        button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;


                        SelectedGroups.Remove(g);
                    }
                };

                panel.Controls.Add(button);


                y += buttonHeight + spacing;
            }


            panel.AutoScroll = true;

            return SelectedGroups;
        }



        public static IconButton GenrateButton(int buttonWidth, int buttonHeight, IconChar icon)
        {
            IconButton button = new IconButton();
            button.Dock = System.Windows.Forms.DockStyle.Top;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Century Gothic", 14.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.ForeColor = System.Drawing.Color.Gainsboro;
            button.IconChar = icon;
            button.IconColor = System.Drawing.Color.Gainsboro; // Change icon color if needed
            button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button.IconSize = 40;
            button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            button.TabIndex = 1;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button.UseVisualStyleBackColor = true;

            return button;
        }

        public static void SetNameInPage(System.Windows.Forms.Panel panel, string labelText)
        {
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.Gainsboro;
            label.AutoSize = true;
            label.Text = labelText;
            label.Location = new Point(90, 20);
            panel.Controls.Add(label);

        }

        
        public static void DisplayMessages(List<SecSemesterProjOOP.BL.Message> groupMessages, System.Windows.Forms.Panel panel)
        {
            
            panel.Controls.Clear();
         
            int x = 10;
            int y = 10;

            foreach (SecSemesterProjOOP.BL.Message message in groupMessages)
            {
                TextMessage textMessage = (TextMessage)message;

               
                Label senderLabel = new Label();
                senderLabel.Text = message.GetSender();
                senderLabel.AutoSize = true;
                senderLabel.BackColor = Color.LightGray; 
                senderLabel.BorderStyle = BorderStyle.FixedSingle;
                senderLabel.Padding = new Padding(5);
                senderLabel.Location = new Point(x, y);
                panel.Controls.Add(senderLabel);
                Label messageLabel = new Label();
                messageLabel.Text = textMessage.GetText();
                messageLabel.AutoSize = true;
                messageLabel.BackColor = Color.LightBlue;
                messageLabel.BorderStyle = BorderStyle.FixedSingle;
                messageLabel.Padding = new Padding(10);

                
                messageLabel.Location = new Point(x + senderLabel.Width + 5, y);
                panel.Controls.Add(messageLabel);
                y += Math.Max(senderLabel.Height, messageLabel.Height) + 10; 
                panel.AutoScroll = true;
            }
        }

    }
}
