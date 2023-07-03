function printMatrix(number) {
  for (let index = 0; index < number; index++) {
    const makeRow = (number) => {
      const row = [];

      for (let index = 0; index < number; index++) {
        row.push(number);
      }

      return row;
    };

    console.log(...makeRow(number));
  }
}

printMatrix(3);
printMatrix(7);
