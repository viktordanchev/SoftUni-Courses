window.addEventListener("load", solve);

function solve() {
  const inputItems = {
    FirstName: document.querySelector("#first-name"),
    LastName: document.querySelector("#last-name"),
    Age: document.querySelector("#age"),
    StoryTitle: document.querySelector("#story-title"),
    Genre: document.querySelector("#genre"),
    StoryText: document.querySelector("#story"),
  };

  const items = {
    ul: document.querySelector("#preview-list"),
    publishButton: document.querySelector("#form-btn"),
    mainDiv: document.querySelector("#main"),
  };

  items["publishButton"].addEventListener("click", publish);

  let inputItemsValues = [];

  function publish() {
    if (Object.values(inputItems).some((value) => value.value == "")) {
      return;
    }

    inputItemsValues = Object.values(inputItems).map((key) => key.value);

    const li = items["ul"].appendChild(createElement("li", ["story-info"], ""));
    const article = li.appendChild(createElement("article", [], ""));
    article.appendChild(
      createElement(
        "h4",
        [],
        `Name: ${inputItems.FirstName.value} ${inputItems.LastName.value}`
      )
    );
    article.appendChild(createElement("p", [], `Age: ${inputItems.Age.value}`));
    article.appendChild(
      createElement("p", [], `Title: ${inputItems.StoryTitle.value}`)
    );
    article.appendChild(
      createElement("p", [], `Genre: ${inputItems.Genre.value}`)
    );
    article.appendChild(
      createElement("p", [], `${inputItems.StoryText.value}`)
    );

    li.appendChild(
      createElement("button", ["save-btn"], "Save Story")
    ).addEventListener("click", save);
    li.appendChild(
      createElement("button", ["edit-btn"], "Edit Story")
    ).addEventListener("click", edit);
    li.appendChild(
      createElement("button", ["delete-btn"], "Delete Story")
    ).addEventListener("click", del);

    for (const key in inputItems) {
      if (key === "Genre") {
        continue;
      }

      inputItems[key].value = "";
    }

    items["publishButton"].disabled = true;
  }

  function save() {
    items["mainDiv"].innerHTML = "";
    items["mainDiv"].appendChild(
      createElement("h1", [], "Your scary story is saved!")
    );
  }

  function edit() {
    items["publishButton"].disabled = false;
    items["ul"].innerHTML = "";
    items["ul"].appendChild(createElement("h3", [], "Preview"));

    let count = 0;
    for (const key in inputItems) {
      inputItems[key].value = inputItemsValues[count++];
    }
  }

  function del() {
    items["publishButton"].disabled = false;
    items["ul"].innerHTML = "";
    items["ul"].appendChild(createElement("h3", [], "Preview"));
  }

  function createElement(tag, classList, textContent) {
    const element = document.createElement(tag);

    if (classList.length > 0) {
      element.classList = classList;
    }

    if (textContent) {
      element.textContent = textContent;
    }

    return element;
  }
}
