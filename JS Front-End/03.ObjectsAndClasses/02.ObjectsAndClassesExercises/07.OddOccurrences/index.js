function solve(string) {
  const words = [];

  string = string.toLowerCase().split(" ");
  for (const word of string) {
    const count = string.reduce((count, currWord) => {
      if (currWord === word) {
        count++;
      }
      return count;
    }, 0);

    if (count % 2 == 1 && !words.includes(word)) {
      words.push(word);
    }
  }

  console.log(words.join(" "));
}

solve("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
solve("Cake IS SWEET is Soft CAKE sweet Food");
