using Library;

namespace ConsoleMode;

public abstract class Element : ElementGeneral
{
    protected void PrintCount(int element, int X_position, int Y_position)
    {
        Console.SetCursorPosition(X_position, Y_position);
        Console.Write(element);
    }
}