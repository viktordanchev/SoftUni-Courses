function solve(arr) {
  class Word {
    constructor(word, count) {
      this.word = word;
      this.count = count;
    }

    toString() {
      console.log(`${this.word} - ${this.count}`);
    }
  }

  const words = [];
  const matches = arr.shift().split(" ");
  for (const match of matches) {
    const count = arr.reduce((count, word) => {
      if (word === match) {
        count++;
      }
      return count;
    }, 0);
    words.push(new Word(match, count));
  }

  words
    .sort((a, b) => {
      return b.count - a.count;
    })
    .forEach((word) => word.toString());
}

solve([
  "this sentence",
  "In",
  "this",
  "sentence",
  "you",
  "have",
  "to",
  "count",
  "the",
  "occurrences",
  "of",
  "the",
  "words",
  "this",
  "and",
  "sentence",
  "because",
  "this",
  "is",
  "your",
  "task",
]);
solve([
  "is the",
  "first",
  "sentence",
  "Here",
  "is",
  "another",
  "the",
  "And",
  "finally",
  "the",
  "the",
  "sentence",
]);
