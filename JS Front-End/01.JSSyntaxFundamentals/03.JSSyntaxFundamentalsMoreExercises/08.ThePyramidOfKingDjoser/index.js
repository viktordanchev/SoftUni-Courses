function solve(base, increment) {
  let stone = 0;
  let marble = 0;
  let lapisLazuli = 0;
  let gold = 0;
  const pyramidHeight = Math.floor(Math.round(Number(base) / 2) * increment);

  let count = 1;
  while (base > 2) {
    const area = Math.pow(base, 2);
    const inside = Math.pow(base - 1 * 2, 2);
    const outerLayer = area - inside;

    stone += inside;
    base -= 2;

    if (count % 5 == 0) {
      lapisLazuli += outerLayer;
    } else {
      marble += outerLayer;
    }

    count++;
  }

  gold += Math.pow(base, 2);

  console.log(`Stone required: ${Math.ceil(stone * increment)}`);
  console.log(`Marble required: ${Math.ceil(marble * increment)}`);
  console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuli * increment)}`);
  console.log(`Gold required: ${Math.ceil(gold * increment)}`);
  console.log(`Final pyramid height: ${pyramidHeight}`);
}

solve(11, 1);
solve(11, 0.75);
solve(12, 1);
solve(23, 0.5);
