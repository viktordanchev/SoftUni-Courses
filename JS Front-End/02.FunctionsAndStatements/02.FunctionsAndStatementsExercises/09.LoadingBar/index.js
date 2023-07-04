function print(number) {
  function fillPercentageBar(number) {
    const percentageBar = [];

    for (let index = 1; index <= 10; index++) {
      let symbol = ".";

      if (index <= number / 10) {
        symbol = "%";
      }

      percentageBar.push(symbol);
    }

    return percentageBar;
  }

  const percentageBar = fillPercentageBar(number).join("");

  if (number < 100) {
    console.log(`${number}% [${percentageBar}]`);
    console.log("Still loading...");
  } else {
    console.log("100% Complete!");
  }
}

print(30);
print(50);
print(100);
