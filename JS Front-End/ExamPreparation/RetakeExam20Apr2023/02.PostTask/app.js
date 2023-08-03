window.addEventListener("load", solve);

function solve() {
  const inputItems = {
    title: document.querySelector("#task-title"),
    category: document.querySelector("#task-category"),
    content: document.querySelector("#task-content"),
  };

  const items = {
    publishButton: document.querySelector("#publish-btn"),
    ulReview: document.querySelector("#review-list"),
    ulPublished: document.querySelector("#published-list"),
  };

  items["publishButton"].addEventListener("click", publish);

  function publish() {
    if (Object.values(inputItems).some((value) => value.value == "")) {
      for (const key in inputItems) {
        inputItems[key].value = "";
      }
      return;
    }

    const li = items["ulReview"].appendChild(createElement("li", "rpost", ""));

    const article = li.appendChild(createElement("article", "", ""));
    article.appendChild(
      createElement("h4", "", `${inputItems["title"].value}`)
    );
    article.appendChild(
      createElement("p", "", `Category: ${inputItems["category"].value}`)
    );
    article.appendChild(
      createElement("p", "", `Content: ${inputItems["content"].value}`)
    );

    const editButton = li.appendChild(
      createElement("button", "action-btn edit", "Edit")
    );
    editButton.addEventListener("click", () => {
      edit(li);
    });

    const postButton = li.appendChild(
      createElement("button", "action-btn post", "Post")
    );
    postButton.addEventListener("click", () => {
      post(li, editButton, postButton);
    });

    for (const key in inputItems) {
      inputItems[key].value = "";
    }
  }

  function edit(li) {
    inputItems["title"].value = li.querySelector("h4").textContent;
    inputItems["category"].value = li
      .querySelectorAll("p")[0]
      .textContent.slice(10);
    inputItems["content"].value = li
      .querySelectorAll("p")[1]
      .textContent.slice(9);

    li.remove();
  }

  function post(li, editButton, postButton) {
    li.removeChild(editButton);
    li.removeChild(postButton);
    li.remove();
    items["ulPublished"].appendChild(li);
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
