function attachEvents() {
  const ul = document.getElementById("phonebook");
  const url = "http://localhost:3030/jsonstore/phonebook";

  document.getElementById("btnLoad").addEventListener("click", loadContacts);
  document.getElementById("btnCreate").addEventListener("click", createContact);

  function createContact() {
    const person = document.getElementById("person");
    const phone = document.getElementById("phone");

    fetch(url, {
      method: "post",
      body: JSON.stringify({ person: person.value, phone: phone.value }),
    });

    person.value = "";
    phone.value = "";

    loadContacts();
  }

  function deleteContact() {
    Array.from(document.querySelectorAll("#phonebook li")).forEach((li) => {
      li.addEventListener("click", () => {
        fetch(`${url}/${li.id}`, {
          method: "delete",
        });
        li.remove();
      });
    });
  }

  function loadContacts() {
    ul.innerHTML = "";

    fetch(url)
      .then((res) => res.json())
      .then((res) => {
        for (const key in res) {
          const li = ul.appendChild(document.createElement("li"));
          li.id = res[key]["_id"];
          li.textContent = `${res[key]["person"]}: ${res[key]["phone"]}`;
        }

        Array.from(document.querySelectorAll("#phonebook li")).forEach((li) => {
          const button = li.appendChild(document.createElement("button"));
          button.textContent = "Delete";

          button.addEventListener("click", deleteContact);
        });
      });
  }
}

attachEvents();
