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
            displayWeatherThreeDayForecast(currLocation["code"]);
          }
        }
      });
  }

  async function displayWeatherToday(code) {
    try {
      const res = await (
        await fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`)
      ).json();

      const resData = {
        0: res["name"],
        1: `${res["forecast"]["low"]}°/${res["forecast"]["high"]}°`,
        2: res["forecast"]["condition"],
      };

      const forecasts = document
        .getElementById("current")
        .appendChild(document.createElement("div"));

      forecasts.className = "forecasts";

      forecasts
        .appendChild(document.createElement("span"))
        .classList.add("condition", "symbol");

      const spanSymbol = document.querySelector("span.symbol");
      spanSymbol.textContent = symbol[resData[2]];

      forecasts.appendChild(document.createElement("span")).className =
        "condition";

      const spanCondition = document.querySelectorAll("span.condition")[1];

      for (let index = 0; index < 3; index++) {
        spanCondition.appendChild(document.createElement("span")).className =
          "forecast-data";
      }

      const spanForecastData = document.querySelectorAll("span.forecast-data");

      for (let index = 0; index < 3; index++) {
        spanForecastData[index].textContent = resData[index];
      }
    } catch (error) {}
  }

  async function displayWeatherThreeDayForecast(code) {
    try {
      const res = await (
        await fetch(
          `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`
        )
      ).json();

      const upcoming = document
        .getElementById("upcoming")
        .appendChild(document.createElement("div"));

      upcoming.className = "forecast-info";

      for (let index = 0; index < 3; index++) {
        const resData = res["forecast"][index];

        const spanUpcoming = upcoming.appendChild(
          document.createElement("span")
        );
        spanUpcoming.className = "upcoming";

        const spanSymbol = spanUpcoming.appendChild(
          document.createElement("span")
        );
        spanSymbol.className = "symbol";
        spanSymbol.textContent = symbol[resData["condition"]];

        const resDataObject = {
          0: `${resData["low"]}°/${resData["high"]}°`,
          1: resData["condition"],
        };

        for (let index = 0; index < 2; index++) {
          const spanForecastDataTemperature = spanUpcoming.appendChild(
            document.createElement("span")
          );
          spanForecastDataTemperature.className = "forecast-data";
          spanForecastDataTemperature.textContent = resDataObject[index];
        }
      }
    } catch (error) {}
  }

  const symbol = {
    Sunny: "\u2600",
    "Partly sunny": "\u26C5",
    Overcast: "\u2601",
    Rain: "\u2614",
  };
}

attachEvents();
