namespace ConsoleMode;

public class Key : Element
{
    public Key()
    {
        Name = "key";
        Symbol = 'K';
        Patency = true;
    }


    public override void PrintElement()
    {
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(Symbol);
        Console.ResetColor();
        Console.Write(" ");
    }
    
    public override void ElementAction(int y, int x)
    {
        PrintCount(++Count, (x + 2) * 3 + 6, 4);
    }
}