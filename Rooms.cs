namespace _038_the_fountain_of_objects;

// Basic room that fills most of the map
public class NormalRoom : Room, IRoom
{
    public string Description { get; }

    public NormalRoom()
    {
        Description = "You don't hear, smell, or see anything specific in this room.";
    }
    
    public override string ToString()
    {
        return "NORM";
    }
}

// The primary goal Fountain of Objects room
public class FountainOfObjectsRoom : Room, IRoom
{
    public string Description { get; }
    
    public bool IsEnabled { get; } = false;

    public FountainOfObjectsRoom()
    {
        Description = "You hear water dripping in this room. The Fountain of Objects is here!!";
    }
    
    public override string ToString()
    {
        return "FOBS";
    }
}

// Entrance to the game map. Also represents the exit
public class CavernEntrance : Room, IRoom
{
    public string Description { get; }

    public CavernEntrance()
    {
        Description = "You see light coming from the cavern entrance.";
    }

    public override string ToString()
    {
        return "CAVE";
    }
}

public abstract class Room
{
    
}

public interface IRoom
{
    public string Description { get; }
}