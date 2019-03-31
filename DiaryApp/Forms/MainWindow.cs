using DiaryApp.Controllers;
using DiaryApp.Data;
using DiaryApp.Data.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class MainWindow : Form
    {
        DiaryContext context = new DiaryContext();
        NoteController NoteController = new NoteController();
        public MainWindow(User currentUser)
        {
            InitializeComponent(currentUser.Username);
            NoteController.SetCurrentUser(currentUser);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            TitleBox.Clear();
            MessegeBox.Clear();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            NoteController.AddNote(new Note(TitleBox.Text, MessegeBox.Text));

            TitleBox.Clear();
            MessegeBox.Clear();
            NotesGridView1.DataSource = NoteController.GetDataSourceForGridView();
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            int index = NotesGridView1.CurrentCell.RowIndex;

            if (index > -1)
            {
                TitleBox.Text = NoteController.GetTitle(index);
                MessegeBox.Text = NoteController.GetText(index);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int index = NotesGridView1.CurrentCell.RowIndex;
            NoteController.DeleteNote(index);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            NotesGridView1.DataSource = NoteController.GetDataSourceForGridView();
        }
    }
}
