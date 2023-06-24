namespace ConsoleMode;

public class Wall : Element
{
    public Wall()
    {
        Name = "wall";
        Symbol = ' ';
        Patency = false;
    }

    public override void PrintElement()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(" " + Symbol + " ");
        Console.ResetColor();
    }
}