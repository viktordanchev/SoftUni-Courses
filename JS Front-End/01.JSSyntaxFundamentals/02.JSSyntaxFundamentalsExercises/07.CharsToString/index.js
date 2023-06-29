function combineToString(...chars) {
  let word = "";

  for (let index = 0; index < chars.length; index++) {
    word += chars[index];
  }
  console.log(word);
}

combineToString("a", "b", "c");
