using NUnit.Framework;
using System;

namespace Database.Tests
{
    public class Tests
    {
        private Database database;
        Database fullDatabase;
        private int indexes;

        [SetUp]
        public void Setup()
        {
            indexes = 0;
            database = new(new int[indexes]);
            fullDatabase = new(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
        }

        [Test]
        public void DatabaseConstructorShouldSetDataProperly()
        {
            database = new(new int[indexes + 5]);

            Assert.AreEqual(5, database.Count);
        }

        [Test]
        public void TryToAddMoreThan16ElementsToArray()
        {
            Assert.Throws<InvalidOperationException>(() => fullDatabase.Add(17));
        }

        [Test]
        public void TryToRemoveInEmptyArray()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnElementsInArray()
        {
            Assert.AreEqual(16, fullDatabase.Count);
        }
    }
}