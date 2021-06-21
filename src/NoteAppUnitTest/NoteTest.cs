using System;
using System.IO;
using System.Text;
using NoteApp;
using NUnit.Framework;

namespace NoteAppUnitTest
{
    public class NoteTest
    {
        /// <summary>
        /// Заметка для тестов.
        /// </summary>
        private Note _note;

        /// <summary>
        /// Путь к фалу с большим текстом(Война и мир том 1)
        /// </summary>
        private readonly string _bigTextFileName = Directory.GetCurrentDirectory() + @"\TestData\BigText.txt";

        /// <summary>
        /// Setup.
        /// </summary>
        public void Setup()
        {
            _note = new Note();
        }

        [TestCase( "Title", TestName = "Позитивный тест сетера названия")]
        [TestCase("12345678901234567890123456789012345678901234567890", TestName = "Позитивный тест сетера названия 50 символов")]
        [TestCase("", TestName = "Позитивный тест сетера названия пустая строка")]
        public void TestNoteSetTitle_CorrectValue(string expected)
        {
            // Setup
            Setup();
            var title = expected;

            // Act
            _note.Title = title;
                        
            // Assert
            var actual = _note.Title;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("TitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitle", TestName = "Негативный тест сетера названия больше 50 символов")]
        [TestCase("123456789012345678901234567890123456789012345678901", TestName = "Негативный тест сетера названия 51 символов")]
        public void TestNoteSetTitle_UncorrectValue_ArgumentException(string wrongTitle)
        {
            // Setup
            Setup();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                {
                    _note.Title = wrongTitle;
                });
        }

        [TestCase("CorrectTitle", TestName = "Тест гетера названия")]
        public void TestNoteGetTitle_CorrectValue(string expected)
        {
            // Setup
            Setup();
            _note.Title = expected;

            // Act
            var actual = _note.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест гетера названия без инициализации поля")]
        public void TestNoteGetTitle_WithoutInitialization_DefaultTitle()
        {
            // Setup
            Setup();
            var expected = "Без названия";

            // Act
            var actual = _note.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(NoteCategory.Documents, TestName = "Тест сетера категории Documents")]
        [TestCase(NoteCategory.Finance, TestName = "Тест сетера категории Finance")]
        [TestCase(NoteCategory.HealthAndSports, TestName = "Тест сетера категории HealthAndSports")]
        [TestCase(NoteCategory.Home, TestName = "Тест сетера категории Home")]
        [TestCase(NoteCategory.Other, TestName = "Тест сетера категории Other")]
        [TestCase(NoteCategory.People, TestName = "Тест сетера категории People")]
        [TestCase(NoteCategory.Work, TestName = "Тест сетера категории Work")]
        public void TestNoteSetCategory_CorrectValue(NoteCategory expected)
        {
            // Setup
            Setup();
            var category = expected;

            // Act
            _note.Category = category;

            // Assert
            var actual = _note.Category;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(NoteCategory.Documents, TestName = "Тест гетера категории")]
        public void TestNoteGetCategory_CorrectValue(NoteCategory expected)
        {
            // Setup
            Setup();
            _note.Category = expected;
            
            // Act
            var actual = _note.Category;
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест гетера категории без инициализации")]
        public void TestNoteGetCategory_WithoutInitialization_DefaultValue()
        {
            // Setup
            Setup();
            var expected = NoteCategory.Other;

            // Act
            var actual = _note.Category;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("какой-то текст", TestName = "Тест сетера текста")]
        [TestCase("", TestName = "Тест сетера текста пустой текст")]
        public void TestNoteSetText_CorrectValue(string text)
        {
            // Setup
            Setup();
            var expected = text;
           
            // Act
            _note.Text = expected;
            
            // Assert
            var actual = _note.Text;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест сетера текста большой текст")]
        public void TestNoteSetText_SetBigText_CorrectValue()
        {
            // Setup
            Setup();
            var expected = File.ReadAllText(_bigTextFileName);

            // Act
            _note.Text = expected;

            // Assert
            var actual = _note.Text;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("CorrectText", TestName = "Тест гетера текста")]
        public void TestNoteGetText_CorrectValue(string expected)
        {
            // Setup
            Setup();
            _note.Text = expected;
            
            // Act
            var actual = _note.Text;
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест гетера текста без инициализации поля")]
        public void TestNoteGetText_WithoutInitialization_DefaultValue()
        {
            // Setup
            Setup();
            var expected = string.Empty;

            // Act
            var actual = _note.Text;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест сетера времени создания")]
        public void TestNoteSetCreateTime_CorrectValue()
        {
            // Setup
            Setup();
            
            // Act
            _note.CreateTime = DateTime.MaxValue;
            
            // Assert
            var expected = DateTime.MaxValue;
            var actual = _note.CreateTime;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест гетера времени создания")]
        public void TestNoteGetCreateTime_CorrectValue()
        {
            // Setup
            Setup();
            var expected = DateTime.MaxValue;
            _note.CreateTime = expected;
            
            // Act
            var actual = _note.CreateTime;
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        // Сомневаюсь в этом тесте, так как он не сработает если тест залагает на моменте после вызова метода Setup.
        [TestCase(TestName = "Тест гетера времени создания без инциализации поля. " +
                             "Должно быть время создания тоесть время вызова Setup()")]
        public void TestNoteGetCreateTime_WithoutInitialization_CorrectValue()
        {
            // Setup
            Setup();
            var expected = DateTime.Now;

            // Act
            var actual = _note.CreateTime;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест сетера времени изменения")]
        public void TestNoteSetModifiedTime_CorrectValue()
        {
            // Setup
            Setup();
            
            // Act
            _note.ModifiedTime = DateTime.MaxValue;
            
            // Assert
            var expected = DateTime.MaxValue;
            var actual = _note.ModifiedTime;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест гетера времени изменения без инициализации поля")]
        public void TestNoteGetModifiedTime_WithoutInitialization_CorrectValue()
        {
            // Setup
            Setup();
            var expected = DateTime.MinValue;

            // Act
            var actual = _note.ModifiedTime;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Тест гетера времени изменения")]
        public void TestNoteGetModifiedTime_CorrectValue()
        {
            // Setup
            Setup();
            var expected = DateTime.MaxValue;
            _note.ModifiedTime = expected;
            
            // Act
            var actual = _note.ModifiedTime;
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест реализации интерфеса clone")]
        public void TestNoteClone_CorrectValue()
        {
            // Setup
            Setup();
            var noteExpected = _note;

            // Act
            var noteCloneActual = (Note)_note.Clone();

            // Assert
            Assert.AreEqual(noteExpected, noteCloneActual);
        }
    }
}