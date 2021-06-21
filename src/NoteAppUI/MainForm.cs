﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{

    public partial class MainForm : Form
    {
        /// <summary>
        /// Поле формы для хранения обьектов.
        /// </summary>
        public Project Project { get; set; } 

        public MainForm()
        {
            Project = new Project();

            InitializeComponent();
            
            Project = ProjectManager.LoadFromFile();

            foreach (var category in Enum.GetValues(typeof(NoteCategory)))
            {
                CategoryComboBox.Items.Add(category);
            }

            CategoryComboBox.Items.Add("All");
            CategoryComboBox.SelectedItem = "All";
            
            FillNotesListBox();

            if (Project.Notes.Count != 0)
            {
                NotesListBox.SelectedItem = Project.CurrentNote;
            }
        }

        /// <summary>
        /// Заполнение NotesListBox.
        /// </summary>
        /// <param name="notes">Проект для заполнения</param>
        private void FillNotesListBox()
        {
            if (Project.Notes.Count == 0)
            {
                ClearRightPanel();
                NotesListBox.Items.Clear();
                Project.CurrentNote = null;
                return;
            }
            NotesListBox.Items.Clear();

            Project.Notes = Project.SortNotesByDate();
            Project.Notes.Reverse();

            foreach (var note in Project.Notes)
            {
                if ((note.Category.ToString() == CategoryComboBox.SelectedItem.ToString()) 
                    || CategoryComboBox.SelectedItem.ToString() == "All")
                {
                    NotesListBox.Items.Add(note);
                }
            }

            NotesListBox.DisplayMember = "note.Title"; 
            NotesListBox.ValueMember = "note";
        }

        /// <summary>
        /// Очистка правой панели.
        /// </summary>
        private void ClearRightPanel()
        {
            CreatedTimeMaskedTextBox.Text = string.Empty;
            NameNoteLabel.Text = string.Empty;
            CategoryChangeableLabel.Text = string.Empty;
            ModifiedMaskedTextBox.Text = string.Empty;
            TextNoteRichTextBox1.Text = string.Empty;
        }

        private void FillRightPanel(Note note)
        {
            CreatedTimeMaskedTextBox.Text = Convert.ToString(note.CreateTime);
            NameNoteLabel.Text = note.Title;
            CategoryChangeableLabel.Text = Convert.ToString(note.Category);
            ModifiedMaskedTextBox.Text = Convert.ToString(note.ModifiedTime);
            TextNoteRichTextBox1.Text = Convert.ToString(note.Text);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillNotesListBox();
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            var noteForm = new NoteForm(null);
            var result = noteForm.ShowDialog();
            
            if (result == DialogResult.OK && noteForm.Note != null)
            {
                Project.Notes.Add(noteForm.Note);
                FillNotesListBox();
                if (CategoryComboBox.SelectedItem.ToString() != "All")
                {
                    CategoryComboBox.SelectedItem = noteForm.Note.Category;
                }
                NotesListBox.SelectedItem = noteForm.Note;
            }

            ProjectManager.SaveToFile(Project);
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem != null)
            {
                Note note = (Note)NotesListBox.SelectedItem;

                FillRightPanel(note);

                if (NotesListBox.Items.Count != 0)
                {
                    Project.CurrentNote = (Note)NotesListBox.SelectedItem;
                }
            }
            else
            {
                ClearRightPanel();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveToFile(Project);
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveToFile(Project);
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            var note = (Note)NotesListBox.SelectedItem;
            var cloneNote = (Note)note.Clone();
            var addEditNoteForm = new NoteForm(note);
            if (addEditNoteForm.ShowDialog() == DialogResult.Cancel)
            {
                note = cloneNote;
            }
            ProjectManager.SaveToFile(Project);
            if (CategoryComboBox.SelectedItem.ToString() != "All")
            {
                CategoryComboBox.SelectedItem = note.Category;
            }
            FillNotesListBox();
            NotesListBox.SelectedItem = note;
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }
            var note = (Note)NotesListBox.SelectedItem;
            var result = MessageBox.Show("Are you sure want to delete this note: " + note.Title + "?", "Attention", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                Project.Notes.Remove(note);
            }
            ProjectManager.SaveToFile(Project);
            FillNotesListBox();
            if (NotesListBox.Items.Count != 0)
            {
                NotesListBox.SelectedIndex = 0;
            }
            else
            {
                ClearRightPanel();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveNoteButton.PerformClick();
            }
        }
    }
}