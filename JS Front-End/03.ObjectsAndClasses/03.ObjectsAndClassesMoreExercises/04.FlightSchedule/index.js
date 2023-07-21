function solve(arr) {
  const allFlights = arr[0].reduce((object, flight) => {
    flight = flight.split(" ");
    const key = flight[0];
    const value = flight.slice(1).join(" ");
    object[key] = { ["Destination"]: value, ["Status"]: "Ready to fly" };
    return object;
  }, {});
  const statuses = arr[1].reduce((object, flight) => {
    const [key, value] = flight.split(" ");
    object[key] = value;
    return object;
  }, {});
  const status = arr[2][0];

  for (const key in statuses) {
    if (allFlights[key]) {
      allFlights[key]["Status"] = statuses[key];
    }
  }

  for (const key in allFlights) {
    if (allFlights[key]["Status"] === status) {
      console.log(allFlights[key]);
    }
  }
}

solve([
  [
    "WN269 Delaware",
    "FL2269 Oregon",
    "WN498 Las Vegas",
    "WN3145 Ohio",
    "WN612 Alabama",
    "WN4010 New York",
    "WN1173 California",
    "DL2120 Texas",
    "KL5744 Illinois",
    "WN678 Pennsylvania",
  ],
  [
    "DL2120 Cancelled",
    "WN612 Cancelled",
    "WN1173 Cancelled",
    "SK430 Cancelled",
  ],
  ["Cancelled"],
]);
solve([
  [
    "WN269 Delaware",
    "FL2269 Oregon",
    "WN498 Las Vegas",
    "WN3145 Ohio",
    "WN612 Alabama",
    "WN4010 New York",
    "WN1173 California",
    "DL2120 Texas",
    "KL5744 Illinois",
    "WN678 Pennsylvania",
  ],
  [
    "DL2120 Cancelled",
    "WN612 Cancelled",
    "WN1173 Cancelled",
    "SK330 Cancelled",
  ],
  ["Ready to fly"],
]);
