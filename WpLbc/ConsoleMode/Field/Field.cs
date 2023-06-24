using System.Text.Json;
using Library;

namespace ConsoleMode;

public class Field : ElementPosition
{
    private ElementRandom elemRand = new ElementRandom();
    private Engine engine;
    private ElementGeneral[,] _field;

    private int _sideX, _sideY;
    private static int _posX = 0, _posY = 0;
    private int _tempX, _tempY;
    private int _coinCount;
    
    private int amountOfGemsArea1 = 4;
    private int amountOfGemsArea2 = 4;
    
    private List<int[]> _spaces = new List<int[]>();

    public Field(string lvlName, string player_name)
    {
        int posX = 0, posY = 0;

        foreach (var i in elems.Keys)
        {
            elems[i].Count = 0;
        }

        foreach (var i in gems.Keys)
        {
            gems[i].Count = 0;
        }
        
        FileWork file = new FileWork("levels");

        string[] lvlLines = file.ReadField(lvlName, out _sideX, out _sideY);

        _field = new Element[_sideY, _sideX];

        for (int i = 0; i < _sideY; i++)
        {
            char[] line = lvlLines[i].ToCharArray();
            for (int j = 0; j < _sideX; j++)
            {
                _field[i, j] = placement[line[j]]();

                switch (_field[i, j].Name)
                {
                    case "space":
                    {
                        _spaces.Add(new int[] { j, i });
                        break;
                    }
                    case "player":
                    {
                        posX = j;
                        posY = i;
                        break;
                    }
                    case "exit":
                    {
                        exitCoordX = j;
                        exitCoordY = i;
                        _field[i, j] = elems['.'];
                        break;
                    }
                }
            }
        }

        elems['G'].Count = amountOfGemsArea1 + amountOfGemsArea2;
        
        _field = elemRand.BasePlacement(_spaces, _field, out _coinCount, out exitKeyCoord);
        _field = elemRand.ArbitraryRandom(new int[] { 1, 1 }, new int[] { 1, 6 }, _field, amountOfGemsArea1, exitCoordX, exitCoordY);
        _field = elemRand.RectangleRandom(new int[] { 6, 7 }, new int[] { 10, 10 }, _field, amountOfGemsArea2, exitCoordX, exitCoordY);

        PrintField();

        engine = new Engine(_field, posX, posY, _sideX, _sideY, exitCoordX, exitCoordY, exitKeyCoord);

        while (engine.Move(player_name)) { }
        
        File.WriteAllText($"../../../../Library/players/{player_name}.json", JsonSerializer.Serialize(SaveItems(JsonSerializer.Deserialize<Gamer>(File.ReadAllText($"../../../../Library/players/{player_name}.json")))));
        
        Victory();
    }
    
    public Field (int sideX, int sideY, out char[,] field)
    {
        field = new char[sideY, sideX];

        Console.Clear();
        Console.WriteLine("\n");
        
        for (int i = 0; i < sideY; i++)
        {
            for (int j = 0; j < sideX; j++)
            {
                field[i, j] = '.';
                Console.Write("  " + field[i, j]);
            }
            Console.Write("\n");
        }

        Console.Write("\n");
    }
    
    public Field (string lvlName, out char[,] field, out int _sideX, out int _sideY)
    {
        FileWork file = new FileWork("levels/custom");

        string[] lvlLines = file.ReadField(lvlName, out _sideX, out _sideY);

        field = new char[_sideY, _sideX];

        Console.Clear();
        Console.WriteLine("\n");
        
        for (int i = 0; i < _sideY; i++)
        {
            char[] line = lvlLines[i].ToCharArray();
            for (int j = 0; j < _sideX; j++)
            {
                field[i, j] = line[j];
                Console.Write("  " + field[i, j]);
            }
            Console.Write("\n");
        }

        Console.Write("\n");
    }

    public Field(string lvlName, string folder, int a)
    {
        int posX = 0, posY = 0;

        FileWork file = new FileWork("levels/" + folder);

        string[] lvlLines = file.ReadField(lvlName, out _sideX, out _sideY);
        
        
        _field = new Element[_sideY, _sideX];

        for (int i = 0; i < _sideY; i++)
        {
            char[] line = lvlLines[i].ToCharArray();
            for (int j = 0; j < _sideX; j++)
            {
                _field[i, j] = placement[line[j]]();

                switch (_field[i, j].Name)
                {
                    case "space":
                    {
                        _spaces.Add(new int[] { j, i });
                        break;
                    }
                    case "player":
                    {
                        posX = j;
                        posY = i;
                        break;
                    }
                    case "gem":
                    {
                        elems['G'].Count++;
                        break;
                    }
                    case "exit":
                    {
                        exitCoordX = j;
                        exitCoordY = i;
                        _field[i, j] = elems['.'];
                        break;
                    }
                }
            }
        }

        _field = elemRand.BasePlacement(_spaces, _field, out _coinCount, out exitKeyCoord);

        PrintField();
        
        engine = new Engine(_field, posX, posY, _sideX, _sideY,exitCoordX, exitCoordY, exitKeyCoord);

        while (engine.Move()) { }

        Victory();
    }

    private void PrintField()
    {
        Console.Clear();

        for (byte i = 0; i < _sideY; i++)
        {
            for (byte j = 0; j < _sideX; j++)
            {
                _field[i, j].PrintElement();
            }

            Console.Write("\n");
        }

        PrintSideBar();
    }

    private void PrintSideBar()
    {
        int topCursor = 1;
        Console.SetCursorPosition((_sideX + 2) * 3, topCursor++);
        Console.WriteLine($"0/{_coinCount} coins");

        Console.SetCursorPosition((_sideX + 2) * 3, ++topCursor);
        Console.WriteLine("Inventory:");

        Console.SetCursorPosition((_sideX + 2) * 3, ++topCursor);
        elems['K'].PrintElement();
        Console.Write(" x 0");

        topCursor++;
        foreach (var pickaxe in pickaxes.Values)
        {
            Console.SetCursorPosition((_sideX + 2) * 3, ++topCursor);
            pickaxe.PrintElement();
            Console.Write(" x 0\n");
        }

        topCursor++;
        foreach (var gem in gems.Values)
        {
            Console.SetCursorPosition((_sideX + 2) * 3, ++topCursor);
            gem.PrintElement();
            Console.Write(" x 0\n");
        }

        topCursor++;
        Console.SetCursorPosition((_sideX + 2) * 3, ++topCursor);
        Console.WriteLine($"Gems left: {elems['G'].Count}");
    }

    private void Victory()
    {
        Console.Clear();

        Console.WriteLine("\nYou`ve collected:");
        
        Console.WriteLine($"\nCoin: {elems['C'].Count}");
        
        Console.WriteLine($"\nAmethyst: {gems['A'].Count}");
        Console.WriteLine($"Ruby: {gems['R'].Count}");
        Console.WriteLine($"Emerald: {gems['E'].Count}");
        Console.WriteLine($"Diamond: {gems['D'].Count}");
        
        Console.Write("\nPress 'Enter' to go to the menu... ");
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
                break;
        }
    }

    private Gamer SaveItems(Gamer gamer)
    {
        gamer.Money += elems['C'].Count;
        gamer.Amethyst += gems['A'].Count;
        gamer.Ruby += gems['R'].Count;
        gamer.Emerald += gems['E'].Count;
        gamer.Diamond += gems['D'].Count;

        return gamer;
    }
}