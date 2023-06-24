namespace ConsoleMode;

public class Emerald : Gem
{
    public Emerald()
    {
        Name = "emerald";
        Symbol = '♦';
        color = ConsoleColor.Green;
    }

    public override void ElementAction(int y, int x)
    {
        PrintCount(++Count, (x + 2) * 3 + 6, 11);
    }
}