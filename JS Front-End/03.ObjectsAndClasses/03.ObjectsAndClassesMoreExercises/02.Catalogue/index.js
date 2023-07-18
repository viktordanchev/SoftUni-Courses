function solve(products) {
  const object = products.reduce((object, product) => {
    const [key, value] = product.split(" : ");
    const letter = key.split("")[0];
    if (!object[letter]) {
      object[letter] = [];
    }

    object[letter].push(`  ${key}: ${value}`);
    return object;
  }, {});

  const sortedKeys = Object.keys(object).sort();
  for (const key of sortedKeys) {
    const value = object[key].sort((a, b) => a.localeCompare(b));
    console.log(key);
    console.log(value.join("\n"));
  }
}

solve([
  "Appricot : 20.4",
  "Fridge : 1500",
  "TV : 1499",
  "Deodorant : 10",
  "Boiler : 300",
  "Apple : 1.25",
  "Anti-Bug Spray : 15",
  "T-Shirt : 10",
]);
