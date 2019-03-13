using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp.Controllers
{
    class Controller
    {
        public void CheckLogin(string username, string password)
        {
            try
            {
                CheckData(username, password);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public void Registrating(string username, string password, string confirmationPassword)
        {
            try
            {
                CheckData(username, password);
            }
            catch (ArgumentException)
            {
                throw;
            }
            if (password == confirmationPassword)
            {
                throw new ArgumentException("Passwords don't match.");
            }

        }

        private void CheckData(string username, string password)
        {
            string exceptionMessege = "Please, enter valid data.";

            if (username == "" || password == "")
            {
                throw new ArgumentException(exceptionMessege);
            }
        }
    }
}
