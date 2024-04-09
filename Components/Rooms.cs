namespace _038_the_fountain_of_objects.Components;

// Basic room that fills most of the map
public class NormalRoom : Room, IRoom
{
    public string Description { get; } = "You don't hear, smell, or see anything specific in this room.";

    public override string ToString()
    {
        return "NORM";
    }
}

// The primary goal Fountain of Objects room
public class FountainOfObjectsRoom : Room, IRoom
{
    public string Description { get; } = "You hear water dripping in this room. The Fountain of Objects is here!!";

    public string FountainEnabledDescription { get; } = "You hear the roaring waters of the " +
                                                        "Fountain of Objects. It has been activated!!";
    
    public bool IsEnabled { get; set; } = false;

    public override string ToString()
    {
        return "FOBS";
    }
}

// Entrance to the game map. Also represents the exit
public class CavernEntranceRoom : Room, IRoom
{
    public string Description { get; } = "You see light coming from the cavern entrance.";

    public override string ToString()
    {
        return "ENTR";
    }
}

public class PitRoom : Room, IRoom
{
    public string Description { get; } = "You have fallen into a pit and perished!!";
    public string Warning { get; } = "You feel a draft. There is a pit in a nearby room.";

    public override string ToString()
    {
        return "PIT_";
    }
}

public abstract class Room
{
    public bool IsVisited { get; set; }
    
    public static void DescribeLocation(Map map, Player player)
    {
        // Describe room player is in
        Console.WriteLine("---------------------------------------------------------------------");

        // Cavern Entrance
        if (player.CurrentLocation[0] == map.CavernEntranceLocation[0])
        {
            if (player.CurrentLocation[1] == map.CavernEntranceLocation[1])
            {
                TextColor.MakeTextYellow();
                Console.WriteLine(map.CavernEntrance.Description);
                TextColor.ResetTextColor();
            }
        }
        
        // The Fountain of Objects
        if (map.GetCurrentRoomType(player, map).GetType() == typeof(FountainOfObjectsRoom))
        {
            if (map.FountainOfObjects.IsEnabled)
            {
                TextColor.MakeTextBlue();
                Console.WriteLine(map.FountainOfObjects.FountainEnabledDescription);
                TextColor.ResetTextColor();
            }
            else
            {
                TextColor.MakeTextBlue();
                Console.WriteLine(map.FountainOfObjects.Description);
                TextColor.ResetTextColor();
            }
        }
        
        // Normal Room
        if (map.GetCurrentRoomType(player, map).GetType() == typeof(NormalRoom))
        {
            TextColor.MakeTextDarkGray();
            Console.WriteLine(map.Normal.Description);
            TextColor.ResetTextColor();
        }
        
        // Pit
        if (map.GetCurrentRoomType(player, map).GetType() == typeof(PitRoom))
        {
            TextColor.MakeTextDarkRed();
            Console.WriteLine(map.Pit.Description);
            TextColor.ResetTextColor();
        }
        
        
        // Is Pit Near
        for (int i = 0; i < map.PitLocations.Length / 2; i++)
        {
            int pitCoordOne = 0;
            int pitCoordTwo = 1;

            // Check cardinal direction in relation to pit
            // West
            if (player.CurrentLocation[0] == map.PitLocations[i, pitCoordOne])
            {
                if (player.CurrentLocation[1] == (map.PitLocations[i, pitCoordTwo]) - 1)
                {
                    TextColor.MakeTextGreen();
                    Console.WriteLine(map.Pit.Warning);
                    TextColor.ResetTextColor();
                }
            }
            // SouthWest
            if (player.CurrentLocation[0] == (map.PitLocations[i, pitCoordOne]) + 1)
            {
                if (player.CurrentLocation[1] == (map.PitLocations[i, pitCoordTwo]) - 1)
                {
                    TextColor.MakeTextGreen();
                    Console.WriteLine(map.Pit.Warning);
                    TextColor.ResetTextColor();
                }
            }
            // NorthWest
            if (player.CurrentLocation[0] == (map.PitLocations[i, pitCoordOne]) - 1)
            {
                if (player.CurrentLocation[1] == (map.PitLocations[i, pitCoordTwo]) - 1)
                {
                    TextColor.MakeTextGreen();
                    Console.WriteLine(map.Pit.Warning);
                    TextColor.ResetTextColor();
                }
            }
            // North
            if (player.CurrentLocation[0] == (map.PitLocations[i, pitCoordOne]) - 1)
            {
                if (player.CurrentLocation[1] == (map.PitLocations[i, pitCoordTwo]))
                {
                    TextColor.MakeTextGreen();
                    Console.WriteLine(map.Pit.Warning);
                    TextColor.ResetTextColor();
                }
            }
            // NorthEast
            if (player.CurrentLocation[0] == (map.PitLocations[i, pitCoordOne]) - 1)
            {
                if (player.CurrentLocation[1] == (map.PitLocations[i, pitCoordTwo]) + 1)
                {
                    TextColor.MakeTextGreen();
                    Console.WriteLine(map.Pit.Warning);
                    TextColor.ResetTextColor();
                }
            }
            // East
            if (player.CurrentLocation[0] == (map.PitLocations[i, pitCoordOne]))
            {
                if (player.CurrentLocation[1] == (map.PitLocations[i, pitCoordTwo]) + 1)
                {
                    TextColor.MakeTextGreen();
                    Console.WriteLine(map.Pit.Warning);
                    TextColor.ResetTextColor();
                }
            }
            // SouthEast
            if (player.CurrentLocation[0] == (map.PitLocations[i, pitCoordOne]) + 1)
            {
                if (player.CurrentLocation[1] == (map.PitLocations[i, pitCoordTwo]) + 1)
                {
                    TextColor.MakeTextGreen();
                    Console.WriteLine(map.Pit.Warning);
                    TextColor.ResetTextColor();
                }
            }
            // South
            if (player.CurrentLocation[0] == (map.PitLocations[i, pitCoordOne]) + 1)
            {
                if (player.CurrentLocation[1] == (map.PitLocations[i, pitCoordTwo]))
                {
                    TextColor.MakeTextGreen();
                    Console.WriteLine(map.Pit.Warning);
                    TextColor.ResetTextColor();
                }
            }
        }
    }
}

public interface IRoom
{
    public string Description { get; }
}