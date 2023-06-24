namespace Library
{
    public class MenuItem
    {
        public bool selected = false;

        public string title;

        public string name;

        public MenuItem(string title, string name)
        {
            this.name = name;
            this.title = title;
        }
    }
}