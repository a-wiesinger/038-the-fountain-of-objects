using System.Globalization;
using System.Runtime.InteropServices.JavaScript;

namespace _038_the_fountain_of_objects.Components;

public static class GameManager
{
    private static bool IsGameActive { get; set; } = true;
    private static DateTime StartTime { get; set; }
    private static DateTime EndTime { get; set; }

    public static void StartGame()
    {
        // Clear console
        Console.Clear();

        // Story time
        TextColor.MakeTextMagenta();
        Console.WriteLine("**************************************************");
        Console.WriteLine("Welcome to the cavern of the Fountain of Objects!");
        Console.WriteLine("**************************************************");
        Console.WriteLine("It is a maze of room filled with dangerous pits in search of the Fountain of Objects.");
        Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
        Console.WriteLine("You must navigate the Caverns with your other senses.");
        Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
        Console.WriteLine("note: Enter the word 'help' to get a list of available commands.");
        Console.WriteLine("note: The top left is the 'origin' point of 0, 0 on the map");
        TextColor.MakeTextWhite();
        Console.WriteLine("---------------------------------------------------------------------");
        TextColor.MakeTextGreen();
        Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room.");
        Console.WriteLine("If you enter a room with a pit, you will die.");
        TextColor.ResetTextColor();
        
        // Build map
        Console.WriteLine("Please enter what size game world you would like to play in.");
        Console.Write("Please enter \"small\", \"medium\", or \"large\": ");
        string? mapSize = Console.ReadLine();

        // Create player
        Player player = new Player();
        
        Map map;
        
        switch (mapSize)
        {
            case "small":
                map = new Map("small", 4, 4, player);
                break;
            case "medium":
                map = new Map("medium", 6, 6, player);
                break;
            case "large":
                map = new Map("large", 8, 8, player);
                break;
            default:
                map = new Map("small", 4, 4, player);
                break;
        }

        // Take turn
        TakeTurn(map, player);
    }

    public static void GetAvailableCommands()
    {
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine("Available Commands: ");
        Console.WriteLine("- move + <cardinal direction> - e.g. 'move north', 'move south', etc.");
        Console.WriteLine("North is up. South is down. East is right. West is left.");
        Console.WriteLine("- 'enable fountain' - When you are in the Fountain of Objects room, " +
                          "this will enable the Fountain of Objects.");
        Console.WriteLine("---------------------------------------------------------------------");
    }

    private static void TakeTurn(Map map, Player player)
    {
        while (IsGameActive)
        {
            Console.Clear();
            
            Room.DescribeLocation(map, player);
            
            player.ShowPlayerLocation(player);
            
            map.RenderMap(map.MapSizeWidth, map.MapSizeHeight, map, player);
            // map.RenderDeveloperMap(map.MapSizeWidth, map.MapSizeHeight, map, player);

            GetStartTime();
            Console.WriteLine($"Starting time: {StartTime}");

            string[] playerInput = player.GetPlayerInput();
            bool isValidAction = player.IsValidAction(playerInput, player, map);

            if (isValidAction)
            {
                player.PerformPlayerAction(playerInput, player, map);
            }
            
            CheckGameState(map, player);
        }
    }

    // Added timers for start, end, and calculated play time per challenge in level 32
    // for DateTime usage
    private static void GetStartTime()
    {
        DateTime startTime = DateTime.Now;
        StartTime = startTime;
    }

    private static void GetEndTime()
    {
        DateTime endTime = DateTime.Now;
        EndTime = endTime;
    }

    private static void CheckGameState(Map map, Player player)
    {
        // Win
        if (map.GetCurrentRoomType(player, map).GetType() == typeof(CavernEntranceRoom))
        {
            if (map.FountainOfObjects.IsEnabled)
            {
                Console.WriteLine("You win!!");
                
                GetEndTime();
                TimeSpan timePlayed = EndTime - StartTime;
                var minutesPlayed = Convert.ToInt32(timePlayed.TotalMinutes);
                var secondsPlayed = Convert.ToInt32(timePlayed.TotalSeconds);
                
                Console.WriteLine($"It took {minutesPlayed} minutes, " +
                                  $"| {secondsPlayed} seconds to finish the game.");
                IsGameActive = false;
            }
        }
        
        // Loss
        if (map.GetCurrentRoomType(player, map).GetType() == typeof(PitRoom))
        {
            TextColor.MakeTextDarkRed();
            Console.WriteLine(map.Pit.Description);
            Console.WriteLine("Game over.");
            TextColor.ResetTextColor();
            
            GetEndTime();
            TimeSpan timePlayed = EndTime - StartTime;
            var minutesPlayed = Convert.ToInt32(timePlayed.TotalMinutes);
            var secondsPlayed = Convert.ToInt32(timePlayed.TotalSeconds);
            
            Console.WriteLine($"It took {minutesPlayed} minutes, " +
                              $"| {secondsPlayed} seconds to finish the game.");
            IsGameActive = false;
        }
    }
}