function replace(words, text) {
  words = words.split(", ");

  for (let index = 0; index < words.length; index++) {
    text = text.replace("*".repeat(words[index].length), words[index]);
  }

  console.log(text);
}

replace(
  "great",
  "softuni is ***** place for learning new programming languages"
);
replace(
  "great, learning",
  "softuni is ***** place for ******** new programming languages"
);
