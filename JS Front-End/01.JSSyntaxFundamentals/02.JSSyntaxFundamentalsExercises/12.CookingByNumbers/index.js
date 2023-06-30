function manipulateNumber(numberString, ...commands) {
  let number = Number(numberString);

  for (const command of commands) {
    switch (command) {
      case "chop":
        number /= 2;
        break;
      case "dice":
        number = Math.sqrt(number, 2);
        break;
      case "spice":
        number += 1;
        break;
      case "bake":
        number *= 3;
        break;
      case "fillet":
        number -= number * 0.2;
        break;
    }

    console.log(number);
  }
}

manipulateNumber("32", "chop", "chop", "chop", "chop", "chop");
