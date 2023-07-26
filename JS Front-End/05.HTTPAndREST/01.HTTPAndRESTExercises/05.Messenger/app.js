function attachEvents() {
  const url = "http://localhost:3030/jsonstore/messenger";
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
    fetch(url)
      .then((res) => res.json())
      .then((res) => {
        console.log(res);
        const textarea = document.getElementById("messages");

        for (const key in res) {
          const author = Object.entries(res[key])[0][1];
          const content = Object.entries(res[key])[1][1];

          textarea.value += `${author}: ${content}` + "\n";
        }
      });
  }
}

attachEvents();
