namespace Library;

public abstract class ElementGeneral
{
    public int Count = 0;
    
    public bool Patency { get; set; }
    public string Name { get; set; }
    
    public char Symbol
    {
        get; set;
    }
    
    public abstract void PrintElement();

    public virtual void ElementAction(int y, int x)
    { }
}