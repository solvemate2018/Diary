using DiaryApp.Controllers;
using DiaryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        Controller controller = new Controller();

        private void SignInButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            try
            {
                controller.CheckLogin(username, password);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Messege");
            }
        }

        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form registrationForm = new RegistrationForm();
            this.Close();
            registrationForm.Show();
        }
    }
}
