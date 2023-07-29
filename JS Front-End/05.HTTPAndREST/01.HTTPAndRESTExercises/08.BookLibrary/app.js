function attachEvents() {
  const url = "http://localhost:3030/jsonstore/collections/books";
  const tbody = document.querySelector("tbody");
  const button = document.querySelector("#form button");
  const title = document.getElementsByName("title")[0];
  const author = document.getElementsByName("author")[0];

  document.getElementById("loadBooks").addEventListener("click", loadAllBooks);
  button.addEventListener("click", createNewBook);

  async function loadAllBooks() {
    tbody.innerHTML = "";

    const res = await (await fetch(url)).json();

    for (const id in res) {
      const tr = tbody.appendChild(document.createElement("tr"));

      const tdAuthor = tr.appendChild(document.createElement("td"));
      tdAuthor.textContent = res[id]["author"];
      const tdTitle = tr.appendChild(document.createElement("td"));
      tdTitle.textContent = res[id]["title"];

      const tdButtons = tr.appendChild(document.createElement("td"));

      const editButton = tdButtons.appendChild(
        document.createElement("button")
      );
      editButton.textContent = "Edit";
      editButton.addEventListener("click", () => {
        editBook(tdAuthor, tdTitle, id);
      });

      const deleteButton = tdButtons.appendChild(
        document.createElement("button")
      );
      deleteButton.textContent = "Delete";
      deleteButton.addEventListener("click", () => {
        deleteBook(id);
      });
    }
  }

  async function editBook(tdAuthor, tdTitle, id) {
    author.value = tdAuthor.textContent;
    title.value = tdTitle.textContent;

    document.querySelector("#form h3").textContent = "Edit FORM";
    button.textContent = "Save";

    button.removeEventListener("click", createNewBook);
    button.addEventListener("click", async () => {
      if (title.value && author.value) {
        await fetch(`${url}/${id}`, {
          method: "put",
          body: JSON.stringify({ author: author.value, title: title.value }),
        });
      }

      document.querySelector("#form h3").textContent = "FORM";
      button.textContent = "Submit";
      button.addEventListener("click", createNewBook);
      author.value = "";
      title.value = "";
    });
  }

  async function deleteBook(id) {
    await fetch(`${url}/${id}`, { method: "delete" });
    loadAllBooks();
  }

  async function createNewBook() {
    if (title.value && author.value) {
      await fetch(url, {
        method: "post",
        body: JSON.stringify({ author: author.value, title: title.value }),
      });
    }

    author.value = "";
    title.value = "";
  }
}

attachEvents();
