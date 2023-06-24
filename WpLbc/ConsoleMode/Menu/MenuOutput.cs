using Library;

namespace ConsoleMode;

public abstract class MenuOutput
{
    private int WibdowPosition = (Console.WindowWidth / 2) - 20;

    private MenuItem[] items;
    private string title;
    private ConsoleColor color;

    private int pos = 0;

    public MenuOutput(MenuItem[] items, string title, ConsoleColor color)
    {
        this.items = items;
        this.title = title;
        this.color = color;

        PrintMenu();
        while (Movement())
        {
        }
    }

    public MenuOutput(MenuItem[] items, string title, ConsoleColor color, out string name)
    {
        name = title;

        this.items = items;
        this.title = title;
        this.color = color;

        PrintMenu();
        while (Movement()) { }
    }

    private void PrintMenu()
    {
        Console.Clear();

        Console.WriteLine("\n" + string.Concat(Enumerable.Repeat(" ", 20 - title.Length / 2 + WibdowPosition)) + title +
                          "\n");

        items[0].selected = true;

        for (int i = 0; i < items.Length; i++)
        {
            Console.Write(string.Concat(Enumerable.Repeat(" ", WibdowPosition)));
            if (items[i].selected)
            {
                Console.BackgroundColor = color;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine($"  {items[i].title}" +
                              string.Concat(Enumerable.Repeat(" ", 40 - items[i].title.Length)));
            Console.ResetColor();
        }
    }

    private bool Movement()
    {
        ConsoleKey key = Console.ReadKey().Key;

        Console.SetCursorPosition(WibdowPosition, pos + 3);
        Console.WriteLine(string.Concat(Enumerable.Repeat(" ", 40)));
        Console.SetCursorPosition(WibdowPosition, pos + 3);
        Console.WriteLine($"  {items[pos].title}" +
                          string.Concat(Enumerable.Repeat(" ", 40 - items[pos].title.Length)));

        switch (key)
        {
            case ConsoleKey.UpArrow:
                pos -= 1;
                break;
            case ConsoleKey.DownArrow:
                pos += 1;
                break;
            case ConsoleKey.Enter:
                if (ChooseAction(items[pos].name))
                {
                    PrintMenu();
                    pos = 0;
                    return true;
                }

                return false;
        }

        if (pos < 0)
            pos += items.Length;
        if (pos > items.Length - 1)
            pos -= items.Length;

        Console.SetCursorPosition(WibdowPosition, pos + 3);
        Console.BackgroundColor = color;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"  {items[pos].title}" +
                          string.Concat(Enumerable.Repeat(" ", 40 - items[pos].title.Length)));
        Console.ResetColor();

        return true;
    }

    protected abstract bool ChooseAction(string name);
}