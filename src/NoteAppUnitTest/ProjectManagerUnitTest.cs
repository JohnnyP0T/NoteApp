using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NoteApp;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Security.Permissions;

namespace NoteAppUnitTest
{
    class ProjectManagerUnitTest
    {
        /// <summary>
        /// Путь к эталонному корректному файлу.
        /// </summary>
        private readonly string _correctProjectFileName = Directory.GetCurrentDirectory() + @"\TestData\correctprojectfile.NoteApp";
        
        /// <summary>
        /// Путь к эталонному некорректному файлу.
        /// </summary>
        private readonly string _uncorrectProjectFileName = Directory.GetCurrentDirectory() + @"\TestData\uncorrectprojectfile.NoteApp";
        
        /// <summary>
        /// Путь для сохранения тестового файла.
        /// </summary>
        private readonly string _outputProjectFileName = Directory.GetCurrentDirectory() + @"\Output\savedfile.NoteApp";
        
        /// <summary>
        /// Несуществующий файл.
        /// </summary>
        private readonly string _nonExsistProjectFileName = Directory.GetCurrentDirectory() + @"\nonExsistenFile.NoteApp";

        /// <summary>
        /// Получение корректного проекта, такой же в эталонном файле.
        /// </summary>
        /// <returns>Корректный проект</returns>
        private Project GetCorrectProject()
        {
            //TODO
            var project = new Project();
            var note = new Note
            {
                Category = NoteCategory.Documents,
                CreateTime = new DateTime(1999, 10, 12, 13, 12, 4),
                Text = "Text",
                Title = "Title",
                ModifiedTime = new DateTime(1999, 10, 12, 13, 12, 4)
            };
            project.Notes.Add(note);
            var note2 = new Note
            {
                Category = NoteCategory.Finance,
                CreateTime = new DateTime(2021, 3, 13, 1, 2, 3),
                Text = "SomeText",
                Title = "SomeTitle",
                ModifiedTime = new DateTime(2021, 3, 13, 1, 2, 3)
            };
            project.Notes.Add(note2);
            return project;
        }

        [TestCase(Description = "Загрузка корректного файла")]
        public void LoadFromFile_SaveCorrectData_FileSaveCorrectly()
        {
            // Setup
            var expectedProject = GetCorrectProject();

            ProjectManager.PathFileSaveWithName = _correctProjectFileName;

            // Act
            var actualProject = ProjectManager.LoadFromFile();

            // Assert
            Assert.AreEqual(expectedProject.Notes.Count, actualProject.Notes.Count);
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expectedProject.Notes.Count; i++)
                {
                    var expected = expectedProject.Notes[i];
                    var actual = actualProject.Notes[i];

                    Assert.AreEqual(expected, actual);
                }
            });
        }

        [TestCase(Description = "Чтение корректного файла")]
        public void SaveToFile_SaveCorrectData_FileSaveCorrectly()
        {
            // Setup
            var savingProject = GetCorrectProject();
            ProjectManager.PathFileSaveWithName = _outputProjectFileName;
            
            if (File.Exists(_outputProjectFileName))
            {
                File.Delete(_outputProjectFileName);
            }

            if (!Directory.Exists("Output"))
            {
                Directory.CreateDirectory("Output");
            }

            // Act
            ProjectManager.SaveToFile(savingProject);

            // Assert
            var actual = File.ReadAllText(_outputProjectFileName);
            var expected = File.ReadAllText(_correctProjectFileName);

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Чтение поврежденного файла")]
        public void LoadFromFile_LoadBrokenFile_NewEmptyProject()
        {
            // Setup
            ProjectManager.PathFileSaveWithName = _uncorrectProjectFileName;

            // Act
            var actualProject = ProjectManager.LoadFromFile();

            // Assert
            Assert.AreEqual(0, actualProject.Notes.Count);
        }

        [Test(Description = "Попытка считать несуществующий файл")]
        public void LoadFromFile_NonexistentFile_NewEmptyProject()
        {
            // Setup
            ProjectManager.PathFileSaveWithName = _nonExsistProjectFileName;
            
            // Act
            var actualProject = ProjectManager.LoadFromFile();

            // Assert
            Assert.AreEqual(0, actualProject.Notes.Count);
        }
    }
}
