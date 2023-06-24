using Library;

namespace ConsoleMode;

public class PlayLvl : LevelsMenu
{
    public PlayLvl(MenuItem[] lvls)
        : base(lvls)
    { }
    
    protected override bool ChooseAction(string name)
    {
        if (name == "back")
            return false;
        
        new Field(name, "custom", 0);
        return false;
    }
}