using System.Windows.Controls;

namespace WpfLbc;

public partial class MainField : Page
{
    public MainField()
    {
        InitializeComponent();
        new Field(Field);
    }
}