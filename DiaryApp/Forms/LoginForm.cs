using DiaryApp.Controllers;
using DiaryApp.Data.Models;
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
        UserController UserController = new UserController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            bool canLogin = false;
            try
            {
                canLogin = UserController.Login(username, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            if (canLogin)
            {
                this.Close();
                Form MainForm = new MainWindow(username, password);
                MainForm.Show();
            }

        }

        private void ClosingButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegistrationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form registrationForm = new RegistrationForm();
            this.Close();
            registrationForm.Show();
        }

        private void LoginWindow_Close(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
