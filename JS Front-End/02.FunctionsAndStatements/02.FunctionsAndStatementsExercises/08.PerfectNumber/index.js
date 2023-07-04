function print(number) {
  let sum = 0;

  for (let index = 0; index < number; index++) {
    if (number % index == 0) {
      sum += index;
    }
  }

  let message = "";

  if (sum === number) {
    message = "We have a perfect number!";
  } else {
    message = "It's not so perfect.";
  }

  console.log(message);
}

print(6);
print(28);
print(1236498);
