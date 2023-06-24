using System.Text.Json;
using Library;

namespace ConsoleMode;

public class PlayerStats : MenuOutput
{
    private static string playerName; private delegate bool Action();

    private Dictionary<string, Action> action = new Dictionary<string, Action>()
    {
        { "view", View },
        { "shop", Shop },
        { "play", Play },
        { "exit", Exit },
    };

    private static bool View()
    {
        new ViewProfile(JsonSerializer.Deserialize<Gamer>(File.ReadAllText($"../../../../Library/players/{playerName}.json")));
        
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.Delete)
                return true;
        }
    }
    
    private static bool Shop()
    {
        new Shop(JsonSerializer.Deserialize<Gamer>(File.ReadAllText($"../../../../Library/players/{playerName}.json")));
        return true;
    }
    
    private static bool Play()
    {
        new Field("mainLvl", playerName);
        
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.Delete)
                return true;
        }
    }
    
    private static bool Exit()
    {
        return false;
    }
    
    public PlayerStats(string player_name)
        : base
        (
            new MenuItem[]
            {
                new MenuItem("View profile", "view"),
                new MenuItem("Shop", "shop"),
                new MenuItem("Play level", "play"),
                new MenuItem("Log out", "exit"),
            },
            player_name,
            ConsoleColor.Yellow,
            out playerName
        )
    { }

    protected override bool ChooseAction(string name)
    {
        return action[name]();
    }
}