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
    public string Description { get; } = "You have fallen into the pit and perished.";
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
        int playerLocationX = player.CurrentLocation[0];
        int playerLocationY = player.CurrentLocation[1];
        int[] entranceLocation = new[] { map.CavernEntranceLocation[0], map.CavernEntranceLocation[1] };
        int[] fountainLocation = new[] { map.FountainLocation[0], map.FountainLocation[1] };
        //int[,] pitLocations = new[,] { }; 
        
        // Cavern Entrance
        if (playerLocationX == entranceLocation[0] && playerLocationY == entranceLocation[1])
        {
            TextColor.MakeTextYellow();
            Console.WriteLine(map.CavernEntrance.Description);
            TextColor.ResetTextColor();
        }
        // The Fountain of Objects
        else if (playerLocationX == fountainLocation[0] && playerLocationY == fountainLocation[1])
        {
            TextColor.MakeTextBlue();
            Console.WriteLine(map.FountainOfObjects.Description);
            TextColor.ResetTextColor();
        }
        // Check to see if fell into pit
        // TODO
        // Check to see if pit is nearby
        // TODO
    }
}

public interface IRoom
{
    public string Description { get; }
}