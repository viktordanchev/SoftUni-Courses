function sovle(arr) {
  const numberOfPieces = arr.shift();
  const pieces = arr.splice(0, numberOfPieces).reduce((acc, piece) => {
    acc.push({
      piece: piece[0],
      composer: piece[1],
      key: piece[2],
    });
    return acc;
  }, []);

  const commands = {
    Add: addPiece,
    Remove: removePiece,
    ChangeKey: changeKey,
  };

  function addPiece() {}
  function removePiece() {}
  function changeKey() {}
}

sovle([
  "3",
  "Fur Elise|Beethoven|A Minor",
  "Moonlight Sonata|Beethoven|C# Minor",
  "Clair de Lune|Debussy|C# Minor",
  "Add|Sonata No.2|Chopin|B Minor",
  "Add|Hungarian Rhapsody No.2|Liszt|C# Minor",
  "Add|Fur Elise|Beethoven|C# Minor",
  "Remove|Clair de Lune",
  "ChangeKey|Moonlight Sonata|C# Major",
  "Stop",
]);
