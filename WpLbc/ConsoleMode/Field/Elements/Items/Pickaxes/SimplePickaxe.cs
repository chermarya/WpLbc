namespace ConsoleMode;

public class SimplePickaxe : Pickaxe
{
    public SimplePickaxe() :base("simple_pickaxe")
    {
        color = ConsoleColor.Gray;
    }
    
    public override void ElementAction(int y, int x)
    {
        PrintCount(++Count, (x + 2) * 3 + 6, 6);
    }
}