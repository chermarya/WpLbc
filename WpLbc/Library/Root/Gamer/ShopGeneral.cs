﻿namespace Library;

public abstract class ShopGeneral
{
    protected Dictionary<string, int> price = new Dictionary<string, int>()
    {
        {"Amethyst", 2},
        {"Ruby", 4},
        {"Emerald", 7},
        {"Diamond", 10}
    };

    protected Dictionary<int, string> itemNumber = new Dictionary<int, string>()
    {
        {1, "Amethyst"},
        {2, "Ruby"},
        {3, "Emerald"},
        {4, "Diamond"}
    };

    protected abstract void Print();
    protected abstract void ChooseAction();
    protected abstract void Sell();
    protected abstract void Buy();
}