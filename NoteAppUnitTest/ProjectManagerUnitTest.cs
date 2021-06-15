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
        private const string CorrectFileProjectFileName = @"\TestData\correctprojectfile.NoteApp";

        private Project GetCorrectProject()
        {
            //TODO
            var project = new Project();
            var note = new Note();
            note.Category = NoteCategory.Documents;
            note.CreateTime = new DateTime(1999, 10, 12, 13, 12, 4);
            note.Text = "Text";
            note.Title = "Title";
            note.ModifiedTime = new DateTime(1999, 10, 12, 13, 12, 4);
            project.Notes.Add(note);
            var note2 = new Note();
            note2.Category = NoteCategory.Finance;
            note2.CreateTime = new DateTime(2021, 3, 13, 1, 2, 3);
            note2.Text = "SomeText";
            note2.Title = "SomeTitle";
            note2.ModifiedTime = new DateTime(2021, 3, 13, 1, 2, 3);
            project.Notes.Add(note2);
            return project;
        }

        [TestCase(Description = "Positive project manager get test", TestName = "Project manager get test")]
        public void ProjectManagerGetTest()
        {
            var project = GetCorrectProject();

            ProjectManager.PathFileSaveWithName = "correctprojectfile.NoteApp";
            ProjectManager.SaveToFile(project);
        }
        
        private const string FileName = "fileSaveForTest.NoteApp";

        // Тут нет сравнения времени потому что при создании нового обьекта оно будет другое
        [TestCase(TestName = "Тест загрузки из файла")]
        public void ProjectManagerTest_LoadNote()
        {
            // Setup
            ProjectManager.PathFileSaveWithName =
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\TestFiles\\" + FileName;
            var expected = new Note();
            expected.Category = NoteCategory.Documents;
            expected.Text = "Text";
            expected.Title = "Title";

            // Act
            var project = ProjectManager.LoadFromFile();
            var actual = project.Notes[0];

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.Category, actual.Category, "category");
                Assert.AreEqual(expected.Text, actual.Text, "text");
                Assert.AreEqual(expected.Title, actual.Title, "title");
            });
        }

        [TestCase(TestName = "Тест загрузки в файл")]
        public void ProjectManagerTest_SaveNote()
        {
            // Setup
            ProjectManager.PathFileSaveWithName =
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\TestFiles\\" + FileName;
            var expected = new Note();
            expected.Category = NoteCategory.Documents;
            expected.Text = "Text";
            expected.Title = "Title";
            var project = new Project();
            project.Notes.Add(expected);
            string[] linesFileExpected =
                File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName 
                                  + "\\TestFiles\\" + FileName);
            
            // Act
            ProjectManager.SaveToFile(project);

            // Assert
            string[] linesFileActual =
                File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\TestFiles\\" + FileName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(linesFileExpected[3], linesFileActual[3], "title");
                Assert.AreEqual(linesFileExpected[4], linesFileActual[4], "category");
                Assert.AreEqual(linesFileExpected[5], linesFileActual[5], "text");
            });
        }

        [TestCase(TestName = "Тест загрузки из поврежденного файла")]
        public void ProjectManagerTest_LoadBrokeFile()
        {
            // Setup
            string fileName = "fileSaveForTest_Broke.NoteApp";
            ProjectManager.PathFileSaveWithName =
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\TestFiles\\" + fileName;

            // Act
            var actual = ProjectManager.LoadFromFile();

            // Assert
            Assert.AreEqual(0, actual.Notes.Count, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест загрузки в поврежденный файл")]
        public void ProjectManagerTest_SaveBrokeFile()
        {
            // Setup
            string fileName = "fileSaveForTest_Broke.NoteApp";
            ProjectManager.PathFileSaveWithName =
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\TestFiles\\" + fileName;
            var expected = new Note();
            expected.Category = NoteCategory.Documents;
            expected.Text = "Text";
            expected.Title = "Title";
            var project = new Project();
            project.Notes = new List<Note>();
            project.Notes.Add(expected);
            string saveBrokeFile =
                File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\TestFiles\\" +
                                 fileName);

            // Act
            ProjectManager.SaveToFile(project);
            var projectLoaded = ProjectManager.LoadFromFile();
            var actual = projectLoaded.Notes[0];

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.Category, actual.Category, "category");
                Assert.AreEqual(expected.Text, actual.Text, "text");
                Assert.AreEqual(expected.Title, actual.Title, "title");
                Assert.AreEqual(1, projectLoaded.Notes.Count, "поврежденный файл затирается и загружается один новый объект");
            });

            File.WriteAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\TestFiles\\" + fileName, saveBrokeFile);
        }

    }
}
