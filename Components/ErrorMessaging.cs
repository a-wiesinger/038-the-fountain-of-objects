using System.Net.Mime;

namespace _038_the_fountain_of_objects.Components;

public class ErrorMessaging
{
    public static void InvalidAction()
    {
        TextColor.MakeTextRed();
        Console.WriteLine($"That is not a valid action. Type help for a list of valid actions");
        TextColor.ResetTextColor();
    }
    
    public static void InvalidDirection()
    {
        TextColor.MakeTextRed();
        Console.WriteLine($"You are unable to move further in this direction.");
        TextColor.ResetTextColor();
    }

    public static void InvalidInput()
    {
        TextColor.MakeTextRed();
        Console.WriteLine("Sorry, but you must enter a valid input.");
        TextColor.ResetTextColor();
    }

    public static void Typo()
    {
        TextColor.MakeTextRed();
        Console.WriteLine("Looks like you've got a typo. Check your inputs and try again.");
        TextColor.ResetTextColor();
    }

    public static void NotAtFountain()
    {
        TextColor.MakeTextRed();
        Console.WriteLine("You're not at the Fountain of Objects, yet!!");
        TextColor.ResetTextColor();
    }
}