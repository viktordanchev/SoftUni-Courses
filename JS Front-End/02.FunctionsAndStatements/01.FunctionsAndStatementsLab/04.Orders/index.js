function calculateTotalPrice(product, count) {
  let price = 0;

  switch (product) {
    case "coffee":
      price = 1.5;
      break;
    case "water":
      price = 1;
      break;
    case "coke":
      price = 1.4;
      break;
    case "snacks":
      price = 2;
      break;
  }

  return (price * count).toFixed(2);
}

console.log(calculateTotalPrice("water", 5));
console.log(calculateTotalPrice("coffee", 2));
