namespace ConsoleMode;

public class NewField : NewFieldSettings
{
    private char[,] field;
    private int posX = 0;
    private int posY = 0;
    private int ind = 0;
    private int tempY, tempX;
    private int sideX, sideY;
    
    public NewField()
    {
        sideX = width;
        sideY = height;
        
        new Field(sideX, sideY, out field);

        while (true)
        {
            while (ChooseItem()) { }

            if (ValidSave())
                break;
        }

        string[] lines = FieldByLines();

        file.SaveField(name, lines);
    }
    
    public NewField(string lvlName) : base(lvlName)
    {
        new Field(lvlName, out field, out sideX, out sideY);

        while (true)
        {
            while (ChooseItem()) { }

            if (ValidSave())
                break;
        }

        string[] lines = FieldByLines();

        file.SaveField(lvlName, lines);
    }

    public bool ChooseItem()
    {
        char[] els = { '.', '#', 'G', 'P', 'K', 'D', 'U', 'E' };

        Console.SetCursorPosition(2 * (posX + 1) + posX, posY + 2);

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(field[posY, posX]);
        Console.ResetColor();

        ConsoleKey move = Console.ReadKey().Key;

        tempY = posY;
        tempX = posX;

        switch (move)
        {
            case ConsoleKey.UpArrow:
                posY -= 1;
                break;
            case ConsoleKey.DownArrow:
                posY += 1;
                break;
            case ConsoleKey.LeftArrow:
                posX -= 1;
                break;
            case ConsoleKey.RightArrow:
                posX += 1;
                break;
            case ConsoleKey.Enter:
            {
                ind = Array.IndexOf(els, field[posY, posX]) + 1;
                
                if (ind < 0)
                    ind += els.Length;
                if (ind > els.Length - 1)
                    ind -= els.Length;
                
                SetItem(posX, posY, els[ind]);
                break;
            }
            case ConsoleKey.Delete:
                return false;
        }

        if (!(posY >= 0 && posY < sideY &&
              posX >= 0 && posX < sideX))
        {
            posY = tempY;
            posX = tempX;
        }

        Console.SetCursorPosition(2 * (tempX + 1) + tempX, tempY + 2);
        Console.Write(field[tempY, tempX]);
        return true;
    }

    private void SetItem(int x, int y, char sym)
    {
        field[y, x] = sym;
        Console.SetCursorPosition(2 * (x + 1) + x, y + 2);
        Console.Write(sym);
    }

    public bool ValidSave()
    {
        int PlayerCount = 0;
        int KeyCount = 0;
        int DoorCount = 0;
        int ExitCount = 0;
        int GemCount = 0;
        int PickaxeCount = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                switch (field[i, j])
                {
                    case 'U': PlayerCount++; break;
                    case 'K': KeyCount++; break;
                    case 'D': DoorCount++; break;
                    case 'E': ExitCount++; break;
                    case 'G': GemCount++; break;
                    case 'P': PickaxeCount++; break;
                }
            }
        }

        Console.SetCursorPosition(0, height + 3);
        Console.Write(string.Concat(Enumerable.Repeat(" ", 100)));
        Console.SetCursorPosition(0, height + 3);
        
        if (PlayerCount != 1)
        {
            Console.WriteLine("There must be 1 player");
            return false;
        }
        if (KeyCount != DoorCount)
        {
            Console.WriteLine("The number of keys should match the number of doors");
            return false;
        }
        if (ExitCount != 1)
        {
            Console.WriteLine("There must be 1 exit");
            return false;
        }
        if (GemCount < 3)
        {
            Console.WriteLine("There must be minimum 3 gems");
            return false;
        }
        if (GemCount != PickaxeCount)
        {
            Console.WriteLine("The number of gems should match the number of pickaxes");
            return false;
        }
        return true;
    }
    
    public string[] FieldByLines()
    {
        string[] _lines = new string[height];
        
        for (byte i = 0; i < height; i++)
        {
            string str = "";
            for (byte j = 0; j < width; j++)
            {
                str += field[i, j];
            }

            _lines[i] = str;
        }

        return _lines;
    }
}