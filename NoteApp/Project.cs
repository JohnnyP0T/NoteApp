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
        /// Сортировка листа по дате.
        /// </summary>
        /// <returns>Отсортированный лист</returns>
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
        /// </summary>
        public List<Note> Notes { get; set; } = new List<Note>();

        /// <summary>
        /// Текущая заметка.
        /// При запуске программы будет загружатся последняя выбранная заметка.
        /// </summary>
        public int CurrentIndex { get; set; }
    }
}
