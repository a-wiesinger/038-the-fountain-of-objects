namespace _038_the_fountain_of_objects.Components;

public class Map
{
    // Properties
    public int MapSizeWidth { get; }
    public int MapSizeHeight { get; }
    
    public int[] FountainLocation { get; }
    public int[] CavernEntranceLocation { get; }
    public int[,] PitLocations { get; }

    private bool IsPitCreationFinished { get; }
    
    public Room[,] DrawnMap { get; }
    public FountainOfObjectsRoom FountainOfObjects { get; } = new FountainOfObjectsRoom();
    public CavernEntranceRoom CavernEntrance { get; } = new CavernEntranceRoom();
    public PitRoom Pit { get; } = new PitRoom();
    public NormalRoom Normal { get; } = new NormalRoom();
    
    // Constructor
    public Map(string mapSize, int mapSizeWidth, int mapSizeHeight, Player player)
    {
        MapSizeWidth = mapSizeWidth;
        MapSizeHeight = mapSizeHeight;

        DrawnMap = new Room[mapSizeWidth, mapSizeHeight];

        // Map sizes based on player input
        if (mapSize == "small")
        {
            FountainLocation = new[] { 0, 2 };
            CavernEntranceLocation = new[] { 0, 0 };
            PitLocations = new[,] { { 3, 2 } };
            player.CurrentLocation = new[] { CavernEntranceLocation[0], CavernEntranceLocation[1] };
        }
        else if (mapSize == "medium")
        {
            FountainLocation = new[] { 3, 4 };
            CavernEntranceLocation = new[] { 0, 3 };
            PitLocations = new[,] { { 3, 0 }, { 5, 2 } };
            player.CurrentLocation = new[] { CavernEntranceLocation[0], CavernEntranceLocation[1] };
        }
        else
        {
            FountainLocation = new[] { 2, 5 };
            CavernEntranceLocation = new[] { 7, 2 };
            PitLocations = new[,] { { 0, 3 }, { 6, 4 }, { 3, 2 }, { 1, 4 } };
            player.CurrentLocation = new[] { CavernEntranceLocation[0], CavernEntranceLocation[1] };
        }
        
        // Build Map
        // Construct basic map full of normal rooms
        AddBlankMap();
        AddFountainOfObjects();
        AddCavernEntrance();
        AddPitLocations();
        RenderMap(mapSizeWidth, mapSizeHeight);
    }
    
    // Methods
    public void AddBlankMap()
    {
        for (int i = 0; i < MapSizeWidth; i++)
        {
            for (int j = 0; j < MapSizeHeight; j++)
            {
                // Fill map with normal empty rooms
                DrawnMap[i, j] = Normal;
            }
        }
    }
    
    public void AddFountainOfObjects()
    {
        DrawnMap[FountainLocation[0], FountainLocation[1]] = FountainOfObjects;
    }

    public void AddCavernEntrance()
    {
        DrawnMap[CavernEntranceLocation[0], CavernEntranceLocation[1]] = CavernEntrance;
    }

    public void AddPitLocations()
    {
        for (int i = 0; i < PitLocations.Length / 2; i++)
        {
            int pitCoordOne = 0;
            int pitCoordTwo = 1;

            DrawnMap[PitLocations[i, pitCoordOne], PitLocations[i, pitCoordTwo]] = Pit;
        }
    }

    public void RenderMap(int mapSizeWidth, int mapSizeHeight)
    {
        for (int i = 0; i < mapSizeWidth; i++)
        {
            for (int j = 0; j < mapSizeHeight; j++)
            {
                Console.Write($"{DrawnMap[i, j]} ");
            }
            Console.WriteLine();
        }
    }
    
    public Room GetCurrentRoomType(Player player, Map map)
    {
        return map.DrawnMap[player.CurrentLocation[0], player.CurrentLocation[1]];
    }
}