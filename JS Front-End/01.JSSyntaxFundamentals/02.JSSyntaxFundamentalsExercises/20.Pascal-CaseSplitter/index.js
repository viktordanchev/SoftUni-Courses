function split(word) {
  const words = word.match(/[A-Z]{1}[a-z]*/g);
  console.log(words.join(", "));
}

split("SplitMeIfYouCanHaHaYouCantOrYouCan");
split("HoldTheDoor");
split("ThisIsSoAnnoyingToDo");
