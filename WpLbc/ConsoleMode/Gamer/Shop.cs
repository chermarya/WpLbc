using System.Text.Json;
using Library;

namespace ConsoleMode;

public class Shop : ShopGeneral
{
    private bool flag = true;
    private static int WibdowPosition = (Console.WindowWidth / 2) - 20;
    private string tab = string.Concat(Enumerable.Repeat(" ", WibdowPosition - 15));

    private Gamer gamer;

    private Dictionary<string, int> amount = new Dictionary<string, int>()
    {
        {"Money", 0},
        {"Amethyst", 0},
        {"Ruby", 0},
        {"Emerald", 0},
        {"Diamond", 0}
    };

    public Shop(Gamer gamer)
    {
        this.gamer = gamer;

        amount["Money"] = gamer.Money;
        amount["Amethyst"] = gamer.Amethyst;
        amount["Ruby"] = gamer.Ruby;
        amount["Emerald"] = gamer.Emerald;
        amount["Diamond"] = gamer.Diamond;

        do
        {
            Print();
            ChooseAction();
        } while (flag);
    }

    protected override void Print()
    {
        Console.Clear();

        string title = "S H O P";

        Console.WriteLine("\n" + string.Concat(Enumerable.Repeat(" ", 20 - title.Length / 2 + WibdowPosition)) + title +
                          "\n");

        Console.WriteLine(tab + $"Your Coins: {amount["Money"]}\n");

        Console.Write(tab + "{0, -15}", "");
        Console.Write("{0, -15}", "You have");
        Console.Write("{0, -15}", "Cost");
        Console.WriteLine();

        Console.Write(tab + "{0, -15}", "1.Amethyst");
        Console.Write("{0, -15}", amount["Amethyst"]);
        Console.Write("{0, -15}", price["Amethyst"]);
        Console.WriteLine();

        Console.Write(tab + "{0, -15}", "2.Ruby");
        Console.Write("{0, -15}", amount["Ruby"]);
        Console.Write("{0, -15}", price["Ruby"]);
        Console.WriteLine();

        Console.Write(tab + "{0, -15}", "3.Emerald");
        Console.Write("{0, -15}", amount["Emerald"]);
        Console.Write("{0, -15}", price["Emerald"]);
        Console.WriteLine();

        Console.Write(tab + "{0, -15}", "4.Diamond");
        Console.Write("{0, -15}", amount["Diamond"]);
        Console.Write("{0, -15}", price["Diamond"]);
        Console.WriteLine();

        Console.WriteLine("\n" + tab + "---------------------------------------\n");
    }

    protected override void ChooseAction()
    {
        Console.WriteLine(tab + $"Choose the action:\n{tab}1 - sell\n{tab}2 - buy\n{tab}3 - exit\n");

        Dictionary<string, Action> acts = new Dictionary<string, Action>()
        {
            { "1", Sell },
            { "2", Buy },
            { "3", Exit },
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
        int input;
        while (true)
        {
            try
            {
                Console.Write("\n" + tab + "Enter a number of item to sell: ");
                input = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine(tab + "Wrong input!");
            }
        }

        string item = itemNumber[input];
        Console.WriteLine("\n" + tab + $"You want to sell {item}");
        
        while (true)
        {
            try
            {
                Console.Write("\n" + tab + "Quantity: ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input > amount[item])
                {
                    Console.WriteLine(tab +"You don't have enough");
                }
                else if (input < 0)
                {
                    Console.WriteLine(tab +"Wrong input");
                }
                else
                {
                    amount[item] -= input;
                    amount["Money"] += input * price[item];
                    Save();
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(tab + "Wrong input!");
            }
        }
    }

    protected override void Buy()
    {
    }

    private void Save()
    {
        gamer.Money = amount["Money"];
        gamer.Amethyst = amount["Amethyst"];
        gamer.Ruby = amount["Ruby"];
        gamer.Emerald = amount["Emerald"];
        gamer.Diamond = amount["Diamond"];
        
        File.WriteAllText($"../../../../Library/players/{gamer.Name}.json", JsonSerializer.Serialize(gamer));
    }
    
    private void Exit()
    {
        flag = false;
    }
}