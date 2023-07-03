function printArray(element1, element2) {
  let array = [];
  let start = Math.min(element1.charCodeAt(0), element2.charCodeAt(0));
  let end = Math.max(element1.charCodeAt(0), element2.charCodeAt(0));

  for (let index = start + 1; index < end; index++) {
    array.push(String.fromCharCode(index));
  }

  console.log(...array);
}

printArray("a", "d");
printArray("#", ":");
printArray("C", "#");
