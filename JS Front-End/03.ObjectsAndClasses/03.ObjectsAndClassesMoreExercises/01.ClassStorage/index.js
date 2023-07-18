class Storage {
  constructor(capacity) {
    this.capacity = capacity;
    this.storage = [];
    this.totalCost = 0;
  }

  addProduct(product) {
    this.storage.push(product);
    this.capacity -= product["quantity"];
    this.totalCost += product["price"] * product["quantity"];
  }

  getProducts() {
    const output = [];
    this.storage.forEach((product) => output.push(JSON.stringify(product)));
    return output.join("\n");
  }
}
