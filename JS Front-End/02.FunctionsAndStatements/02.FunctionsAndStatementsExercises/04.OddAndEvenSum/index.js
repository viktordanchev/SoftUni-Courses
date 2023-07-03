function printSum(number) {
  const digits = number.toString().split("").map(Number);
  let evenSum = 0;
  let oddSum = 0;

  for (const digit of digits) {
    digit % 2 == 0 ? (evenSum += digit) : (oddSum += digit);
  }

  console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

printSum(1000435);
printSum(3495892137259234);
