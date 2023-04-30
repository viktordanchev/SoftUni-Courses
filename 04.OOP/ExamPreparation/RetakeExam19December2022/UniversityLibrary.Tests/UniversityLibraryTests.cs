using NUnit.Framework;
using System.Text;

namespace UniversityLibrary.Tests
{
    public class Tests
    {
        private UniversityLibrary library;
        private TextBook textBook;
        private string title;
        private string author;
        private string category;
        private int inventoryNumber;
        private string holder;

        [SetUp]
        public void Setup()
        {
            title = "Harry Potter";
            author = "J.K. Rowling";
            category = "fantasy";
            holder = "Viktor";
            inventoryNumber = 0;
            textBook = new TextBook(title, author, category);
            textBook.Holder = holder;
            textBook.InventoryNumber = inventoryNumber;
            library = new UniversityLibrary();
        }

        [Test]
        public void TextBookCategory_MakeNewTextBookProperly()
        {
            title = "Harry Potter";
            author = "J.K. Rowling";
            category = "fantasy";
            textBook = new TextBook(title, author, category);
            textBook.Holder = holder;
            textBook.InventoryNumber = inventoryNumber;

            Assert.AreEqual(title, textBook.Title);
            Assert.AreEqual(author, textBook.Author);
            Assert.AreEqual(category, textBook.Category);
            Assert.AreEqual(holder, textBook.Holder);
            Assert.AreEqual(inventoryNumber, textBook.InventoryNumber);
        }
        
        [Test]
        public void ToStringMethod_ReturnBookInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {textBook.Title} - {textBook.InventoryNumber}");
            sb.AppendLine($"Category: {textBook.Category}");
            sb.AppendLine($"Author: {textBook.Author}");

            Assert.AreEqual(sb.ToString().Trim(), textBook.ToString());
        }
        
        [Test]
        public void UniversityLibraryConstructor_MakeNewUniversityLibraryProperly()
        {
            library = new UniversityLibrary();

            Assert.AreEqual(0, library.Catalogue.Count);
        }
        
        [Test]
        public void AddTextBookToLibraryMethod_ReturnInfoAboutAddedBook()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {textBook.Title} - {textBook.InventoryNumber + 1}");
            sb.AppendLine($"Category: {textBook.Category}");
            sb.AppendLine($"Author: {textBook.Author}");

            Assert.AreEqual(sb.ToString().Trim(), library.AddTextBookToLibrary(textBook));
            Assert.AreEqual(1, library.Catalogue.Count);
        }

        [Test]
        public void LoanTextBookMethod_IfHolderIsEqualToStudentNameReturnString()
        {
            string text = $"{holder} still hasn't returned {textBook.Title}!";

            library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(text, library.LoanTextBook(inventoryNumber + 1, holder));
        }
        
        [Test]
        public void LoanTextBookMethod_IfHolderIsNotEqualToStudentNameReturnString()
        {
            string text = $"{textBook.Title} loaned to Asen.";

            library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(text, library.LoanTextBook(inventoryNumber + 1, "Asen"));
            Assert.AreEqual("Asen", textBook.Holder);
        }
        
        [Test]
        public void ReturnTextBookMethod_IfHolderIsNotEqualToStudentNameReturnString()
        {
            string text = $"{textBook.Title} is returned to the library.";

            library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(text, library.ReturnTextBook(inventoryNumber + 1));
            Assert.AreEqual(string.Empty, textBook.Holder);
        }
    }
}