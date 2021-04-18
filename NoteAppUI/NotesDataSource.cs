using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp;

namespace NoteAppUI
{
    /// <summary>
    /// Данные для отображения на NotesListBox.
    /// NotesListBox.DisplayMember = "title".
    /// NotesListBox.ValueMember = "note".
    /// </summary>
    class NotesDataSource
    {
        public Note note { get; set; }
        public string title { get; set; }

        public NotesDataSource(string title, Note note)
        {
            this.note = note;
            this.title = title;
        }
    }
}
