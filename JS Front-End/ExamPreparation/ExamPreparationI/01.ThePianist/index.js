function sovle(arr) {
  const numberOfPieces = arr.shift();
  let pieces = arr.splice(0, numberOfPieces).reduce((acc, piece) => {
    piece = piece.split("|");
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

  while (true) {
    const [command, ...res] = arr.shift().split("|");

    if (command === "Stop") {
      break;
    }

    commands[command](...res);
  }

  pieces.forEach((piece) => {
    console.log(
      `${piece.piece} -> Composer: ${piece.composer}, Key: ${piece.key}`
    );
  });

  function addPiece(piece, composer, key) {
    if (pieces.some((currPiece) => currPiece["piece"] === piece)) {
      console.log(`${piece} is already in the collection!`);
      return;
    }

    pieces.push({ piece, composer, key });
    console.log(`${piece} by ${composer} in ${key} added to the collection!`);
  }

  function removePiece(piece) {
    const currPiece = pieces.find((currPiece) => currPiece["piece"] === piece);

    if (currPiece) {
      pieces = pieces.filter((currPiece) => currPiece.piece !== piece);
      console.log(`Successfully removed ${piece}!`);
      return;
    }

    console.log(
      `Invalid operation! ${piece} does not exist in the collection.`
    );
  }

  function changeKey(piece, newKey) {
    const currPiece = pieces.find((currPiece) => currPiece["piece"] === piece);

    if (currPiece) {
      currPiece.key = newKey;
      console.log(`Changed the key of ${piece} to ${newKey}!`);
      return;
    }

    console.log(
      `Invalid operation! ${piece} does not exist in the collection.`
    );
  }
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
sovle([
  "4",
  "Eine kleine Nachtmusik|Mozart|G Major",
  "La Campanella|Liszt|G# Minor",
  "The Marriage of Figaro|Mozart|G Major",
  "Hungarian Dance No.5|Brahms|G Minor",
  "Add|Spring|Vivaldi|E Major",
  "Remove|The Marriage of Figaro",
  "Remove|Turkish March",
  "ChangeKey|Spring|C Major",
  "Add|Nocturne|Chopin|C# Minor",
  "Stop",
]);
