namespace ConsoleMode;

public class Door : Element
{
    public Door()
    {
        Name = "door";
        Symbol = '¶';
        Patency = false;
    }

    public override void PrintElement()
    {
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(Symbol);
        Console.ResetColor();
        Console.Write(" ");
    }
}