using AddEmUp;

public class Program 
{
    public static void Main()
    {
        string? userInput = Console.ReadLine();
        winner winner = new(userInput);
        winner.GetInputFile(userInput);
    }
}