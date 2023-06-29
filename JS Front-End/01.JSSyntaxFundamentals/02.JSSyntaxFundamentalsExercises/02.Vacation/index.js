function calculateHowMuchToPay(people, groupType, dayOfWeek) {
  let totalPrice = 0;
  let promotion = 0;

  switch (groupType) {
    case "Students":
      if (dayOfWeek === "Friday") {
        totalPrice = 8.45 * people;
      } else if (dayOfWeek === "Saturday") {
        totalPrice = 9.8 * people;
      } else if (dayOfWeek === "Sunday") {
        totalPrice = 10.46 * people;
      }

      if (people >= 30) {
        totalPrice *= 0.85;
      }
      break;
    case "Business":
      if (people >= 100) {
        people -= 10;
      }

      if (dayOfWeek === "Friday") {
        totalPrice = 10.9 * people;
      } else if (dayOfWeek === "Saturday") {
        totalPrice = 15.6 * people;
      } else if (dayOfWeek === "Sunday") {
        totalPrice = 16 * people;
      }
      break;
    case "Regular":
      if (dayOfWeek === "Friday") {
        totalPrice = 15 * people;
      } else if (dayOfWeek === "Saturday") {
        totalPrice = 20 * people;
      } else if (dayOfWeek === "Sunday") {
        totalPrice = 22.5 * people;
      }

      if (people >= 10 && people <= 20) {
        totalPrice *= 0.95;
      }
      break;
  }

  console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

calculateHowMuchToPay(30, "Students", "Sunday");
