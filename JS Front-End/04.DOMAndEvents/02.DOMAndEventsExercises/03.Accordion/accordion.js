function toggle() {
  const button = document.getElementsByClassName("button")[0];
  const div = document.getElementById("extra");

  if (button.textContent === "More") {
    button.textContent = "Less";
    div.style.display = "block";
  } else {
    button.textContent = "More";
    div.style.display = "none";
  }
}
