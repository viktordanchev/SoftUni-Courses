function attachEvents() {
  const button = document.getElementById("submit");
  button.addEventListener("click", getWeather);

  function getWeather() {
    const location = document.getElementById("location").value;
    fetch("http://localhost:3030/jsonstore/forecaster/locations")
      .then((res) => res.json())
      .then((locations) => {
        for (const currLocation of locations) {
          if (currLocation["name"] === location) {
            document.getElementById("forecast").style = "display:block";
            displayWeatherToday(currLocation["code"]);
          }
        }
      });
  }

  async function displayWeatherToday(code) {
    try {
      await (
        await fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`)
      ).json();

      document
        .getElementById("current")
        .appendChild(document.createElement("div"))
        .classList.add("forecasts");

      const forecasts = document.querySelector("div.forecasts");

      forecasts
        .appendChild(document.createElement("span"))
        .classList.add("condition", "symbol");

      forecasts
        .appendChild(document.createElement("span"))
        .classList.add("condition");

      const spanCondition = document.querySelector("span.condition");

      console.log(spanCondition);

      spanCondition.appendChild(document.createElement("span"));
    } catch (error) {}
  }
}

attachEvents();
