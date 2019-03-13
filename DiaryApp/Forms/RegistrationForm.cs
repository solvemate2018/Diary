using DiaryApp.Controllers;
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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        Controller controller = new Controller();

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;
            string confirmPassword = ConfirmPasswordBox.Text;

            try
            {
                controller.Registrating(username, password, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Messege");
            }
        }
    }
}
