using System.Windows;
using System.Windows.Controls;

namespace WpfLbc;

public partial class MainMenu : Page
{
    private Frame MainFrame;
    private void BtnClck(object sender, RoutedEventArgs e)
    {
        string name = (string)((Button)e.OriginalSource).Content;
        new MenuActions().acts[name](MainFrame);
    }
    
    public MainMenu(Frame MainFrame)
    {
        this.MainFrame = MainFrame;
        
        InitializeComponent();
        
        foreach (UIElement el in Menu.Children)
        {
            if (el is Button)
            {
                ((Button)el).Click += BtnClck;
            }
        }
    }
}