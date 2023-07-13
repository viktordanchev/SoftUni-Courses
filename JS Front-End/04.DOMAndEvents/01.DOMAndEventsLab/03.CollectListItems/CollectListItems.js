function extractText() {
  const items = Array.from(document.getElementsByTagName("li")).map(item => item.innerText);
  const textArea = document.getElementById("result");

  textArea.value = items.join("\n");
}
