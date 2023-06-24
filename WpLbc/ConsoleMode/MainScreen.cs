namespace ConsoleMode;

public class MainScreen
{
    private int WindowPosition = Console.WindowWidth / 2;
    private static Dictionary<char, ConsoleColor> Color = new Dictionary<char, ConsoleColor>()
    {
        {'D', ConsoleColor.DarkBlue},
        {'C', ConsoleColor.Cyan},
        {'Y', ConsoleColor.Yellow},
        {'W', ConsoleColor.White}
    };

    private static char[,] frame1 = new char[,]
    {
        {' ', ' ', ' ', '.', ' ', ' ', ' '},
        {' ', ' ', ' ', 'D', ' ', ' ', ' '},
        {' ', ' ', '.', 'D', '.', ' ', ' '},
        {'.', 'D', 'D', 'Y', 'D', 'D', '.'},
        {' ', ' ', '.', 'D', '.', ' ', ' '},
        {' ', ' ', ' ', 'D', ' ', ' ', ' '},
        {' ', ' ', ' ', '.', ' ', ' ', ' '},
    };
    private static char[,] frame2 = new char[,]
    {
        {' ', ' ', ' ', 'D', ' ', ' ', ' '},
        {' ', ' ', ' ', 'D', ' ', ' ', ' '},
        {' ', ' ', 'D', 'Y', 'D', ' ', ' '},
        {'D', 'D', 'Y', 'W', 'Y', 'D', 'D'},
        {' ', ' ', 'D', 'Y', 'D', ' ', ' '},
        {' ', ' ', ' ', 'D', ' ', ' ', ' '},
        {' ', ' ', ' ', 'D', ' ', ' ', ' '},
    };
    
    private static char[,] Field = new char[,]
    {
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //0
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //1
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //2
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //3
        {' ', ' ', ' ', ' ', ' ', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //4
        {' ', ' ', ' ', ' ', 'D', 'C', 'C', 'C', 'C', 'C', 'C', 'C', 'C', 'C', 'C', 'C', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //5
        {' ', ' ', ' ', 'D', 'C', 'D', 'C', 'C', 'C', 'C', 'C', 'D', 'W', 'W', 'C', 'C', 'C', 'D', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //6
        {' ', ' ', 'D', 'C', 'C', 'C', 'D', 'W', 'W', 'C', 'D', 'C', 'D', 'W', 'C', 'C', 'D', 'C', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' '}, //7
        {' ', 'D', 'C', 'C', 'C', 'C', 'C', 'D', 'W', 'D', 'C', 'C', 'C', 'D', 'C', 'D', 'W', 'C', 'C', 'C', 'D', ' ', ' ', ' ', ' ', ' '}, //8
        {'D', 'C', 'W', 'W', 'C', 'C', 'C', 'C', 'D', 'W', 'W', 'C', 'C', 'C', 'D', 'W', 'W', 'W', 'C', 'C', 'C', 'D', ' ', ' ', ' ', ' '}, //9
        {'D', 'C', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'C', 'D', ' ', ' ', ' ', ' '}, //10
        {' ', 'D', 'W', 'W', 'C', 'C', 'C', 'C', 'D', 'W', 'C', 'C', 'C', 'C', 'D', 'W', 'W', 'C', 'C', 'C', 'D', ' ', ' ', ' ', ' ', ' '}, //11
        {' ', ' ', 'D', 'W', 'C', 'C', 'C', 'C', 'D', 'W', 'W', 'C', 'C', 'C', 'D', 'W', 'C', 'C', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' '}, //12
        {' ', ' ', ' ', 'D', 'W', 'D', 'C', 'C', 'D', 'W', 'W', 'C', 'C', 'C', 'D', 'C', 'C', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //13
        {' ', ' ', ' ', ' ', 'D', 'C', 'D', 'C', 'C', 'D', 'C', 'C', 'C', 'D', 'C', 'C', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //14
        {' ', ' ', ' ', ' ', ' ', 'D', 'C', 'D', 'C', 'D', 'C', 'C', 'C', 'C', 'D', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //15
        {' ', ' ', ' ', ' ', ' ', ' ', 'D', 'C', 'D', 'C', 'D', 'C', 'D', 'D', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //16
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'C', 'D', 'D', 'C', 'D', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //17
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'C', 'D', 'D', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //18
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'C', 'C', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //19
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //20
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //21
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //22
    };

    public MainScreen()
    {
        string str;
        ConsoleKeyInfo key;
        
        Console.Clear();
        str = "J E W E L E R";
        Console.WriteLine("\n" + string.Concat(Enumerable.Repeat(" ", WindowPosition - str.Length / 2 + 7)) + str);
        str = "press 'Enter' to start\n";
        Console.WriteLine(string.Concat(Enumerable.Repeat(" ", WindowPosition - str.Length / 2 + 7)) + str);
        
        do {
            while (Console.KeyAvailable == false)
            {
                Console.SetCursorPosition(0, 3);
                PrintDiamond(Field);

                Animation(19, 0, frame2);
                Animation(0, 16, frame2);
                Animation(17, 14, frame1);
                Thread.Sleep(500);

                Animation(19, 0, frame1);
                Animation(0, 16, frame1);
                Animation(17, 14, frame2);
                Thread.Sleep(500);
            }
            
            key = Console.ReadKey(true);
        } while(key.Key != ConsoleKey.Enter);
        
        Console.Clear();
    }
    private void PrintDiamond(char[,] field)
    {
        for (int i = 0; i < 23; i++)
        {
            Console.Write(string.Concat(Enumerable.Repeat(" ", WindowPosition - 14)));
            for (int j = 0; j < 26; j++)
            {
                if (field[i, j] != ' ')
                {
                    Console.BackgroundColor = Color[field[i, j]];
                    Console.Write("  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
    }
    private void Animation(int x, int y, char[,] frame)
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Console.SetCursorPosition(WindowPosition - 14 + (x + j) * 2, y + i + 4);
                if (frame[i, j] == '.')
                {
                    Console.Write("  ");
                }
                else if (frame[i, j] != ' ')
                {
                    Console.BackgroundColor = Color[frame[i, j]];
                    Console.Write("  ");
                    Console.ResetColor();
                }
            }
        }
        Console.WriteLine("  ");
    }
}