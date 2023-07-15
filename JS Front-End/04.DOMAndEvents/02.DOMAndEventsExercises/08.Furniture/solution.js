function solve() {
  const buttons = document.getElementsByTagName("button");

  buttons[0].addEventListener("click", addFurniture);
  buttons[1].addEventListener("click", buy);

  function addFurniture() {
    const textarea = JSON.parse(
      document.getElementsByTagName("textarea")[0].value
    );

    for (const furniture of textarea) {
      const newRow = document
        .querySelector("tbody")
        .appendChild(document.createElement("tr"));

      newRow
        .appendChild(document.createElement("td"))
        .appendChild(document.createElement("img")).src = furniture["img"];

      for (const key in furniture) {
        if (key === "img") {
          continue;
        }

        const td = newRow.appendChild(document.createElement("td"));
        td.textContent = furniture[key];
      }

      newRow
        .appendChild(document.createElement("td"))
        .appendChild(document.createElement("input")).type = "checkbox";
    }
  }

  function buy() {
    const textarea = document.getElementsByTagName("textarea")[1];
    const rows = Array.from(document.querySelectorAll("tbody tr")).filter(
      (tr) => tr.querySelector("input").checked
    );

    let sum = 0;
    let factor = 0;
    let items = [];
    for (const row of rows) {
      const itemData = Array.from(row.children)
        .slice(1, 4)
        .map((td) => td.textContent);

      sum += Number(itemData[1]);
      factor += Number(itemData[2]);
      items.push(itemData[0]);
    }

    textarea.value += `Bought furniture: ${items.join(", ")}` + "\n";
    textarea.value += `Total price: ${sum.toFixed(2)}` + "\n";
    textarea.value +=
      `Average decoration factor: ${factor / rows.length}` + "\n";
  }
}
