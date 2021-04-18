using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{

    public partial class MainForm : Form
    {
        public Notes notes { get; set; }

        private BindingList<NotesDataSource> titleList = new BindingList<NotesDataSource>(); 

        private const string nameFileSave = "fileSave.noteapp";

        public MainForm()
        {
            notes = new Notes();
            notes._notesCollection = new List<Note>();

            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(ShowCategoryNote));
            CategoryComboBox.SelectedIndex = 0;
            try
            {
                notes = SaveLoadNotes.LoadFromFile(nameFileSave);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            if(notes != null)
            {
                foreach(var item in notes._notesCollection)
                {
                    titleList.Add(new NotesDataSource(item.Title, item));
                }
            }

            NotesListBox.DataSource = titleList;
            NotesListBox.DisplayMember = "title";
            NotesListBox.ValueMember = "note";

            //
            CreatedTimeMaskedTextBox.Text = string.Empty;
            NameNoteLabel.Text = string.Empty;
            CategoryChangeableLabel.Text = string.Empty;
            ModifiedMaskedTextBox.Text = string.Empty;
            TextNoteRichTextBox1.Text = string.Empty;
            //

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            titleList.Clear();
            if (notes != null)
            {
                foreach (var item in notes._notesCollection)
                {
                    if(Convert.ToString(CategoryComboBox.SelectedItem) == Convert.ToString(item.category)
                    || (ShowCategoryNote)CategoryComboBox.SelectedItem == 0 /*=> Все*/)
                    {
                        titleList.Add(new NotesDataSource(item.Title, item));
                    }
                }
            }
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            var addEditNoteForm = new AddEditNoteForm();
            var result = addEditNoteForm.ShowDialog();
            
            if (result == DialogResult.OK && addEditNoteForm.note != null)
            {
                notes._notesCollection.Add(addEditNoteForm.note);
                titleList.Add(new NotesDataSource(addEditNoteForm.note.Title, addEditNoteForm.note));
            }
            
            SaveLoadNotes.SaveToFile(notes, nameFileSave);
            
            if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(NotesListBox.SelectedItem != null)
            {
                NotesDataSource item = (NotesDataSource)NotesListBox.SelectedItem;
                Note value = item.note;
                CreatedTimeMaskedTextBox.Text = Convert.ToString(value._createTime);
                NameNoteLabel.Text = value.Title;
                CategoryChangeableLabel.Text = Convert.ToString(value.category);
                ModifiedMaskedTextBox.Text = Convert.ToString(value.modifiedTime);
                TextNoteRichTextBox1.Text = Convert.ToString(value.Text);
            }
            else
            {
                CreatedTimeMaskedTextBox.Text = string.Empty;
                NameNoteLabel.Text = string.Empty;
                CategoryChangeableLabel.Text = string.Empty;
                ModifiedMaskedTextBox.Text = string.Empty;
                TextNoteRichTextBox1.Text = string.Empty;
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLoadNotes.SaveToFile(notes, nameFileSave);
            Close();
            return;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveLoadNotes.SaveToFile(notes, nameFileSave);
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            NotesDataSource item = (NotesDataSource)NotesListBox.SelectedItem;
            Note value = item.note;
            Note valueUnSave = item.note.Clone();
            var addEditNoteForm = new AddEditNoteForm(value);
            var result = addEditNoteForm.ShowDialog();
            CategoryComboBox_SelectedIndexChanged(sender, e);

            if (result == DialogResult.Cancel)
            {
                value = valueUnSave;
                return;
            }
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            NotesDataSource item = (NotesDataSource)NotesListBox.SelectedItem;
            Note value = item.note;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить эту заметку: " + value.Title + "?", "Внимание", MessageBoxButtons.OKCancel);
            
            if(result == DialogResult.OK)
            {
                notes._notesCollection.Remove(value);
                titleList.Remove(item);
            }

            SaveLoadNotes.SaveToFile(notes, nameFileSave);

            if (result == DialogResult.Cancel)
            {
                return;
            }
            
        }
    }
}
