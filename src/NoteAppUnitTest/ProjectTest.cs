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
        /// <summary>
        /// Проект.
        /// </summary>
        private Project _project;

        [TestCase(TestName = "Тест Сетера NotesCollection")]
        public void ProjectTestSetNoteCollection()
        {
            // Setup
            _project = new Project();
            var note = new Note();
            var expected = new List<Note>();
            expected.Add(note);
            
            // Act
            _project.Notes = expected;
            
            // Assert
            var actual = _project.Notes;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест Гетера NotesCollection")]
        public void ProjectTestGetNoteCollection()
        {
            // Setup
            _project = new Project();
            var note = new Note();
            var expected = new List<Note>();
            expected.Add(note);
            _project.Notes = expected;
            
            // Act
            var actual = _project.Notes;
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест сетера CurrentNoteIndex")]
        public void ProjectTestSetCurrentNoteIndex()
        {
            // Setup
            var project = new Project();
            var expectedNote = new Note();

            // Act
            project.CurrentNote = expectedNote;

            // Assert
            var actualNote = project.CurrentNote;
            Assert.AreEqual(expectedNote, actualNote, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест гетера CurrentNoteIndex")]
        public void ProjectTestGetCurrentNoteIndex()
        {
            // Setup
            var project = new Project();
            var expectedNote = new Note();
            project.CurrentNote = expectedNote;

            // Act
            var actualNote = project.CurrentNote;

            // Assert
            Assert.AreEqual(expectedNote, actualNote, "Тест сработал неправильно");
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
