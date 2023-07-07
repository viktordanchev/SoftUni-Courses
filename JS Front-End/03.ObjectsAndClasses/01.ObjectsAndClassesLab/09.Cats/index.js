function solve(arr) {
  class Cat {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }

    meow() {
      console.log(`${this.name}, age ${this.age} says Meow`);
    }
  }

  for (let index = 0; index < arr.length; index++) {
    const [name, age] = arr[index].split(" ");
    const cat = new Cat(name, age);
    cat.meow();
  }
}

solve(["Mellow 2", "Tom 5"]);
solve(["Candy 1", "Poppy 3", "Nyx 2"]);
