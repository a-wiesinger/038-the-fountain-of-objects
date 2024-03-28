namespace _038_the_fountain_of_objects;

public class NormalRoom : Room, IRoom
{
    public string Description { get; }

    public NormalRoom()
    {
        Description = "You don't hear, smell, or see anything specific in this room.";
        
    }
}

public class FountainOfObjectsRoom : Room, IRoom
{
    public string Description { get; }

    public FountainOfObjectsRoom()
    {
        Description = "You hear water dripping in this room. The Fountain of Objects is here!!";
    }
}

public class CavernEntrance : Room, IRoom
{
    public string Description { get; }

    public CavernEntrance()
    {
        Description = "You see light coming from the cavern entrance.";
    }
}

public abstract class Room
{
    
}

public interface IRoom
{
    public string Description { get; }
}