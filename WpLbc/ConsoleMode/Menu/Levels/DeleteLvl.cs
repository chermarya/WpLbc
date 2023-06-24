using Library;

namespace ConsoleMode;

public class DeleteLvl : LevelsMenu
{
    public DeleteLvl(MenuItem[] lvls)
        : base(lvls)
    { }
    
    protected override bool ChooseAction(string name)
    {
        if (name == "back")
            return false;
        
        new FileWork("levels/custom/").DeleteFile(name);
        return false;
    }
}