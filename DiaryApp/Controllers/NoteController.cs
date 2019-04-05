using DiaryApp.Data;
using DiaryApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryApp.Controllers
{
    public class NoteController
    {
        private DiaryContext context;
        public User currentUser;

        //<summary>
        //  Binding Source for the DataGridView
        //</summary>
        public BindingSource Notes = new BindingSource();

        //<summary>
        // Constructor, in which the context is set
        //</summary>
        public NoteController(DiaryContext context)
        {
            this.context = context;
        }

        //<summary>
        //  Setting current User and setting his ID and Notes
        //</summary>
        public void SetCurrentUser(User user)
        {
            currentUser = user;

            currentUser.ID = context.Users.Single(x => x.Username == user.Username).ID;

            currentUser.Notes.AddRange(context.Notes.Where(x => x.UserID == currentUser.ID));
        }

        //<summary>
        //  Setting the notes of the current User
        //  in the Binding source and returning it.
        //</summary>
        public object GetBindingSource()
        {
            Notes.DataSource = context.Notes.Where(x => x.UserID == currentUser.ID).ToList();
            return Notes;
        }

        //<summary>
        //  Saving the given title and text as a Note 
        //  and updating the data source of the binding source.
        //</summary>
        public void SaveNote(string title, string text)
        {
            Note note = new Note(title, text);
            if (context.Notes.Select(x => x.Title).Contains(title))
            {
                throw new ArgumentException("You have already the same title!");
            }
            context.Users.Single(x => x.ID == currentUser.ID).Notes.Add(note);
            context.SaveChanges();
            currentUser.Notes.Add(note);
            Notes.DataSource = currentUser.Notes;
        }

        //<summary>
        //  Returns the text of a given title.
        //</summary>
        public string GetText(string title)
        {
            return context.Notes.Single(x => x.Title == title).Text;
        }

        //<summary>
        //  Deleting Note, with given index from the binding source,
        //  from current user and from the DB.
        //</summary>
        public void DeleteNote(int index)
        {
            Note note = currentUser.Notes[index];
            currentUser.Notes.Remove(note);
            context.Notes.Remove(context.Notes.Single(x => x.ID == note.ID));
            context.SaveChanges();
            Notes.DataSource = currentUser.Notes;
        }
    }
}
