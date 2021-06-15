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
            _notes.Notes = expected;
            
            // Assert
            var actual = _notes.Notes;
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
            _notes.Notes = expected;
            
            // Act
            var actual = _notes.Notes;
            
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
            project.CurrentIndex = expected;

            // Assert
            var actual = project.CurrentIndex;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест гетера CurrentNoteIndex")]
        public void ProjectTestGetCurrentNoteIndex()
        {
            // Setup
            var project = new Project();
            int expected = 1;
            project.CurrentIndex = expected;

            // Act
            var actual = project.CurrentIndex;

            // Assert
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест сориторовки по времени создания")]
        public void ProjectTestNotesSortDate()
        {
            // Setup
            var project = new Project();
            project.Notes = new List<Note>();
            var note1 = new Note();
            var note2 = new Note();
            note1.CreateTime = DateTime.MinValue;
            project.Notes.Add(note1);
            project.Notes.Add(note2);

            // Act
            project.Notes = project.SortNotesByDate();

            bool actual = project.Notes[0].CreateTime < project.Notes[1].CreateTime;
            bool expected = true;

            // Assert
            Assert.AreEqual(expected, actual, "тест сработал непрвильно");
        }
    }
}
