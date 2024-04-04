namespace _038_the_fountain_of_objects.Components;

public class TextColor
{
    public static void MakeTextMagenta()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
    }

    public static void MakeTextYellow()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }

    public static void MakeTextWhite()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void MakeTextCyan()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    public static void MakeTextBlue()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }

    public static void ResetTextColor()
    {
        Console.ResetColor();
    }
}