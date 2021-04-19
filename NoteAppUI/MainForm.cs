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
        /// <summary>
        /// Поле формы для хранения обьектов.
        /// </summary>
        public Notes Notes { get; set; }

        /// <summary>
        /// Специальный лсит для хранения элементов NotesListBox.
        /// Будет изменятся в зависимости от выбора CategoryComboBox.
        /// Не нашел как сделать, что бы просто скрывать некоторые элементы из ListBox.
        /// </summary>
        private BindingList<NotesDataSource> _titleList = new BindingList<NotesDataSource>(); 

        /// <summary>
        /// Имя файла для сохранения.
        /// </summary>
        private const string NameFileSave = "fileSave.noteapp";

        public MainForm()
        {
            Notes = new Notes();
            Notes.NotesCollection = new List<Note>();

            InitializeComponent();
            // Тут нужно новое перечисление, 
            // потому что NoteCategory логически не может содержать элемент All.
            CategoryComboBox.DataSource = Enum.GetValues(typeof(ShowCategoryNote));
            CategoryComboBox.SelectedIndex = 0; /*=> все*/

            try
            {
                // Выполнение начальной загрузки из файла.
                Notes = SaveLoadNotes.LoadFromFile(NameFileSave);
            }
            catch (Exception exception) // Если файла не будет в нужнем каталоге.
            {
                MessageBox.Show(exception.Message);
            }

            if(Notes != null && Notes.NotesCollection != null)
            {
                foreach(var item in Notes.NotesCollection)
                {
                    _titleList.Add(new NotesDataSource(item.Title, item));
                }
            }
            else // Если кто то удалит сохраняемый файл или очистит его.
            {
                Notes = new Notes();
                Notes.NotesCollection = new List<Note>();
            }

            //* Биндинг данных.
            NotesListBox.DataSource = _titleList;
            NotesListBox.DisplayMember = "title"; // => titelList.title Могут быть одинаковые.
            NotesListBox.ValueMember = "note"; // => _titleList.note 
            //*// Даже если title Будут одинаковые NotesListBox.SelectedItem будет указывать на разные обьекты.

            //* Очистка формы.
            CreatedTimeMaskedTextBox.Text = string.Empty;
            NameNoteLabel.Text = string.Empty;
            CategoryChangeableLabel.Text = string.Empty;
            ModifiedMaskedTextBox.Text = string.Empty;
            TextNoteRichTextBox1.Text = string.Empty;
            //*

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Выполняется очистка листа и новое заполнение 
            // при каждой смене CategoryComboBox.
            _titleList.Clear();

            // Предостерижение.
            if (Notes == null)
            {
                return;
            }

            foreach (var item in Notes.NotesCollection)
            {
                if(Convert.ToString(CategoryComboBox.SelectedItem) == Convert.ToString(item.Category)
                || (ShowCategoryNote)CategoryComboBox.SelectedItem == 0 /*=> Все*/)
                {
                    _titleList.Add(new NotesDataSource(item.Title, item));
                }
            }
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            var addEditNoteForm = new AddEditNoteForm();
            var result = addEditNoteForm.ShowDialog();
            
            if (result == DialogResult.OK && addEditNoteForm.Note != null)
            {
                Notes.NotesCollection.Add(addEditNoteForm.Note);
                _titleList.Add(new NotesDataSource(addEditNoteForm.Note.Title, addEditNoteForm.Note));
            }
            
            // Сохраниние данных при добавлении новой заметки.
            SaveLoadNotes.SaveToFile(Notes, NameFileSave);
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Изменение данных формы в зависимости от выбора в NotesListBox.
            if(NotesListBox.SelectedItem != null)
            {
                //* Сомневаюсь в этом участке кода.
                // Так не работает.
                // Note value = (NotesDataSource)NotesListBox.SelectedItem.note;
                NotesDataSource item = (NotesDataSource)NotesListBox.SelectedItem;
                Note value = item.note;
                //*

                CreatedTimeMaskedTextBox.Text = Convert.ToString(value.CreateTime);
                NameNoteLabel.Text = value.Title;
                CategoryChangeableLabel.Text = Convert.ToString(value.Category);
                ModifiedMaskedTextBox.Text = Convert.ToString(value.ModifiedTime);
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
            // Сохранение данных при закрытии формы.
            SaveLoadNotes.SaveToFile(Notes, NameFileSave);
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Сохранение данных при закрытии формы.
            SaveLoadNotes.SaveToFile(Notes, NameFileSave);
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                return;
            }

            NotesDataSource item = (NotesDataSource)NotesListBox.SelectedItem;
            Note value = item.note;
            
            // Если пользователь нажмет Cancel.
            // Копия обьекта.
            Note valueUnSave = item.note.Clone();
            
            // Передача данных.
            var addEditNoteForm = new AddEditNoteForm(value);
            // Здесь уже измененный value.

            var result = addEditNoteForm.ShowDialog();
            CategoryComboBox_SelectedIndexChanged(sender, e);

            if (result == DialogResult.Cancel)
            {
                // Отмена изменений.
                value = valueUnSave;
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
            // Предупреждение.
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить эту заметку: " + value.Title + "?", "Внимание", MessageBoxButtons.OKCancel);
            
            if(result == DialogResult.OK)
            {
                Notes.NotesCollection.Remove(value);
                _titleList.Remove(item);
            }

            // Сохранение данных при удалении обьекта.
            SaveLoadNotes.SaveToFile(Notes, NameFileSave);
        }
    }
}
