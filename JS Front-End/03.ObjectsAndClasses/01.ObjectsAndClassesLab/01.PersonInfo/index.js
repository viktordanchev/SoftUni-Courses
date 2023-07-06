function createPerson(firstName, lastName, age) {
  const person = {
    firstName,
    lastName,
    age,

    print: function () {
      console.log(`firstName: ${this.firstName}`);
      console.log(`lastName: ${this.lastName}`);
      console.log(`age: ${this.age}`);
    },
  };

  return person;
}

const person = createPerson("Peter", "Pan", "20");
person.print();
