using Library;

namespace ConsoleMode;

public class Gamer : GamerGeneral
{
    public Gamer(){}
    
    public Gamer(int a)
    {
        Console.Clear();

        while (ChooseName())
        {
        }

        string password;
        while (ChoosePassword(out password))
        {
        }

        Password = GetHash(password);

        Money = 0;
        Amethyst = 0;
        Ruby = 0;
        Emerald = 0;
        Diamond = 0;
    }

    protected override bool ChooseName()
    {
        string[] playersNames = new FileWork("players").GetNames();

        
        
        Console.Write("\nName: ");
        Name = Console.ReadLine();

        if (Name == "")
        {
            Console.WriteLine("Name can not be empty");
            return true;
        }

        foreach (string i in playersNames)
        {
            if (i == Name)
            {
                Console.WriteLine("This player already exists");
                return true;
            }
        }

        return false;
    }

    protected override bool ChoosePassword(out string password)
    {
        Console.Write("\nPassword: ");
        password = Console.ReadLine();

        if (password.Length < 8)
        {
            Console.WriteLine("Password is too short. It must be minimum 8 symbols.");
            return true;
        }

        int upper = password.Count(c => c >= 'A' && c <= 'Z');
        int lower = password.Count(c => c >= 'a' && c <= 'z');

        if (upper == 0 || lower == 0)
        {
            Console.WriteLine("Password must contain letters in upper and lower case.");
            return true;
        }

        return false;
    }

    public static MenuItem[] ReadPlayers(int a)
    {
        MenuItem[] players = new MenuItem[] { };

        FileWork file = new FileWork("players");

        string[] names = file.GetNames();

        if (names.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("There are no players\n");
            Console.Write("Press any key to go back... ");
            Console.ReadKey();
            new PlayerMenu();
        }
        else
        {
            if (a == 0)
                players = new MenuItem[names.Length + 1];
            else
                players = new MenuItem[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                players[i] = new MenuItem(names[i], names[i]);
            }

            if (a == 0)
                players[names.Length] = new MenuItem("Go back", "back");
        }

        return players;
    }
}