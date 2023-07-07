function printNameAndPhone(arr) {
  const phoneBook = {};
  for (let index = 0; index < arr.length; index++) {
    const [name, number] = arr[index].split(" ");
    phoneBook[name] = number;
  }

  for (const contact in phoneBook) {
    console.log(`${contact} -> ${phoneBook[contact]}`);
  }
}

printNameAndPhone([
  "Tim 0834212554",
  "Peter 0877547887",
  "Bill 0896543112",
  "Tim 0876566344",
]);
printNameAndPhone([
  "George 0552554",
  "Peter 087587",
  "George 0453112",
  "Bill 0845344",
]);
