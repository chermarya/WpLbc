using Library;
namespace ConsoleMode;

public class DeletePlayer : MenuOutput
{
    public DeletePlayer(MenuItem[] players)
        : base
        (
            players,
            "PLAYERS",
            ConsoleColor.Yellow
        )
    { }

    protected override bool ChooseAction(string name)
    {
        File.Delete($"../../../../Library/players/{name}.json");
        return false;
    }
}