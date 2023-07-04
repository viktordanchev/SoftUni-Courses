function find(text) {
  const words = text.match(/#[A-z]+/g);
  words.map((w) => w.substring(1, w.length)).forEach((w) => console.log(w));
}

find("Nowadays everyone uses # to tag a #special word in #socialMedia");
find(
  "The symbol # is known #variously in English-speaking #regions as the #number sign"
);
