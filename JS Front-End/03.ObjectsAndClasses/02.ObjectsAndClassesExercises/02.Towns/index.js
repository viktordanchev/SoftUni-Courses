function solve(arr) {
  for (let index = 0; index < arr.length; index++) {
    const cityData = arr[index].split(" | ");

    function createCity(cityData) {
      return {
        town: cityData[0],
        latitude: Number(cityData[1]).toFixed(2),
        longitude: Number(cityData[2]).toFixed(2),
      };
    }

    console.log(createCity(cityData));
  }
}

solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);
