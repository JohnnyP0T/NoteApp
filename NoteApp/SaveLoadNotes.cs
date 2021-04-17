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
    /// </summary>
    class SaveLoadNotes
    {
        /// <summary>
        /// Путь сохранения файла.
        /// </summary>
        private const string _fileSave = "..\\My Documents\\NoteApp.notes";

        /// <summary>
        /// Сохранить Заметку.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename"></param>
        public static void SaveToFile(Notes data, string filename)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(_fileSave + filename))
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
        public static Note LoadFromFile(string filename)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(_fileSave + filename))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return (Note)serializer.Deserialize<Note>(reader);
            }
        }
    }
}
