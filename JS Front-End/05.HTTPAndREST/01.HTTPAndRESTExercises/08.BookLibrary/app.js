function attachEvents() {
  const url = "http://localhost:3030/jsonstore/collections/books";
  const tbody = document.querySelector("tbody");

  document.getElementById("loadBooks").addEventListener("click", loadAllBooks);
  document
    .querySelector("#form button")
    .addEventListener("click", createNewBook);

  async function loadAllBooks() {
    tbody.innerHTML = "";

    const res = await (await fetch(url)).json();

    for (const key in res) {
      const tr = tbody.appendChild(document.createElement("tr"));

      tr.appendChild(document.createElement("td")).textContent =
        res[key]["author"];
      tr.appendChild(document.createElement("td")).textContent =
        res[key]["title"];
      const tdButtons = tr.appendChild(document.createElement("td"));
      tdButtons.appendChild(document.createElement("button")).textContent =
        "Edit";
      tdButtons.appendChild(document.createElement("button")).textContent =
        "Delete";
    }
  }

  async function createNewBook() {
    const title = document.getElementsByName("title")[0];
    const author = document.getElementsByName("author")[0];

    if (!title || !author) {
      return;
    }

    await fetch(url, {
      method: "post",
      body: JSON.stringify({ author: author.value, title: title.value }),
    });

    author.value = "";
    title.value = "";
  }
}

attachEvents();
