using System;
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
        public Notes Notes { get; set; }

        /// <summary>
        /// Специальный лсит для хранения элементов NotesListBox.
        /// Будет изменятся в зависимости от выбора CategoryComboBox.
        /// Не нашел как сделать, что бы просто скрывать некоторые элементы из ListBox.
        /// </summary>
        private BindingList<NotesDataSource> _titleList = new BindingList<NotesDataSource>(); 

        public MainForm()
        {
            Notes = new Notes();
            Notes.NotesCollection = new List<Note>();

            InitializeComponent();

            try
            {
                // Выполнение начальной загрузки из файла.
                Notes = SaveLoadNotes.LoadFromFile();
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
            var currentNoteIndex = Notes.CurrentNoteIndex;
            NotesListBox.DataSource = _titleList;
            NotesListBox.DisplayMember = "title"; // => titelList.title Могут быть одинаковые.
            NotesListBox.ValueMember = "note"; // => _titleList.note 
            //*// Даже если title Будут одинаковые NotesListBox.SelectedItem будет указывать на разные обьекты.

            foreach (var category in Enum.GetValues(typeof(NoteCategory)))
            {
                CategoryComboBox.Items.Add(category);
            }

            // Дополнительная категория для формы.
            CategoryComboBox.Items.Add("All");
            CategoryComboBox.SelectedItem = "All";

            if (NotesListBox.Items.Count != 0)
            {
                NotesListBox.SelectedIndex = currentNoteIndex;
            }

            //* Очистка формы.
            //CreatedTimeMaskedTextBox.Text = string.Empty;
            //NameNoteLabel.Text = string.Empty;
            //CategoryChangeableLabel.Text = string.Empty;
            //ModifiedMaskedTextBox.Text = string.Empty;
            //TextNoteRichTextBox1.Text = string.Empty;
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

            List<Note> notesSort = Notes.NotesSortDate();

            // Как я понял по заданию надо было так сделать а не через цикл ниже
            // Проблема в том что у меня не получается првильно ShowNoteCategory преобразовать в NoteCategory.
            // Из-за этого перегруженный метод в Notes не нужен
            //notesSort = CategoryComboBox.SelectedIndex != 0 /*=> Все*/
            //    ? Notes.NotesSortDate((NoteCategory)CategoryComboBox.SelectedItem) : Notes.NotesSortDate();

            notesSort.Reverse();

            // Я думаю что лучше оставить так.
            foreach (var item in notesSort)
            {
                if(CategoryComboBox.SelectedIndex == (int)item.Category
                || Convert.ToString(CategoryComboBox.SelectedItem) == "All" /*=> Все*/)
                {
                    _titleList.Add(new NotesDataSource(item.Title, item));
                }
            }

            if (NotesListBox.Items.Count != 0)
            {
                NotesListBox.SelectedIndex = Notes.CurrentNoteIndex;
            }
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            var addEditNoteForm = new NoteForm();
            var result = addEditNoteForm.ShowDialog();
            
            if (result == DialogResult.OK && addEditNoteForm.Note != null)
            {
                Notes.NotesCollection.Add(addEditNoteForm.Note);
                _titleList.Add(new NotesDataSource(addEditNoteForm.Note.Title, addEditNoteForm.Note));
            }

            // Сохраниние данных при добавлении новой заметки.
            SaveLoadNotes.SaveToFile(Notes);
            
            // Обновление данных в ListBox/ не знаю как лучше можно сделать.
            CategoryComboBox_SelectedIndexChanged(sender, e);

            if (NotesListBox.Items.Count != 0)
            {
                NotesListBox.SelectedIndex = 0;
            }
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Изменение данных формы в зависимости от выбора в NotesListBox.
            if (NotesListBox.SelectedItem != null)
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

                if (NotesListBox.Items.Count != 0)
                {
                    Notes.CurrentNoteIndex = NotesListBox.SelectedIndex;
                }
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
            SaveLoadNotes.SaveToFile(Notes);
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Сохранение данных при закрытии формы.
            SaveLoadNotes.SaveToFile(Notes);
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
            Note valueUnSave = (Note)item.note.Clone();
            
            // Передача данных.
            var addEditNoteForm = new NoteForm(value);
            // Здесь уже измененный value.

            var result = addEditNoteForm.ShowDialog();

            // Сохранение данных при изменении формы.
            SaveLoadNotes.SaveToFile(Notes);

            var currentNoteIndex = Notes.CurrentNoteIndex;

            CategoryComboBox_SelectedIndexChanged(sender, e);

            if (NotesListBox.Items.Count != 0)
            {
                NotesListBox.SelectedIndex = currentNoteIndex;
            }

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
            SaveLoadNotes.SaveToFile(Notes);

            CategoryComboBox_SelectedIndexChanged(sender, e);
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
