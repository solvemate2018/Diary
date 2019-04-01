using DiaryApp.Data;
using DiaryApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryApp.Controllers
{
    public class NoteController
    {
        public User currentUser;
        public BindingSource Notes = new BindingSource();

        public void SetCurrentUser(User user)
        {
            currentUser = user;

            using (var context = new DiaryContext())
            {
                currentUser.ID = context.Users.Single(x => x.Username == user.Username).ID;

                currentUser.Notes.AddRange(context.Notes.Where(x => x.UserID == currentUser.ID));
            }
        }

        public object GetBindingSource()
        {
            using (var context = new DiaryContext())
            {
                Notes.DataSource = context.Notes.Where(x => x.UserID == currentUser.ID).ToList();
            }
            return Notes;
        }

        public void SaveNote(string title, string text)
        {
            Note note = new Note(title, text);

            using (var context = new DiaryContext())
            {
                if (context.Notes.Select(x => x.Title).Contains(title))
                {
                    throw new ArgumentException("You have already the same title!");
                }
                context.Users.Single(x => x.ID == currentUser.ID).Notes.Add(note);
                context.SaveChanges();
            }
            currentUser.Notes.Add(note);
            Notes.DataSource = currentUser.Notes;
        }

        internal string GetText(string title)
        {
            using (var context = new DiaryContext())
            {
                return context.Notes.Single(x => x.Title == title).Text;
            }
        }
    }
}
