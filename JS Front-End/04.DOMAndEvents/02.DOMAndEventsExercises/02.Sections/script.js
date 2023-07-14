function create(words) {
  const contentBox = document.getElementById("content");
  words.forEach((word) => {
    const div = contentBox.appendChild(document.createElement("div"));
    const p = div.appendChild(document.createElement("p"));
    p.textContent = word;
    p.hidden = true;
    div.addEventListener("click", (e) => {
      p.hidden = false;
    });
  });
}
