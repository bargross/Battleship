# Battleship (Console-Game)

### Before Executing the solution

To play the game an IDE is necessary or if you know how to compile and execute files from the terminal 
then lets cut to the chase.

### IDE suggestions

+ Unity (although this is a 3D game engine)
+ MonoDevelop (It is what im using, recommended)
+ Visual Studio


### How to play it

The game is simple:

+ The game takes inputs in the form of either "A5" or "a5", the range of letters and numbers are from A-J and 0-9.
+ The game is set to give the player 10 attempts to shoot all 9 shits on the 10x10 board(grid)
+ Each input is an attempt, at 10 attempts the game ends telling you the amount of attempts and  ships 
destroyed.
+ For each ship destroyed "x" is displayed, missed shots are represented as "o" and water as "-"

### The rules are the following

+ Input length cannot be longer than 2
+ Input has to be in the form of a character and a number, Eg: "A5", all other inputs are invalid.
+ If you enter "A5" then you cannot fire at "A5" again as you cannot shoot the same target twice.


