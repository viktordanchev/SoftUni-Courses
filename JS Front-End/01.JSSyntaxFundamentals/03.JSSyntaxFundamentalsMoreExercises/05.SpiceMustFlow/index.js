function solve(source) {
  let total = 0;
  let days = 0;
  while (source >= 100) {
    total += source - 26;
    source -= 10;
    days++;
  }

  if (total != 0) {
    total -= 26;
  }
  console.log(days);
  console.log(total);
}

solve(111);
solve(450);
