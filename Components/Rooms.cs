using System.Data;
using System.Net;

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
        int[] playerLocation = new[] { player.CurrentLocation[0], player.CurrentLocation[1] };
        int[] entranceLocation = new[] { map.CavernEntranceLocation[0], map.CavernEntranceLocation[1] };
        int[] fountainLocation = new[] { map.FountainLocation[0], map.FountainLocation[1] };
        int[,] pitLocations = map.PitLocations;
        
        // TODO - Remove comment when done building out
        // Console.WriteLine($"{map.PitLocations[2, 0]}, {map.PitLocations[2, 1]}");
        
        // Cavern Entrance
        if (playerLocation[0] == entranceLocation[0] && playerLocation[1] == entranceLocation[1])
        {
            TextColor.MakeTextYellow();
            Console.WriteLine(map.CavernEntrance.Description);
            TextColor.ResetTextColor();
        }
        // The Fountain of Objects
        else if (playerLocation[0] == fountainLocation[0] && playerLocation[1] == fountainLocation[1])
        {
            TextColor.MakeTextBlue();
            Console.WriteLine(map.FountainOfObjects.Description);
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
                    Console.WriteLine(map.Pit.Description);
                }
            }
        }
        
        // Check to see if pit is nearby
        // TODO
    }
}

public interface IRoom
{
    public string Description { get; }
}