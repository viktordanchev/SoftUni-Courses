function solve(currStock, orderedStock) {
  const stock = {};

  while (currStock.length > 0) {
    const name = currStock.shift();
    const count = Number(currStock.shift());
    stock[name] = count;
  }

  while (orderedStock.length > 0) {
    const name = orderedStock.shift();
    const count = Number(orderedStock.shift());

    if (stock.hasOwnProperty(name)) {
      stock[name] += count;
      continue;
    }

    stock[name] = count;
  }

  for (const product in stock) {
    console.log(`${product} -> ${stock[product]}`);
  }
}

solve(
  ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
  ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
);
solve(
  ["Salt", "2", "Fanta", "4", "Apple", "14", "Water", "4", "Juice", "5"],
  ["Sugar", "44", "Oil", "12", "Apple", "7", "Tomatoes", "7", "Bananas", "30"]
);
