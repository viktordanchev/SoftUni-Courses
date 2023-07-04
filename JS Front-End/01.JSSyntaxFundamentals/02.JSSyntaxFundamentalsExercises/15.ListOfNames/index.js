function sortNames(collection) {
  collection = collection.sort();

  for (let index = 0; index < collection.length; index++) {
    console.log(`${index + 1}.${collection[index]}`);
  }
}

sortNames(["John", "Bob", "Christina", "Ema"]);
