namespace _038_the_fountain_of_objects.Components;

public class ErrorMessaging
{
    public static void InvalidAction()
    {
        Console.WriteLine($"That is not a valid action. Type help for a list of valid actions");
    }
    
    public static void InvalidDirection()
    {
        Console.WriteLine($"You are unable to move further in this direction.");
    }

    public static void InvalidInput()
    {
        Console.WriteLine("Sorry, but you must enter a valid input.");
    }

    public static void Typo()
    {
        Console.WriteLine("Looks like you've got a typo. Check your inputs and try again.");
    }

    public static void NotAtFountain()
    {
        Console.WriteLine("You're not at the Fountain of Objects, yet!!");
    }
}