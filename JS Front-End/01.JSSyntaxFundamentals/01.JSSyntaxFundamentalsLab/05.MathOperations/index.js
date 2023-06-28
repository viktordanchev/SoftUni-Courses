function mathOperation(firstNum, secondNum, operation) {
  let result;

  switch (operation) {
    case "+":
      result = firstNum + secondNum;
      break;
    case "-":
      result = firstNum - secondNum;
      break;
    case "*":
      result = firstNum * secondNum;
      break;
    case "/":
      result = firstNum / secondNum;
      break;
    case "%":
      result = firstNum % secondNum;
      break;
    case "**":
      result = firstNum ** secondNum;
      break;
  }

  console.log(result);
}

mathOperation(5, 5, "*");
