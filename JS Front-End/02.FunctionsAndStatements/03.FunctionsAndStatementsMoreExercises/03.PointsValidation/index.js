function solve(numbers) {
  console.log(isValid(numbers[0], numbers[1], 0, 0));
  console.log(isValid(numbers[2], numbers[3], 0, 0));
  console.log(isValid(numbers[0], numbers[1], numbers[2], numbers[3]));

  function isValid(...numbers) {
    const result =
      Math.pow(numbers[2] - numbers[0], 2) +
      Math.pow(numbers[3] - numbers[1], 2);

    if (Number.isInteger(Math.sqrt(result))) {
      return `{${numbers[0]}, ${numbers[1]}} to {${numbers[2]}, ${numbers[3]}} is valid`;
    }

    return `{${numbers[0]}, ${numbers[1]}} to {${numbers[2]}, ${numbers[3]}} is invalid`;
  }
}

solve([3, 0, 0, 4]);
solve([2, 1, 1, 1]);
