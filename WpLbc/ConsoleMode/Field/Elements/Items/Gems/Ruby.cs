namespace ConsoleMode;

public class Ruby : Gem
{
    public Ruby()
    {
        Name = "ruby";
        Symbol = '♦';
        color = ConsoleColor.Red;
    }

    public override void ElementAction(int y, int x)
    {
        PrintCount(++Count, (x + 2) * 3 + 6, 10);
    }
}