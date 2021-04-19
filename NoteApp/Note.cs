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
    public class Note : ICloneable
    {
        /// <summary>
        /// Лимит количества символов названия.
        /// </summary>
        private const int LimitLengthName = 50;

        /// <summary>
        /// Название заметки.
        /// </summary>
        private string _title = "Без названия";

        /// <summary>
        /// Гетер и сетер для названия.
        /// </summary>
        public string Title 
        {
            get 
            {
                return _title;
            }

            set
            {
                if(value.Length > LimitLengthName)
                {
                    throw new ArgumentException("Имя больше 50 символов");
                }

                _title = value;
            }
        }

        /// <summary>
        /// Категория заметки.
        /// </summary>
        public NoteCategory Category { get; set; }

        /// <summary>
        /// Текст заметки.
        /// </summary>
        private StringBuilder _text;


        /// <summary>
        /// Гетер и сетер текста.
        /// </summary>
        public StringBuilder Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                ModifiedTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Время создания заметки.
        /// </summary>
        //public readonly DateTime _createTime = DateTime.Now;
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Время последнего изменения заметки.
        /// </summary>
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        /// Реализация интерфейса ICloneable.
        /// </summary>
        /// <returns></returns>
        public Note Clone()
        {
            var note = new Note();
            note.Title = this.Title;
            note.Category = this.Category;
            note.Text = this.Text;
            note.ModifiedTime = this.ModifiedTime;
            return note;
        }
    }
}
