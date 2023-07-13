function sumTable() {
  const sum = Array.from(
    document.querySelectorAll("td:nth-child(even)")
  ).reduce((sum, num) => {
    sum += Number(num.textContent);
    return sum;
  }, 0);

  document.getElementById("sum").textContent = sum;
}
