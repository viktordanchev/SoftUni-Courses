window.addEventListener("load", solve);

function solve() {
  const inputItems = {
    student: document.querySelector("#student"),
    university: document.querySelector("#university"),
    score: document.querySelector("#score"),
  };

  const items = {
    nextButton: document.querySelector("#next-btn"),
    ulPreview: document.querySelector("#preview-list"),
    candidates: document.querySelector("#candidates-list"),
  };

  items["nextButton"].addEventListener("click", addToList);

  function addToList() {
    if (Object.values(inputItems).some((value) => value.value == "")) {
      clearInputs();
      return;
    }

    const li = items["ulPreview"].appendChild(
      createElement("li", "application", "")
    );

    const article = li.appendChild(createElement("article", "", ""));
    article.appendChild(
      createElement("h4", "", `${inputItems["student"].value}`)
    );
    article.appendChild(
      createElement("p", "", `University: ${inputItems["university"].value}`)
    );
    article.appendChild(
      createElement("p", "", `Score: ${inputItems["score"].value}`)
    );

    const editButton = li.appendChild(
      createElement("button", "action-btn edit", "edit")
    );
    editButton.addEventListener("click", () => {
      edit(li);
    });

    const applyButton = li.appendChild(
      createElement("button", "action-btn apply", "apply")
    );
    applyButton.addEventListener("click", () => {
      apply(li);
    });

    items["nextButton"].disabled = true;
    clearInputs();
  }

  function apply(li) {
    li.removeChild(li.querySelector("button"));
    li.removeChild(li.querySelector("button"));
    li.remove();
    items["candidates"].appendChild(li);
  }

  function edit(li) {
    items["nextButton"].disabled = false;

    inputItems["student"].value = li.querySelector("h4").textContent;
    inputItems["university"].value = li
      .querySelectorAll("p")[0]
      .textContent.slice(12);
    inputItems["score"].value = Number(
      li.querySelectorAll("p")[1].textContent.slice(7)
    );

    li.remove();
  }

  function clearInputs() {
    for (const key in inputItems) {
      inputItems[key].value = "";
    }
  }

  function createElement(tag, classList, textContent) {
    const element = document.createElement(tag);

    if (classList) {
      element.classList = classList;
    }

    if (textContent) {
      element.textContent = textContent;
    }

    return element;
  }
}
