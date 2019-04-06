using DiaryApp.Data;
using DiaryApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DiaryApp.Controllers
{
    public class UserController
    {
        private DiaryContext context;

        public UserController(DiaryContext context)
        {
            this.context = context;
        }

        //<summary>
        // Checking if the user can login with the given info.
        //</summary>
        public bool Login(string username, string password)
        {
            if (!context.Users.Select(x => x.Username).Contains(username))
            {
                throw new ArgumentException("Incorrect Username");
            }
            else if (context.Users.Where(x => x.Username == username).First().Password != password)
            {
                throw new ArgumentException("Incorrect password");
            }
            else
            {
                return true;
            }
        }

        //<summary>
        // Checking the information for registering and adding the User into the DB.
        //</summary>
        public bool Registrate(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("Passwords do not match");
            }

            if (context.Users.Select(x => x.Username).Contains(username))
            {
                throw new ArgumentException("User is already registrated");
            }
            else if (username.Count() < 4)
            {
                throw new ArgumentException("Username must be at least 4 letters");
            }
            else if (password.Count() < 4)
            {
                throw new ArgumentException("Password must be at least 4 letters");
            }
            else
            {
                context.Users.Add(new User(username, password));
                context.SaveChanges();
            }

            return true;
        }

    }
}
