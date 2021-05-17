using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс который хранит заметки в листе.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Лист с заметками.
        /// Хотел сдлеать словарь, но в нем нельзя хранить одинаковые ключи.
        /// </summary>
        public List<Note> NotesCollection { get; set; }

        private List<Note> _notesSortDate = new List<Note>();

        public int CurrentNoteIndex { get; set; }

        public List<Note> NotesSortDate()
        {
            return _notesSortDate = this.NotesCollection.OrderBy(x => x.CreateTime).ToList();
        }
    }
}
