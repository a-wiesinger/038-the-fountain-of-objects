using System.ComponentModel;

namespace _038_the_fountain_of_objects;

public class Map
{
    // Properties
    public int MapSizeWidth { get; }
    public int MapSizeHeight { get; }
    
    public int[] FountainLocation { get; } = new [] { 0, 2 }; // Change to 
    private int[] EntranceLocation { get; } = new [] { 0, 0 }; // Change to update entrace location
    
    public Room[,] DrawnMap { get; }
    
    // Constructor
    public Map(int mapSizeWidth, int mapSizeHeight)
    {
        MapSizeWidth = mapSizeWidth;
        MapSizeHeight = mapSizeHeight;

        DrawnMap = new Room[mapSizeWidth, mapSizeHeight];

        for (int i = 0; i < MapSizeWidth; i++)
        {
            for (int j = 0; j < MapSizeHeight; j++)
            {
                // Fill out row
                if (i == EntranceLocation[0] && j == EntranceLocation[1])
                {
                    DrawnMap[i, j] = new CavernEntrance();
                }
                else if (i == FountainLocation[0] && j == FountainLocation[1])
                {
                    DrawnMap[i, j] = new FountainOfObjectsRoom();
                }
                else // The rest are normal empty rooms
                {
                    DrawnMap[i, j] = new NormalRoom();
                }
                
                Console.Write($"{DrawnMap[i, j]} ");
            }
            // Move to next row 
            Console.WriteLine();
        }
    }
}