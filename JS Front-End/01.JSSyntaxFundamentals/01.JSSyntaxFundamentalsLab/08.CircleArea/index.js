function calculateCircleArea(input) {
  const type = typeof input;
  if (typeof input !== "number") {
    console.log(
      `We can not calculate the circle area, because we receive a ${type}.`
    );
  } else {
    const area = Math.PI * Math.pow(input, 2);
    console.log(area.toFixed(2));
  }
}

calculateCircleArea(5);