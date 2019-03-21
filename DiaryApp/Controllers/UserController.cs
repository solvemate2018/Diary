using DiaryApp.Data;
using DiaryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp.Controllers
{
    public class UserController
    {
        DiaryContext DBContext = new DiaryContext();

        Dictionary<string, string> Username_Password = new Dictionary<string, string>();


        public bool Login(User user)
        {

            GetUsers();

            if (user.Username == "" || user.Password == "")
            {
                throw new ArgumentNullException("Enter valid data");
            }

            else if (!Username_Password.ContainsKey(user.Username))
            {
                throw new ArgumentException("There is no such Account");
            }

            else if (!Username_Password.ContainsValue(user.Password))
            {
                throw new ArgumentException("Incorrect Password");
            }

            else
            {
                return true;
            }
        }

        public bool Registrate(string username, string password, string confirmPassword)
        {
            GetUsers();

            if (password != confirmPassword)
            {
                throw new ArgumentException("Passwords are different");
            }

            else if (Username_Password.ContainsKey(username))
            {
                throw new ArgumentException("The User is already registrated");
            }

            else
            {
                DBContext.Users.Add(new User(username, password));
                DBContext.SaveChanges();
                return true;
            }
        }

        private void GetUsers()
        {
            Username_Password = new Dictionary<string, string>();
            foreach (User user in DBContext.Users)
            {
                Username_Password.Add(user.Username, user.Password);
            }
        }
    }
}
