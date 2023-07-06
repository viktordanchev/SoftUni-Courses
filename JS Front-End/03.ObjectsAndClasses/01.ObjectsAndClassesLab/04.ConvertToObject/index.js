function convertJSONToObject(input) {
  const object = JSON.parse(input);

  for (const key in object) {
    console.log(`${key}: ${object[key]}`);
  }
}

convertJSONToObject('{"name": "George", "age": 40, "town": "Sofia"}');
convertJSONToObject('{"name": "Peter", "age": 35, "town": "Plovdiv"}');
