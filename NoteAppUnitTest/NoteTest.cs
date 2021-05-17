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

        [TestCase( "Title", TestName = "���������� ���� ������ ��������")]
        [TestCase("Titleeee", TestName = "���������� ���� ������ ��������")]
        public void TestNoteSetTitle(string expected)
        {
            Setup();
            var title = expected;
            _note.Title = title;
            var actual = _note.Title;
            Assert.AreEqual(expected, actual, "����� �������� �����������");
        }

        [TestCase("TitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitle",
            "���������� ����� ������ 50 ��������", TestName = "���������� ���� ������ ��������")]
        public void TestNoteSetTitle_ArgumentException(string wrongTitle, string message)
        {
            Setup();
            Assert.Throws<ArgumentException>(
                () => { _note.Title = wrongTitle; },
                message);
        }

        [TestCase("CorrectTitle", TestName = "���� ������ ��������")]
        public void TestNoteGetTitle_CorrectValue(string expected)
        {
            Setup();
            _note.Title = expected;
            var actual = _note.Title;
            Assert.AreEqual(expected, actual, "����� �������� �� ���������");
        }

        [TestCase(NoteCategory.Documents, TestName = "���� ������ ���������")]
        public void TestNoteSetCategory_CorrectValue(NoteCategory expected)
        {
            Setup();
            var category = expected;
            _note.Category = category;
            var actual = _note.Category;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        [TestCase(NoteCategory.Documents, TestName = "���� ������ ���������")]
        public void TestNoteGetCategory_CorrectValue(NoteCategory expected)
        {
            Setup();
            _note.Category = expected;
            var actual = _note.Category;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }
        
        [TestCase("�����-�� �����", TestName = "���� ������ ������")]
        public void TestNoteSetText_CorrectValue(string text)
        {
            Setup();
            var expected = text;
            _note.Text = expected;
            var actual = _note.Text;
            Assert.AreEqual(expected, actual, "���� �������� �� ���������");
        }

        [TestCase(TestName = "���� ������ ������")]
        public void TestNoteGetText_CorrectValue()
        {
            Setup();
            var expected = "CorrectText";
            _note.Text = expected;
            var actual = _note.Text;
            Assert.AreEqual(expected, actual, "���� �������� �� ���������");
        }

        [TestCase(TestName = "���� ������ ������� ��������")]
        public void TestNoteSetCreateTime_CorrectValue()
        {
            Setup();
            _note.CreateTime = DateTime.MaxValue;
            var expected = DateTime.MaxValue;
            var actual = _note.CreateTime;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        [TestCase(TestName = "���� ������ ������� ��������")]
        public void TestNoteGetCreateTime_CorrectValue()
        {
            Setup();
            var expected = DateTime.MaxValue;
            _note.CreateTime = expected;
            var actual = _note.CreateTime;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        [TestCase(TestName = "���� ������ ������� ���������")]
        public void TestNoteSetModifiedTime_CorrectValue()
        {
            Setup();
            _note.ModifiedTime = DateTime.MaxValue;
            var expected = DateTime.MaxValue;
            var actual = _note.ModifiedTime;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        [TestCase(TestName = "���� ������ ������� ���������")]
        public void TestNoteGetModifiedTime_CorrectValue()
        {
            Setup();
            var expected = DateTime.MaxValue;
            _note.ModifiedTime = expected;
            var actual = _note.ModifiedTime;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        // ����� ���� ������ ��� � ������ Note ��� ���������� ��������� ==.
        [Test(Description = "���� ���������� ��������� clone")]
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
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

    }
}