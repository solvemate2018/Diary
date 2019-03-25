using DiaryApp.Data;
using DiaryApp.Data.Models;
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
            Note currentNote = (Note)DBContext.Notes.Where(x => x.ID == index);
            return currentNote.Title;
        }

        public string GetText(int index)
        {
            Note currentNote = (Note)DBContext.Notes.Where(x => x.ID == index);
            return currentNote.Text;
        }

        public void DeleteNote(int index)
        {
            Note currentNote = (Note)DBContext.Notes.Where(x => x.ID == index);
            DBContext.Notes.Remove(currentNote);
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }
    }
}
