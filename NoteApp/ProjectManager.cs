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
    /// </summary>
    public static class ProjectManager
    {

        private const string FileName = "fileSave.NoteApp";

        /// <summary>
        /// Сохранить Заметку.
        /// </summary>
        /// <param name="data"></param>
        public static void SaveToFile(Project data)
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
        public static Project LoadFromFile()
        {
            var serializer = new JsonSerializer();
            try
            {
                using (var sr = new StreamReader(PathFileSaveWithName))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    return (Project)serializer.Deserialize<Project>(reader);
                }
            }
            catch (Exception exception)
            {
                return new Project();
            }
        }

        public static string PathFileSaveWithName { get; set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + FileName;
    }
}
