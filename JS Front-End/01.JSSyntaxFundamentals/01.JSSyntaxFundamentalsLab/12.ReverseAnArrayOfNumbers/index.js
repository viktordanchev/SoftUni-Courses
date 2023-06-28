function solve(length, array) {
  const arrayLength = array.length;
  for (let index = 0; index < arrayLength - length; index++) {
    array.pop();
  }

  array.reverse();
  console.log(...array);
}

solve(3, [10, 20, 30, 40, 50]);