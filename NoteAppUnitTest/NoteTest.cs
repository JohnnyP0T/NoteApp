using System;
using System.Text;
using NoteApp;
using NUnit.Framework;

namespace NoteAppUnitTest
{
    public class NoteTest
    {
        private Note _note;

        public void Setup()
        {
            _note = new Note();
        }

        [TestCase( "Title", TestName = "Позитивный тест сетера названия")]
        [TestCase("Titleeee", TestName = "Позитивный тест сетера названия")]
        public void TestNoteSetTitle(string expected)
        {
            Setup();
            var title = expected;
            _note.Title = title;
            var actual = _note.Title;
            Assert.AreEqual(expected, actual, "Сетер сработал неправильно");
        }

        [TestCase("TitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitle",
            "Присвоение имени больше 50 символов", TestName = "Негативный тест сетера названия")]
        public void TestNoteSetTitle_ArgumentException(string wrongTitle, string message)
        {
            Setup();
            Assert.Throws<ArgumentException>(
                () => { _note.Title = wrongTitle; },
                message);
        }

        [TestCase("CorrectTitle", TestName = "Тест гетера названия")]
        public void TestNoteGetTitle_CorrectValue(string expected)
        {
            Setup();
            _note.Title = expected;
            var actual = _note.Title;
            Assert.AreEqual(expected, actual, "Гетер сработал не правильно");
        }

        [TestCase(NoteCategory.Documents, TestName = "Тест сетера категории")]
        public void TestNoteSetCategory_CorrectValue(NoteCategory expected)
        {
            Setup();
            var category = expected;
            _note.Category = category;
            var actual = _note.Category;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(NoteCategory.Documents, TestName = "Тест гетера категории")]
        public void TestNoteGetCategory_CorrectValue(NoteCategory expected)
        {
            Setup();
            _note.Category = expected;
            var actual = _note.Category;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }
        
        [TestCase("какой-то текст", TestName = "Тест сетера текста")]
        public void TestNoteSetText_CorrectValue(string text)
        {
            Setup();
            var expected = text;
            _note.Text = expected;
            var actual = _note.Text;
            Assert.AreEqual(expected, actual, "Тест сработал не правильно");
        }

        [TestCase(TestName = "Тест гетера текста")]
        public void TestNoteGetText_CorrectValue()
        {
            Setup();
            var expected = "CorrectText";
            _note.Text = expected;
            var actual = _note.Text;
            Assert.AreEqual(expected, actual, "Тест сработал не правильно");
        }

        [TestCase(TestName = "Тест сетера времени создания")]
        public void TestNoteSetCreateTime_CorrectValue()
        {
            Setup();
            _note.CreateTime = DateTime.MaxValue;
            var expected = DateTime.MaxValue;
            var actual = _note.CreateTime;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест гетера времени создания")]
        public void TestNoteGetCreateTime_CorrectValue()
        {
            Setup();
            var expected = DateTime.MaxValue;
            _note.CreateTime = expected;
            var actual = _note.CreateTime;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест сетера времени изменения")]
        public void TestNoteSetModifiedTime_CorrectValue()
        {
            Setup();
            _note.ModifiedTime = DateTime.MaxValue;
            var expected = DateTime.MaxValue;
            var actual = _note.ModifiedTime;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        [TestCase(TestName = "Тест гетера времени изменения")]
        public void TestNoteGetModifiedTime_CorrectValue()
        {
            Setup();
            var expected = DateTime.MaxValue;
            _note.ModifiedTime = expected;
            var actual = _note.ModifiedTime;
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

        // Такой тест потому что у класса Note нет перегрузки оператора ==.
        [Test(Description = "Тест реализации интерфеса clone")]
        public void TestNoteClone_CorrectValue()
        {
            Setup();
            var expected = true;
            var noteClone = (Note)_note.Clone();
            bool actual;
            if (_note == noteClone)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }
            Assert.AreEqual(expected, actual, "Тест сработал неправильно");
        }

    }
}