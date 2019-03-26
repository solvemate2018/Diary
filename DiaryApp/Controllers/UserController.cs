using DiaryApp.Data;
using DiaryApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp.Controllers
{
    public class UserController
    {
        DiaryContext Context = new DiaryContext();

        public User currentUser;


        public bool Login(User user)
        {
            if (user.Username == "" || user.Password == "")
            {
                throw new ArgumentNullException("Enter valid data");
            }
            else if (Context.Users.Where(x => x.Username.Contains(user.Username)).Count() == 0 && Context.Users.Where(x => x.Username.Contains(user.Username)).First().Password != user.Password)
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
            User user = new User(username, password);

            if (password != confirmPassword)
            {
                throw new ArgumentException("Passwords are different");
            }
            else if (Context.Users.Where(x => x.Username.Contains(user.Username)).Count() == 0)
            {
                throw new ArgumentException("The User is already registrated");
            }

            else
            {
                Context.Users.Add(user);
                Context.SaveChanges();
                return true;
            }
        }

    }
}
