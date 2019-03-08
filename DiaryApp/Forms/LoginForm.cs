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

        private void SignInButton_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.TextLength == 0 || PasswordTextBox.TextLength == 0)
            {
                MessageBox.Show("Please, enter valid username and password!", "Messege");
            }
            else
            {
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;
                User user = new User(username, password);
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
