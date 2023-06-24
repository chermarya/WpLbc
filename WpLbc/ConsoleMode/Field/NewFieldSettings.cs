using Library;

namespace ConsoleMode;

public class NewFieldSettings
{
    protected FileWork file = new FileWork("levels/custom/");

    protected int width = 10;
    protected int height = 10;
    protected string name;

    protected StreamWriter lvlFile;

    public NewFieldSettings()
    {
        Console.Clear();
        while (Name()) { }

        lvlFile = file.CreateFile(name);
        lvlFile.Close();
        
        Size();
    }

    public NewFieldSettings(string name)
    { }

    private bool Name()
    {
        string[] lvlNames = file.GetNames();

        Console.WriteLine("\nChoose name for your level");
        Console.Write(">>> ");
        name = Console.ReadLine();

        if (name == "")
        {
            Console.WriteLine("Name can not be empty");
            return true;
        }

        foreach (string i in lvlNames)
        {
            if (i == name)
            {
                Console.WriteLine("File with the same name already exists");
                return true;
            }
        }

        return false;
    }

    private void Size()
    {
        Console.Clear();
        Console.WriteLine("\nSize of field\n");
        Console.WriteLine("Minimum size is 10x10");
        Console.WriteLine("Maximum size is 30x30");
        
        while (true)
        {
            Console.Write("\nWidth: ");
            string w = Console.ReadLine();

            if (int.TryParse(w, out width))
            {
                if (width < 10)
                {
                    width = 10;
                }

                if (width > 30)
                {
                    width = 30;
                }

                break;
            }

            Console.WriteLine("Wrong format!");
        }

        while (true)
        {
            Console.Write("Height: ");
            string h = Console.ReadLine();
            if (int.TryParse(h, out height))
            {
                if (height < 10)
                {
                    height = 10;
                }

                if (height > 30)
                {
                    height = 30;
                }

                break;
            }

            Console.WriteLine("Wrong format!");
        }
    }
}