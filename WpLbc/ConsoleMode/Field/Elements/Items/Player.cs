namespace ConsoleMode;

public class Player : Element
{
    public Player()
    {
        Name = "player";
        Symbol = '║';
    }

    public override void PrintElement()
    {
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(Symbol);
        Console.Write(" ");
        Console.ResetColor();
    }
}