function solve() {
  const output = document.getElementById("output");
  const sentences = Array.from(
    document.getElementById("input").value.split(".")
  ).filter((sentence) => sentence.length > 1);

  const end = Math.ceil(sentences.length / 3);
  for (let index = 0; index < end; index++) {
    const p = output.appendChild(document.createElement("p"));

    for (let index = 0; index < 3; index++) {
      p.appendChild(document.createTextNode(sentences.shift() + "."));

      if (sentences.length == 0) {
        break;
      }
    }
  }
}
