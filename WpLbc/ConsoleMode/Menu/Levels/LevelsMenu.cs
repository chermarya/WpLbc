using Library;

namespace ConsoleMode;

public class LevelsMenu : MenuOutput
{
    public LevelsMenu(MenuItem[] lvls)
        : base(
            lvls,
            "CUSTOM LEVELS",
            ConsoleColor.Cyan)
    { }

    protected override bool ChooseAction(string name)
    {
        return true;
    }
}