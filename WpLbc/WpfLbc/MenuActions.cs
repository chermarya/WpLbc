using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfLbc;

public class MenuActions
{
    public delegate void Action(Frame frame);
    public Dictionary<string, Action> acts = new Dictionary<string, Action>()
    {
        {"Play", Play},
        {"Custom", Custom},
        {"Rules", Rules},
        {"Exit", Exit},
    };
    
    public static void Play(Frame frame)
    {
        frame.Content = new MainField();
    }
    
    public static void Custom(Frame frame)
    {
        frame.Content = new CustomMenu();
    }
    
    public static void Rules(Frame frame)
    {
        frame.Content = new Rules();
    }
    
    public static void Exit(Frame frame)
    {
        Application.Current.Shutdown();
    }

}