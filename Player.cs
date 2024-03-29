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
        PerformPlayerAction(GetPlayerInput());
    }
    
    // Methods
    
    // Get input
    private string[] GetPlayerInput()
    {
        Console.Write($"What do you want to do? ");
        string? input = Console.ReadLine();
        string[] inputs = input.Split(" "); // Chunk up response
        
        return inputs; 
    }

    // Perform player action
    private void PerformPlayerAction(string[] inputs)
    {
        
    }
}