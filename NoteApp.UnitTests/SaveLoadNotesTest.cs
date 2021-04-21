using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.UnitTests
{
    class SaveLoadNotesTest
    {
        private const string FileName = "TestSaveLoad.noteapp";
        private Notes _notes;

        [SetUp]
        public void Setup()
        {
            _notes = new Notes();
            _notes.NotesCollection = new List<Note>();
            var note = new Note();
            note.Title = "title";
            _notes.NotesCollection.Add(note);
        }

        // Тут я считаю нужен только один тест.
        [Test(Description = "Тест сериализации")]
        public void SaveLoadFileTest()
        {
            var expected = true;
            bool actual;
            SaveLoadNotes.SaveToFile(_notes, FileName);
            var loadNotes = SaveLoadNotes.LoadFromFile(FileName);
            var countItem = 0;
            for(int i = 0; i < _notes.NotesCollection.Count; i++)
            {
                if (_notes.NotesCollection[i].Category == loadNotes.NotesCollection[i].Category &&
                    _notes.NotesCollection[i].CreateTime == loadNotes.NotesCollection[i].CreateTime &&
                    _notes.NotesCollection[i].ModifiedTime == loadNotes.NotesCollection[i].ModifiedTime &&
                    _notes.NotesCollection[i].Text == loadNotes.NotesCollection[i].Text &&
                    _notes.NotesCollection[i].Title == loadNotes.NotesCollection[i].Title)
                {
                    ++countItem;
                }
            }
            actual = countItem == _notes.NotesCollection.Count;

            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
