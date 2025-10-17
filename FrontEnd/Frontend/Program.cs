using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecSemesterProjOOP.BL;
using FontAwesome.Sharp;
using OOPProject.UI;
using System.Text.RegularExpressions;
using OOPProject.UI.SignInSignUpForms;
using OOPProject.UI.Settings;

//using SecSemesterProjOOP.DL;

namespace OOPProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //UserPage2 userPage2 = new UserPage2();
            SignInForm signInForm = new SignInForm();
           //AddGroupPage g=new AddGroupPage();

           
            
            Application.Run(signInForm);
            
        }
    }
}
