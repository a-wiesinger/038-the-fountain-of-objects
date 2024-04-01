using System.Runtime.InteropServices.JavaScript;

namespace _038_the_fountain_of_objects;

public class Player
{
    // Properties
    private int[] StartingLocation { get; } = new[] { 0, 0 };
    public int[] CurrentLocation { get; set; }

    // Constructor
    public Player()
    {
        CurrentLocation = StartingLocation;
    }

    // Methods
    // Get input
    public string[] GetPlayerInput()
    {
        bool IsValidInput = true;
        
        string[] inputs = new[] { "", "" };

        while (IsValidInput)
        {
            Console.Write($"What do you want to do? ");
            string? input = Console.ReadLine();
            
            // Check to see if the person has entered anything at all
            if (input != null)
            {
                string[] inputsActual = input.Split(" "); // Chunk up response

                // Check to see that the user has only entered 2 arguments
                if (inputsActual.Length == 2)
                {
                    inputs = inputsActual;
                    IsValidInput = false;
                    break;
                }
                else
                {
                    ErrorMessaging.InvalidInput();
                }
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
                    player.CurrentLocation[1]--;
                    Console.WriteLine($"Moving North");
                    break;
                case "south":
                    // Move player in +Y direction
                    player.CurrentLocation[1]++;
                    Console.WriteLine($"Moving South");
                    break;
                case "east":
                    // Move player in +X direction
                    player.CurrentLocation[0]++;
                    Console.WriteLine($"Moving East");
                    break;
                case "west":
                    // Move player in -X direction
                    player.CurrentLocation[0]--;
                    Console.WriteLine($"Moving West");
                    break;
                default:
                    break;
            }
        }

        if (action == "enable" && actedOnOrDirection == "fountain")
        {
            Console.WriteLine($"Congratulations, you've enabled the Fountain of Objects!!");
        }
    }

    public bool IsValidAction(string[] inputs, Player player, Map map)
    {
        string action = inputs[0];
        string ojbectOrDirection = inputs[1];
        
        int playerLocationX = player.CurrentLocation[0];
        int playerLocationY = player.CurrentLocation[1];
        
        int moveNorth = -1;
        int moveSouth = 1;
        int moveEast = 1;
        int moveWest = -1;
        
        // if (action == "move" && actedOnorDirection)
        switch (action)
        {
            case "move":
                switch (ojbectOrDirection)
                {
                    case "north":
                        if (playerLocationY + moveNorth < map.MapSizeHeight -
                            map.MapSizeHeight)
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
                        if (playerLocationY + moveSouth > map.MapSizeHeight - 1)
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
                        if (playerLocationX + moveEast > map.MapSizeWidth - 1)
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
                        if (playerLocationX + moveWest < map.MapSizeWidth - 
                        map.MapSizeWidth)
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
                        break;
                }
                break;
            case "enable":
                if (true)
                {
                    
                }
                break;
            default:
                ErrorMessaging.InvalidAction();
                break;
        }

        return false;
    }
}