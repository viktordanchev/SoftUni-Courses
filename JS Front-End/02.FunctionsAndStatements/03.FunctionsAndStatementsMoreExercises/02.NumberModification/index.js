function solve(number) {
  let numbers = String(number).split("");
  let currSum = sum(numbers);

  while (currSum / numbers.length < 5) {
    numbers.push(9);
    currSum = sum(numbers);
  }

  console.log(numbers.join(""));

  function sum(numbers) {
    return numbers.reduce((acc, number) => {
      acc += Number(number);
      return acc;
    }, 0);
  }
}

solve(101);
solve(5835);
