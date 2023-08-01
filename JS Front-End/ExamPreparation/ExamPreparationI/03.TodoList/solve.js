function attachEvents() {
  const url = "http://localhost:3030/jsonstore/tasks";

  document.querySelector("#load-button").addEventListener("click", loadAll);
  document.querySelector("#add-button").addEventListener("click", addTask);
  const ul = document.querySelector("#todo-list");

  async function addTask() {
    const name = document.querySelector("#title").value;

    if (name) {
      await fetch(url, {
        method: "post",
        body: JSON.stringify({ name }),
      });
    }
  }

  async function loadAll() {
    ul.innerHTML = "";
    const res = await (await fetch(url)).json();

    for (const key in res) {
      const li = ul.appendChild(document.createElement("li"));
      li.appendChild(document.createElement("span")).textContent =
        res[key]["name"];
      const removeButton = li.appendChild(document.createElement("button"));
      removeButton.textContent = "Remove";
      removeButton.addEventListener();
      const editButton = li.appendChild(document.createElement("button"));
      editButton.textContent = "Edit";
    }
  }
}

attachEvents();
