function printDNK(number) {
  const dnk = {
    1: (x, y) => `**${x}${y}**`,
    2: (x, y) => `*${x}--${y}*`,
    3: (x, y) => `${x}----${y}`,
    4: (x, y) => `*${x}--${y}*`,
  };

  const words = "ATCGTTAGGG".split("");
  let count = 1;
  for (let index = 1; index <= number; index++) {
    const x = words.shift();
    words.push(x);
    const y = words.shift();
    words.push(y);
    console.log(dnk[count](x, y));

    if (count === 4) {
      count = 1;
    } else {
      count++;
    }
  }
}

printDNK(4);
printDNK(10);
