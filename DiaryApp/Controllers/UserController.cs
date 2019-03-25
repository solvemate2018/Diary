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

        public User currentUser;


        public bool Login(User user)
        {

            if (user.Username == "" || user.Password == "")
            {
                throw new ArgumentNullException("Enter valid data");
            }

            else if (!DBContext.Users.Contains(user))
            {
                throw new ArgumentException("There is no such account");
            }
            else
            {
                currentUser = user;
                return true;
            }
        }

        public bool Registrate(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("Passwords are different");
            }

            else if (DBContext.Users.Contains(new User(username, password)))
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

    }
}
