function sortNumbers(collection) {
  collection = collection.sort((a, b) => {
    return a - b;
  });

  for (let index = 0; index < collection.length; index++) {
    if (index % 2 == 1) {
      collection.splice(index, 0, collection.pop());
    }
  }

  return collection;
}

console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
