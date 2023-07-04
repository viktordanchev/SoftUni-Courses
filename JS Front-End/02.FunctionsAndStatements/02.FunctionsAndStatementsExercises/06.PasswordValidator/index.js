function isPasswordValid(password) {
  function isLongEnough(password) {
    return password.length >= 6 && password.length <= 10 ? true : false;
  }

  function isConsistOnlyLettersAndDigits(password) {
    const regex = new RegExp("^[A-z0-9]*$");
    return regex.test(password) ? true : false;
  }

  function haveAtLeast2Digits(password) {
    const regex = new RegExp("[0-9]{2,}");
    return regex.test(password) ? true : false;
  }

  const errors = [];

  if (!isLongEnough(password)) {
    errors.push("Password must be between 6 and 10 characters");
  }

  if (!isConsistOnlyLettersAndDigits(password)) {
    errors.push("Password must consist only of letters and digits");
  }

  if (!haveAtLeast2Digits(password)) {
    errors.push("Password must have at least 2 digits");
  }

  if (errors.length > 0) {
    console.log(errors.join("\n"));
    return;
  }

  console.log("Password is valid");
}

isPasswordValid("logIn");
isPasswordValid("MyPass123");
isPasswordValid("Pa$s$s");
