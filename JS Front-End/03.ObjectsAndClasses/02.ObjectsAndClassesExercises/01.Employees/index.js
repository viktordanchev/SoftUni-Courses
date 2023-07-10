function solve(arr) {
  const people = arr.reduce((people, person) => {
    people[person] = person.length;
    return people;
  }, {});

  for (const person in people) {
    console.log(`Name: ${person} -- Personal Number: ${people[person]}`);
  }
}

solve([
  "Silas Butler",
  "Adnaan Buckley",
  "Juan Peterson",
  "Brendan Villarreal",
]);
solve(["Samuel Jackson", "Will Smith", "Bruce Willis", "Tom Holland"]);
