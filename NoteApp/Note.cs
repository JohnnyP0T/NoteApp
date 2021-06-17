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
        /// Текст заметки.
        /// </summary>
        private string _text;

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

        public static bool operator ==(Note note1, Note note2)
        {
            return Object.Equals(note1, note2);
        }

        public static bool operator !=(Note note1, Note note2)
        {
            return !Object.Equals(note1, note2);
        }

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

        public bool Equals(Note other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _title == other._title && _text == other._text && Category == other.Category && CreateTime.Equals(other.CreateTime) && ModifiedTime.Equals(other.ModifiedTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Note) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_title != null ? _title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_text != null ? _text.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Category;
                hashCode = (hashCode * 397) ^ CreateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ ModifiedTime.GetHashCode();
                return hashCode;
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
    }
}
