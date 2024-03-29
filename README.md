# Level 38 - "The Fountain of Objects"
Following along with the C# Player's Guide by RB Whitaker
## Topic
Object Oriented Programming Game
## Criteria:
1. The world is a grid of rooms (4 x 4). Each room can be referenced by its row and column coordinates.
   1. North = up
   2. South = down
   3. East = right
   4. West = left
2. The game loop is as follows:
   1. The player is told what they can sense in the dark (see, hear, smell, etc.) 
   2. The player can then enter in an action that they will take  by typing in the command (move, enable, etc.)
   3. The state of the game is altered
   4. Check for win/loss
   5. Rinse and repeat
3. Most rooms are empty
4. Move between rooms by typing "e.g. move north, move east, etc."
5. Room 0,0 is the cavern entrance. The player starts here and can see light coming from outside the cavern when in the room.
6. Room 0,2 is the Fountain of Objects room. The player hears different things depending on if the Fountain is active or not. The fountain's default state is to off. If the player is in the Fountain room and types "enable fountain" it will turn it on. If it is already on and they type it again, nothing happens. If they try to enable the fountain from another room, the player will be shown an appropriate error message.
7. The player wins the game if they turn the Fountain on and return to the cavern entrance. If the player has enabled the Fountain and are in the entrance, they win.
8. Use different colors to display the different types of text in the console window. e.g. Narrative items are in magenta, description text is in white, user input is in cyan, text describing the entrance light is in yellow, messages about the Fountain are in blue.
9. Example of what program might look like:
   1. You are in the room at (Row=0, Column=0).
   2. You see light coming from the cavern entrance.
   3. What do you want to do? (move east)