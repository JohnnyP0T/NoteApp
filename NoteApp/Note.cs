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
    public class Note : ICloneable, IEquatable<Note>
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
            get => _title;

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
        private string _text;


        /// <summary>
        /// Гетер и сетер текста.
        /// </summary>
        public string Text
        {
            get => _text;
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
        public Object Clone()
        {
            var note = new Note();
            note.Title = this.Title;
            note.Category = this.Category;
            note.Text = this.Text;
            note.ModifiedTime = this.ModifiedTime;
            note.CreateTime = this.CreateTime;
            return note;
        }


        public override bool Equals(object other)
            => other is Note otherNote && Equals(otherNote);

        public bool Equals(Note other)
        {
            return Title == other.Title && Category == other.Category && Text == other.Text &&
                   ModifiedTime == other.ModifiedTime && CreateTime == other.CreateTime;
        }

        public static bool operator ==(Note note1, Note note2)
        {
            return Object.Equals(note1, note2);
        }

        public static bool operator !=(Note note1, Note note2)
        {
            return !Object.Equals(note1, note2);
        }
    }
}
