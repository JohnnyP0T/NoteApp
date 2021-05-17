using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NoteApp;
using NUnit.Framework;


namespace NoteAppUnitTest
{
    class ProjectTest
    {
        private Project _notes;

        [TestCase(TestName = "Тест Сетера NotesCollection")]
        public void ProjectTestSetNoteCollection()
        {
            // Setup
            _notes = new Project();
            var note = new Note();
            var expected = new List<Note>();
            expected.Add(note);
            
            // Act
            _notes.NotesCollection = expected;
            
            // Assert
            var actual = _notes.NotesCollection;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест Гетера NotesCollection")]
        public void ProjectTestGetNoteCollection()
        {
            // Setup
            _notes = new Project();
            var note = new Note();
            var expected = new List<Note>();
            expected.Add(note);
            _notes.NotesCollection = expected;
            
            // Act
            var actual = _notes.NotesCollection;
            
            // Assert
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест сетера CurrentNoteIndex")]
        public void ProjectTestSetCurrentNoteIndex()
        {
            // Setup
            var project = new Project();
            int expected = 1;

            // Act
            project.CurrentNoteIndex = expected;

            // Assert
            var actual = project.CurrentNoteIndex;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест гетера CurrentNoteIndex")]
        public void ProjectTestGetCurrentNoteIndex()
        {
            // Setup
            var project = new Project();
            int expected = 1;
            project.CurrentNoteIndex = expected;

            // Act
            var actual = project.CurrentNoteIndex;

            // Assert
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест сориторовки по времени создания")]
        public void ProjectTestNotesSortDate()
        {
            // Setup
            var project = new Project();
            project.NotesCollection = new List<Note>();
            var note1 = new Note();
            var note2 = new Note();
            note1.CreateTime = DateTime.MinValue;
            project.NotesCollection.Add(note1);
            project.NotesCollection.Add(note2);

            // Act
            project.NotesCollection = project.NotesSortDate();

            bool actual = project.NotesCollection[0].CreateTime < project.NotesCollection[1].CreateTime;
            bool expected = true;

            // Assert
            Assert.AreEqual(expected, actual, "тест сработал непрвильно");
        }
    }
}
