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
        NoteController NoteController = new NoteController();

        public MainWindow(string username, string password)
        {
            InitializeComponent(username);
            NoteController.SetCurrentUser(new User(username, password));
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            TitleBox.Clear();
            MessegeBox.Clear();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var title = TitleBox.Text;
            var text = MessegeBox.Text;

            try
            {
                NoteController.SaveNote(title, text);
            }
            catch (ArgumentException exeption)
            {
                MessageBox.Show(exeption.Message, "Error");
            }
            
            NotesGridView1.DataSource = NoteController.GetBindingSource();

            if (NotesGridView1.DataSource != null)
            {
                NotesGridView1.Columns["Id"].Visible = false;
                NotesGridView1.Columns["UserId"].Visible = false;
                NotesGridView1.Columns["Text"].Visible = false;
            }
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            string title = NotesGridView1.CurrentCell.Value.ToString();
            TitleBox.Text = title;
            MessegeBox.Text = NoteController.GetText(title);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            NotesGridView1.DataSource = NoteController.GetBindingSource();
            if (NotesGridView1.DataSource != null)
            {
                NotesGridView1.Columns["Id"].Visible = false;
                NotesGridView1.Columns["UserId"].Visible = false;
                NotesGridView1.Columns["Text"].Visible = false;
            }
        }
    }
}
