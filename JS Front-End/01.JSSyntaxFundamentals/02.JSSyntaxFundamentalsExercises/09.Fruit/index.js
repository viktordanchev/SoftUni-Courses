function calculateKg(fruit, grams, pricePerKg) {
  const kg = grams / 1000;
  console.log(`I need $${(kg * pricePerKg).toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`);
}

calculateKg("orange", "2500", "1.80");
