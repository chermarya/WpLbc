using Library;

namespace ConsoleMode;

public class EditLvl : LevelsMenu
{
    public EditLvl(MenuItem[] lvls)
        : base(lvls)
    { }
    
    protected override bool ChooseAction(string name)
    {
        if (name == "back")
            return false;
        
        Console.Clear();
        new NewField(name);
        return false;
    }
}