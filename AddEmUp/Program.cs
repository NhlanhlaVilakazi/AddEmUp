using AddEmUp;

public class Program 
{
    public static void Main()
    {
        string? userInput = Console.ReadLine();

        var fileName = new winner(userInput).GetInputFile();
        new winner(userInput).GetGameWinner(fileName);
    }
}