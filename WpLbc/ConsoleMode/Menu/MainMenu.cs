using Library;

namespace ConsoleMode;

    public class MainMenu : MenuOutput
    {
        private delegate bool Action();
        private Dictionary<string, Action> action = new Dictionary<string, Action>()
        {
            { "rules", Rules },
            { "play", Play },
            { "custom", Custom },
            { "exit", Exit }
        };

        private static bool Rules()
        {
            Console.Clear();
            Console.WriteLine("\nR U L E S\n");
            Console.WriteLine("Use ←,↑,↓,→ to move. ║ - your position.\n");
            Console.WriteLine("█ - walls, you can not go through them.\n");
            Console.WriteLine("Also, you have doors on the field. You need to collect keys to open them.");
            Console.WriteLine("K - key");
            Console.WriteLine("¶ - door");
            Console.WriteLine("\nYou can collect coins ($), they are randomly generated (from 3 to 5).");
            Console.WriteLine("\n♦ - gem, you can collect them, but you need a pickaxe.");
            Console.WriteLine("They are randomly generated. It depends on which pickaxe you use.");
            Console.WriteLine("\nThe exit (‡) and special key (î) for it will appear when you collect all gems (you can see how many are left).");
            Console.WriteLine("A special key is randomly generated.");
            Console.WriteLine("\nPress 'Delete' to leave the level and go back to menu.");
            Console.Write("\n\nPress any key to back to menu... ");
            Console.ReadKey();

            return true;
        }

        private static bool Play()
        {
            new PlayerMenu();
            return true;
        }

        private static bool Custom()
        {
            new CustomMenu();
            return true;
        }
        
        private static bool Exit()
        {
            return false;
        }

        public MainMenu()
            : base
            (
                new MenuItem[]
                {
                    new MenuItem("Rules", "rules"),
                    new MenuItem("Play", "play"),
                    new MenuItem("Custom", "custom"),
                    new MenuItem("Exit", "exit"),
                },
                
                "Jeweler",
                ConsoleColor.Green
            )
        {  }

        protected override bool ChooseAction(string name)
        {
            return action[name]();
        }
    }
