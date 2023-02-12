//1914, September 22 – German submarine U-9 sinks three unescorted british armored cruisers hms aboukir, hms hogue and hms cressyinapproximately one hour. Imagine that they had the technology to make themselves a navigational program for the submarine and youarechosen to implement the logic. Navigate U-9 through the battlefield, find and sink the british cruisers in the dark night, avoidingthefloating mines all over the north sea.

//You will be given an integer n for the size of the battlefield (square shape). on the next n lines, you will receive the rows ofthebattlefield. the submarine will start at a random position, marked with the letter 's'. The submarine surveys the surroundingareathrough its periscope, so it has to climb up to periscope depth, where it might run across naval mines.

//When the submarine receives direction, it goes deep and moves one position toward the given direction. on each turn, you will beguidin the submarine and giving it the direction, in which it should move. The commands will be "up", "down", "left" and "right".

//When a new position is reached, the submarine climbs up to periscope depth to search for a cruiser:
//· if a position with '-'(dash) is reached, it means that the field is empty and the submarine awaits its next direction.
//· if it runs across a naval mine ('*'), the submarine takes serious damage. when a mine is blown, the position of the mine willbemarked with '-' (dash). U-9 can withstand two hits from naval mines. The third time the submarine is hit by a mine, it disappearsandthe mission is failed. The battle is over and the following message should be printed on the console: "mission failed, U-9 disappeared!Last known coordinates [{row}, {col}]!"

//· If a battle cruiser is reached('c'), the submarine destroys it and the position of the destroyed cruiser will be markedwith'-' (dash).
//· If this is the last (third)battle cruiser on the battlefield, the battle is over and the following message should be printed on thconsole: "mission accomplished, U-9 has destroyed all battle cruisers of the enemy!"

//The program will end when the battle is over (all battle cruisers are destroyed or the submarine hits mines three times).

//Input
//· On the first line, you are given the integer n – the size of the matrix (wall).
//· The next n lines hold the values for every row.
//· On each of the next lines, you will get a direction command.

//Output
//· If all battle cruisers are destroyed, print: "mission accomplished, U-9 has destroyed all battle cruisers of the enemy!"
//· If u - 9 is hit by a mine three times, print: "mission failed, U-9 disappeared! last known coordinates [{row}, {col}]!".
//· At the end, print the final state of the matrix(battlefield) with the last known U-9’s position on it.

//Constraints
//· The size of the square matrix(battlefield) will be between[4…10].
//· U - 9’s starting position will always be marked with 's'.
//· There will be always three battle cruisers - fields marked with 'c'.
//· There will be always enough mines on the battlefield to destroy the submarine.
//· The commands given will direct the submarine only within the limits of the battlefield.
//· You will always receive enough commands to end the battle.