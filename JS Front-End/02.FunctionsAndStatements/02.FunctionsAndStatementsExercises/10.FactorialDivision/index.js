function devide(num1, num2) {
  const getFactorial = (num) => {
    let sum = 1;

    for (let index = num; index > 0; index--) {
      sum *= index;
    }

    return sum;
  };

  console.log((getFactorial(num1) / getFactorial(num2)).toFixed(2));
}

devide(5, 2);
devide(6, 2);
