namespace ConsoleMode;

public class Exit : Door
{
    public Exit()
    {
        Name = "exit";
        Symbol = '‡';
        Patency = false;
    }

    public override void PrintElement()
    {
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(Symbol);
        Console.ResetColor();
        Console.Write(" ");
    }
}