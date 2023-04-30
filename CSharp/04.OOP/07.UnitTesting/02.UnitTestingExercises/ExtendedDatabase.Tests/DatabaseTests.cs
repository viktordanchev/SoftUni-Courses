using NUnit.Framework;
using System;

namespace ExtendedDatabase.Tests
{
    public class Tests
    {
        private Database database;
        private Person person;
        private long id;
        private string username;

        [SetUp]
        public void Setup()
        {
            id = 2;
            username = "Georgi";
            person = new(1, "Viktor");
            database = new(person);
        }

        [Test]
        public void Constructor_CreateDataBaseWithPersons()
        {
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddRangeMethod_CreateDataBaseWithMoreThan16Persons()
        {
            Assert.Throws<ArgumentException>(() => database = new(new Person[17]));
        }

        [Test]
        public void AddMethod_ShouldAddPersonToDatebase()
        {
            person = new(id, username);

            database.Add(person);

            Assert.AreEqual(2, database.Count);
            Assert.AreEqual(id, database.FindById(id).Id);
            Assert.AreEqual(username, database.FindByUsername(username).UserName);
        }

        [Test]
        public void AddMethod_AddMoreThan16PersonsShouldThorwException()
        {
            database = new(new Person[0]);

            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"{i} + Gosho"));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "Gosho")));
        }

        [Test]
        public void AddMethod_AddUserWithExistedUsernameShouldThorwException()
        {
            username = "Viktor";
            person = new(id, username);

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void AddMethod_AddUserWithExistedIdShouldThorwException()
        {
            id = 1;
            person = new(id, username);

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void RemoveMethod_RemoveUserFromDatabase()
        {
            database.Remove();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void RemoveMethod_IfTryToRemoveUserFromEmptyDatabaseShouldThrowsException()
        {
            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsernameMethod_IfUsernameIsNullOrEmpty()
        {
            username = string.Empty;

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameMethod_IfUserWithThisUsernameIsNoPresent()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));
        }

        [Test]
        public void FindByUsernameMethod_IfUserWithThisUsernameIsPresentReturnIt()
        {
            database.Add(new Person(id, username));
            person = database.FindByUsername(username);

            Assert.AreEqual(username, person.UserName);
        }

        [Test]
        public void FindByIdMethod_IfIdIsSmallerThan0()
        {
            id = -5;

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        [Test]
        public void FindByIdMethod_IfUserWithThisIdIsNoPresent()
        {
            id = 5;

            Assert.Throws<InvalidOperationException>(() => database.FindById(id));
        }

        [Test]
        public void FindByUsernameId_IfUserWithThisIdIsPresentReturnIt()
        {
            database.Add(new Person(id, username));
            person = database.FindById(id);

            Assert.AreEqual(id, person.Id);
        }
    }
}