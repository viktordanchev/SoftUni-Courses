function sortAlphabetically(collection) {
  const sortedCollection = collection.sort(function (a, b) {
    if (a < b) {
      return -1;
    }
    if (a > b) {
      return 1;
    }
    return 0;
  });

  for (let index = 0; index < sortedCollection.length; index++) {
    console.log(`${index + 1}.${sortedCollection[index]}`);
  }
}

sortAlphabetically(["John", "Bob", "Christina", "Ema"]);
