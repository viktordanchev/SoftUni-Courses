function checkGrade(grade) {
  let output = "Excellent";

  if (grade < 5.5) {
    output = "Not excellent";
  }

  console.log(output);
}

checkGrade(5.49);
