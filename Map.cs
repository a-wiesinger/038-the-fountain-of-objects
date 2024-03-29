namespace _038_the_fountain_of_objects;

public class Map
{
    // Properties
    private int MapSizeWidth { get; }
    private int MapSizeHeight { get; }
    
    public Room[,] DrawnMap { get; }

    // Constructor
    public Map(int mapSizeWidth, int mapSizeHeight)
    {
        MapSizeWidth = mapSizeWidth;
        MapSizeHeight = mapSizeHeight;

        DrawnMap = new Room[MapSizeWidth, MapSizeHeight];

        for (int i = 0; i < MapSizeWidth; i++)
        {
            for (int j = 0; j < MapSizeHeight; j++)
            {
                // Fill out row
                if (i == 0 && j == 0) // Where the entrance is
                {
                    DrawnMap[i, j] = new CavernEntrance();
                }
                else if (i == 0 && j == 2) // Where the Fountain is
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