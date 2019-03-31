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
    public class NoteController
    {
        DiaryContext DBContext = new DiaryContext();

        public User currentUser;

        public string GetTitle(int index)
        {
            Note currentNote = DBContext.Notes.Single(x => x.ID == index);
            return currentNote.Title;
        }

        public string GetText(int index)
        {
            Note currentNote = DBContext.Notes.Single(x => x.ID == index);
            return currentNote.Text;
        }

        public void DeleteNote(int index)
        {
            Note currentNote = DBContext.Notes.Single(x => x.ID == index);
            DBContext.Notes.Remove(currentNote);
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }

        public void AddNote(Note currentNote)
        {
            currentUser.Notes.Add(currentNote);
            DBContext.Notes.Add(currentNote);
            DBContext.SaveChanges();
        }

        public object GetDataSourceForGridView()
        {
            if (currentUser.Notes.Count == 0)
            {
                return new List<string> { "Nothing here" };
            }
            return DBContext.Notes.Where(note => note.ID == currentUser.Notes.First().ID).Select(note => note.Title).ToList();
        }
    }
}
