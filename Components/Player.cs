using System.Runtime.InteropServices.JavaScript;

namespace _038_the_fountain_of_objects.Components;

public class Player
{
    // Properties
    public int[] CurrentLocation { get; set; }

    // Methods
    // Get input
    public string[] GetPlayerInput()
    {
        bool IsValidInput = true;
        
        string[] inputs = new[] { "", "" };

        while (IsValidInput)
        {
            Console.Write($"What do you want to do? ");
            TextColor.MakeTextCyan();
            string? input = Console.ReadLine();
            TextColor.ResetTextColor();
            
            // Check to see if the person has entered anything at all
            if (input != null)
            {
                string[] inputSeparated = input.Split(" "); // Chunk up response

                // Check to see that the user has only entered 2 arguments
                if (inputSeparated.Length == 2)
                {
                    inputs = inputSeparated;
                    break;
                }
                // Check to see if the person is asking for help with commands
                if (inputSeparated.Length == 1 && inputSeparated[0] == "help")
                {
                    GameManager.GetAvailableCommands();
                    break;
                }
                ErrorMessaging.InvalidInput();
                IsValidInput = false;
            }
            else
            {
                ErrorMessaging.InvalidInput();
            }
        }

        return inputs; 
    }

    // Perform player action
    public void PerformPlayerAction(string[] inputs, Player player, Map map)
    {
        string action = inputs[0];
        string actedOnOrDirection = inputs[1];
        
        if (action == "move")
        {
            switch (actedOnOrDirection)
            {
                case "north":
                    // Move player in -Y direction
                    player.CurrentLocation[0]--;
                    Console.WriteLine($"Moving North");
                    break;
                case "south":
                    // Move player in +Y direction
                    player.CurrentLocation[0]++;
                    Console.WriteLine($"Moving South");
                    break;
                case "east":
                    // Move player in +X direction
                    player.CurrentLocation[1]++;
                    Console.WriteLine($"Moving East");
                    break;
                case "west":
                    // Move player in -X direction
                    player.CurrentLocation[1]--;
                    Console.WriteLine($"Moving West");
                    break;
                default:
                    break;
            }
        }

        if (action == "enable" && actedOnOrDirection == "fountain")
        {
            TextColor.MakeTextBlue();
            Console.WriteLine($"You've enabled the Fountain of Objects!!");
            TextColor.ResetTextColor();
        }
    }

    public void ShowPlayerLocation(Player player)
    {
        Console.WriteLine($"You are now at: (Row: {player.CurrentLocation[0]}, Column: {player.CurrentLocation[1]})");
    }

    public bool IsValidAction(string[] inputs, Player player, Map map)
    {
        string action = inputs[0];
        string ojbectOrDirection = inputs[1];
        
        int playerLocationRow = player.CurrentLocation[0];
        int playerLocationColumn = player.CurrentLocation[1];
        
        int moveNorth = -1;
        int moveSouth = 1;
        int moveEast = 1;
        int moveWest = -1;
        
        if (action == "move")
        {
            switch (ojbectOrDirection)
            {
                case "north":
                    if (playerLocationRow + moveNorth < map.MapSizeHeight - map.MapSizeHeight)
                    {
                        ErrorMessaging.InvalidDirection();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                case "south":
                    if (playerLocationRow + moveSouth > map.MapSizeHeight - 1)
                    {
                        ErrorMessaging.InvalidDirection();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                case "east":
                    if (playerLocationColumn + moveEast > map.MapSizeWidth - 1)
                    {
                        ErrorMessaging.InvalidDirection();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                case "west":
                    if (playerLocationColumn + moveWest < map.MapSizeWidth - map.MapSizeWidth)
                    {
                        ErrorMessaging.InvalidDirection();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                default:
                    ErrorMessaging.Typo();
                    break;
            }
        }

        if (action == "enable")
        {
            if (player.CurrentLocation[0] == map.FountainLocation[0] && 
            player.CurrentLocation[1] == map.FountainLocation[1])
            {
                map.FountainOfObjects.IsEnabled = true;
                
                return true;
            }
            
            ErrorMessaging.NotAtFountain();
        }
        
        return false;
    }
}