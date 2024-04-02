using System.ComponentModel;

namespace _038_the_fountain_of_objects;

public class Map
{
    // Properties
    public int MapSizeWidth { get; }
    public int MapSizeHeight { get; }
    
    public int[] FountainLocation { get; }
    public int[] EntranceLocation { get; }
    
    public Room[,] DrawnMap { get; }
    public FountainOfObjectsRoom FountainOfObjects { get; } = new FountainOfObjectsRoom();
    public CavernEntranceRoom CavernEntrance { get; } = new CavernEntranceRoom();
    
    // Constructor
    public Map(string mapSize, int mapSizeWidth, int mapSizeHeight)
    {
        MapSizeWidth = mapSizeWidth;
        MapSizeHeight = mapSizeHeight;

        DrawnMap = new Room[mapSizeWidth, mapSizeHeight];

        if (mapSize == "small")
        {
            FountainLocation = new[] { 0, 2 };
            EntranceLocation = new[] { 0, 0 };
        }
        else if (mapSize == "medium")
        {
            FountainLocation = new[] { 3, 4 };
            EntranceLocation = new[] { 0, 3 };
        }
        else
        {
            FountainLocation = new[] { 2, 5 };
            EntranceLocation = new[] { 7, 2 };
        }

        for (int i = 0; i < MapSizeWidth; i++)
        {
            for (int j = 0; j < MapSizeHeight; j++)
            {
                // Fill out row
                if (i == EntranceLocation[0] && j == EntranceLocation[1])
                {
                    DrawnMap[i, j] = CavernEntrance;
                }
                else if (i == FountainLocation[0] && j == FountainLocation[1])
                {
                    DrawnMap[i, j] = FountainOfObjects;
                }
                else // The rest are normal empty rooms
                {
                    DrawnMap[i, j] = new NormalRoom();
                }
                
                // Comment out below cws to hide map
                Console.Write($"{DrawnMap[i, j]} ");
            }
            // Move to next row 
            Console.WriteLine();
        }
    }
}