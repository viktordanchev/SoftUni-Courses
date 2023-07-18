function washCar(params) {
  const commands = {
    soap: (cleanPercentage) => (cleanPercentage += 10),
    water: (cleanPercentage) => (cleanPercentage += cleanPercentage * 0.2),
    "vacuum cleaner": (cleanPercentage) =>
      (cleanPercentage += cleanPercentage * 0.25),
    mud: (cleanPercentage) => (cleanPercentage -= cleanPercentage * 0.1),
  };

  let cleanPercentage = 0;
  while (params.length > 0) {
    const command = params.shift();
    cleanPercentage = commands[command](cleanPercentage);
  }

  console.log(`The car is ${cleanPercentage.toFixed(2)}% clean.`);
}

washCar(["soap", "soap", "vacuum cleaner", "mud", "soap", "water"]);
washCar(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);
