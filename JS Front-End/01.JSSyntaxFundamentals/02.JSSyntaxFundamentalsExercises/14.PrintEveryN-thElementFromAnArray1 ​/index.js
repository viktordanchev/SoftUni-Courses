function printEveryNElement(collection, elementNumber) {
  const array = [];

  for (let index = 0; index <= collection.length; index++) {
    if (index % elementNumber == 0) {
      array.push(collection[index]);
    }
  }

  return array;
}

printEveryNElement(["5", "20", "31", "4", "20"], 2);
