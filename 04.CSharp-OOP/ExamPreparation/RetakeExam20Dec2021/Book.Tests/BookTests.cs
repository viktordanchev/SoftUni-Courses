using NUnit.Framework;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Book.Tests
{
    public class Tests
    {
        Book book;
        private string bookName;
        private string author;

        [SetUp]
        public void Setup()
        {
            bookName = "Harry Potter";
            author = "J.K. Rowling";
            book = new Book(bookName, author);
        }

        [Test]
        public void Constructor_MakeNewBookProperly()
        {
            bookName = "Start with Why";
            author = "Simon Sinek";
            book = new Book(bookName, author);

            Assert.AreEqual(bookName, book.BookName);
            Assert.AreEqual(author, book.Author);
        }

        [Test]
        public void BookNameProperty_IfIsNullOrEmptyShouldThrowException()
        {
            bookName = string.Empty;

            Assert.Throws<ArgumentException>(() => book = new Book(bookName, author));
            Assert.Throws<ArgumentException>(() => book = new Book(null, author));
        }

        [Test]
        public void AuthorProperty_IfIsNullOrEmptyShouldThrowException()
        {
            author = string.Empty;

            Assert.Throws<ArgumentException>(() => book = new Book(bookName, author));
            Assert.Throws<ArgumentException>(() => book = new Book(bookName, null));
        }

        [Test]
        public void AddFootnoteMethod_IncreaseTheFootnoteCount()
        {
            book.AddFootnote(31, "text");

            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void AddFootnoteMethod_IfTryToAddToTheSameNumberShouldThrowException()
        {
            book.AddFootnote(31, "text");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(31, "text"));
        }

        [Test]
        public void FindFootnoteMethod_ReturnInfoForFootnote()
        {
            book.AddFootnote(31, "text");

            Assert.AreEqual("Footnote #31: text", book.FindFootnote(31));
        }

        [Test]
        public void FindFootnoteMethod_IfFootnoteNumberIsNonExistingShouldThrowException()
        {
            book.AddFootnote(31, "text");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(11));
        }

        [Test]
        public void AlterFootnoteMethod_ReplaceText()
        {
            book.AddFootnote(31, "text");
            book.AlterFootnote(31, "altered text");

            Assert.AreEqual("Footnote #31: altered text", book.FindFootnote(31));
        }

        [Test]
        public void AlterFootnoteMethod_IfFootnoteNumberIsNonExistingShouldThrowException()
        {
            book.AddFootnote(31, "text");
            book.AlterFootnote(31, "altered text");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(11, "altered text"));
        }
    }    
}