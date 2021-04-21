using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    class NotesTest
    {
        private Notes _notes;

        [SetUp]
        public void Setup()
        {
            _notes = new Notes();
        }

        [Test(Description = "Тест Сетера NotesCollection")]
        public void NotesTestSetNoteCollection()
        {
            var note = new Note();
            note.Title = "Title";
            var expected = new List<Note>();
            expected.Add(note);
            _notes.NotesCollection = expected;
            var actual = _notes.NotesCollection;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [Test(Description = "Тест Гетера NotesCollection")]
        public void NotesTestGetNoteCollection()
        {
            var note = new Note();
            note.Title = "Title";
            var expected = new List<Note>();
            expected.Add(note);
            _notes.NotesCollection = expected;
            var actual = _notes.NotesCollection;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }
    }
}
