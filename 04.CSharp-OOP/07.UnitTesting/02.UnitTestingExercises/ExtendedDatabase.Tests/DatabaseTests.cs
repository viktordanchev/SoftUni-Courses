using NUnit.Framework;
using System;

namespace ExtendedDatabase.Tests
{
    public class Tests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new(new Person(1, "Viktor"));
        }

        [Test]
        public void CreateDatabaseWith2Elements()
        {

        }

        [Test]
        public void AddMethod_AddPersonToDatabase()
        {
            database.Add(new Person(2, "Georgi"));

            Assert.AreEqual(2, database.Count);
            Assert.AreEqual("Georgi", database.FindByUsername("Georgi").UserName);
        }

        [Test]
        public void AddMethod_FindUserByUsername()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Viktor"));
        }

        [Test]
        public void AddMethod_FindUserById()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(1));
        }
    }
}