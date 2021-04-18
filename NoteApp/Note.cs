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
        private const int _limitLengthName = 50;

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
                if(value.Length > _limitLengthName)
                {
                    throw new ArgumentException("Имя больше 50 символов");
                }

                _title = value;
            }
        }

        /// <summary>
        /// Категория заметки.
        /// </summary>
        public NoteCategory category { get; set; }

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
                modifiedTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Время создания заметки.
        /// </summary>
        public readonly DateTime _createTime = DateTime.Now;

        /// <summary>
        /// Время последнего изменения заметки.
        /// </summary>
        public DateTime modifiedTime { get; set; }

        public Note Clone()
        {
            var note = new Note();
            note.Title = this.Title;
            note.category = this.category;
            note.Text = this.Text;
            note.modifiedTime = this.modifiedTime;
            return note;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="noteCategory"></param>
        /// <param name="name"> По умолчанию "Без названия"</param>
        //public Note(NoteCategory noteCategory) => category = noteCategory;
    }
}
