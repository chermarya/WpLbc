using Library;

namespace ConsoleMode;

public class ExitKey : Element
{
    public ExitKey()
    {
        Name = "exit_key";
        Symbol = 'î';
        Patency = true;
    }

    public override void PrintElement()
    {
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(Symbol);
        Console.ResetColor();
        Console.Write(" ");
    }
    
    public override void ElementAction(int y, int x)
    {
        PrintCount(++ElementPosition.elems['K'].Count, (x + 2) * 3 + 6, 4);
    }
}