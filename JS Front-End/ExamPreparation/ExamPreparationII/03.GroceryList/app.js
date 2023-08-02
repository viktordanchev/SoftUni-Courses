function solve() {
  const url = "http://localhost:3030/jsonstore/grocery";

  const inputItems = {
    product: document.querySelector("#product"),
    count: document.querySelector("#count"),
    price: document.querySelector("#price"),
  };

  const items = {
    loadButton: document.querySelector("#load-product"),
    addButton: document.querySelector("#add-product"),
    updateButton: document.querySelector("#update-product"),
    tbody: document.querySelector("#tbody"),
  };

  items["loadButton"].addEventListener("click", loadAllProducts);
  items["addButton"].addEventListener("click", addProduct);

  async function loadAllProducts() {
    items["tbody"].innerHTML = "";
    const res = await (await fetch(url)).json();

    for (const product in res) {
      const productName = res[product]["product"];
      const count = res[product]["count"];
      const price = res[product]["price"];

      const tr = items["tbody"].appendChild(createElement("tr", "", ""));
      tr.appendChild(createElement("td", "name", productName));
      tr.appendChild(createElement("td", "count-product", count));
      tr.appendChild(createElement("td", "product-price", price));

      const buttons = tr.appendChild(createElement("td", "btn", ""));
      buttons
        .appendChild(createElement("button", "update", "Update"))
        .addEventListener("click", async () => {
          items["addButton"].disabled = true;
          items["updateButton"].disabled = false;

          inputItems["product"].value = productName;
          inputItems["count"].value = count;
          inputItems["price"].value = price;

          items["updateButton"].addEventListener("click", () => {
            updateButton(
              product,
              inputItems["product"].value,
              inputItems["count"].value,
              inputItems["price"].value
            );
          });
        });
      buttons
        .appendChild(createElement("button", "delete", "Delete"))
        .addEventListener("click", async () => {
          await fetch(`${url}/${product}`, { method: "DELETE" });
          loadAllProducts();
        });
    }
  }

  function updateButton(id, product, count, price) {
    fetch(`${url}/${id}`, {
      method: "PATCH",
      body: JSON.stringify({
        product,
        count,
        price,
      }),
    });

    items["addButton"].disabled = false;
    items["updateButton"].disabled = true;
    for (const key in inputItems) {
      inputItems[key].value = "";
    }
    loadAllProducts();
  }

  function addProduct(event) {
    fetch(url, {
      method: "POST",
      body: JSON.stringify({
        product: inputItems["product"].value,
        count: inputItems["count"].value,
        price: inputItems["price"].value,
      }),
    });

    for (const key in inputItems) {
      inputItems[key].value = "";
    }

    loadAllProducts();
    event.preventDefault();
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
