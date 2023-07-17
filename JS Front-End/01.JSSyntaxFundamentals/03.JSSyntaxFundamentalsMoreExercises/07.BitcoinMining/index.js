function solve(days) {
  let bitcoins = 0;
  let dayOfFirstBitcoin = 0;
  let money = 0;

  for (let index = 1; index <= days.length; index++) {
    const gold =
      index % 3 === 0 ? Number(days[index - 1]) * 0.7 : Number(days[index - 1]);

    money += gold * 67.51;

    while (money >= 11949.16) {
      if (dayOfFirstBitcoin === 0) {
        dayOfFirstBitcoin = index;
      }

      money -= 11949.16;
      bitcoins++;
    }
  }

  console.log(`Bought bitcoins: ${bitcoins}`);
  if (dayOfFirstBitcoin > 0) {
    console.log(`Day of the first purchased bitcoin: ${dayOfFirstBitcoin}`);
  }
  console.log(`Left money: ${money.toFixed(2)} lv.`);
}

solve([100, 200, 300]);
solve([50, 100]);
solve([3124.15, 504.212, 2511.124]);
