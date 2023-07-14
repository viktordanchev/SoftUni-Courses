function solve() {
  const output = document.getElementById("output");
  const sentences = Array.from(
    document.getElementById("input").value.split(".")
  ).filter((sentence) => sentence.length > 1);

  for (let index = 0; index < sentences.length; index++) {
    const p = output.appendChild(document.createElement("p"));

    if (index % 3 === 1) {
      p.appendChild(document.createTextNode(sentences.shift()));
    }
  }
}
