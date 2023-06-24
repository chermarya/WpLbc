using System.Security.Cryptography;
using System.Text;

namespace Library;

public abstract class GamerGeneral
{
    public string Name { get; set; }
    public string Password { get; set; }
    public int Money { get; set; }
    public int Amethyst { get; set; }
    public int Ruby { get; set; }
    public int Emerald { get; set; }
    public int Diamond { get; set; }

    public GamerGeneral(){}

    protected abstract bool ChooseName();
    protected abstract bool ChoosePassword(out string password);
    
    public string GetHash(string input)
    {
        byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(hash);
    }
}