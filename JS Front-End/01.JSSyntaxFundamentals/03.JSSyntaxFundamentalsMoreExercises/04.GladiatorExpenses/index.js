function solve(...params) {
  const lostFights = Number(params[0]);
  const helmetPrice = Number(params[1]);
  const swordPrice = Number(params[2]);
  const shieldPrice = Number(params[3]);
  const armorPrice = Number(params[4]);

  const brokenHelmets = Math.floor(lostFights / 2);
  const brokenSwords = Math.floor(lostFights / 3);
  const brokenShields = Math.floor(lostFights / 6);
  const brokenArmors = Math.floor(lostFights / 12);

  console.log(
    `Gladiator expenses: ${(
      brokenHelmets * helmetPrice +
      brokenSwords * swordPrice +
      brokenShields * shieldPrice +
      brokenArmors * armorPrice
    ).toFixed(2)} aureus`
  );
}

solve(7, 2, 3, 4, 5);
solve(23, 12.5, 21.5, 40, 200);
