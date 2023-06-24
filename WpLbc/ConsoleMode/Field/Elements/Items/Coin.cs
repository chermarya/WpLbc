namespace ConsoleMode;

public class Coin : Element
{
    public Coin()
    {
        Name = "coin";
        Symbol = '$';
        Patency = true;
    }

    public override void PrintElement()
    {
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(Symbol);
        Console.ResetColor();
        Console.Write(" ");
    }
    
    public override void ElementAction(int y, int x)
    {
        PrintCount(++Count, (x + 2) * 3, 1);
    }
}