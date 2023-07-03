function calculate(num1, num2, operator) {
  const multiply = (num1, num2) => num1 * num2;
  const divide = (num1, num2) => num1 / num2;
  const add = (num1, num2) => num1 + num2;
  const subtract = (num1, num2) => num1 - num2;

  let result = 0;

  switch (operator) {
    case "multiply":
      result = multiply(num1, num2);
      break;
    case "divide":
      result = divide(num1, num2);
      break;
    case "add":
      result = add(num1, num2);
      break;
    case "subtract":
      result = subtract(num1, num2);
      break;
  }

  console.log(result);
}

calculate(5, 5, "multiply");
calculate(40, 8, "divide");
calculate(12, 19, "add");
calculate(50, 13, "subtract");
