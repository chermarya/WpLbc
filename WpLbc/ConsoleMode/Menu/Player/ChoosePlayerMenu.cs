using System.Text.Json;
using Library;

namespace ConsoleMode;

public class ChoosePlayerMenu : MenuOutput
{
    public ChoosePlayerMenu(MenuItem[] players)
        : base
        (
            players,
            "PLAYERS",
            ConsoleColor.Yellow
        )
    {
    }

    protected override bool ChooseAction(string name)
    {
        if (name == "back")
            return false;
        
        if (IsPasswordCorrect(name))
            new PlayerStats(name);
        else
        {
            Console.WriteLine("Wrong password!");
            Console.Write("Press any key to go back... ");
            Console.ReadKey();
        }

        return true;
    }

    private bool IsPasswordCorrect(string name)
    {
        Console.Clear();

        Gamer gamer = JsonSerializer.Deserialize<Gamer>(File.ReadAllText($"../../../../Library/players/{name}.json"));

        Console.Write("Password: ");
        string input = Console.ReadLine();
        return gamer.GetHash(input) == gamer.Password;
    }
}