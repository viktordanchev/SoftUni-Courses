function attachEvents() {
  const url = "http://localhost:3030/jsonstore/messenger";
  const textarea = document.getElementById("messages");

  document.getElementById("submit").addEventListener("click", send);
  document.getElementById("refresh").addEventListener("click", get);

  function send() {
    let authorName = document.getElementsByName("author")[0];
    let msgText = document.getElementsByName("content")[0];

    fetch(url, {
      method: "post",
      body: JSON.stringify({
        author: authorName.value,
        content: msgText.value,
      }),
    });

    authorName.value = "";
    msgText.value = "";
  }

  function get() {
    textarea.value = "";

    fetch(url)
      .then((res) => res.json())
      .then((res) => {
        const array = [];
        for (const key in res) {
          array.push(`${res[key]["author"]}: ${res[key]["content"]}`);
        }

        textarea.value += array.join("\n");
      });
  }
}

attachEvents();
