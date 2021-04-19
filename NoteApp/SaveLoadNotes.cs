using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoteApp
{
    /// <summary>
    /// Сохраниение заметок.
    /// Json формат.
    /// Файл сохранения: C:\\Users\\arrog\\source\\repos\\NoteApp\\SaveFile\\
    /// </summary>
    public class SaveLoadNotes
    {
        /// <summary>
        /// Путь сохранения файла.
        /// </summary>
        private const string FileSave = "C:\\Users\\arrog\\source\\repos\\NoteApp\\SaveFile\\";

        /// <summary>
        /// Сохранить Заметку.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename"></param>
        public static void SaveToFile(Notes data, string filename)
        {
            var serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            using (var sw = new StreamWriter(FileSave + filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Загрузить заметку.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Notes LoadFromFile(string filename)
        {
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(FileSave + filename))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return (Notes)serializer.Deserialize<Notes>(reader);
            }
        }
    }
}
