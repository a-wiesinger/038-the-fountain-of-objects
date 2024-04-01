namespace _038_the_fountain_of_objects;

public static class GameManager
{
    private static bool IsGameActive { get; set; } = true;
    
    public static void StartGame()
    {
        // Build map
        Map map = new Map(4, 4);
        
        Console.WriteLine(map.DrawnMap[map.FountainLocation[0], map.FountainLocation[1]]);
        
        // Create player
        Player player = new Player();
        Console.WriteLine($"Here is the player: ({player.CurrentLocation[0]}, {player.CurrentLocation[1]})");
        
        // Take turn
        TakeTurn(map, player);
    }

    public static void TakeTurn( Map map, Player player)
    {
        while (IsGameActive)
        {
            string[] playerInput = player.GetPlayerInput();
            bool isValidAction = player.IsValidAction(playerInput, player, map);

            if (isValidAction)
            {
                player.PerformPlayerAction(playerInput, player, map);
            }
        
            Console.WriteLine($"You are now at location: {player.CurrentLocation[0]}, {player.CurrentLocation[1]}");
        }
        
        CheckGameState(map, player);
    }

    public static void CheckGameState(Map map, Player player)
    {
        if (player.CurrentLocation[0] == 0 && player.CurrentLocation[1] == 0)
        {
            if (true)
            {
                Console.WriteLine($"{map.DrawnMap[0, 1]}");
            }
        }
    }
}