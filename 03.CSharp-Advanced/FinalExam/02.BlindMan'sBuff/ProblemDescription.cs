//Blind man's buff is played in a spacious area, such as outdoors or in a large room, in which one player, is blindfolded and gropes around attempting to touch the other players without being able to see them…

//You will be given N and M – integers, indicating the playground’s dimensions. On the next N lines, you will receive the rows of the playground, with M columns. You will be marked with the letter 'B', and placed in a random position. In random positions, furniture or other obstacles will be marked with the letter 'O'. The other players (opponents) will be marked with the letter 'P'. There will always be three other players participating in the game. All of the empty positions will be marked with '-'.

//Your goal is to touch as many players as possible during the game, without leaving the playground or stepping on an obstacle.

//On the next few lines, until you receive the command "Finish", you will receive a few lines with commands representing which directio you need to move. The possible directions are "up", " down", "right", and "left". If the direction leads you out of the field, younee to stay in position inside the field (do NOT make the move). If you have an obstacle, towards the direction, do NOT make the mov and wait for the next command.

//You need to keep track of the count of touched opponents and the moves you’ve made.

//In case you step on a position marked with '-', increase the count of the moves made.

//When you receive a command with direction, you check the position you need to step on for an obstacle or opponent. If there is an opponent, you touch him and the position is marked with '-'(increase the count of the touched opponents and moves made), and this is your new position.

//The game is over when you manage to touch all opponents or the given command is "Finish". A game report is printed on the Console:
//"Game over!"
//"Touched opponents: {count} Moves made: {count}"

//Input
//• On the first line, you'll receive the dimensions of the playground in format: "N M", where N is the number of rows, and M is the number of columns. They'll be separated by a single space (" ").
//• On the next N lines, you will receive a string representing the respective row of the playground. The positions in every string will be separated by a single space (" ").
//• On the next few lines, until you receive the command "Finish", you will be given directions (up, down, right, left). 

//Output
//• When the game is over, the following output should be printed on the Console:
//"Game over!"
//"Touched opponents: {count} Moves made: {count}"

//Constraints
//• The playground size will be a 32-bit integer in the range [2 … 2 147 483 647].
//• The playground will always have three opponents in it - 'P'.
//• The obstacles on the playground will always be random count, and thеre will be cases without any obstacles.