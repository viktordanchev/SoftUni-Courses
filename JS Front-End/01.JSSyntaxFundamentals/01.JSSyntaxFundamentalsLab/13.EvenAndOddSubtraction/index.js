function solve(array) {
  let oddSum = 0;
  let evenSum = 0;

  for (let index = 0; index < array.length; index++) {
    const number = array[index];

    if (number % 2 == 0) {
      evenSum += number;
    } else {
      oddSum += number;
    }
  }

  console.log(evenSum - oddSum);
}

solve([1, 2, 3, 4, 5, 6]);