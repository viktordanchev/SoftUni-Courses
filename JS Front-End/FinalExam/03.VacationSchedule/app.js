function solve() {
  const url = "http://localhost:3030/jsonstore/tasks";

  const inputItems = {
    name: document.querySelector("#name"),
    days: document.querySelector("#num-days"),
    date: document.querySelector("#from-date"),
  };

  const items = {
    loadButton: document.querySelector("#load-vacations"),
    addButton: document.querySelector("#add-vacation"),
    editButton: document.querySelector("#edit-vacation"),
    divList: document.querySelector("#list"),
  };

  items["loadButton"].addEventListener("click", printAllVacations);
  items["addButton"].addEventListener("click", addVacation);

  function addVacation() {
    if (Object.values(inputItems).some((value) => value.value == "")) {
      clearInputs();
      return;
    }

    const name = inputItems["name"].value;
    const days = inputItems["days"].value;
    const date = inputItems["date"].value;

    fetch(url, { method: "post", body: JSON.stringify({ name, days, date }) });

    clearInputs();
  }

  async function printAllVacations() {
    const res = await (await fetch(url)).json();
    items["divList"].innerHTML = "";

    for (const key in res) {
      const divContainer = items["divList"].appendChild(
        createElement("div", "container", "")
      );
      divContainer.appendChild(createElement("h2", "", res[key]["name"]));
      divContainer.appendChild(createElement("h3", "", res[key]["date"]));
      divContainer.appendChild(createElement("h3", "", res[key]["days"]));

      const changeButton = divContainer.appendChild(
        createElement("button", "change-btn", "Change")
      );
      changeButton.addEventListener("click", () => {
        edit(divContainer, res[key]["_id"]);
      });

      const doneButton = divContainer.appendChild(
        createElement("button", "done-btn", "Done")
      );
      doneButton.addEventListener("click", () => {
        del(divContainer, res[key]["_id"]);
      });
    }
  }

  function del(divContainer, id) {
    divContainer.remove();
    fetch(`${url}/${id}`, { method: "delete" });
  }

  function edit(divContainer, id) {
    inputItems["name"].value = divContainer.querySelector("h2").textContent;
    inputItems["date"].value = divContainer.querySelectorAll("h3")[0].textContent;
    inputItems["days"].value = divContainer.querySelectorAll("h3")[1].textContent;

    divContainer.remove();
    items["addButton"].disabled = true;
    items["editButton"].disabled = false;
    items["editButton"].addEventListener("click", (event) => {
      event.preventDefault();
      items["addButton"].disabled = true;
      items["editButton"].disabled = false;

      fetch(`${url}/${id}`, {
        method: "put",
        body: JSON.stringify({
          name: inputItems["name"].value,
          days: inputItems["days"].value,
          date: inputItems["date"].value,
        }),
      });
    });
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

solve();
