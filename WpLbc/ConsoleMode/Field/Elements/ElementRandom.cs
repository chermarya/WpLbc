using Library;

namespace ConsoleMode;

public class ElementRandom : ElementPosition
{
    private Random rand = new Random();

    public static Element SetRandomGem(string pickaxe_name)
    {
        int num = new Random().Next(1, 100 + 1);

        switch (pickaxe_name)
        {
            case "simple_pickaxe":
            {
                if (num <= 40)
                    return gems['A'];
                if (num <= 70)
                    return gems['R'];
                if (num <= 90)
                    return gems['E'];
                return gems['D'];
            }
            case "super_pickaxe":
            {
                if (num <= 40)
                    return gems['R'];
                if (num <= 70)
                    return gems['E'];
                if (num <= 90)
                    return gems['D'];
                return gems['A'];
            }
            default: return gems['A'];
        }
    }

    public ElementGeneral[,] BasePlacement(List<int[]> spaces, ElementGeneral[,] field, out int amount,
        out int[] exitKeyCoordinates)
    {
        amount = rand.Next(3, 6);
        exitKeyCoordinates = new int[2];

        for (int i = 0; i < amount; i++)
        {
            int num = rand.Next(0, spaces.Count);
            field[spaces[num][1], spaces[num][0]] = placement['C']();
            spaces.RemoveAt(num);
        }

        int keyPos = rand.Next(0, spaces.Count);
        exitKeyCoordinates[0] = spaces[keyPos][0];
        exitKeyCoordinates[1] = spaces[keyPos][1];

        return field;
    }

    public ElementGeneral[,] RectangleRandom(int[] leftUp, int[] rightDown, ElementGeneral[,] field, int amount, int exitCoordX, int exitCoordY)
    {
        List<int[]> spaces = new List<int[]>();

        for (int i = leftUp[1]; i <= rightDown[1]; i++)
        {
            for (int j = leftUp[0]; j <= rightDown[0]; j++)
            {
                if (field[i, j].Name == "space" &&
                    exitCoordX != j && exitCoordY != i)
                    spaces.Add(new int[] { j, i });
            }
        }

        RandomPlacement(amount, spaces, field);

        return field;
    }

    public ElementGeneral[,] ArbitraryRandom(int[] Up, int[] Down, ElementGeneral[,] field, int amount, int exitCoordX, int exitCoordY)
    {
        List<int[]> spaces = new List<int[]>();

        for (int i = Up[1]; i <= Down[1]; i++)
        {
            for (int j = Up[0]; field[i, j].Name != "wall"; j++)
            {
                if (field[i, j].Name == "space" &&
                    exitCoordX != j && exitCoordY != i)
                    spaces.Add(new int[] { j, i });
            }
        }

        RandomPlacement(amount, spaces, field);

        return field;
    }

    private bool CanBeElement(int posX, int posY, ElementGeneral[,] field)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                if (field[posY + y, posX + x].Name == "gem")
                    return false;
            }
        }

        return true;
    }

    private void RandomPlacement(int amount, List<int[]> spaces, ElementGeneral[,] field)
    {
        while (amount > 0)
        {
            int pos = rand.Next(0, spaces.Count);
            int x = spaces[pos][0];

            int y = spaces[pos][1];

            if (CanBeElement(x, y, field))
            {
                field[y, x] = placement['G']();
                amount--;
            }

            spaces.RemoveAt(pos);
        }
    }
}