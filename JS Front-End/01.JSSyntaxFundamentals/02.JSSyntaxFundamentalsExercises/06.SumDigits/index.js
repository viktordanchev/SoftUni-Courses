function sumNumberDigits(number) {
  const digits = number.toString().split("").map(Number);
  let sum = 0;
  digits.forEach((digit) => (sum += digit));
  console.log(sum);
}

sumNumberDigits(245678);
