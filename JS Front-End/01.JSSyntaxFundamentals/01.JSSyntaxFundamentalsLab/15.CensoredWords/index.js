function replaceWord(text, word) {
  while (text.includes(word)) {
    text = text.replace(word, "*".repeat(word.length));
  }

  console.log(text);
}

replaceWord("A small sentence with some words", "small");