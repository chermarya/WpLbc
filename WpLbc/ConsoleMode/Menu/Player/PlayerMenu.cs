using System.Text.Json;
using Library;

namespace ConsoleMode;

public class PlayerMenu : MenuOutput
{
    private delegate bool Action();
    private Dictionary<string, Action> action = new Dictionary<string, Action>()
    {
        { "create", Create },
        { "choose", Choose },
        { "delete", Delete },
        { "exit", Exit },
    };

    private static bool Create()
    {
        new FileWork("").CreateGamer(new Gamer(0));
        return true;
    }
    
    private static bool Delete()
    {
        new DeletePlayer(Gamer.ReadPlayers(0));
        return false;
    }
    
    private static bool Choose()
    {
        new ChoosePlayerMenu(Gamer.ReadPlayers(0));
        return true;
    }

    private static bool Exit()
    {
        return false;
    }
    
    public PlayerMenu()
        : base
        (
            new MenuItem[]
            {
                new MenuItem("Create new Player", "create"),
                new MenuItem("Choose existing Player", "choose"),
                new MenuItem("Delete Player", "delete"),
                new MenuItem("Go back", "exit"),
            },
            "",
            ConsoleColor.White
        )
    { }

    protected override bool ChooseAction(string name)
    {
        return action[name]();
    }
}