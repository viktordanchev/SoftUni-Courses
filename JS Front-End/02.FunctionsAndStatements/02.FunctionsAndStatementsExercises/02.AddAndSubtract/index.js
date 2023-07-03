function sum(num1, num2, num3) {
  const result = num1 + num2;
  console.log(subtract(result, num3));

  function subtract(num1, num2) {
    return num1 - num2;
  }
}

sum(23, 6, 10);
sum(1, 17, 30);
sum(42, 58, 100);
