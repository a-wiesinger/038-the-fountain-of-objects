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
        if (player.CurrentLocation[0] == map.FountainLocation[0])
        {
            if (player.CurrentLocation[1] == map.FountainLocation[1])
            {
                TextColor.MakeTextBlue();
                Console.WriteLine(map.FountainOfObjects.Description);
                TextColor.ResetTextColor();
            }
        }
        
        // Normal Room
        if (player.GetRoomType(player, map).GetType() == typeof(NormalRoom))
        {
            TextColor.MakeTextDarkGray();
            Console.WriteLine(map.Normal.Description);
            TextColor.ResetTextColor();
        }
        
        // Pit
        for (int i = 0; i < map.PitLocations.Length / 2; i++)
        {
            int pitCoordOne = 0;
            int pitCoordTwo = 1;

            if (map.PitLocations[i, pitCoordOne] == player.CurrentLocation[0])
            {
                if (map.PitLocations[i, pitCoordTwo] == player.CurrentLocation[1])
                {
                    TextColor.MakeTextDarkRed();
                    Console.WriteLine(map.Pit.Description);
                    TextColor.ResetTextColor();
                }
            }
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