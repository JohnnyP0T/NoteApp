using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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

        [TestCase(TestName = "Тест сориторовки по времени создания пустого листа")]
        public void ProjectTestNotesSortDate_EmptyList()
        {
            // Setup
            var actualProject = new Project();
            var expectedCount = 0;

            // Act
            actualProject.Notes = actualProject.SortNotesByDate();

            // Assert
            Assert.AreEqual(expectedCount, actualProject.Notes.Count);
        }

        [TestCase(TestName = "Тест сориторовки по времени создания")]
        public void ProjectTestNotesSortDate()
        {
            // Setup
            var actualProject = new Project();
            var date = new RandomDateTime();

            for (int i = 0; i < 1000; i++)
            {
                actualProject.Notes.Add(new Note() { CreateTime = date.Next() });
            }

            var expectedProject = new Project();
            expectedProject.Notes = actualProject.Notes.OrderBy(x => x.CreateTime).ToList();

            // Act
            actualProject.Notes = actualProject.SortNotesByDate();

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
    }
}
