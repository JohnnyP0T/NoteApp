using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Заметка.
    /// </summary>
    class Note
    {
        /// <summary>
        /// Лимит количества символов названия.
        /// </summary>
        private const int _limitLengthName = 50;

        /// <summary>
        /// Название заметки.
        /// </summary>
        private string _name; //= "Без названия";

        /// <summary>
        /// Гетер и сетер для названия.
        /// </summary>
        public string Name 
        {
            get 
            {
                return _name;
            }

            set
            {
                if(value.Length > _limitLengthName)
                {
                    throw new ArgumentException("Имя больше 50 символов");
                }

                _name = value;
            }
        }

        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NoteCategoty _category { get; set; }

        /// <summary>
        /// Текст заметки.
        /// </summary>
        private StringBuilder _text { get; set; }

        /// <summary>
        /// Время создания заметки.
        /// </summary>
        public readonly DateTime _createTime = DateTime.Now;

        /// <summary>
        /// Время последнего изменения заметки.
        /// </summary>
        private DateTime _lastChangeTime { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="noteCategory"></param>
        /// <param name="name"> По умолчанию "Без названия"</param>
        public Note(NoteCategoty noteCategory, string name = "Без названия") 
            => _category = noteCategory;
    }
}
