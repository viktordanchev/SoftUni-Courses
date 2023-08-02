function solve(arr) {
  let groceries = arr.shift().split("!");

  const commands = {
    Urgent: add,
    Unnecessary: remove,
    Correct: changeName,
    Rearrange: rearrange,
  };

  while (true) {
    const data = arr.shift();

    if (data === "Go Shopping!") {
      break;
    }

    const [command, ...res] = data.split(" ");
    commands[command](...res);
  }

  console.log(groceries.join(", "));

  function add(item) {
    if (!groceries.includes(item)) {
      groceries.unshift(item);
    }
  }

  function remove(item) {
    if (groceries.includes(item)) {
      groceries = groceries.filter((el) => el !== item);
    }
  }

  function changeName(oldItem, newItem) {
    if (groceries.includes(oldItem)) {
      groceries[groceries.indexOf(oldItem)] = newItem;
    }
  }

  function rearrange(item) {
    if (groceries.includes(item)) {
      const index = groceries.indexOf(item);
      groceries.push(groceries.splice(index, 1));
    }
  }
}

solve([
  "Tomatoes!Potatoes!Bread",
  "Unnecessary Milk",
  "Urgent Tomatoes",
  "Go Shopping!",
]);
solve([
  "Milk!Pepper!Salt!Water!Banana",
  "Urgent Salt",
  "Unnecessary Grapes",
  "Correct Pepper Onion",
  "Rearrange Grapes",
  "Correct Tomatoes Potatoes",
  "Go Shopping!",
]);
