function checkForLeapYear(year) {
  console.log(
    (year % 4 == 0 && year % 100 > 0) || year % 400 == 0 ? "yes" : "no"
  );
}

checkForLeapYear(1984);
