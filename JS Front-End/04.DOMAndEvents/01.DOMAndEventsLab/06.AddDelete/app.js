function addItem() {
  const input = document.getElementById("newItemText").value;
  const list = document.getElementById("items");

  const liTag = document.createElement("li");
  list.appendChild(liTag);
  liTag.appendChild(document.createTextNode(input));

  const aTag = liTag.appendChild(document.createElement("a"));
  aTag.href = "#";
  aTag.appendChild(document.createTextNode("[Delete]"));

  aTag.addEventListener("click", deleteItem);

  function deleteItem() {
    liTag.remove();
  }
}
