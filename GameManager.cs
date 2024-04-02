using System.Net.Mime;

namespace _038_the_fountain_of_objects;

public static class GameManager
{
    private static bool IsGameActive { get; set; } = true;

    public static void StartGame()
    {
        // Build map
        Map map = new Map(4, 4);

        // Create player
        Player player = new Player();

        // Story time
        TextColor.MakeTextMagenta();
        Console.WriteLine("Welcome to the cavern of the Fountain of Objects!");
        Console.WriteLine("You must explore the cavern and try to locate " +
                          "the Fountain and re-activate it.");
        TextColor.ResetTextColor();

        // Take turn
        TakeTurn(map, player);
    }

    public static void TakeTurn(Map map, Player player)
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
    
    public static void CheckGameState(Map map, Player player)
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