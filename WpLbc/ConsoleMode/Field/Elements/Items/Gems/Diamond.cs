namespace ConsoleMode;

public class Diamond : Gem
{
    public Diamond()
    {
        Name = "diamond";
        Symbol = '♦';
        color = ConsoleColor.Cyan;
    }

    public override void ElementAction(int y, int x)
    {
        PrintCount(++Count, (x + 2) * 3 + 6, 12);
    }
}