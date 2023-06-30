function isSame(...number) {
  let bool = true;
  let sum = 0;
  const digits = number.toString().split("").map(Number);
  const currDigit = digits[0];

  for (let index = 0; index < digits.length; index++) {
    if (digits[index] != currDigit) {
        bool = false;
    }

    sum += digits[index];
  }
                  
  console.log(bool);
  console.log(sum);
}

isSame(2222222);