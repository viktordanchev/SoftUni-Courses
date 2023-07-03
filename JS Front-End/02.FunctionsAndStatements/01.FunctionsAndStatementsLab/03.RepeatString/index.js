function concat(word, count) {
  let output = "";

  for (let index = 0; index < count; index++) {
    output += word;
  }

  return output;
}

console.log(concat("abc", 3));
console.log(concat("String", 2));
