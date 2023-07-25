function getInfo() {
  const busID = document.getElementById("stopId").value;
  getRepo(busID);

  function getRepo(busID) {
    const stopName = document.getElementById("stopName");

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${busID}`)
      .then((res) => res.json())
      .then((data) => {
        stopName.textContent = data["name"];
        const keys = Object.keys(data["buses"]);

        for (const key of keys) {
          const li = document
            .getElementById("buses")
            .appendChild(document.createElement("li"));

          li.textContent = `Bus ${key} arrives in ${data["buses"][key]} minutes`;
        }
      })
      .catch(() => stopName.textContent = "Error");

    document.getElementById("stopId").value = "";
    document.getElementById("buses").innerHTML = "";
  }
}
