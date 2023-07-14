function addItem() {
  const itemText = document.getElementById("newItemText").value;
  const itemValue = document.getElementById("newItemValue").value;

  const option = document
    .getElementById("menu")
    .appendChild(document.createElement("option"));
  option.value = itemValue;
  option.textContent = itemText;

  document.getElementById("newItemText").value = "";
  document.getElementById("newItemValue").value = "";
}
