function subtract() {
  const firstNum = document.getElementById("firstNumber").value;
  const secondNum = document.getElementById("secondNumber").value;
  const sum = Number(firstNum) - Number(secondNum);

  document.getElementById("result").textContent = sum;
}
