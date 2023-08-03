function solve(arr) {
  let horses = arr.shift().split("|");

  const commands = {
    Retake: retake,
    Trouble: trouble,
    Rage: rage,
    Miracle: miracle,
  };

  while (true) {
    const data = arr.shift();

    if (data === "Finish") {
      break;
    }

    const [command, ...res] = data.split(" ");
    commands[command](...res);
  }

  console.log(horses.join("->"));
  console.log(`The winner is: ${horses.pop()}`);

  function retake(overtakingHorse, overtakenHorse) {
    const overtakenHorseIndex = horses.indexOf(overtakenHorse);
    const overtakingHorseIndex = horses.indexOf(overtakingHorse);

    if (overtakingHorseIndex < overtakenHorseIndex) {
      horses[overtakingHorseIndex] = overtakenHorse;
      horses[overtakenHorseIndex] = overtakingHorse;
      console.log(`${overtakingHorse} retakes ${overtakenHorse}.`);
    }
  }

  function trouble(horse) {
    const horseIndex = horses.indexOf(horse);
    const overtakingHorseIndex = horseIndex - 1;

    if (horseIndex > 0) {
      horses[horseIndex] = horses[overtakingHorseIndex];
      horses[overtakingHorseIndex] = horse;
      console.log(`Trouble for ${horse} - drops one position.`);
    }
  }

  function rage(horse) {
    for (let index = 0; index < 2; index++) {
      if (horses.indexOf(horse) === horses.length - 1) {
        break;
      }

      const horseIndex = horses.indexOf(horse);
      const overtakenHorseIndex = horseIndex + 1;
      horses[horseIndex] = horses[overtakenHorseIndex];
      horses[overtakenHorseIndex] = horse;
    }

    console.log(`${horse} rages 2 positions ahead.`);
  }

  function miracle() {
    const lastHorse = horses.shift();
    horses.push(lastHorse);

    console.log(`What a miracle - ${lastHorse} becomes first.`);
  }
}

solve([
  "Bella|Alexia|Sugar",
  "Retake Alexia Sugar",
  "Rage Bella",
  "Trouble Bella",
  "Finish",
]);
solve([
  "Onyx|Domino|Sugar|Fiona",
  "Trouble Onyx",
  "Retake Onyx Sugar",
  "Rage Domino",
  "Miracle",
  "Finish",
]);
solve([
  "Fancy|Lilly",
  "Retake Lilly Fancy",
  "Trouble Lilly",
  "Trouble Lilly",
  "Finish",
  "Rage Lilly",
]);
