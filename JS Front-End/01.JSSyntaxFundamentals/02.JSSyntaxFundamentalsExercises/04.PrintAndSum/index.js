function solve(start, end) {
  let numbers = [];
  let sum = 0;

  for (let index = start; index <= end; index++) {
    numbers.push(index);
    sum += index;
  }

  console.log(...numbers);
  console.log(`Sum: ${sum}`);
}

solve(5, 10);
