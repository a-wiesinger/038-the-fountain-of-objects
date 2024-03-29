namespace _038_the_fountain_of_objects;

public class Player
{
    // Properties
    private int[] StartingLocation { get; } = new[] { 0, 0 };
    public int[] CurrentLocation { get; set; }
    
    // Constructor
    public Player()
    {
        CurrentLocation = StartingLocation;
        GetPlayerInput();
    }
    
    // Take input
    public void GetPlayerInput()
    {
        string? input;
        
        Console.Write($"What do you want to do? ");

        input = Console.ReadLine();
    }

    // Move the player


    // Enable Fountain when able

}