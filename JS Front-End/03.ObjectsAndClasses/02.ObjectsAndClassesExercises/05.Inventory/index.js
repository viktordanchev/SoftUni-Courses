function registerHeroes(arr) {
  class Hero {
    constructor(name, level, items) {
      this.name = name;
      this.level = level;
      this.items = items;
    }

    toString() {
      console.log(`Hero: ${this.name}`);
      console.log(`level => ${this.level}`);
      console.log(`items => ${this.items}`);
    }
  }

  const heroes = [];

  while (arr.length > 0) {
    const data = arr.shift().split(" / ");
    heroes.push(new Hero(data[0], data[1], data[2]));
  }

  heroes
    .sort((a, b) => {
      return a.level - b.level;
    })
    .forEach((hero) => hero.toString());
}

registerHeroes([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);
registerHeroes([
  "Batman / 2 / Banana, Gun",
  "Superman / 18 / Sword",
  "Poppy / 28 / Sentinel, Antara",
]);
