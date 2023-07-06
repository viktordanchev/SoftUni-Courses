function convertObjectToJSON(name, lastName, hairColor) {
  const object = {
    name,
    lastName,
    hairColor,
  };

  console.log(JSON.stringify(object));
}

convertObjectToJSON("George", "Jones", "Brown");
convertObjectToJSON("Peter", "Smith", "Blond");
