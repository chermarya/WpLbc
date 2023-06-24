namespace ConsoleMode;

public class SuperPickaxe : Pickaxe
{
    public SuperPickaxe() :base("super_pickaxe")
    {
        color = ConsoleColor.Yellow;
    }
    
    public override void ElementAction(int y, int x)
    {
        PrintCount(++Count, (x + 2) * 3 + 6, 7);
    }
}