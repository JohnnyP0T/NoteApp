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
        /// ������� ��� ������.
        /// </summary>
        private Note _note;

        /// <summary>
        /// ���� � ���� � ������� �������(����� � ��� ��� 1)
        /// </summary>
        private readonly string _bigTextFileName = Directory.GetCurrentDirectory() + @"\TestData\BigText.txt";

        /// <summary>
        /// Setup.
        /// </summary>
        public void Setup()
        {
            _note = new Note();
        }

        [TestCase( "Title", TestName = "���������� ���� ������ ��������")]
        [TestCase("12345678901234567890123456789012345678901234567890", TestName = "���������� ���� ������ �������� 50 ��������")]
        [TestCase("", TestName = "���������� ���� ������ �������� ������ ������")]
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

        [TestCase("TitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitle", TestName = "���������� ���� ������ �������� ������ 50 ��������")]
        [TestCase("123456789012345678901234567890123456789012345678901", TestName = "���������� ���� ������ �������� 51 ��������")]
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

        [TestCase("CorrectTitle", TestName = "���� ������ ��������")]
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

        [TestCase(TestName = "���� ������ �������� ��� ������������� ����")]
        public void TestNoteGetTitle_WithoutInitialization_DefaultTitle()
        {
            // Setup
            Setup();
            var expected = "��� ��������";

            // Act
            var actual = _note.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(NoteCategory.Documents, TestName = "���� ������ ��������� Documents")]
        [TestCase(NoteCategory.Finance, TestName = "���� ������ ��������� Finance")]
        [TestCase(NoteCategory.HealthAndSports, TestName = "���� ������ ��������� HealthAndSports")]
        [TestCase(NoteCategory.Home, TestName = "���� ������ ��������� Home")]
        [TestCase(NoteCategory.Other, TestName = "���� ������ ��������� Other")]
        [TestCase(NoteCategory.People, TestName = "���� ������ ��������� People")]
        [TestCase(NoteCategory.Work, TestName = "���� ������ ��������� Work")]
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

        [TestCase(NoteCategory.Documents, TestName = "���� ������ ���������")]
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

        [TestCase(TestName = "���� ������ ��������� ��� �������������")]
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

        [TestCase("�����-�� �����", TestName = "���� ������ ������")]
        [TestCase("", TestName = "���� ������ ������ ������ �����")]
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

        [TestCase(TestName = "���� ������ ������ ������� �����")]
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

        [TestCase("CorrectText", TestName = "���� ������ ������")]
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

        [TestCase(TestName = "���� ������ ������ ��� ������������� ����")]
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

        [TestCase(TestName = "���� ������ ������� ��������")]
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

        [TestCase(TestName = "���� ������ ������� ��������")]
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

        // ���������� � ���� �����, ��� ��� �� �� ��������� ���� ���� �������� �� ������� ����� ������ ������ Setup.
        [TestCase(TestName = "���� ������ ������� �������� ��� ������������ ����. " +
                             "������ ���� ����� �������� ������ ����� ������ Setup()")]
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

        [TestCase(TestName = "���� ������ ������� ���������")]
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

        [TestCase(TestName = "���� ������ ������� ��������� ��� ������������� ����")]
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

        [TestCase(TestName = "���� ������ ������� ���������")]
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

        [Test(Description = "���� ���������� ��������� clone")]
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