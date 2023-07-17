function solve(passwords) {
  const username = passwords[0];
  const password = passwords[0].split("").reverse().join("");

  for (let index = 1; index <= 4; index++) {
    if (password === passwords[index]) {
      console.log(`User ${username} logged in.`);
      return;
    }

    if (index === 4) {
      console.log(`User ${username} blocked!`);
      return;
    }

    console.log("Incorrect password. Try again.");
  }
}

solve(["Acer", "login", "go", "let me in", "recA"]);
solve(["momo", "omom"]);
solve(["sunny", "rainy", "cloudy", "sunny", "not sunny"]);
