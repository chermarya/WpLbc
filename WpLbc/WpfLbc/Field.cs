using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Library;

namespace WpfLbc;

public class Field
{
    private FileWork file = new FileWork("levels");

    private string[] _lines;

    private Grid _frame;
    private int _sizeX = 10;
    private int _sizeY = 10;

    private Dictionary<char, string> elems = new Dictionary<char, string>()
    {
        { '.', "space" },
        { '#', "wall" },
        { 'U', "player" },
        { 'E', "exit" },
        { 'D', "door" },
        { 'K', "key" },
        { 'C', "coin" },
        { 'P', "pickaxe" },
        { 'G', "gem" }
    };

    public Field(Grid frame)
    {
        _frame = frame;

        _lines = file.ReadField("mainLvl", out _sizeX, out _sizeY);

        for (int i = 0; i < _sizeY; i++)
        {
            _frame.RowDefinitions.Add(new RowDefinition { Height = new GridLength(45, GridUnitType.Pixel) });
        }

        for (int i = 0; i < _sizeX; i++)
        {
            _frame.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(45, GridUnitType.Pixel) });
        }
        
        
        

        for (int i = 0; i < _lines.Length; i++)
        {
            for (int j = 0; j < _lines[i].Length; j++)
            {
                UIElement img = new Image
                {
                    Source = new BitmapImage(new Uri(Environment.CurrentDirectory + $"../../../../img/{elems[_lines[i][j]]}.png",
                        UriKind.Absolute))
                };

                Grid.SetColumn(img, j);
                Grid.SetRow(img, i);
                frame.Children.Add(img);
            }
        }

        foreach (var i in _lines)
        {
            UIElement img = new Image
            {
                Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "../../../../img/wall.png",
                    UriKind.Absolute))
            };

            Grid.SetColumn(img, 1);
            Grid.SetRow(img, 0);
            frame.Children.Add(img);
        }
    }
}