using Library;

namespace ConsoleMode;

public class ElementPosition
{
    protected int exitCoordX, exitCoordY;
    
    protected int[] exitKeyCoord = new int[2];
    
    protected delegate ElementGeneral ElementPos();
    protected Dictionary <char, ElementPos> placement = new Dictionary<char, ElementPos>
    {
        {'.', Space},
        {'#', Wall},
        {'U', Player},
        {'E', Exit},
        {'D', Door},
        {'K', Key},
        {'C', Coin},
        {'P', Pickaxe},
        {'G', Gem}
    };
    
    public static Dictionary <char, ElementGeneral> elems = new Dictionary<char, ElementGeneral>
    {
        {'.', new Space()},
        {'#', new Wall()},
        {'E', new Exit()},
        {'e', new ExitKey()},
        {'D', new Door()},
        {'K', new Key()},
        {'C', new Coin()},
        {'P', new SimplePickaxe()},
        {'S', new SuperPickaxe()},
        {'G', new Gem()}
    };

    protected static Dictionary<char, Gem> gems = new Dictionary<char, Gem>()
    {
        {'A', new Amethyst()},
        {'R', new Ruby()},
        {'E', new Emerald()},
        {'D', new Diamond()},
    };
    
    protected Dictionary<char, Pickaxe> pickaxes = new Dictionary<char, Pickaxe>()
    {
        {'S', new SimplePickaxe()},
        {'U', new SuperPickaxe()},
    };
    private static ElementGeneral Gem() => elems['G'];
    private static ElementGeneral Pickaxe()
    {
        Random rand = new Random();
        int num = rand.Next(1, 11);

        if (num == 1)
            return elems['S'];
        return elems['P'];
    }
    private static ElementGeneral Space() => elems['.'];
    private static ElementGeneral Wall() => elems['#'];
    private static ElementGeneral Player() => new Player();
    private static ElementGeneral Exit() => elems['E'];
    private static ElementGeneral Door() => elems['D'];
    private static ElementGeneral Key() => elems['K'];
    private static ElementGeneral Coin() => elems['C'];
}