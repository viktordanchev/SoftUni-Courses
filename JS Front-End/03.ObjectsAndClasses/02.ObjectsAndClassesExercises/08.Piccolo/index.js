function solve(arr) {
  const numbers = [];

  const commands = {
    in: (number) => {
      if (!numbers.includes(number)) {
        numbers.push(number);
      }
    },
    out: (number) => {
      if (numbers.includes(number)) {
        const index = numbers.indexOf(number);
        numbers.splice(index, 1);
      }
    },
  };

  while (arr.length > 0) {
    const data = arr.shift().split(", ");
    const command = data[0].toLowerCase();
    const number = data[1];
    commands[command](number);
  }

  numbers.length !== 0
    ? numbers.sort().forEach((number) => console.log(number))
    : console.log("Parking Lot is Empty");
}

solve([
  "IN, CA2844AA",
  "IN, CA1234TA",
  "OUT, CA2844AA",
  "IN, CA9999TT",
  "IN, CA2866HI",
  "OUT, CA1234TA",
  "IN, CA2844AA",
  "OUT, CA2866HI",
  "IN, CA9876HH",
  "IN, CA2822UU",
]);
solve(["IN, CA2844AA", "IN, CA1234TA", "OUT, CA2844AA", "OUT, CA1234TA"]);
