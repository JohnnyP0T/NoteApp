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
    public partial class AddEditNoteForm : Form
    {
        /// <summary>
        /// Ограничение длинны названия.
        /// </summary>
        private const int LimitLengthName = 50;

        /// <summary>
        /// Свойство для передачи новой\измененной заметки.
        /// </summary>
        public Note Note { get; set; }

        /// <summary>
        /// Конструктор с параметром для передачи заметки.
        /// </summary>
        /// <param name="note"></param>
        public AddEditNoteForm(Note note)
        {
            InitializeComponent();
            TitleTextBox.Text = note.Title;

            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CategoryComboBox.SelectedItem = note.Category;

            this.Note = note;
            CreatedTimeMaskedTextBox.Text = Convert.ToString(note.CreateTime);
            TextNoteRichTextBox.Text = note.Text.ToString();
        }

        public AddEditNoteForm()
        {
            InitializeComponent();
            TitleTextBox.Text = "Без названия";
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CategoryComboBox.SelectedIndex = 0;
            Note = new Note();
            CreatedTimeMaskedTextBox.Text = Convert.ToString(Note.CreateTime);
            if(Note.ModifiedTime != DateTime.MinValue)
            {
                ModifiedMaskedTextBox.Text = Convert.ToString(Note.ModifiedTime);
            }

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Note.Text = new StringBuilder(TextNoteRichTextBox.Text);
            if(TitleTextBox.Text != string.Empty)
            {
                Note.Title = TitleTextBox.Text;
            }
            Note.Category = (NoteCategory)CategoryComboBox.SelectedItem;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TitleTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (TitleTextBox.Text.Length > LimitLengthName)
            {
                MessageBox.Show("Длинна названия не может быть больше 50");
                TitleTextBox.BackColor = Color.LightSalmon;
                OkButton.Enabled = false;
            }
            else
            {
                TitleTextBox.BackColor = Color.White;
                OkButton.Enabled = true;
            }
        }

        private void AddEditNoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(this, "Вы уверенны что хотите выйти?", "Внимание", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.OK)
            {
                Note = null;
                DialogResult = DialogResult.Cancel;
                Close();
            }

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
