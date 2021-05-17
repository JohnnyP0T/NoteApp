using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NoteApp;
using System.IO;
using System.Security.Permissions;

namespace NoteAppUnitTest
{
    class ProjectManagerUnitTest
    {
        private const string FileName = "fileSaveForTest.NoteApp";

        // Тут нет сравнения времени потому что при создании нового обьекта оно будет другое
        [TestCase(TestName = "Тест загрузки из файла")]
        public void ProjectManagerTest_LoadNote()
        {
            // Setup
            ProjectManager.PathFileSaveWithName =
                "C:\\Users\\arrog\\source\\repos\\NoteApp\\NoteAppUnitTest\\TestFiles" + "\\" + FileName;
            var expected = new Note();
            expected.Category = NoteCategory.Documents;
            expected.Text = "Text";
            expected.Title = "Title";

            // Act
            var project = ProjectManager.LoadFromFile();
            var actual = project.NotesCollection[0];

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
                Directory.GetCurrentDirectory() + "\\" + FileName;
            var expected = new Note();
            expected.Category = NoteCategory.Documents;
            expected.Text = "Text";
            expected.Title = "Title";
            var project = new Project();
            project.NotesCollection = new List<Note>();
            project.NotesCollection.Add(expected);
            string[] linesFileExpected =
                File.ReadAllLines("C:\\Users\\arrog\\source\\repos\\NoteApp\\NoteAppUnitTest\\TestFiles" + "\\" +
                                  FileName);
            
            // Act
            ProjectManager.SaveToFile(project);

            // Assert
            string[] linesFileActual =
                File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + FileName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(linesFileExpected[4], linesFileExpected[4], "title");
                Assert.AreEqual(linesFileExpected[5], linesFileExpected[5], "category");
                Assert.AreEqual(linesFileExpected[6], linesFileExpected[6], "text");
            });
        }

        [TestCase(TestName = "Тест загрузки из поврежденного файла")]
        public void ProjectManagerTest_LoadBrokeFile()
        {
            // Setup
            string fileName = "fileSaveForTest_Broke.NoteApp";
            ProjectManager.PathFileSaveWithName =
                    "C:\\Users\\arrog\\source\\repos\\NoteApp\\NoteAppUnitTest\\TestFiles" + "\\" + fileName;

            // Act
            var actual = ProjectManager.LoadFromFile();

            // Assert
            Assert.AreEqual(null, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест загрузки в поврежденный файл")]
        public void ProjectManagerTest_SaveBrokeFile()
        {
            // Setup
            string fileName = "fileSaveForTest_Broke.NoteApp";
            ProjectManager.PathFileSaveWithName =
                "C:\\Users\\arrog\\source\\repos\\NoteApp\\NoteAppUnitTest\\TestFiles" + "\\" + fileName;
            var expected = new Note();
            expected.Category = NoteCategory.Documents;
            expected.Text = "Text";
            expected.Title = "Title";
            var project = new Project();
            project.NotesCollection = new List<Note>();
            project.NotesCollection.Add(expected);
            string saveBrokeFile =
                File.ReadAllText("C:\\Users\\arrog\\source\\repos\\NoteApp\\NoteAppUnitTest\\TestFiles" + "\\" +
                                 fileName);

            // Act
            ProjectManager.SaveToFile(project);
            var projectLoaded = ProjectManager.LoadFromFile();
            var actual = projectLoaded.NotesCollection[0];

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.Category, actual.Category, "category");
                Assert.AreEqual(expected.Text, actual.Text, "text");
                Assert.AreEqual(expected.Title, actual.Title, "title");
                Assert.AreEqual(1, projectLoaded.NotesCollection.Count, "поврежденный файл затирается и загружается один новый объект");
            });

            File.WriteAllText("C:\\Users\\arrog\\source\\repos\\NoteApp\\NoteAppUnitTest\\TestFiles" + "\\" + fileName, saveBrokeFile);
        }

    }
}
