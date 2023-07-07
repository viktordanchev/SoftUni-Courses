function printPersonInfo(arr) {
  const addressBook = {};
  for (let index = 0; index < arr.length; index++) {
    const [name, address] = arr[index].split(":");
    addressBook[name] = address;
  }

  const sortedNames = Object.keys(addressBook).sort();

  for (const name of sortedNames) {
    console.log(`${name} -> ${addressBook[name]}`);
  }
}

printPersonInfo([
  "Tim:Doe Crossing",
  "Bill:Nelson Place",
  "Peter:Carlyle Ave",
  "Bill:Ornery Rd",
]);
printPersonInfo([
  "Bob:Huxley Rd",
  "John:Milwaukee Crossing",
  "Peter:Fordem Ave",
  "Bob:Redwing Ave",
  "George:Mesta Crossing",
  "Ted:Gateway Way",
  "Bill:Gateway Way",
  "John:Grover Rd",
  "Peter:Huxley Rd",
  "Jeff:Gateway Way",
  "Jeff:Huxley Rd",
]);
