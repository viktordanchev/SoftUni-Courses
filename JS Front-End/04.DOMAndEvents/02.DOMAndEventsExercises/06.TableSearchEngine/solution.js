function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    const match = document.getElementById("searchField").value;
    const tdData = Array.from(document.querySelectorAll("tbody td")).forEach(
      (td) => {
        if (td.textContent.includes(match)) {
          td.parentElement.className = "select";
        }
      }
    );

    document.getElementById("searchField").value = "";
  }
}
