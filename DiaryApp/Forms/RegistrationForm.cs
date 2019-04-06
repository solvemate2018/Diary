using DiaryApp.Controllers;
using System;
using System.Windows.Forms;

namespace DiaryApp.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private UserController UserController = new UserController(new Data.DiaryContext());

        private void ClosingButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegistrateButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string confirmPassword = ConfirmPasswordBox.Text;

            bool isRegistrated = false;

            try
            {
                isRegistrated = UserController.Registrate(username, password, confirmPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            if (isRegistrated)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                MessageBox.Show("You have been registrated", "Messege");
            }
        }

        private void RegistrationWindow_Close(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
