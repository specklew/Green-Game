using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ShopItem
{
    public string Name { get; set; }
    public int PointsValue { get; set; }

    public ShopItem(string name, int points)
    {
        Name = name;
        PointsValue = points;
    }
    private static System.Random rng = new System.Random();
    private static List<ShopItem> shopItems = new List<ShopItem>()
    {
        new ShopItem("Beef", -3),
        new ShopItem("Salmon", -2),
        new ShopItem("Cow Milk", -1),
        new ShopItem("Rice", 1),
        new ShopItem("Oat Milk", 2),
        new ShopItem("Fruits", 3)
    };

    public static List<ShopItem> GenerateRandomItems()
    {
        var items = shopItems.OrderBy(m => rng.Next()).ToList();
        return items.GetRange(0,6);
    }
}
