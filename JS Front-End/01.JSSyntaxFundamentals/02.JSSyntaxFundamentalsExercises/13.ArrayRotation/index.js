function rotateArray(collection, count) {
  for (let index = 0; index < count; index++) {
    const firstElement = collection.shift();
    collection.push(firstElement);
  }

  console.log(...collection);
}

rotateArray([51, 47, 32, 61, 21], 2);
