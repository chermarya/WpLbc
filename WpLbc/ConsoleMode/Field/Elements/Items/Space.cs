namespace ConsoleMode;

public class Space : Element
{
    public Space()
    {
        Name = "space";
        Symbol = ' ';
        Patency = true;
    }

    public override void PrintElement()
    {
        Console.Write(" " + Symbol + " ");
    }
}