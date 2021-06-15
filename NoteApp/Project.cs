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
        public List<Note> SortNotesByDate()
        {
            if (Notes.Count != 0)
            {
                return Notes.OrderBy(x => x.CreateTime).ToList();
            }

            return Notes;
        }

        /// <summary>
        /// Лист с заметками.
        /// Хотел сдлеать словарь, но в нем нельзя хранить одинаковые ключи.
        /// </summary>
        public List<Note> Notes { get; set; } = new List<Note>();

        public int CurrentIndex { get; set; }

    }
}
