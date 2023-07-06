function printCityInfo(city) {
  for (const array of Object.entries(city)) {
    console.log(array[0] + " -> " + array[1]);
  }
}

printCityInfo({
  name: "Sofia",
  area: 492,
  population: 1238438,
  country: "Bulgaria",
  postCode: "1000",
});
