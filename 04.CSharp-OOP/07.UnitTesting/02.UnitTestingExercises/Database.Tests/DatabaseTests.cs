using NUnit.Framework;
using System;

namespace Database.Tests
{
    public class Tests
    {
        private Database database;
        private Database fullDatabase;

        [SetUp]
        public void Setup()
        {
            database = new(new int[0]);
            fullDatabase = new(new int[16]);
        }

        [Test]
        public void CreateDatabaseWithIntegers()
        {
            Assert.AreEqual(16, fullDatabase.Count);
        }

        [Test]
        public void AddMethod_AddElementToDatabase()
        {
            int[] array = { 23 };

            database.Add(23);

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(23, array[0]);
        }

        [Test]
        public void AddMethod_Add17ElementToDatabaseShouldThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => fullDatabase.Add(17));
        }

        [Test]
        public void RemoveMethod_RemoveElementFromDatabase()
        {
            int[] array = { 23 };

            fullDatabase.Remove();

            Assert.AreEqual(15, fullDatabase.Count);
        }

        [Test]
        public void RemoveMethod_IfTryToRemoveElementFromEmptyDatabaseShouldThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMethod_ShouldReturnArray()
        {
            database = new(23, 32, 45);
            int[] array = { 23, 32, 45 };

            int[] fetchedDatabase = database.Fetch();

            Assert.AreEqual(array.Length, fetchedDatabase.Length);
            Assert.AreEqual(array[1], fetchedDatabase[1]);
        }
    }
}