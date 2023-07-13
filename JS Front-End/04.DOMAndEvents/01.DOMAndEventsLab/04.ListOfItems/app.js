function addItem() {
  const item = document.createElement("li");
  const itemToAdd = document.getElementById("newItemText").value;
  item.appendChild(document.createTextNode(itemToAdd));
  document.getElementById("items").appendChild(item);
  document.getElementById("newItemText").value = "";
}
