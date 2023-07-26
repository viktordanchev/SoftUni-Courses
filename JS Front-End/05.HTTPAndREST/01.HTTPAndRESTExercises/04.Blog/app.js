function attachEvents() {
  const loadButton = document.getElementById("btnLoadPosts");
  const viewButton = document.getElementById("btnViewPost");
  const ul = document.getElementById("post-comments");

  loadButton.addEventListener("click", getPosts);
  viewButton.addEventListener("click", view);

  const posts = {};

  async function getPosts() {
    try {
      const res = await (
        await fetch("http://localhost:3030/jsonstore/blog/posts")
      ).json();

      for (const object in res) {
        const option = document
          .getElementById("posts")
          .appendChild(document.createElement("option"));

        option.value = object;
        option.textContent = res[object]["title"];
        posts[object] = [res[object]["title"], res[object]["body"]];
      }
    } catch (error) {}
  }

  async function view() {
    ul.innerHTML = "";
    const post = document.getElementById("posts").value;
    const comments = {};

    try {
      const res = await (
        await fetch("http://localhost:3030/jsonstore/blog/comments")
      ).json();

      for (const object in res) {
        const postID = res[object]["postId"];
        if (postID === post) {
          comments[res[object]["id"]] = res[object]["text"];
        }
      }
    } catch (error) {}

    document.getElementById("post-title").textContent = posts[post][0];
    document.getElementById("post-body").textContent = posts[post][1];

    for (const comment in comments) {
      const li = ul.appendChild(document.createElement("li"));
      li.id = comment;
      li.textContent = comments[comment];
    }
  }
}

attachEvents();
