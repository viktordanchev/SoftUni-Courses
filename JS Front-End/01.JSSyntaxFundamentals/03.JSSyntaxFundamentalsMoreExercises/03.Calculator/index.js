function calculate(...params) {
  const operator = params[1];
  const firstNum = Number(params[0]);
  const secondNum = Number(params[2]);

  const result = {
    "+": (x, y) => x + y,
    "-": (x, y) => x - y,
    "*": (x, y) => x * y,
    "/": (x, y) => x / y,
  };

  console.log(result[operator](firstNum, secondNum).toFixed(2));
}

calculate(5, "+", 10);
calculate(25.5, "-", 3);
