function solve(text, startIndex, count) {
  let array = "";
  let output;
  for (let index = startIndex; index <= count; index++) {
    array += text[index];
  }

  console.log(array);
}

solve("ASentence", 1, 8);
