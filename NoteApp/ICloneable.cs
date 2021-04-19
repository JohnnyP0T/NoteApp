using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Интерфейс для создания клонов. 
    /// Что бы разные обьекты не указывали на одну и ту же область памяти.
    /// </summary>
    public interface ICloneable
    {
        /// <summary>
        /// Метод клонирования.
        /// </summary>
        /// <returns></returns>
        Note Clone();
    }
}
