namespace ConsoleMode;

public class Pickaxe : Element
{
    protected ConsoleColor color;
    public Pickaxe(string name)
    {
        Name = name;
        Symbol = '╦';
        Patency = true;
    }
    
    public override void PrintElement()
    {
        Console.Write(" ");
        Console.ForegroundColor = color;
        Console.Write(Symbol);
        Console.ResetColor();
        Console.Write(" ");
    }
}