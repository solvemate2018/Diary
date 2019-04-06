using DiaryApp.Controllers;
using System;
using System.Windows.Forms;

namespace DiaryApp.Forms
{
    public partial class LoginForm : Form
    {
        UserController UserController = new UserController(new Data.DiaryContext());

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
                this.Hide();
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
            this.Hide();
            registrationForm.Show();
        }

        private void LoginWindow_Close(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
