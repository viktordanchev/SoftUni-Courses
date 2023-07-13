function deleteByEmail() {
  const emailToRemove = document.getElementsByTagName("input")[0].value;
  document.getElementsByTagName("input")[0].value = "";

  const emails = Array.from(
    document.querySelectorAll("tbody td:nth-child(even)")
  );
  const email = emails.find((email) => email.textContent === emailToRemove);

  if (email) {
    email.parentElement.remove();
    document.getElementById("result").textContent = "Deleted.";
  } else {
    document.getElementById("result").textContent = "Not found.";
  }
}
