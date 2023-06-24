using Library;

namespace ConsoleMode;

public class Gem : Element
{
    protected ConsoleColor color = ConsoleColor.White;
    public Gem()
    {
        Name = "gem";
        Symbol = '▼';
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

    public override void ElementAction(int y, int x)
    {
        PrintCount(--Count, (x + 2) * 3 + 11, 14);

        if (ElementPosition.elems['S'].Count > 0)
        {
            ElementPosition.elems['S'].Count--;
            Console.SetCursorPosition((x + 2) * 3 + 6, 7);
            Console.Write(ElementPosition.elems['S'].Count);
            ElementRandom.SetRandomGem("super_pickaxe").ElementAction(y, x);
        }
        
        else if (ElementPosition.elems['P'].Count > 0)
        {
            ElementPosition.elems['P'].Count--;
            Console.SetCursorPosition((x + 2) * 3 + 6, 6);
            Console.Write(ElementPosition.elems['P'].Count);
            ElementRandom.SetRandomGem("simple_pickaxe").ElementAction(y, x);
        }   
    }
}