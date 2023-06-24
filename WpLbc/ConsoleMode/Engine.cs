using Library;

namespace ConsoleMode;

public class Engine : ElementPosition
{
    private ElementGeneral[,] _field;
    private int _sideX, _sideY;
    private int _tempX, _tempY;

    private int _exitCoordX, _exitCoordY;
    private int[] _exitKeyCoord;

    private bool isTrue = true;
    
    private static int _posX, _posY;
    public Engine (ElementGeneral[,] field, int posX, int posY, int sideX, int sideY, int exitCoordX, int exitCoordY, int[] exitKeyCoord)
    {
        _field = field;
        _posX = posX;
        _posY = posY;
        _sideX = sideX;
        _sideY = sideY;
        _exitCoordX = exitCoordX;
        _exitCoordY = exitCoordY;
        _exitKeyCoord = exitKeyCoord;
    }

    private Dictionary<ConsoleKey, int[]> steps = new Dictionary<ConsoleKey, int[]>()
    {
        {ConsoleKey.UpArrow, new int[] {0, -1}},
        {ConsoleKey.DownArrow, new int[] {0, 1}},
        {ConsoleKey.LeftArrow, new int[] {-1, 0}},
        {ConsoleKey.RightArrow, new int[] {1, 0}},
    };

    private bool Validate(ConsoleKey step)
    {
        _tempY = _posY;
        _tempX = _posX;

        _posX += steps[step][0];
        _posY += steps[step][1];

        if (_posY >= 0 && _posY < _sideX &&
            _posX >= 0 && _posX < _sideY)
        {
            switch (_field[_posY, _posX].Name)
            {
                case "gem":
                {
                    if (!(elems['S'].Count > 0 || elems['P'].Count > 0))
                    {
                        _posY = _tempY;
                        _posX = _tempX;
                        return false;
                    }
                    break;
                }
                case "door":
                {
                    if (elems['K'].Count > 0)
                    {
                        Console.SetCursorPosition((_sideX + 2) * 3 + 6, 4);
                        Console.Write(--elems['K'].Count);
                        return true;
                    }
                    break;
                }
                case "exit":
                {
                    if (elems['K'].Count > 0)
                    {
                        Console.SetCursorPosition((_sideX + 2) * 3 + 6, 4);
                        Console.Write(--elems['K'].Count);
                        return true;
                    }
                    break;
                }
            }
            
            if (_field[_posY, _posX].Patency)
                return true;
        }
        
        _posY = _tempY;
        _posX = _tempX;
        return false;
    }
    
    public bool Move()
    {
        Console.SetCursorPosition(_tempX * 3, _tempY);
        _field[_tempY, _tempX].PrintElement();
        Console.SetCursorPosition(_posX * 3, _posY);
        _field[_posY, _posX].PrintElement();
        Console.SetCursorPosition(_posX * 3, _posY);
        
        ConsoleKey input = Console.ReadKey().Key;

        if (input == ConsoleKey.Delete)
        {
            foreach (var i in elems.Keys)
            {
                elems[i].Count = 0;
            }
            new MainMenu();
            return false;
        }
        
        if (Validate(input))
        {
            if (_field[_posY, _posX].Name == "exit")
                return false;
            
            _field[_posY, _posX].ElementAction(_sideY, _sideX);

            
            if (elems['G'].Count == 0 && isTrue)
            {
                _field[_exitKeyCoord[1], _exitKeyCoord[0]] = new ExitKey();
                Console.SetCursorPosition(_exitKeyCoord[0] * 3 + 1, _exitKeyCoord[1]);
                Console.Write(elems['e'].Symbol);
                
                _field[_exitCoordY, _exitCoordX] = new Exit();
                Console.SetCursorPosition(_exitCoordX * 3 + 1, _exitCoordY);
                Console.Write(elems['E'].Symbol);

                isTrue = false;
            }
            
            _field[_tempY, _tempX] = new Space();
            _field[_posY, _posX] = new Player();
        }

        return true;
    }
    
    public bool Move(string player_name)
    {
        Console.SetCursorPosition(_tempX * 3, _tempY);
        _field[_tempY, _tempX].PrintElement();
        Console.SetCursorPosition(_posX * 3, _posY);
        _field[_posY, _posX].PrintElement();
        Console.SetCursorPosition(_posX * 3, _posY);
        
        ConsoleKey input = Console.ReadKey().Key;

        if (input == ConsoleKey.Delete)
        {
            foreach (var i in elems.Keys)
            {
                elems[i].Count = 0;
            }
            new PlayerStats(player_name);
            return false;
        }
        
        if (Validate(input))
        {
            if (_field[_posY, _posX].Name == "exit")
                return false;
            
            _field[_posY, _posX].ElementAction(_sideY, _sideX);

            
            if (elems['G'].Count == 0 && isTrue)
            {
                _field[_exitKeyCoord[1], _exitKeyCoord[0]] = new ExitKey();
                Console.SetCursorPosition(_exitKeyCoord[0] * 3 + 1, _exitKeyCoord[1]);
                Console.Write(elems['e'].Symbol);
                
                _field[_exitCoordY, _exitCoordX] = new Exit();
                Console.SetCursorPosition(_exitCoordX * 3 + 1, _exitCoordY);
                Console.Write(elems['E'].Symbol);

                isTrue = false;
            }
            
            _field[_tempY, _tempX] = new Space();
            _field[_posY, _posX] = new Player();
        }

        return true;
    }
}