function solve(numbers) {
  const isPalindrom = (number) => {
    const reversedNumber = number
      .toString()
      .split("")
      .reverse()
      .map(Number)
      .join("");

    return reversedNumber == number ? true : false;
  };

  for (const number of numbers) {
    console.log(isPalindrom(number));
  }
}

solve([123, 323, 421, 121]);
solve([32, 2, 232, 1010]);
