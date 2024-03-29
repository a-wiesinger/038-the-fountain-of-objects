namespace _038_the_fountain_of_objects;

public static class GameManager
{
    public static void StartGame()
    {
        // Build map
        Map map = new Map(4, 4);
        
        // Create player
        Player player = new Player();
        Console.Write($"Here is the player: ({player.CurrentLocation[0]}, {player.CurrentLocation[1]})");
    }

    public static void TakeTurn()
    {
        
    }

    public static void CheckGameState()
    {
        
    }
}