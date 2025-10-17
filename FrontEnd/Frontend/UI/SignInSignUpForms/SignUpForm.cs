using SecSemesterProjOOP.BL;
using SecSemesterProjOOP.DLInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOPProject.Utilities;




namespace OOPProject.UI.SignInSignUpForms

{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            User user = new User(guna2TextBox1.Text,guna2TextBox2.Text,guna2TextBox3.Text,guna2TextBox5.Text);
            bool check=ObjectHandler.GetUserDL().SignUp(user);
            if (check==false)
            {
                CommonMessageBox m = new CommonMessageBox();
                m.SetLabelText("Account Already Exists !");
                m.ShowDialog();
            }
            else
            {
                CommonMessageBox m = new CommonMessageBox();
                m.SetLabelText("Account Made Successfully !");
                m.ShowDialog();
                this.Hide();
                SignInForm signIpForm = new SignInForm();
                signIpForm.ShowDialog();
                signIpForm = null;
                this.Show();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //hide this form
            this.Hide();
            //create an instance of SignUpForm
            SignInForm signInForm = new SignInForm();
            //show signin form
            signInForm.ShowDialog();
            signInForm = null;
            this.Show();
        }
    }
}
