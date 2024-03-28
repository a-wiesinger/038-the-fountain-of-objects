namespace _038_the_fountain_of_objects;

public class Map
{
    private int MapSizeWidth { get; }
    private int MapSizeHeight { get; }
    
    public Room[,] DrawnMap { get; }

    public Map(int mapSizeWidth, int mapSizeHeight)
    {
        MapSizeWidth = mapSizeWidth;
        MapSizeHeight = mapSizeWidth;

        DrawnMap = new Room[MapSizeWidth, MapSizeHeight];

        for (int i = 0; i < MapSizeWidth; i++)
        {
            for (int j = 0; j < MapSizeHeight; j++)
            {
                // Fill out row
                if (i == 0 && j == 0)
                {
                    DrawnMap[i, j] = new CavernEntrance();
                    Console.Write($"{DrawnMap[i, j]} ");
                }
                else if (i == 0 && j == 2)
                {
                    DrawnMap[i, j] = new FountainOfObjectsRoom();
                }
                else
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

