namespace ConsoleMode;

public class ViewProfile
{
    public ViewProfile(Gamer gamer)
    {
        Console.Clear();

        Console.WriteLine("\n" + gamer.Name.ToUpper());
        
        Console.WriteLine("\nMoney: " + gamer.Money);
        
        Console.WriteLine("\nAmethyst: " + gamer.Amethyst);
        Console.WriteLine("Ruby: " + gamer.Ruby);
        Console.WriteLine("Emerald: " + gamer.Emerald);
        Console.WriteLine("Diamond: " + gamer.Diamond);
        
        Console.Write("\nPress 'Delete' to go back... ");
    }
}