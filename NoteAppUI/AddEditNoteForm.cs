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
        private const int _limitLengthName = 50;

        public Note note { get; set; }

        public AddEditNoteForm(Note note)
        {
            InitializeComponent();
            TitleTextBox.Text = note.Title;

            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CategoryComboBox.SelectedItem = note.category;

            this.note = note;
            CreatedTimeMaskedTextBox.Text = Convert.ToString(note._createTime);
            TextNoteRichTextBox.Text = note.Text.ToString();
        }

        public AddEditNoteForm()
        {
            InitializeComponent();
            TitleTextBox.Text = "Без названия";
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CategoryComboBox.SelectedIndex = 0;
            note = new Note();
            CreatedTimeMaskedTextBox.Text = Convert.ToString(note._createTime);
            if(note.modifiedTime != DateTime.MinValue)
            {
                ModifiedMaskedTextBox.Text = Convert.ToString(note.modifiedTime);
            }

        }

        private void AddEditNoteForm_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            note.Text = new StringBuilder(TextNoteRichTextBox.Text);
            if(TitleTextBox.Text != string.Empty)
            {
                note.Title = TitleTextBox.Text;
            }
            note.category = (NoteCategory)CategoryComboBox.SelectedItem;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TitleTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (TitleTextBox.Text.Length > _limitLengthName)
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
                note = null;
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
