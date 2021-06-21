using System;
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
    public partial class NoteForm : Form
    {
        /// <summary>
        /// Свойство для передачи новой\измененной заметки.
        /// </summary>
        public Note Note { get; set; }

        /// <summary>
        /// Конструктор с параметром для передачи заметки.
        /// </summary>
        /// <param name="note"></param>
        public NoteForm(Note note)
        {
            InitializeComponent();
            if (note == null)
            {
                note = new Note();
            }
            TitleTextBox.Text = note.Title;

            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CategoryComboBox.SelectedItem = note.Category;

            Note = note;
            CreatedTimeMaskedTextBox.Text = Convert.ToString(note.CreateTime);
            TextNoteRichTextBox.Text = note.Text;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                Note.Title = TitleTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
                TitleTextBox.BackColor = Color.LightSalmon;
                return;
            }

            Note.Text = TextNoteRichTextBox.Text;
            Note.Category = (NoteCategory)CategoryComboBox.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
