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
    public class Notes
    {
        /// <summary>
        /// Лист с заметками.
        /// Хотел сдлеать словарь, но в нем нельзя хранить одинаковые ключи.
        /// </summary>
        public List<Note> NotesCollection { get; set; }
    }
}
