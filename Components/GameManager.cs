namespace _038_the_fountain_of_objects.Components;

public static class GameManager
{
    private static bool IsGameActive { get; set; } = true;

    public static void StartGame()
    {
        // Clear console
        Console.Clear();

        // Story time
        TextColor.MakeTextMagenta();
        Console.WriteLine("Welcome to the cavern of the Fountain of Objects!");
        Console.WriteLine("You must explore the cavern and try to locate " +
                          "the Fountain and re-activate it.");
        TextColor.ResetTextColor();
        
        // Build map
        Console.WriteLine("Please enter what size game world you would like to play in.");
        Console.Write("Please enter \"small\", \"medium\", or \"large\": ");
        string? mapSize = Console.ReadLine();

        Map map;
        
        switch (mapSize)
        {
            case "small":
                map = new Map("small", 4, 4);
                break;
            case "medium":
                map = new Map("medium", 6, 6);
                break;
            case "large":
                map = new Map("large", 8, 8);
                break;
            default:
                map = new Map("small", 4, 4);
                break;
        }
        
        // Create player
        Player player = new Player();

        // Take turn
        TakeTurn(map, player);
    }

    private static void TakeTurn(Map map, Player player)
    {
        while (IsGameActive)
        {
            Room.DescribeLocation(map, player);

            string[] playerInput = player.GetPlayerInput();
            bool isValidAction = player.IsValidAction(playerInput, player, map);

            if (isValidAction)
            {
                player.PerformPlayerAction(playerInput, player, map);
            }
            
            CheckGameState(map, player);
        }
    }
    
    private static void CheckGameState(Map map, Player player)
    {
        if (player.CurrentLocation[0] == 0 && player.CurrentLocation[1] == 0)
        {
            if (map.FountainOfObjects.IsEnabled)
            {
                Console.WriteLine($"You win!!");
                IsGameActive = false;
            }
        }
    }
}