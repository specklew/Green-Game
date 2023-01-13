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
        //new ShopItem("Cow Milk", 1),
        //new ShopItem("Oat Milk", 3),
        //new ShopItem("Salmon", 0),
        //new ShopItem("Beef", 0),
        new ShopItem("item1", 1),
        new ShopItem("item2", 2),
        new ShopItem("item3", 3),
        new ShopItem("item01", -1),
        new ShopItem("item02", -2),
        new ShopItem("item03", -3),
    };

    public static List<ShopItem> GenerateRandomItems()
    {
        var items = shopItems.OrderBy(m => rng.Next()).ToList();
        return items.GetRange(0,6);
    }
}
