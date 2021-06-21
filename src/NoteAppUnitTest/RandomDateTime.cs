using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteAppUnitTest
{
    /// <summary>
    /// Класс для генерации рандомной даты.
    /// </summary>
    class RandomDateTime
    {
        /// <summary>
        /// Start.
        /// </summary>
        private readonly DateTime _start;

        /// <summary>
        /// Random.
        /// </summary>
        private readonly Random _gen;

        /// <summary>
        /// Range.
        /// </summary>
        private readonly int _range;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public RandomDateTime()
        {
            _start = new DateTime(1995, 1, 1);
            _gen = new Random();
            _range = (DateTime.Today - _start).Days;
        }

        /// <summary>
        /// Генерация рандомной даты.
        /// </summary>
        /// <returns>Рандомная дата.</returns>
        public DateTime Next()
        {
            return _start.AddDays(_gen.Next(_range)).AddHours(_gen.Next(0, 24)).AddMinutes(_gen.Next(0, 60)).AddSeconds(_gen.Next(0, 60));
        }
    }
}
