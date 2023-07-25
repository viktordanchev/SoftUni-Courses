function solve() {
  let ID = "depot";
  let stopName = "";
  const spanInfo = document.querySelector("span.info");
  const departButton = document.getElementById("depart");
  const arriveButton = document.getElementById("arrive");

  function depart() {
    fetch(`http://localhost:3030/jsonstore/bus/schedule/${ID}`)
      .then((res) => res.json())
      .then((data) => {
        stopName = data["name"];
        ID = data["next"];

        spanInfo.textContent = `Next stop ${stopName}`;
      });

    departButton.disabled = true;
    arriveButton.disabled = false;
  }

  async function arrive() {
    spanInfo.textContent = `Arriving at ${stopName}`;
    departButton.disabled = false;
    arriveButton.disabled = true;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
