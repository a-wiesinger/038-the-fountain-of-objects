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
8. Use different colors to display the different types of text in the console window. e.g. 
   1. Narrative items are in magenta
   2. Description text is in white
   3. User input is in cyan
   4. Text describing the entrance light is in yellow
   5. Messages about the Fountain are in blue
9. Example of what program might look like:
   1. You are in the room at (Row=0, Column=0).
   2. You see light coming from the cavern entrance.
   3. What do you want to do? (move east)

## Expansions
Small, Medium, Large
1. Create an option for a 4x4, 6x6, and 8x8 grid game world
2. Before the game begins, ask the player what size world they want to play in (S, M, L)
   1. Create the game world based on this
3. Pick new locations for the Cave Entrance and the Fountain of Objects rooms
4. Note: Other challenges may need to be updated based on these new sizes

Pits
1. Add this number of rooms to the game depending on map size:
   1. Small = 1
   2. Medium = 2
   3. Large = 4
2. If a player goes into a pit room, it's game over
3. Players can sense a pit room with they are in any of the adjacent 8 rooms
   1. "You feel a draft. There is a pit in a nearby room."