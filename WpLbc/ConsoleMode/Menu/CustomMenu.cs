using Library;

namespace ConsoleMode;

public class CustomMenu : MenuOutput
{
    private delegate bool Action();

    private Dictionary<string, Action> action = new Dictionary<string, Action>()
    {
        { "play", Play },
        { "create", Create },
        { "edit", Edit },
        { "delete", Delete },
        { "exit", Exit }
    };

    private static bool NewMenu(out MenuItem[] levels)
    {
        levels = new MenuItem[] { };

        FileWork file = new FileWork("levels/custom");

        string[] names = file.GetNames();

        if (names.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("There are no custom levels\n");
            Console.Write("Press any key to go back... ");
            Console.ReadKey();
            return false;
        }

        levels = new MenuItem[names.Length + 1];

        for (int i = 0; i < names.Length; i++)
        {
            levels[i] = new MenuItem(names[i], names[i]);
        }
        
        levels[names.Length] = new MenuItem("Go back", "back");
        
        return true;
    }

    private static bool Play()
    {
        MenuItem[] lvls;
        if (NewMenu(out lvls))
            new PlayLvl(lvls);
        return true;
    }

    private static bool Create()
    {
        Console.Clear();
        Console.WriteLine("\nCreating a new level\n");
        Console.WriteLine("# - Wall\n. - Space\nG - gem");
        Console.WriteLine("\nK - key\nD - door\nE - exit\nU - Player");
        Console.WriteLine(
            "\nFirst you need to enter the field size. After that, you will fill the field by pressing 'Enter'.\n");
        Console.WriteLine("When you are done, press 'Delete' to save the level.\n");
        Console.Write("Press any key to continue... ");
        Console.ReadKey();

        Console.Clear();
        new NewField();

        Console.WriteLine("Level was successfully saved\n");
        Console.WriteLine("Press any key to go to menu...");

        Console.ReadKey();
        return true;
    }

    private static bool Edit()
    {
        MenuItem[] lvls;
        if (NewMenu(out lvls))
            new EditLvl(lvls);
        return true;
    }

    private static bool Delete()
    {
        MenuItem[] lvls;
        if (NewMenu(out lvls))
            new DeleteLvl(lvls);
        return true;
    }

    private static bool Exit()
    {
        return false;
    }

    protected override bool ChooseAction(string name)
    {
        return action[name]();
    }

    public CustomMenu()
        : base(
            new MenuItem[]
            {
                new MenuItem("Play a level", "play"),
                new MenuItem("Create a level", "create"),
                new MenuItem("Edit custom level", "edit"),
                new MenuItem("Delete custom level", "delete"),
                new MenuItem("Go back", "exit"),
            },
            "CUSTOM",
            ConsoleColor.White)
    {
    }
}