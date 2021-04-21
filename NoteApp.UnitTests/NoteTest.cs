using System;
using System.Text;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    public class NoteTest
    {
        private Note _note;

        [SetUp]
        public void Setup()
        {
            _note = new Note();
        }

        [Test(Description = "���������� ���� ������ ��������")]
        [TestCase("Title")]
        [TestCase("Titleeee")]
        public void TestNoteSetTitle(string expected)
        {
            var title = expected;
            _note.Title = title;
            var actual = _note.Title;
            Assert.AreEqual(expected, actual, "����� �������� �����������");
        }

        [Test(Description = "���������� ���� ������ ��������")]
        [TestCase("TitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitle",
            "���������� ����� ������ 50 ��������")]
        public void TestNoteSetTitle_ArgumentException(string wrongTitle, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _note.Title = wrongTitle; },
                message);
        }

        [Test(Description = "���� ������ ��������")]
        [TestCase("CorrectTitle")]
        public void TestNoteGetTitle_CorrectValue(string expected)
        {
            _note.Title = expected;
            var actual = _note.Title;
            Assert.AreEqual(expected, actual, "����� �������� �� ���������");
        }

        [Test(Description = "���� ������ ���������")]
        [TestCase(NoteCategory.���������)]
        public void TestNoteSetCategory_CorrectValue(NoteCategory expected)
        {
            var category = expected;
            _note.Category = category;
            var actual = _note.Category;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        [Test(Description = "���� ������ ���������")]
        [TestCase(NoteCategory.���������)]
        public void TestNoteGetCategory_CorrectValue(NoteCategory expected)
        {
            _note.Category = expected;
            var actual = _note.Category;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        [Test(Description = "���� ������ ������")]
        [TestCase("�����-�� �����")]
        public void TestNoteSetText_CorrectValue(string text)
        {
            var expected = new StringBuilder(text);
            _note.Text = expected;
            var actual = _note.Text;
            Assert.AreEqual(expected, actual, "���� �������� �� ���������");
        }

        [Test(Description = "���� ������ ������")]
        public void TestNoteGetText_CorrectValue()
        {
            var expected = new StringBuilder("CorrectText");
            _note.Text = expected;
            var actual = _note.Text;
            Assert.AreEqual(expected, actual, "���� �������� �� ���������");
        }

        [Test(Description = "���� ������ ������� ��������")]
        public void TestNoteSetCreateTime_CorrectValue()
        {
            _note.CreateTime = DateTime.MaxValue;
            var expected = DateTime.MaxValue;
            var actual = _note.CreateTime;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        [Test(Description = "���� ������ ������� ��������")]
        public void TestNoteGetCreateTime_CorrectValue()
        {
            var expected = DateTime.MaxValue;
            _note.CreateTime = expected;
            var actual = _note.CreateTime;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        [Test(Description = "���� ������ ������� ���������")]
        public void TestNoteSetModifiedTime_CorrectValue()
        {
            _note.ModifiedTime = DateTime.MaxValue;
            var expected = DateTime.MaxValue;
            var actual = _note.ModifiedTime;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        [Test(Description = "���� ������ ������� ���������")]
        public void TestNoteGetModifiedTime_CorrectValue()
        {
            var expected = DateTime.MaxValue;
            _note.ModifiedTime = expected;
            var actual = _note.ModifiedTime;
            Assert.AreEqual(expected, actual, "���� �������� �����������");
        }

        // ����� ���� ������ ��� � ������ Note ��� ���������� ��������� ==.
        [Test(Description = "���� ���������� ��������� clone")]
        public void TestNoteClone_CorrectValue()
        {
            var expected = true;
            var noteClone = _note.Clone();
            bool actual;
            if (_note.Category == noteClone.Category &&
                _note.CreateTime == noteClone.CreateTime &&
                _note.ModifiedTime == noteClone.ModifiedTime &&
                _note.Text == noteClone.Text &&
                _note.Title == noteClone.Title)
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