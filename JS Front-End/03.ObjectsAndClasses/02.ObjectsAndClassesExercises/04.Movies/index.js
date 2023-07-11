function solve(arr) {
  class Movie {
    constructor(name, director, date) {
      this.name = name;
      this.director = director;
      this.date = date;
    }
  }

  const movies = [];

  while (arr.length > 0) {
    const line = arr.shift();

    if (line.includes("addMovie")) {
      const name = line.substring(9);
      movies.push(new Movie(name));
    } else if (line.includes("directedBy")) {
      const data = line.replace("directedBy", "|").split(" | ");
      const name = data[0];
      const director = data[1];
      const movie = movies.find((movie) => movie.name === name);

      if (movie !== undefined) {
        movie.director = director;
      }
    } else {
      const data = line.replace("onDate", "|").split(" | ");
      const name = data[0];
      const date = data[1];
      const movie = movies.find((movie) => movie.name === name);

      if (movie !== undefined) {
        movie.date = date;
      }
    }
  }

  movies.forEach((movie) => {
    if (movie.director !== undefined || movie.director !== undefined) {
      console.log(JSON.stringify(movie));
    }
  });
}

solve([
  "addMovie Fast and Furious",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis Ford Coppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
]);
solve([
  "addMovie The Avengers",
  "addMovie Superman",
  "The Avengers directedBy Anthony Russo",
  "The Avengers onDate 30.07.2010",
  "Captain America onDate 30.07.2010",
  "Captain America directedBy Joe Russo",
]);
