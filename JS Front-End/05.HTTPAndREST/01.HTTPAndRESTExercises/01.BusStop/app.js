function getInfo() {
  const busID = document.getElementById("stopId").value;

  const repo = fetch(
    `http://localhost:3030/jsonstore/bus/businfo/${busID}`
  ).then((repo) => repo.json());

  console.log(repo);
}
