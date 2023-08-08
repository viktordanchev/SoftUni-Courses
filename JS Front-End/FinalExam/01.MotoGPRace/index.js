function solve(arr) {
  const ridersNum = arr.shift();

  let riders = [];

  for (let index = 0; index < ridersNum; index++) {
    const riderData = arr.shift().split("|");
    riders.push({
      rider: riderData[0],
      fuel: Number(riderData[1]),
      position: riderData[2],
    });
  }

  const commands = {
    StopForFuel: stopForFuel,
    Overtaking: overtaking,
    EngineFail: engineFail,
  };

  while (true) {
    const data = arr.shift();

    if (data === "Finish") {
      break;
    }

    const [command, ...res] = data.split(" - ");
    commands[command](...res);
  }

  riders.forEach((rider) => {
    console.log(rider.rider);
    console.log(`  Final position: ${rider.position}`);
  });

  function stopForFuel(rider, minFuel, changedPosition) {
    const currRider = riders.filter((el) => el.rider === rider)[0];

    if (currRider.fuel < Number(minFuel)) {
      currRider.position = changedPosition;
      currRider.fuel = 100;

      console.log(
        `${rider} stopped to refuel but lost his position, now he is ${changedPosition}.`
      );
    } else {
      console.log(`${rider} does not need to stop for fuel!`);
    }
  }

  function overtaking(firstRiderName, secondRiderName) {
    const firstRider = riders.filter((el) => el.rider === firstRiderName)[0];
    const secondRider = riders.filter((el) => el.rider === secondRiderName)[0];

    if (firstRider.position < secondRider.position) {
      const firstRiderPositon = firstRider.position;
      firstRider.position = secondRider.position;
      secondRider.position = firstRiderPositon;

      console.log(`${firstRiderName} overtook ${secondRiderName}!`);
    }
  }

  function engineFail(rider, lapsLeft) {
    riders = riders.reduce((acc, currRider) => {
      if (currRider.rider !== rider) {
        acc.push(currRider);
      }
      return acc;
    }, []);

    console.log(
      `${rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
    );
  }
}

solve([
  "3",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|2",
  "Jorge Lorenzo|80|3",
  "StopForFuel - Valentino Rossi - 50 - 1",
  "Overtaking - Marc Marquez - Jorge Lorenzo",
  "EngineFail - Marc Marquez - 10",
  "Finish",
]);
