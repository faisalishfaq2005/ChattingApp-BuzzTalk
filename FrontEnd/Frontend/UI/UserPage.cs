using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using OOPProject.UI.Chat;
using OOPProject.UI.Settings;
using OOPProject.UI.SignInSignUpForms;
using OOPProject.Utilities;
using SecSemesterProjOOP.BL;


namespace OOPProject.UI
{
    public partial class UserPage2 : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel LeftBorderBtn;
        public Form CurrentChildForm;
        public User SignedInUser;

        
        public UserPage2(User u)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new Size(7, 70);
            PanelMenu.Controls.Add(LeftBorderBtn);
            SignedInUser = u;

        }
        public UserPage2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new Size(7, 70);
            PanelMenu.Controls.Add(LeftBorderBtn);
           

        }
        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(172,126,241);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(249, 118,176);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(253, 138, 114);
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(95, 72, 223);
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(249, 88,155);
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(24, 161, 251);



        }

        private void ActivateButton(object senderBtn,System.Drawing.Color color)
        {
            if(senderBtn!=null)
            {
                DisableButton();
                //button
                currentBtn=(IconButton)senderBtn;
                currentBtn.BackColor=System.Drawing.Color.FromArgb(37,36,81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //left border button
                LeftBorderBtn.BackColor = color;
                LeftBorderBtn.Location = new Point(0,currentBtn.Location.Y);
                LeftBorderBtn.Visible=true;
                LeftBorderBtn.BringToFront();

                //icon current child form
                iconPictureBox1.IconChar = currentBtn.IconChar;
                iconPictureBox1.IconColor = color;

                


            }

        }

        private void DisableButton()
        {
            if(currentBtn!=null) 
            
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(31, 30, 65);
                currentBtn.ForeColor = System.Drawing.Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        private void Reset()
        {
            DisableButton();
            LeftBorderBtn.Visible=false;
            iconPictureBox1.IconChar = IconChar.Home;
            iconPictureBox1.IconColor = System.Drawing.Color.MediumPurple;
            HomeForm.Text = "Home";
        }

        public  System.Windows.Forms.Panel StoreHomePagePanel()
        {
            return HomePagePanel;
        }


        

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            CommonFunctoions.OpenChildForm(new HomePage(SignedInUser), HomePagePanel);




        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            CommonFunctoions.OpenChildForm(new ChatPage(HomePagePanel, SignedInUser), HomePagePanel);

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            CommonFunctoions.OpenChildForm(new CommunityPage(HomePagePanel, SignedInUser), HomePagePanel);

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            CommonFunctoions.OpenChildForm(new SettingsPage(HomePagePanel,SignedInUser),HomePagePanel);
        }

        private void HomeForm_Click(object sender, EventArgs e)
        {
           
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void iconDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignInForm signIpForm = new SignInForm();
            signIpForm.ShowDialog();
            signIpForm = null;
            this.Show();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            CommonFunctoions.OpenChildForm(new ChannelPage(HomePagePanel, SignedInUser), HomePagePanel);

        }

    }
}
