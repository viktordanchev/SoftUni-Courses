function solve(arr) {
  class Song {
    constructor(type, name, time) {
      this.type = type;
      this.name = name;
      this.time = time;
    }

    printName() {
      console.log(this.name);
    }
  }

  const type = arr.pop();
  const songs = [];
  const count = arr.shift();

  for (let index = 0; index < count; index++) {
    const [type, name, time] = arr[index].split("_");
    const song = new Song(type, name, time);
    songs.push(song);
  }

  songs.forEach((song) => {
    if (song.type === type || type == "all") {
      song.printName();
    }
  });
}

solve([
  3,
  "favourite_DownTown_3:14",
  "favourite_Kiss_4:16",
  "favourite_Smooth Criminal_4:01",
  "favourite",
]);
solve([
  4,
  "favourite_DownTown_3:14",
  "listenLater_Andalouse_3:24",
  "favourite_In To The Night_3:58",
  "favourite_Live It Up_3:48",
  "listenLater",
]);
solve([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);
