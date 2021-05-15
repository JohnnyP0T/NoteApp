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
    public static class SaveLoadNotes
    {
        private static readonly string fileName = "fileSave.NoteApp";

        public static string PathFileSaveWithName { get; set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + fileName;

        /// <summary>
        /// Сохранить Заметку.
        /// </summary>
        /// <param name="data"></param>
        public static void SaveToFile(Notes data)
        {
            var serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            using (var sw = new StreamWriter(PathFileSaveWithName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Загрузить заметку.
        /// </summary>
        /// <returns></returns>
        public static Notes LoadFromFile()
        {
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(PathFileSaveWithName))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return (Notes)serializer.Deserialize<Notes>(reader);
            }
        }
    }
}
