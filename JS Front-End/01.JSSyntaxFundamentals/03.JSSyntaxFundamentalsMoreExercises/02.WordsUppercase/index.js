function solve(string) {
  const words = string.match(/[A-z0-9]+/g).map((word) => word.toUpperCase());

  console.log(words.join(", "));
}

solve("Hi, how are you?");
solve("hello");
