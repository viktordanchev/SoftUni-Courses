function signCheck(...numbers) {
  let count = 0;

  numbers.forEach((n) => {
    if (n < 0) {
      count++;
    }
  });

  console.log(count % 2 == 1 ? "Negative" : "Positive");
}

signCheck(5, 12, -15);
signCheck(-6, -12, 14);
signCheck(-1, -2, -3);
signCheck(-5, 1, 1);
