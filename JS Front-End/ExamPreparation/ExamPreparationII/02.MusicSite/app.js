window.addEventListener("load", solve);

function solve() {
  const inputItems = {
    genre: document.querySelector("#genre"),
    songName: document.querySelector("#name"),
    author: document.querySelector("#author"),
    date: document.querySelector("#date"),
  };

  const items = {
    addButton: document.querySelector("#add-btn"),
    divAllHits: document.querySelector("#all-hits>.all-hits-container"),
    divSavedHits: document.querySelector("#saved-hits>.saved-container"),
  };

  let likes = 0;

  items["addButton"].addEventListener("click", add);

  function add(event) {
    if (Object.values(inputItems).some((value) => value.value == "")) {
      return;
    }

    const divHitsInfo = items["divAllHits"].appendChild(
      createElement("div", "hits-info", "")
    );

    const img = divHitsInfo.appendChild(createElement("img", "", ""));
    img.src = "./static/img/img.png";

    divHitsInfo.appendChild(
      createElement("h2", "", `Genre: ${inputItems["genre"].value}`)
    );
    divHitsInfo.appendChild(
      createElement("h2", "", `Name: ${inputItems["songName"].value}`)
    );
    divHitsInfo.appendChild(
      createElement("h2", "", `Author: ${inputItems["author"].value}`)
    );
    divHitsInfo.appendChild(
      createElement("h3", "", `Date: ${inputItems["date"].value}`)
    );

    divHitsInfo
      .appendChild(createElement("button", "save-btn", "Save song"))
      .addEventListener("click", () => {
        save(divHitsInfo);
      });

    divHitsInfo
      .appendChild(createElement("button", "like-btn", "Like song"))
      .addEventListener("click", () => {
        like(divHitsInfo);
      });

    divHitsInfo
      .appendChild(createElement("button", "delete-btn", "Delete"))
      .addEventListener("click", () => {
        deleteSong(divHitsInfo);
      });

    for (const key in inputItems) {
      inputItems[key].value = "";
    }

    event.preventDefault();
  }

  function save(divHitsInfo) {
    divHitsInfo.removeChild(divHitsInfo.querySelector("button.like-btn"));
    divHitsInfo.removeChild(divHitsInfo.querySelector("button.save-btn"));

    items["divSavedHits"].appendChild(divHitsInfo);
    items["divAllHits"].removeChild(divHitsInfo);
  }

  function like(divHitsInfo) {
    const totalLikes = document.querySelector("#total-likes>.likes>p");
    totalLikes.textContent = `Total Likes: ${++likes}`;
    divHitsInfo.querySelector(".like-btn").disabled = true;
  }

  function deleteSong(divHitsInfo) {
    const parent = divHitsInfo.parentElement;
    parent.removeChild(divHitsInfo);
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
