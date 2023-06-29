function searchWord(text, word) {
  let count = 0;
  let words = text.split(" ");

  for (let index = 0; index < words.length; index++) {
    if (words[index] === word) {
      count++;
    }
  }

  console.log(count);
}

searchWord("This is a word and it also is a sentence", "is");