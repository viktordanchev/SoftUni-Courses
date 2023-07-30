async function lockedProfile() {
  const url = "http://localhost:3030/jsonstore/advanced/profiles";
  const main = document.getElementById("main");
  main.innerHTML = "";

  await loadData();

  Array.from(document.querySelectorAll("div.profile")).forEach((profile) => {
    const button = profile.getElementsByTagName("button")[0];
    button.addEventListener("click", () => {
      action(profile, button);
    });
  });

  async function loadData() {
    let count = 1;
    const res = await (await fetch(url)).json();

    for (const key in res) {
      const profileHtml = `<div class="profile">
      <img src="./iconProfile2.png" class="userIcon" />
      <label>Lock</label>
      <input type="radio" name="user${count}Locked" value="lock" checked>
      <label>Unlock</label>
      <input type="radio" name="user${count}Locked" value="unlock"><br>
      <hr>
      <label>Username</label>
      <input type="text" name="user${count}Username" value="${res[key]["username"]}" disabled readonly />
      <div class="user${count}Username hiddenInfo">
        <hr>
        <label>Email:</label>
        <input type="email" name="user${count}Email" value="${res[key]["email"]}" disabled readonly />
        <label>Age:</label>
        <input type="text" name="user${count}Age" value="${res[key]["age"]}" disabled readonly />
      </div>

      <button>Show more</button>
    </div>`;

      main.innerHTML += profileHtml;
      count++;
    }
  }

  function action(profile, button) {
    if (button.textContent === "Show more") {
      if (!profile.querySelector([`input[value="unlock"]`]).checked) {
        return;
      }
      profile.querySelector(".profile>div").classList.remove("hiddenInfo");
      button.textContent = "Hide it";
    } else {
      if (!profile.querySelector([`input[value="unlock"]`]).checked) {
        return;
      }
      profile.querySelector(".profile>div").classList.add("hiddenInfo");
      button.textContent = "Show more";
    }
  }
}
