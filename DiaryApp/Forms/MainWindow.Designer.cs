using System;
using DiaryApp.Data.Models;

namespace DiaryApp.Forms
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(string username)
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.MessegeLabel = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.MessegeBox = new System.Windows.Forms.TextBox();
            this.NotesGridView1 = new System.Windows.Forms.DataGridView();
            this.NewButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ReadButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NotesGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(23, 121);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(35, 17);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title";
            // 
            // MessegeLabel
            // 
            this.MessegeLabel.AutoSize = true;
            this.MessegeLabel.Location = new System.Drawing.Point(23, 179);
            this.MessegeLabel.Name = "MessegeLabel";
            this.MessegeLabel.Size = new System.Drawing.Size(65, 17);
            this.MessegeLabel.TabIndex = 1;
            this.MessegeLabel.Text = "Messege";
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(96, 118);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(297, 22);
            this.TitleBox.TabIndex = 2;
            // 
            // MessegeBox
            // 
            this.MessegeBox.Location = new System.Drawing.Point(96, 172);
            this.MessegeBox.Multiline = true;
            this.MessegeBox.Name = "MessegeBox";
            this.MessegeBox.Size = new System.Drawing.Size(297, 196);
            this.MessegeBox.TabIndex = 3;
            // 
            // NotesGridView1
            // 
            this.NotesGridView1.AllowUserToOrderColumns = false;
            this.NotesGridView1.ReadOnly = true;
            this.NotesGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NotesGridView1.Location = new System.Drawing.Point(470, 118);
            this.NotesGridView1.Name = "NotesGridView1";
            this.NotesGridView1.RowTemplate.Height = 24;
            this.NotesGridView1.Size = new System.Drawing.Size(333, 250);
            this.NotesGridView1.TabIndex = 4;
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(96, 415);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 5;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(318, 415);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ReadButton
            // 
            this.ReadButton.Location = new System.Drawing.Point(470, 415);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(75, 23);
            this.ReadButton.TabIndex = 7;
            this.ReadButton.Text = "Read";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(728, 415);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(363, 9);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(139, 31);
            this.UsernameLabel.TabIndex = 9;
            this.UsernameLabel.Text = username;
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(871, 486);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ReadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.NotesGridView1);
            this.Controls.Add(this.MessegeBox);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.MessegeLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_Close);
            ((System.ComponentModel.ISupportInitialize)(this.NotesGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label MessegeLabel;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.TextBox MessegeBox;
        private System.Windows.Forms.DataGridView NotesGridView1;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ReadButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label UsernameLabel;
    }
}