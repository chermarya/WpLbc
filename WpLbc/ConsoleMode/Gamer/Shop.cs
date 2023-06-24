using Library;

namespace ConsoleMode;

public class Shop : ShopGeneral
{
    private static int WibdowPosition = (Console.WindowWidth / 2) - 20;
    private string tab = string.Concat(Enumerable.Repeat(" ", WibdowPosition - 15));

    private Gamer gamer;

    public Shop(Gamer gamer)
    {
        this.gamer = gamer;
        ConsoleKeyInfo key;

        do
        {
            while (Console.KeyAvailable == false)
            {
                Print();
                ChooseAction();
            }

            key = Console.ReadKey(true);
        } while (key.Key != ConsoleKey.Delete);
    }

    protected override void Print()
    {
        Console.Clear();

        string title = "S H O P";

        Console.WriteLine("\n" + string.Concat(Enumerable.Repeat(" ", 20 - title.Length / 2 + WibdowPosition)) + title +
                          "\n");

        Console.WriteLine(tab + $"Your Coins: {gamer.Money}\n");

        Console.Write(tab + "{0, -15}", "");
        Console.Write("{0, -15}", "You have");
        Console.Write("{0, -15}", "Cost");
        Console.WriteLine();

        Console.Write(tab + "{0, -15}", "1.Amethyst");
        Console.Write("{0, -15}", gamer.Amethyst);
        Console.Write("{0, -15}", price["Amethyst"]);
        Console.WriteLine();

        Console.Write(tab + "{0, -15}", "2.Ruby");
        Console.Write("{0, -15}", gamer.Ruby);
        Console.Write("{0, -15}", price["Ruby"]);
        Console.WriteLine();

        Console.Write(tab + "{0, -15}", "3.Emerald");
        Console.Write("{0, -15}", gamer.Emerald);
        Console.Write("{0, -15}", price["Emerald"]);
        Console.WriteLine();

        Console.Write(tab + "{0, -15}", "4.Diamond");
        Console.Write("{0, -15}", gamer.Diamond);
        Console.Write("{0, -15}", price["Diamond"]);
        Console.WriteLine();

        Console.WriteLine("\n" + tab + "---------------------------------------\n");
    }

    protected override void ChooseAction()
    {
        Console.WriteLine(tab + $"Choose the action:\n{tab}1 - sell\n{tab}2 - buy\n");

        Dictionary<string, Action> acts = new Dictionary<string, Action>()
        {
            { "1", Sell },
            { "2", Buy },
        };

        while (true)
        {
            try
            {
                Console.Write(tab + ">>> ");
                string input = Console.ReadLine();
                acts[input]();
                break;
            }
            catch
            {
                Console.WriteLine(tab + "Incorrect input\n");
            }
        }
    }
    
    protected override void Sell()
    {
    }

    protected override void Buy()
    {
    }
}