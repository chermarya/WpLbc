using Library;

namespace ConsoleMode;

public class Amethyst : Gem
{
    public Amethyst()
    { 
        Name = "amethyst";
        Symbol = '♦';
        color = ConsoleColor.Magenta;
    }

    public override void ElementAction(int y, int x)
    {
        PrintCount(++Count, (x + 2) * 3 + 6, 9);
    }
}