function search(word, text) {
  text = text.toLowerCase();
  console.log(text.includes(word) ? word : `${word} not found!`);
}

search("javascript", "JavaScript is the best programming language");
search("python", "JavaScript is the best programming language");
